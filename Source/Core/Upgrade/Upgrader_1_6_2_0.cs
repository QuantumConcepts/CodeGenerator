using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Extensions;

namespace QuantumConcepts.CodeGenerator.Core.Upgrade
{
    public class Upgrader_1_6_2_0 : IUpgrader
    {
        public Version Version { get { return new Version(1, 6, 2, 0); } }

        public void Upgrade(string projectPath, string userSettingsPath, ref System.Xml.XmlDocument projectDocument, ref System.Xml.XmlDocument userSettingsDocument, ref System.Xml.XmlNamespaceManager nsm)
        {
            //Add DataTypeReferencedTableMappingSchemaName to each Parameter.
            foreach (XmlAttribute node in projectDocument.SelectNodes("//*/@DataTypeReferencedTableMappingName", nsm))
            {
                XmlAttribute tableSchemaName = (XmlAttribute)node.SelectSingleNode("//P:TableMapping[@TableName='{0}']/@SchemaName".FormatString(node.Value), nsm);
                XmlAttribute dataTypeReferencedTableMappingSchemaName = projectDocument.CreateAttribute("DataTypeReferencedTableMappingSchemaName");

                dataTypeReferencedTableMappingSchemaName.Value = tableSchemaName.Value;

                node.OwnerElement.Attributes.Append(dataTypeReferencedTableMappingSchemaName);
            }

            //Add ParentTableMappingSchemaName and ReferencedTableMappingSchemaName to each Foreign Key Mapping.
            foreach (XmlElement node in projectDocument.SelectNodes("//P:ForeignKeyMapping", nsm))
            {
                XmlAttribute parentTableSchemaName = (XmlAttribute)projectDocument.SelectSingleNode("//P:TableMapping[@TableName='{0}']/@SchemaName".FormatString(node.GetAttribute("ParentTableMappingName")), nsm);
                XmlAttribute referencedTableSchemaName = (XmlAttribute)projectDocument.SelectSingleNode("//P:TableMapping[@TableName='{0}']/@SchemaName".FormatString(node.GetAttribute("ReferencedTableMappingName")), nsm);
                XmlAttribute parentTableMappingSchemaName = projectDocument.CreateAttribute("ParentTableMappingSchemaName");
                XmlAttribute referencedTableMappingSchemaName = projectDocument.CreateAttribute("ReferencedTableMappingSchemaName");

                parentTableMappingSchemaName.Value = parentTableSchemaName.Value;
                referencedTableMappingSchemaName.Value = referencedTableSchemaName.Value;

                node.Attributes.Append(parentTableMappingSchemaName);
                node.Attributes.Append(referencedTableMappingSchemaName);
            }

            //Add ReferencedTableMappingSchemaName to each Enumeration Mapping.
            //Rename ReferencedTableName to ReferencedTableMappingName for each Enumeration Mapping
            foreach (XmlAttribute node in projectDocument.SelectNodes("//P:EnumerationMapping/@ReferencedTableName", nsm))
            {
                XmlAttribute tableSchemaName = (XmlAttribute)projectDocument.SelectSingleNode("//P:TableMapping[@TableName='{0}']/@SchemaName".FormatString(node.Value), nsm);
                XmlAttribute tableMappingSchemaName = projectDocument.CreateAttribute("ReferencedTableMappingSchemaName");
                XmlAttribute tableMappingName = projectDocument.CreateAttribute("ReferencedTableMappingName");

                tableMappingSchemaName.Value = tableSchemaName.Value;
                tableMappingName.Value = node.Value;

                node.OwnerElement.Attributes.Append(tableMappingSchemaName);
                node.OwnerElement.Attributes.Append(tableMappingName);
                node.OwnerElement.Attributes.Remove(node);
            }

            //Remove Template.Name attribute.
            foreach (XmlAttribute node in projectDocument.SelectNodes("//P:Template/@Name", nsm))
                node.OwnerElement.Attributes.Remove(node);
        }

        public void UpgradeTemplates(IEnumerable<ProjectSchema.Template> templates)
        {
        }
    }
}
