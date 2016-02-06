using System;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace QuantumConcepts.CodeGenerator.Core.Utils
{
    public class XPathContextFunction : IXsltContextFunction
    {
        public XPathResultType[] ArgTypes { get; set; }
        public int Maxargs { get { return this.ArgTypes.Length; } }
        public int Minargs { get { return this.ArgTypes.Length; } }
        public XPathResultType ReturnType { get; } = XPathResultType.Any;
        public Func<XsltContext, XPathResultType[], object[], object> Executor { get; set; }

        public object Invoke(XsltContext xsltContext, object[] args, XPathNavigator docContext)
        {
            return this.Executor(xsltContext, this.ArgTypes, args);
        }
    }
}
