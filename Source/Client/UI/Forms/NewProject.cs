using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using QuantumConcepts.CodeGenerator.Core;
using QuantumConcepts.CodeGenerator.Core.PackageSchema;
using log4net;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.Common.Forms.UI;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.CodeGenerator.Client.UI.Controls;
using System.Threading;

namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    public partial class NewProject : Form
    {
        private const string _noPackageSelectedText = "Select a package to see its description";

        private static readonly ILog _logger = LogManager.GetLogger(typeof(NewProject));

        private ListViewItem _emptyProjectListViewItem = new ListViewItem("Empty Project", 0);
        private ListViewItem _loadPackageListViewItem = new ListViewItem("Load Package...", 1);
        private Package _selectedPackage = null;

        public NewProject()
        {
            InitializeComponent();

            packageDescriptionLabel.Text = _noPackageSelectedText;
        }

        private void NewPoject_Load(object sender, EventArgs e)
        {
            InitializePackages();
        }

        private void InitializePackages()
        {
            using (new Wait())
            {
                List<ListViewItem> packageListViewItems = new List<ListViewItem>();
                string packagesPath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "Packages");

                packageListView.Items.Clear();
                packageListView.Items.Add(_emptyProjectListViewItem);

                //Load packages in the installation folder.
                if (Directory.Exists(packagesPath))
                    foreach (FileInfo file in Directory.GetFiles(packagesPath, "*.cgk").Select(s => new FileInfo(s)))
                        GetPackageListViewItem(packageListViewItems, file);

                //Load packages that were manually added.
                if (!Configuration.Instance.LoadedPackages.IsNullOrEmpty())
                    foreach (FileInfo file in Configuration.Instance.LoadedPackages.Select(s => new FileInfo(s)).ToList())
                        if (file.Exists)
                            GetPackageListViewItem(packageListViewItems, file);

                packageListViewItems = packageListViewItems.OrderBy(o => o.Text).ToList();
                packageListViewItems.ForEach(o => packageListView.Items.Add(o));

                packageListView.Items.Add(_loadPackageListViewItem);
            }
        }

        private void GetPackageListViewItem(List<ListViewItem> packageListViewItems, FileInfo file)
        {
            Package package = null;
            int imageIndex = 2;

            try
            {
                package = Package.Open(file.FullName);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);

                return;
            }

            //Try to get an icon for the package.
            try
            {
                using (Stream stream = new MemoryStream())
                {
                    package.ExtractPackageFile("PackageIcon.png", stream);
                    stream.Seek(0, SeekOrigin.Begin);
                    packagesImageList.Images.Add(Image.FromStream(stream));
                }

                imageIndex = (packagesImageList.Images.Count - 1);
            }
            catch { }

            packageListViewItems.Add(new ListViewItem(package.Name, imageIndex)
            {
                Tag = package
            });
        }

        private void packageListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!packageListView.SelectedItems.IsNullOrEmpty())
            {
                ListViewItem selectedItem = packageListView.SelectedItems[0];

                nextButton.Enabled = false;

                if (selectedItem == _emptyProjectListViewItem)
                {
                    packageDescriptionLabel.Text = "Choose this option to create a new, empty project.";
                    nextButton.Text = "&OK";
                    nextButton.Enabled = true;
                }
                else if (selectedItem == _loadPackageListViewItem)
                    packageDescriptionLabel.Text = "Double-click this option to load a package which isn't already in the list.";
                else
                {
                    _selectedPackage = (Package)packageListView.SelectedItems[0].Tag;
                    packageDescriptionLabel.Text = _selectedPackage.Description;
                    nextButton.Text = "&Next";
                    nextButton.Enabled = true;
                }
            }
            else
                packageDescriptionLabel.Text = _noPackageSelectedText;
        }

        private void packageListView_DoubleClick(object sender, EventArgs e)
        {
            if (!packageListView.SelectedItems.IsNullOrEmpty())
            {
                ListViewItem selectedItem = packageListView.SelectedItems[0];

                if (selectedItem == _emptyProjectListViewItem)
                    CreateEmptyProject();
                else if (selectedItem == _loadPackageListViewItem)
                    LoadPackage();
                else
                    ShowPackageInputsView();
            }
        }

        private void CreateEmptyProject()
        {
            ProjectContext.Initialize(new Project());
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void LoadPackage()
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.CheckFileExists = true;
                dialog.Filter = "CodeGenerator Packages (*.cgk)|*.cgk";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    Configuration.Instance.AddLoadedPackage(dialog.FileName);
                    Configuration.Instance.Save();
                }
            }

            InitializePackages();
        }

        private void ShowPackageSelectionView()
        {
            packageSelectionPanel.Visible = true;
            packageInputsPanel.Visible = false;
            backButton.Visible = false;
            nextButton.Text = "&Next";
        }

        private void ShowPackageInputsView()
        {
            //Create package inputs.
            packageInputsFlowPanel.Controls.Clear();

            if (!_selectedPackage.Inputs.IsNullOrEmpty())
            {
                foreach (Input input in _selectedPackage.Inputs)
                {
                    PackageInput packageInput = new PackageInput(input);

                    packageInput.Left = 0;
                    packageInput.Width = packageInputsFlowPanel.ClientSize.Width;
                    packageInputsFlowPanel.Controls.Add(packageInput);
                }
            }

            packageSelectionPanel.Visible = false;
            packageInputsPanel.Visible = true;
            backButton.Visible = true;
            nextButton.Text = "&OK";
        }

        private bool CreateProjectFromPackage()
        {
            PackageContext packageContext = null;
            List<InputResult> inputResults = new List<InputResult>();
            Project project = null;

            if (locationTextBox.Text.IsNullOrEmpty() || !Directory.Exists(locationTextBox.Text))
            {
                MessageBox.Show("Please enter or select a valid location to create your project.", null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            progressLabel.Text = "Initializing";
            progressBar.Value = 0;
            progressPanel.Visible = true;

            //Extract package inputs.
            inputResults = packageInputsFlowPanel.Controls.OfType<PackageInput>().Select(c => c.GetInputResult()).ToList();

            //Create the project.
            packageContext = new PackageContext(_selectedPackage, locationTextBox.Text, inputResults);

            try
            {
                ProjectFactory projectFactory = new ProjectFactory();

                projectFactory.ReportProgress += new Common.ReportProgressEventHandler(projectFactory_ReportProgress);
                project = projectFactory.CreateProject(packageContext);
                projectFactory.ReportProgress -= new Common.ReportProgressEventHandler(projectFactory_ReportProgress);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                progressPanel.Visible = false;
                return false;
            }

            ProjectContext.Initialize(project);

            return true;
        }

        private void projectFactory_ReportProgress(string message, long? current, long? total)
        {
            progressLabel.Text = (message ?? progressLabel.Text);

            if (current.HasValue && total.HasValue)
                progressBar.Value = (int)Math.Round((current.Value / (decimal)total.Value) * 100, 0);
        }

        private void backButton_Click(object sender, EventArgs e)
        {
            ShowPackageSelectionView();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            if (packageSelectionPanel.Visible)
            {
                if (_selectedPackage == null)
                    CreateEmptyProject();
                else
                {
                    ShowPackageInputsView();
                    return;
                }
            }
            else if (packageInputsPanel.Visible)
                if (!CreateProjectFromPackage())
                    return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void packageInputsFlowPanel_Resize(object sender, EventArgs e)
        {
            foreach (Control control in packageInputsFlowPanel.Controls)
                control.Width = packageInputsFlowPanel.ClientSize.Width;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    locationTextBox.Text = dialog.SelectedPath;
            }
        }
    }
}