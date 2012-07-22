using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Sample.DataAccess
{
    public partial class Teacher
    {
        public string FullName { get { return string.Format("{0}, {1}", this.LastName, this.FirstName); } }
    }
}
