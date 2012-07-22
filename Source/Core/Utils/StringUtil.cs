using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.Utils
{
    internal static class StringUtil
    {
        public static bool ToBool(string value)
        {
            value = value.ToLower();

            return (value != null && (value.Equals("1") || value.Equals("y") || value.Equals("yes") || value.Equals("true")));
        }
    }
}
