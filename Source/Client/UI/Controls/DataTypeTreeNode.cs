using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal sealed class DataTypeTreeNode : ProjectSchemaTreeNode
    {
        private DataTypeMapping _dataTypeMapping;

        public DataTypeMapping DataTypeMapping { get { return _dataTypeMapping; } }

        public DataTypeTreeNode(DataTypeMapping dataTypeMapping)
        {
            _dataTypeMapping = dataTypeMapping;

            UpdateNode();
        }

        public override void UpdateNode()
        {
            this.Text = _dataTypeMapping.DatabaseDataType + " (" + _dataTypeMapping.ApplicationDataType + ", " + (_dataTypeMapping.Nullable ? "Null" : "Not Null") + ")";
        }
    }
}
