using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Collections;
using System.Xml.XPath;

namespace QuantumConcepts.CodeGenerator.Core.Utils
{
    public class ComingledXPathExpressionXPathPart : IComingledXPathExpressionPart
    {
        public string RawValue { get; private set; }

        public ComingledXPathExpressionXPathPart(string rawValue)
        {
            this.RawValue = rawValue;
        }

        public string GetValue(XElement element)
        {
            object pathPartElement = ((IEnumerable)element.XPathEvaluate(this.RawValue)).Cast<object>().FirstOrDefault();

            if (pathPartElement != null)
                return (pathPartElement is XAttribute ? ((XAttribute)pathPartElement).Value : ((XElement)pathPartElement).Value);

            return string.Empty;
        }
    }
}
