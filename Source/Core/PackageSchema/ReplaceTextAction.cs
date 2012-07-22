using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using QuantumConcepts.Common.Extensions;
using System.IO;

namespace QuantumConcepts.CodeGenerator.Core.PackageSchema
{
    [XmlRoot]
    public class ReplaceTextAction : BaseAction
    {
        [XmlAttribute]
        public string ManifestItemID { get; set; }

        [XmlAttribute]
        public string Match { get; set; }

        [XmlAttribute]
        public string Replacement { get; set; }

        public override void Apply(PackageContext packageContext)
        {
            ManifestItem manifestItem = packageContext.Package.GetManifestItemByID(this.ManifestItemID);

            if (manifestItem == null)
                throw new ApplicationException("Could not locate manifest item with ID \"{0}\".".FormatString(this.ManifestItemID));

            Apply(packageContext, manifestItem, this.Match, this.Replacement);
        }

        public static void Apply(PackageContext packageContext, ManifestItem manifestItem, string match, string replacement)
        {
            Regex matchRegex = new Regex(match);

            Apply(packageContext, manifestItem, matchRegex, replacement);
        }

        public static void Apply(PackageContext packageContext, ManifestItem manifestItem, Regex matchRegex, string replacement)
        {
            string manifestItemPath = null;

            if (manifestItem == null)
                throw new ArgumentNullException("manifestItem");

            if (manifestItem.Type != ManifestItemType.File)
                throw new ApplicationException("Can not replace text in a manifest item which is not a file.");

            manifestItemPath = packageContext.GetAbsoluteOutputPath(manifestItem.RelativePath);

            if (!File.Exists(manifestItemPath))
                throw new ApplicationException("Manifest item not found at path \"{0}\".".FormatString(manifestItemPath));

            File.WriteAllText(manifestItemPath, Apply(File.ReadAllText(manifestItemPath), matchRegex, replacement));
        }

        public static string Apply(string text, string match, string replacement)
        {
            Regex matchRegex = new Regex(match);

            return Apply(text, matchRegex, replacement);
        }

        public static string Apply(string text, Regex matchRegex, string replacement)
        {
            return matchRegex.Replace(text, replacement);
        }
    }
}
