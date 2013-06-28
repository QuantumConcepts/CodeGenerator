using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    public class ColumnMappingComparer : IComparer<ColumnMapping>
    {
        public int Compare(ColumnMapping a, ColumnMapping b)
        {
            int length = Math.Max(a.Sequence.ToString().Length, b.Sequence.ToString().Length);

            return string.Compare(a.Sequence.ToString().PadLeft(length, '0'), b.Sequence.ToString().PadLeft(length, '0'), true);
        }
    }
}
