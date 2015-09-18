using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema {
    public class ModelMap<SourceModelType, DestinationModelType> : IProjectSchemaElement, IHasAnnotations<ModelMap<SourceModelType, DestinationModelType>>, IHasAttributes<ModelMap<SourceModelType, DestinationModelType>>
        where SourceModelType : Model
        where DestinationModelType : Model {

        [XmlIgnore]
        public Project ContainingProject { get; set; }

        [XmlAttribute]
        public string SourceModelName { get; set; }

        [XmlIgnore]
        public SourceModelType SourceModel { get { return (SourceModelType)this.ContainingProject.Models.Single(o => string.Equals(o.Name, this.SourceModelName)); } }

        [XmlAttribute]
        public string DestinationModelName { get; set; }

        [XmlIgnore]
        public DestinationModelType DestinationModel { get { return (DestinationModelType)this.ContainingProject.Models.Single(o => string.Equals(o.Name, this.DestinationModelName)); } }

        [XmlArray]
        [XmlArrayItem]
        public List<DataTypeMapping> DataTypeMappings { get; set; } = new List<DataTypeMapping>();

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public List<Annotation<ModelMap<SourceModelType, DestinationModelType>>> Annotations { get; set; } = new List<Annotation<ModelMap<SourceModelType, DestinationModelType>>>();

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<ModelMap<SourceModelType, DestinationModelType>>> Attributes { get; set; } = new List<Attribute<ModelMap<SourceModelType, DestinationModelType>>>();

        [XmlIgnore]
        public virtual IEnumerable<IAnnotation> AllAnnotations {
            get {
                foreach (IAnnotation annotation in this.Annotations.Union(this.SourceModel.AllAnnotations).Union(this.DestinationModel.AllAnnotations))
                    yield return annotation;
            }
        }

        [XmlIgnore]
        public virtual IEnumerable<IAttribute> AllAttributes {
            get {
                foreach (IAttribute attribute in this.Attributes.Union(this.SourceModel.AllAttributes).Union(this.DestinationModel.AllAttributes))
                    yield return attribute;
            }
        }
    }
}
