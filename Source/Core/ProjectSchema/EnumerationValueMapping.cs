using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using QuantumConcepts.Common.Extensions;
using System.Linq;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    [XmlRoot]
    public class EnumerationValueMapping : IProjectSchemaElement, IHasAnnotations<EnumerationValueMapping>, IHasAttributes<EnumerationValueMapping>
    {
        private EnumerationMapping _enumerationMapping;

        private string _name;
        private string _databaseValue;
        private string _description;
        private List<Annotation<EnumerationValueMapping>> _annotations = new List<Annotation<EnumerationValueMapping>>();
        private List<Attribute<EnumerationValueMapping>> _attributes = new List<Attribute<EnumerationValueMapping>>();

        [XmlAttribute]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [XmlAttribute]
        public string DatabaseValue
        {
            get { return _databaseValue; }
            set { _databaseValue = value; }
        }

        [XmlElement]
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public List<Annotation<EnumerationValueMapping>> Annotations
        {
            get { return _annotations; }
            set { _annotations = value; }
        }

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<EnumerationValueMapping>> Attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
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

        public Project ContainingProject { get { return _enumerationMapping.ContainingProject; } }

        public EnumerationValueMapping() { }

        public EnumerationValueMapping(string name, string databaseValue, string description)
        {
            _name = name;
            _databaseValue = databaseValue;
            _description = description;
        }

        public void JoinToEnumerationMapping(EnumerationMapping enumerationMapping)
        {
            _enumerationMapping = enumerationMapping;
            _annotations.ForEach(a => a.JoinToParent(this));
            _attributes.ForEach(a => a.JoinToParent(this));
        }

        public override string ToString()
        {
            return "{0} ({1})".FormatString(_name, _databaseValue);
        }
    }
}
