using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Utils;
using System;
using System.Linq;
using System.Windows.Forms;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal sealed class ConnectionTreeNode : ProjectSchemaTreeNode
    {
        public delegate void ConnectionInfoEventHandler(object sender, ConnectionInfo connectionInfo);
        public event ConnectionInfoEventHandler DeleteClicked;

        private TreeNode TablesNode { get; set; }
        private TreeNode ViewsNode { get; set; }

        public ConnectionInfo ConnectionInfo { get; private set; }

        public ConnectionTreeNode(ProjectSchemaTreeNode parent, ConnectionInfo connectionInfo)
            : base(parent)
        {
            this.ConnectionInfo = connectionInfo;

            Initialize();
        }

        private void Initialize()
        {
            this.ContextMenu = new ContextMenu(new MenuItem[]
            {
                new MenuItem("Test Connection...", new EventHandler(TestMenuItem_Click)),
                new MenuItem("Delete Connection",  new EventHandler(DeleteConnectionMenuItem_Click))
            });

            TablesNode = new TreeNode("Tables");
            ViewsNode = new TreeNode("Views");

            UpdateNode();
            Rebuild();
        }

        public void Rebuild()
        {
            RefreshTablesNode();
            RefreshViewsNode();

            if (TablesNode.Nodes.Count > 0)
                this.Nodes.Add(TablesNode);

            if (ViewsNode.Nodes.Count > 0)
                this.Nodes.Add(ViewsNode);

            this.Expand();
        }

        private void TestMenuItem_Click(object sender, EventArgs e)
        {
            Connection connection = this.ProjectNode.Project.UserSettings.Connections.SingleOrDefault(o => string.Equals(this.ConnectionInfo, o.Name));

            if (connection == null)
                MessageBox.Show("The connection has not been configured.", "Connection Not Configured", MessageBoxButtons.OK);
            else
            {
                try
                {
                    connection.Validate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("The connection to the data source could not be established. The following error was returned:" + TextUtil.GetExceptionText(ex), "Connection Failed", MessageBoxButtons.OK);
                    return;
                }

                MessageBox.Show("Connection test succeeded!");
            }
        }

        public override void UpdateNode()
        {
            this.Text = this.ConnectionInfo.ToString();
        }

        public void RefreshTablesNode()
        {
            TablesNode.Nodes.Clear();

            foreach (var schemaName in this.ProjectNode.Project.TableMappings.Select(o => o.SchemaName).Distinct().OrderBy(o => o))
            {
                SchemaTreeNode schemaNode = new SchemaTreeNode(this, schemaName);
                bool anyVisible = false;

                foreach (TableMapping tableMapping in this.ProjectNode.Project.TableMappings
                    .Where(o => string.Equals(o.ConnectionName, this.ConnectionInfo.Name))
                    .Where(o => string.Equals(o.SchemaName, schemaName))
                    .OrderBy(o => o.ClassName))
                {
                    if (!tableMapping.Exclude || this.ProjectNode.Project.UserSettings.ShowExcludedItems)
                    {
                        schemaNode.Nodes.Add(new TableOrViewTreeNode(this, tableMapping));
                        anyVisible = true;
                    }
                }

                if (anyVisible)
                    TablesNode.Nodes.Add(schemaNode);
            }

            TablesNode.Expand();
        }

        public void RefreshViewsNode()
        {
            ViewsNode.Nodes.Clear();

            foreach (var schemaName in this.ProjectNode.Project.ViewMappings.Select(o => o.SchemaName).Distinct().OrderBy(o => o))
            {
                SchemaTreeNode schemaNode = new SchemaTreeNode(this, schemaName);
                bool anyVisible = false;

                foreach (ViewMapping viewMapping in this.ProjectNode.Project.ViewMappings
                    .Where(o => string.Equals(o.ConnectionName, this.ConnectionInfo.Name))
                    .Where(o => string.Equals(o.SchemaName, schemaName))
                    .OrderBy(o => o.ClassName))
                {
                    if (!viewMapping.Exclude || this.ProjectNode.Project.UserSettings.ShowExcludedItems)
                    {
                        schemaNode.Nodes.Add(new TableOrViewTreeNode(this, viewMapping));
                        anyVisible = true;
                    }
                }

                if (anyVisible)
                    ViewsNode.Nodes.Add(schemaNode);
            }

            ViewsNode.Expand();
        }

        private void DeleteConnectionMenuItem_Click(object sender, EventArgs e)
        {
            OnDeleteConnection();
        }

        private void OnDeleteConnection()
        {
            if (DeleteClicked != null)
                DeleteClicked(this, this.ConnectionInfo);
        }
    }
}