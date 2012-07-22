using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using QuantumConcepts.Common.Extensions;

namespace QuantumConcepts.CodeGenerator.Core.PackageSchema
{
    [XmlRoot]
    public class ApplyInputReplacementsAction : BaseAction, IReferencesInput, IReferencesManifestItem, IEquatable<ApplyInputReplacementsAction>
    {
        [XmlAttribute]
        public string InputID { get; set; }

        [XmlAttribute]
        public string ManifestItemID { get; set; }

        public override void Apply(PackageContext packageContext)
        {
            ManifestItem manifestItem = packageContext.Package.GetManifestItemByID(this.ManifestItemID);
            InputResult inputResult = packageContext.GetInputResultByID(this.InputID);

            if (manifestItem == null)
                throw new ApplicationException("Could not locate manifest item with ID \"{0}\".".FormatString(this.ManifestItemID));

            if (inputResult == null)
                throw new ApplicationException("Could not locate input with ID \"{0}\".".FormatString(this.InputID));

            Apply(packageContext, manifestItem, inputResult);
        }

        public static void Apply(PackageContext packageContext, ManifestItem manifestItem, InputResult inputResult)
        {
            if (inputResult == null)
                throw new ArgumentNullException("inputResult");

            ReplaceTextAction.Apply(packageContext, manifestItem, @"\{{{0}\}}".FormatString(inputResult.Input.ID), inputResult.Value);
        }

        public static string Apply(string text, InputResult inputResult)
        {
            return ReplaceTextAction.Apply(text, @"\{{{0}\}}".FormatString(inputResult.Input.ID), inputResult.Value);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as ApplyInputReplacementsAction);
        }

        public bool Equals(ApplyInputReplacementsAction other)
        {
            return (other != null && this.InputID == other.InputID && this.ManifestItemID == other.ManifestItemID);
        }
    }
}
