using QuantumConcepts.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema {

    [XmlRoot("Relationship")]
    public class EntityRelationship : IProjectSchemaElement, IHasAnnotations<EntityRelationship>, IHasAttributes<EntityRelationship> {
        private Entity _referencedTableMapping;
        private Property _parentColumnMapping;
        private Entity _parentTableMapping;
        private Property _referencedColumnMapping;

        [XmlIgnore]
        public Project ContainingProject { get { return this.ContainingModel?.ContainingProject; } }

        [XmlIgnore]
        public Model ContainingModel { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public bool Exclude { get; set; }

        [XmlElement]
        public EntityRelationshipEnd OwningEnd { get; set; }

        [XmlElement]
        public EntityRelationshipEnd ReferencingEnd { get; set; }

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public List<Annotation<EntityRelationship>> Annotations { get; set; } = new List<Annotation<EntityRelationship>>();

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<EntityRelationship>> Attributes { get; set; } = new List<Attribute<EntityRelationship>>();

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

        public EntityRelationship() {
        }

        public EntityRelationship(Model model, string name, Property owningProperty, Property referencingProperty, List<Annotation<EntityRelationship>> annotations, List<Attribute<EntityRelationship>> attributes) : this() {
            this.ContainingModel = model;
            this.Name = name;
            this.OwningEnd = new EntityRelationshipEnd(this, owningProperty);
            this.ReferencingEnd = new EntityRelationshipEnd(this, referencingProperty, true);

            _fieldName = owningProperty.FieldName;
            _propertyName = FieldNameToPropertyName(_fieldName, referencingProperty.Entity.ClassName);

            if (owningProperty.Entity == referencingProperty.Entity)
                _pluralFieldName = "Child{0}".FormatString(owningProperty.Entity.ClassName.Pluralize());
            else
                _pluralFieldName = owningProperty.Entity.ClassName.Pluralize();

            _pluralPropertyName = _pluralFieldName;
            _parentTableMappingSchemaName = owningProperty.Entity.SchemaName;
            _parentTableMappingName = owningProperty.Entity.Name;
            _parentColumnMappingName = owningProperty.Name;
            _referencedTableMappingSchemaName = referencingProperty.Entity.SchemaName;
            _referencedTableMappingName = referencingProperty.Entity.Name;
            _referencedColumnMappingName = referencingProperty.Name;
            _parentColumnMapping = owningProperty;
            _referencedColumnMapping = referencingProperty;
            _annotations = (annotations ?? new List<Annotation<EntityRelationship>>());
            _attributes = (attributes ?? new List<Attribute<EntityRelationship>>());
        }

        public void JoinToModel(Model model) {
            if (this.ContainingModel != null)
                throw new ApplicationException("Already joined to a model.");

            this.ContainingModel = model;
            this.Annotations.ForEach(a => a.JoinToParent(this));
            this.Attributes.ForEach(a => a.JoinToParent(this));
        }

        private string FieldNameToPropertyName(string fieldName, string referencedClassName) {
            const string propertyNameGroup = "PropertyName";

            Regex regex = new Regex(@"^(?<{0}>.+)_?ID$".FormatString(propertyNameGroup), RegexOptions.IgnoreCase);
            Match match = regex.Match(fieldName);

            if (match.Success)
                return match.Groups[propertyNameGroup].Value;

            return referencedClassName;
        }
    }
}