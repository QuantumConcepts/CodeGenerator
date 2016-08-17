using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Xsl;
using System.Xml.Serialization;
using System.IO;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.Xml;
using QuantumConcepts.CodeGenerator.Core.Utils;
using QuantumConcepts.Common.Extensions;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Threading;
using log4net;
using System.Collections.Concurrent;
using QuantumConcepts.CodeGenerator.Core.Generation;

namespace QuantumConcepts.CodeGenerator.Core {
    public class GenerationContext : IGenerator {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(GenerationContext));

        public event GenerationStatusEventHandler GenerationStatus;
        public event ItemGenerationStatusEventHandler ItemGenerationStatus;
        public event TemplateGenerationStatusEventHandler TemplateGenerationStatus;

        private Project Project { get; set; }
        private TemplateOutputMap TemplateOutputs { get; set; }

        public GenerationContext(Project project)
            : this(project, project.Templates)
        { }

        public GenerationContext(Project project, IEnumerable<Template> templates)
            : this(project, new TemplateOutputMap(templates))
        { }

        public GenerationContext(Project project, TemplateOutputMap templateOutputs) {
            if (project == null)
                throw new ArgumentNullException(nameof(project));

            if (templateOutputs.IsNullOrEmpty())
                throw new ArgumentNullException(nameof(templateOutputs));

            this.Project = project;
            this.TemplateOutputs = templateOutputs;
        }

        /// <summary>Generates all outputs.</summary>
        public async Task GenerateAsync() {

        }

        private void OnGenerationStatus(GenerationStatusEventArgs e)
        {
            if (this.GenerationStatus != null)
                GenerationStatus(this, e);
        }

        private void OnTemplateGenerationStatus(TemplateGenerationStatusEventArgs e)
        {
            if (this.TemplateGenerationStatus != null)
                TemplateGenerationStatus(this, e);
        }

        private void OnItemGenerationStatus(ItemGenerationStatusEventArgs e)
        {
            if (this.ItemGenerationStatus != null)
                ItemGenerationStatus(this, e);
        }
    }
}
