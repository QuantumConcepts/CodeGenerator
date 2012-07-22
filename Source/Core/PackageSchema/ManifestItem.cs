using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using QuantumConcepts.Common.Extensions;

namespace QuantumConcepts.CodeGenerator.Core.PackageSchema
{
    public enum ManifestItemType { File, Folder }

    [XmlRoot("Item")]
    public class ManifestItem : IEquatable<ManifestItem>
    {
        [XmlAttribute]
        public string ID { get; set; }

        [XmlAttribute]
        public ManifestItemType Type { get; set; }

        [XmlAttribute]
        public string RelativePath { get; set; }

        [XmlAttribute]
        public bool DoNotCopy { get; set; }

        public ManifestItem() { }

        public ManifestItem(string id, ManifestItemType type, string relativePath, bool doNotCopy)
        {
            this.ID = id;
            this.Type = type;
            this.RelativePath = relativePath;
            this.DoNotCopy = doNotCopy;
        }

        public string GetAbsolutePath(Package package)
        {
            return package.GetAbsolutePath(this.RelativePath);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ManifestItem);
        }

        public bool Equals(ManifestItem other)
        {
            return (other != null && other.ID == this.ID);
        }
    }
}
