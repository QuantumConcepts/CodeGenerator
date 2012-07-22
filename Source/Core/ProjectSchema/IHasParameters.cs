using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    public interface IHasParameters<T>
        where T : IProjectSchemaElement
    {
        List<Parameter<T>> Parameters { get; set; }
    }
}
