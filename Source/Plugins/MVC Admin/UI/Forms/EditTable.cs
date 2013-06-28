using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Extensions;

namespace QuantumConcepts.CodeGenerator.Plugins.MvcAdmin.UI.Forms
{
    public partial class EditTable : Form
    {
        public TableMapping TableMapping { get; set; }

        public bool Visible
        {
            get { return visible.Checked; }
            set { visible.Checked = value; }
        }

        public bool VisibleEnabled
        {
            get { return visible.Enabled; }
            set { visible.Enabled = value; }
        }

        public string DisplayName
        {
            get { return displayName.Text; }
            set { displayName.Text = value; }
        }

        public bool DisplayNameEnabled
        {
            get { return displayName.Enabled; }
            set { displayName.Enabled = value; }
        }

        public string PluralDisplayName
        {
            get { return pluralDisplayName.Text; }
            set { pluralDisplayName.Text = value; }
        }

        public bool PluralDisplayNameEnabled
        {
            get { return pluralDisplayName.Enabled; }
            set { pluralDisplayName.Enabled = value; }
        }

        public bool Deletable
        {
            get { return deletable.Checked; }
            set { deletable.Checked = value; }
        }

        public bool DeletableEnabled
        {
            get { return deletable.Enabled; }
            set { deletable.Enabled = value; }
        }

        public EditTable()
        {
            InitializeComponent();
        }

        public EditTable(bool visible, bool editable, string displayName, string pluralDisplayName)
            : this()
        {
            this.Visible = visible;
            this.Deletable = editable;
            this.DisplayName = displayName;
            this.PluralDisplayName = pluralDisplayName;
        }

        private void EditTable_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.FormatString(this.TableMapping);
        }

        private void ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
