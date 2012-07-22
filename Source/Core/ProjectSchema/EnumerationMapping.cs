using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    [XmlRoot]
    public class EnumerationMapping : IProjectSchemaElement, IHasAnnotations<EnumerationMapping>, IHasAttributes<EnumerationMapping>
    {
        private ColumnMapping _columnMapping;
        private string _name;
        private bool _isReference = false;
        private string _referencedTableMappingSchemaName;
        private string _referencedTableMappingName;
        private string _referencedColumnName;
        private List<EnumerationValueMapping> _values = new List<EnumerationValueMapping>();
        private List<Annotation<EnumerationMapping>> _annotations = new List<Annotation<EnumerationMapping>>();
        private List<Attribute<EnumerationMapping>> _attributes = new List<Attribute<EnumerationMapping>>();

        [XmlIgnore]
        public Project ContainingProject
        {
            get { return (_columnMapping == null ? ProjectContext.Project : _columnMapping.ContainingProject); }
        }

        [XmlIgnore]
        public ColumnMapping ColumnMapping
        {
            get { return _columnMapping; }
            set { _columnMapping = value; }
        }

        [XmlAttribute]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [XmlAttribute]
        public bool IsReference
        {
            get { return _isReference; }
            set { _isReference = value; }
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
        public string ReferencedColumnName
        {
            get { return _referencedColumnName; }
            set { _referencedColumnName = value; }
        }

        [XmlArray]
        [XmlArrayItem]
        public List<EnumerationValueMapping> Values
        {
            get { return _values; }
            set { _values = value; }
        }

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public List<Annotation<EnumerationMapping>> Annotations
        {
            get { return _annotations; }
            set { _annotations = value; }
        }

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<EnumerationMapping>> Attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations
        {
            get
            {
                foreach (IAnnotation annotation in _annotations.Union(_values.SelectMany(v => v.AllAnnotations)))
                    yield return annotation;
            }
        }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes
        {
            get
            {
                foreach (IAttribute attribute in this.Attributes.Union(_values.SelectMany(o => o.AllAttributes)).Union(_annotations.SelectMany(o => o.AllAttributes)))
                    yield return attribute;
            }
        }

        public EnumerationMapping() { }

        public EnumerationMapping(string name, List<EnumerationValueMapping> enumerationValueMappings, List<Annotation<EnumerationMapping>> annotations, List<Attribute<EnumerationMapping>> attributes)
        {
            _name = name;
            _values = (enumerationValueMappings ?? new List<EnumerationValueMapping>());
            _annotations = (annotations ?? new List<Annotation<EnumerationMapping>>());
            _attributes = (attributes ?? new List<Attribute<EnumerationMapping>>());
        }

        /// <summary>This constructor creates a referenced enumeration mapping from the supplied EnumerationMapping.</summary>
        public EnumerationMapping(EnumerationMapping reference)
        {
            UpdateReference(reference);
        }

        public void JoinToColumnMapping(ColumnMapping columnMapping)
        {
            if (_columnMapping != null)
                throw new ApplicationException("Already joined to a column mapping.");

            _columnMapping = columnMapping;

            if (_values != null)
                _values.ForEach(ev => ev.JoinToEnumerationMapping(this));

            if (_annotations != null)
                _annotations.ForEach(a => a.JoinToParent(this));

            if (_attributes != null)
                _attributes.ForEach(a => a.JoinToParent(this));
        }

        public EnumerationMapping GetReferencedEnumerationMapping()
        {
            if (!_isReference)
                return null;

            return ContainingProject.FindTableMapping(_referencedTableMappingSchemaName, _referencedTableMappingName).FindColumnMapping(_referencedColumnName).EnumerationMapping;
        }

        public void UpdateReference(EnumerationMapping reference)
        {
            _name = reference.Name;
            _isReference = true;
            _referencedTableMappingSchemaName = reference.ColumnMapping.TableMapping.SchemaName;
            _referencedTableMappingName = reference.ColumnMapping.TableMapping.TableName;
            _referencedColumnName = reference.ColumnMapping.ColumnName;
            _values = null;
            _annotations = null;
            _attributes = null;
        }

        public bool References(EnumerationMapping reference)
        {
            return (object.Equals(reference.Name, _name) && object.Equals(reference.ColumnMapping.TableMapping.TableName, _referencedTableMappingName) && object.Equals(reference.ColumnMapping.ColumnName, _referencedColumnName));
        }

        public override string ToString()
        {
            return _name;
        }
    }
}
