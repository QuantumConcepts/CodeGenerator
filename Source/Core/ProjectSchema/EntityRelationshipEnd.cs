using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema {

    [XmlRoot("End")]
    public class EntityRelationshipEnd : IProjectSchemaElement, IHasAnnotations<EntityRelationshipEnd>, IHasAttributes<EntityRelationshipEnd> {

        [XmlIgnore]
        public Project ContainingProject { get { return this.ContainingModel?.ContainingProject; } }

        [XmlIgnore]
        public Model ContainingModel { get { return this.ContainingRelationship?.ContainingModel; } }

        [XmlIgnore]
        public EntityRelationship ContainingRelationship { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public string EntityName { get; set; }

        [XmlAttribute]
        public string PropertyName { get; set; }

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public List<Annotation<EntityRelationshipEnd>> Annotations { get; set; } = new List<Annotation<EntityRelationshipEnd>>();

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<EntityRelationshipEnd>> Attributes { get; set; } = new List<Attribute<EntityRelationshipEnd>>();

        [XmlIgnore]
        public ReferenceResolver<Entity> EntityResolver { get; protected set; }

        [XmlIgnore]
        public ReferenceResolver<Property> PropertyResolver { get; protected set; }

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

        public EntityRelationshipEnd() {
            this.EntityResolver = new ReferenceResolver<Entity>(() => this.ContainingModel.FindEntity(this.EntityName));
            this.PropertyResolver = new ReferenceResolver<Property>(() => this.EntityResolver.Resolve().FindColumnMapping(this.PropertyName));
        }

        public EntityRelationshipEnd(EntityRelationship relationship, Property property, bool pluralize = false) : this() {
            this.ContainingRelationship = relationship;
            this.EntityName = property.Entity.FullName;
            this.PropertyName = property.Name;

            if (owningProperty.Entity == referencingProperty.Entity)
                _pluralFieldName = "Child{0}".FormatString(owningProperty.Entity.ClassName.Pluralize());
            else
                _pluralFieldName = owningProperty.Entity.ClassName.Pluralize();
        }

        public void JoinToRelationship(EntityRelationship relationship) {
            if (this.ContainingModel != null)
                throw new ApplicationException("Already joined to a relationship.");

            this.ContainingRelationship = relationship;
            this.Annotations.ForEach(a => a.JoinToParent(this));
            this.Attributes.ForEach(a => a.JoinToParent(this));
        }
    }
}