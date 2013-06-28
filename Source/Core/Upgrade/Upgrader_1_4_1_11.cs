using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using QuantumConcepts.Common.Utils;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;

namespace QuantumConcepts.CodeGenerator.Core.Upgrade
{
    public class Upgrader_1_4_1_11 : IUpgrader
    {
        public Version Version { get { return new Version(1, 4, 1, 11); } }

        public void Upgrade(string projectPath, string userSettingsPath, ref XmlDocument projectDocument, ref XmlDocument userSettingsDocument, ref XmlNamespaceManager nsm)
        {
            //Renamed "ParameterOfAPI" to "Parameter."
            {
                XmlNodeList nodes = projectDocument.SelectNodes("P:Project/P:TableMappings/P:TableMapping/P:APIs/P:API/P:Parameters/P:ParameterOfAPI", nsm);

                if (nodes != null)
                    nodes.Rename("", "Parameter", ProjectSchema.Project.XmlNamespace);
            }

            //Added "hint paths" to Templates.
            if (userSettingsDocument != null)
            {
                XmlNodeList nodes = userSettingsDocument.SelectNodes("P:UserSettings/P:Templates/P:Template", nsm);

                if (nodes != null)
                {
                    foreach (XmlElement node in nodes)
                    {
                        XmlAttribute xsltPathAttribute = node.Attributes["XsltPath"];
                        string xsltHintPath = FileSystemUtil.AbsolutePathToHintPath(projectPath, xsltPathAttribute.Value);
                        XmlAttribute xsltHintPathAttribute = projectDocument.CreateAttribute("XsltHintPath", ProjectSchema.Project.XmlNamespace);
                        XmlAttribute outputPathAttribute = node.Attributes["OutputPath"];
                        string outputHintPath = FileSystemUtil.AbsolutePathToHintPath(projectPath, outputPathAttribute.Value);
                        XmlAttribute outputHintPathAttribute = projectDocument.CreateAttribute("OutputHintPath", ProjectSchema.Project.XmlNamespace);

                        node.Attributes.InsertBefore(xsltPathAttribute, xsltHintPathAttribute);
                        node.Attributes.Remove(xsltPathAttribute);
                        node.Attributes.InsertBefore(outputPathAttribute, outputHintPathAttribute);
                        node.Attributes.Remove(outputPathAttribute);
                    }
                }
            }
        }

        public void UpgradeTemplates(IEnumerable<Template> templates)
        {

        }
    }
}
