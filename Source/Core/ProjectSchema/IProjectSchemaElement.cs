using System;
using System.Collections.Generic;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema {
    public interface IProjectSchemaElement
    {
        Guid Id { get; }
        Project ContainingProject { get; }
        IEnumerable<IAnnotation> AllAnnotations { get; }
        IEnumerable<IAttribute> AllAttributes { get; }
    }
}
