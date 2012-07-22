using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;

namespace QuantumConcepts.CodeGenerator.Core
{
    internal class TemplateGenerationStatusEventArgs : GenerationStatusEventArgs
    {
        public Template Template { get; protected set; }

        protected TemplateGenerationStatusEventArgs(Template template, GenerationStatus status, Exception error = null)
            : base(status, error)
        {
            this.Template = template;
        }

        public static TemplateGenerationStatusEventArgs CreateGenerating(Template template)
        {
            if (template == null)
                throw new ArgumentNullException("template");

            return new TemplateGenerationStatusEventArgs(template, GenerationStatus.Generating);
        }

        public static TemplateGenerationStatusEventArgs CreateError(Template template, Exception error)
        {
            if (template == null)
                throw new ArgumentNullException("template");

            if (error == null)
                throw new ArgumentNullException("error");

            return new TemplateGenerationStatusEventArgs(template, GenerationStatus.Error, error);
        }

        public static TemplateGenerationStatusEventArgs CreateComplete(Template template)
        {
            if (template == null)
                throw new ArgumentNullException("template");

            return new TemplateGenerationStatusEventArgs(template, GenerationStatus.Complete);
        }
    }
}
