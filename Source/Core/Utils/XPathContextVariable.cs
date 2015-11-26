using System.Xml.XPath;
using System.Xml.Xsl;

namespace QuantumConcepts.CodeGenerator.Core.Utils
{
    public class XPathContextVariable : IXsltContextVariable
    {
        public string Prefix { get; set; }
        public string Name { get; set; }
        public bool IsLocal { get; } = true;
        public bool IsParam { get; } = false;
        public XPathResultType VariableType { get; set; } = XPathResultType.Any;

        public XPathContextVariable(string prefix, string name)
        {
            this.Prefix = prefix;
            this.Name = name;
        }

        public object Evaluate(XsltContext xsltContext)
        {
            var args = (xsltContext as XPathContext)?.Arguments;

            return args?.GetParam(this.Name, this.Prefix);
        }
    }
}
