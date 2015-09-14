using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core
{
    public enum GenerationStatus
    {
        Compiling,
        Waiting,
        Generating,
        Error,
        Complete
    }
}
