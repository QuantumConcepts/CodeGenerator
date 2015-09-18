using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using QuantumConcepts.CodeGenerator.Core.Utils;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Linq;
using QuantumConcepts.Common.Extensions;
using System.Xml.Linq;
using QuantumConcepts.Common.Utils;
using QuantumConcepts.CodeGenerator.Core.Upgrade;

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
        public UserSettings UserSettings { get; set; }

        [XmlArray]
        [XmlArrayItem]
        public List<Template> Templates { get; set; } = new List<Template>();

        [XmlArray]
        [XmlArrayItem(ElementName = "DatabaseModel", Type = typeof(DatabaseModel))]
        [XmlArrayItem(ElementName = "ConceptualModel", Type = typeof(Model))]
        public List<Model> Models { get; set; } = new List<Model>();
        
        [XmlArray]
        [XmlArrayItem]
        public List<EntityRelationship> ForeignKeyMappings { get; set; } = new List<EntityRelationship>();

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
                foreach (IAnnotation annotation in this.DataTypeMappings.SelectMany(o => o.AllAnnotations).Union(this.Entities.SelectMany(o => o.AllAnnotations)).Union(this.ForeignKeyMappings.SelectMany(o => o.AllAnnotations)))
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
                    .Union(this.Entities.SelectMany(o => o.AllAttributes))
                    .Union(this.ForeignKeyMappings.SelectMany(o => o.AllAttributes)))
                {
                    yield return attribute;
                }
            }
        }

        public Project()
        {
            this.UserSettings = new UserSettings();
            this.DataTypeMappings = new List<DataTypeMapping>();
            this.Templates = new List<Template>();
            this.Entities = new List<Entity>();
            this.ViewMappings = new List<ViewEntity>();
            this.ForeignKeyMappings = new List<EntityRelationship>();
            this.Attributes = new List<Attribute<Project>>();

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
            this.UserSettings.JoinToProject(this);
            this.DataTypeMappings.ForEach(o => o.JoinToProject(this));
            this.Templates.ForEach(o => o.JoinToProject(this));
            this.Entities.ForEach(o => o.JoinToProject(this));
            this.ViewMappings.ForEach(o => o.JoinToProject(this));
            this.ForeignKeyMappings.ForEach(o => o.JoinToModel(this));
        }

        public DataTypeMapping FindDataTypeMapping(string databaseDataType)
        {
            return this.DataTypeMappings.SingleOrDefault(o => o.DatabaseDataType.EqualsIgnoreCase(databaseDataType));
        }

        public Entity FindTableMapping(string schemaName, string name)
        {
            return this.Entities.SingleOrDefault(o => o.SchemaName.EqualsIgnoreCase(schemaName) && o.Name.EqualsIgnoreCase(name));
        }

        public Template FindTemplate(string xsltAbsolutePath)
        {
            return this.Templates.SingleOrDefault(o => o.XsltAbsolutePath.EqualsIgnoreCase(xsltAbsolutePath));
        }

        public ViewEntity FindViewMapping(string schemaName, string name)
        {
            return this.ViewMappings.SingleOrDefault(vm => vm.SchemaName.EqualsIgnoreCase(schemaName) && vm.Name.EqualsIgnoreCase(name));
        }

        public EntityRelationship FindForeignKeyMapping(string name)
        {
            return this.ForeignKeyMappings.SingleOrDefault(o => o.Name.EqualsIgnoreCase(name));
        }

        public EntityRelationship FindForeignKeyMappingForParentColumn(Property parentColumn)
        {
            return this.ForeignKeyMappings.SingleOrDefault(o => o.ParentColumnMapping.Equals(parentColumn));
        }

        public void SortAll()
        {
            this.Entities.Sort(new EntityComparer());
            this.ForeignKeyMappings.Sort(new EntityRelationshipComparer());

            foreach (Entity tm in this.Entities)
                tm.Properties.Sort(new PropertyComparer());
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