using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using System.Linq;
using QuantumConcepts.Common.Extensions;

namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    internal partial class About : Form
    {
        public bool LicenseValidationSucceeded { get; private set; }

        public About()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            versionLabel.Text = Program.Version.ToString();
            copyrightLabel.Text = copyrightLabel.Text.FormatString(DateTime.Now.Year);
        }

        private void link_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("http://{0}".FormatString(((LinkLabel)sender).Text));
        }

        private void closeLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}