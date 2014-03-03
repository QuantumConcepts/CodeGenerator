using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using QuantumConcepts.CodeGenerator.Sample.DataAccess;
using QuantumConcepts.CodeGenerator.Sample.Logic;

namespace QuantumConcepts.CodeGenerator.Sample.Web.WebControls
{
	public partial class EditCourse : BaseUserControl
	{
		private const string ViewState_ID = "ID";
		
		public delegate void SavedEventHandler(object sender, Course obj);
		
		public event SavedEventHandler Saved;
		public event EventHandler Cancelled;

		private int? ObjectID { get { return (this.ViewState[ViewState_ID] as int?); } set { this.ViewState[ViewState_ID] = value; } }

		protected DropDownList SemesterField;
		protected DropDownList TeacherField;
		protected TextBox NumberField;
		protected TextBox NameField;
		protected DropDownList CourseStatusField;
		
		protected override void OnLoad(EventArgs e)
		{
			this.SemesterField.DataSource = SemesterLogic.GetAll();
			this.SemesterField.DataBind();
			this.TeacherField.DataSource = TeacherLogic.GetAll();
			this.TeacherField.DataBind();
			this.CourseStatusField.DataSource = Enum.GetValues(typeof(DataObjects.CourseStatus));
			this.CourseStatusField.DataBind();
		}
		
        public void DataBind(Course obj)
        {
            if (obj != null)
            {
                this.ObjectID = obj.ID;
				this.SemesterField.SelectedValue = obj.SemesterID.ToString();
				this.TeacherField.SelectedValue = obj.TeacherID.ToString();
				this.NumberField.Text = obj.Number;
				this.NameField.Text = obj.Name;
				this.CourseStatusField.SelectedValue = obj.Status.ToString();
			}
		}

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.ObjectID.HasValue)
            {
            	Course obj = CourseLogic.GetByID(this.DataContext, this.ObjectID.Value);
		
				obj.SemesterID = int.Parse(this.SemesterField.SelectedValue);
				obj.TeacherID = int.Parse(this.TeacherField.SelectedValue);
				obj.Number = this.NumberField.Text;
				obj.Name = this.NameField.Text;
				obj.Status = (DataObjects.CourseStatus)Enum.Parse(typeof(DataObjects.CourseStatus), this.CourseStatusField.SelectedValue);
            
				this.DataContext.SubmitChanges();
				OnSaved(obj);
            }
            else
            {
            	Course obj = CourseLogic.CreateCourse(this.DataContext, int.Parse(this.SemesterField.SelectedValue), int.Parse(this.TeacherField.SelectedValue), this.NumberField.Text, this.NameField.Text, (DataObjects.CourseStatus)Enum.Parse(typeof(DataObjects.CourseStatus), this.CourseStatusField.SelectedValue));
				
				this.DataContext.SubmitChanges();
				OnSaved(obj);
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            OnCancelled();
        }

        private void OnSaved(Course obj)
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