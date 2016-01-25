using System.Collections.Generic;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema {
    [XmlRoot(Table.ElementName)]
    public class Table : Entity, IHasAnnotations<Table>, IHasAttributes<Table> {
        public new const string ElementName = nameof(Table);

        [XmlAttribute]
        public string SchemaName { get; set; }

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public new List<Annotation<Table>> Annotations { get; set; } = new List<Annotation<Table>>();

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public new List<Attribute<Table>> Attributes { get; set; } = new List<Attribute<Table>>();

        public Table() { }

        public Table(string schemaName, string name, List<Property> columnMappings, List<UniqueConstraint> uniqueIndexMappings, List<Annotation<Entity>> annotations, List<Attribute<Entity>> attributes)
            : base(name, columnMappings, uniqueIndexMappings, annotations, attributes) {
            this.SchemaName = schemaName;
        }
    }
}
