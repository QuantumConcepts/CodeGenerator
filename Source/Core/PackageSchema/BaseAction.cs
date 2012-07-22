using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.PackageSchema
{
    public abstract class BaseAction
    {
        public abstract void Apply(PackageContext packageContext);
    }
}
