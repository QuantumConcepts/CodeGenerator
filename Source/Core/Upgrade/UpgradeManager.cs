using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using QuantumConcepts.Common.Extensions;
using System.Xml;
using QuantumConcepts.CodeGenerator.Core.Utils;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.IO;
using System.Collections;
using log4net;
using System.Reflection;

namespace QuantumConcepts.CodeGenerator.Core.Upgrade
{
    internal class UpgradeManager : IEnumerable<IUpgrader>
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(UpgradeManager));

        public static UpgradeManager Instance { get; private set; }

        private List<IUpgrader> Upgraders { get; set; }

        static UpgradeManager()
        {
            UpgradeManager.Instance = new UpgradeManager();
        }

        private UpgradeManager()
        {
            this.Upgraders = new List<IUpgrader>();
            LoadUpgraders();
        }

        /// <summary>This method performs no operation but will cause the static initializer to fire.</summary>
        public static void Initialize() { }

        private void LoadUpgraders()
        {
            List<string> files = new List<string>();
            Type baseType = typeof(IUpgrader);
            List<Type> typesAdded = new List<Type>();

            files.AddRange(Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "*.dll").ToList());
            files.AddRange(Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "*.exe").ToList());

            this.Upgraders.Clear();

            foreach (string file in files)
            {
                Assembly assembly = null;

                try
                {
                    assembly = Assembly.LoadFrom(file);
                }
                catch (Exception ex)
                {
                    UpgradeManager.Logger.Error("While loading upgraders, could not load assembly \"{0}\".".FormatString(file), ex);
                }

                if (assembly != null)
                {
                    foreach (Type type in assembly.GetTypes().Where(t => t != baseType && baseType.IsAssignableFrom(t)))
                    {
                        if (!typesAdded.Contains(type))
                        {
                            IUpgrader instance = (IUpgrader)Activator.CreateInstance(type);

                            if (instance != null)
                            {
                                this.Upgraders.Add(instance);
                                typesAdded.Add(type);
                            }
                        }
                    }
                }
            }
        }

        public IEnumerable<IUpgrader> GetUpgradersForVersion(Version version)
        {
            return UpgradeManager.Instance.Upgraders.Where(o => version < o.Version).OrderBy(o => o.Version);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.Upgraders.GetEnumerator();
        }

        public IEnumerator<IUpgrader> GetEnumerator()
        {
            return this.Upgraders.GetEnumerator();
        }

        public static XmlDocument OpenDocument(string path, ref XmlNamespaceManager nsm)
        {
            XmlDocument document = new XmlDocument();

            if (nsm == null)
                nsm = XmlUtil.GetXmlNamespaceManager(document);

            document.Load(path);

            return document;
        }

        public static void Open(string projectPath, string userSettingsPath, out XmlDocument projectDocument, out XmlDocument userSettingsDocument, out XmlNamespaceManager nsm)
        {
            nsm = null;
            projectDocument = UpgradeManager.OpenDocument(projectPath, ref nsm);

            if (!userSettingsPath.IsNullOrEmpty() && File.Exists(userSettingsPath))
                userSettingsDocument = UpgradeManager.OpenDocument(userSettingsPath, ref nsm);
            else
                userSettingsDocument = null;
        }

        public static Version GetVersion(string projectPath)
        {
            XmlNamespaceManager nsm = null;

            return GetVersion(OpenDocument(projectPath, ref nsm), nsm);
        }

        public static Version GetVersion(XmlDocument projectDocument, XmlNamespaceManager nsm)
        {
            return Version.Parse(GetVersionAttribute(projectDocument, nsm).Value);
        }

        private static void SetVersion(XmlDocument projectDocument, XmlNamespaceManager nsm, Version version)
        {
            GetVersionAttribute(projectDocument, nsm).Value = version.ToString();
        }

        private static XmlAttribute GetVersionAttribute(XmlDocument projectDocument, XmlNamespaceManager nsm)
        {
            XmlAttribute attribute = (projectDocument.SelectSingleNode("Project/@Version", nsm) as XmlAttribute);

            if (attribute == null)
                attribute = (projectDocument.SelectSingleNode("P:Project/@Version", nsm) as XmlAttribute);

            if (attribute == null)
                throw new ApplicationException("Could not determine project version. Please ensure that the Project element in the project file has a valid Version attribute.");

            return attribute;
        }

        public static void Upgrade(string projectPath, string userSettingsPath)
        {
            XmlNamespaceManager nsm = null;
            XmlDocument projectDocument = null;
            XmlDocument userSettingsDocument = null;

            Open(projectPath, userSettingsPath, out projectDocument, out userSettingsDocument, out nsm);

            if (UpgradeManager.TryUpgrade(projectPath, userSettingsPath, projectDocument, userSettingsDocument, nsm))
                Save(projectPath, userSettingsPath, projectDocument, userSettingsDocument, nsm);
        }

        public static bool TryUpgrade(string projectPath, string userSettingsPath, XmlDocument projectDocument, XmlDocument userSettingsDocument, XmlNamespaceManager nsm)
        {
            Version version = GetVersion(projectDocument, nsm);
            bool upgraded = false;

            foreach (IUpgrader upgrader in UpgradeManager.Instance.GetUpgradersForVersion(version))
            {
                upgrader.Upgrade(projectPath, userSettingsPath, ref projectDocument, ref userSettingsDocument, ref nsm);

                SetVersion(projectDocument, nsm, upgrader.Version);

                upgraded = true;
            }

            return upgraded;
        }

        public static void Save(string projectPath, string userSettingsPath, XmlDocument projectDocument, XmlDocument userSettingsDocument, XmlNamespaceManager nsm)
        {
            XmlWriterSettings settings = new XmlWriterSettings();

            settings.NamespaceHandling = NamespaceHandling.OmitDuplicates;
            settings.Indent = true;
            settings.ConformanceLevel = ConformanceLevel.Document;
            settings.Encoding = Encoding.UTF8;

            using (XmlWriter writer = XmlWriter.Create(projectPath, settings))
            {
                projectDocument.WriteTo(writer);
            }

            if (userSettingsDocument != null)
            {
                using (XmlWriter writer = XmlWriter.Create(userSettingsPath, settings))
                {
                    userSettingsDocument.WriteTo(writer);
                }
            }
        }

        public static void UpgradeTemplates(Version version, IEnumerable<Template> templates)
        {
            foreach (IUpgrader upgrader in UpgradeManager.Instance.GetUpgradersForVersion(version))
                upgrader.UpgradeTemplates(templates);
        }
    }
}