using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.Data;

namespace QuantumConcepts.CodeGenerator.Core.Data.Oracle
{
    internal class OracleWorker : DatabaseWorker
    {
        public override string Name { get { return "Oracle"; } }

        protected override DataTable GetTables(Project project)
        {
            throw new NotImplementedException();
        }

        protected override DataTable GetViews(Project project)
        {
            throw new NotImplementedException();
        }

        protected override DataTable GetColumns(Project project)
        {
            throw new NotImplementedException();
        }

        protected override DataTable GetForeignKeys(Project project)
        {
            throw new NotImplementedException();
        }

        protected override DataTable GetUniqueIndices(Project project)
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<DataTypeMappingConfiguration> GetDataTypeMappingConfigurations()
        {
            yield return new DataTypeMappingConfiguration()
            {
                DatabaseType = this.Name,
                Language = "CSharp",
                DataTypeMappings = new List<DataTypeMapping>()
                {
                    new DataTypeMapping("INTEGER", "int", true),
                    new DataTypeMapping("REAL", "java.math.BigDecimal", true),
                    new DataTypeMapping("NUMBER", "java.math.BigDecimal", true),
                    new DataTypeMapping("DOUBLE", "decimal", true),
                    new DataTypeMapping("FLOAT", "decimal", true),
                    new DataTypeMapping("DECIMAL", "decimal", true),
                    new DataTypeMapping("CHAR", "string", false),
                    new DataTypeMapping("VARCHAR", "string", false),
                    new DataTypeMapping("VARCHAR2", "string", false),
                    new DataTypeMapping("NVARCHAR2", "string", false),
                    new DataTypeMapping("LONG", "string", false),
                    new DataTypeMapping("RAW", "byte[]", false),
                    new DataTypeMapping("LONGRAW", "byte[]", false),
                    new DataTypeMapping("DATE", "DateTime", true),
                    new DataTypeMapping("BLOB", "string", false),
                    new DataTypeMapping("CLOB", "string", false),
                    new DataTypeMapping("NCLOB", "string", false)
                }
            };

            yield return new DataTypeMappingConfiguration()
            {
                DatabaseType = this.Name,
                Language = "Java",
                DataTypeMappings = new List<DataTypeMapping>()
                {
                    new DataTypeMapping("INTEGER", "int", false),
                    new DataTypeMapping("REAL", "java.math.BigDecimal", false),
                    new DataTypeMapping("NUMBER", "java.math.BigDecimal", false),
                    new DataTypeMapping("DOUBLE", "double", false),
                    new DataTypeMapping("FLOAT", "double", false),
                    new DataTypeMapping("DECIMAL", "java.math.BigDecimal", false),
                    new DataTypeMapping("CHAR", "String", false),
                    new DataTypeMapping("VARCHAR", "String", false),
                    new DataTypeMapping("VARCHAR2", "String", false),
                    new DataTypeMapping("NVARCHAR2", "String", false),
                    new DataTypeMapping("LONG", "sqlj.runtime.CharacterStream", false),
                    new DataTypeMapping("RAW", "sqlj.runtime.BinaryStream", false),
                    new DataTypeMapping("LONGRAW", "sqlj.runtime.BinaryStream", false),
                    new DataTypeMapping("DATE", "java.util.GregorianCalendar", false),
                    new DataTypeMapping("BLOB", "java.sql.Blob", false),
                    new DataTypeMapping("CLOB", "java.sql.Clob", false),
                    new DataTypeMapping("NCLOB", "java.sql.NClob", false)
                }
            };
        }

        public override IDbConnection GetConnection(Connection connection)
        {
            throw new NotImplementedException();
        }
    }
}
