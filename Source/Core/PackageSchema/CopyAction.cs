using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using QuantumConcepts.Common.Extensions;
using System.IO;
using QuantumConcepts.Common.Zip;

namespace QuantumConcepts.CodeGenerator.Core.PackageSchema
{
    [XmlRoot]
    public class CopyAction : BaseAction, IReferencesManifestItem, IEquatable<CopyAction>
    {
        [XmlAttribute]
        public string ManifestItemID { get; set; }

        [XmlAttribute]
        public string RelativePath { get; set; }

        [XmlAttribute]
        public bool SkipIfExists { get; set; }

        public override void Apply(PackageContext packageContext)
        {
            ManifestItem manifestItem = packageContext.Package.GetManifestItemByID(this.ManifestItemID);

            if (manifestItem == null)
                throw new ApplicationException("Could not locate manifest item with ID \"{0}\".".FormatString(this.ManifestItemID));

            Apply(packageContext, manifestItem, packageContext.GetAbsoluteOutputPath(this.RelativePath), !this.SkipIfExists);
        }

        public static void Apply(PackageContext packageContext, ManifestItem manifestItem, string destinationPath, bool overwrite)
        {
            if (manifestItem == null)
                throw new ArgumentNullException("manifestItem");

            if (!File.Exists(destinationPath) || overwrite)
            {
                using (Stream inputStream = File.OpenRead(packageContext.Package.Path))
                {
                    using (Stream outputStream = File.OpenWrite(destinationPath))
                    {
                        SimpleZip.UnzipFile(inputStream, outputStream, manifestItem.RelativePath, null);
                    }
                }
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CopyAction);
        }

        public bool Equals(CopyAction other)
        {
            return (other != null && this.ManifestItemID == other.ManifestItemID && this.RelativePath == other.RelativePath);
        }
    }
}
