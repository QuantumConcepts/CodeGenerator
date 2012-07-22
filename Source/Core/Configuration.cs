using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.Xml.Serialization;
using System.Reflection;
using System.IO;
using System.IO.IsolatedStorage;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.CodeGenerator.Client.Plugins;
using QuantumConcepts.CodeGenerator.Core.Data;

namespace QuantumConcepts.CodeGenerator.Core
{
    [XmlRoot]
    public class Configuration
    {
        private const string FileName = "Configuration.xml";

        [XmlIgnore]
        public static Configuration Instance { get; private set; }

        [XmlIgnore]
        public static string CodeBase { get { return Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath); } }

        [XmlArray]
        public List<string> RecentProjects { get; set; }

        [XmlArray]
        public List<string> LoadedPackages { get; set; }

        [XmlArray]
        public List<PluginConfig> Plugins { get; set; }

        public Configuration()
        {
            this.RecentProjects = new List<string>();
            this.LoadedPackages = new List<string>();
            this.Plugins = new List<PluginConfig>();
        }

        public string AddRecentProject(string path)
        {
            AddFileToList(this.RecentProjects, path);

            if (this.RecentProjects.Count > 10)
                this.RecentProjects = RecentProjects.Take(10).ToList();

            return path;
        }

        public string AddLoadedPackage(string path)
        {
            AddFileToList(this.LoadedPackages, path);

            return path;
        }

        private void AddFileToList(List<string> list, string path)
        {
            if (list == null)
                list = new List<string>();

            if (list.Contains(path))
                list.Remove(path);

            list.Insert(0, path);

            CleanFileList(list);
        }

        private void CleanFileList(List<string> list)
        {
            for (int i = (list.Count - 1); i >= 0; i--)
                if (!File.Exists(list[i]))
                    list.RemoveAt(i);
        }

        private static IsolatedStorageFileStream GetFileStream(FileMode mode, FileAccess access)
        {
            bool existsIgnored;

            return GetFileStream(mode, access, out existsIgnored);
        }

        private static IsolatedStorageFileStream GetFileStream(FileMode mode, FileAccess access, out bool exists)
        {
            IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForAssembly();

            exists = file.FileExists(Configuration.FileName);

            return file.OpenFile(Configuration.FileName, mode, access);
        }

        public void Save()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));

            using (Stream stream = GetFileStream(FileMode.Create, FileAccess.Write))
            {
                serializer.Serialize(stream, this);
            }
        }

        static Configuration()
        {
            bool exists = false;
            XmlSerializer serializer = new XmlSerializer(typeof(Configuration));

            using (IsolatedStorageFileStream stream = GetFileStream(FileMode.Open, FileAccess.Read, out exists))
            {
                if (exists)
                {
                    try
                    {
                        Configuration.Instance = (Configuration)serializer.Deserialize(stream);
                    }
                    catch { }
                }
            }

            //Create a new configuration file if one couldn't be loaded.
            if (Configuration.Instance == null)
            {
                Configuration.Instance = new Configuration();
                Configuration.Instance.Save();
            }
        }

        public static void Initialize() { }
    }

    [XmlRoot]
    public class DataTypeMappingConfiguration
    {
        public string DatabaseType { get; set; }
        public string Language { get; set; }
        public List<DataTypeMapping> DataTypeMappings { get; set; }
    }
}
