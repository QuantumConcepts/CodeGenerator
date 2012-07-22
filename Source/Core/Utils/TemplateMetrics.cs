using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.IO;
using QuantumConcepts.Common.Extensions;

namespace QuantumConcepts.CodeGenerator.Core.Utils
{
    internal class TemplateMetrics
    {
        public Template Template { get; private set; }
        public long FileCount { get; private set; }
        public long TotalFileSize { get; private set; }
        public long CharacterCount { get; set; }
        public long LineCount { get; private set; }

        private TemplateMetrics(Template template)
        {
            this.Template = template;
        }

        public static TemplateMetrics Compute(Template template)
        {
            TemplateMetrics metrics = new TemplateMetrics(template);

            foreach (TemplateOutputDefinitionFilenameResult outputFilename in template.GetOutputFilenames())
            {
                metrics.FileCount++;

                if (File.Exists(outputFilename.Value))
                {
                    FileInfo fileInfo = new FileInfo(outputFilename.Value);

                    metrics.TotalFileSize += fileInfo.Length;

                    using (StreamReader reader = File.OpenText(outputFilename.Value))
                    {
                        while (!reader.EndOfStream)
                        {
                            metrics.CharacterCount += reader.ReadLine().ValueOrDefault(s => s.Length);
                            metrics.LineCount++;
                        }
                    }
                }
            }

            return metrics;
        }
    }
}
