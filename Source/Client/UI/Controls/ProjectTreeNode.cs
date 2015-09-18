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

        private Project _project;
        private TreeNode _settingsNode, _templatesNode, _tablesNode, _viewsNode;

        public Project Project { get { return _project; } }

        public ProjectTreeNode(Project project)
        {
            _project = project;

            Initialize();
        }

        private void Initialize()
        {
            this.ContextMenu = new ContextMenu(new MenuItem[]
            {
                new MenuItem("Properties", new EventHandler(PropertiesMenuItem_Click))
            });

            _settingsNode = new TreeNode("Settings");
            _templatesNode = new TreeNode("Templates");
            _tablesNode = new TreeNode("Tables");
            _viewsNode = new TreeNode("Views");

            UpdateNode();
            Rebuild();

            this.Expand();
        }

        public override void UpdateNode()
        {
            if (String.IsNullOrEmpty(_project.Path))
                this.Text = "New Project";
            else
                this.Text = _project.Path.Substring(_project.Path.LastIndexOf("\\") + 1);
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
            this.Nodes.AddRange(new TreeNode[]
            {
                _settingsNode,
                _templatesNode,
                _tablesNode,
                _viewsNode
            });
        }

        public void RefreshSettingsNode()
        {
            TreeNode connectionsNode = null;
            TreeNode dataTypesNode = null;

            _settingsNode.Nodes.Clear();

            connectionsNode = new TreeNode("Connections");

            if (_project.UserSettings.Connection != null)
                connectionsNode.Nodes.Add(new ConnectionTreeNode(_project.UserSettings.Connection));

            dataTypesNode = new TreeNode("Data Types");

            foreach (DataTypeMapping dataTypeMapping in _project.DataTypeMappings)
                dataTypesNode.Nodes.Add(new DataTypeTreeNode(dataTypeMapping));

            _settingsNode.Nodes.Add(connectionsNode);
            _settingsNode.Nodes.Add(dataTypesNode);
        }

        public void RefreshTemplatesNode()
        {
            _templatesNode.Nodes.Clear();
            _templatesNode.ContextMenu = new ContextMenu(new MenuItem[]
            {
                new MenuItem("New Template....",  new EventHandler(NewTemplateMenuItem_Click))
            });

            if (!_project.Templates.IsNullOrEmpty())
            {
                foreach (Template template in _project.Templates)
                {
                    TemplateTreeNode node = new TemplateTreeNode(template);

                    node.GenerateClick += new EventHandler((s, e) =>
                    {
                        if (TemplateGenerateClick != null)
                            TemplateGenerateClick(s, e);
                    });
                    _templatesNode.Nodes.Add(node);
                }
            }
        }

        public void RefreshTablesNode()
        {
            _tablesNode.Nodes.Clear();

            foreach (var schemaName in _project.Entities.Select(o => o.SchemaName).Distinct().OrderBy(o => o))
            {
                SchemaTreeNode schemaNode = new SchemaTreeNode(schemaName);

                foreach (Entity tableMapping in _project.Entities.Where(o => string.Equals(o.SchemaName, schemaName)))
                    schemaNode.Nodes.Add(new TableOrViewTreeNode(tableMapping));

                _tablesNode.Nodes.Add(schemaNode);
            }

            _tablesNode.Expand();
        }

        public void RefreshViewsNode()
        {
            _viewsNode.Nodes.Clear();

            foreach (var schemaName in _project.ViewMappings.Select(o => o.SchemaName).Distinct().OrderBy(o => o))
            {
                SchemaTreeNode schemaNode = new SchemaTreeNode(schemaName);

                foreach (ViewEntity viewMapping in _project.ViewMappings.Where(o => string.Equals(o.SchemaName, schemaName)))
                    schemaNode.Nodes.Add(new TableOrViewTreeNode(viewMapping));

                _viewsNode.Nodes.Add(schemaNode);
            }

            _viewsNode.Expand();
        }

        private void PropertiesMenuItem_Click(object sender, EventArgs e)
        {
            using (ProjectProperties dialog = new ProjectProperties(_project))
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

                    _project.Templates.Add(dialog.Template);

                    RefreshTemplatesNode();
                }
            }
        }
    }
}
