using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal sealed class TableOrViewTreeNode : ProjectSchemaTreeNode
    {
        public TableMapping TableMapping { get; private set; }
        public ViewMapping ViewMapping { get { return (this.TableMapping as ViewMapping); } }

        public TableOrViewTreeNode(ProjectSchemaTreeNode parent, TableMapping tableOrViewMapping)
            : base(parent)
        {
            this.TableMapping = tableOrViewMapping;

            Initialize();
        }

        private void Initialize()
        {
            TreeNode columnsNode = new TreeNode("Columns");
            bool showExcludedItems = this.ProjectNode.Project.UserSettings.ShowExcludedItems;

            this.Nodes.Add(columnsNode);

            foreach (var columnMapping in this.TableMapping.ColumnMappings)
            {
                if (!columnMapping.Exclude || showExcludedItems)
                {
                    ColumnTreeNode node = new ColumnTreeNode(this, columnMapping);

                    columnsNode.Nodes.Add(node);
                    Application.DoEvents();
                }
            }

            if (this.TableMapping.UniqueIndexMappings.Count > 0)
            {
                TreeNode uniqueIndicesNode = new TreeNode("Unique Indices");

                this.Nodes.Add(uniqueIndicesNode);

                foreach (var uniqueIndexMapping in this.TableMapping.UniqueIndexMappings)
                {
                    if (!uniqueIndexMapping.Exclude || showExcludedItems)
                    {
                        UniqueIndexTreeNode node = new UniqueIndexTreeNode(this, uniqueIndexMapping);

                        uniqueIndicesNode.Nodes.Add(node);
                        Application.DoEvents();
                    }
                }
            }

            this.ContextMenu = new ContextMenu();
            this.ContextMenu.MenuItems.Add(new MenuItem("Exclude From Project"));
            this.ContextMenu.MenuItems[0].Checked = this.TableMapping.Exclude;
            this.ContextMenu.MenuItems[0].Click += new EventHandler(ExcludeFromProjectMenuItem_Click);

            UpdateNode();
        }

        public override void UpdateNode()
        {
            if (this.TableMapping.Exclude && !this.ProjectNode.Project.UserSettings.ShowExcludedItems)
                Remove();
            else
            {
                this.Text = this.TableMapping.TableName;

                if (!string.IsNullOrEmpty(this.TableMapping.ClassName) && !this.TableMapping.TableName.Equals(this.TableMapping.ClassName))
                    this.Text += " (" + this.TableMapping.ClassName + ")";

                this.ForeColor = (this.TableMapping.Exclude ? Color.LightGray : Color.Black);
            }
        }

        void ExcludeFromProjectMenuItem_Click(object sender, EventArgs e)
        {
            MenuItem menuItem = (MenuItem)sender;

            menuItem.Checked = !menuItem.Checked;
            this.TableMapping.Exclude = menuItem.Checked;

            UpdateNode();
        }
    }
}
