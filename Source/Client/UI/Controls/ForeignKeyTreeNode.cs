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
        private ForeignKeyMapping _foreignKeyMapping;

        public ForeignKeyMapping ForeignKeyMapping
        {
            get { return _foreignKeyMapping; }
            set { _foreignKeyMapping = value; }
        }

        public ForeignKeyTreeNode(ForeignKeyMapping foreignKeyMapping)
        {
            _foreignKeyMapping = foreignKeyMapping;

            Initialize();
        }

        private void Initialize()
        {
            this.ContextMenu = new ContextMenu();
            this.ContextMenu.MenuItems.Add(new MenuItem("Exclude From Project"));
            this.ContextMenu.MenuItems[0].Checked = _foreignKeyMapping.Exclude;
            this.ContextMenu.MenuItems[0].Click += new EventHandler(ExcludeFromProjectMenuItem_Click);

            UpdateNode();
        }

        public override void UpdateNode()
        {
            this.Text = _foreignKeyMapping.ForeignKeyName;

            if (!string.IsNullOrEmpty(_foreignKeyMapping.FieldName))
                this.Text += " (" + _foreignKeyMapping.FieldName + ")";

            this.ForeColor = (_foreignKeyMapping.Exclude ? Color.LightGray : Color.Black);
        }

        void ExcludeFromProjectMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;

            menuItem.Checked = !menuItem.Checked;
            _foreignKeyMapping.Exclude = menuItem.Checked;

            UpdateNode();
        }
    }
}
