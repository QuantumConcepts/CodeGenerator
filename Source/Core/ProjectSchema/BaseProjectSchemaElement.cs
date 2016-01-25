using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema {
    [XmlRoot]
    public abstract class BaseProjectSchemaElement : IProjectSchemaElement {
        [XmlAttribute]
        public Guid Id { get; set; } = Guid.NewGuid();

        [XmlIgnore]
        public virtual Project ContainingProject { get; protected set; }

        [XmlIgnore]
        public abstract IEnumerable<IAnnotation> AllAnnotations { get; }

        [XmlIgnore]
        public abstract IEnumerable<IAttribute> AllAttributes { get; }
    }
}
