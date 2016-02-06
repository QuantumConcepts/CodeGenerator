using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.Drawing;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal sealed class UniqueIndexTreeNode : ProjectSchemaTreeNode
    {
        public UniqueIndexMapping UniqueIndexMapping { get; private set; }

        public UniqueIndexTreeNode(ProjectSchemaTreeNode parent, UniqueIndexMapping uniqueIndexMapping)
            : base(parent)
        {
            this.UniqueIndexMapping = uniqueIndexMapping;

            Initialize();
        }

        private void Initialize()
        {
            this.ContextMenu = new ContextMenu();
            this.ContextMenu.MenuItems.Add(new MenuItem("Exclude From Project"));
            this.ContextMenu.MenuItems[0].Checked = this.UniqueIndexMapping.Exclude;
            this.ContextMenu.MenuItems[0].Click += new EventHandler(ExcludeFromProjectMenuItem_Click);

            UpdateNode();
        }

        public override void UpdateNode()
        {
            if (this.UniqueIndexMapping.Exclude && !this.ProjectNode.Project.UserSettings.ShowExcludedItems)
                Remove();
            else
            {
                this.Text = this.UniqueIndexMapping.UniqueIndexName + " (";

                foreach (ColumnMapping cm in this.UniqueIndexMapping.ColumnMappings)
                    this.Text += cm.FieldName + (cm == this.UniqueIndexMapping.ColumnMappings[this.UniqueIndexMapping.ColumnMappings.Count - 1] ? "" : ", ");

                this.Text += ")";
                this.ForeColor = (this.UniqueIndexMapping.Exclude ? Color.LightGray : Color.Black);
            }
        }

        void ExcludeFromProjectMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;

            menuItem.Checked = !menuItem.Checked;
            this.UniqueIndexMapping.Exclude = menuItem.Checked;

            UpdateNode();
        }
    }
}
