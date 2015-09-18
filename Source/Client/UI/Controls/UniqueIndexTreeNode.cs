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
        private UniqueConstraint _uniqueIndexMapping;

        public UniqueConstraint UniqueIndexMapping
        {
            get { return _uniqueIndexMapping; }
        }

        public UniqueIndexTreeNode(UniqueConstraint uniqueIndexMapping)
        {
            _uniqueIndexMapping = uniqueIndexMapping;

            Initialize();
        }

        private void Initialize()
        {
            this.ContextMenu = new ContextMenu();
            this.ContextMenu.MenuItems.Add(new MenuItem("Exclude From Project"));
            this.ContextMenu.MenuItems[0].Checked = _uniqueIndexMapping.Exclude;
            this.ContextMenu.MenuItems[0].Click += new EventHandler(ExcludeFromProjectMenuItem_Click);

            UpdateNode();
        }

        public override void UpdateNode()
        {
            this.Text = _uniqueIndexMapping.UniqueIndexName + " (";

            foreach (Property cm in _uniqueIndexMapping.Properties)
                this.Text += cm.FieldName + (cm == _uniqueIndexMapping.Properties[_uniqueIndexMapping.Properties.Count - 1] ? "" : ", ");

            this.Text += ")";
            this.ForeColor = (_uniqueIndexMapping.Exclude ? Color.LightGray : Color.Black);
        }

        void ExcludeFromProjectMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;

            menuItem.Checked = !menuItem.Checked;
            _uniqueIndexMapping.Exclude = menuItem.Checked;

            UpdateNode();
        }
    }
}
