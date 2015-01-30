using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.Exceptions {
    public class NonExistentDatabaseWorkerSpecifiedException : Exception {
        public NonExistentDatabaseWorkerSpecifiedException() : this(null) { }
        public NonExistentDatabaseWorkerSpecifiedException(string message) : this(message, null) { }
        public NonExistentDatabaseWorkerSpecifiedException(string message, Exception innerException) : base(message, innerException) { }
    }
}
