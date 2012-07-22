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
    internal partial class EditAttributes<T> : Form
        where T : IProjectSchemaElement, IHasAttributes<T>, new()
    {
        private Controls.EditAttributes<T> _editAttributesControl = null;

        private IHasAttributes<T> _attributeContainer;

        public IEnumerable<Attribute<T>> Attributes { get { return _editAttributesControl.Attributes; } set { _editAttributesControl.Attributes = value; } }

        public EditAttributes(IHasAttributes<T> attributeContainer)
        {
            InitializeComponent();

            _attributeContainer = attributeContainer;
            _editAttributesControl = new Controls.EditAttributes<T>();
            _editAttributesControl.Attributes = _attributeContainer.Attributes;
            _editAttributesControl.Dock = DockStyle.Fill;

            editAttributesPanel.Controls.Add(_editAttributesControl);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            _attributeContainer.Attributes = new List<Attribute<T>>(_editAttributesControl.Attributes);

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