using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Extensions;

namespace QuantumConcepts.CodeGenerator.Core.Data.SqlServer
{
    public class SqlServerWorker : DatabaseWorker
    {
        public override string Name { get { return "SQL Server"; } }

        protected override DataTable GetTables(Project project)
        {
            return ExecuteQuery(project,
                "SELECT " +
                    "s.name AS " + QueryConstants.TableOrView.SchemaName + ", " +
                    "t.name AS " + QueryConstants.TableOrView.Name + " " +
                "FROM " +
                    "sys.tables t " +
                    "JOIN sys.schemas s ON s.schema_id = t.schema_id " +
                "WHERE t.type = 'U'");
        }

        protected override DataTable GetViews(Project project)
        {
            return ExecuteQuery(project,
                "SELECT " +
                    "s.name AS " + QueryConstants.TableOrView.SchemaName + ", " +
                    "v.name AS " + QueryConstants.TableOrView.Name + " " +
                "FROM " +
                    "sys.views v " +
                    "JOIN sys.schemas s ON s.schema_id = v.schema_id");
        }

        protected override DataTable GetColumns(Project project)
        {
            return ExecuteQuery(project,
                "( " +
                    "SELECT " +
                        "'" + QueryConstants.Column.ForTable + "' AS [" + QueryConstants.Column.For + "], " +
                        QueryConstants.TableOrView.SchemaName + ", " +
                        QueryConstants.TableOrView.Name + ", " +
                        QueryConstants.Column.Name + ", " +
                        QueryConstants.Column.Sequence + ", " +
                        QueryConstants.Column.DataType + ", " +
                        QueryConstants.Column.Length + ", " +
                        QueryConstants.Column.DefaultValue + ", " +
                        QueryConstants.Column.Nullable + ", " +
                        "CONVERT(BIT, MAX(CONVERT(INT, " + QueryConstants.Column.PrimaryKey + "))) as " + QueryConstants.Column.PrimaryKey + " " +
                    "FROM " +
                    "( " +
                        "SELECT DISTINCT " +
                            "s.name AS " + QueryConstants.TableOrView.SchemaName + ", " +
                            "t.name AS " + QueryConstants.TableOrView.Name + ", " +
                            "c.name AS " + QueryConstants.Column.Name + ", " +
                            "CONVERT(DECIMAL(20, 0), c.column_id) AS " + QueryConstants.Column.Sequence + ", " +
                            "ty.name AS " + QueryConstants.Column.DataType + ", " +
                            "CONVERT(DECIMAL(20, 0), CASE WHEN c.precision = 0 THEN c.max_length ELSE c.precision END) AS " + QueryConstants.Column.Length + ", " +
                            "CASE WHEN dc.name IS NULL THEN NULL ELSE dc.definition END AS " + QueryConstants.Column.DefaultValue + ", " +
                            "c.is_nullable AS " + QueryConstants.Column.Nullable + ", " +
                            "CONVERT(BIT, CASE WHEN kc.name IS NULL THEN 0 ELSE 1 END) AS " + QueryConstants.Column.PrimaryKey + " " +
                        "FROM " +
                            "sys.columns c " +
                            "JOIN sys.types ty ON ty.user_type_id = c.system_type_id " +
                            "JOIN sys.tables t ON t.object_id = c.object_id " +
                            "JOIN sys.schemas s ON s.schema_id = t.schema_id " +
                            "LEFT JOIN sys.default_constraints dc ON dc.parent_column_id = c.column_id AND dc.parent_object_id = t.object_id " +
                            "LEFT JOIN sys.index_columns ic ON ic.object_id = t.object_id AND ic.column_id = c.column_id AND ic.is_included_column = 0 " +
                            "LEFT JOIN sys.key_constraints kc ON kc.parent_object_id = c.object_id AND kc.unique_index_id = ic.index_id AND kc.type = 'PK' " +
                    ") t " +
                    "GROUP BY " +
                        QueryConstants.TableOrView.SchemaName + ", " +
                        QueryConstants.TableOrView.Name + ", " +
                        QueryConstants.Column.Name + ", " +
                        QueryConstants.Column.Sequence + ", " +
                        QueryConstants.Column.DataType + ", " +
                        QueryConstants.Column.Length + ", " +
                        QueryConstants.Column.DefaultValue + ", " +
                        QueryConstants.Column.Nullable + " " +
                ") " +
                "UNION " +
                "( " +
                    "SELECT " +
                        "'" + QueryConstants.Column.ForView + "' AS [" + QueryConstants.Column.For + "], " +
                        QueryConstants.TableOrView.SchemaName + ", " +
                        QueryConstants.TableOrView.Name + ", " +
                        QueryConstants.Column.Name + ", " +
                        QueryConstants.Column.Sequence + ", " +
                        QueryConstants.Column.DataType + ", " +
                        QueryConstants.Column.Length + ", " +
                        QueryConstants.Column.DefaultValue + ", " +
                        QueryConstants.Column.Nullable + ", " +
                        "CONVERT(BIT, MAX(CONVERT(INT, " + QueryConstants.Column.PrimaryKey + "))) as " + QueryConstants.Column.PrimaryKey + " " +
                    "FROM " +
                    "( " +
                        "SELECT DISTINCT " +
                            "s.name AS " + QueryConstants.TableOrView.SchemaName + ", " +
                            "v.name AS " + QueryConstants.TableOrView.Name + ", " +
                            "c.name AS " + QueryConstants.Column.Name + ", " +
                            "CONVERT(DECIMAL(38, 0), c.column_id) AS " + QueryConstants.Column.Sequence + ", " +
                            "ty.name AS " + QueryConstants.Column.DataType + ", " +
                            "CONVERT(DECIMAL(38, 0), CASE WHEN c.precision = 0 THEN c.max_length ELSE c.precision END) AS " + QueryConstants.Column.Length + ", " +
                            "CASE WHEN dc.name IS NULL THEN NULL ELSE dc.definition END AS " + QueryConstants.Column.DefaultValue + ", " +
                            "c.is_nullable AS " + QueryConstants.Column.Nullable + ", " +
                            "CONVERT(BIT, CASE WHEN kc.name IS NULL THEN 0 ELSE 1 END) AS " + QueryConstants.Column.PrimaryKey + " " +
                        "FROM " +
                            "sys.columns c " +
                            "JOIN sys.types ty ON ty.user_type_id = c.system_type_id " +
                            "JOIN sys.views v ON v.object_id = c.object_id " +
                            "JOIN sys.schemas s ON s.schema_id = v.schema_id " +
                            "LEFT JOIN sys.default_constraints dc ON dc.parent_column_id = c.column_id AND dc.parent_object_id = v.object_id " +
                            "LEFT JOIN sys.index_columns ic ON ic.object_id = v.object_id AND ic.column_id = c.column_id AND ic.is_included_column = 0 " +
                            "LEFT JOIN sys.key_constraints kc ON kc.parent_object_id = c.object_id AND kc.unique_index_id = ic.index_id AND kc.type = 'PK' " +
                    ") t " +
                    "GROUP BY " +
                        QueryConstants.TableOrView.SchemaName + ", " +
                        QueryConstants.TableOrView.Name + ", " +
                        QueryConstants.Column.Name + ", " +
                        QueryConstants.Column.Sequence + ", " +
                        QueryConstants.Column.DataType + ", " +
                        QueryConstants.Column.Length + ", " +
                        QueryConstants.Column.DefaultValue + ", " +
                        QueryConstants.Column.Nullable + " " +
                ")");
        }

