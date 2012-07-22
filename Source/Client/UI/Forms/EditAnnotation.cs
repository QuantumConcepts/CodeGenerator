using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;

namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    internal partial class EditAnnotation<T> : Form
        where T : IProjectSchemaElement, IHasAnnotations<T>, new()
    {
        public Annotation<T> Annotation { get; private set; }

        public EditAnnotation()
            :this(null)
        {}

        public EditAnnotation(Annotation<T> annotation)
        {
            InitializeComponent();

            this.Annotation = annotation;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.Annotation == null)
                this.Annotation = new Annotation<T>();

            typeComboBox.Items.AddRange(ProjectContext.Project.AllAnnotations.Select(a => a.Type).Distinct().ToArray());
            textComboBox.Items.AddRange(ProjectContext.Project.AllAnnotations.Select(a => a.Text).Distinct().ToArray());

            typeComboBox.Text = this.Annotation.Type;
            textComboBox.Text = this.Annotation.Text;
        }

        private void attributesButton_Click(object sender, EventArgs e)
        {
            using (Forms.EditAttributes<Annotation<T>> dialog = new EditAttributes<Annotation<T>>(this.Annotation))
            {
                dialog.ShowDialog();
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(typeComboBox.Text))
            {
                MessageBox.Show("Please enter the type.");
                typeComboBox.Focus();
                typeComboBox.SelectAll();
                return;
            }

            this.Annotation.Type = typeComboBox.Text;
            this.Annotation.Text = textComboBox.Text;

            //Remove the AutoGen attribute if one exists.
            this.Annotation.Attributes.RemoveAll(o => Main.ATTRIBUTE_AUTOGEN.Equals(o.Key));

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
