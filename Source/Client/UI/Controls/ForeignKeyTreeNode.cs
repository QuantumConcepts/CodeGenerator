using System;
using System.Collections.Generic;
using System.Text;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.Windows.Forms;
using System.Drawing;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal sealed class ForeignKeyTreeNode : ProjectSchemaTreeNode
    {
        public ForeignKeyMapping ForeignKeyMapping { get; private set; }

        public ForeignKeyTreeNode(ProjectSchemaTreeNode parent, ForeignKeyMapping foreignKeyMapping)
            : base(parent)
        {
            this.ForeignKeyMapping = foreignKeyMapping;

            Initialize();
        }

        private void Initialize()
        {
            this.ContextMenu = new ContextMenu();
            this.ContextMenu.MenuItems.Add(new MenuItem("Exclude From Project"));
            this.ContextMenu.MenuItems[0].Checked = this.ForeignKeyMapping.Exclude;
            this.ContextMenu.MenuItems[0].Click += new EventHandler(ExcludeFromProjectMenuItem_Click);

            UpdateNode();
        }

        public override void UpdateNode()
        {
            if (this.ForeignKeyMapping.Exclude && !this.ProjectNode.Project.UserSettings.ShowExcludedItems)
                Remove();
            else
            {
                this.Text = this.ForeignKeyMapping.ForeignKeyName;

                if (!string.IsNullOrEmpty(this.ForeignKeyMapping.FieldName))
                    this.Text += " (" + this.ForeignKeyMapping.FieldName + ")";

                this.ForeColor = (this.ForeignKeyMapping.Exclude ? Color.LightGray : Color.Black);
            }
        }

        void ExcludeFromProjectMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;

            menuItem.Checked = !menuItem.Checked;
            this.ForeignKeyMapping.Exclude = menuItem.Checked;

            UpdateNode();
        }
    }
}
