using QuantumConcepts.CodeGenerator.Core.Data;
using QuantumConcepts.CodeGenerator.Core.Exceptions;
using QuantumConcepts.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    [XmlRoot]
    public class ConnectionInfo : IProjectSchemaElement, IHasAttributes<ConnectionInfo>
    {
        [XmlIgnore]
        public Project ContainingProject { get; private set; }
        
        [XmlAttribute]
        public string Name { get; set; }

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<ConnectionInfo>> Attributes { get; set; } = new List<Attribute<ConnectionInfo>>();

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations { get { return null; } }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes { get { return this.Attributes; } }
        
        public void JoinToParent(Project project)
        {
            this.ContainingProject = project;
            this.Attributes.ForEach(o => o.JoinToParent(this));
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
