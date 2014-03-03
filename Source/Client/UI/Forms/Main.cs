using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.CodeGenerator.Core;
using System.Xml.Serialization;
using System.IO;
using QuantumConcepts.CodeGenerator.Core.Utils;
using System.Collections;
using QuantumConcepts.CodeGenerator.Core.Data;
using System.Text.RegularExpressions;
using QuantumConcepts.CodeGenerator.Client.UI.Controls;
using QuantumConcepts.Common.Forms.UI;
using QuantumConcepts.Common.Extensions;
using System.Linq;
using QuantumConcepts.Common.Utils;
using Microsoft.WindowsAPICodePack.Taskbar;
using QuantumConcepts.Common.Forms.Utils;
using QuantumConcepts.CodeGenerator.Core.Upgrade;
using log4net;
using QuantumConcepts.Common.Forms.UI.Controls;
using QuantumConcepts.Common.Forms.UI.Forms;
using System.Reflection;
using System.Diagnostics;
using QuantumConcepts.CodeGenerator.Client.Plugins;
using QuantumConcepts.CodeGenerator.Core.BatchEditors;

namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    public partial class Main : Form
    {
        public const string ATTRIBUTE_AUTOGEN = "AutoGen";

        private static ILog Logger = LogManager.GetLogger(typeof(Main));

        private Dictionary<Type, int> LastShownTabPage { get; set; }
        private Dictionary<Template, TabPage> TemplateTabPages { get; set; }

        private bool _unsavedChanges = false;

        public string ProjectPath { get; private set; }
        public bool UnsavedChanges { get { return _unsavedChanges; } set { _unsavedChanges = value; UpdateTitle(); } }
        public ToolStripMenuItem FileMenu { get { return this.fileMenuItem; } }
        public ToolStripMenuItem ProjectMenu { get { return this.projectMenuItem; } }
        public ToolStripMenuItem ToolsMenu { get { return this.toolsMenuItem; } }
        public ToolStripMenuItem HelpMenu { get { return this.helpMenuItem; } }

        public Main() : this(null) { }

        public Main(string projectPath)
        {
            this.LastShownTabPage = new Dictionary<Type, int>();
            this.TemplateTabPages = new Dictionary<Template, TabPage>();

            InitializeComponent();

            if (!string.IsNullOrEmpty(projectPath))
                this.ProjectPath = projectPath;
        }

        private void new_Click(object sender, EventArgs e)
        {
            New();
        }

        private void open_Click(object sender, EventArgs e)
        {
            OpenProject(false);
        }

        private void save_Click(object sender, EventArgs e)
        {
            Save();
        }

        private void saveAs_Click(object sender, EventArgs e)
        {
            SaveProjectAs();
        }

        private void RecentProjectMenuItem_Click(object sender, EventArgs e)
        {
            OpenProject(((ToolStripMenuItem)sender).Text, true);
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void properties_Click(object sender, EventArgs e)
        {
            Properties();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            RefreshMappings();
        }

        private void generate_Click(object sender, EventArgs e)
        {
            GenerateAll();
        }

        private void generateWithOptions_Click(object sender, EventArgs e)
        {
            GenerateWithOptions();
        }

        private void addDefaultClassAnnotationMenuItem_Click(object sender, EventArgs e)
        {
            AddDefaultAnnotationToAll<TableMapping>(ProjectContext.Project.TableMappings, (o => "Maps to the {0} table in the database.".FormatString(o.ClassName)));
        }

        private void addClassAttributeMenuItem_Click(object sender, EventArgs e)
        {
            AddAttributeToAll<TableMapping>(ProjectContext.Project.TableMappings);
        }

        private void removeDefaultClassAnnotationMenuItem_Click(object sender, EventArgs e)
        {
            RemoveDefaultAnnotationFromAll<TableMapping>(ProjectContext.Project.TableMappings);
        }

        private void addDefaultPropertyAnnotationMenuItem_Click(object sender, EventArgs e)
        {
            AddDefaultAnnotationToAll<ColumnMapping>(ProjectContext.Project.TableMappings.SelectMany(o => o.ColumnMappings), (o => "Maps to the {0} column.".FormatString(o.ColumnName)));
        }

        private void removeDefaultPropertyAnnotationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveDefaultAnnotationFromAll<ColumnMapping>(ProjectContext.Project.TableMappings.SelectMany(o => o.ColumnMappings));
        }

        private void addDefaultForeignKeyAnnotationMenuItem_Click(object sender, EventArgs e)
        {
            AddDefaultAnnotationToAll<ForeignKeyMapping>(ProjectContext.Project.ForeignKeyMappings, (o => "Maps to the {0} foreign key in the database.".FormatString(o.ForeignKeyName)));
        }

        private void addForeignKeyAttributeMenuItem_Click(object sender, EventArgs e)
        {
            AddAttributeToAll<ForeignKeyMapping>(ProjectContext.Project.ForeignKeyMappings);
            this.UnsavedChanges = true;
        }

        private void removeDefaultForeignKeyAnnotationMenuItem_Click(object sender, EventArgs e)
        {
            RemoveDefaultAnnotationFromAll<ForeignKeyMapping>(ProjectContext.Project.ForeignKeyMappings);
        }

        private void addDefaultUniqueIndexAnnotationMenuItem_Click(object sender, EventArgs e)
        {
            AddDefaultAnnotationToAll<UniqueIndexMapping>(ProjectContext.Project.TableMappings.SelectMany(o => o.UniqueIndexMappings), (o => "Maps to the {0} foreign key in the database.".FormatString(o.UniqueIndexName)));
        }

        private void addCreateAPIMenuItem_Click(object sender, EventArgs e)
        {
            using (new Wait())
            {
                AddGeneratedAPIs(API.APIType.Create);
            }
        }

        private void addDeleteAPIMenuItem_Click(object sender, EventArgs e)
        {
            using (new Wait())
            {
                AddGeneratedAPIs(API.APIType.Delete);
            }
        }

        private void addAPIAttributeMenuItem_Click(object sender, EventArgs e)
        {
            AddAttributeToAll<API>(ProjectContext.Project.TableMappings.SelectMany(tm => tm.APIs));
            this.UnsavedChanges = true;
        }

        private void removeCreateAPIMenuItem_Click(object sender, EventArgs e)
        {
            RemoveGeneratedAPIs(API.APIType.Create);
        }

        private void removeDeleteAPIMenuItem_Click(object sender, EventArgs e)
        {
            RemoveGeneratedAPIs(API.APIType.Delete);
        }

        private void metricsMenuItem_Click(object sender, EventArgs e)
        {
            LineCount();
        }

        private void batchEditMenuItem_Click(object sender, EventArgs e)
        {
            BatchEdit();
        }

        private void feedbackMenuItem_Click(object sender, EventArgs e)
        {
            using (Feedback dialog = new Feedback())
            {
                dialog.ShowDialog();
            }
        }

        private void samplesMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"{0}\Samples\".FormatString(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)));
        }

        private void aboutMenuItem_Click(object sender, EventArgs e)
        {
            using (About dialog = new About())
            {
                dialog.ShowDialog();
            }
        }

        public void RefreshMappings_ProgressUpdate(string status, int itemsProcessed, int totalItems)
        {
            progressPanel.Status = status;

            if (itemsProcessed < 0 || totalItems <= 0)
                progressPanel.ProgressBar.Style = ProgressBarStyle.Marquee;
            else
            {
                progressPanel.ProgressBar.Maximum = totalItems;
                progressPanel.ProgressBar.Value = Math.Min(itemsProcessed, totalItems);
                progressPanel.ProgressBar.Style = ProgressBarStyle.Continuous;
            }

            Application.DoEvents();
        }

        private void projectTreeview_AfterSelect(object sender, TreeViewEventArgs e)
        {
            using (new Wait())
            {
                optionsPlaceholderPanel.SuspendLayout();
                propertiesToolbox.HeaderText = "Properties";

                while (!optionsPlaceholderPanel.Controls.IsNullOrEmpty())
                {
                    IOptionsPanel optionsPanel = (optionsPlaceholderPanel.Controls[0] as IOptionsPanel);

                    if (optionsPanel != null)
                        this.LastShownTabPage[optionsPanel.GetType()] = optionsPanel.SelectedTabIndex;

                    optionsPlaceholderPanel.Controls[0].Dispose();
                }

                if (e.Node is ProjectTreeNode)
                    ShowOptionsPanel(new ProjectOptions(((ProjectTreeNode)e.Node).Project));
                else if (e.Node is TemplateTreeNode)
                    ShowOptionsPanel(new TemplateOptions(((TemplateTreeNode)e.Node).Template));
                else if (e.Node is TableOrViewTreeNode)
                    ShowOptionsPanel(new TableOrViewOptions(((TableOrViewTreeNode)e.Node).TableMapping));
                else if (e.Node is ColumnTreeNode)
                    ShowOptionsPanel(new ColumnOptions(((ColumnTreeNode)e.Node).ColumnMapping));
                else if (e.Node is UniqueIndexTreeNode)
                    ShowOptionsPanel(new UniqueIndexOptions(((UniqueIndexTreeNode)e.Node).UniqueIndexMapping));
                else if (e.Node is ForeignKeyTreeNode)
                    ShowOptionsPanel(new ForeignKeyOptions(((ForeignKeyTreeNode)e.Node).ForeignKeyMapping));

                optionsPlaceholderPanel.ResumeLayout();
            }
        }

        private void projectTreeview_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            using (new Wait())
            {
                if (e.Node is TemplateTreeNode)
                {
                    TemplateTreeNode node = (TemplateTreeNode)e.Node;

                    if (TemplateTabPages.ContainsKey(node.Template))
                        documentsTabControl.SelectedTab = TemplateTabPages[node.Template];
                    else
                    {
                        TabPage tabPage = new TabPage(Path.GetFileName(node.Template.XsltHintPath));
                        TemplateEditor editor = null;

                        try
                        {
                            editor = new TemplateEditor(node.Template);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("An error occurred while loading the template: " + ex.Message, "Template Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }


                        editor.Dock = DockStyle.Fill;
                        editor.TextChanged += new EventHandler(Editor_TextChanged);

                        tabPage.Controls.Add(editor);
                        documentsTabControl.TabPages.Add(tabPage);
                        documentsTabControl.SelectedTab = tabPage;
                        documentsTabControl.Visible = true;

                        TemplateTabPages.Add(node.Template, tabPage);
                    }
                }
            }
        }

        private void Editor_TextChanged(object sender, EventArgs e)
        {
            TemplateEditor editor = (TemplateEditor)sender;
            TabPage tabPage = (TabPage)editor.Parent;

            _unsavedChanges = true;
            tabPage.Text = Path.GetFileName(editor.Template.XsltHintPath) + "*";
            UpdateTitle();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveActiveDocumentTab();
        }

        private void saveAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveAllDocumentTabs();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseActiveDocumentTab();
        }

        private void closeAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseAllDocumentTabs();
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = ConfirmProjectClosing();

            if (result == DialogResult.Yes)
                Save();
            else if (result == DialogResult.Cancel)
                e.Cancel = true;
        }

        private void documentsTabControl_TabClosing(object sender, ClosableTabControlTabClosingEventArgs e)
        {
            e.Cancel = CloseDocumentTab(e.TabPage);
        }

        public void InitializeRecentProjectsMenu()
        {
            List<string> recentProjects = null;

            recentProjectsMenuItem.DropDownItems.Clear();

            try
            {
                recentProjects = Configuration.Instance.RecentProjects;
            }
            catch (Exception ex)
            {
                Logger.Error(ex);
                MessageBox.Show(ex.Message, "Unable to Load Configuration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if (!recentProjects.IsNullOrEmpty())
            {
                foreach (string filePath in Configuration.Instance.RecentProjects)
                    recentProjectsMenuItem.DropDownItems.Add(filePath, null, new EventHandler(RecentProjectMenuItem_Click));

                recentProjectsMenuItem.Enabled = true;
            }
            else
                recentProjectsMenuItem.Enabled = false;
        }

        public void InitializeJumpLists()
        {
            if (TaskbarManager.IsPlatformSupported)
            {
                if (TaskbarManager.Instance.ApplicationId.IsNullOrEmpty())
                    TaskbarManager.Instance.ApplicationId = Application.ProductName;

                try
                {
                    JumpList recentJumpList = JumpList.CreateJumpList();

                    recentJumpList.KnownCategoryToDisplay = JumpListKnownCategoryType.Recent;
                    recentJumpList.Refresh();
                }
                catch { }

                try
                {
                    JumpList frequentJumpList = JumpList.CreateJumpList();

                    frequentJumpList.KnownCategoryToDisplay = JumpListKnownCategoryType.Frequent;
                    frequentJumpList.Refresh();
                }
                catch { }
            }
        }

        internal void InitializeBatchEditors()
        {
            BatchEditorManager.Initialize();
            batchEditMenuItem.Visible = BatchEditorManager.Instance.Any();
        }

        internal void InitializePlugins()
        {
            Type iPluginType = typeof(IPlugin);

            foreach (string file in Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "*.dll"))
            {
                Assembly assembly = null;

                try
                {
                    assembly = Assembly.LoadFile(file);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("An error occurred while loading the assembly located at the path: {0}".FormatString(file), ex);
                }

                if (assembly != null)
                {
                    foreach (Type type in assembly.GetTypes().Where(o => o != iPluginType && iPluginType.IsAssignableFrom(o)))
                    {
                        PluginConfig config = Configuration.Instance.Plugins.SingleOrDefault(o => string.Equals(o.TypeName, type.FullName));

                        if (config == null)
                        {
                            config = new PluginConfig(type, true);
                            Configuration.Instance.Plugins.Add(config);
                            Configuration.Instance.Save();
                        }

                        if (config.Enabled)
                        {
                            IPlugin plugin = null;

                            try
                            {
                                plugin = (IPlugin)Activator.CreateInstance(type);
                            }
                            catch (Exception ex)
                            {
                                throw new ApplicationException("An error occurred while loading the plugin \"{0}\" located at the path: {1}".FormatString(plugin.Name, assembly.Location), ex);
                            }

                            try
                            {
                                plugin.InstallUI(this);
                            }
                            catch (Exception ex)
                            {
                                throw new ApplicationException("An error occurred while installing the plugin \"{0}\" located at the path: {1}".FormatString(plugin.Name, assembly.Location), ex);
                            }
                        }
                    }
                }
            }
        }

        private void ToggleUI(bool enabled)
        {
            using (new Wait())
            {
                contentSplitContainer.Enabled = enabled;

                saveMenuItem.Enabled = (ProjectContext.Exists && enabled);
                saveAsMenuItem.Enabled = (ProjectContext.Exists && enabled);
                projectMenuItem.Enabled = (ProjectContext.Exists && enabled);
                toolsMenuItem.Enabled = (ProjectContext.Exists && enabled);

                saveButton.Enabled = (ProjectContext.Exists && enabled);
                propertiesButton.Enabled = (ProjectContext.Exists && enabled);
                refreshButton.Enabled = (ProjectContext.Exists && enabled);
                generateButton.Enabled = (ProjectContext.Exists && enabled);
            }
        }

        private void New()
        {
            using (NewProject dialog = new NewProject())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    using (ProjectProperties propertiesForm = new ProjectProperties(ProjectContext.Project))
                    {
                        propertiesForm.ShowDialog();
                    }

                    contentSplitContainer.Visible = true;
                    RefreshMappings();
                    ToggleUI(true);
                }
            }
        }

        public void OpenProject(bool isFromRecentFilesList)
        {
            using (new Wait())
            {
                using (OpenFileDialog dlg = new OpenFileDialog())
                {
                    dlg.Filter = Application.ProductName + " Projects|*.cgp;*.dfp";

                    if (dlg.ShowDialog(this) == DialogResult.OK)
                        OpenProject(dlg.FileName, isFromRecentFilesList);
                }
            }
        }

        public void OpenProject(string path, bool isFromRecentFilesList)
        {
            Main.Logger.Info("Opening project at path: {0}".FormatString(path));

            DialogResult result = ConfirmProjectClosing();

            if (result == DialogResult.Yes)
                Save();
            else if (result == DialogResult.Cancel)
                return;

            if (!File.Exists(path))
            {
                Logger.Info("File does not exist.");

                if (isFromRecentFilesList && MessageBox.Show("Could not find file \"{0}\". Would you like to remove it from the Recent Projects list?".FormatString(path), null, MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == System.Windows.Forms.DialogResult.Yes)
                {
                    Configuration.Instance.RecentProjects.Remove(path);
                    InitializeRecentProjectsMenu();
                }
                else if (!isFromRecentFilesList)
                    MessageBox.Show("Could not find file \"{0}\".".FormatString(path), null, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return;
            }

            using (new Wait())
            {
                Project project = null;
                Regex userSettingsFileCheckRegex = new Regex(@"(\.(?:dfp|cgp))u$", RegexOptions.IgnoreCase);
                string projectPath = path;
                string userSettingsPath = null;
                Version productVersion = new Version(Application.ProductVersion);
                Version projectVersion;

                if (userSettingsFileCheckRegex.IsMatch(projectPath))
                    projectPath = userSettingsFileCheckRegex.Replace(projectPath, "$1");

                userSettingsPath = "{0}u".FormatString(projectPath);
                projectVersion = UpgradeManager.GetVersion(projectPath);

                Main.Logger.Info("Project path: {0}".FormatString(projectPath));
                Main.Logger.Info("User Settings path: {0}".FormatString(userSettingsPath));
                Main.Logger.Info("Version: {0}".FormatString(projectVersion));

                //Upgrade if needed.
                if (productVersion < projectVersion)
                {
                    Logger.Info("Project is from newer version of CodeGenerator (v{0}).".FormatString(projectVersion));

                    //Just because the project is from a newer version does not mean that the schema changed and the project can't be opened.
                    if (!UpgradeManager.IsVersionCompatible(projectVersion))
                    {
                        MessageBox.Show("The project you are opening is from a newer version of CodeGenerator and therefore cannot be opened.");
                        return;
                    }
                }
                else if (productVersion > projectVersion)
                {
                    Logger.Info("Project is from older version of CodeGenerator (v{0}).".FormatString(projectVersion));

                    //Don't try to upgrade the project unless there is an actual upgrade to apply.
                    if (UpgradeManager.CanUpgrade(projectVersion))
                    {
                        if (MessageBox.Show("The project you are opening is from an older version of CodeGenerator and therefore must be upgraded. Would you like to upgrade the project now?", "Upgrade Required", MessageBoxButtons.YesNo) != DialogResult.Yes)
                            return;

                        Logger.Info("Project is being upgraded.");

                        try
                        {
                            UpgradeManager.Upgrade(projectPath, userSettingsPath);
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex);
                            MessageBox.Show("An error occurred while upgrading the project: {0}".FormatString(ex.Message), "Upgrade Failed", MessageBoxButtons.OK);
                            return;
                        }

                        MarkAsUnsaved();
                    }
                }

                try
                {
                    project = Project.Open(projectPath);
                }
                catch (Exception ex)
                {
                    Logger.Error("Error opening project.", ex);

                    if (MessageBox.Show("An error occurred while opening the project:\n\n{0}{1}".FormatString(ex.Message, (isFromRecentFilesList ? "\n\nWould you like to remove it from the Recent Projects list?" : "")), null, (isFromRecentFilesList ? MessageBoxButtons.YesNo : MessageBoxButtons.OK)) == System.Windows.Forms.DialogResult.Yes)
                    {
                        Configuration.Instance.RecentProjects.Remove(path);
                        InitializeRecentProjectsMenu();
                    }

                    return;
                }

                if (project != null)
                {
                    ProjectContext.Initialize(project);

                    this.ProjectPath = projectPath;
                    _unsavedChanges = false;

                    UpdateTitle();
                    LoadTreeView();

                    contentSplitContainer.Visible = true;

                    Configuration.Instance.AddRecentProject(projectPath);
                    Configuration.Instance.Save();

                    //Try to add the file to the Jump List.
                    if (TaskbarManager.IsPlatformSupported)
                        JumpList.AddToRecent(projectPath);

                    InitializeRecentProjectsMenu();

                    if (productVersion > projectVersion)
                    {
                        Logger.Info("Upgrading templates.");

                        try
                        {
                            UpgradeManager.UpgradeTemplates(projectVersion, project.Templates);
                        }
                        catch (Exception ex)
                        {
                            Logger.Error(ex);
                            MessageBox.Show("An error occurred while upgrading the templates: {0}".FormatString(ex.Message), "Upgrade Failed", MessageBoxButtons.OK);
                        }
                    }
                }
            }
        }

        private void Save()
        {
            using (new Wait())
            {
                if (String.IsNullOrEmpty(ProjectContext.Project.Path))
                    SaveProjectAs();
                else
                    SaveProject(ProjectContext.Project.Path);
            }
        }

        private void SaveProject(string filename)
        {
            using (new Wait())
            {
                ProjectContext.Project.SaveAs(filename);

                SaveAllDocumentTabs();

                Configuration.Instance.AddRecentProject(filename);
                Configuration.Instance.Save();

                _unsavedChanges = false;
                UpdateTitle();
            }
        }

        private void SaveProjectAs()
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.Filter = Application.ProductName + " Projects|*.cgp;*.dfp";

                if (dlg.ShowDialog(this) == DialogResult.OK)
                    SaveProject(dlg.FileName);
            }
        }

        private void Properties()
        {
            using (ProjectProperties dialog = new ProjectProperties(ProjectContext.Project))
            {
                dialog.ShowDialog();
            }
        }

        private void GenerateAll()
        {
            using (Generate dialog = new Generate(ProjectContext.Project, null, true, true))
            {
                dialog.ShowDialog();
            }
        }

        private void GenerateWithOptions()
        {
            using (Generate dialog = new Generate(ProjectContext.Project))
            {
                dialog.ShowDialog();
            }
        }

        private void GenerateTemplate(Template template)
        {
            using (Generate dialog = new Generate(ProjectContext.Project, template, true, true))
            {
                dialog.ShowDialog();
            }
        }

        private DialogResult ConfirmProjectClosing()
        {
            if (_unsavedChanges)
                return MessageBox.Show("Do you want to save the changes to this project before exiting?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            return DialogResult.None;
        }

        private void UpdateTitle()
        {
            const string titleFormat = "{0}{1} - CodeGenerator";

            using (new Wait())
            {
                this.Text = titleFormat.FormatString((String.IsNullOrEmpty(ProjectContext.Project.Path) ? "New Project" : Path.GetFileNameWithoutExtension(ProjectContext.Project.Path)), (_unsavedChanges ? "*" : ""));
            }
        }

        private void RefreshMappings()
        {
            using (new Wait())
            {
                ToggleUI(false);

                progressPanel.Status = "Preparing to refresh mappings....";
                progressPanel.ProgressBar.Style = ProgressBarStyle.Marquee;
                progressPanel.BringToFront();
                progressPanel.Visible = true;

                if (TaskbarManager.IsPlatformSupported)
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.Indeterminate);

                try
                {
                    DatabaseUtil.RefreshMappings(ProjectContext.Project, RefreshMappings_ProgressUpdate);
                }
                catch (Exception ex)
                {
                    progressPanel.Visible = false;
                    ToggleUI(true);
                    MessageBox.Show(ExceptionUtil.GetExceptionText(ex), "Error Refreshing Schema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                progressPanel.Visible = false;

                if (TaskbarManager.IsPlatformSupported)
                    TaskbarManager.Instance.SetProgressState(TaskbarProgressBarState.NoProgress);

                LoadTreeView();

                ToggleUI(true);
            }
        }

        private void LoadTreeView()
        {
            using (new Wait())
            {
                ToggleUI(false);

                ProjectTreeNode projectNode = new ProjectTreeNode(ProjectContext.Project);

                projectTreeview.Nodes.Clear();
                projectNode.TemplateGenerateClick += new EventHandler((s, e) => GenerateTemplate(((TemplateTreeNode)s).Template));
                projectTreeview.Nodes.Add(projectNode);

                ToggleUI(true);
            }
        }

        private void MainForm_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] filePaths = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (filePaths != null && filePaths.Length == 1)
                {
                    string extension = Path.GetExtension(filePaths[0]);

                    if (".cgp".Equals(extension, StringComparison.OrdinalIgnoreCase) || ".cgpu".Equals(extension, StringComparison.OrdinalIgnoreCase) || ".dfp".Equals(extension, StringComparison.OrdinalIgnoreCase) || ".dfpu".Equals(extension, StringComparison.OrdinalIgnoreCase))
                    {
                        e.Effect = DragDropEffects.Link;
                        return;
                    }
                }
            }

            e.Effect = DragDropEffects.None;
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            string filePath = ((string[])e.Data.GetData(DataFormats.FileDrop))[0];

            OpenProject(filePath, false);
        }

        private void SaveActiveDocumentTab()
        {
            if (documentsTabControl.SelectedTab != null)
                SaveDocumentTab(documentsTabControl.SelectedTab);
        }

        private void SaveAllDocumentTabs()
        {
            foreach (TabPage tabPage in documentsTabControl.TabPages)
                SaveDocumentTab(tabPage);
        }

        private void SaveDocumentTab(TabPage tabPage)
        {
            TemplateEditor editor = (TemplateEditor)tabPage.Controls[0];

            editor.Save();

            tabPage.Text = Path.GetFileName(editor.Template.XsltHintPath);
        }

        private void CloseActiveDocumentTab()
        {
            if (documentsTabControl.SelectedTab != null)
                CloseDocumentTab(documentsTabControl.SelectedTab);
        }

        private void CloseAllDocumentTabs()
        {
            foreach (TabPage tabPage in documentsTabControl.TabPages)
                CloseDocumentTab(tabPage);
        }

        private bool CloseDocumentTab(TabPage tabPage)
        {
            TemplateEditor editor = (TemplateEditor)tabPage.Controls[0];

            if (editor.UnsavedChanges)
            {
                DialogResult result = MessageBox.Show("The file \"{0}\" has unsaved changes. Would you like to save this file before closing it?".FormatString(editor.Template.XsltAbsolutePath), "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                    editor.Save();
                else if (result == DialogResult.Cancel)
                    return false;
            }

            TemplateTabPages.Remove(editor.Template);
            documentsTabControl.TabPages.Remove(tabPage);
            documentsTabControl.Visible = (documentsTabControl.TabPages.Count > 0);

            return true;
        }

        private void AddGeneratedAPIs(API.APIType apiType)
        {
            foreach (TableMapping tm in ProjectContext.Project.TableMappings.Where(o => !o.Exclude && !o.APIs.Any(a => a.Type == apiType)))
            {
                API api = (apiType == API.APIType.Create ? API.CreateValueTypeCreateAPI(tm) : API.CreateDeleteAPI(tm));

                api.Attributes.Add(new Attribute<API>(ATTRIBUTE_AUTOGEN, null));
                tm.APIs.Add(api);

                if (apiType == API.APIType.Create && tm.ContainingProject.ForeignKeyMappings.Any(fkm => fkm.ParentTableMapping == tm))
                {
                    api = API.CreateObjectCreateAPI(tm);
                    api.Attributes.Add(new Attribute<API>(ATTRIBUTE_AUTOGEN, null));
                    tm.APIs.Add(api);
                }

                MarkAsUnsaved();
            }
        }

        private void RemoveGeneratedAPIs(API.APIType apiType)
        {
            using (new Wait())
            {
                foreach (TableMapping tm in ProjectContext.Project.TableMappings)
                {
                    List<API> apisToRemove = new List<API>();

                    foreach (API api in new List<API>(tm.APIs))
                        tm.APIs.Remove(api);
                }
            }
        }

        private void LineCount()
        {
            using (Metrics dialog = new Metrics())
            {
                dialog.ShowDialog();
            }
        }

        private void BatchEdit()
        {
            using (BatchEdit dialog = new BatchEdit())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    LoadTreeView();
            }
        }

        private TreeNode GetSelectedNode()
        {
            return projectTreeview.SelectedNode;
        }

        private ProjectSchemaTreeNode GetSelectedProjectSchemaNode()
        {
            return (GetSelectedNode() as ProjectSchemaTreeNode);
        }

        private T GetSelectedNode<T>() where T : ProjectSchemaTreeNode
        {
            return (GetSelectedNode() as T);
        }

        private void ShowOptionsPanel(Control control)
        {
            using (new Wait())
            {
                IOptionsPanel optionsPanel = (control as IOptionsPanel);

                if (optionsPanel == null)
                    throw new ArgumentException("Provided control must be an IOptionsPanel.", "optionsPanel");

                optionsPlaceholderPanel.SuspendLayout();
                optionsPlaceholderPanel.Controls.Add(control);
                control.Dock = DockStyle.Fill;

                propertiesToolbox.HeaderText = optionsPanel.Title + " Properties";

                optionsPanel.SelectedTabIndex = this.LastShownTabPage.ValueOrDefault(optionsPanel.GetType());
                optionsPanel.Saved += new SavedDelegate(
                    delegate(object sender, EventArgs e)
                    {
                        _unsavedChanges = true;
                        UpdateTitle();
                        RefreshSelectedNode();
                    });

                optionsPlaceholderPanel.ResumeLayout();
            }
        }

        private void RefreshSelectedNode()
        {
            using (new Wait())
            {
                ProjectSchemaTreeNode node = GetSelectedProjectSchemaNode();

                //If a ProjectSchemaNode is currently selected, update it.
                if (node != null)
                    node.UpdateNode();
            }
        }

        private void MarkAsUnsaved()
        {
            _unsavedChanges = true;
            UpdateTitle();
            RefreshSelectedNode();
        }

        private void AddDefaultAnnotationToAll<T>(IEnumerable<IHasAnnotations<T>> addTo, Func<T, string> textSelector)
            where T : IProjectSchemaElement, IHasAnnotations<T>
        {
            using (new Wait())
            {
                foreach (T item in addTo)
                {
                    Attribute<Annotation<T>> autoGenAttribute = new Attribute<Annotation<T>>(ATTRIBUTE_AUTOGEN, null);
                    Annotation<T> annotation = new Annotation<T>("summary", textSelector(item), new Attribute<Annotation<T>>[] { autoGenAttribute }.ToList());

                    annotation.JoinToParent(item);
                    item.Annotations.Add(annotation);
                }
            }

            MarkAsUnsaved();
        }

        private void RemoveDefaultAnnotationFromAll<T>(IEnumerable<IHasAnnotations<T>> removeFrom)
            where T : IProjectSchemaElement, IHasAnnotations<T>
        {
            using (new Wait())
            {
                removeFrom.ForEach(o => o.Annotations.RemoveAll(a => a.Attributes.Any(atr => atr.Key.Equals(ATTRIBUTE_AUTOGEN) && "summary".Equals(a.Type, StringComparison.InvariantCultureIgnoreCase))));
            }

            MarkAsUnsaved();
        }

        private void AddAttributeToAll<T>(IEnumerable<IHasAttributes<T>> addTo)
            where T : IProjectSchemaElement, IHasAttributes<T>, new()
        {
            EditAttribute<T> dialog = new EditAttribute<T>();

            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                foreach (T element in addTo)
                {
                    Attribute<T> existingAttribute = element.Attributes.FirstOrDefault(o => string.Equals(o.Key, dialog.Attribute.Key));

                    if (existingAttribute != null)
                        element.Attributes.Remove(existingAttribute);

                    element.Attributes.Add(dialog.Attribute);
                }
            }

            MarkAsUnsaved();
        }
    }
}