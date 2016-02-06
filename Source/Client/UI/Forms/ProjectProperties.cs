using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.CodeGenerator.Core;
using System.Linq;
using QuantumConcepts.CodeGenerator.Core.Data;
using QuantumConcepts.Common.Forms.UI;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.Common.Utils;
using QuantumConcepts.CodeGenerator.Core.Exceptions;

namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    internal partial class ProjectProperties : Form
    {
        public Project Project { get; private set; }

        public ProjectProperties() : this(new Project()) { }

        public ProjectProperties(Project project)
        {
            this.Project = project;

            InitializeComponent();
            InitializeUI();
        }

        void InitializeUI()
        {
            //General tab
            rootNamespaceTextBox.DataBindings.Clear();
            rootNamespaceTextBox.DataBindings.Add(nameof(TextBox.Text), this.Project, nameof(Project.RootNamespace));
            showExcludedItemsCheckBox.DataBindings.Clear();
            showExcludedItemsCheckBox.DataBindings.Add(nameof(CheckBox.Checked), this.Project.UserSettings, nameof(UserSettings.ShowExcludedItems));

            InitializeDatabaseTab();
            InitializeDataTypesTab();
        }

        private void InitializeDatabaseTab() {
            //TODO Support multiple connections.
            var connection = this.Project.UserSettings.Connections.FirstOrDefault();

            databaseTypeComboBox.Items.AddRange(DatabaseWorkerManager.Instance.OrderBy(o => o.Name).ToArray());
            databaseConnectionStringTextBox.DataBindings.Clear();

            if (connection != null) {
                databaseTypeComboBox.SelectedItem = DatabaseWorkerManager.Instance[connection.DatabaseType];
                databaseConnectionStringTextBox.DataBindings.Add(nameof(TextBox.Text), connection, nameof(Connection.ConnectionString));
            }
            
            //TODO
            //editAttributes.DataBindings.Clear();
            //editAttributes.DataBindings.Add("Attributes", this.Project, "Attributes");
        }

        private void InitializeDataTypesTab()
        {
            InitializeResetToDefaultDataTypes();

            dataTypesListView.Items.Clear();

            foreach (DataTypeMapping dataType in this.Project.DataTypeMappings)
            {
                ListViewItem item = new ListViewItem(dataType.DatabaseDataType);

                item.Tag = dataType;
                item.SubItems.Add(dataType.ApplicationDataType);
                item.SubItems.Add(dataType.Nullable ? "Yes" : "No");
                dataTypesListView.Items.Add(item);
            }
        }

        private void InitializeDatabaseParameters()
        {
            Connection connection = this.Project.UserSettings.Connections.First();
            DatabaseWorker worker = connection.GetDatabaseWorker();

            databaseParametersGridView.Rows.Clear();

            if (worker != null && !worker.Parameters.IsNullOrEmpty())
            {
                string[] allParameterNames = worker.Parameters.Select(o => o.Name).ToArray();

                connection.Attributes.RemoveAll(o => !allParameterNames.Contains(o.Key));

                foreach (DatabaseParameter parameter in worker.Parameters)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    string value = connection.Attributes.SingleOrDefault(o => o.Key.Equals(parameter.Name)).ValueOrDefault(o => o.Value);

                    row.CreateCells(databaseParametersGridView, parameter.Name, value);
                    row.Cells[databaseParametersNameColumn.Index].ToolTipText = parameter.Description;
                    row.Cells[databaseParametersValueColumn.Index].ToolTipText = parameter.Description;
                    databaseParametersGridView.Rows.Add(row);
                }
            }
            else
                connection.Attributes.Clear();
        }

        private void InitializeResetToDefaultDataTypes()
        {
            Connection connection = this.Project.UserSettings.Connections.FirstOrDefault();

            if (connection != null) {
                DatabaseWorker worker = connection.GetDatabaseWorker();

                resetToDefaultDataTypesButton.DropDownItems.Clear();

                if (worker != null) {
                    IEnumerable<DataTypeMappingConfiguration> mappings = worker.GetDataTypeMappingConfigurations();

                    if (!mappings.IsNullOrEmpty()) {
                        foreach (DataTypeMappingConfiguration config in mappings) {
                            ToolStripMenuItem button = new ToolStripMenuItem(config.Language, null, resetToDefaultDataTypesButton_Click) {
                                DisplayStyle = ToolStripItemDisplayStyle.Text,
                                Tag = config.Language
                            };

                            resetToDefaultDataTypesButton.DropDownItems.Add(button);
                        }
                    }
                    else
                        resetToDefaultDataTypesButton.Enabled = false;
                }
            }
        }

        private void databaseType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.Project.UserSettings.Connections.Count == 0)
                this.Project.UserSettings.Connections.Add(new Connection());

            this.Project.UserSettings.Connections.First().DatabaseType = ((DatabaseWorker)databaseTypeComboBox.SelectedItem).Name;

            InitializeDatabaseParameters();
            InitializeResetToDefaultDataTypes();
        }

        private void databaseParametersGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                Connection connection = this.Project.UserSettings.Connections.First();
                DataGridViewRow row = databaseParametersGridView.Rows[e.RowIndex];
                string name = (string)(row.Cells[databaseParametersNameColumn.Index].Value);
                string value = (string)(row.Cells[databaseParametersValueColumn.Index].Value);
                Attribute<Connection> parameter = connection.Attributes.SingleOrDefault(o => o.Key.Equals(name));

                if (parameter == null)
                {
                    parameter = new Attribute<Connection>(name, value);
                    connection.Attributes.Add(parameter);
                }
                else
                    parameter.Value = value;
            }
        }

        private void dataTypesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dataTypesListView.SelectedItems.Count == 0)
                return;

            DataTypeMapping dataType = (DataTypeMapping)dataTypesListView.SelectedItems[0].Tag;

            addDataTypeDatabaseDataTypeTextBox.Text = dataType.DatabaseDataType;
            addDataTypeApplicationDataTypeTextBox.Text = dataType.ApplicationDataType;
            addDataTypeNullableCheckBox.Checked = dataType.Nullable;
        }

        private void deleteDataTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in dataTypesListView.SelectedItems)
                this.Project.DataTypeMappings.Remove((DataTypeMapping)item.Tag);

            InitializeDataTypesTab();
        }

        private void resetToDefaultDataTypesButton_Click(object sender, EventArgs e)
        {
            Connection connection = this.Project.UserSettings.Connections.First();
            DatabaseWorker worker = connection.GetDatabaseWorker();

            if (worker != null)
            {
                string language = (((ToolStripItem)sender).Tag as string);
                DataTypeMappingConfiguration config = worker.GetDataTypeMappingConfigurations().SingleOrDefault(o => string.Equals(o.Language, language) && string.Equals(o.DatabaseType, connection.DatabaseType));

                if (config == null)
                {
                    MessageBox.Show("No default data type mappings exist for the language and database type you have selected.");
                    return;
                }

                this.Project.DataTypeMappings.Clear();
                this.Project.DataTypeMappings.AddRange(config.DataTypeMappings.Select(dtm => new DataTypeMapping(dtm.DatabaseDataType, dtm.ApplicationDataType, dtm.Nullable)));

                InitializeDataTypesTab();
            }
        }

        private void clearDataTypesButton_Click(object sender, EventArgs e)
        {
            dataTypesListView.Items.Clear();
            this.Project.DataTypeMappings.Clear();
            InitializeDataTypesTab();
        }

        private void addDataTypeSaveButton_Click(object sender, EventArgs e)
        {
            DataTypeMapping dataType = null;

            if (string.IsNullOrEmpty(addDataTypeDatabaseDataTypeTextBox.Text))
            {
                MessageBox.Show("Please enter the database data type for this mapping.");
                return;
            }

            if (string.IsNullOrEmpty(addDataTypeApplicationDataTypeTextBox.Text))
            {
                MessageBox.Show("Please enter the application data type for this mapping.");
                return;
            }

            if (dataTypesListView.SelectedItems.Count == 1)
            {
                dataType = (DataTypeMapping)dataTypesListView.SelectedItems[0].Tag;
                dataType.DatabaseDataType = addDataTypeDatabaseDataTypeTextBox.Text;
                dataType.ApplicationDataType = addDataTypeApplicationDataTypeTextBox.Text;
                dataType.Nullable = addDataTypeNullableCheckBox.Checked;
            }
            else
            {
                dataType = new DataTypeMapping(addDataTypeDatabaseDataTypeTextBox.Text, addDataTypeApplicationDataTypeTextBox.Text, addDataTypeNullableCheckBox.Checked);
                this.Project.DataTypeMappings.Add(dataType);
            }

            addDataTypeDatabaseDataTypeTextBox.Clear();
            addDataTypeApplicationDataTypeTextBox.Clear();

            InitializeDataTypesTab();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            bool close = true;
            bool focusOnDatabaseType = false;

            using (new Wait())
            {
                try
                {
                    this.Project.UserSettings.Connections.First().Validate();
                }
                catch (EmptyDatabaseWorkerSpecifiedException)
                {
                    if (MessageBox.Show("No Database Type was selected on the Database tab.\n\nWould you like to continue anyway?", "Connection Failed", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        close = false;
                        focusOnDatabaseType = true;
                    }
                }
                catch (NonExistentDatabaseWorkerSpecifiedException)
                {
                    if (MessageBox.Show("Could not locate a database worker for the selected Database Type.\n\nWould you like to continue anyway?", "Connection Failed", MessageBoxButtons.YesNo) == DialogResult.No)
                    {
                        close = false;
                        focusOnDatabaseType = true;
                    }
                }
                catch (Exception ex)
                {
                    //Warn that the connection could not be made.
                    if (MessageBox.Show("The connection to the data source could not be established. The following error was returned:{0}\n\nWould you like to continue anyway?".FormatString(TextUtil.GetExceptionText(ex)), "Connection Failed", MessageBoxButtons.YesNo) == DialogResult.No)
                        close = false;
                }

                if (close)
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else if (focusOnDatabaseType)
                {
                    propertiesTabControl.SelectedTab = databaseTabPage;
                    databaseTypeComboBox.Focus();
                }
            }
        }
    }
}