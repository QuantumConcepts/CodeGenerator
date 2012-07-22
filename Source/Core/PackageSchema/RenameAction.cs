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
    public class RenameAction : BaseAction, IReferencesManifestItem, IEquatable<RenameAction>
    {
        [XmlAttribute]
        public string ManifestItemID { get; set; }

        [XmlAttribute]
        public string NewName { get; set; }

        public override void Apply(PackageContext packageContext)
        {
            ManifestItem manifestItem = packageContext.Package.GetManifestItemByID(this.ManifestItemID);

            if (manifestItem == null)
                throw new ApplicationException("Could not locate manifest item with ID \"{0}\".".FormatString(this.ManifestItemID));

            Apply(packageContext, manifestItem, this.NewName);
        }

        public static void Apply(PackageContext packageContext, ManifestItem manifestItem, string newName)
        {
            string manifestItemPath = null;
            string newNameWithReplacements = null;

            if (manifestItem == null)
                throw new ArgumentNullException("manifestItem");

            manifestItemPath = packageContext.GetAbsoluteOutputPath(manifestItem.RelativePath);

            //Apply input replacements to the new file/folder name.
            newNameWithReplacements = ApplyAllInputReplacementsAction.Apply(packageContext, newName);

            //Remove any invalid characters.
            foreach (char character in Path.GetInvalidPathChars())
                newNameWithReplacements = newNameWithReplacements.Replace(character.ToString(), string.Empty);

            if (manifestItem.Type == ManifestItemType.File)
            {
                FileInfo fileInfo = new FileInfo(manifestItemPath);
                string newPath = Path.Combine(Path.GetDirectoryName(fileInfo.FullName), newNameWithReplacements);

                if (!fileInfo.Exists)
                    throw new ApplicationException("Manifest item not found at path \"{0}\".".FormatString(manifestItemPath));

                if (File.Exists(newPath))
                    File.Delete(newPath);

                fileInfo.MoveTo(newPath);
            }
            else if (manifestItem.Type == ManifestItemType.Folder)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(manifestItemPath);

                if (!directoryInfo.Exists)
                    throw new ApplicationException("Manifest item not found at path \"{0}\".".FormatString(manifestItemPath));

                directoryInfo.MoveTo(Path.Combine(Path.GetDirectoryName(directoryInfo.Parent.FullName), newNameWithReplacements));
            }
        }

        public override bool  Equals(object obj)
        {
            return Equals(obj as RenameAction);
        }

        public bool Equals(RenameAction other)
        {
            return (other != null && this.ManifestItemID == other.ManifestItemID);
        }
    }
}
