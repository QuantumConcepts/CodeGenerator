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

        private void generateButton_Click(object sender, EventArgs e)
        {
            GenerateSelection();
        }

        private void generateAllButton_Click(object sender, EventArgs e)
        {
            GenerateAll();
        }

        private void generator_GenerationStatus(Generator generator, GenerationStatusEventArgs e)
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

                this.Generator.GenerationStatus -= new Generator.GenerationStatusEventHandler(generator_GenerationStatus);
                this.Generator.ItemGenerationStatus -= new Generator.ItemGenerationStatusEventHandler(generator_ItemGenerationStatus);
                this.Generator = null;

                if (x.Status == GenerationStatus.Complete && autoCloseCheckBox.Checked)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }

                ToggleUI(true);
                progressBar.Visible = false;
            }), e);
        }

        private void generator_ItemGenerationStatus(Generator generator, ItemGenerationStatusEventArgs e)
        {
            this.Invoke(new GenericDelegate<ItemGenerationStatusEventArgs>(x =>
            {
                ListViewItem item = outputsListView.CheckedItems.Cast<ListViewItem>().Single(o => o.Tag == x.Result);

                item.SubItems[statusColumn.Index].Text = x.Status.ToString();

                if (x.Status == GenerationStatus.Complete)
                    progressBar.Value++;
                else if (x.Status == GenerationStatus.Error)
                {
                    Logger.Error(x.Error);
                    outputsListView.Items.Cast<ListViewItem>().Single(o => o.Tag == x.Template).SubItems[messageColumn.Index].Text = x.Error.Message;
                }
            }), e);
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

                outputsListView.CheckedItems.Cast<ListViewItem>().ForEach(o =>
                {
                    o.SubItems[statusColumn.Index].Text = null;
                    o.SubItems[messageColumn.Index].Text = null;
                });

                progressBar.Value = 0;
                progressBar.Maximum = templateOutputs.SelectMany(o => o.Value).Count();
                progressBar.Visible = true;

                this.Generator = new Generator(ProjectContext.Project, templateOutputs);
                this.Generator.GenerationStatus += new Generator.GenerationStatusEventHandler(generator_GenerationStatus);
                this.Generator.ItemGenerationStatus += new Generator.ItemGenerationStatusEventHandler(generator_ItemGenerationStatus);
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

        private void cancelButton_Click(object sender, EventArgs e)
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
    }
}
