using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal class SchemaTreeNode : ProjectSchemaTreeNode
    {
        private string SchemaName { get; set; }

        public SchemaTreeNode(string schemaName)
        {
            this.SchemaName = schemaName;

            UpdateNode();
            this.Expand();
        }

        public override void UpdateNode()
        {
            this.Text = this.SchemaName;
        }
    }
}
