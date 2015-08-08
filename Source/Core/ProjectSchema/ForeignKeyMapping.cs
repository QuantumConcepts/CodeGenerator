using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.CodeGenerator.Core.Utils;
using System.Linq;
using System.Text.RegularExpressions;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    [XmlRoot("ForeignKeyMapping")]
    public class ForeignKeyMapping : IProjectSchemaElement, IHasAnnotations<ForeignKeyMapping>, IHasAttributes<ForeignKeyMapping>
    {
        private Project _project;
        private string _foreignKeyName;
        private string _fieldName;
        private string _pluralFieldName;
        private string _propertyName;
        private string _pluralPropertyName;
        private string _parentTableMappingSchemaName;
        private string _parentTableMappingName;
        private string _parentColumnMappingName;
        private string _referencedTableMappingSchemaName;
        private string _referencedTableMappingName;
        private string _referencedColumnMappingName;
        private bool _exclude = false;
        private List<Annotation<ForeignKeyMapping>> _annotations = new List<Annotation<ForeignKeyMapping>>();
        private List<Attribute<ForeignKeyMapping>> _attributes = new List<Attribute<ForeignKeyMapping>>();
        private TableMapping _referencedTableMapping;
        private ColumnMapping _parentColumnMapping;
        private TableMapping _parentTableMapping;
        private ColumnMapping _referencedColumnMapping;

        [XmlIgnore]
        public Project ContainingProject
        {
            get { return (_project == null ? ProjectContext.Project : _project); }
        }

        [XmlIgnore]
        public Project Project
        {
            get { return _project; }
        }

        [XmlAttribute]
        public string ForeignKeyName
        {
            get { return _foreignKeyName; }
            set { _foreignKeyName = value; }
        }

        [XmlAttribute]
        public string FieldName
        {
            get { return _fieldName; }
            set { _fieldName = value; }
        }

        [XmlAttribute]
        public string PluralFieldName
        {
            get { return _pluralFieldName; }
            set { _pluralFieldName = value; }
        }

        [XmlAttribute]
        public string PropertyName
        {
            get { return _propertyName; }
            set { _propertyName = value; }
        }

        [XmlAttribute]
        public string PluralPropertyName
        {
            get { return _pluralPropertyName; }
            set { _pluralPropertyName = value; }
        }

        [XmlAttribute]
        public string ParentTableMappingSchemaName
        {
            get { return _parentTableMappingSchemaName; }
            set { _parentTableMappingSchemaName = value; }
        }

        [XmlAttribute]
        public string ParentTableMappingName
        {
            get { return _parentTableMappingName; }
            set { _parentTableMappingName = value; }
        }

        [XmlAttribute]
        public string ParentColumnMappingName
        {
            get { return _parentColumnMappingName; }
            set { _parentColumnMappingName = value; }
        }

        [XmlAttribute]
        public string ReferencedTableMappingSchemaName
        {
            get { return _referencedTableMappingSchemaName; }
            set { _referencedTableMappingSchemaName = value; }
        }

        [XmlAttribute]
        public string ReferencedTableMappingName
        {
            get { return _referencedTableMappingName; }
            set { _referencedTableMappingName = value; }
        }

        [XmlAttribute]
        public string ReferencedColumnMappingName
        {
            get { return _referencedColumnMappingName; }
            set { _referencedColumnMappingName = value; }
        }

        [XmlAttribute]
        public bool Exclude
        {
            get { return _exclude; }
            set { _exclude = value; }
        }

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public List<Annotation<ForeignKeyMapping>> Annotations
        {
            get { return _annotations; }
            set { _annotations = value; }
        }

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<ForeignKeyMapping>> Attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }

        [XmlIgnore]
        public TableMapping ParentTableMapping
        {
            get
            {
                if (string.IsNullOrEmpty(_parentTableMappingSchemaName) || string.IsNullOrEmpty(_parentTableMappingName))
                    throw new ApplicationException("Parent Table Mapping Schema and/or Name is not known.");

                if (_parentTableMapping == null || !_parentTableMapping.SchemaName.Equals(_parentTableMappingSchemaName) || !_parentTableMapping.TableName.Equals(_parentTableMappingName))
                    _parentTableMapping = _project.FindTableMapping(_parentTableMappingSchemaName, _parentTableMappingName);

                return _parentTableMapping;
            }
        }

        [XmlIgnore]
        public ColumnMapping ParentColumnMapping
        {
            get
            {
                if (string.IsNullOrEmpty(_parentColumnMappingName))
                    throw new ApplicationException("Parent Column Mapping Name is not known.");

                if (_parentColumnMapping == null || !_parentColumnMapping.ColumnName.Equals(_parentColumnMappingName))
                    _parentColumnMapping = this.ParentTableMapping.FindColumnMapping(_parentColumnMappingName);

                return _parentColumnMapping;
            }
            set
            {
                _parentTableMappingSchemaName = value.TableMapping.SchemaName;
                _parentTableMappingName = value.TableMapping.TableName;
                _parentColumnMappingName = value.ColumnName;
                _parentColumnMapping = value;
            }
        }

        [XmlIgnore]
        public TableMapping ReferencedTableMapping
        {
            get
            {
                if (string.IsNullOrEmpty(_referencedTableMappingName))
                    throw new ApplicationException("Referenced Table Mapping Name is not known.");

                if (_referencedTableMapping == null || !_referencedTableMapping.TableName.Equals(_referencedTableMappingName))
                    _referencedTableMapping = _project.FindTableMapping(_referencedTableMappingSchemaName, _referencedTableMappingName);

                return _referencedTableMapping;
            }
        }

        [XmlIgnore]
        public ColumnMapping ReferencedColumnMapping
        {
            get
            {
                if (string.IsNullOrEmpty(_referencedColumnMappingName))
                    throw new ApplicationException("Parent Table Mapping Name is not known.");

                if (_referencedColumnMapping == null || !_referencedColumnMapping.ColumnName.Equals(_referencedColumnMappingName))
                    _referencedColumnMapping = this.ReferencedTableMapping.FindColumnMapping(_referencedColumnMappingName);

                return _referencedColumnMapping;
            }
            set
            {
                _referencedTableMappingSchemaName = value.TableMapping.SchemaName;
                _referencedTableMappingName = value.TableMapping.TableName;
                _referencedColumnMappingName = value.ColumnName;
                _referencedColumnMapping = value;
            }
        }

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations
        {
            get
            {
                foreach (IAnnotation annotation in _annotations)
                    yield return annotation;
            }
        }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes
        {
            get
            {
                foreach (IAttribute attribute in this.Attributes.Union(_annotations.SelectMany(o => o.AllAttributes)))
                    yield return attribute;
            }
        }

        public ForeignKeyMapping() { }

        public ForeignKeyMapping(Project project, string foreignKeyName, ColumnMapping parentColumnMapping, ColumnMapping referencedColumnMapping, List<Annotation<ForeignKeyMapping>> annotations, List<Attribute<ForeignKeyMapping>> attributes)
        {
            _project = project;
            _foreignKeyName = foreignKeyName;
            _fieldName = parentColumnMapping.FieldName;
            _propertyName = FieldNameToPropertyName(_fieldName, referencedColumnMapping.TableMapping.ClassName);

            if (parentColumnMapping.TableMapping == referencedColumnMapping.TableMapping)
                _pluralFieldName = "Child{0}".FormatString(parentColumnMapping.TableMapping.ClassName.Pluralize());
            else
                _pluralFieldName = parentColumnMapping.TableMapping.ClassName.Pluralize();

            _pluralPropertyName = _pluralFieldName;
            _parentTableMappingSchemaName = parentColumnMapping.TableMapping.SchemaName;
            _parentTableMappingName = parentColumnMapping.TableMapping.TableName;
            _parentColumnMappingName = parentColumnMapping.ColumnName;
            _referencedTableMappingSchemaName = referencedColumnMapping.TableMapping.SchemaName;
            _referencedTableMappingName = referencedColumnMapping.TableMapping.TableName;
            _referencedColumnMappingName = referencedColumnMapping.ColumnName;
            _parentColumnMapping = parentColumnMapping;
            _referencedColumnMapping = referencedColumnMapping;
            _annotations = (annotations ?? new List<Annotation<ForeignKeyMapping>>());
            _attributes = (attributes ?? new List<Attribute<ForeignKeyMapping>>());
        }

        public void JoinToProject(Project project)
        {
            if (_project != null)
                throw new ApplicationException("Already joined to a project.");

            _project = project;
            _annotations.ForEach(a => a.JoinToParent(this));
            _attributes.ForEach(a => a.JoinToParent(this));
        }

        private string FieldNameToPropertyName(string fieldName, string referencedClassName)
        {
            const string propertyNameGroup = "PropertyName";

            Regex regex = new Regex(@"^(?<{0}>.+)_?ID$".FormatString(propertyNameGroup), RegexOptions.IgnoreCase);
            Match match = regex.Match(fieldName);

            if (match.Success)
                return match.Groups[propertyNameGroup].Value;

            return referencedClassName;
        }
    }
}
