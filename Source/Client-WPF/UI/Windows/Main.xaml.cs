using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using QuantumConcepts.DAOGenerator.Core.ProjectSchema;
using QuantumConcepts.DAOGenerator.Client.UI.Controls;

namespace QuantumConcepts.DAOGenerator.Client.UI.Windows
{
    public partial class Main : Window
    {
        public Main()
        {
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            const string projectFilePath = @"D:\Users\Josh\Documents\Projects\QuantumConcepts\QuantumConcepts\DAOGenerator\Test Projects\SQL Server\SQLServer.dfp";

            ProjectContext.Initialize(Project.Open(projectFilePath));
            LoadTreeView();
        }

        private void LoadTreeView()
        {
            projectTreeView.Items.Clear();
            projectTreeView.Items.Add(new ProjectTreeNode(ProjectContext.Project));
        }
    }
}
