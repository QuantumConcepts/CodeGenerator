using QuantumConcepts.CodeGenerator.Core.Data;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    public partial class ConnectionOptions : UserControl, IOptionsPanel
    {
        public delegate void DatabaseTypeChangedEventHandler(object sender, DatabaseWorker worker);
        public event DatabaseTypeChangedEventHandler DatabaseTypeChanged;
        public event SavedDelegate Saved;

        private bool IsInitialized { get; set; }
        private string OriginalConnectionName { get; set; }

        public Project Project { get; private set; }
        public ConnectionInfo ConnectionInfo { get; private set; }
        public Connection Connection { get; private set; }

        /// <summary>This constructor is only to be used by the designer.</summary>
        public ConnectionOptions()
        {
            this.Project = new Project();
            this.ConnectionInfo = new ConnectionInfo();
            this.Connection = new Connection();

            InitializeComponent();
            Initialize();
        }

        public ConnectionOptions(Project project)
        {
            InitializeComponent();
            Initialize();
            Initialize(project);
        }

        public ConnectionOptions(ConnectionInfo connectionInfo)
        {
            InitializeComponent();
            Initialize();
            Initialize(connectionInfo);
        }

        public ConnectionOptions(Connection connection)
        {
            InitializeComponent();
            Initialize();
            Initialize(connection);
        }

        public void Initialize(Project project)
        {
            this.Project = project;
            this.ConnectionInfo = new ConnectionInfo
            {
                Name = "New Connection"
            };
            this.Connection = new Connection
            {
                Name = this.ConnectionInfo.Name
            };
            this.ConnectionInfo.JoinToParent(this.Project);
            this.Connection.JoinToParent(this.Project.UserSettings);

            InitializeUI();
        }

        public void Initialize(ConnectionInfo connectionInfo)
        {
            this.Project = connectionInfo.ContainingProject;
            this.ConnectionInfo = connectionInfo;
            this.Connection = this.Project.UserSettings.Connections.SingleOrDefault(o => string.Equals(o.Name, this.ConnectionInfo.Name));
            this.OriginalConnectionName = this.ConnectionInfo.Name;

            if (this.Connection == null)
            {
                this.Connection = new Connection
                {
                    Name = this.ConnectionInfo.Name
                };
            }

            InitializeUI();
        }

        public void Initialize(Connection connection)
        {
            this.Project = connection.ContainingProject;
            this.ConnectionInfo = this.Project.Connections.SingleOrDefault(o => string.Equals(o.Name, connection.Name));
            this.Connection = connection;
            this.OriginalConnectionName = connection.Name;

            if (this.ConnectionInfo == null)
            {
                this.ConnectionInfo = new ConnectionInfo
                {
                    Name = connection.Name
                };
            }

            InitializeUI();
        }

        private void Initialize()
        {
            typeComboBox.Items.AddRange(DatabaseWorkerManager.Instance.OrderBy(o => o.Name).ToArray());

            if (typeComboBox.Items.Count > 0)
                typeComboBox.SelectedIndex = 0;

            this.IsInitialized = true;
        }

        private void InitializeUI()
        {
            var worker = this.Connection.GetDatabaseWorker();

            this.IsInitialized = false;

            nameTextBox.Text = this.Connection.Name;
            typeComboBox.SelectedItem = worker;
            connectionStringTextBox.Text = this.Connection.ConnectionString;

            if (this.Connection.DatabaseType != null)
            {
                if (worker != null && worker.Parameters.Any())
                {
                    foreach (var attribute in this.Connection.Attributes)
                        parametersGridView.Rows.Add(attribute.Key, attribute.Value);
                }
                else
                    tabs.TabPages.Remove(parametersTab);
            }

            this.IsInitialized = true;
        }

        public string Title { get { return this.Connection.Name; } }

        public int SelectedTabIndex { get { return 0; } set { } }

        private void InitializeDatabaseParameters(DatabaseWorker worker)
        {
            parametersGridView.Rows.Clear();

            if (worker != null && worker.Parameters.Any())
            {
                string[] allParameterNames = worker.Parameters.Select(o => o.Name).ToArray();

                this.Connection.Attributes.RemoveAll(o => !allParameterNames.Contains(o.Key));

                foreach (DatabaseParameter parameter in worker.Parameters)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    string value = this.Connection.Attributes.SingleOrDefault(o => o.Key.Equals(parameter.Name)).ValueOrDefault(o => o.Value);

                    row.CreateCells(parametersGridView, parameter.Name, value);
                    row.Cells[databaseParametersNameColumn.Index].ToolTipText = parameter.Description;
                    row.Cells[databaseParametersValueColumn.Index].ToolTipText = parameter.Description;
                    parametersGridView.Rows.Add(row);
                }

                tabs.TabPages.Add(parametersTab);
            }
            else {
                this.Connection.Attributes.Clear();
                tabs.TabPages.Remove(parametersTab);
            }
        }

        private void type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!this.IsInitialized)
                return;

            DatabaseWorker selectedWorker = ((DatabaseWorker)typeComboBox.SelectedItem);

            InitializeDatabaseParameters(selectedWorker);
            OnDatabaseTypeChanged(selectedWorker);

            PropertyChanged(sender, e);
        }

        private void parametersGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = parametersGridView.Rows[e.RowIndex];
                string name = (string)(row.Cells[databaseParametersNameColumn.Index].Value);
                string value = (string)(row.Cells[databaseParametersValueColumn.Index].Value);
                Attribute<Connection> parameter = this.Connection.Attributes.SingleOrDefault(o => o.Key.Equals(name));

                if (parameter == null)
                {
                    parameter = new Attribute<Connection>(name, value);
                    this.Connection.Attributes.Add(parameter);
                }
                else
                    parameter.Value = value;
            }
        }

        private void PropertyChanged(object sender, EventArgs e)
        {
            SaveOptions();
        }

        public void SaveOptions()
        {
            if (!this.IsInitialized)
                return;

            var worker = ((DatabaseWorker)typeComboBox.SelectedItem);

            this.ConnectionInfo.Name = nameTextBox.Text;

            this.Connection.Name = nameTextBox.Text;
            this.Connection.DatabaseType = worker?.Name;
            this.Connection.ConnectionString = connectionStringTextBox.Text;
            this.Connection.Attributes.Clear();

            if (worker != null && worker.Parameters.Any())
            {
                foreach (DataGridViewRow row in parametersGridView.Rows)
                {
                    string name = (string)(row.Cells[databaseParametersNameColumn.Index].Value);
                    string value = (string)(row.Cells[databaseParametersValueColumn.Index].Value);
                    Attribute<Connection> parameter = this.Connection.Attributes.SingleOrDefault(o => o.Key.Equals(name));

                    if (parameter == null)
                    {
                        parameter = new Attribute<Connection>(name, value);
                        this.Connection.Attributes.Add(parameter);
                    }
                    else
                        parameter.Value = value;
                }
            }

            // Check if the connection name has changed.
            if (this.OriginalConnectionName != null && !string.Equals(this.OriginalConnectionName, this.Connection.Name))
            {
                UpdateConnectionReferences(this.OriginalConnectionName, this.Connection.Name);

                // The new connection name becomes the original connection name;
                this.OriginalConnectionName = this.Connection.Name;
            }

            OnSaved();
        }

        private void UpdateConnectionReferences(string oldConnectionName, string newConnectionName)
        {
            Func<IHasConnectionReference, bool> predicate = (o => string.Equals(o.ConnectionName, this.OriginalConnectionName));
            var toUpdate = new List<IEnumerable<IHasConnectionReference>>
                    {
                        this.Project.TableMappings.Where(predicate),
                        this.Project.ViewMappings.Where(predicate),
                        this.Project.ForeignKeyMappings.Where(predicate)
                    };

            foreach (var items in toUpdate)
                foreach (var item in items)
                    item.ConnectionName = this.Connection.Name;
        }

        private void OnDatabaseTypeChanged(DatabaseWorker worker)
        {
            if (DatabaseTypeChanged != null)
                DatabaseTypeChanged(this, worker);
        }

        protected void OnSaved()
        {
            if (Saved != null)
                Saved(this, EventArgs.Empty);
        }
    }
}
