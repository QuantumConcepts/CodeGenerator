using System.Xml;
using System.Xml.Linq;

namespace QuantumConcepts.CodeGenerator.Core.Utils
{
    public class ComingledXPathExpressionTextPart : IComingledXPathExpressionPart
    {
        public string RawValue { get; private set; }

        public ComingledXPathExpressionTextPart(string rawValue)
        {
            this.RawValue = rawValue;
        }

        public string GetValue(XElement element, XmlNamespaceManager nsm)
        {
            return this.RawValue;
        }
    }
}
