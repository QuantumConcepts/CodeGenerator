using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Client.UI.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal partial class TableOrViewOptions : UserControl, IOptionsPanel
    {
        public event SavedDelegate Saved;

        private bool _isLoaded = false;

        private TableMapping _tableOrViewMapping;

        public string Title { get { return (_tableOrViewMapping == null ? "Unknown Table Mapping" : _tableOrViewMapping.TableName); } }
        
        public int SelectedTabIndex
        {
            get { return tabControl.SelectedIndex; }
            set
            {
                if (value < tabControl.TabPages.Count)
                    tabControl.SelectedIndex = value;
            }
        }

        public TableOrViewOptions(TableMapping tableOrViewMapping)
        {
            InitializeComponent();

            _tableOrViewMapping = tableOrViewMapping;
        }

        private void TableOptions_Load(object sender, EventArgs e)
        {
            tableClassNameTextBox.Text = _tableOrViewMapping.ClassName;
            tablePluralClassNameTextBox.Text = _tableOrViewMapping.PluralClassName;
            tableReadWriteModeOptionButton.Checked = (!(_tableOrViewMapping is ViewMapping) && !_tableOrViewMapping.ReadOnly);
            tableReadWriteModeOptionButton.Enabled = (!(_tableOrViewMapping is ViewMapping));
            tableReadOnlyModeOptionButton.Checked = (_tableOrViewMapping is ViewMapping || _tableOrViewMapping.ReadOnly);
            tableReadOnlyModeOptionButton.Enabled = (!(_tableOrViewMapping is ViewMapping));

            foreach (API thisAPI in _tableOrViewMapping.APIs)
                AddAPI(thisAPI);

            LoadTransferAPIToMenu();

            editAnnotations.Annotations = _tableOrViewMapping.Annotations;
            editAttributes.Attributes = _tableOrViewMapping.Attributes;

            _isLoaded = true;
        }

        private void PropertyChanged(object sender, EventArgs e)
        {
            SaveOptions();
        }

        private void addCustomAPIButton_ButtonClick(object sender, EventArgs e)
        {
            using (EditAPI dialog = new EditAPI(_tableOrViewMapping.ContainingProject))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    dialog.API.JoinToTableMapping(_tableOrViewMapping);
                    AddAPI(dialog.API);

                    PropertyChanged(sender, e);
                }
            }
        }

        private void addCreateAPIMenuItem_Click(object sender, EventArgs e)
        {
            AddAPI(API.CreateValueTypeCreateAPI(_tableOrViewMapping));

            PropertyChanged(sender, e);
        }

        private void addDeleteAPIMenuItem_Click(object sender, EventArgs e)
        {
            AddAPI(API.CreateDeleteAPI(_tableOrViewMapping));

            PropertyChanged(sender, e);
        }

        private void editAPIButton_Click(object sender, EventArgs e)
        {
            EditAPI();

            PropertyChanged(sender, e);
        }

        private void removeAPIButton_Click(object sender, EventArgs e)
        {
            for (int i = (apisListBox.SelectedIndices.Count - 1); i >= 0; i--)
                apisListBox.Items.RemoveAt(apisListBox.SelectedIndices[i]);

            PropertyChanged(sender, e);
        }

        private void transferAPIToTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("The selected table is about to be refreshed, would you like to save any changes first?", "Save Changes?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Cancel)
                return;

            TableMapping tableMapping = (TableMapping)((ToolStripMenuItem)sender).Tag;

            foreach (object item in apisListBox.SelectedItems)
            {
                API api = (API)item;

                api.TransferTo(tableMapping);
                apisListBox.Items.Remove(item);
            }

            PropertyChanged(sender, e);
        }

        private void apisListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (apisListBox.SelectedItems.Count > 0)
            {
                API api = (API)apisListBox.SelectedItem;
                bool isCustomAPI = (api.Type == API.APIType.Custom);

                editAPIButton.Enabled = (apisListBox.SelectedItems.Count == 1 && isCustomAPI);
                removeAPIButton.Enabled = true;
                transferAPIToolStripDropDownButton.Enabled = true;
            }
            else
            {
                editAPIButton.Enabled = false;
                removeAPIButton.Enabled = false;
                transferAPIToolStripDropDownButton.Enabled = false;
            }
        }

        private void apisListView_DoubleClick(object sender, EventArgs e)
        {
            EditAPI();
        }

        private void LoadTransferAPIToMenu()
        {
            transferAPIToolStripDropDownButton.DropDownItems.Clear();

            foreach (TableMapping tm in _tableOrViewMapping.ContainingProject.TableMappings)
            {
                ToolStripMenuItem transferAPIToTableToolStripMenuItem = new ToolStripMenuItem(tm.ToString());

                transferAPIToTableToolStripMenuItem.Tag = tm;
                transferAPIToTableToolStripMenuItem.Click += new EventHandler(transferAPIToTableToolStripMenuItem_Click);
                transferAPIToolStripDropDownButton.DropDownItems.Add(transferAPIToTableToolStripMenuItem);
            }

            SaveOptions();
        }

        private void AddAPI(API api)
        {
            apisListBox.Items.Add(api);
        }

        private void EditAPI()
        {
            using (EditAPI dialog = new EditAPI(_tableOrViewMapping.ContainingProject, (API)apisListBox.SelectedItem))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    int itemIndex = apisListBox.SelectedIndex;

                    apisListBox.Items.Remove(apisListBox.SelectedItem);
                    apisListBox.Items.Insert(itemIndex, dialog.API);

                    SaveOptions();
                }
            }
        }

        public void SaveOptions()
        {
            if (!_isLoaded)
                return;

            _tableOrViewMapping.ClassName = tableClassNameTextBox.Text;
            _tableOrViewMapping.PluralClassName = tablePluralClassNameTextBox.Text;
            _tableOrViewMapping.ReadOnly = tableReadOnlyModeOptionButton.Checked;

            _tableOrViewMapping.APIs.Clear();

            foreach (object item in apisListBox.Items)
                _tableOrViewMapping.APIs.Add((API)item);

            _tableOrViewMapping.Annotations = new List<Annotation<TableMapping>>(editAnnotations.Annotations);
            _tableOrViewMapping.Attributes = new List<Attribute<TableMapping>>(editAttributes.Attributes);

            OnSaved();
        }

        protected void OnSaved()
        {
            if (Saved != null)
                Saved(this, EventArgs.Empty);
        }
    }
}
