using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using QuantumConcepts.Common.Utils;

namespace QuantumConcepts.CodeGenerator.Core.Upgrade
{
    public class Upgrader_1_5_0_1 : IUpgrader
    {
        private static readonly string[] ElementNames = 
        {
            "Project", 
            "DataTypeMappings", 
            "DataTypeMapping", 
            "Templates", 
            "Template", 
            "TableMappings", 
            "TableMapping", 
            "ColumnMappings", 
            "ColumnMapping", 
            "Annotations", 
            "Annotation", 
            "Text", 
            "Attributes", 
            "Attribute", 
            "UniqueIndexMappings", 
            "APIs", 
            "API", 
            "ReturnParameter", 
            "Parameters", 
            "Parameter", 
            "UniqueIndexMapping", 
            "ColumnNames", 
            "ColumnName", 
            "EnumerationMapping", 
            "Values", 
            "EnumerationValueMapping", 
            "Description", 
            "ViewMappings", 
            "ViewMapping", 
            "ForeignKeyMappings", 
            "ForeignKeyMapping"
        };
        private List<string> UpgradedIncludes = new List<string>();

        public Version Version { get { return new Version(1, 5, 0, 1); } }

        public void Upgrade(string projectPath, string userSettingsPath, ref XmlDocument projectDocument, ref XmlDocument userSettingsDocument, ref XmlNamespaceManager nsm)
        {
            //Add the namespace to the document.
            {
                ((XmlElement)projectDocument.SelectSingleNode("P:Project", nsm)).Rename("", "Project", ProjectSchema.Project.XmlNamespace);

                if (userSettingsDocument != null)
                    ((XmlElement)userSettingsDocument.SelectSingleNode("U:UserSettings", nsm)).Rename("", "UserSettings", ProjectSchema.UserSettings.XmlNamespace);
            }

            //Remove the "Language" attribute Project.
            {
                XmlAttribute node = (projectDocument.SelectSingleNode("P:Project/@Language", nsm) as XmlAttribute);

                if (node != null)
                    projectDocument.SelectSingleNode("P:Project", nsm).Attributes.Remove(node);
            }

            //Remove the "ServiceName" attribute from Connection.
            if (userSettingsDocument != null)
            {
                XmlElement node = (userSettingsDocument.SelectSingleNode("U:UserSettings/U:Connection/U:ServiceName", nsm) as XmlElement);

                if (node != null && !node.InnerText.IsNullOrEmpty())
                {
                    XmlElement databaseElement = (userSettingsDocument.SelectSingleNode("U:UserSettings/U:Connection/U:Database", nsm) as XmlElement);

                    if (databaseElement == null)
                    {
                        databaseElement = userSettingsDocument.CreateElement("Database", ProjectSchema.UserSettings.XmlNamespace);
                        node.ParentNode.InsertAfter(databaseElement, node);
                    }

                    databaseElement.InnerText = node.InnerText;
                    userSettingsDocument.SelectSingleNode("U:UserSettings/U:Connection", nsm).RemoveChild(node);
                }
            }

            //Moved "OutputDefinitions" into parent element.
            {
                XmlNodeList nodes = projectDocument.SelectNodes("P:Project/P:Templates/P:Template[P:OutputDefinitions]", nsm);

                if (nodes != null)
                {
                    foreach (XmlElement node in nodes)
                    {
                        XmlElement newParent = projectDocument.CreateElement("TemplateOutputDefinitions", ProjectSchema.Project.XmlNamespace);
                        XmlNodeList innerNodes = node.SelectNodes("P:OutputDefinitions", nsm);
                        List<XmlElement> newElements = new List<XmlElement>(innerNodes.Count);

                        node.AppendChild(newParent);

                        foreach (XmlElement innerNode in innerNodes)
                            newParent.AppendChild(innerNode);

                        innerNodes.Rename("", "TemplateOutputDefinition", ProjectSchema.Project.XmlNamespace);
                    }
                }
            }
        }

        public void UpgradeTemplates(IEnumerable<Template> templates)
        {
            Parallel.ForEach(templates, t =>
            {
                UpgradeTemplate(t.XsltAbsolutePath);
            });
        }

        private void UpgradeTemplate(string path)
        {
            if (File.Exists(path))
            {
                string templateContent = File.ReadAllText(path);

                //Replace each element Name if it starts with a double quote or a slash.
                foreach (string elementName in Upgrader_1_5_0_1.ElementNames)
                    templateContent = Regex.Replace(templateContent, "(match=\"|select=\"|test=\"|/|\\[)({0})".FormatString(elementName), "$1P:$2");

                //First, add the namespace to the template.
                templateContent = templateContent.Replace(" xmlns:xsl", " xmlns:P=\"{0}\" xmlns:xsl".FormatString(Project.XmlNamespace));

                //Save the template.
                File.WriteAllText(path, templateContent);

                //Upgrade any included XSLTs.
                foreach (Match match in Regex.Matches(templateContent, "xsl:include href=\"([^\"]+)\""))
                {
                    string includePath = FileSystemUtil.HintPathToAbsolutePath(path, match.Groups[1].Value);
                    bool upgrade = false;

                    lock (this.UpgradedIncludes)
                    {
                        if (!this.UpgradedIncludes.Contains(includePath))
                        {
                            this.UpgradedIncludes.Add(includePath);
                            upgrade = true;
                        }
                    }

                    if (upgrade)
                        UpgradeTemplate(includePath);
                }
            }
        }
    }
}