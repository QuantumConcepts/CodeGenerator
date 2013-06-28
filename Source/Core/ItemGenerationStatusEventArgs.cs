using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;

namespace QuantumConcepts.CodeGenerator.Core
{
    public class ItemGenerationStatusEventArgs : TemplateGenerationStatusEventArgs
    {
        public TemplateOutputDefinitionFilenameResult Result { get; protected set; }

        protected ItemGenerationStatusEventArgs(Template template, TemplateOutputDefinitionFilenameResult result, GenerationStatus status, Exception error = null)
            : base(template, status, error)
        {
            this.Result = result;
        }

        public static ItemGenerationStatusEventArgs CreateGenerating(Template template, TemplateOutputDefinitionFilenameResult result)
        {
            if (template == null)
                throw new ArgumentNullException("template");

            if (result == null)
                throw new ArgumentNullException("result");

            return new ItemGenerationStatusEventArgs(template, result, GenerationStatus.Generating);
        }

        public static ItemGenerationStatusEventArgs CreateError(Template template, TemplateOutputDefinitionFilenameResult result, Exception error)
        {
            if (template == null)
                throw new ArgumentNullException("template");

            if (result == null)
                throw new ArgumentNullException("result");

            if (error == null)
                throw new ArgumentNullException("error");

            return new ItemGenerationStatusEventArgs(template, result, GenerationStatus.Error, error);
        }

        public static ItemGenerationStatusEventArgs CreateComplete(Template template, TemplateOutputDefinitionFilenameResult result)
        {
            if (template == null)
                throw new ArgumentNullException("template");

            if (result == null)
                throw new ArgumentNullException("result");

            return new ItemGenerationStatusEventArgs(template, result, GenerationStatus.Complete);
        }
    }
}
