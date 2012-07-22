using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    public interface IProjectSchemaElement
    {
        Project ContainingProject { get; }
        IEnumerable<IAnnotation> AllAnnotations { get; }
        IEnumerable<IAttribute> AllAttributes { get; }
    }
}
