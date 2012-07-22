using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Forms.Extensions;

namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    internal partial class EditAttribute<T> : Form
        where T : IProjectSchemaElement, IHasAttributes<T>, new()
    {
        public Attribute<T> Attribute { get; private set; }

        public EditAttribute()
            :this(null)
        {}

        public EditAttribute(Attribute<T> attribute)
        {
            InitializeComponent();

            this.Attribute = attribute;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.Attribute == null)
                this.Attribute = new Attribute<T>();

            keyComboBox.Items.TryAddRange(ProjectContext.Project.AllAttributes.Select(a => a.Key).Distinct());
            valueComboBox.Items.TryAddRange(ProjectContext.Project.AllAttributes.Select(a => a.Value).Distinct());

            keyComboBox.Text = this.Attribute.Key;
            valueComboBox.Text = this.Attribute.Value;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(keyComboBox.Text))
            {
                MessageBox.Show("Please enter the key.");
                keyComboBox.Focus();
                keyComboBox.SelectAll();
                return;
            }

            this.Attribute.Key = keyComboBox.Text;
            this.Attribute.Value = valueComboBox.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
