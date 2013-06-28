using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.IO;

namespace QuantumConcepts.CodeGenerator.Core.Utils
{
    public static class Tools
    {
        /// <summary>Reads through the output file(s) associated with each template and computes metrics for each one.</summary>
        /// <param name="templates">The templates whose metrics will be computed.</param>
        /// <returns>A list of TemplateMetrics.</returns>
        public static List<TemplateMetrics> GetMetricsForTemplates(params Template[] templates)
        {
            List<TemplateMetrics> templateMetrics = new List<TemplateMetrics>(templates.Length);

            foreach (Template template in templates)
                templateMetrics.Add(TemplateMetrics.Compute(template));

            return templateMetrics;
        }
    }
}
