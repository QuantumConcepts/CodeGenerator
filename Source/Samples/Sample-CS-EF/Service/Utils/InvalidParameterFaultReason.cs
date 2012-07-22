using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;

namespace QuantumConcepts.CodeGenerator.Sample.Service.Utils
{
    public class InvalidParameterFaultReason : FaultReason
    {
        public InvalidParameterFaultReason(string reason) : base(reason) { }
    }
}
