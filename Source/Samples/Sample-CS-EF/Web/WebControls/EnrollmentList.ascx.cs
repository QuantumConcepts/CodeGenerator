using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using QuantumConcepts.CodeGenerator.Sample.DataAccess;
using QuantumConcepts.CodeGenerator.Sample.Logic;

namespace QuantumConcepts.CodeGenerator.Sample.Web.WebControls
{
	public partial class EnrollmentList : BaseUserControl
	{
        public delegate void EditEventHandler(object sender, Enrollment obj);
        public delegate void DeleteEventHandler(object sender, Enrollment obj);

        public event EventHandler NeedsDataBinding;
        public event EditEventHandler Edit;
        public event DeleteEventHandler Delete;
        
        protected DataGrid Grid;
        
		public bool ShowIDColumn { set { this.Grid.Columns[0].Visible = value; } }
		public bool ShowStudentIDColumn { set { this.Grid.Columns[1].Visible = value; } }
		public bool ShowCourseIDColumn { set { this.Grid.Columns[2].Visible = value; } }
        public bool ShowEditColumn { set { this.Grid.Columns[3].Visible = value; } }
        public bool ShowDeleteColumn { set { this.Grid.Columns[4].Visible = value; } }

        protected void Grid_NeedsDataBinding(object sender, EventArgs e)
        {
            this.OnNeedsDataBinding();
        }

        protected void Grid_ItemCommand(object sender, DataGridCommandEventArgs e)
        {
            if ("Edit".Equals(e.CommandName))
            {
				int primaryKey = (int)this.Grid.DataKeys[e.Item.ItemIndex];

                this.OnEdit(EnrollmentLogic.GetByID(this.DataContext, primaryKey));
            }
            else if ("Delete".Equals(e.CommandName))
            {
				int primaryKey = (int)this.Grid.DataKeys[e.Item.ItemIndex];

                this.OnDelete(EnrollmentLogic.GetByID(this.DataContext, primaryKey));
            }
        }

        public void DataBind(IEnumerable<Enrollment> objects)
        {
            this.Grid.DataSource = objects.ToList();
            this.Grid.DataBind();
        }

        private void OnNeedsDataBinding()
        {
            if (this.NeedsDataBinding != null)
                this.NeedsDataBinding(this, EventArgs.Empty);
        }

        private void OnEdit(Enrollment obj)
        {
            if (this.Edit != null)
                this.Edit(this, obj);
        }

        private void OnDelete(Enrollment obj)
        {
            if (this.Delete != null)
                this.Delete(this, obj);
        }
	}
}