using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal class SchemaTreeNode : ProjectSchemaTreeNode
    {
        private string SchemaName { get; set; }

        public SchemaTreeNode(ProjectSchemaTreeNode parent, string schemaName)
            : base(parent)
        {
            this.SchemaName = schemaName;

            Initialize();
        }

        private void Initialize()
        {
            this.ContextMenu = new ContextMenu();
            this.ContextMenu.MenuItems.Add(new MenuItem("Exclude From Project"));
            this.ContextMenu.MenuItems[0].Checked = GetSchemaTableMappings().All(o => o.Exclude);
            this.ContextMenu.MenuItems[0].Click += new EventHandler(ExcludeFromProjectMenuItem_Click);

            UpdateNode();
            this.Expand();
        }

        private IEnumerable<TableMapping> GetSchemaTableMappings()
        {
            return this.ProjectNode.Project
                .TableMappings
                .Where(o => string.Equals(o.SchemaName, this.SchemaName, StringComparison.InvariantCultureIgnoreCase));
        }

        public override void UpdateNode()
        {
            this.Text = this.SchemaName;
        }

        void ExcludeFromProjectMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;

            menuItem.Checked = !menuItem.Checked;
            GetSchemaTableMappings().ForEach(o => o.Exclude = menuItem.Checked);
            this.Nodes.Cast<TableOrViewTreeNode>().ForEach(o =>
            {
                if (o != null)
                    o.UpdateNode();
            });

            UpdateNode();
        }
    }
}
