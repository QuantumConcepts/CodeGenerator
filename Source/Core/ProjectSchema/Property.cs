using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema {

    public class Property : IProjectSchemaElement, IHasAnnotations<Property>, IHasAttributes<Property> {

        [XmlIgnore]
        public Project ContainingProject { get { return this.Entity?.ContainingProject; } }

        [XmlIgnore]
        public Entity Entity { get; private set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public bool IsKey { get; set; }

        [XmlAttribute]
        public int Sequence { get; set; }

        [XmlAttribute]
        public string DataType { get; set; }

        [XmlAttribute]
        public decimal Length { get; set; }

        [XmlAttribute]
        public string DefaultValue { get; set; }

        [XmlAttribute]
        public bool Nullable { get; set; }

        [XmlAttribute]
        public bool TreatAsYesNoIndicator { get; set; }

        [XmlAttribute]
        public bool Exclude { get; set; }

        [XmlAttribute]
        public string EncryptionVectorColumnName { get; set; }

        [XmlAttribute]
        public string DecryptionPropertyName { get; set; }

        [XmlElement]
        public EnumerationMapping EnumerationMapping { get; set; }

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public List<Annotation<Property>> Annotations { get; set; } = new List<Annotation<Property>>();

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<Property>> Attributes { get; set; } = new List<Attribute<Property>>();

        [XmlIgnore]
        public bool IsEncrypted { get { return !string.IsNullOrEmpty(this.EncryptionVectorColumnName); } }

        [XmlIgnore]
        public bool IsEncryptionColumn {
            get {
                foreach (Property cm in this.Entity.Properties)
                    if (cm.IsEncrypted && cm.EncryptionVectorColumnName.Equals(this.Name))
                        return true;

                return false;
            }
        }

        [XmlIgnore]
        public bool IsEnumeration { get { return this.EnumerationMapping != null; } }

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

        public Property() {
            this.Annotations = new List<Annotation<Property>>();
            this.Attributes = new List<Attribute<Property>>();
        }

        public Property(Entity tableMapping, string name, int sequence, string dataType, decimal length, string defaultValue, bool nullable, List<Annotation<Property>> annotations, List<Attribute<Property>> attributes) {
            this.Entity = tableMapping;
            this.Name = name;
            this.Sequence = sequence;
            this.DataType = dataType;
            this.Length = length;
            this.Nullable = nullable;
            this.Annotations = (annotations ?? new List<Annotation<Property>>());
            this.Attributes = (attributes ?? new List<Attribute<Property>>());
        }

        public void JoinToTableMapping(Entity tableMapping) {
            if (this.Entity != null)
                throw new ApplicationException("Already joined to a table mapping.");

            this.Entity = tableMapping;

            if (this.EnumerationMapping != null)
                this.EnumerationMapping.JoinToColumnMapping(this);

            this.Annotations.ForEach(a => a.JoinToParent(this));
            this.Attributes.ForEach(a => a.JoinToParent(this));
        }

        public override string ToString() {
            return this.Entity.ToString() + "." + this.Name;
        }
    }
}