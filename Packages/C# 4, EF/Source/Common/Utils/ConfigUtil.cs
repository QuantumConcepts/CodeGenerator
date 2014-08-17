using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace {RootNamespace}.Common.Utils
{
    /// <summary>Exposes common functionality to access configuration settings (as stored in the application or web configuration file).</summary>
    public class ConfigUtil
    {
        public static new ConfigUtil Instance { get; private set; }

        static ConfigUtil()
        {
            ConfigUtil.Instance = new ConfigUtil();
        }

        private ConfigUtil() { }

        /// <summary>Gets the database connection string to use.</summary>
        public string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["Default"].ConnectionString;
            }
        }
    }
}
