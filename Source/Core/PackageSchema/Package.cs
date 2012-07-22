using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using QuantumConcepts.CodeGenerator.Core.Utils;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.Common.Zip;

namespace QuantumConcepts.CodeGenerator.Core.PackageSchema
{
    [XmlRoot(Namespace = Package.XmlNamespace)]
    public class Package
    {
        public const string PackageXmlFileName = "Package.xml";
        public const string PackageIconFileName = "PackageIcon.png";

        [XmlIgnore]
        public const string XmlNamespace = "http://Schemas.QuantumConceptsCorp.com/CodeGenerator/Package.xsd";

        [XmlIgnore]
        public string Path { get; private set; }

        [XmlAttribute]
        public string Version { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlElement]
        public string Description { get; set; }

        [XmlArray]
        [XmlArrayItem(ElementName = "Item", Type = typeof(PackageReferenceItem))]
        public List<PackageReferenceItem> PackageReferences { get; set; }

        [XmlElement]
        public Manifest Manifest { get; set; }

        [XmlArray]
        public List<Input> Inputs { get; set; }

        [XmlArray]
        [XmlArrayItem(ElementName = "CopyAll", Type = typeof(CopyAllAction))]
        [XmlArrayItem(ElementName = "Copy", Type = typeof(CopyAction))]
        [XmlArrayItem(ElementName = "ApplyAllInputReplacements", Type = typeof(ApplyAllInputReplacementsAction))]
        [XmlArrayItem(ElementName = "ApplyInputReplacements", Type = typeof(ApplyInputReplacementsAction))]
        [XmlArrayItem(ElementName = "Rename", Type = typeof(RenameAction))]
        [XmlArrayItem(ElementName = "ReplaceText", Type = typeof(ReplaceTextAction))]
        public List<BaseAction> Actions { get; set; }

        public ManifestItem GetManifestItemByID(string id)
        {
            return this.Manifest.Items.ValueOrDefault(i => i.SingleOrDefault(f => string.Equals(f.ID, id)));
        }

        public Input GetInputByID(string id)
        {
            return this.Inputs.ValueOrDefault(i => i.OfType<Input>().ValueOrDefault(l => l.SingleOrDefault(f => string.Equals(f.ID, id))));
        }

        public string GetAbsolutePath(string relativePath)
        {
            return @"{0}\{1}".FormatString(System.IO.Path.GetDirectoryName(this.Path), relativePath);
        }

        public void Save()
        {
            if (File.Exists(this.Path))
                File.Delete(this.Path);

            this.Version = CommonUtil.GetApplicationVersion().ToString();

            using (FileStream stream = File.Open(this.Path, FileMode.OpenOrCreate))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Package));

                serializer.Serialize(stream, this);
            }
        }

        public void SaveAs(string fileName)
        {
            this.Path = fileName;
            Save();
        }

        public void ExtractPackageFile(string relativeFilePath, Stream outputStream)
        {
            ExtractPackageFile(this.Path, relativeFilePath, outputStream);
        }

        private void MergeWith(Package otherPackage)
        {
            if (otherPackage != null)
            {
                this.Manifest.Items.InsertRange(0, otherPackage.Manifest.Items.Where(oa => !this.Manifest.Items.Any(a => a.Equals(oa))));
                this.Inputs.InsertRange(0, otherPackage.Inputs.Where(oa => !this.Inputs.Any(a => a.Equals(oa))));
                this.Actions.InsertRange(0, otherPackage.Actions.Where(oa => !this.Actions.Any(a => a.Equals(oa))));
            }
        }

        public static Package Open(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException("Package file '" + path + "' could not be opened.");

            XmlSerializer serializer = new XmlSerializer(typeof(Package));
            Package package = null;

            using (MemoryStream packageXmlStream = new MemoryStream())
            {
                ExtractPackageFile(path, Package.PackageXmlFileName, packageXmlStream);
                packageXmlStream.Seek(0, SeekOrigin.Begin);
                package = (Package)serializer.Deserialize(packageXmlStream);
            }

            package.Path = path;

            if (!package.PackageReferences.IsNullOrEmpty())
            {
                package.PackageReferences.ForEach(pr =>
                {
                    pr.OpenPackage(package);
                    package.MergeWith(pr.Package);
                });
            }

            return package;
        }

        public static void ExtractPackageFile(string packagePath, string relativeFilePath, Stream outputStream)
        {
            using (FileStream packageStream = File.OpenRead(packagePath))
            {
                SimpleZip.UnzipFile(packageStream, outputStream, relativeFilePath, null);
            }
        }
    }
}