        protected override DataTable GetForeignKeys(Project project)
        {
            return ExecuteQuery(project,
                "SELECT DISTINCT " +
                    "fk.name AS " + QueryConstants.ForeignKey.Name + ", " +
                    "s.name AS " + QueryConstants.ForeignKey.ParentTableSchemaName + ", " +
                    "t.name AS " + QueryConstants.ForeignKey.ParentTableName + ", " +
                    "c.name AS " + QueryConstants.ForeignKey.ParentColumnName + ", " +
                    "c.column_id, " +
                    "s2.name AS " + QueryConstants.ForeignKey.ReferencedTableSchemaName + ", " +
                    "t2.name AS " + QueryConstants.ForeignKey.ReferencedTableName + ", " +
                    "c2.name AS " + QueryConstants.ForeignKey.ReferencedColumnName + ", " +
                    "c2.column_id " +
                "FROM " +
                    "sys.foreign_keys fk " +
                    "JOIN sys.foreign_key_columns fkc ON fkc.constraint_object_id = fk.object_id " +
                    "JOIN sys.tables t ON t.object_id = fkc.parent_object_id " +
                    "JOIN sys.schemas s ON s.schema_id = t.schema_id " +
                    "JOIN sys.columns c ON c.object_id = t.object_id AND c.column_id = fkc.parent_column_id " +
                    "JOIN sys.tables t2 ON t2.object_id = fkc.referenced_object_id " +
                    "JOIN sys.schemas s2 ON s2.schema_id = t2.schema_id " +
                    "JOIN sys.columns c2 ON c2.object_id = t2.object_id AND c2.column_id = fkc.referenced_column_id");
        }

