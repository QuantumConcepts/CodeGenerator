using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace QuantumConcepts.CodeGenerator.Core.Utils
{
    internal class ComingledXPathExpressionTextPart : IComingledXPathExpressionPart
    {
        public string RawValue { get; private set; }

        public ComingledXPathExpressionTextPart(string rawValue)
        {
            this.RawValue = rawValue;
        }

        public string GetValue(XElement element)
        {
            return this.RawValue;
        }
    }
}
