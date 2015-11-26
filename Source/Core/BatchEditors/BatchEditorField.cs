using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.CodeGenerator.Core.Utils;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;

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

        public ComingledXPathExpressionResult GetValue(XElement element, XmlNamespaceManager nsm, ElementType elementType)
        {
            return XmlUtil.ComputeComingledXPathExpression(element, nsm, elementType, this.XPathParts);
        }
    }
}
