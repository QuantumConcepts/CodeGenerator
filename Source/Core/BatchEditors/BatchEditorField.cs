using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using QuantumConcepts.CodeGenerator.Core.Utils;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;

namespace QuantumConcepts.CodeGenerator.Core.BatchEditors
{
    public class BatchEditorField
    {
        public string Name { get; private set; }
        public string XPath { get; private set; }
        public List<IComingledXPathExpressionPart> XPathParts { get; private set; }

        public BatchEditorField(string name, string xPath)
        {
            this.Name = name;
            this.XPath = xPath;
            this.XPathParts = XmlUtil.ParseComingledXPathExpression(this.XPath);
        }

        public ComingledXPathExpressionResult GetValue(XElement element, ElementType elementType)
        {
            return XmlUtil.ComputeComingledXPathExpression(element, elementType, this.XPathParts);
        }
    }
}
