using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    public interface IHasReturnParameter<T>
        where T : IProjectSchemaElement
    {
        Parameter<T> ReturnParameter { get; set; }
    }
}
