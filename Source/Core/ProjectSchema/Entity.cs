using QuantumConcepts.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema {

    [XmlRoot(Entity.ElementName)]
    public class Entity : IProjectSchemaElement, IHasAnnotations<Entity>, IHasAttributes<Entity> {
        public const string ElementName = "Entity";

        [XmlIgnore]
        public Project ContainingProject { get; protected set; }

        [XmlAttribute]
        public virtual string Name { get; set; }

        [XmlAttribute]
        public string PluralName { get; set; }

        [XmlAttribute]
        public virtual bool ReadOnly { get; set; }

        [XmlAttribute]
        public bool Exclude { get; set; }

        [XmlArray]
        [XmlArrayItem]
        public List<Property> Properties { get; set; } = new List<Property>();

        [XmlArray]
        [XmlArrayItem]
        public List<UniqueConstraint> UniqueConstraints { get; set; } = new List<UniqueConstraint>();

        [XmlArray]
        [XmlArrayItem]
        public List<API> APIs { get; set; } = new List<API>();

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public List<Annotation<Entity>> Annotations { get; set; } = new List<Annotation<Entity>>();

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<Entity>> Attributes { get; set; } = new List<Attribute<Entity>>();

        [XmlIgnore]
        public List<Property> PrimaryKeyColumnMappings {
            get {
                List<Property> primaryKeyColumnMappings = new List<Property>();

                foreach (Property cm in this.Properties)
                    if (cm.IsKey)
                        primaryKeyColumnMappings.Add(cm);

                return primaryKeyColumnMappings;
            }
        }

        [XmlIgnore]
        public List<Property> NonPrimaryKeyColumnMappings {
            get {
                List<Property> nonPrimaryKeyColumnMappings = new List<Property>();

                foreach (Property cm in this.Properties)
                    if (!cm.IsKey)
                        nonPrimaryKeyColumnMappings.Add(cm);

                return nonPrimaryKeyColumnMappings;
            }
        }

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations {
            get {
                foreach (IAnnotation annotation in this.Annotations.Union(this.Properties.SelectMany(o => o.AllAnnotations)).Union(this.UniqueConstraints.SelectMany(o => o.AllAnnotations)).Union(this.APIs.SelectMany(o => o.AllAnnotations)))
                    yield return annotation;
            }
        }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes {
            get {
                foreach (IAttribute attribute in this.Attributes.Union(this.Properties.SelectMany(o => o.AllAttributes)).Union(this.UniqueConstraints.SelectMany(o => o.AllAttributes)).Union(this.Annotations.SelectMany(o => o.AllAttributes)).Union(this.APIs.SelectMany(o => o.AllAttributes)))
                    yield return attribute;
            }
        }

        public Entity() {
        }

        public Entity(string name, List<Property> columnMappings, List<UniqueConstraint> uniqueIndexMappings, List<Annotation<Entity>> annotations, List<Attribute<Entity>> attributes) {
            this.Name = name;
            this.PluralName = name.Pluralize();
            this.Properties = (columnMappings ?? new List<Property>());
            this.UniqueConstraints = (uniqueIndexMappings ?? new List<UniqueConstraint>());
            this.Annotations = (annotations ?? new List<Annotation<Entity>>());
            this.Attributes = (attributes ?? new List<Attribute<Entity>>());
        }

        public void JoinToProject(Project project) {
            if (this.ContainingProject != null)
                throw new ApplicationException("Already joined to a project.");

            this.ContainingProject = project;

            this.Properties.ForEach(cm => cm.JoinToTableMapping(this));
            this.UniqueConstraints.ForEach(uim => uim.JoinToTableMapping(this));
            this.APIs.ForEach(api => api.JoinToTableMapping(this));
            this.Annotations.ForEach(a => a.JoinToParent(this));
            this.Attributes.ForEach(a => a.JoinToParent(this));
        }

        public Property FindColumnMapping(string name) {
            foreach (Property cm in this.Properties)
                if (cm.Name.Equals(name))
                    return cm;

            return null;
        }

        public UniqueConstraint FindUniqueIndexMapping(string name) {
            foreach (UniqueConstraint uim in this.UniqueConstraints)
                if (uim.UniqueIndexName.Equals(name))
                    return uim;

            return null;
        }

        public API FindAPI(string name) {
            return this.APIs.Where(api => api.Name.Equals(name)).SingleOrDefault();
        }

        public bool ContainsEnumeration() {
            foreach (Property cm in this.Properties)
                if (cm.EnumerationMapping != null)
                    return true;

            return false;
        }

        public override string ToString() {
            return this.Name;
        }
    }
}