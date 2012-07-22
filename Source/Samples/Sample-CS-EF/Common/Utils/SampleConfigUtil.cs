using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace QuantumConcepts.CodeGenerator.Sample.Common.Utils
{
    /// <summary>Exposes common functionality to access configuration settings (as stored in the application or web configuration file).</summary>
    public class SampleConfigUtil
    {
        public static new SampleConfigUtil Instance { get; private set; }

        static SampleConfigUtil()
        {
            SampleConfigUtil.Instance = new SampleConfigUtil();
        }

        private SampleConfigUtil() { }

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
