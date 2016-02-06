using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    [XmlRoot(Namespace = UserSettings.XmlNamespace)]
    public class UserSettings : IProjectSchemaElement
    {
        [XmlIgnore]
        public const string XmlNamespace = "http://Schemas.QuantumConceptsCorp.com/CodeGenerator/UserSettings.xsd";

        [XmlIgnore]
        public Project ContainingProject { get; private set; }

        [XmlArray]
        [XmlArrayItem]
        public List<Connection> Connections { get; set; } = new List<Connection>();

        [XmlAttribute]
        public bool ShowExcludedItems { get; set; }

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations { get { return null; } }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes { get { return null; } }
        
        public void JoinToProject(Project project)
        {
            this.ContainingProject = project;
            this.Connections.ForEach(o => o.JoinToParent(this));
        }
    }
}