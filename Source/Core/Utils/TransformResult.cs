using System;
using System.Collections.Generic;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.Utils
{
    /// <summary>Indicates the result of a transformation.</summary>
    public enum TransformResult
    {
        /// <summary>No result.</summary>
        None,

        /// <summary>Successful.</summary>
        Success,

        /// <summary>Successful - file was overwritten.</summary>
        ForceOverwrite,

        /// <summary>Failure.</summary>
        Failed,

        /// <summary>Skipped.</summary>
        Skipped
    }
}
