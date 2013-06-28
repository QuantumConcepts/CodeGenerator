using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Text.RegularExpressions;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.Xml.XPath;
using System.Collections;

namespace QuantumConcepts.CodeGenerator.Core.Utils
{
    public static class XmlUtil
    {
        public static XmlNamespaceManager GetXmlNamespaceManager(XmlDocument document)
        {
            XmlNamespaceManager nsm = new XmlNamespaceManager(document.NameTable);

            AddNamespaces(nsm);

            return nsm;
        }

        public static XmlNamespaceManager GetXmlNamespaceManager(XmlReader reader)
        {
            XmlNamespaceManager nsm = new XmlNamespaceManager(reader.NameTable);

            AddNamespaces(nsm);

            return nsm;
        }

        private static void AddNamespaces(XmlNamespaceManager nsm)
        {
            nsm.AddNamespace("P", ProjectSchema.Project.XmlNamespace);
            nsm.AddNamespace("U", ProjectSchema.UserSettings.XmlNamespace);
        }

        public static List<IComingledXPathExpressionPart> ParseComingledXPathExpression(string expression)
        {
            const string Regex_Text = "Text";
            const string Regex_XPath = "XPath";
            const string Regex_Exp = "(?:(?<" + Regex_Text + ">[^{]+))|(?:{(?<" + Regex_XPath + ">[^}]+)})*";

            MatchCollection matches = Regex.Matches(expression, Regex_Exp);
            List<IComingledXPathExpressionPart> parts = new List<IComingledXPathExpressionPart>();

            foreach (Match match in matches)
            {
                Group text = match.Groups[Regex_Text];
                Group xPath = match.Groups[Regex_XPath];
                List<Group> groups = new List<Group>() { text, xPath };

                groups = groups.Where(g => g != null && !g.Value.IsNullOrEmpty()).ToList();
                groups = groups.OrderBy(g => g.Index).ToList();

                foreach (Group group in groups)
                {
                    if (group == text)
                        parts.Add(new ComingledXPathExpressionTextPart(group.Value));
                    else if (group == xPath)
                        parts.Add(new ComingledXPathExpressionXPathPart(group.Value));
                }
            }

            return parts;
        }

        public static List<ComingledXPathExpressionResult> ComputeComingledXPathExpression(Project project, ElementType elementType, string filterXPath, string expression)
        {
            List<IComingledXPathExpressionPart> parts = ParseComingledXPathExpression(expression);

            return ComputeComingledXPathExpression(project, elementType, filterXPath, parts);
        }

        public static List<ComingledXPathExpressionResult> ComputeComingledXPathExpression(Project project, ElementType elementType, string filterXPath, List<IComingledXPathExpressionPart> parts)
        {
            XmlNamespaceManager nsm = null;
            XDocument projectDocument = project.GetXDocument(out nsm);
            string baseXPath = GetBaseXPathForElementType(elementType);
            IEnumerable<XElement> elements = projectDocument.XPathSelectElements(baseXPath, nsm);
            List<ComingledXPathExpressionResult> results = new List<ComingledXPathExpressionResult>();

            //If a filter was supplied, further filter the elements.
            if (!filterXPath.IsNullOrEmpty())
            {
                try
                {
                    string xPath = "{0}[{1}]".FormatString(baseXPath, filterXPath);
                    IEnumerable<XElement> filteredElements = projectDocument.XPathSelectElements(xPath, nsm);

                    elements = elements.Intersect(filteredElements);
                }
                catch (XPathException ex)
                {
                    throw new ApplicationException("Error parsing Filter XPath.", ex);
                }
            }

            try
            {
                foreach (XElement element in elements)
                    results.Add(ComputeComingledXPathExpression(element, elementType, parts));
            }
            catch (XPathException ex)
            {
                throw new ApplicationException("Error computing comingled XPath.", ex);
            }

            return results;
        }

        public static ComingledXPathExpressionResult ComputeComingledXPathExpression(XElement element, ElementType elementType, List<IComingledXPathExpressionPart> parts)
        {
            string nameXPath = GetXPathForNameForElementType(elementType);
            XAttribute nameAttribute = (XAttribute)((IEnumerable)element.XPathEvaluate(nameXPath)).Cast<object>().First();
            StringBuilder path = new StringBuilder();

            foreach (IComingledXPathExpressionPart part in parts)
                path.Append(part.GetValue(element));

            return new ComingledXPathExpressionResult(element, nameAttribute.Value, path.ToString());
        }

