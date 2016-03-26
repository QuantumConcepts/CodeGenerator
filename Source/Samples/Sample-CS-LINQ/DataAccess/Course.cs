using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Sample.DataAccess
{
    public partial class Course
    {
        public string FullName { get { return string.Format("{0}: {1}", this.Number, this.Name); } }
    }
}
