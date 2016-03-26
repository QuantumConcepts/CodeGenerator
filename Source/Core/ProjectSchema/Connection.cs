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
    public class Connection : IProjectSchemaElement, IHasAttributes<Connection>
    {
        [XmlIgnore]
        public UserSettings ContainingUserSettings { get; private set; }

        [XmlIgnore]
        public Project ContainingProject { get { return this.ContainingUserSettings.ContainingProject; } }

        [XmlIgnore]
        public ConnectionInfo Info { get { return this.ContainingProject.Connections.SingleOrDefault(o => string.Equals(o.Name, this.Name)); } }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string DatabaseType { get; set; }

        [XmlAttribute]
        public string ConnectionString { get; set; }

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<Connection>> Attributes { get; set; } = new List<Attribute<Connection>>();

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations { get { return null; } }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes { get { return this.Attributes; } }
        
        public void JoinToParent(UserSettings userSettings)
        {
            this.ContainingUserSettings = userSettings;
            this.Attributes.ForEach(o => o.JoinToParent(this));
        }

        public void Validate() {
            if (this.DatabaseType.IsNullOrEmpty())
                throw new EmptyDatabaseWorkerSpecifiedException();
            else {
                DatabaseWorker worker = GetDatabaseWorker();

                if (worker == null)
                    throw new NonExistentDatabaseWorkerSpecifiedException("Could not locate database worker named: {0}.".FormatString(this.DatabaseType));

                worker.ValidateConnection(this);
            }
        }

        public DatabaseWorker GetDatabaseWorker()
        {
            return DatabaseWorkerManager.Instance[this.DatabaseType];
        }

        public string GetDescription()
        {
            const string dataSourceKey = "Data Source";
            const string initialCatalogKey = "Initial Catalog";

            string[] parts = this.ConnectionString?.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, string> info = parts?.Select(o => o.Split('=')).ToDictionary(o => o[0].Trim(), o => o[1].Trim());
            string dataSource = "Unknown";
            string initialCatalog = "Unknown";

            info?.TryGetValue(dataSourceKey, out dataSource);
            info?.TryGetValue(initialCatalogKey, out initialCatalog);

            return $@"{dataSource}\{initialCatalog} ({this.DatabaseType})";
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
