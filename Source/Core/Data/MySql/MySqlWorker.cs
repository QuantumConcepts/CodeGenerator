using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using MySql.Data.MySqlClient;
using QuantumConcepts.Common.Extensions;
using System.Text.RegularExpressions;

namespace QuantumConcepts.CodeGenerator.Core.Data.MySql
{
    public class MySqlWorker : DatabaseWorker
    {
        private const string Parameter_SchemasToShow = "Schemas to Show";

        private static readonly Dictionary<string, string> ParameterNameMap = new Dictionary<string, string>()
        {
            {MySqlWorker.Parameter_SchemasToShow, Regex.Replace(MySqlWorker.Parameter_SchemasToShow, @"\s", "_")}
        };

        public override string Name { get { return "MySQL"; } }

        public override IList<DatabaseParameter> Parameters
        {
            get
            {
                return new List<DatabaseParameter>()
                {
                    new DatabaseParameter(MySqlWorker.Parameter_SchemasToShow, "Enter the schema names you wish to use separated by commas.")
                };
            }
        }

        protected override DataTable GetTables(Project project, Connection connection)
        {
            return GetTablesOrViews(project, connection, "BASE TABLE");
        }

        protected override DataTable GetViews(Project project, Connection connection)
        {
            return GetTablesOrViews(project, connection, "VIEW");
        }

        private DataTable GetTablesOrViews(Project project, Connection connection, string tableType)
        {
            return ExecuteQuery(connection,
                "SELECT " +
                    "t.table_schema AS " + QueryConstants.TableOrView.SchemaName + ", " +
                    "t.table_name AS " + QueryConstants.TableOrView.Name + " " +
                "FROM information_schema.tables t " +
                "WHERE " +
                    "FIND_IN_SET(t.table_schema, @{0}) != 0 ".FormatString(MySqlWorker.ParameterNameMap[MySqlWorker.Parameter_SchemasToShow]) +
                    "AND t.table_type = \"" + tableType + "\"", GetCommonParameters(connection));
        }

        protected override DataTable GetColumns(Project project, Connection connection)
        {
            DataTable dataTable = ExecuteQuery(connection,
                "SELECT " +
                    "CASE t.table_type " +
                        "WHEN \"BASE TABLE\" THEN \"" + QueryConstants.Column.ForTable + "\" " +
                        "WHEN \"VIEW\" THEN \"" + QueryConstants.Column.ForView + "\" " +
                    "END AS \"" + QueryConstants.Column.For + "\", " +
                    "c.table_schema AS " + QueryConstants.TableOrView.SchemaName + ", " +
                    "c.table_name AS " + QueryConstants.TableOrView.Name + ", " +
                    "c.column_name AS " + QueryConstants.Column.Name + ", " +
                    "CONVERT(c.ordinal_position, DECIMAL(65, 0)) AS " + QueryConstants.Column.Sequence + ", " +
                    "c.data_type AS " + QueryConstants.Column.DataType + ", " +
                    "CONVERT(c.character_maximum_length, DECIMAL(65, 0)) AS " + QueryConstants.Column.Length + ", " +
                    "c.column_default AS " + QueryConstants.Column.DefaultValue + ", " +
                    "c.is_nullable AS " + QueryConstants.Column.Nullable + ", " +
                    "IF(c.column_key = \"PRI\", \"YES\", \"NO\") AS " + QueryConstants.Column.PrimaryKey + " " +
                "FROM " +
                    "information_schema.columns c " +
                    "JOIN information_schema.tables t ON t.table_schema = c.table_schema AND t.table_name = c.table_name " +
                "WHERE " +
                    "FIND_IN_SET(t.table_schema, @{0}) != 0 ".FormatString(MySqlWorker.ParameterNameMap[MySqlWorker.Parameter_SchemasToShow]) +
                    "AND t.table_type IN (\"BASE TABLE\", \"VIEW\")", GetCommonParameters(connection));

            return dataTable;
        }

        protected override DataTable GetForeignKeys(Project project, Connection connection)
        {
            return ExecuteQuery(connection,
                "SELECT DISTINCT " +
                    "fk.constraint_name AS " + QueryConstants.ForeignKey.Name + ", " +
                    "ic.table_schema AS " + QueryConstants.ForeignKey.ParentTableSchemaName + ", " +
                    "ic.table_name AS " + QueryConstants.ForeignKey.ParentTableName + ", " +
                    "ic.column_name AS " + QueryConstants.ForeignKey.ParentColumnName + ", " +
                    "ic.referenced_table_schema AS " + QueryConstants.ForeignKey.ReferencedTableSchemaName + ", " +
                    "ic.referenced_table_name AS " + QueryConstants.ForeignKey.ReferencedTableName + ", " +
                    "ic.referenced_column_name AS " + QueryConstants.ForeignKey.ReferencedColumnName + " " +
                "FROM " +
                    "information_schema.table_constraints fk " +
                    "JOIN information_schema.key_column_usage ic ON ic.constraint_name = fk.constraint_name AND ic.table_schema = fk.table_schema AND ic.table_name = fk.table_name " +
                "WHERE " +
                    "FIND_IN_SET(fk.table_schema, @{0}) != 0 ".FormatString(MySqlWorker.ParameterNameMap[MySqlWorker.Parameter_SchemasToShow]) +
                    "AND fk.constraint_type = \"FOREIGN KEY\"", GetCommonParameters(connection));
        }

