using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using QuantumConcepts.CodeGenerator.Core.BatchEditors;
using QuantumConcepts.CodeGenerator.Core;
using log4net;
using System.IO;
using QuantumConcepts.CodeGenerator.Core.Data;

namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    internal partial class Splash : Form
    {
        private static ILog Logger = LogManager.GetLogger(typeof(Splash));

        public Main Main { get; private set; }
        public string ProjectPath { get; private set; }
        public bool LicenseValidationSucceeded { get; private set; }

        public Splash()
        {
            InitializeComponent();
        }

        public Splash(Main main, string projectPath)
            : this()
        {
            this.Main = main;
            this.ProjectPath = projectPath;

            versionLabel.Text = Program.Version.ToString();
            splashTimer.Enabled = true;
        }

        private void splashTimer_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += .1;
            else
            {
                splashTimer.Stop();

                statusLabel.Text = "Validating license...";
#if(!DEBUG)
                this.LicenseValidationSucceeded = Program.ValidateLicense();
#else
                this.LicenseValidationSucceeded = true;
#endif

                statusLabel.Text = "Loading database workers...";

                try
                {
                    DatabaseWorkerManager.Initialize();
                }
                catch (Exception ex)
                {
                    Splash.Logger.Error("Error initializing database workers.", ex);
                    MessageBox.Show("An error occurred while loading one or more database workers. Please see the log for more details.");
                }

                statusLabel.Text = "Loading configuration...";

                try
                {
                    Configuration.Initialize();
                }
                catch (Exception ex)
                {
                    Logger.Error(ex);
                    MessageBox.Show(ex.Message, "Unable to Load Configuration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                this.Main.InitializeRecentProjectsMenu();
                this.Main.InitializeJumpLists();

                statusLabel.Text = "Loading batch editors...";

                try
                {
                    this.Main.InitializeBatchEditors();
                }
                catch (Exception ex)
                {
                    Splash.Logger.Error("Error initializing batch editors.", ex);
                    MessageBox.Show("An error occurred while loading one or more batch editors. Please see the log for more details.");
                }

                statusLabel.Text = "Loading plugins...";

                try
                {
                    this.Main.InitializePlugins();
                }
                catch (Exception ex)
                {
                    Splash.Logger.Error("Error initializing plugins.", ex);
                    MessageBox.Show("An error occurred while loading one or more plugins. Please see the log for more details.");
                }

                if(!string.IsNullOrEmpty(this.ProjectPath))
                {
                    statusLabel.Text = "Opening project...";
                    this.Main.OpenProject(this.ProjectPath, false);
                }

                statusLabel.Text = "Done.";

                this.Close();
            }
        }
    }
}