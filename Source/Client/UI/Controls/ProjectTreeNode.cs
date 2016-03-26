using QuantumConcepts.CodeGenerator.Client.UI.Forms;
using QuantumConcepts.CodeGenerator.Core;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Extensions;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal sealed class ProjectTreeNode : ProjectSchemaTreeNode
    {
        public event TemplateTreeNode.GenerateEventHandler TemplateGenerateClicked;
        public event ConnectionTreeNode.ConnectionInfoEventHandler ConnectionDeleteClicked;
        
        public event EventHandler NewConnectionClicked;

        private TreeNode SettingsNode { get; set; }
        private TreeNode TemplatesNode { get; set; }
        private TreeNode ConnectionsNode { get; set; }

        public Project Project { get; private set; }

        public ProjectTreeNode(Project project) : this(null, project) { }

        public ProjectTreeNode(ProjectSchemaTreeNode parent, Project project)
            : base(parent)
        {
            this.Project = project;

            Initialize();
        }

        private void Initialize()
        {
            this.ContextMenu = new ContextMenu(new MenuItem[]
            {
                new MenuItem("Properties", new EventHandler(PropertiesMenuItem_Click))
            });

            this.SettingsNode = new TreeNode("Settings");
            this.TemplatesNode = new TreeNode("Templates");
            this.ConnectionsNode = new TreeNode("Connections");

            UpdateNode();
            Rebuild();
        }

        public override void UpdateNode()
        {
            if (String.IsNullOrEmpty(this.Project.Path))
                this.Text = "New Project";
            else
                this.Text = this.Project.Path.Substring(this.Project.Path.LastIndexOf("\\") + 1);
        }

        public void Rebuild()
        {
            RefreshSettingsNode();
            RefreshTemplatesNode();
            RefreshConnectionsNode();

            RebuildTree();

            this.Expand();
        }

        public void RebuildTree()
        {
            this.Nodes.Clear();
            this.Nodes.Add(SettingsNode);
            this.Nodes.Add(TemplatesNode);
            this.Nodes.Add(ConnectionsNode);
        }

        public void RefreshSettingsNode()
        {
            TreeNode dataTypesNode = null;

            SettingsNode.Nodes.Clear();

            dataTypesNode = new TreeNode("Data Types");

            foreach (DataTypeMapping dataTypeMapping in this.Project.DataTypeMappings)
                dataTypesNode.Nodes.Add(new DataTypeTreeNode(this, dataTypeMapping));

            SettingsNode.Nodes.Add(dataTypesNode);
        }

        public void RefreshTemplatesNode()
        {
            this.TemplatesNode.Nodes.Clear();
            this.TemplatesNode.ContextMenu = new ContextMenu(new MenuItem[]
            {
                new MenuItem("New Template...",  new EventHandler(NewTemplateMenuItem_Click))
            });

            if (!this.Project.Templates.IsNullOrEmpty())
            {
                foreach (Template template in this.Project.Templates.OrderBy(o => o.XsltHintPath))
                {
                    TemplateTreeNode node = new TemplateTreeNode(this, template);

                    node.GenerateClick += new TemplateTreeNode.GenerateEventHandler((s, e) =>
                    {
                        if (TemplateGenerateClicked != null)
                            TemplateGenerateClicked(s, e);
                    });
                    this.TemplatesNode.Nodes.Add(node);
                }
            }
        }

        public void RefreshConnectionsNode()
        {
            this.ConnectionsNode.Nodes.Clear();
            this.ConnectionsNode.ContextMenu = new ContextMenu(new MenuItem[]
            {
                new MenuItem("New Connection...",  new EventHandler(NewConnectionMenuItem_Click))
            });

            if (!this.Project.Connections.IsNullOrEmpty())
            {
                foreach (var connectionInfo in this.Project.Connections.OrderBy(o => o.Name))
                {
                    ConnectionTreeNode node = new ConnectionTreeNode(this, connectionInfo);

                    node.DeleteClicked += ConnectionNode_DeleteClicked;

                    this.ConnectionsNode.Nodes.Add(node);
                }
            }

            this.ConnectionsNode.Expand();
        }

        private void PropertiesMenuItem_Click(object sender, EventArgs e)
        {
            using (ProjectProperties dialog = new ProjectProperties(this.Project))
            {
                dialog.ShowDialog();
            }

            Rebuild();
        }

        private void NewTemplateMenuItem_Click(object sender, EventArgs e)
        {
            using (EditTemplate dialog = new EditTemplate(this.Project))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    string newTemplateFilePath = Configuration.CodeBase + "\\Resources\\Templates\\NewTemplate.xslt";

                    try
                    {
                        //If they are creating a new file, copy the template over.
                        if (!File.Exists(dialog.Template.XsltAbsolutePath))
                        {
                            if (File.Exists(newTemplateFilePath))
                                File.Copy(newTemplateFilePath, dialog.Template.XsltAbsolutePath);
                            else
                                File.Create(dialog.Template.XsltAbsolutePath).Dispose();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("An error occurred while creating the new template file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    this.Project.Templates.Add(dialog.Template);

                    RefreshTemplatesNode();
                }
            }
        }

        private void NewConnectionMenuItem_Click(object sender, EventArgs e)
        {
            OnNewConnectionClicked();
        }

        private void ConnectionNode_DeleteClicked(object sender, ConnectionInfo connectionInfo)
        {
            OnConnectionDeleteClicked(connectionInfo);
        }

        private void OnNewConnectionClicked()
        {
            if (NewConnectionClicked != null)
                NewConnectionClicked(this, EventArgs.Empty);
        }

        private void OnConnectionDeleteClicked(ConnectionInfo connectionInfo)
        {
            if (ConnectionDeleteClicked != null)
                ConnectionDeleteClicked(this, connectionInfo);
        }
    }
}
