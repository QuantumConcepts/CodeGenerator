using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.Exceptions {
    public class EmptyDatabaseWorkerSpecifiedException : Exception {
        public EmptyDatabaseWorkerSpecifiedException() : this("No database worker was specified.") { }
        public EmptyDatabaseWorkerSpecifiedException(string message) : this(message, null) { }
        public EmptyDatabaseWorkerSpecifiedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
