using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using QuantumConcepts.CodeGenerator.Sample.DataAccess;
using QuantumConcepts.CodeGenerator.Sample.Logic;

namespace QuantumConcepts.CodeGenerator.Sample.Web.WebControls
{
	public partial class EditEnrollment : BaseUserControl
	{
		private const string ViewState_ID = "ID";
		
		public delegate void SavedEventHandler(object sender, Enrollment obj);
		
		public event SavedEventHandler Saved;
		public event EventHandler Cancelled;

		private int? ObjectID { get { return (this.ViewState[ViewState_ID] as int?); } set { this.ViewState[ViewState_ID] = value; } }

		protected DropDownList StudentField;
		protected DropDownList CourseField;
		
		protected override void OnLoad(EventArgs e)
		{
			this.StudentField.DataSource = StudentLogic.GetAll();
			this.StudentField.DataBind();
			this.CourseField.DataSource = CourseLogic.GetAll();
			this.CourseField.DataBind();
		}
		
        public void DataBind(Enrollment obj)
        {
            if (obj != null)
            {
                this.ObjectID = obj.ID;
				this.StudentField.SelectedValue = obj.StudentID.ToString();
				this.CourseField.SelectedValue = obj.CourseID.ToString();
			}
		}

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.ObjectID.HasValue)
            {
            	Enrollment obj = EnrollmentLogic.GetByID(this.DataContext, this.ObjectID.Value);
		
				obj.StudentID = int.Parse(this.StudentField.SelectedValue);
				obj.CourseID = int.Parse(this.CourseField.SelectedValue);
            
				this.DataContext.AcceptAllChanges();
				OnSaved(obj);
            }
            else
            {
            	Enrollment obj = EnrollmentLogic.CreateEnrollment(this.DataContext, int.Parse(this.StudentField.SelectedValue), int.Parse(this.CourseField.SelectedValue));
				
				this.DataContext.AcceptAllChanges();
				OnSaved(obj);
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            OnCancelled();
        }

        private void OnSaved(Enrollment obj)
        {
            if (this.Saved != null)
                this.Saved(this, obj);
        }

        private void OnCancelled()
        {
            if (this.Cancelled != null)
                this.Cancelled(this, EventArgs.Empty);
        }
    }
}