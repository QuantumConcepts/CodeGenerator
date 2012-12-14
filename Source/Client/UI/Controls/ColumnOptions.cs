using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.CodeGenerator.Client.UI.Forms;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal partial class ColumnOptions : UserControl, IOptionsPanel
    {
        public event SavedDelegate Saved;

        private bool IsLoaded { get; set; }
        private ColumnMapping ColumnMapping { get; set; }

        public string Title { get { return (this.ColumnMapping == null ? "Unknown Column Mapping" : this.ColumnMapping.TableMapping.TableName + " > " + this.ColumnMapping.ColumnName); } }
        
        public int SelectedTabIndex
        {
            get { return tabControl.SelectedIndex; }
            set
            {
                if (value < tabControl.TabPages.Count)
                    tabControl.SelectedIndex = value;
            }
        }

        public ColumnOptions(ColumnMapping columnMapping)
        {
            InitializeComponent();

            this.ColumnMapping = columnMapping;
        }

        protected void Form_Load(object sender, EventArgs e)
        {
            columnFieldNameTextBox.Text = this.ColumnMapping.FieldName;
            columnDataTypeTextBox.Text = this.ColumnMapping.DataType;
            columnPrimaryKeyCheckBox.Checked = this.ColumnMapping.PrimaryKey;
            columnNullableCheckBox.Checked = this.ColumnMapping.Nullable;
            columnTreatAsYesNoIndicatorCheckBox.Checked = this.ColumnMapping.TreatAsYesNoIndicator;

            if (this.ColumnMapping.DataType.Equals(this.ColumnMapping.ContainingProject.FindDataTypeMapping("binary").ApplicationDataType) ||
                this.ColumnMapping.DataType.Equals(this.ColumnMapping.ContainingProject.FindDataTypeMapping("varbinary").ApplicationDataType))
            {
                foreach (ColumnMapping cm in this.ColumnMapping.TableMapping.ColumnMappings)
                {
                    if (cm.DataType.Equals(this.ColumnMapping.ContainingProject.FindDataTypeMapping("binary").ApplicationDataType) ||
                        cm.DataType.Equals(this.ColumnMapping.ContainingProject.FindDataTypeMapping("varbinary").ApplicationDataType))
                    {
                        encryptionVectorColumnComboBox.Items.Add(cm);
                    }
                }

                if (!string.IsNullOrEmpty(this.ColumnMapping.EncryptionVectorColumnName))
                {
                    ColumnMapping encryptionVectorColumn = this.ColumnMapping.TableMapping.FindColumnMapping(this.ColumnMapping.EncryptionVectorColumnName);

                    encryptionPropertyNameTextBox.Text = this.ColumnMapping.DecryptionPropertyName;

                    if (encryptionVectorColumnComboBox.Items.Contains(encryptionVectorColumn))
                        encryptionVectorColumnComboBox.SelectedItem = encryptionVectorColumn;
                    else
                        MessageBox.Show("The encryption vector column for this encrypted column could not be located.");

                    encryptionCheckBox.Checked = true;
                }
                else
                    encryptionCheckBox.Checked = false;

                encryptionCheckBox.Enabled = true;
            }
            else
                encryptionCheckBox.Enabled = false;

            foreach (TableMapping tm in this.ColumnMapping.ContainingProject.TableMappings)
                foreach (ColumnMapping cm in tm.ColumnMappings)
                    if (cm.EnumerationMapping != null)
                        referencedEnumerationComboBox.Items.Add(cm.EnumerationMapping);

            if (this.ColumnMapping.EnumerationMapping != null)
            {

                if (this.ColumnMapping.EnumerationMapping.IsReference)
                {
                    EnumerationMapping referencedEnumerationMapping = this.ColumnMapping.EnumerationMapping.GetReferencedEnumerationMapping();

                    enumerationIsReferenceCheckBox.Checked = true;

                    if (referencedEnumerationMapping != null && referencedEnumerationComboBox.Items.Contains(referencedEnumerationMapping))
                        referencedEnumerationComboBox.SelectedItem = referencedEnumerationMapping;
                    else
                        MessageBox.Show("The referenced enumeration mapping '" + referencedEnumerationMapping.Name + "' could not be located.");
                }
                else
                {
                    enumerationIsReferenceCheckBox.Checked = false;
                    enumerationNameTextBox.Text = this.ColumnMapping.EnumerationMapping.Name;

                    foreach (EnumerationValueMapping value in this.ColumnMapping.EnumerationMapping.Values)
                        AddEnumerationValue(value);
                }

                enumerationCheckBox.Checked = true;
            }
            else
                enumerationCheckBox.Checked = false;

            editAnnotations.Annotations = this.ColumnMapping.Annotations;
            editAttributes.Attributes = this.ColumnMapping.Attributes;

            this.IsLoaded = true;
        }

        private void encryptionCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            encryptionPropertyNameTextBox.Enabled = (encryptionCheckBox.Checked);
            encryptionVectorColumnComboBox.Enabled = (encryptionCheckBox.Checked);

            PropertyChanged(sender, e);
        }

        private void enumerationCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            enumerationIsReferenceCheckBox.Enabled = enumerationCheckBox.Checked;

            if (!enumerationCheckBox.Checked)
                enumerationIsReferenceCheckBox.Checked = false;

            enumerationIsReferenceCheckBox_CheckedChanged(sender, e);
        }

        private void enumerationIsReferenceCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            referencedEnumerationComboBox.Enabled = enumerationIsReferenceCheckBox.Checked;
            enumerationNameTextBox.Enabled = !enumerationIsReferenceCheckBox.Checked;
            enumerationValuesListBox.Enabled = !enumerationIsReferenceCheckBox.Checked;
            addEnumerationValueButton.Enabled = !enumerationIsReferenceCheckBox.Checked;
            editEnumerationValueButton.Enabled = !enumerationIsReferenceCheckBox.Checked;
            removeEnumerationValueButton.Enabled = !enumerationIsReferenceCheckBox.Checked;
            enumerationAnnotationsButton.Enabled = !enumerationIsReferenceCheckBox.Checked;
            enumerationAttributesButton.Enabled = !enumerationIsReferenceCheckBox.Checked;

            PropertyChanged(sender, e);
        }

        private void addEnumerationValueButton_Click(object sender, EventArgs e)
        {
            using (EditEnumerationValue dialog = new EditEnumerationValue())
            {
                if (dialog.ShowDialog(this) == DialogResult.OK)
                    AddEnumerationValue(dialog.EnumerationValueMapping);

                PropertyChanged(sender, e);
            }
        }

        private void editEnumerationValueButton_Click(object sender, EventArgs e)
        {
            EditEnumerationValue();

            PropertyChanged(sender, e);
        }

        private void removeEnumerationValueButton_Click(object sender, EventArgs e)
        {
            enumerationValuesListBox.Items.Remove(enumerationValuesListBox.SelectedItems[0]);

            PropertyChanged(sender, e);
        }

        private void enumerationValuesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            editEnumerationValueButton.Enabled = (enumerationValuesListBox.SelectedItems.Count > 0);
            removeEnumerationValueButton.Enabled = (enumerationValuesListBox.SelectedItems.Count > 0);
        }

        private void enumerationValuesListBox_DoubleClick(object sender, EventArgs e)
        {
            EditEnumerationValue();
        }

        private void AddEnumerationValue(EnumerationValueMapping value)
        {
            enumerationValuesListBox.Items.Add(value);
        }

        private void EditEnumerationValue()
        {
            using (EditEnumerationValue dialog = new EditEnumerationValue((EnumerationValueMapping)enumerationValuesListBox.SelectedItem))
            {
                dialog.ShowDialog(this);
            }
        }

        private void PropertyChanged(object sender, EventArgs e)
        {
            SaveOptions();
        }

        private void editAnnotationsButton_Click(object sender, EventArgs e)
        {
            using (Forms.EditAnnotations<ColumnMapping> dialog = new Forms.EditAnnotations<ColumnMapping>(ColumnMapping))
            {
                dialog.ShowDialog();
            }
        }

        private void attributesButton_Click(object sender, EventArgs e)
        {
            using (Forms.EditAttributes<ColumnMapping> dialog = new Forms.EditAttributes<ColumnMapping>(this.ColumnMapping))
            {
                dialog.ShowDialog();
            }
        }

        public void SaveOptions()
        {
            if (!IsLoaded)
                return;

            this.ColumnMapping.FieldName = columnFieldNameTextBox.Text;
            this.ColumnMapping.PrimaryKey = columnPrimaryKeyCheckBox.Checked;
            this.ColumnMapping.DataType = columnDataTypeTextBox.Text;
            this.ColumnMapping.Nullable = columnNullableCheckBox.Checked;
            this.ColumnMapping.TreatAsYesNoIndicator = columnTreatAsYesNoIndicatorCheckBox.Checked;

            if (encryptionCheckBox.Checked && !string.IsNullOrEmpty(encryptionPropertyNameTextBox.Text) && encryptionVectorColumnComboBox.SelectedItem != null)
            {
                this.ColumnMapping.DecryptionPropertyName = encryptionPropertyNameTextBox.Text;
                this.ColumnMapping.EncryptionVectorColumnName = ((ColumnMapping)encryptionVectorColumnComboBox.SelectedItem).ColumnName;
            }
            else
            {
                this.ColumnMapping.DecryptionPropertyName = null;
                this.ColumnMapping.EncryptionVectorColumnName = null;
            }

            if (enumerationCheckBox.Checked)
            {
                if (enumerationIsReferenceCheckBox.Checked && referencedEnumerationComboBox.SelectedIndex >= 0)
                {
                    EnumerationMapping referencedEnumerationMapping = (EnumerationMapping)referencedEnumerationComboBox.SelectedItem;

                    this.ColumnMapping.EnumerationMapping = new EnumerationMapping(referencedEnumerationMapping);
                    this.ColumnMapping.EnumerationMapping.JoinToColumnMapping(this.ColumnMapping);
                }
                else if (!enumerationIsReferenceCheckBox.Checked)
                {
                    this.ColumnMapping.EnumerationMapping = new EnumerationMapping(enumerationNameTextBox.Text, null, null, null);

                    foreach (EnumerationValueMapping item in enumerationValuesListBox.Items)
                        this.ColumnMapping.EnumerationMapping.Values.Add(item);

                    this.ColumnMapping.EnumerationMapping.JoinToColumnMapping(this.ColumnMapping);

                    //Update any referenced enumerations.
                    foreach (TableMapping tm in this.ColumnMapping.ContainingProject.TableMappings)
                        foreach (ColumnMapping cm in tm.ColumnMappings)
                            if (cm.EnumerationMapping != null && cm.EnumerationMapping.References(this.ColumnMapping.EnumerationMapping))
                                cm.EnumerationMapping.UpdateReference(this.ColumnMapping.EnumerationMapping);
                }
            }
            else
                this.ColumnMapping.EnumerationMapping = null;

            this.ColumnMapping.Annotations = new List<Annotation<ColumnMapping>>(editAnnotations.Annotations);
            this.ColumnMapping.Attributes = new List<Attribute<ColumnMapping>>(editAttributes.Attributes);

            OnSaved();
        }

        protected void OnSaved()
        {
            if (Saved != null)
                Saved(this, EventArgs.Empty);
        }
    }
}
