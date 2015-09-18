using QuantumConcepts.CodeGenerator.Core.Data;
using QuantumConcepts.CodeGenerator.Core.Exceptions;
using QuantumConcepts.Common.Extensions;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema {

    [XmlRoot]
    public class DatabaseConnection : IProjectSchemaElement, IHasAttributes<DatabaseConnection> {

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
        public List<Attribute<DatabaseConnection>> Attributes { get; set; }

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations { get { return null; } }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes { get { return this.Attributes; } }

        public DatabaseConnection() {
            this.Attributes = new List<Attribute<DatabaseConnection>>();
        }

        public void JoinToParent(UserSettings userSettings) {
            this.ContainingUserSettings = userSettings;
            this.Attributes.ForEach(o => o.JoinToParent(this));
        }

        public void Validate() {
            if (this.DatabaseType.IsNullOrEmpty())
                throw new EmptyDatabaseWorkerSpecifiedException();
            else {
                DatabaseWorker worker = DatabaseWorkerManager.Instance[this.DatabaseType];

                if (worker == null)
                    throw new NonExistentDatabaseWorkerSpecifiedException("Could not locate database worker named: {0}.".FormatString(this.DatabaseType));

                worker.ValidateConnection(this.ContainingProject);
            }
        }

        public DatabaseWorker GetDatabaseWorker() {
            return DatabaseWorkerManager.Instance[this.DatabaseType];
        }
    }
}