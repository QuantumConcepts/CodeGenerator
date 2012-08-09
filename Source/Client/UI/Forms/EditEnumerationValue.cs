using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.Text.RegularExpressions;

namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    internal partial class EditEnumerationValue : Form
    {
        public EnumerationValueMapping EnumerationValueMapping { get; private set; }

        public EditEnumerationValue() : this(null) { }

        public EditEnumerationValue(EnumerationValueMapping enumerationValueMapping)
        {
            InitializeComponent();

            this.EnumerationValueMapping = enumerationValueMapping;
        }

        protected override void OnLayout(LayoutEventArgs levent)
        {
            base.OnLayout(levent);

            if (this.EnumerationValueMapping == null)
                this.EnumerationValueMapping = new EnumerationValueMapping();

            nameTextBox.Text = this.EnumerationValueMapping.Name;
            databaseValueTextBox.Text = this.EnumerationValueMapping.DatabaseValue;
            descriptionTextBox.Text = this.EnumerationValueMapping.Description;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Please enter the value.");
                nameTextBox.Focus();
                nameTextBox.SelectAll();
                return;
            }
            else if (string.IsNullOrEmpty(descriptionTextBox.Text))
            {
                MessageBox.Show("Please enter the description.");
                descriptionTextBox.Focus();
                descriptionTextBox.SelectAll();
                return;
            }

            this.EnumerationValueMapping.Name = nameTextBox.Text;
            this.EnumerationValueMapping.DatabaseValue = databaseValueTextBox.Text;
            this.EnumerationValueMapping.Description = descriptionTextBox.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void nameTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
                return;

            nameTextBox.Text = nameTextBox.Text.Trim();

            if (string.IsNullOrEmpty(databaseValueTextBox.Text))
                databaseValueTextBox.Text = nameTextBox.Text;

            if (string.IsNullOrEmpty(descriptionTextBox.Text))
                descriptionTextBox.Text = Regex.Replace(nameTextBox.Text, "(?-i)([A-Z])", " $1").Trim();
        }

        private void editAnnotationsButton_Click(object sender, EventArgs e)
        {
            using (EditAnnotations<EnumerationValueMapping> dialog = new EditAnnotations<EnumerationValueMapping>(this.EnumerationValueMapping))
            {
                dialog.ShowDialog();
            }
        }

        private void attributesButton_Click(object sender, EventArgs e)
        {
            using (EditAttributes<EnumerationValueMapping> dialog = new EditAttributes<EnumerationValueMapping>(this.EnumerationValueMapping))
            {
                dialog.ShowDialog();
            }
        }
    }
}