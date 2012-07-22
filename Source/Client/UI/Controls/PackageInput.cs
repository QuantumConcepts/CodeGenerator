using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.PackageSchema;
using QuantumConcepts.Common.Extensions;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    public partial class PackageInput : UserControl
    {
        public Input Input { get; private set; }

        public PackageInput(Input input)
        {
            InitializeComponent();

            this.Input = input;
            label.Text = "{0}:".FormatString(input.Label);
        }

        public InputResult GetInputResult()
        {
            return new InputResult(this.Input, textBox.Text);
        }
    }
}
