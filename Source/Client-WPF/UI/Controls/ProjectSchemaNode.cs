using System;
using System.Collections.Generic;
using System.Text;
using QuantumConcepts.DAOGenerator.Core.ProjectSchema;
using System.Windows.Controls;

namespace QuantumConcepts.DAOGenerator.Client.UI.Controls
{
    public abstract class ProjectSchemaNode : TreeViewItem
    {
        public abstract void UpdateNode();
    }
}
