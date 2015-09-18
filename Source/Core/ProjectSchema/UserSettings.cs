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

        [XmlElement]
        public DatabaseConnection Connection { get; set; }

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations { get { return null; } }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes { get { return null; } }

        public UserSettings()
        {
            this.Connection = new DatabaseConnection();
        }

        public void JoinToProject(Project project)
        {
            this.ContainingProject = project;
            this.Connection.JoinToParent(this);
        }
    }
}