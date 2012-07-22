using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.PackageSchema
{
    [XmlRoot]
    public class Manifest
    {
        [XmlAttribute]
        public bool Automatic { get; set; }

        [XmlAttribute]
        public string ProjectFileManifestItemID { get; set; }

        [XmlElement(ElementName = "Item")]
        public List<ManifestItem> Items { get; set; }
    }
}
