using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.BatchEditors;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Utils;
using QuantumConcepts.CodeGenerator.Core.Utils;

namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    internal partial class BatchEdit : Form
    {
        private BaseBatchEditor BatchEditor { get { return (editorComboBox.SelectedItem as BaseBatchEditor); } }

        public BatchEdit()
            : this(null)
        {
        }

        public BatchEdit(BaseBatchEditor batchEditor)
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            editorComboBox.Items.AddRange(BatchEditorManager.Instance.ToArray());

            if (this.BatchEditor != null)
            {
                editorComboBox.SelectedItem = this.BatchEditor;
                BatchEditorSelectionChanged();
            }
        }

        private void editorComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            BatchEditorSelectionChanged();
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
            if (this.BatchEditor == null)
            {
                MessageBox.Show("Please select a Batch Editor.");
                return;
            }

            if (elementTypeComboBox.SelectedIndex < 0)
            {
                MessageBox.Show("Please select an Element Type.");
                return;
            }

            if (valueXPathTextBox.Text.IsNullOrEmpty())
            {
                MessageBox.Show("Please enter the Value XPath.");
                return;
            }

            EnumValue<ElementType> elementType = (elementTypeComboBox.SelectedItem as EnumValue<ElementType>);


        }

        private void BatchEditorSelectionChanged()
        {
            this.Text = "Batch Edit: {0}".FormatString(this.BatchEditor.Name);
            UpdateElementTypeSelection();
        }

        private void UpdateElementTypeSelection()
        {
            elementTypeComboBox.Items.AddRange(EnumUtil.GetEnumValues(this.BatchEditor.ElementTypes).ToArray());
            UpdatePreview();
        }

        private void UpdatePreview()
        {
            EnumValue<ElementType> elementType = (elementTypeComboBox.SelectedItem as EnumValue<ElementType>);

            previewListView.Items.Clear();
            okButton.Enabled = false;

            if (elementType != null)
            {
                List<ComingledXPathExpressionResult> results = null;

                if (elementTypeComboBox.SelectedIndex < 0 || valueXPathTextBox.Text.IsNullOrEmpty())
                    return;

                try
                {
                    results = XmlUtil.ComputeComingledXPathExpression(ProjectContext.Project, elementType.Value, filterXPathTextBox.Text, valueXPathTextBox.Text);
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
}
