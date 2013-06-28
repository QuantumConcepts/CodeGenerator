using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.IO;

namespace QuantumConcepts.CodeGenerator.Core.PackageSchema
{
    public class PackageContext
    {
        public Package Package { get; private set; }
        public string OutputPath { get; private set; }
        public List<InputResult> InputResults { get; private set; }

        public PackageContext(Package package, string outputPath, List<InputResult> inputResults)
        {
            if (package == null)
                throw new ArgumentNullException("package");

            this.Package = package;
            this.OutputPath = outputPath;
            this.InputResults = inputResults;
        }

        public string GetAbsoluteOutputPath(string relativePath)
        {
            return System.IO.Path.Combine(this.OutputPath, relativePath);
        }

        public InputResult GetInputResultByID(string id)
        {
            return this.InputResults.ValueOrDefault(l => l.SingleOrDefault(i => string.Equals(i.Input.ID, id)));
        }
    }
}
