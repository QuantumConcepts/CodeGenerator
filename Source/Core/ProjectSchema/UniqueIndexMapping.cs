using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    [XmlRoot]
    public class UniqueIndexMapping : IProjectSchemaElement, IHasAnnotations<UniqueIndexMapping>, IHasAttributes<UniqueIndexMapping>
    {
        private TableMapping _tableMapping;

        private string _uniqueIndexName;
        private List<string> _columnNames = new List<string>();
        private bool _exclude = false;
        private List<Annotation<UniqueIndexMapping>> _annotations = new List<Annotation<UniqueIndexMapping>>();
        private List<Attribute<UniqueIndexMapping>> _attributes = new List<Attribute<UniqueIndexMapping>>();
        private List<ColumnMapping> _columnMappings = new List<ColumnMapping>();

        [XmlIgnore]
        public Project ContainingProject { get { return _tableMapping.ContainingProject; } }

        [XmlAttribute]
        public string UniqueIndexName
        {
            get { return _uniqueIndexName; }
            set { _uniqueIndexName = value; }
        }

        [XmlArray]
        [XmlArrayItem("ColumnName")]
        public List<string> ColumnNames
        {
            get
            {
                _columnNames = new List<string>();

                foreach (ColumnMapping cm in _columnMappings)
                    _columnNames.Add(cm.ColumnName);

                return _columnNames;
            }
            set
            {
                if (_columnNames.Count > 0)
                    throw new ApplicationException("This property can not be set directly. Use ColumnMappings instead.");

                _columnNames = value;
            }
        }

        [XmlAttribute]
        public bool Exclude
        {
            get { return _exclude; }
            set { _exclude = value; }
        }

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public List<Annotation<UniqueIndexMapping>> Annotations
        {
            get { return _annotations; }
            set { _annotations = value; }
        }

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<UniqueIndexMapping>> Attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }

        [XmlIgnore]
        public List<ColumnMapping> ColumnMappings
        {
            get { return _columnMappings; }
            set { _columnMappings = value; }
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

        public UniqueIndexMapping() { }

        public UniqueIndexMapping(string uniqueIndexName, List<Annotation<UniqueIndexMapping>> annotations, List<Attribute<UniqueIndexMapping>> attributes)
        {
            _uniqueIndexName = uniqueIndexName;
            _annotations = (annotations ?? new List<Annotation<UniqueIndexMapping>>());
            _attributes = (attributes ?? new List<Attribute<UniqueIndexMapping>>());
        }

        public void JoinToTableMapping(TableMapping tableMapping)
        {
            if (_tableMapping != null)
                throw new ApplicationException("Already joined to a table mapping.");

            _tableMapping = tableMapping;
            _columnMappings = new List<ColumnMapping>(_columnNames.Count);
            _annotations.ForEach(a => a.JoinToParent(this));
            _attributes.ForEach(a => a.JoinToParent(this));

            foreach (string columnName in _columnNames)
                _columnMappings.Add(tableMapping.FindColumnMapping(columnName));
        }
    }
}
