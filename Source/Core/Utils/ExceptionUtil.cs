using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumConcepts.DAOGenerator.Core.Utils
{
    public class ExceptionUtil
    {
        public static string GetExceptionText(Exception exception)
        {
            StringBuilder text = new StringBuilder();
            int depth = 0;

            do
            {
                text.Append((exception.Message + "\n").PadLeft(depth++, '\t'));
            }
            while ((exception = exception.InnerException) != null);

            return text.ToString();
        }
    }
}
