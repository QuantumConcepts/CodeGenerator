using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    [XmlRoot(ViewEntity.ElementName)]
    public class ViewEntity : Table {
        public new const string ElementName = "View";

        [XmlAttribute]
        public override bool ReadOnly { get { return true; } set { } }

        public ViewEntity() { }

        public ViewEntity(string schemaName, string name, List<Property> columnMappings, List<UniqueConstraint> uniqueIndexMappings, List<Annotation<Entity>> annotations, List<Attribute<Entity>> attributes)
            : base(schemaName, name, columnMappings, uniqueIndexMappings, annotations, attributes)
        {
        }
    }
}
