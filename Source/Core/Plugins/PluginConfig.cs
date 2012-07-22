using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Client.Plugins
{
    [XmlRoot]
    public class PluginConfig
    {
        [XmlAttribute]
        public string TypeName { get; set; }

        [XmlAttribute]
        public bool Enabled { get; set; }

        [XmlArray]
        public List<KeyValuePair<string, string>> Settings { get; set; }

        public PluginConfig()
        {
            this.Settings = new List<KeyValuePair<string, string>>();
        }

        public PluginConfig(Type type, bool enabled) : this(type.FullName, enabled) { }

        public PluginConfig(string typeName, bool enabled)
            : this()
        {
            this.TypeName = typeName;
            this.Enabled = enabled;
        }
    }
}
