using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;

namespace QuantumConcepts.CodeGenerator.Core
{
    public class GenerationStatusEventArgs : EventArgs
    {
        public GenerationStatus Status { get; protected set; }
        public Exception Error { get; protected set; }

        protected GenerationStatusEventArgs(GenerationStatus status, Exception error = null)
        {
            this.Status = status;
            this.Error = error;
        }

        public static GenerationStatusEventArgs CreateGenerating()
        {
            return new GenerationStatusEventArgs(GenerationStatus.Generating);
        }

        public static GenerationStatusEventArgs CreateError(Exception error)
        {
            if (error == null)
                throw new ArgumentNullException("error");

            return new GenerationStatusEventArgs(GenerationStatus.Error, error);
        }

        public static GenerationStatusEventArgs CreateComplete()
        {
            return new GenerationStatusEventArgs(GenerationStatus.Complete);
        }
    }
}
