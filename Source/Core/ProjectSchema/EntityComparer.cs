using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    public class EntityComparer : IComparer<Entity>
    {
        public int Compare(Entity x, Entity y)
        {
            return string.Compare(x.Name, y.Name, true);
        }
    }
}
