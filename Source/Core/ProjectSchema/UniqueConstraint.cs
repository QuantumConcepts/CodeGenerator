using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema {

    [XmlRoot]
    public class UniqueConstraint : IProjectSchemaElement, IHasAnnotations<UniqueConstraint>, IHasAttributes<UniqueConstraint> {
        private List<string> _propertyNames = new List<string>();

        [XmlIgnore]
        public Project ContainingProject { get { return this.Entity?.ContainingProject; } }

        [XmlIgnore]
        private Entity Entity { get; set; }

        [XmlAttribute]
        public string UniqueIndexName { get; set; }

        [XmlArray]
        [XmlArrayItem("PropertyName")]
        public List<string> PropertyNamesForSerialization {
            get {
                _propertyNames = this.Properties.Select(o => o.Name).ToList();

                return _propertyNames;
            }
            set {
                if (this.Properties.Count != 0)
                    throw new ApplicationException($"Cannot set {nameof(PropertyNamesForSerialization)} except during deserialization.");

                _propertyNames = value;
            }
        }

        [XmlIgnore]
        public List<Property> Properties { get; set; } = new List<Property>();

        [XmlAttribute]
        public bool Exclude { get; set; }

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public List<Annotation<UniqueConstraint>> Annotations { get; set; } = new List<Annotation<UniqueConstraint>>();

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<UniqueConstraint>> Attributes { get; set; } = new List<Attribute<UniqueConstraint>>();

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations {
            get {
                foreach (IAnnotation annotation in this.Annotations)
                    yield return annotation;
            }
        }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes {
            get {
                foreach (IAttribute attribute in this.Attributes.Union(this.Annotations.SelectMany(o => o.AllAttributes)))
                    yield return attribute;
            }
        }

        public UniqueConstraint() {
        }

        public UniqueConstraint(string uniqueIndexName, List<Annotation<UniqueConstraint>> annotations, List<Attribute<UniqueConstraint>> attributes) {
            this.UniqueIndexName = uniqueIndexName;
            this.Annotations = (annotations ?? new List<Annotation<UniqueConstraint>>());
            this.Attributes = (attributes ?? new List<Attribute<UniqueConstraint>>());
        }

        public void JoinToTableMapping(Entity entity) {
            if (this.Entity != null)
                throw new ApplicationException("Already joined to a table mapping.");

            this.Entity = entity;
            this.Properties = new List<Property>();
            this.Annotations.ForEach(a => a.JoinToParent(this));
            this.Attributes.ForEach(a => a.JoinToParent(this));

            if (this.PropertyNamesForSerialization != null)
                this.Properties = this.Entity.Properties.Where(o => this.PropertyNamesForSerialization.Contains(o.Name)).ToList();
        }
    }
}