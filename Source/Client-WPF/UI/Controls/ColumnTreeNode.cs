using System;
using System.Collections.Generic;
using System.Text;
using QuantumConcepts.DAOGenerator.Core.ProjectSchema;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace QuantumConcepts.DAOGenerator.Client.UI.Controls
{
    public class ColumnTreeNode : ProjectSchemaNode
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
            ForeignKeyMapping foreignKey = _columnMapping.ContainingProject.FindForeignKeyForParentColumn(_columnMapping);
            MenuItem exclude = new MenuItem()
            {
                Header = "Exclude From Project"
            };

            exclude.IsCheckable = true;
            exclude.IsChecked = _columnMapping.Exclude;
            exclude.Click += new RoutedEventHandler(ExcludeFromProjectMenuItem_Click);
            this.ContextMenu = new ContextMenu();
            this.ContextMenu.Items.Add(exclude);

            if (foreignKey != null)
                this.Items.Add(new ForeignKeyNode(foreignKey));

            UpdateNode();
        }

        public override void UpdateNode()
        {
            this.Header = _columnMapping.ColumnName;

            if (!String.IsNullOrEmpty(_columnMapping.FieldName) && !_columnMapping.ColumnName.Equals(_columnMapping.FieldName))
                this.Header += " (" + _columnMapping.FieldName + ")";

            this.Foreground = new SolidColorBrush(_columnMapping.Exclude ? Colors.LightGray : Colors.Black);
        }

        void ExcludeFromProjectMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;

            menuItem.IsChecked = !menuItem.IsChecked;
            _columnMapping.Exclude = menuItem.IsChecked;

            UpdateNode();
        }
    }
}
