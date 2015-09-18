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
                project.Entities.Add(CreateTableMapping(project));

            return project;
        }

        public Entity CreateTableMapping(Project project) {
            string random = this.Random.Next().ToString();
            string tableName = "Table{0}".FormatString(random);
            string className = "Class{0}".FormatString(random);
            Entity table = new Entity() {
                ClassName = className,
                SchemaName = "dbo",
                Name = tableName
            };

            for (int i = 0; i < this.Random.Next(1, 25); i++)
                table.Properties.Add(CreateColumnMapping(table));

            table.Properties.First().PrimaryKey = true;
            table.JoinToProject(project);

            return table;
        }

        public Property CreateColumnMapping(Entity table) {
            string random = this.Random.Next().ToString();
            string columnName = "Column{0}".FormatString(random);
            string fieldName = "Field{0}".FormatString(random);
            DataTypeMapping dataType = table.ContainingProject.DataTypeMappings.Random(this.Random);
            bool nullable = (dataType.Nullable ? this.Random.NextBool() : false);
            Property column = new PropertyMapping() {
                Name = columnName,
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
