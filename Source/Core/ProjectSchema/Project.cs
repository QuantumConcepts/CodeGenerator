using QuantumConcepts.CodeGenerator.Core.Utils;
using QuantumConcepts.Common.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    [XmlRoot(Namespace = Project.XmlNamespace)]
    public class Project : IProjectSchemaElement, IHasAttributes<Project>
    {
        [XmlIgnore]
        public const string XmlNamespace = "http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Project.xsd";

        [XmlIgnore]
        public string Path { get; private set; }

        [XmlAttribute]
        public string Version { get; set; }

        [XmlAttribute]
        public string RootNamespace { get; set; }

        [XmlIgnore]
        public UserSettings UserSettings { get; set; } = new UserSettings();

        [XmlArray]
        [XmlArrayItem]
        public List<ConnectionInfo> Connections { get; set; } = new List<ConnectionInfo>();

        [XmlArray]
        [XmlArrayItem]
        public List<DataTypeMapping> DataTypeMappings { get; set; } = new List<DataTypeMapping>();

        [XmlArray]
        [XmlArrayItem]
        public List<Template> Templates { get; set; } = new List<Template>();

        [XmlArray]
        [XmlArrayItem]
        public List<TableMapping> TableMappings { get; set; } = new List<TableMapping>();

        [XmlIgnore]
        public IEnumerable<TableMapping> IncludedTableMappings { get { return this.TableMappings.Where(o => !o.Exclude); } }

        [XmlArray]
        [XmlArrayItem]
        public List<ViewMapping> ViewMappings { get; set; } = new List<ViewMapping>();

        [XmlArray]
        [XmlArrayItem]
        public List<ForeignKeyMapping> ForeignKeyMappings { get; set; } = new List<ForeignKeyMapping>();

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<Project>> Attributes { get; set; } = new List<Attribute<Project>>();

        [XmlIgnore]
        public Project ContainingProject
        {
            get { return this; }
        }

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations
        {
            get
            {
                foreach (IAnnotation annotation in this.DataTypeMappings.SelectMany(o => o.AllAnnotations).Union(this.TableMappings.SelectMany(o => o.AllAnnotations)).Union(this.ForeignKeyMappings.SelectMany(o => o.AllAnnotations)))
                    yield return annotation;
            }
        }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes
        {
            get
            {
                foreach (IAttribute attribute in this.Attributes
                    .Union(this.DataTypeMappings.SelectMany(o => o.AllAttributes))
                    .Union(this.Templates.SelectMany(o => o.AllAttributes))
                    .Union(this.TableMappings.SelectMany(o => o.AllAttributes))
                    .Union(this.ForeignKeyMappings.SelectMany(o => o.AllAttributes)))
                {
                    yield return attribute;
                }
            }
        }

        public Project()
        {
            Initialize();
        }

        public XDocument GetXDocument(out XmlNamespaceManager nsm)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Project));

            using (Stream stream = new MemoryStream())
            {
                serializer.Serialize(stream, this);
                stream.Position = 0;

                using (XmlReader reader = XmlReader.Create(stream))
                {
                    XDocument document = XDocument.Load(reader);

                    nsm = XmlUtil.GetXmlNamespaceManager(reader);

                    return document;
                }
            }
        }

        private void Initialize()
        {
            EnsureConnectionsExist();

            this.UserSettings.JoinToProject(this);
            this.Connections.ForEach(o => o.JoinToParent(this));
            this.DataTypeMappings.ForEach(o => o.JoinToProject(this));
            this.Templates.ForEach(o => o.JoinToProject(this));
            this.TableMappings.ForEach(o => o.JoinToProject(this));
            this.ViewMappings.ForEach(o => o.JoinToProject(this));
            this.ForeignKeyMappings.ForEach(o => o.JoinToProject(this));
        }

        private void EnsureConnectionsExist()
        {
            var connectionNames = this.Connections.Select(o => o.Name).Union(this.UserSettings.Connections.Select(o => o.Name)).Distinct().ToList();

            this.Connections.AddRange((from name in connectionNames
                                       where !this.Connections.Any(o => string.Equals(o.Name, name))
                                       select new ConnectionInfo
                                       {
                                           Name = name
                                       }));

            this.UserSettings.Connections.AddRange((from name in connectionNames
                                                    where !this.UserSettings.Connections.Any(o => string.Equals(o.Name, name))
                                                    select new Connection
                                                    {
                                                        Name = name
                                                    }));
        }

        public DataTypeMapping FindDataTypeMapping(string databaseDataType)
        {
            return this.DataTypeMappings.SingleOrDefault(o => o.DatabaseDataType.EqualsIgnoreCase(databaseDataType));
        }

        public TableMapping FindTableMapping(string connectionName, string schemaName, string name)
        {
            return this.TableMappings.SingleOrDefault(o =>
                o.ConnectionName.EqualsIgnoreCase(connectionName)
                && o.SchemaName.EqualsIgnoreCase(schemaName)
                && o.TableName.EqualsIgnoreCase(name));
        }

        public Template FindTemplate(string xsltAbsolutePath)
        {
            return this.Templates.SingleOrDefault(o => o.XsltAbsolutePath.EqualsIgnoreCase(xsltAbsolutePath));
        }

        public ViewMapping FindViewMapping(string connectionName, string schemaName, string name)
        {
            return this.ViewMappings.SingleOrDefault(o =>
                o.ConnectionName.EqualsIgnoreCase(connectionName)
                && o.SchemaName.EqualsIgnoreCase(schemaName)
                && o.TableName.EqualsIgnoreCase(name));
        }

        public ForeignKeyMapping FindForeignKeyMapping(string connectionName, string name)
        {
            return this.ForeignKeyMappings.SingleOrDefault(o =>
                o.ConnectionName.EqualsIgnoreCase(connectionName)
                && o.ForeignKeyName.EqualsIgnoreCase(name));
        }

        public ForeignKeyMapping FindForeignKeyMappingForParentColumn(ColumnMapping parentColumn)
        {
            return this.ForeignKeyMappings.SingleOrDefault(o => o.ParentColumnMapping.Equals(parentColumn));
        }

        public void SortAll()
        {
            this.TableMappings.Sort(new TableMappingComparer());
            this.ForeignKeyMappings.Sort(new ForeignKeyMappingComparer());

            foreach (TableMapping tm in this.TableMappings)
                tm.ColumnMappings.Sort(new ColumnMappingComparer());
        }

        public void Save()
        {
            string userSettingsFileName = this.Path + "u";

            this.Version = CommonUtil.GetApplicationVersion().ToString();

            if (File.Exists(this.Path))
                File.Delete(this.Path);

            if (File.Exists(userSettingsFileName))
                File.Delete(userSettingsFileName);

            using (FileStream stream = File.Open(this.Path, FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Project));

                serializer.Serialize(stream, this);
            }

            using (FileStream stream = File.Open(userSettingsFileName, FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(UserSettings));

                serializer.Serialize(stream, this.UserSettings);
            }
        }

        public void SaveAs(string fileName)
        {
            this.Path = fileName;
            Save();
        }

        public static Project Open(string path)
        {
            Project project = OpenProjectFile<Project>(path);

            //Set the user settings if available.
            project.Path = path;

            try
            {
                project.UserSettings = OpenProjectFile<UserSettings>(path + "u");
            }
            catch (FileNotFoundException) { }
            catch (Exception ex)
            {
                throw new ApplicationException("An error occurred while loading the User Settings.", ex);
            }

            if (project.UserSettings == null)
                project.UserSettings = new UserSettings();

            project.Initialize();

            return project;
        }

        private static T OpenProjectFile<T>(string path) where T : new()
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Project file '" + path + "' could not be opened.");

            T deserializedObject = default(T);
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            using (FileStream stream = File.OpenRead(path))
            {
                deserializedObject = (T)serializer.Deserialize(stream);
            }

            return deserializedObject;
        }
    }
}