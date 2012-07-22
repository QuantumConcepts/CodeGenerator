using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.Common.Extensions;
using System.Text.RegularExpressions;

namespace QuantumConcepts.CodeGenerator.Core.PackageSchema
{
    public class InputResult
    {
        public Input Input { get; private set; }
        public string Value { get; private set; }

        public InputResult(Input input, string value)
        {
            this.Input = input;
            this.Value = value;
        }

        public void Validate()
        {
            if (this.Input.Required && this.Value.IsNullOrEmpty())
                throw new ApplicationException("The field {0} is required.".FormatString(this.Input.Label));

            if (!this.Input.Validation.IsNullOrEmpty())
            {
                Regex regex = new Regex(this.Input.Validation);

                if (!regex.IsMatch(this.Value))
                    throw new ApplicationException("The field {0} is not valid.".FormatString(this.Input.Label));
            }
        }
    }
}