        public static string GetBaseXPathForElementType(ElementType elementType)
        {
            if (elementType == ElementType.Table)
                return "/P:Project/P:TableMappings/P:TableMapping";
            else if (elementType == ElementType.ForeignKey)
                return "/P:Project/P:ForeignKeyMappings/P:ForeignKeyMapping";
            else if (elementType == ElementType.UniqueIndex)
                return "/P:Project/P:TableMappings/P:TableMapping/P:UniqueIndexMappings/P:UniqueIndexMapping";
            else if (elementType == ElementType.API)
                return "/P:Project/P:TableMappings/P:TableMapping/P:APIs/P:API";

            throw new ApplicationException("Unhandled TemplateOutputDefinitionElementType of \"{0}.\"".FormatString(elementType));
        }

        public static string GetXPathForNameForElementType(ElementType elementType)
        {
            if (elementType == ElementType.Table)
                return "@TableName";
            else if (elementType == ElementType.ForeignKey)
                return "@ForeignKeyName";
            else if (elementType == ElementType.UniqueIndex)
                return "@UniqueIndexName";
            else if (elementType == ElementType.API)
                return "@Name";

            throw new ApplicationException("Unhandled TemplateOutputDefinitionElementType of \"{0}.\"".FormatString(elementType));
        }

        public static string GetNameForElement(ElementType elementType, XElement element)
        {
            string nameXPath = GetXPathForNameForElementType(elementType);
            XAttribute nameAttribute = (XAttribute)((IEnumerable)element.XPathEvaluate(nameXPath)).Cast<object>().First();

            if (nameAttribute == null)
                throw new ApplicationException("Could not determine name for element of type \"{0}.\"".FormatString(elementType));

            return nameAttribute.Value;
        }

        public static string GetNameForParentElement(ElementType elementType, XElement element)
        {
            ElementType parentElementType;
            XElement parentElement = null;

            switch (elementType)
            {
                case ElementType.Annotation:
                case ElementType.Attribute:
                case ElementType.Column:
                case ElementType.Parameter:
                case ElementType.UniqueIndex:
                {
                    //These elements have parents which are two elements shallower.
                    parentElement = element.Parent.Parent;
                    break;
                }
                case ElementType.API:
                case ElementType.ForeignKey:
                case ElementType.Table:
                {
                    //These elements don't have parents.
                    return null;
                }
            }

            if (parentElement == null)
                throw new ApplicationException("Could not determine parent element for element of type \"{0}.\"".FormatString(elementType));

            if (TableMapping.ElementName.Equals(parentElement.Name))
                parentElementType = ElementType.Table;
            else
                throw new ApplicationException("Could not determine parent element type for element of type \"{0}.\"".FormatString(elementType));

            return GetNameForElement(parentElementType, parentElement);
        }

        public static IProjectSchemaElement GetElementForXElement(Project project, ElementType elementType, XElement element)
        {
            string elementName = GetNameForElement(elementType, element);
            string parentElementName = GetNameForParentElement(elementType, element);

            if (elementType == ElementType.Table)
                return project.FindTableMapping(element.Attribute("SchemaName").Value, elementName);
            else if (elementType == ElementType.ForeignKey)
                return project.FindForeignKeyMapping(elementName);
            else
            {
                TableMapping tableMapping = project.FindTableMapping(((XAttribute)element.XPathEvaluate("ancestor::TableMapping/@SchemaName")).Value, parentElementName);

                if (elementType == ElementType.Column)
                    return tableMapping.FindColumnMapping(elementName);
                else if (elementType == ElementType.UniqueIndex)
                    return tableMapping.FindUniqueIndexMapping(elementName);
                else if (elementType == ElementType.API)
                    return tableMapping.FindAPI(elementName);
            }

            throw new ApplicationException("Unhandled TemplateOutputDefinitionElementType of \"{0}.\"".FormatString(elementType));
        }
    }
}
