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
        private TreeNode TablesNode { get; set; }
        private TreeNode ViewsNode { get; set; }

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
            TablesNode = new TreeNode("Tables");
            ViewsNode = new TreeNode("Views");

            UpdateNode();
            Rebuild();

            this.Expand();
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
            RefreshTablesNode();
            RefreshViewsNode();

            RebuildTree();
        }

        public void RebuildTree()
        {
            this.Nodes.Clear();
            this.Nodes.Add(SettingsNode);
            this.Nodes.Add(TemplatesNode);

            if (TablesNode.Nodes.Count > 0)
                this.Nodes.Add(TablesNode);

            if (ViewsNode.Nodes.Count > 0)
                this.Nodes.Add(ViewsNode);
        }

        public void RefreshSettingsNode()
        {
            TreeNode connectionsNode = null;
            TreeNode dataTypesNode = null;

            SettingsNode.Nodes.Clear();

            connectionsNode = new TreeNode("Connections");

            if (this.Project.UserSettings.Connection != null)
                connectionsNode.Nodes.Add(new ConnectionTreeNode(this, this.Project.UserSettings.Connection));

            dataTypesNode = new TreeNode("Data Types");

            foreach (DataTypeMapping dataTypeMapping in this.Project.DataTypeMappings)
                dataTypesNode.Nodes.Add(new DataTypeTreeNode(this, dataTypeMapping));

            SettingsNode.Nodes.Add(connectionsNode);
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
                foreach (Template template in this.Project.Templates.OrderBy(o => o.Name))
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

        public void RefreshTablesNode()
        {
            TablesNode.Nodes.Clear();

            foreach (var schemaName in this.Project.TableMappings.Select(o => o.SchemaName).Distinct().OrderBy(o => o))
            {
                SchemaTreeNode schemaNode = new SchemaTreeNode(this, schemaName);
                bool anyVisible = false;

                foreach (TableMapping tableMapping in this.Project.TableMappings
                    .Where(o => string.Equals(o.SchemaName, schemaName))
                    .OrderBy(o => o.ClassName))
                {
                    if (!tableMapping.Exclude || this.Project.UserSettings.ShowExcludedItems)
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

            foreach (var schemaName in this.Project.ViewMappings.Select(o => o.SchemaName).Distinct().OrderBy(o => o))
            {
                SchemaTreeNode schemaNode = new SchemaTreeNode(this, schemaName);
                bool anyVisible = false;

                foreach (ViewMapping viewMapping in this.Project.ViewMappings
                    .Where(o => string.Equals(o.SchemaName, schemaName))
                    .OrderBy(o => o.ClassName))
                {
                    if (!viewMapping.Exclude || this.Project.UserSettings.ShowExcludedItems)
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
    }
}
