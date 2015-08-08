using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.CodeGenerator.Core.Utils;
using System.Linq;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    [XmlRoot(TableMapping.ElementName)]
    public class TableMapping : IProjectSchemaElement, IHasAnnotations<TableMapping>, IHasAttributes<TableMapping>
    {
        public const string ElementName = "TableMapping";

        protected Project _project;
        protected string _schemaName;
        protected string _tableName;
        protected string _className;
        protected string _pluralClassName;
        protected bool _readOnly;
        protected bool _exclude = false;
        protected List<ColumnMapping> _columnMappings = new List<ColumnMapping>();
        protected List<UniqueIndexMapping> _uniqueIndexMappings = new List<UniqueIndexMapping>();
        protected List<API> _apis = new List<API>();
        protected List<Annotation<TableMapping>> _annotations = new List<Annotation<TableMapping>>();
        protected List<Attribute<TableMapping>> _attributes = new List<Attribute<TableMapping>>();

        [XmlIgnore]
        public Project ContainingProject
        {
            get { return (_project == null ? ProjectContext.Project : _project); }
        }

        [XmlAttribute]
        public string SchemaName
        {
            get { return _schemaName; }
            set { _schemaName = value; }
        }

        [XmlAttribute]
        public virtual string TableName
        {
            get { return _tableName; }
            set { _tableName = value; }
        }

        [XmlAttribute]
        public string ClassName
        {
            get { return _className; }
            set { _className = value; }
        }

        [XmlAttribute]
        public string PluralClassName
        {
            get { return _pluralClassName; }
            set { _pluralClassName = value; }
        }

        [XmlAttribute]
        public virtual bool ReadOnly
        {
            get { return _readOnly; }
            set { _readOnly = value; }
        }

        [XmlAttribute]
        public bool Exclude
        {
            get { return _exclude; }
            set { _exclude = value; }
        }

        [XmlArray]
        [XmlArrayItem]
        public List<ColumnMapping> ColumnMappings
        {
            get { return _columnMappings; }
            set { _columnMappings = value; }
        }

        [XmlArray]
        [XmlArrayItem]
        public List<UniqueIndexMapping> UniqueIndexMappings
        {
            get { return _uniqueIndexMappings; }
            set { _uniqueIndexMappings = value; }
        }

        [XmlArray]
        [XmlArrayItem]
        public List<API> APIs
        {
            get { return _apis; }
            set { _apis = value; }
        }

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public List<Annotation<TableMapping>> Annotations
        {
            get { return _annotations; }
            set { _annotations = value; }
        }

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<TableMapping>> Attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }

        [XmlIgnore]
        public List<ColumnMapping> PrimaryKeyColumnMappings
        {
            get
            {
                List<ColumnMapping> primaryKeyColumnMappings = new List<ColumnMapping>();

                foreach (ColumnMapping cm in _columnMappings)
                    if (cm.PrimaryKey)
                        primaryKeyColumnMappings.Add(cm);

                return primaryKeyColumnMappings;
            }
        }

        [XmlIgnore]
        public List<ColumnMapping> NonPrimaryKeyColumnMappings
        {
            get
            {
                List<ColumnMapping> nonPrimaryKeyColumnMappings = new List<ColumnMapping>();

                foreach (ColumnMapping cm in _columnMappings)
                    if (!cm.PrimaryKey)
                        nonPrimaryKeyColumnMappings.Add(cm);

                return nonPrimaryKeyColumnMappings;
            }
        }

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations
        {
            get
            {
                foreach (IAnnotation annotation in _annotations.Union(_columnMappings.SelectMany(o => o.AllAnnotations)).Union(_uniqueIndexMappings.SelectMany(o => o.AllAnnotations)).Union(_apis.SelectMany(o => o.AllAnnotations)))
                    yield return annotation;
            }
        }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes
        {
            get
            {
                foreach (IAttribute attribute in this.Attributes.Union(_columnMappings.SelectMany(o => o.AllAttributes)).Union(_uniqueIndexMappings.SelectMany(o => o.AllAttributes)).Union(_annotations.SelectMany(o => o.AllAttributes)).Union(_apis.SelectMany(o => o.AllAttributes)))
                    yield return attribute;
            }
        }

        public TableMapping() {
            this.Annotations = new List<Annotation<TableMapping>>();
            this.Attributes = new List<Attribute<TableMapping>>();
        }

        public TableMapping(string schemaName, string tableName, string className, List<ColumnMapping> columnMappings, List<UniqueIndexMapping> uniqueIndexMappings, List<Annotation<TableMapping>> annotations, List<Attribute<TableMapping>> attributes)
        {
            _schemaName = schemaName;
            _tableName = tableName;
            _className = tableName;
            _pluralClassName = tableName.Pluralize();
            _columnMappings = (columnMappings ?? new List<ColumnMapping>());
            _uniqueIndexMappings = (uniqueIndexMappings ?? new List<UniqueIndexMapping>());
            _annotations = (annotations ?? new List<Annotation<TableMapping>>());
            _attributes = (attributes ?? new List<Attribute<TableMapping>>());
        }

        public void JoinToProject(Project project)
        {
            if (_project != null)
                throw new ApplicationException("Already joined to a project.");

            _project = project;

            _columnMappings.ForEach(cm => cm.JoinToTableMapping(this));
            _uniqueIndexMappings.ForEach(uim => uim.JoinToTableMapping(this));
            _apis.ForEach(api => api.JoinToTableMapping(this));
            _annotations.ForEach(a => a.JoinToParent(this));
            _attributes.ForEach(a => a.JoinToParent(this));
        }

        public ColumnMapping FindColumnMapping(string name)
        {
            foreach (ColumnMapping cm in _columnMappings)
                if (cm.ColumnName.Equals(name))
                    return cm;

            return null;
        }

        public UniqueIndexMapping FindUniqueIndexMapping(string name)
        {
            foreach (UniqueIndexMapping uim in _uniqueIndexMappings)
                if (uim.UniqueIndexName.Equals(name))
                    return uim;

            return null;
        }

        public API FindAPI(string name)
        {
            return _apis.Where(api => api.Name.Equals(name)).SingleOrDefault();
        }

        public bool ContainsEnumeration()
        {
            foreach (ColumnMapping cm in _columnMappings)
                if (cm.EnumerationMapping != null)
                    return true;

            return false;
        }

        public override string ToString()
        {
            return _className;
        }
    }
}
