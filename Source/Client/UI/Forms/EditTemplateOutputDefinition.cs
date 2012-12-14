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
using QuantumConcepts.Common.Utils;
using System.Xml.Linq;
using System.Xml.XPath;
using System.Text.RegularExpressions;
using System.Collections;
using System.IO;
using System.Xml;

namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    internal partial class EditTemplateOutputDefinition : Form
    {
        private XmlNamespaceManager NamespaceManager = null;
        private XDocument ProjectDocument = null;

        public Template Template { get; private set; }
        public TemplateOutputDefinition TemplateOutputDefinition { get; private set; }

        public EditTemplateOutputDefinition(Template template)
        {
            InitializeComponent();

            this.Template = template;
        }

        public EditTemplateOutputDefinition(TemplateOutputDefinition templateOutputDefinition)
        {
            InitializeComponent();

            this.ProjectDocument = ProjectContext.Project.GetXDocument(out this.NamespaceManager);
            this.Template = templateOutputDefinition.Template;
            this.TemplateOutputDefinition = templateOutputDefinition;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            elementTypeComboBox.Items.AddRange(EnumUtil.GetEnumValues<ElementType>().ToArray());

            if (this.TemplateOutputDefinition != null)
            {
                this.Text = "Edit Template Output Definition: {0}".FormatString(this.TemplateOutputDefinition);
                elementTypeComboBox.SelectedItem = this.TemplateOutputDefinition.ElementType;
                rootPathTextBox.Text = this.TemplateOutputDefinition.RootAbsolutePath;
                filterXPathTextBox.Text = this.TemplateOutputDefinition.FilterXPath;
                filenameXPathTextBox.Text = this.TemplateOutputDefinition.FilenameXPath;
            }
            else
                this.Text = "Create Template Output Definition";
        }

        private void rootPathBrowseButton_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.SelectedPath = rootPathTextBox.Text;

                if (dialog.ShowDialog(this) == DialogResult.OK)
                    rootPathTextBox.Text = dialog.SelectedPath;
            }
        }

        private void field_Changed(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void updatePreviewButton_Click(object sender, EventArgs e)
        {
            UpdatePreview();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (elementTypeComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an Element Type.");
                return;
            }

            if (rootPathTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Please enter or choose the Root Path.");
                return;
            }

            if (filenameXPathTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Please enter the Filename XPath.");
                return;
            }

            ElementType elementType = ((EnumValue<ElementType>)elementTypeComboBox.SelectedItem).Value;

            if (this.TemplateOutputDefinition == null)
                this.TemplateOutputDefinition = new TemplateOutputDefinition(this.Template, elementType, filterXPathTextBox.Text, rootPathTextBox.Text, filenameXPathTextBox.Text);
            else
            {
                this.TemplateOutputDefinition.ElementType = elementType;
                this.TemplateOutputDefinition.FilterXPath = filterXPathTextBox.Text;
                this.TemplateOutputDefinition.RootAbsolutePath = rootPathTextBox.Text;
                this.TemplateOutputDefinition.FilenameXPath = filenameXPathTextBox.Text;
            }

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void UpdatePreview()
        {
            ElementType elementType = ((EnumValue<ElementType>)elementTypeComboBox.SelectedItem).Value;
            List<TemplateOutputDefinitionFilenameResult> results = null;

            previewListView.Items.Clear();
            okButton.Enabled = false;

            if (elementTypeComboBox.SelectedIndex < 0 || rootPathTextBox.Text.IsNullOrEmpty() || filenameXPathTextBox.Text.IsNullOrEmpty())
                return;

            try
            {
                TemplateOutputDefinitionFilename filename = TemplateOutputDefinitionFilename.Parse(filenameXPathTextBox.Text);

                results = filename.Compute(this.Template.ContainingProject, elementType, filterXPathTextBox.Text, rootPathTextBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            results.ForEach(o => previewListView.Items.Add(new ListViewItem(new[] { o.ElementName, o.Value })));

            okButton.Enabled = true;
        }
    }
}
