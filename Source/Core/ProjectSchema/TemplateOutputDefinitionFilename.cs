using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using QuantumConcepts.Common.Extensions;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Collections;
using System.Xml;
using QuantumConcepts.CodeGenerator.Core.Utils;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    internal class TemplateOutputDefinitionFilename : List<IComingledXPathExpressionPart>
    {
        public List<TemplateOutputDefinitionFilenameResult> Compute(TemplateOutputDefinition templateOutputDefinition)
        {
            return Compute(templateOutputDefinition.ContainingProject, templateOutputDefinition.ElementType, templateOutputDefinition.FilterXPath, templateOutputDefinition.RootAbsolutePath);
        }

        public List<TemplateOutputDefinitionFilenameResult> Compute(Project project, ElementType elementType, string filterXPath, string rootPath)
        {
            string startingPath = rootPath;
            List<ComingledXPathExpressionResult> results = XmlUtil.ComputeComingledXPathExpression(project, elementType, filterXPath, this);

            if (!rootPath.EndsWith(@"\"))
                startingPath += @"\";

            return results.Select(r => new TemplateOutputDefinitionFilenameResult(r.Element, r.ElementName, "{0}{1}".FormatString(startingPath, r.Value))).ToList();
        }

        public static TemplateOutputDefinitionFilename Parse(string filename)
        {
            TemplateOutputDefinitionFilename output = new TemplateOutputDefinitionFilename();

            output.AddRange(XmlUtil.ParseComingledXPathExpression(filename));

            return output;
        }
    }
}