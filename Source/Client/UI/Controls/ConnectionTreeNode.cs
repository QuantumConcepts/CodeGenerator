using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.Common.Utils;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.CodeGenerator.Core.Data;
using QuantumConcepts.CodeGenerator.Core.Utils;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal sealed class ConnectionTreeNode : ProjectSchemaTreeNode
    {
        public Connection Connection { get; private set; }

        public ConnectionTreeNode(Connection connection)
        {
            this.Connection = connection;

            Initialize();
        }

        private void Initialize()
        {
            this.ContextMenu = new ContextMenu();
            this.ContextMenu.MenuItems.Add(new MenuItem("Test..."));
            this.ContextMenu.MenuItems[0].Click += new EventHandler(TestMenuItem_Click);

            UpdateNode();
        }

        private void TestMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                this.Connection.Validate();
            }
            catch (Exception ex)
            {
                MessageBox.Show("The connection to the data source could not be established. The following error was returned:" + TextUtil.GetExceptionText(ex), "Connection Failed", MessageBoxButtons.OK);
                return;
            }

            MessageBox.Show("Connection test succeeded!");
        }

        public override void UpdateNode()
        {
            this.Text = "Default Connection";
        }
    }
}
