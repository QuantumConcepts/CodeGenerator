using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Client.UI.Forms;
using QuantumConcepts.CodeGenerator.Core;
using Microsoft.WindowsAPICodePack.Taskbar;
using log4net;
using System.Reflection;
using QuantumConcepts.Common.Extensions;
using log4net.Config;
using System.IO;
using QuantumConcepts.Common;
using System.ServiceModel;
using QuantumConcepts.Licensing.Client.Utils;
using QuantumConcepts.Licensing.Client;
using QuantumConcepts.Licensing.Client.UI.Forms;
using QuantumConcepts.Common.Forms.UI.Forms;
using QuantumConcepts.Licensing.Common.DataObjects;

namespace QuantumConcepts.CodeGenerator.Client
{
    internal class Program : BaseApp
    {
        private static ILog Logger = LogManager.GetLogger(typeof(Program));

        static Program()
        {
            Program.Initialize("CodeGenerator", "http://www.quantumconceptscorp.com/Products/CodeGenerator.aspx", null);
            XmlConfigurator.Configure();
        }

        internal static bool ValidateLicense()
        {
            try
            {
                LicenseActivationData activationData = LicenseManager.ValidateLicense();

                if (activationData.IsTrial && activationData.IsExpired)
                {
                    using (Trial dialog = new Trial())
                    {
                        if (dialog.ShowDialog() != DialogResult.OK)
                            Application.Exit();
                    }
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("{0} must be activated before you may proceed.".FormatString(Program.ApplicationTitle), "Activation Required", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                Program.Logger.Info(ex);
            }

            using (Activation dialog = new Activation())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    return true;
            }

            return false;
        }

        [STAThread]
        static void Main(string[] arguments)
        {
            Logger.Info("CodeGenerator v{0} started.".FormatString(Program.Version));

            Main main = null;
            string projectPath = null;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Initialize
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);

            //See if a project to open was specified.
            if (arguments != null && arguments.Length > 0)
                projectPath = arguments[0];
            else if (AppDomain.CurrentDomain.SetupInformation.ActivationArguments != null && AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData != null && AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData.Length > 0)
                projectPath = new Uri(AppDomain.CurrentDomain.SetupInformation.ActivationArguments.ActivationData[0]).LocalPath;

            //Create the main form.
            main = new Main();

            //Show the splash screen.
            using (Splash splash = new Splash(main, projectPath))
            {
                splash.ShowDialog();

                if (!splash.LicenseValidationSucceeded)
                {
                    Application.Exit();
                    return;
                }
            }

            //Show the main form.
            Application.Run(main);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            (new Error(e.Exception)).ShowDialog();
        }
    }
}