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
using System.ComponentModel;

namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    internal partial class ProjectProperties : Form
    {
        public Project Project { get; private set; }

        private BindingList<Connection> ConnectionList { get; set; }

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

            InitializeConnectionsTab();
            InitializeDataTypesTab();
        }

        private void InitializeConnectionsTab()
        {
            this.ConnectionList = new BindingList<Connection>(this.Project.UserSettings.Connections);

            connectionsComboBox.DataSource = new BindingSource
            {
                DataSource = this.ConnectionList
            };

            if (this.Project.UserSettings.Connections.Any())
                connectionsComboBox.SelectedIndex = 0;
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

        private void InitializeResetToDefaultDataTypes()
        {
            Connection connection = this.Project.UserSettings.Connections.FirstOrDefault();

            if (connection != null)
            {
                DatabaseWorker worker = connection.GetDatabaseWorker();

                resetToDefaultDataTypesButton.DropDownItems.Clear();

                if (worker != null)
                {
                    IEnumerable<DataTypeMappingConfiguration> mappings = worker.GetDataTypeMappingConfigurations();

                    if (!mappings.IsNullOrEmpty())
                    {
                        foreach (DataTypeMappingConfiguration config in mappings)
                        {
                            ToolStripMenuItem button = new ToolStripMenuItem(config.Language, null, resetToDefaultDataTypesButton_Click)
                            {
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

        private void connectionsComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var connection = (Connection)connectionsComboBox.SelectedItem;

            this.connectionOptions.Initialize(connection);
        }

        private void newConnectionButton_Click(object sender, EventArgs e)
        {
            this.connectionOptions.Initialize(this.Project);

            this.Project.Connections.Add(this.connectionOptions.ConnectionInfo);
            this.Project.UserSettings.Connections.Add(this.connectionOptions.Connection);

            this.ConnectionList.ResetBindings();
            this.connectionsComboBox.SelectedItem = this.connectionOptions.Connection;
        }

        private void connectionOptions_Saved(object sender, EventArgs e)
        {

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
                    propertiesTabControl.SelectedTab = connectionTabPage;
            }
        }
    }
}