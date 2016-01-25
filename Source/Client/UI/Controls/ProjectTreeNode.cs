using System;
using System.Collections.Generic;
using System.Text;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Client.UI.Forms;
using System.Reflection;
using System.IO;
using QuantumConcepts.CodeGenerator.Core;
using QuantumConcepts.Common.Extensions;
using System.Linq;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal sealed class ProjectTreeNode : ProjectSchemaTreeNode
    {
        public event EventHandler TemplateGenerateClick;

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

            SettingsNode = new TreeNode("Settings");
            TemplatesNode = new TreeNode("Templates");
            ConnectionsNode = new TreeNode("Connections");

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
            TemplatesNode.Nodes.Clear();
            TemplatesNode.ContextMenu = new ContextMenu(new MenuItem[]
            {
                new MenuItem("New Template....",  new EventHandler(NewTemplateMenuItem_Click))
            });

            if (!this.Project.Templates.IsNullOrEmpty())
            {
                foreach (Template template in this.Project.Templates.OrderBy(o => o.XsltHintPath))
                {
                    TemplateTreeNode node = new TemplateTreeNode(this, template);

                    node.GenerateClick += new EventHandler((s, e) =>
                    {
                        if (TemplateGenerateClick != null)
                            TemplateGenerateClick(s, e);
                    });
                    TemplatesNode.Nodes.Add(node);
                }
            }
        }

        public void RefreshConnectionsNode()
        {
            ConnectionsNode.Nodes.Clear();
            ConnectionsNode.ContextMenu = new ContextMenu(new MenuItem[]
            {
                new MenuItem("New Connection....",  new EventHandler(NewConnectionMenuItem_Click))
            });

            if (!this.Project.Connections.IsNullOrEmpty())
            {
                foreach (var connectionName in this.Project.Connections.OrderBy(o => o.Name))
                {
                    ConnectionTreeNode node = new ConnectionTreeNode(this, connectionName);

                    ConnectionsNode.Nodes.Add(node);
                }
            }

            ConnectionsNode.Expand();
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
        }
    }
}
