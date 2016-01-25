using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema {
    public interface IParameter : IRenameable {
        string Name { get; set; }
    }
}
