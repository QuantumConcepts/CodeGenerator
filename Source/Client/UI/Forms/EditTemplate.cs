using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.IO;
using QuantumConcepts.Common.Extensions;

namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    internal partial class EditTemplate : Form
    {
        public Project Project { get; private set; }
        public Template Template { get; private set; }
        public List<TemplateOutputDefinition> TemplateOutputDefinitions { get; private set; }

        public EditTemplate(Project project)
        {
            InitializeComponent();

            this.Project = project;
            this.TemplateOutputDefinitions = new List<TemplateOutputDefinition>();
        }

        public EditTemplate(Template template)
        {
            InitializeComponent();

            this.Project = template.ContainingProject;
            this.Template = template;
            this.TemplateOutputDefinitions = this.Template.TemplateOutputDefinitions;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.Template != null)
            {
                this.Text = "Edit Template {0}".FormatString(this.Template);
                xsltPathTextBox.Text = this.Template.XsltAbsolutePath;
                singleFileRadioButton.Checked = (this.Template.OutputMode == TemplateOutputMode.SingleFile);
                multipleFilesRadioButton.Checked = (this.Template.OutputMode == TemplateOutputMode.MultipleFile);

                if (this.Template.OutputMode == TemplateOutputMode.SingleFile)
                    singleFileOutputPathTextBox.Text = this.Template.OutputAbsolutePath;
                else
                    BindTemplateOutputDefinitions();
            }
            else
                this.Text = "Create Template";
        }

        private void xsltBrowseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "XSLT Files|*.xslt";
                openFileDialog.CheckFileExists = false;
                openFileDialog.CheckPathExists = false;
                openFileDialog.FileName = xsltPathTextBox.Text;

                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                    xsltPathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void singleFileRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            singleFilePanel.Enabled = singleFileRadioButton.Checked;
            multipleFilesPanel.Enabled = !singleFilePanel.Enabled;
        }

        private void singleFileOutputPathBrowseButton_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.CheckFileExists = false;
                openFileDialog.CheckPathExists = false;
                openFileDialog.FileName = singleFileOutputPathTextBox.Text;

                if (openFileDialog.ShowDialog(this) == DialogResult.OK)
                    singleFileOutputPathTextBox.Text = openFileDialog.FileName;
            }
        }

        private void multipleFilesRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            multipleFilesPanel.Enabled = multipleFilesRadioButton.Checked;
            singleFilePanel.Enabled = !multipleFilesPanel.Enabled;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            EditTemplateOutputDefinition(null);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            EditTemplateOutputDefinition((TemplateOutputDefinition)templateOutputDefinitionsListBox.SelectedItems[0]);
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            var selected = templateOutputDefinitionsListBox.SelectedItems;

            foreach (TemplateOutputDefinition item in selected)
                this.TemplateOutputDefinitions.Remove(item);

            BindTemplateOutputDefinitions();
        }

        private void outputDefinitionsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            editButton.Enabled = (templateOutputDefinitionsListBox.SelectedIndices.Count == 1);
            removeButton.Enabled = (templateOutputDefinitionsListBox.SelectedIndices.Count > 0);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!Save())
                return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void EditTemplateOutputDefinition(TemplateOutputDefinition definition)
        {
            if (!Save())
                return;

            using (EditTemplateOutputDefinition dialog = (definition == null ? new EditTemplateOutputDefinition(this.Template) : new EditTemplateOutputDefinition(definition)))
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (definition == null)
                        this.TemplateOutputDefinitions.Add(dialog.TemplateOutputDefinition);

                    BindTemplateOutputDefinitions();
                }
            }
        }

        private void BindTemplateOutputDefinitions()
        {
            templateOutputDefinitionsListBox.Items.AddRange(this.TemplateOutputDefinitions.ToArray());
        }

        private bool Save()
        {
            TemplateOutputMode mode = (singleFileRadioButton.Checked ? TemplateOutputMode.SingleFile : TemplateOutputMode.MultipleFile);
            string singleFileOutputPath = (mode == TemplateOutputMode.SingleFile ? singleFileOutputPathTextBox.Text : null);

            if (string.IsNullOrEmpty(xsltPathTextBox.Text))
            {
                MessageBox.Show("You must enter the XSLT Path.");
                return false;
            }

            if (mode == TemplateOutputMode.SingleFile && string.IsNullOrEmpty(singleFileOutputPathTextBox.Text))
            {
                MessageBox.Show("You must enter the Output Path.");
                return false;
            }

            if (this.Template == null)
                this.Template = new Template(this.Project, xsltPathTextBox.Text, mode, singleFileOutputPath, this.TemplateOutputDefinitions);
            else
            {
                this.Template.XsltAbsolutePath = xsltPathTextBox.Text;
                this.Template.OutputMode = mode;
                this.Template.OutputAbsolutePath = singleFileOutputPath;
                this.Template.TemplateOutputDefinitions = this.TemplateOutputDefinitions;
            }

            return true;
        }
    }
}