        protected override DataTable GetUniqueIndices(Project project)
        {
            return ExecuteQuery(project,
                "SELECT DISTINCT " +
                    "i.name AS " + QueryConstants.Index.Name + ", " +
                    "s.name AS " + QueryConstants.TableOrView.SchemaName + ", " +
                    "t.name AS " + QueryConstants.TableOrView.Name + ", " +
                    "c.name AS " + QueryConstants.Column.Name + ", " +
                    "c.column_id " +
                "FROM " +
                    "sys.indexes i " +
                    "JOIN sys.tables t ON t.object_id = i.object_id " +
                    "JOIN sys.schemas s ON s.schema_id = t.schema_id " +
                    "JOIN sys.index_columns ic ON ic.object_id = i.object_id AND ic.index_id = i.index_id " +
                    "JOIN sys.columns c ON c.object_id = ic.object_id AND c.column_id = ic.column_id " +
                "WHERE " +
                    "i.is_unique = 1 " +
                    "AND i.is_primary_key = 0 " +
                    "AND i.is_disabled = 0");
        }

        private DataTable ExecuteQuery(Project project, string sql)
        {
            return ExecuteQuery(project, sql, null);
        }

        private DataTable ExecuteQuery(Project project, string sql, SqlParameter[] parameters)
        {
            using (SqlConnection connection = new SqlConnection(project.UserSettings.Connection.ConnectionString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(sql, connection))
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
            using (SqlConnection connection = new SqlConnection(project.UserSettings.Connection.ConnectionString))
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
                    new DataTypeMapping("BIGINT", "Int64", true),
                    new DataTypeMapping("BINARY", "byte[]", false),
                    new DataTypeMapping("TIMESTAMP", "byte[]", false),
                    new DataTypeMapping("BIT", "bool", true),
                    new DataTypeMapping("CHAR", "char", true),
                    new DataTypeMapping("MONEY", "decimal", true),
                    new DataTypeMapping("SMALLMONEY", "decimal", true),
                    new DataTypeMapping("DATETIME", "DateTime", true),
                    new DataTypeMapping("SMALLDATETIME", "DateTime", true),
                    new DataTypeMapping("FLOAT", "double", true),
                    new DataTypeMapping("UNIQUEIDENTIFIER", "Guid", true),
                    new DataTypeMapping("IDENTITY", "int", true),
                    new DataTypeMapping("INT", "int", true),
                    new DataTypeMapping("IMAGE", "byte[]", false),
                    new DataTypeMapping("TEXT", "string", false),
                    new DataTypeMapping("NTEXT", "string", false),
                    new DataTypeMapping("DECIMAL", "decimal", true),
                    new DataTypeMapping("NUMERIC", "decimal", true),
                    new DataTypeMapping("REAL", "single", true),
                    new DataTypeMapping("SMALLINT", "int16", true),
                    new DataTypeMapping("TINYINT", "byte", true),
                    new DataTypeMapping("VARBINARY", "byte[]", false),
                    new DataTypeMapping("VARCHAR", "string", false),
                    new DataTypeMapping("SQL_VARIANT", "object", false),
                    new DataTypeMapping("NVARCHAR", "string", false),
                    new DataTypeMapping("NCHAR", "string", false)
                }
            };
        }
    }
}
