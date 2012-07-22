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
    internal partial class EditAnnotations<T> : Form
        where T : IProjectSchemaElement, IHasAnnotations<T>, new()
    {
        private Controls.EditAnnotations<T> _editAnnotationsControl = null;

        private IHasAnnotations<T> _AnnotationContainer;

        public IEnumerable<Annotation<T>> Annotations { get { return _editAnnotationsControl.Annotations; } set { _editAnnotationsControl.Annotations = value; } }

        public EditAnnotations(IHasAnnotations<T> annotationContainer)
        {
            InitializeComponent();

            _AnnotationContainer = annotationContainer;
            _editAnnotationsControl = new Controls.EditAnnotations<T>();
            _editAnnotationsControl.Annotations = _AnnotationContainer.Annotations;
            _editAnnotationsControl.Dock = DockStyle.Fill;

            editAnnotationsPanel.Controls.Add(_editAnnotationsControl);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            _AnnotationContainer.Annotations = new List<Annotation<T>>(_editAnnotationsControl.Annotations);

            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}