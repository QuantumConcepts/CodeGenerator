using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    public interface IAnnotation : IRenameable
    {
        string Type { get; set; }
        string Text { get; set; }
    }
}
