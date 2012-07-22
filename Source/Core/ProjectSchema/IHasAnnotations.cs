using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    public interface IHasAnnotations<T>
        where T : IProjectSchemaElement
    {
        List<Annotation<T>> Annotations { get; set; }
    }
}
