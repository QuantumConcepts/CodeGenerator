using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema {

    public class DatabaseModel : Model<TableEntity>, IProjectSchemaElement, IHasAnnotations<DatabaseModel>, IHasAttributes<DatabaseModel> {

        [XmlArray]
        [XmlArrayItem("Table")]
        public List<TableEntity> Tables { get { return this.Entities; } set { this.Entities = value; } }

        [XmlArray]
        [XmlArrayItem("View")]
        public List<ViewEntity> View { get; set; }

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public new List<Annotation<DatabaseModel>> Annotations { get; set; } = new List<Annotation<DatabaseModel>>();

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public new List<Attribute<DatabaseModel>> Attributes { get; set; } = new List<Attribute<DatabaseModel>>();

        [XmlIgnore]
        public override IEnumerable<IAnnotation> AllAnnotations {
            get {
                foreach (IAnnotation annotation in this.Annotations.Union(this.Entities.SelectMany(o => o.AllAnnotations)))
                    yield return annotation;
            }
        }

        [XmlIgnore]
        public override IEnumerable<IAttribute> AllAttributes {
            get {
                foreach (IAttribute attribute in this.Attributes.Union(this.Entities.SelectMany(o => o.AllAttributes)))
                    yield return attribute;
            }
        }
    }
}