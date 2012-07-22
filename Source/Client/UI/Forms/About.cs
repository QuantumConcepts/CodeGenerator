using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
using QuantumConcepts.Licensing.Common.DataObjects;
using QuantumConcepts.Licensing.Client;
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

            string registeredTo = null;
#if (!DEBUG)
            bool isRegistered = false;

            try
            {
                LicenseActivationData activationData = LicenseManager.ExtractLicenseActivation();

                registeredTo = "{0} {1}".FormatString(activationData.FirstName, activationData.LastName);
                isRegistered = true;
            }
            catch
            {
                registeredTo = "A. Meane Pyrate";
                isRegistered = false;
            }

            if (!isRegistered && !Program.ValidateLicense())
                Application.Exit();
#else
            registeredTo = "Debug Mode";
#endif
            versionLabel.Text = Program.Version.ToString();
            registrationLabel.Text = registrationLabel.Text.FormatString(registeredTo);
            copyrightLabel.Text = copyrightLabel.Text.FormatString(DateTime.Now.Year);

#if (!DEBUG)
            if (!isRegistered && !Program.ValidateLicense())
                Application.Exit();
#endif
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