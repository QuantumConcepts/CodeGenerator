using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.Common.Utils;

namespace QuantumConcepts.CodeGenerator.Core.Utils
{
    public static class Extensions
    {
        public static string Pad(this LogSeverity severity)
        {
            return severity.Pad(' ');
        }

        public static string Pad(this LogSeverity severity, char pad)
        {
            int length = EnumUtil.GetEnumValues<LogSeverity>().Max(v => v.ValueString.Length);

            return severity.ToString().PadRight(length, pad);
        }
    }
}
