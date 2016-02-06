using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.Drawing;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal sealed class ColumnTreeNode : ProjectSchemaTreeNode
    {
        public ColumnMapping ColumnMapping { get; private set; }

        public ColumnTreeNode(ProjectSchemaTreeNode parent, ColumnMapping columnMapping)
            : base(parent)
        {
            this.ColumnMapping = columnMapping;

            Initialize();
        }

        private void Initialize()
        {
            ForeignKeyMapping foreignKey = this.ColumnMapping.ContainingProject.FindForeignKeyMappingForParentColumn(this.ColumnMapping);

            if (foreignKey != null && (!foreignKey.Exclude || this.ProjectNode.Project.UserSettings.ShowExcludedItems))
                this.Nodes.Add(new ForeignKeyTreeNode(this, foreignKey));

            this.ContextMenu = new ContextMenu();
            this.ContextMenu.MenuItems.Add(new MenuItem("Exclude From Project"));
            this.ContextMenu.MenuItems[0].Checked = this.ColumnMapping.Exclude;
            this.ContextMenu.MenuItems[0].Click += new EventHandler(ExcludeFromProjectMenuItem_Click);

            UpdateNode();
        }

        public override void UpdateNode()
        {
            if (this.ColumnMapping.Exclude && !this.ProjectNode.Project.UserSettings.ShowExcludedItems)
                Remove();
            else
            {
                this.Text = this.ColumnMapping.ColumnName;

                if (!String.IsNullOrEmpty(this.ColumnMapping.FieldName) && !this.ColumnMapping.ColumnName.Equals(this.ColumnMapping.FieldName))
                    this.Text += " (" + this.ColumnMapping.FieldName + ")";

                this.ForeColor = (this.ColumnMapping.Exclude ? Color.LightGray : Color.Black);
            }
        }

        void ExcludeFromProjectMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;

            menuItem.Checked = !menuItem.Checked;
            this.ColumnMapping.Exclude = menuItem.Checked;

            UpdateNode();
        }
    }
}
