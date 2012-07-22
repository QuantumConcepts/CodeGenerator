using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    internal class TableMappingComparer : IComparer<TableMapping>
    {
        public int Compare(TableMapping x, TableMapping y)
        {
            return string.Compare(x.TableName, y.TableName, true);
        }
    }
}
