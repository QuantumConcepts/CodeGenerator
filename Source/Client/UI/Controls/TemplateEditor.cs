using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Forms.UI.Controls;
using System.IO;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal partial class TemplateEditor : UserControl
    {
        public new event EventHandler TextChanged;

        private TextEditor Editor { get; set; }

        public Template Template { get; set; }
        public bool UnsavedChanges { get; private set; }

        public TemplateEditor(Template template)
        {
            InitializeComponent();

            this.Template = template;
        }

        private void TemplateEditor_Load(object sender, EventArgs e)
        {
            this.Editor = new TextEditor();
            elementHost.Child = this.Editor;
            this.Editor.ShowLineNumbers = true;
            this.Editor.Load(this.Template.XsltAbsolutePath);
            this.Editor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("XML");
            this.Editor.FontFamily = new System.Windows.Media.FontFamily("Courier New");
            this.Editor.TextChanged += new EventHandler(Editor_TextChanged);
        }

        void Editor_TextChanged(object sender, EventArgs e)
        {
            this.UnsavedChanges = true;
            OnTextChanged();
        }

        public void Save()
        {
            this.Editor.Save(Template.XsltAbsolutePath);
            this.UnsavedChanges = false;
        }

        private void OnTextChanged()
        {
            if (TextChanged != null)
                TextChanged(this, EventArgs.Empty);
        }
    }
}
