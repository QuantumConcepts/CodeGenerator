using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    public class PropertyComparer : IComparer<Property>
    {
        public int Compare(Property a, Property b)
        {
            int length = Math.Max(a.Sequence.ToString().Length, b.Sequence.ToString().Length);

            return string.Compare(a.Sequence.ToString().PadLeft(length, '0'), b.Sequence.ToString().PadLeft(length, '0'), true);
        }
    }
}
