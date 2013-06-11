using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.Common.Forms.UI;
using QuantumConcepts.CodeGenerator.Core;
using log4net;
using QuantumConcepts.Common;

namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    internal partial class Generate : Form
    {
        private static ILog Logger = LogManager.GetLogger(typeof(Generate));

        private Project Project { get; set; }
        private bool AutoGenerate { get; set; }
        private Generator Generator { get; set; }

        public Generate()
        {
            InitializeComponent();
        }

        public Generate(Project project)
            : this()
        {
            this.Project = project;

            LoadOutputsListView();
        }

        public Generate(Project project, Template template, bool autoGenerate, bool autoClose)
            : this(project)
        {
            if (template != null)
                outputsListView.Groups.Cast<ListViewGroup>().Single(o => o.Tag == template).Items.Cast<ListViewItem>().ForEach(o => o.Checked = true);
            else
                outputsListView.Items.Cast<ListViewItem>().ForEach(o => o.Checked = true);

            this.AutoGenerate = autoGenerate;
            autoCloseCheckBox.Checked = autoClose;
        }

        private void Generate_Load(object sender, EventArgs e)
        {
            if (this.AutoGenerate)
                GenerateSelection();
        }

        private void outputsListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            generateButton.Enabled = !outputsListView.CheckedItems.IsNullOrEmpty();
        }

        private void outputsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewItem item = outputsListView.GetItemAt(e.Location.X, e.Location.Y);

            if (item != null)
            {
                Template template = (Template)item.Group.Tag;
                Exception error = (item.SubItems[messageColumn.Index].Tag as Exception);

                if (error != null)
                {
                    StringBuilder message = new StringBuilder();

                    message.AppendLine("Template:\t\t{0}".FormatString(template.Name));
                    message.AppendLine("XSLT Path:\t{0}".FormatString(template.XsltAbsolutePath));
                    message.AppendLine("Output Path:\t{0}".FormatString(item.SubItems[pathColumn.Index].Text));

                    if (template.OutputMode == TemplateOutputMode.MultipleFile)
                        message.AppendLine("Element:\t\t{0}".FormatString(item.SubItems[elementColumn.Index].Text));

                    message.AppendLine();

                    while (error != null)
                    {
                        message.AppendLine(error.Message);
                        error = error.InnerException;
                    }

                    message.AppendLine();
                    message.Append("See the log for more information.");

                    MessageBox.Show(message.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            GenerateSelection();
        }

        private void generateAllButton_Click(object sender, EventArgs e)
        {
            GenerateAll();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            if (this.Generator != null)
            {
                if (MessageBox.Show("Generation is currently under way, are you sure you want to cancel?", "Confirm Cancelation", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) != System.Windows.Forms.DialogResult.Yes)
                    return;

                this.Generator.Cancel();
            }

            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void Generator_GenerationStatus(Generator generator, GenerationStatusEventArgs e)
        {
            this.Invoke(new GenericDelegate<GenerationStatusEventArgs>(x =>
            {
                if (x.Status == GenerationStatus.Generating)
                    return;

                if (x.Status == GenerationStatus.Error)
                {
                    Logger.Error(x.Error);
                    MessageBox.Show(x.Error.Message, "Generation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                this.Generator.GenerationStatus -= new Generator.GenerationStatusEventHandler(Generator_GenerationStatus);
                this.Generator.TemplateGenerationStatus -= new Generator.TemplateGenerationStatusEventHandler(Generator_TemplateGenerationStatus);
                this.Generator.ItemGenerationStatus -= new Generator.ItemGenerationStatusEventHandler(Generator_ItemGenerationStatus);
                this.Generator = null;

                if (x.Status == GenerationStatus.Complete)
                {
                    bool hasErrors = outputsListView.Items.Cast<ListViewItem>().Any(o => GenerationStatus.Error.ToString().Equals(o.SubItems[statusColumn.Index].Text));

                    ToggleUI(true);
                    progressBar.Visible = false;

                    if (!hasErrors && autoCloseCheckBox.Checked)
                    {
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else if (hasErrors)
                        MessageBox.Show("One or more errors occurred during the generation process. Double click each error message above for more information.", "Errors Occurred", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }), e);
        }

        void Generator_TemplateGenerationStatus(Generator generator, TemplateGenerationStatusEventArgs e)
        {
            this.Invoke(new GenericDelegate<TemplateGenerationStatusEventArgs>(x =>
            {
                ListViewGroup group = outputsListView.Groups.Cast<ListViewGroup>().Single(o => o.Tag == e.Template);

                foreach (ListViewItem item in group.Items)
                    UpdateListViewItemStatus(item, e.Status, e.Error);
            }), e);
        }

        private void Generator_ItemGenerationStatus(Generator generator, ItemGenerationStatusEventArgs e)
        {
            this.Invoke(new GenericDelegate<ItemGenerationStatusEventArgs>(x =>
            {
                ListViewItem item = outputsListView.CheckedItems.Cast<ListViewItem>().Single(o => o.Tag == x.Result);

                if (x.Status == GenerationStatus.Complete)
                    progressBar.Value++;

                UpdateListViewItemStatus(item, x.Status, x.Error);
            }), e);
        }

        private void UpdateListViewItemStatus(ListViewItem item, GenerationStatus status, Exception exception)
        {
            item.SubItems[statusColumn.Index].Text = status.ToString();

            if (status == GenerationStatus.Error)
            {
                Logger.Error(exception);
                item.SubItems[messageColumn.Index].Text = "{0} (Double click for more.)".FormatString(exception.Message);
                item.SubItems[messageColumn.Index].Tag = exception;
            }
        }

        private void LoadOutputsListView()
        {
            outputsListView.Items.Clear();
            outputsListView.BeginUpdate();

            foreach (Template template in ProjectContext.Project.Templates)
            {
                ListViewGroup group = new ListViewGroup(template.Name)
                {
                    Tag = template
                };

                foreach (TemplateOutputDefinitionFilenameResult output in template.GetOutputFilenames())
                {
                    ListViewItem item = new ListViewItem(new[] { output.Value, (template.OutputMode == TemplateOutputMode.SingleFile ? null : output.ElementName), null, null })
                    {
                        Group = group,
                        Tag = output
                    };

                    group.Items.Add(item);
                    outputsListView.Items.Add(item);
                }

                outputsListView.Groups.Add(group);
            }

            pathColumn.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            outputsListView.EndUpdate();
        }

        public void GenerateAll()
        {
            outputsListView.Items.Cast<ListViewItem>().ForEach(o => o.Checked = true);

            GenerateSelection();
        }

        private void GenerateSelection()
        {
            ToggleUI(false);

            using (new Wait())
            {
                Dictionary<Template, List<TemplateOutputDefinitionFilenameResult>> templateOutputs = (from li in outputsListView.CheckedItems.Cast<ListViewItem>()
                                                                                                      group (TemplateOutputDefinitionFilenameResult)li.Tag by (Template)li.Group.Tag into g
                                                                                                      select new
                                                                                                      {
                                                                                                          Template = g.Key,
                                                                                                          Outputs = g.ToList()
                                                                                                      }).ToDictionary(o => o.Template, o => o.Outputs);

                if (templateOutputs.IsNullOrEmpty())
                {
                    MessageBox.Show("You must select one or more template you wish to generate.", "Generate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ToggleUI(true);
                    return;
                }

                outputsListView.CheckedItems.Cast<ListViewItem>().ForEach(o =>
                {
                    o.SubItems[statusColumn.Index].Text = null;
                    o.SubItems[messageColumn.Index].Text = null;
                });

                progressBar.Value = 0;
                progressBar.Maximum = templateOutputs.SelectMany(o => o.Value).Count();
                progressBar.Visible = true;

                this.Generator = new Generator(ProjectContext.Project, templateOutputs);
                this.Generator.GenerationStatus += new Generator.GenerationStatusEventHandler(Generator_GenerationStatus);
                this.Generator.TemplateGenerationStatus += new Generator.TemplateGenerationStatusEventHandler(Generator_TemplateGenerationStatus);
                this.Generator.ItemGenerationStatus += new Generator.ItemGenerationStatusEventHandler(Generator_ItemGenerationStatus);
                this.Generator.Generate();
            }
        }

        private void ToggleUI(bool enable)
        {
            outputsListView.Enabled = enable;
            autoCloseCheckBox.Enabled = enable;
            generateButton.Enabled = enable;
            generateAllButton.Enabled = enable;
        }
    }
}
