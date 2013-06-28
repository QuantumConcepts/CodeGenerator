using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;

namespace QuantumConcepts.CodeGenerator.Core.Upgrade
{
    public interface IUpgrader
    {
        Version Version { get; }

        void Upgrade(string projectPath, string userSettingsPath, ref XmlDocument projectDocument, ref XmlDocument userSettingsDocument, ref XmlNamespaceManager nsm);
        void UpgradeTemplates(IEnumerable<Template> templates);
    }
}
