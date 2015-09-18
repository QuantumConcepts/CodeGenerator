using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.Drawing;
using QuantumConcepts.Common.Extensions;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal sealed class TableOrViewTreeNode : ProjectSchemaTreeNode
    {
        private Entity _tableOrViewMapping;

        public Entity TableMapping
        {
            get { return _tableOrViewMapping; }
        }

        public ViewEntity ViewMapping
        {
            get { return (_tableOrViewMapping as ViewEntity); }
        }

        public TableOrViewTreeNode(Entity tableOrViewMapping)
        {
            _tableOrViewMapping = tableOrViewMapping;

            Initialize();
        }

        private void Initialize()
        {
            TreeNode columnsNode = new TreeNode("Columns");

            this.Nodes.Add(columnsNode);

            for (int i = 0; i < _tableOrViewMapping.Properties.Count; i++)
            {
                ColumnTreeNode node = new ColumnTreeNode(_tableOrViewMapping.Properties[i]);

                columnsNode.Nodes.Add(node);
                Application.DoEvents();
            }

            if (_tableOrViewMapping.UniqueConstraints.Count > 0)
            {
                TreeNode uniqueIndicesNode = new TreeNode("Unique Indices");

                this.Nodes.Add(uniqueIndicesNode);

                for (int i = 0; i < _tableOrViewMapping.UniqueConstraints.Count; i++)
                {
                    UniqueIndexTreeNode node = new UniqueIndexTreeNode(_tableOrViewMapping.UniqueConstraints[i]);

                    uniqueIndicesNode.Nodes.Add(node);
                    Application.DoEvents();
                }
            }

            this.ContextMenu = new ContextMenu();
            this.ContextMenu.MenuItems.Add(new MenuItem("Exclude From Project"));
            this.ContextMenu.MenuItems[0].Checked = _tableOrViewMapping.Exclude;
            this.ContextMenu.MenuItems[0].Click += new EventHandler(ExcludeFromProjectMenuItem_Click);

            UpdateNode();
        }

        public override void UpdateNode()
        {
            this.Text = _tableOrViewMapping.Name;

            if (!string.IsNullOrEmpty(_tableOrViewMapping.ClassName) && !_tableOrViewMapping.Name.Equals(_tableOrViewMapping.ClassName))
                this.Text += " (" + _tableOrViewMapping.ClassName + ")";

            this.ForeColor = (_tableOrViewMapping.Exclude ? Color.LightGray : Color.Black);
        }

        void ExcludeFromProjectMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;

            menuItem.Checked = !menuItem.Checked;
            _tableOrViewMapping.Exclude = menuItem.Checked;

            UpdateNode();
        }
    }
}
