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
    public partial class EditColumn : Form
    {
        public Property ColumnMapping { get; set; }

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

        public bool ShowInIndex
        {
            get { return showInIndex.Checked; }
            set { showInIndex.Checked = value; }
        }

        public bool ShowInIndexEnabled
        {
            get { return showInIndex.Enabled; }
            set { showInIndex.Enabled = value; }
        }

        public int? IndexOrder
        {
            get { return (indexOrderEnabled.Checked ? (int?)indexOrder.Value : null); }
            set
            {
                indexOrderEnabled.Checked = value.HasValue;

                if (value.HasValue)
                    indexOrder.Value = value.Value;
            }
        }

        public bool IndexOrderEnabled
        {
            get
            {
                return (indexOrderEnabled.Enabled && indexOrder.Enabled);
            }
            set
            {
                indexOrderEnabled.Enabled = value;
                indexOrder.Enabled = value;
            }
        }

        public bool Filterable
        {
            get { return filterable.Checked; }
            set { filterable.Checked = value; }
        }

        public bool FilterableEnabled
        {
            get { return filterable.Enabled; }
            set { filterable.Enabled = value; }
        }

        public bool Sortable
        {
            get { return sortable.Checked; }
            set { sortable.Checked = value; }
        }

        public bool SortableEnabled
        {
            get { return sortable.Enabled; }
            set { sortable.Enabled = value; }
        }

        public string DataType
        {
            get { return dataType.Text; }
            set { dataType.Text = value; }
        }

        public bool DataTypeEnabled
        {
            get { return dataType.Enabled; }
            set { dataType.Enabled = value; }
        }

        public EditColumn()
        {
            InitializeComponent();
        }

        public EditColumn(bool visible, string displayName, bool showInIndex, int? indexOrder, bool filterable, bool sortable, string dataType)
            : this()
        {
            this.Visible = visible;
            this.DisplayName = displayName;
            this.ShowInIndex = showInIndex;
            this.IndexOrder = indexOrder;
            this.Filterable = filterable;
            this.Sortable = sortable;
            this.DataType = dataType;
        }

        private void EditColumn_Load(object sender, EventArgs e)
        {
            this.Text = this.Text.FormatString(this.ColumnMapping);
        }

        private void indexOrderEnabled_CheckedChanged(object sender, EventArgs e)
        {
            indexOrder.Enabled = indexOrderEnabled.Checked;
        }

        private void ok_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
