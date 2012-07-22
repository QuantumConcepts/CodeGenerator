using System;
using System.Collections.Generic;
using System.Text;
using QuantumConcepts.DAOGenerator.Core.ProjectSchema;
using System.Reflection;
using System.IO;
using QuantumConcepts.DAOGenerator.Core;
using System.Windows.Controls;
using System.Windows;

namespace QuantumConcepts.DAOGenerator.Client.UI.Controls
{
    public class ProjectTreeNode : ProjectSchemaNode
    {
        private Project _project;

        public Project Project { get { return _project; } }

        public ProjectTreeNode(Project project)
        {
            _project = project;

            Initialize();
        }

        private void Initialize()
        {
            MenuItem properties = new MenuItem()
            {
                Header = "Properties"
            };

            properties.Click += new RoutedEventHandler(PropertiesMenuItem_Click);
            this.ContextMenu = new ContextMenu();
            this.ContextMenu.Items.Add(properties);

            UpdateNode();
        }

        public override void UpdateNode()
        {
            if (String.IsNullOrEmpty(_project.FileName))
                this.Header = "New Project";
            else
                this.Header = _project.FileName.Substring(_project.FileName.LastIndexOf("\\") + 1);

            this.Items.Clear();
            this.Items.Add(GetSettingsNode());
            this.Items.Add(GetTablesNode());
        }

        private TreeViewItem GetTablesNode()
        {
            TreeViewItem item = new TreeViewItem();

            item.Header = "Tables";

            foreach (TableMapping tableMapping in _project.TableMappings)
                item.Items.Add(new TableTreeNode(tableMapping));

            return item;
        }

        private TreeViewItem GetSettingsNode()
        {
            TreeViewItem item = new TreeViewItem();

            item.Header = "Settings";
            item.Items.Add(GetConnectionsNode());
            item.Items.Add(GetDataTypesNode());
            item.Items.Add(GetTemplatesNode());

            return item;
        }

        private TreeViewItem GetConnectionsNode()
        {
            TreeViewItem item = new TreeViewItem();
            MenuItem newConnection = new MenuItem()
            {
                Header = "New Connection...."
            };

            item.Header = "Connections";
            item.ContextMenu = new ContextMenu();
            item.ContextMenu.Items.Add(newConnection);
            item.Items.Add(new ConnectionTreeNode(_project.UserSettings.Connection));

            return item;
        }

        private TreeViewItem GetDataTypesNode()
        {
            TreeViewItem item = new TreeViewItem();
            MenuItem newDataType = new MenuItem()
            {
                Header = "New Data Type...."
            };

            item.Header = "Data Types";
            item.ContextMenu = new ContextMenu();
            item.ContextMenu.Items.Add(newDataType);

            foreach (DataTypeMapping dataTypeMapping in _project.DataTypeMappings)
                item.Items.Add(new DataTypeTreeNode(dataTypeMapping));

            return item;
        }

        private TreeViewItem GetTemplatesNode()
        {
            TreeViewItem item = new TreeViewItem();
            MenuItem newTemplate = new MenuItem()
            {
                Header = "New Template"
            };

            item.Header = "Templates";
            item.ContextMenu = new ContextMenu();
            item.ContextMenu.Items.Add(newTemplate);
            newTemplate.Click += new RoutedEventHandler(NewTemplateMenuItem_Click);

            foreach (Template template in _project.UserSettings.Templates)
                item.Items.Add(new TemplateTreeNode(template));

            return item;
        }

        private void PropertiesMenuItem_Click(object sender, EventArgs e)
        {
            //ProjectProperties dialog = new ProjectProperties(_project);

            //dialog.ShowDialog();
        }

        private void NewConnectionMenuItem_Click(object sender, EventArgs e)
        {
            //TODO
            //EditConnectionDialog dialog = new EditConnectionDialog();

            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    TreeNode node = (TreeNode)sender;

            //    _project.Connections.Add(dialog.Connection);
            //    node.Nodes.Add(new ConnectionTreeNode(dialog.Connection);
            //}
        }

        private void NewDataTypeMenuItem_Click(object sender, EventArgs e)
        {
            //TODO
            //EditDataType dialog = new EditDataType();

            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    TreeNode node = (TreeNode)sender;

            //    _project.DataTypeMappings.Add(dialog.DataTypeMapping);
            //    node.Nodes.Add(new DataTypeTreeNode(dialog.DataTypeMapping);
            //}
        }

        private void NewTemplateMenuItem_Click(object sender, EventArgs e)
        {
            //SaveFileDialog dialog = new SaveFileDialog();

            //dialog.Filter = "XSLT Files|*.xslt";

            //if (dialog.ShowDialog() == DialogResult.OK)
            //{
            //    string filePath = dialog.FileName;
            //    string newTemplateFilePath = Configuration.CodeBase + "\\Resources\\Templates\\NewTemplate.xslt";

            //    try
            //    {
            //        if (File.Exists(newTemplateFilePath))
            //            File.Copy(newTemplateFilePath, filePath);
            //        else
            //            File.Create(filePath);
            //    }
            //    catch (Exception ex)
            //    {
            //        MessageBox.Show("An error occurred while creating the new template file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }

            //    _project.UserSettings.Templates.Add(new Template(filePath, null));
            //}
        }

        private void ProjectTreeNode_Click(object sender, EventArgs e)
        {
            //ProjectProperties propertiesForm = new ProjectProperties(_project);

            //propertiesForm.ShowDialog();
        }
    }
}
