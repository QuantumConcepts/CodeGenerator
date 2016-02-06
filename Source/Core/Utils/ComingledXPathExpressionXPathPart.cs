using System.Linq;
using System.Xml.Linq;
using System.Collections;
using System.Xml.XPath;
using System.Xml;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;

namespace QuantumConcepts.CodeGenerator.Core.Utils
{
    public class ComingledXPathExpressionXPathPart : IComingledXPathExpressionPart
    {
        public string RawValue { get; private set; }

        public ComingledXPathExpressionXPathPart(string rawValue)
        {
            this.RawValue = rawValue;
        }

        public string GetValue(XElement element, XmlNamespaceManager nsm)
        {
            XPathContext context = new XPathContext((NameTable)nsm.NameTable);
            XPathNavigator navigator = element.CreateNavigator();
            object result = null;

            foreach (var ns in nsm.GetNamespacesInScope(XmlNamespaceScope.All))
                context.AddNamespace(ns.Key, ns.Value);

            context.Arguments.AddParam(XPathContext.ParameterNames.CurrentNode, string.Empty, navigator.Select("."));
            result = navigator.Evaluate(this.RawValue, context);

            if (result is string)
                return (string)result;
            else if (result is XPathNodeIterator)
            {
                var iterator = ((XPathNodeIterator)result);
                var current = (XPathNavigator)((IEnumerable)iterator).Cast<object>().First();

                return current.Value;
            }
            else if (result is XAttribute)
                return ((XAttribute)result).Value;
            else if (result is XElement)
                return ((XElement)result).Value;

            return string.Empty;
        }
    }
}
