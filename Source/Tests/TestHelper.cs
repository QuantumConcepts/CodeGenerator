using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.CodeGenerator.Core.Data.SqlServer;

namespace Tests {
    public class TestHelper {
        public Random Random { get; private set; }

        public TestHelper() {
            this.Random = new Random();
        }

        public TestHelper(int seed) {
            this.Random = new Random(seed);
        }

        public Project CreateProject(int tableCount = 10) {
            Project project = new Project();

            ProjectContext.Initialize(project);

            project.DataTypeMappings = (new SqlServerWorker()).GetDataTypeMappingConfigurations().Single(o => o.Language == "CSharp").DataTypeMappings;

            for (int i = 0; i < tableCount; i++)
                project.TableMappings.Add(CreateTableMapping(project));

            return project;
        }

        public TableMapping CreateTableMapping(Project project) {
            string random = this.Random.Next().ToString();
            string tableName = "Table{0}".FormatString(random);
            string className = "Class{0}".FormatString(random);
            TableMapping table = new TableMapping() {
                ClassName = className,
                SchemaName = "dbo",
                TableName = tableName
            };

            for (int i = 0; i < this.Random.Next(1, 25); i++)
                table.ColumnMappings.Add(CreateColumnMapping(table));

            table.ColumnMappings.First().PrimaryKey = true;
            table.JoinToProject(project);

            return table;
        }

        public ColumnMapping CreateColumnMapping(TableMapping table) {
            string random = this.Random.Next().ToString();
            string columnName = "Column{0}".FormatString(random);
            string fieldName = "Field{0}".FormatString(random);
            DataTypeMapping dataType = table.ContainingProject.DataTypeMappings.Random(this.Random);
            bool nullable = (dataType.Nullable ? this.Random.NextBool() : false);
            ColumnMapping column = new ColumnMapping() {
                ColumnName = columnName,
                DatabaseDataType = dataType.DatabaseDataType,
                DataType = dataType.ApplicationDataType,
                FieldName = fieldName,
                Nullable = nullable,
                NullableInDatabase = nullable
            };

            return column;
        }
    }
}
