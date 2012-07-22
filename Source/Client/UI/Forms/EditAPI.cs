using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Forms.Utils;

namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    internal partial class EditAPI : Form
    {
        private Project _project = null;
        private API _api = null;
        private Parameter<API> _returnParameter = null;

        public API API
        {
            get { return _api; }
        }

        public EditAPI(Project project)
            : this(project, null)
        { }

        public EditAPI(Project project, API api)
        {
            InitializeComponent();

            _project = project;
            _api = api;
        }

        private void EditAPIDialog_Load(object sender, EventArgs e)
        {
            if (_api == null)
                _api = new API();

            _returnParameter = _api.ReturnParameter;

            nameTextBox.Text = _api.Name;
            returnParameterLabel.Tag = _api.ReturnParameter;
            returnParameterLabel.Text = _api.ReturnParameter.ToString();

            foreach (Parameter<API> thisParameter in _api.Parameters)
                AddParameter(thisParameter);
        }

        private void parametersListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            editParameterButton.Enabled = (parametersListView.SelectedItems.Count > 0);
            removeParameterButton.Enabled = (parametersListView.SelectedItems.Count > 0);
            moveUpButton.Enabled = (parametersListView.SelectedItems.Count == 1 && parametersListView.Items.Count > 1 && parametersListView.SelectedIndices[0] != 0);
            moveDownButton.Enabled = (parametersListView.SelectedItems.Count == 1 && parametersListView.Items.Count > 1 && parametersListView.SelectedIndices[0] != (parametersListView.Items.Count - 1));
        }

        private void editReturnParameterButton_Click(object sender, EventArgs e)
        {
            using (EditParameterDialog<API> dialog = new EditParameterDialog<API>(_project, true, (Parameter<API>)returnParameterLabel.Tag))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _returnParameter = dialog.Parameter;
                    returnParameterLabel.Text = dialog.Parameter.ToString();
                }
            }
        }

        private void addParameterButton_Click(object sender, EventArgs e)
        {
            using (EditParameterDialog<API> dialog = new EditParameterDialog<API>(_project, false))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    AddParameter(dialog.Parameter);
            }
        }

        private void AddParameter(Parameter<API> parameter)
        {
            ListViewItem item = new ListViewItem(parameter.ToString());

            item.Tag = parameter;
            parametersListView.Items.Add(item);
        }

        private void editParameterButton_Click(object sender, EventArgs e)
        {
            EditParameter();
        }

        private void parametersListView_DoubleClick(object sender, EventArgs e)
        {
            EditParameter();
        }

        private void removeParameterButton_Click(object sender, EventArgs e)
        {
            parametersListView.Items.Remove(parametersListView.SelectedItems[0]);
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = parametersListView.SelectedIndices[0];

            ListViewUtil.SwapListViewItems(parametersListView.Items[selectedIndex - 1], parametersListView.Items[selectedIndex]);
            parametersListView.Focus();
            parametersListView.Items[selectedIndex - 1].Selected = true;
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = parametersListView.SelectedIndices[0];

            ListViewUtil.SwapListViewItems(parametersListView.Items[selectedIndex], parametersListView.Items[selectedIndex + 1]);
            parametersListView.Focus();
            parametersListView.Items[selectedIndex + 1].Selected = true;
        }

        private void EditParameter()
        {
            using (EditParameterDialog<API> dialog = new EditParameterDialog<API>(_project, false, (Parameter<API>)parametersListView.SelectedItems[0].Tag))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ListViewItem item = parametersListView.SelectedItems[0];

                    item.Tag = dialog.Parameter;
                    item.Text = dialog.Parameter.ToString();
                }
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(nameTextBox.Text))
            {
                MessageBox.Show("Please enter the name.");
                nameTextBox.Focus();
                nameTextBox.SelectAll();
                return;
            }

            _api.Type = (_api == null ? QuantumConcepts.CodeGenerator.Core.ProjectSchema.API.APIType.Custom : _api.Type);
            _api.Name = nameTextBox.Text;
            _api.ReturnParameter = (_returnParameter ?? Parameter<API>.CreateVoidReturnParameter(null, null));
            
            _api.Parameters.Clear();

            foreach (ListViewItem lvi in parametersListView.Items)
                _api.Parameters.Add((Parameter<API>)lvi.Tag);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void editAnnotationsButton_Click(object sender, EventArgs e)
        {
            using (EditAnnotations<API> dialog = new EditAnnotations<API>(_api))
            {
                dialog.ShowDialog();
            }
        }

        private void attributesButton_Click(object sender, EventArgs e)
        {
            using (EditAttributes<API> dialog = new EditAttributes<API>(_api))
            {
                dialog.ShowDialog();
            }
        }
    }
}
