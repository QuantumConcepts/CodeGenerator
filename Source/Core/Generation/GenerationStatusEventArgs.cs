using System;

namespace QuantumConcepts.CodeGenerator.Core.Generation
{
    public delegate void GenerationStatusEventHandler(IGenerator generator, GenerationStatusEventArgs e);

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
