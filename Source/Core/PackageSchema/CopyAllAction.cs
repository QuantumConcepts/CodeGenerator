using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.Common.Zip;

namespace QuantumConcepts.CodeGenerator.Core.PackageSchema
{
    [XmlRoot]
    public class CopyAllAction : BaseAction, IEquatable<CopyAllAction>
    {
        [XmlAttribute]
        public bool SkipIfExists { get; set; }

        public override void Apply(PackageContext packageContext)
        {
            List<PackageContext> packageContexts = new List<PackageContext>();

            //Need to look at all packages that are referenced and copy files from them in order.
            packageContexts.AddRange(packageContext.Package.PackageReferences.Select(o => new PackageContext(o.Package, packageContext.OutputPath, packageContext.InputResults)));
            packageContexts.Add(packageContext);

            foreach (PackageContext currentPackageContext in packageContexts)
            {
                if (currentPackageContext.Package.Manifest.Automatic)
                {
                    string[] filesToDelete =
                    {
                        currentPackageContext.GetAbsoluteOutputPath(Package.PackageXmlFileName),
                        currentPackageContext.GetAbsoluteOutputPath(Package.PackageIconFileName)
                    };

                    using (Stream stream = File.OpenRead(currentPackageContext.Package.Path))
                    {
                        SimpleZip.Unzip(stream, packageContext.OutputPath + "\\", null);
                    }

                    //Delete package-related files.
                    foreach (string filePath in filesToDelete)
                        if (File.Exists(filePath))
                            File.Delete(filePath);
                }
                else
                    foreach (ManifestItem item in currentPackageContext.Package.Manifest.Items.Where(i => !i.DoNotCopy))
                        CopyAction.Apply(currentPackageContext, item, currentPackageContext.GetAbsoluteOutputPath(item.RelativePath), true);
            }
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as CopyAllAction);
        }

        public bool Equals(CopyAllAction other)
        {
            return (other != null);
        }
    }
}
