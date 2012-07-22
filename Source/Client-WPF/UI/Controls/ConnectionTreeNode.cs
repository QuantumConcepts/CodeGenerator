using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.Common.Utils;
using QuantumConcepts.DAOGenerator.Core.ProjectSchema;

namespace QuantumConcepts.DAOGenerator.Client.UI.Controls
{
    public class ConnectionTreeNode : ProjectSchemaNode
    {
        private Connection _connection;

        public Connection Connection { get { return _connection; } }

        public ConnectionTreeNode(Connection connection)
        {
            _connection = connection;

            UpdateNode();
        }

        public override void UpdateNode()
        {
            this.Header = _connection.Host + " (" + _connection.DatabaseType.GetDescription() + ")";
        }
    }
}
