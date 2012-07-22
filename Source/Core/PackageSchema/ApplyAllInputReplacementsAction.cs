using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using QuantumConcepts.Common.Extensions;
using System.IO;

namespace QuantumConcepts.CodeGenerator.Core.PackageSchema
{
    [XmlRoot]
    public class ApplyAllInputReplacementsAction : BaseAction, IEquatable<ApplyAllInputReplacementsAction>
    {
        public override void Apply(PackageContext packageContext)
        {
            if (packageContext.Package.Manifest.Automatic)
            {
                foreach (string filePath in Directory.GetFiles(packageContext.OutputPath, "*", SearchOption.AllDirectories))
                {
                    ManifestItem manifestItem = new ManifestItem(null, ManifestItemType.File, filePath.Substring(packageContext.OutputPath.Length + 1), false);

                    foreach (InputResult inputResult in packageContext.InputResults)
                        ApplyInputReplacementsAction.Apply(packageContext, manifestItem, inputResult);
                }
            }
            else
                foreach (ManifestItem item in packageContext.Package.Manifest.Items)
                    foreach (InputResult inputResult in packageContext.InputResults)
                        ApplyInputReplacementsAction.Apply(packageContext, item, inputResult);
        }

        public static string Apply(PackageContext packageContext, string originalText)
        {
            string text = string.Copy(originalText);

            foreach (InputResult inputResult in packageContext.InputResults)
                text = ApplyInputReplacementsAction.Apply(text, inputResult);

            return text;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ApplyAllInputReplacementsAction);
        }

        public bool Equals(ApplyAllInputReplacementsAction other)
        {
            return (other != null);
        }
    }
}
