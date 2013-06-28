using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.CodeGenerator.Core.Data;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    [XmlRoot]
    public class Connection : IProjectSchemaElement, IHasAttributes<Connection>
    {
        [XmlIgnore]
        public UserSettings ContainingUserSettings { get; private set; }

        [XmlIgnore]
        public Project ContainingProject { get { return this.ContainingUserSettings.ContainingProject; } }

        [XmlAttribute]
        public string DatabaseType { get; set; }

        [XmlText]
        public string ConnectionString { get; set; }

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<Connection>> Attributes { get; set; }

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations { get { return null; } }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes { get { return this.Attributes; } }

        public Connection()
        {
            this.Attributes = new List<Attribute<Connection>>();
        }

        public void JoinToParent(UserSettings userSettings)
        {
            this.ContainingUserSettings = userSettings;
            this.Attributes.ForEach(o => o.JoinToParent(this));
        }

        public void Validate()
        {

            DatabaseWorker worker = DatabaseWorkerManager.Instance[this.DatabaseType];

            if (worker == null)
                throw new ApplicationException("Could not locate database worker named: {0}.".FormatString(this.DatabaseType));

            worker.ValidateConnection(this.ContainingProject);
        }

        public DatabaseWorker GetDatabaseWorker()
        {
            return DatabaseWorkerManager.Instance[this.DatabaseType];
        }
    }
}
