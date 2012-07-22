using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal partial class ProgressPanel : UserControl
    {
        public string Status
        {
            get { return statusLabel.Text; }
            set { statusLabel.Text = value; }
        }

        public ProgressBar ProgressBar
        {
            get { return progressBar; }
        }

        public ProgressPanel()
        {
            InitializeComponent();
        }
    }
}
