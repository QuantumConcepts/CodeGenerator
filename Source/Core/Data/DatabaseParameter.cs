using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.Data
{
    public class DatabaseParameter
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public DatabaseParameter(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }
    }
}