        protected override DataTable GetUniqueIndices(Project project, Connection connection)
        {
            return ExecuteQuery(connection,
                "SELECT DISTINCT " +
                    "i.constraint_name AS " + QueryConstants.Index.Name + ", " +
                    "ic.table_schema AS " + QueryConstants.TableOrView.SchemaName + ", " +
                    "ic.table_name AS " + QueryConstants.TableOrView.Name + ", " +
                    "ic.column_name AS " + QueryConstants.Column.Name + " " +
                "FROM " +
                    "information_schema.table_constraints i " +
                    "JOIN information_schema.key_column_usage ic ON ic.constraint_name = i.constraint_name AND ic.table_schema = i.table_schema AND ic.table_name = i.table_name " +
                "WHERE " +
                    "FIND_IN_SET(i.table_schema, @{0}) != 0 ".FormatString(MySqlWorker.ParameterNameMap[MySqlWorker.Parameter_SchemasToShow]) +
                    "AND i.constraint_type = \"UNIQUE\"", GetCommonParameters(connection));
        }

        protected override void ExtractColumnInfo(DataRow dr, out string forParent, out string name, out string schemaName, out string tableName, out decimal sequence, out string databaseDataType, out decimal length, out string defaultValue, out bool nullable, out bool primaryKey)
        {
            forParent = dr.TryGetValue<string>(QueryConstants.Column.For);
            name = dr.TryGetValue<string>(QueryConstants.Column.Name);
            schemaName = dr.TryGetValue<string>(QueryConstants.TableOrView.SchemaName);
            tableName = dr.TryGetValue<string>(QueryConstants.TableOrView.Name);
            sequence = dr.TryGetValue<decimal>(QueryConstants.Column.Sequence);
            databaseDataType = dr.TryGetValue<string>(QueryConstants.Column.DataType);
            length = dr.TryGetValue<decimal>(QueryConstants.Column.Length);
            defaultValue = dr.TryGetValue<string>(QueryConstants.Column.DefaultValue);
            nullable = YesNoToBool(dr.TryGetValue<string>(QueryConstants.Column.Nullable));
            primaryKey = YesNoToBool(dr.TryGetValue<string>(QueryConstants.Column.PrimaryKey));
        }

        private bool YesNoToBool(string value)
        {
            return "YES".Equals(value);
        }

        private DataTable ExecuteQuery(Connection connection, string sql)
        {
            return ExecuteQuery(connection, sql, null);
        }

        private MySqlParameter[] GetCommonParameters(Connection connection)
        {
            string value = connection.Attributes.SingleOrDefault(o => o.Key.Equals(MySqlWorker.Parameter_SchemasToShow)).ValueOrDefault(o => o.Value);

            return new MySqlParameter[] { new MySqlParameter(MySqlWorker.ParameterNameMap[MySqlWorker.Parameter_SchemasToShow], value) };
        }

        private DataTable ExecuteQuery(Connection connection, string sql, MySqlParameter[] parameters)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connection.ConnectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, mySqlConnection))
                {
                    DataTable dataTable = new DataTable();

                    if (parameters != null)
                        adapter.SelectCommand.Parameters.AddRange(parameters);

                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }

        public override void ValidateConnection(Connection connection)
        {
            using (MySqlConnection mySqlConnection = new MySqlConnection(connection.ConnectionString))
            {
                mySqlConnection.Open();
            }
        }

        public override IEnumerable<DataTypeMappingConfiguration> GetDataTypeMappingConfigurations()
        {
            yield return new DataTypeMappingConfiguration()
            {
                DatabaseType = this.Name,
                Language = "CSharp",
                DataTypeMappings = new List<DataTypeMapping>()
                {
                    new DataTypeMapping("TINYINT", "byte", true),
                    new DataTypeMapping("SMALLINT", "int16", true),
                    new DataTypeMapping("MEDIUMINT", "int", true),
                    new DataTypeMapping("INT", "int", true),
                    new DataTypeMapping("BIGINT", "Int64", true),
                    new DataTypeMapping("DECIMAL", "decimal", true),
                    new DataTypeMapping("NUMERIC", "decimal", true),
                    new DataTypeMapping("FLOAT", "double", true),
                    new DataTypeMapping("DOUBLE", "double", true),
                    new DataTypeMapping("BIT", "bool", true),
                    new DataTypeMapping("DATE", "DateTime", true),
                    new DataTypeMapping("DATETIME", "DateTime", true),
                    new DataTypeMapping("TIMESTAMP", "DateTime", true),
                    new DataTypeMapping("TIME", "DateTime", true),
                    new DataTypeMapping("YEAR", "byte", true),
                    new DataTypeMapping("CHAR", "string", true),
                    new DataTypeMapping("VARCHAR", "string", false),
                    new DataTypeMapping("BINARY", "byte[]", false),
                    new DataTypeMapping("VARBINARY", "byte[]", false),
                    new DataTypeMapping("BLOB", "byte[]", false),
                    new DataTypeMapping("TEXT", "string", false),
                    new DataTypeMapping("ENUM", "string", false),
                    new DataTypeMapping("SET", "string", false)
                }
            };
        }
    }
}
