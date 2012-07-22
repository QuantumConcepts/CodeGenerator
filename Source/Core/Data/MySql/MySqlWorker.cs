using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using MySql.Data.MySqlClient;
using QuantumConcepts.Common.Extensions;

namespace QuantumConcepts.CodeGenerator.Core.Data.MySql
{
    internal class MySqlWorker : DatabaseWorker
    {
        private const string Parameter_SchemasToShow = "Schemas to Show";

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

        protected override DataTable GetTables(Project project)
        {
            return GetTablesOrViews(project, "BASE TABLE");
        }

        protected override DataTable GetViews(Project project)
        {
            return GetTablesOrViews(project, "VIEW");
        }

        private DataTable GetTablesOrViews(Project project, string tableType)
        {
            return ExecuteQuery(project,
                "SELECT " +
                    "t.table_schema AS " + QueryConstants.TableOrView.SchemaName + ", " +
                    "t.table_name AS " + QueryConstants.TableOrView.Name + " " +
                "FROM information_schema.tables t " +
                "WHERE " +
                    "FIND_IN_SET(t.table_schema, @SchemasToShow) != 0 " +
                    "AND t.table_type = \"" + tableType + "\"", GetCommonParameters(project));
        }

        protected override DataTable GetColumns(Project project)
        {
            DataTable dataTable = ExecuteQuery(project,
                "SELECT " +
                    "CASE t.table_type " +
                        "WHEN \"BASE TABLE\" THEN \"" + QueryConstants.Column.ForTable + "\" " +
                        "WHEN \"VIEW\" THEN \"" + QueryConstants.Column.ForView + "\" " +
                    "END AS \"" + QueryConstants.Column.For + "\", " +
                    "c.table_schema AS " + QueryConstants.TableOrView.SchemaName + ", " +
                    "c.table_name AS " + QueryConstants.TableOrView.Name + ", " +
                    "c.column_name AS " + QueryConstants.Column.Name + ", " +
                    "c.ordinal_position AS " + QueryConstants.Column.Sequence + ", " +
                    "c.data_type AS " + QueryConstants.Column.DataType + ", " +
                    "c.character_maximum_length AS " + QueryConstants.Column.Length + ", " +
                    "c.column_default AS " + QueryConstants.Column.DefaultValue + ", " +
                    "c.is_nullable AS " + QueryConstants.Column.Nullable + ", " +
                    "c.column_key AS " + QueryConstants.Column.PrimaryKey + " " +
                "FROM " +
                    "information_schema.columns c " +
                    "JOIN information_schema.tables t ON t.table_schema = c.table_schema AND t.table_name = c.table_name " +
                "WHERE " +
                    "FIND_IN_SET(t.table_schema, @SchemasToShow) != 0 " +
                    "AND t.table_type IN (\"BASE TABLE\", \"VIEW\")", GetCommonParameters(project));

            return dataTable;
        }

        protected override DataTable GetForeignKeys(Project project)
        {
            return ExecuteQuery(project,
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
                    "FIND_IN_SET(fk.table_schema, @SchemasToShow) != 0 " +
                    "AND fk.constraint_type = \"FOREIGN KEY\"", GetCommonParameters(project));
        }

        protected override DataTable GetUniqueIndices(Project project)
        {
            return ExecuteQuery(project,
                "SELECT DISTINCT " +
                    "i.constraint_name AS " + QueryConstants.Index.Name + ", " +
                    "ic.table_schema AS " + QueryConstants.TableOrView.SchemaName + ", " +
                    "ic.table_name AS " + QueryConstants.TableOrView.Name + ", " +
                    "ic.column_name AS " + QueryConstants.Column.Name + " " +
                "FROM " +
                    "information_schema.table_constraints i " +
                    "JOIN information_schema.key_column_usage ic ON ic.constraint_name = i.constraint_name AND ic.table_schema = i.table_schema AND ic.table_name = i.table_name " +
                "WHERE " +
                    "FIND_IN_SET(i.table_schema, @SchemasToShow) != 0 " +
                    "AND i.constraint_type = \"UNIQUE\"", GetCommonParameters(project));
        }

        protected override void ExtractColumnInfo(DataRow dr, out string forParent, out string name, out string schemaName, out string tableName, out UInt64 sequence, out string databaseDataType, out UInt64 length, out string defaultValue, out bool nullable, out bool primaryKey)
        {
            forParent = dr.TryGetValue<string>(QueryConstants.Column.For);
            name = dr.TryGetValue<string>(QueryConstants.Column.Name);
            schemaName = dr.TryGetValue<string>(QueryConstants.TableOrView.SchemaName);
            tableName = dr.TryGetValue<string>(QueryConstants.TableOrView.Name);
            sequence = dr.TryGetValue<UInt64>(QueryConstants.Column.Sequence);
            databaseDataType = dr.TryGetValue<string>(QueryConstants.Column.DataType);
            length = dr.TryGetValue<UInt64>(QueryConstants.Column.Length);
            defaultValue = dr.TryGetValue<string>(QueryConstants.Column.DefaultValue);
            nullable = YesNoToBool(dr.TryGetValue<string>(QueryConstants.Column.Nullable));
            primaryKey = YesNoToBool(dr.TryGetValue<string>(QueryConstants.Column.PrimaryKey));
        }

        private bool YesNoToBool(string value)
        {
            return "YES".Equals(value);
        }

        private DataTable ExecuteQuery(Project project, string sql)
        {
            return ExecuteQuery(project, sql, null);
        }

        private MySqlParameter[] GetCommonParameters(Project project)
        {
            string value = project.UserSettings.Connection.Attributes.SingleOrDefault(o => o.Key.Equals(Parameter_SchemasToShow)).ValueOrDefault(o => o.Value);

            return new MySqlParameter[] { new MySqlParameter("SchemasToShow", value) };
        }

        private DataTable ExecuteQuery(Project project, string sql, MySqlParameter[] parameters)
        {
            using (MySqlConnection connection = new MySqlConnection(project.UserSettings.Connection.ConnectionString))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(sql, connection))
                {
                    DataTable dataTable = new DataTable();

                    if (parameters != null)
                        adapter.SelectCommand.Parameters.AddRange(parameters);

                    adapter.Fill(dataTable);

                    return dataTable;
                }
            }
        }

        public override void ValidateConnection(Project project)
        {
            using (MySqlConnection connection = new MySqlConnection(project.UserSettings.Connection.ConnectionString))
            {
                connection.Open();
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
