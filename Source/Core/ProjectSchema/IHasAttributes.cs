using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    public interface IHasAttributes<T>
        where T : IProjectSchemaElement
    {
        List<Attribute<T>> Attributes { get; set; }
    }
}
