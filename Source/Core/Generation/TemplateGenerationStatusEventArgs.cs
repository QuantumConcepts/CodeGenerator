using System;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;

namespace QuantumConcepts.CodeGenerator.Core.Generation
{
    public delegate void TemplateGenerationStatusEventHandler(IGenerator generator, TemplateGenerationStatusEventArgs e);

    public class TemplateGenerationStatusEventArgs : GenerationStatusEventArgs
    {
        public Template Template { get; protected set; }

        protected TemplateGenerationStatusEventArgs(Template template, GenerationStatus status, Exception error = null)
            : base(status, error)
        {
            this.Template = template;
        }

        public static TemplateGenerationStatusEventArgs CreateCompiling(Template template)
        {
            if (template == null)
                throw new ArgumentNullException("template");

            return new TemplateGenerationStatusEventArgs(template, GenerationStatus.Compiling);
        }

        public static TemplateGenerationStatusEventArgs CreateError(Template template, Exception error)
        {
            if (template == null)
                throw new ArgumentNullException("template");

            if (error == null)
                throw new ArgumentNullException("error");

            return new TemplateGenerationStatusEventArgs(template, GenerationStatus.Error, error);
        }

        public static TemplateGenerationStatusEventArgs CreateWaiting(Template template)
        {
            if (template == null)
                throw new ArgumentNullException("template");

            return new TemplateGenerationStatusEventArgs(template, GenerationStatus.Waiting);
        }

        public static TemplateGenerationStatusEventArgs CreateComplete(Template template)
        {
            if (template == null)
                throw new ArgumentNullException("template");

            return new TemplateGenerationStatusEventArgs(template, GenerationStatus.Complete);
        }
    }
}
