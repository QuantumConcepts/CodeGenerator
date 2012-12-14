using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal partial class ForeignKeyOptions : UserControl, IOptionsPanel
    {
        public event SavedDelegate Saved;

        private bool _isLoaded = false;

        private ForeignKeyMapping _foreignKeyMapping;

        public string Title { get { return (_foreignKeyMapping == null ? "Unknown Foreign Key Mapping" : _foreignKeyMapping.ForeignKeyName); } }
        
        public int SelectedTabIndex
        {
            get { return tabControl.SelectedIndex; }
            set
            {
                if (value < tabControl.TabPages.Count)
                    tabControl.SelectedIndex = value;
            }
        }

        public ForeignKeyOptions(ForeignKeyMapping foreignKeyMapping)
        {
            InitializeComponent();

            _foreignKeyMapping = foreignKeyMapping;
        }

        private void ForeignKeyOptions_Load(object sender, EventArgs e)
        {
            foreignKeyFieldNameTextBox.Text = _foreignKeyMapping.FieldName;
            foreignKeyFieldPluralFieldNameTextBox.Text = _foreignKeyMapping.PluralFieldName;
            foreignKeyFieldPropertyNameTextBox.Text = _foreignKeyMapping.PropertyName;
            foreignKeyFieldPluralPropertyNameTextBox.Text = _foreignKeyMapping.PluralPropertyName;

            editAnnotations.Annotations = _foreignKeyMapping.Annotations;
            editAttributes.Attributes = _foreignKeyMapping.Attributes;

            _isLoaded = true;
        }

        private void PropertyChanged(object sender, EventArgs e)
        {
            SaveOptions();
        }

        public void SaveOptions()
        {
            if (!_isLoaded)
                return;

            _foreignKeyMapping.FieldName = foreignKeyFieldNameTextBox.Text;
            _foreignKeyMapping.PluralFieldName = foreignKeyFieldPluralFieldNameTextBox.Text;
            _foreignKeyMapping.PropertyName = foreignKeyFieldPropertyNameTextBox.Text;
            _foreignKeyMapping.PluralPropertyName = foreignKeyFieldPluralPropertyNameTextBox.Text;

            _foreignKeyMapping.Annotations = new List<Annotation<ForeignKeyMapping>>(editAnnotations.Annotations);
            _foreignKeyMapping.Attributes = new List<Attribute<ForeignKeyMapping>>(editAttributes.Attributes);

            OnSaved();
        }

        protected void OnSaved()
        {
            if (Saved != null)
                Saved(this, EventArgs.Empty);
        }

        private void encryptionCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void enumerationValuesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void enumerationValuesListBox_DoubleClick(object sender, EventArgs e)
        {

        }

        private void enumerationIsReferenceCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void addEnumerationValueButton_Click(object sender, EventArgs e)
        {

        }

        private void editEnumerationValueButton_Click(object sender, EventArgs e)
        {

        }

        private void removeEnumerationValueButton_Click(object sender, EventArgs e)
        {

        }

        private void enumerationCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
