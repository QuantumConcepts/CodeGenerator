using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    public interface IAttribute
    {
        string Key { get; set; }
        string Value { get; set; }
    }
}
