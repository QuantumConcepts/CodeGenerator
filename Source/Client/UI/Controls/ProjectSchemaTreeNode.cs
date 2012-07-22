using System;
using System.Collections.Generic;
using System.Text;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.Windows.Forms;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal abstract class ProjectSchemaTreeNode : TreeNode
    {
        public ProjectTreeNode ProjectNode
        {
            get
            {
                TreeNode node = this.Parent;

                while (node != null && !(node is ProjectTreeNode))
                    node = node.Parent;

                return (node as ProjectTreeNode);
            }
        }

        public abstract void UpdateNode();
    }
}
