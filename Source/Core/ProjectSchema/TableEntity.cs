using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema {
    [XmlRoot(TableEntity.ElementName)]
    public class TableEntity : Entity, IHasAnnotations<TableEntity>, IHasAttributes<TableEntity> {
        public new const string ElementName = "Table";

        [XmlAttribute]
        public string SchemaName { get; set; }

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public new List<Annotation<TableEntity>> Annotations { get; set; } = new List<Annotation<TableEntity>>();

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public new List<Attribute<TableEntity>> Attributes { get; set; } = new List<Attribute<TableEntity>>();

        public TableEntity() { }

        public TableEntity(string schemaName, string name, List<Property> columnMappings, List<UniqueConstraint> uniqueIndexMappings, List<Annotation<Entity>> annotations, List<Attribute<Entity>> attributes)
            : base(name, columnMappings, uniqueIndexMappings, annotations, attributes) {
            this.SchemaName = schemaName;
        }
    }
}
