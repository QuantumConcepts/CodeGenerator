using System;
using System.Collections.Generic;
using System.Text;
using QuantumConcepts.DAOGenerator.Core.ProjectSchema;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace QuantumConcepts.DAOGenerator.Client.UI.Controls
{
    public class TableTreeNode : ProjectSchemaNode
    {
        private TableMapping _tableMapping;

        public TableMapping TableMapping
        {
            get { return _tableMapping; }
        }

        public TableTreeNode(TableMapping tableMapping)
        {
            _tableMapping = tableMapping;

            Initialize();
        }

        private void Initialize()
        {
            TreeViewItem columnsItem = new TreeViewItem();
            MenuItem exclude = new MenuItem()
            {
                Header = "Exclude From Project"
            };

            exclude.IsCheckable = true;
            exclude.IsChecked = _tableMapping.Exclude;
            exclude.Click += new RoutedEventHandler(ExcludeFromProjectMenuItem_Click);
            this.ContextMenu = new ContextMenu();
            this.ContextMenu.Items.Add(exclude);

            columnsItem.Header = "Columns";
            this.Items.Add(columnsItem);

            for (int i = 0; i < _tableMapping.ColumnMappings.Count; i++)
            {
                ColumnTreeNode item = new ColumnTreeNode(_tableMapping.ColumnMappings[i]);

                columnsItem.Items.Add(item);
            }

            if (_tableMapping.UniqueIndexMappings.Count > 0)
            {
                TreeViewItem uniqueIndicesItem = new TreeViewItem();

                uniqueIndicesItem.Header = "Unique Indices";
                this.Items.Add(uniqueIndicesItem);

                for (int i = 0; i < _tableMapping.UniqueIndexMappings.Count; i++)
                {
                    UniqueIndexTreeNode item = new UniqueIndexTreeNode(_tableMapping.UniqueIndexMappings[i]);

                    uniqueIndicesItem.Items.Add(item);
                }
            }

            UpdateNode();
        }

        public override void UpdateNode()
        {
            this.Header = _tableMapping.TableName;

            if (!string.IsNullOrEmpty(_tableMapping.ClassName) && !_tableMapping.TableName.Equals(_tableMapping.ClassName))
                this.Header += " (" + _tableMapping.ClassName + ")";

            this.Foreground = new SolidColorBrush(_tableMapping.Exclude ? Colors.LightGray : Colors.Black);
        }

        void ExcludeFromProjectMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;

            menuItem.IsChecked = !menuItem.IsChecked;
            _tableMapping.Exclude = menuItem.IsChecked;

            UpdateNode();
        }
    }
}
