using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.PackageSchema
{
    [XmlRoot]
    public class PackageReferenceItem
    {
        [XmlAttribute]
        public string RelativePath { get; set; }

        [XmlIgnore]
        public Package Package { get; private set; }

        public void OpenPackage(Package package)
        {
            this.Package = Package.Open(package.GetAbsolutePath(this.RelativePath));
        }
    }
}
