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
        private UniqueIndexMapping _uniqueIndexMapping;

        public UniqueIndexMapping UniqueIndexMapping
        {
            get { return _uniqueIndexMapping; }
        }

        public UniqueIndexTreeNode(UniqueIndexMapping uniqueIndexMapping)
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

            foreach (ColumnMapping cm in _uniqueIndexMapping.ColumnMappings)
                this.Text += cm.FieldName + (cm == _uniqueIndexMapping.ColumnMappings[_uniqueIndexMapping.ColumnMappings.Count - 1] ? "" : ", ");

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
