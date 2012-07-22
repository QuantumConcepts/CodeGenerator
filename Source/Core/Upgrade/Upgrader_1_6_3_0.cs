using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.CodeGenerator.Core.Data.SqlServer;
using QuantumConcepts.CodeGenerator.Core.Data;

namespace QuantumConcepts.CodeGenerator.Core.Upgrade
{
    public class Upgrader_1_6_3_0 : IUpgrader
    {
        public Version Version { get { return new Version(1, 6, 3, 0); } }

        public void Upgrade(string projectPath, string userSettingsPath, ref XmlDocument projectDocument, ref XmlDocument userSettingsDocument, ref System.Xml.XmlNamespaceManager nsm)
        {
            //Remove elements from Connection and create connection string as text instead.
            foreach (XmlElement node in userSettingsDocument.SelectNodes("//U:Connection", nsm))
            {
                XmlElement type = (XmlElement)node.SelectSingleNode("U:DatabaseType", nsm);
                XmlElement host = (XmlElement)node.SelectSingleNode("U:Host", nsm);
                XmlElement port = (XmlElement)node.SelectSingleNode("U:Port", nsm);
                XmlElement database = (XmlElement)node.SelectSingleNode("U:Database", nsm);
                XmlElement userID = (XmlElement)node.SelectSingleNode("U:UserId", nsm);
                XmlElement password = (XmlElement)node.SelectSingleNode("U:Password", nsm);
                XmlAttribute databaseTypeAttribute = userSettingsDocument.CreateAttribute("DatabaseType");

                if (string.Equals(type.ValueOrDefault(o => o.InnerText), "SQLServer", StringComparison.InvariantCultureIgnoreCase))
                {
                    string hostAndPort = null;

                    if (!port.ValueOrDefault(o => o.Value.IsNullOrEmpty()))
                        hostAndPort = "{0}:{1}".FormatString(host.ValueOrDefault(o => o.InnerText), port.ValueOrDefault(o => o.InnerText));
                    else
                        hostAndPort = host.ValueOrDefault(o => o.InnerText);

                    node.InnerText = "Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3};".FormatString(hostAndPort, database.ValueOrDefault(o => o.InnerText), userID.ValueOrDefault(o => o.InnerText), password.ValueOrDefault(o => o.InnerText));
                    databaseTypeAttribute.Value = (new SqlServerWorker()).Name;
                }
                else
                {
                    node.InnerText = "Host={0}; Port={1}; Database={2}; User ID={3}; Password={4};".FormatString(host.ValueOrDefault(o => o.InnerText), port.ValueOrDefault(o => o.InnerText), database.ValueOrDefault(o => o.InnerText), userID.ValueOrDefault(o => o.InnerText), password.ValueOrDefault(o => o.InnerText));

                    //Try to load the proper database worker to get the name.
                    if (type != null && !type.InnerText.IsNullOrEmpty())
                    {
                        DatabaseWorker worker = DatabaseWorkerManager.Instance[type.InnerText];

                        //Use the name of the worker if one exists.
                        if (worker != null)
                            databaseTypeAttribute.Value = worker.Name;
                    }

                    //Otherwise just use the value from the DatabaseType element.
                    databaseTypeAttribute.Value = type.InnerText;
                }

                //Setting InnerText (as above) will automatically remove all children from the node.
                //Need to add a DatabaseType attribute.
                node.Attributes.Append(databaseTypeAttribute);
            }
        }

        public void UpgradeTemplates(IEnumerable<ProjectSchema.Template> templates)
        {
        }
    }
}
