using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace QuantumConcepts.CodeGenerator.Core.Utils
{
    public interface IComingledXPathExpressionPart
    {
        string RawValue { get; }
        string GetValue(XElement element);
    }
}
