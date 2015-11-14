namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal class SchemaTreeNode : ProjectSchemaTreeNode
    {
        private string SchemaName { get; set; }

        public SchemaTreeNode(ProjectSchemaTreeNode parent, string schemaName)
            : base(parent)
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
