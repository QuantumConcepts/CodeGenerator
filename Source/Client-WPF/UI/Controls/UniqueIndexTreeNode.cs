using System;
using System.Collections.Generic;
using System.Text;
using QuantumConcepts.DAOGenerator.Core.ProjectSchema;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace QuantumConcepts.DAOGenerator.Client.UI.Controls
{
    public class UniqueIndexTreeNode : ProjectSchemaNode
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
            MenuItem exclude = new MenuItem()
            {
                Header = "Exclude From Project"
            };

            exclude.IsCheckable = true;
            exclude.IsChecked = _uniqueIndexMapping.Exclude;
            exclude.Click += new RoutedEventHandler(ExcludeFromProjectMenuItem_Click);
            this.ContextMenu = new ContextMenu();
            this.ContextMenu.Items.Add(exclude);

            UpdateNode();
        }

        public override void UpdateNode()
        {
            this.Header = _uniqueIndexMapping.UniqueIndexName + " (";

            foreach (ColumnMapping cm in _uniqueIndexMapping.ColumnMappings)
                this.Header += cm.FieldName + (cm == _uniqueIndexMapping.ColumnMappings[_uniqueIndexMapping.ColumnMappings.Count - 1] ? "" : ", ");

            this.Header += ")";
            this.Foreground = new SolidColorBrush(_uniqueIndexMapping.Exclude ? Colors.LightGray : Colors.Black);
        }

        void ExcludeFromProjectMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;

            menuItem.IsChecked = !menuItem.IsChecked;
            _uniqueIndexMapping.Exclude = menuItem.IsChecked;

            UpdateNode();
        }
    }
}
