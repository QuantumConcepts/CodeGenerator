using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System;
using System.Collections.Generic;
using System.Xml;

namespace QuantumConcepts.CodeGenerator.Core.Upgrade
{
    public class Upgrader_1_7_4_0 : IUpgrader
    {
        public Version Version { get { return new Version(1, 7, 4, 0); } }

        public void Upgrade(string projectPath, string userSettingsPath, ref XmlDocument projectDocument, ref XmlDocument userSettingsDocument, ref System.Xml.XmlNamespaceManager nsm)
        {
            XmlElement defaultConnectionInfo = projectDocument.CreateElement("ConnectionInfo", Project.XmlNamespace);
            XmlElement projectConnectionInfoContainer = projectDocument.CreateElement("Connections", Project.XmlNamespace);
            XmlElement projectElement = (XmlElement)projectDocument.SelectSingleNode("/P:Project", nsm);
            string newConnectionName = "Default";

            defaultConnectionInfo.SetAttribute("Name", newConnectionName);
            projectConnectionInfoContainer.AppendChild(defaultConnectionInfo);
            projectElement.AppendChild(projectConnectionInfoContainer);

            foreach (XmlElement node in projectDocument.SelectNodes("//P:TableMapping", nsm))
                node.SetAttribute("ConnectionName", newConnectionName);

            foreach (XmlElement node in projectDocument.SelectNodes("//P:TableMapping//P:ColumnMapping//P:EnumerationMapping[@IsReference='true']", nsm))
                node.SetAttribute("ReferencedConnectionName", newConnectionName);

            foreach (XmlElement node in projectDocument.SelectNodes("//P:ForeignKeyMapping", nsm))
                node.SetAttribute("ConnectionName", newConnectionName);

            foreach (XmlElement node in projectDocument.SelectNodes("//P:Parameter[@Type='DataObject']", nsm))
                node.SetAttribute("DataTypeReferencedTableMappingConnectionName", newConnectionName);

            //Push Connection element into parent Connections element.
            if (userSettingsDocument != null)
            {
                XmlElement connection = (XmlElement)userSettingsDocument.SelectSingleNode("//U:Connection", nsm);
                XmlElement connectionsParent = userSettingsDocument.CreateElement("Connections", UserSettings.XmlNamespace);
                XmlElement userSettingsElement = (XmlElement)userSettingsDocument.SelectSingleNode("/U:UserSettings", nsm);

                connection.SetAttribute("Name", newConnectionName);
                connection.SetAttribute("ConnectionString", connection.InnerText);
                connection.InnerText = null;
                connectionsParent.AppendChild(connection);
                userSettingsElement.AppendChild(connectionsParent);
            }
        }

        public void UpgradeTemplates(IEnumerable<ProjectSchema.Template> templates)
        {
        }
    }
}
