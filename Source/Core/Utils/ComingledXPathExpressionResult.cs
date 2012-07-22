using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace QuantumConcepts.CodeGenerator.Core.Utils
{
    public class ComingledXPathExpressionResult
    {
        public XElement Element { get; private set; }
        public string ElementName { get; private set; }
        public string Value { get; private set; }

        public ComingledXPathExpressionResult(XElement element, string elementName, string value)
        {
            this.Element = element;
            this.ElementName = elementName;
            this.Value = value;
        }
    }
}
