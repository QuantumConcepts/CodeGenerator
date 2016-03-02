using System.Collections.Generic;
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

        public Connection GetConnection()
        {
            return this.ContainingProject.UserSettings.Connections.SingleOrDefault(o => string.Equals(this.Name, o.Name));
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
