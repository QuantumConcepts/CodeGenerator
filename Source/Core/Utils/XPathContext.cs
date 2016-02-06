using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using System.Xml.Xsl;
using QuantumConcepts.Common.Extensions;
using System.Xml;

namespace QuantumConcepts.CodeGenerator.Core.Utils
{
    public class XPathContext : XsltContext
    {
        public static class FunctionNames
        {
            public const string Current = "current";
        }

        public static class ParameterNames
        {
            public const string CurrentNode = "currentNode";
        }

        public Dictionary<string, XPathContextFunction> Functions { get; } = new Dictionary<string, XPathContextFunction>();
        public XsltArgumentList Arguments { get; } = new XsltArgumentList();
        public override bool Whitespace { get; } = true;

        public XPathContext(NameTable nameTable) : base(nameTable)
        {
            this.Functions.Add(FunctionNames.Current, new XPathContextFunction
            {
                ArgTypes = new XPathResultType[] { },
                Executor = (context, argType, args) =>
                {
                    var variable = context.ResolveVariable(null, ParameterNames.CurrentNode);

                    return variable?.Evaluate(context);
                }
            });
        }

        public override int CompareDocument(string baseUri, string nextbaseUri)
        {
            return baseUri.CompareTo(nextbaseUri);
        }

        public override bool PreserveWhitespace(XPathNavigator node)
        {
            return true;
        }

        public override IXsltContextFunction ResolveFunction(string prefix, string name, XPathResultType[] ArgTypes)
        {
            string fullName = GetFullName(prefix, name);
            XPathContextFunction function = this.Functions.SingleOrDefault(o => string.Equals(o.Key, fullName)).Value;

            return function;
        }

        public override IXsltContextVariable ResolveVariable(string prefix, string name)
        {
            var ns = this.LookupNamespace(prefix);
            var arg = this.Arguments.GetParam(name, ns);

            if (arg != null)
                return new XPathContextVariable(prefix, name);

            return null;
            //string fullName = GetFullName(prefix, name);
            //XPathContextVariable variableOrParameter = this.Parameters.Union(this.Variables).FirstOrDefault(o => string.Equals(o.Key, fullName)).Value;

            //return variableOrParameter;
        }

        private static string GetFullName(string prefix, string name)
        {
            return (prefix.IsNullOrEmpty() ? name : $"{prefix}:{name}");
        }
    }
}
