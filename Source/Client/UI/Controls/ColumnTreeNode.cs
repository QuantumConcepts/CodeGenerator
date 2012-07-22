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
        private ColumnMapping _columnMapping;

        public ColumnMapping ColumnMapping
        {
            get { return _columnMapping; }
        }

        public ColumnTreeNode(ColumnMapping columnMapping)
        {
            _columnMapping = columnMapping;

            Initialize();
        }

        private void Initialize()
        {
            ForeignKeyMapping foreignKey = _columnMapping.ContainingProject.FindForeignKeyMappingForParentColumn(_columnMapping);

            if (foreignKey != null)
                this.Nodes.Add(new ForeignKeyTreeNode(foreignKey));

            this.ContextMenu = new ContextMenu();
            this.ContextMenu.MenuItems.Add(new MenuItem("Exclude From Project"));
            this.ContextMenu.MenuItems[0].Checked = _columnMapping.Exclude;
            this.ContextMenu.MenuItems[0].Click += new EventHandler(ExcludeFromProjectMenuItem_Click);

            UpdateNode();
        }

        public override void UpdateNode()
        {
            this.Text = _columnMapping.ColumnName;

            if (!String.IsNullOrEmpty(_columnMapping.FieldName) && !_columnMapping.ColumnName.Equals(_columnMapping.FieldName))
                this.Text += " (" + _columnMapping.FieldName + ")";

            this.ForeColor = (_columnMapping.Exclude ? Color.LightGray : Color.Black);
        }

        void ExcludeFromProjectMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;

            menuItem.Checked = !menuItem.Checked;
            _columnMapping.Exclude = menuItem.Checked;

            UpdateNode();
        }
    }
}
