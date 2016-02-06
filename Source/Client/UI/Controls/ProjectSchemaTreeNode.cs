using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal abstract class ProjectSchemaTreeNode : TreeNode
    {
        public ProjectSchemaTreeNode ParentSchemaNode { get; private set; }

        public ProjectTreeNode ProjectNode
        {
            get
            {
                ProjectSchemaTreeNode node = this;

                while (node != null && !(node is ProjectTreeNode))
                    node = node.ParentSchemaNode;

                return (node as ProjectTreeNode);
            }
        }

        //public ProjectSchemaTreeNode() { }

        public ProjectSchemaTreeNode(ProjectSchemaTreeNode parent)
        {
            this.ParentSchemaNode = parent;
        }

        public abstract void UpdateNode();

        public virtual void RemoveIfEmpty()
        {
            if (this.Nodes.Count == 0)
                Remove();
        }

        public new virtual void Remove()
        {
            var parent = (this.Parent as ProjectSchemaTreeNode);

            base.Remove();

            if (parent != null)
                parent.RemoveIfEmpty();
        }
    }
}
