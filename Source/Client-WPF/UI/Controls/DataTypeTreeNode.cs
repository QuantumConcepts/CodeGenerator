using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.DAOGenerator.Core.ProjectSchema;

namespace QuantumConcepts.DAOGenerator.Client.UI.Controls
{
    public class DataTypeTreeNode : ProjectSchemaNode
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
            this.Header = _dataTypeMapping.DatabaseDataType + " (" + _dataTypeMapping.ApplicationDataType + ", " + (_dataTypeMapping.Nullable ? "Null" : "Not Null") + ")";
        }
    }
}
