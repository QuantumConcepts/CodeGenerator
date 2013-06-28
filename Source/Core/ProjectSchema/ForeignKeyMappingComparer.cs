using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    /// <summary>Compares two ForeignKeyMapping instances.</summary>
    public class ForeignKeyMappingComparer : IComparer<ForeignKeyMapping>
    {
        /// <summary>Determines if two ForeignKeyMappings are equal.</summary>
        /// <param name="a">A ForeignKeyMapping to compare with.</param>
        /// <param name="b">A ForeignKeyMapping to compare with.</param>
        /// <returns>-1 if x is larger; 0 if x and y are the same; or 1 if y is larger.</returns>
        public int Compare(ForeignKeyMapping a, ForeignKeyMapping b)
        {
            int length = Math.Max(a.ParentColumnMapping.Sequence.ToString().Length, b.ParentColumnMapping.Sequence.ToString().Length);
            string aText = a.ParentColumnMapping.TableMapping.TableName + a.ParentColumnMapping.Sequence.ToString().PadLeft(length, '0');
            string bText = b.ParentColumnMapping.TableMapping.TableName + b.ParentColumnMapping.Sequence.ToString().PadLeft(length, '0');

            return string.Compare(aText, bText, true);
        }
    }
}
