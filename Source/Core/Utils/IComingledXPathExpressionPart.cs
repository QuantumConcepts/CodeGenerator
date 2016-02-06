using System.Xml;
using System.Xml.Linq;

namespace QuantumConcepts.CodeGenerator.Core.Utils
{
    public interface IComingledXPathExpressionPart
    {
        string RawValue { get; }
        string GetValue(XElement element, XmlNamespaceManager nsm);
    }
}
