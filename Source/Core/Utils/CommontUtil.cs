using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Security.Principal;
using System.Threading;
using System.Reflection;

namespace QuantumConcepts.CodeGenerator.Core.Utils
{
    internal class CommonUtil
    {
        public static WindowsIdentity GetWindowsIdentity()
        {
            return WindowsIdentity.GetCurrent();
        }

        public static string GetWindowsIdentityUsername()
        {
            string username = GetWindowsIdentity().Name;

            return username.Substring(username.LastIndexOf("\\") + 1);
        }

        public static Version GetApplicationVersion()
        {
            return Assembly.GetExecutingAssembly().GetName().Version;
        }
    }
}
