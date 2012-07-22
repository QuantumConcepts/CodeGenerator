using System;
using System.Collections.Generic;
using System.Text;
using QuantumConcepts.DAOGenerator.Core.ProjectSchema;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Media;

namespace QuantumConcepts.DAOGenerator.Client.UI.Controls
{
    public class ForeignKeyNode : ProjectSchemaNode
    {
        private ForeignKeyMapping _foreignKeyMapping;

        public ForeignKeyMapping ForeignKeyMapping
        {
            get { return _foreignKeyMapping; }
            set { _foreignKeyMapping = value; }
        }

        public ForeignKeyNode(ForeignKeyMapping foreignKeyMapping)
        {
            _foreignKeyMapping = foreignKeyMapping;

            Initialize();
        }

        private void Initialize()
        {
            MenuItem exclude = new MenuItem()
            {
                Header = "Exclude From Project"
            };

            exclude.IsCheckable = true;
            exclude.IsChecked = _foreignKeyMapping.Exclude;
            exclude.Click += new RoutedEventHandler(ExcludeFromProjectMenuItem_Click);
            this.ContextMenu = new ContextMenu();
            this.ContextMenu.Items.Add(exclude);

            UpdateNode();
        }

        public override void UpdateNode()
        {
            this.Header = _foreignKeyMapping.ForeignKeyName;

            if (!string.IsNullOrEmpty(_foreignKeyMapping.FieldName))
                this.Header += " (" + _foreignKeyMapping.FieldName + ")";

            this.Foreground = new SolidColorBrush(_foreignKeyMapping.Exclude ? Colors.LightGray : Colors.Black);
        }

        void ExcludeFromProjectMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;

            menuItem.IsChecked = !menuItem.IsChecked;
            _foreignKeyMapping.Exclude = menuItem.IsChecked;

            UpdateNode();
        }
    }
}
