using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.CodeGenerator.Core.Utils;
using System.Xml.Linq;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    internal class TemplateOutputDefinitionFilenameResult : ComingledXPathExpressionResult
    {
        public const string Param_ElementName = "elementName";

        public TemplateOutputDefinitionFilenameResult(XElement element, string elementName, string outputPath)
            : base(element, elementName, outputPath)
        {
        }
    }
}
