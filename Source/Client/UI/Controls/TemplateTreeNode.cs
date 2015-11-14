using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.IO;
using QuantumConcepts.CodeGenerator.Client.UI.Forms;
using QuantumConcepts.CodeGenerator.Core;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal sealed class TemplateTreeNode : ProjectSchemaTreeNode
    {
        public event EventHandler GenerateClick;

        public Template Template { get; private set; }

        public TemplateTreeNode(ProjectSchemaTreeNode parent, Template template)
            : base(parent)
        {
            this.Template = template;

            Initialize();
        }

        private void Initialize()
        {
            this.ContextMenu = new ContextMenu();
            this.ContextMenu.MenuItems.Add(new MenuItem("Generate"));
            this.ContextMenu.MenuItems.Add(new MenuItem("-"));
            this.ContextMenu.MenuItems.Add(new MenuItem("Edit..."));
            this.ContextMenu.MenuItems.Add(new MenuItem("Remove"));
            this.ContextMenu.MenuItems[0].Click += new EventHandler(GenerateMenuItem_Click);
            this.ContextMenu.MenuItems[2].Click += new EventHandler(EditMenuItem_Click);
            this.ContextMenu.MenuItems[3].Click += new EventHandler(RemoveMenuItem_Click);

            UpdateNode();
        }

        private void GenerateMenuItem_Click(object sender, EventArgs e)
        {
            OnGenerateClick();
        }

        private void EditMenuItem_Click(object sender, EventArgs e)
        {
            using (EditTemplate dialog = new EditTemplate(this.Template))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    UpdateNode();
            }
        }

        private void RemoveMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Would you like to delete the template and generated file from the file system?", "Remove Template", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try { File.Delete(this.Template.XsltAbsolutePath); }
                catch { }

                try { File.Delete(this.Template.OutputAbsolutePath); }
                catch { }
            }
            else if (result == DialogResult.Cancel)
                return;

            this.Template.ContainingProject.Templates.Remove(this.Template);
            this.ProjectNode.RefreshTemplatesNode();
        }

        public override void UpdateNode()
        {
            this.Text = Path.GetFileNameWithoutExtension(this.Template.XsltAbsolutePath);
        }

        private void OnGenerateClick()
        {
            if (GenerateClick != null)
                GenerateClick(this, EventArgs.Empty);
        }
    }
}
