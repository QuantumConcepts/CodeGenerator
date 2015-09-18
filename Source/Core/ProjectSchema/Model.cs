using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema {
    public class Model : Model<Entity> {
    }

    public class Model<EntityType> : IProjectSchemaElement, IHasAnnotations<Model>, IHasAttributes<Model> where EntityType : Entity {
        public ModelType Type { get; set; }
        public string Name { get; set; }

        [XmlArray]
        [XmlArrayItem]
        public List<EntityType> Entities { get; set; }

        [XmlIgnore]
        public IEnumerable<Entity> IncludedEntities { get { return this.Entities.Where(o => !o.Exclude); } }

        public Project ContainingProject {
            get {
                throw new NotImplementedException();
            }
        }

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public List<Annotation<Model>> Annotations { get; set; } = new List<Annotation<Model>>();

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<Model>> Attributes { get; set; } = new List<Attribute<Model>>();

        [XmlIgnore]
        public virtual IEnumerable<IAnnotation> AllAnnotations {
            get {
                foreach (IAnnotation annotation in this.Annotations.Union(this.Entities.SelectMany(o => o.AllAnnotations)))
                    yield return annotation;
            }
        }

        [XmlIgnore]
        public virtual IEnumerable<IAttribute> AllAttributes {
            get {
                foreach (IAttribute attribute in this.Attributes.Union(this.Entities.SelectMany(o => o.AllAttributes)))
                    yield return attribute;
            }
        }
    }
}
