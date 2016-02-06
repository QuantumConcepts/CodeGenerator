using QuantumConcepts.CodeGenerator.Core.ProjectSchema;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal sealed class DataTypeTreeNode : ProjectSchemaTreeNode
    {
        public DataTypeMapping DataTypeMapping { get; private set; }

        public DataTypeTreeNode(ProjectSchemaTreeNode parent, DataTypeMapping dataTypeMapping)
            : base(parent)
        {
            this.DataTypeMapping = dataTypeMapping;

            UpdateNode();
        }

        public override void UpdateNode()
        {
            this.Text = this.DataTypeMapping.DatabaseDataType + " (" + this.DataTypeMapping.ApplicationDataType + ", " + (this.DataTypeMapping.Nullable ? "Null" : "Not Null") + ")";
        }
    }
}
