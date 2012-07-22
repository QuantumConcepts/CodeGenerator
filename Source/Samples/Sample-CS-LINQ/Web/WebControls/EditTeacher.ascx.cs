using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using QuantumConcepts.CodeGenerator.Sample.DataAccess;
using QuantumConcepts.CodeGenerator.Sample.Logic;

namespace QuantumConcepts.CodeGenerator.Sample.Web.WebControls
{
	public partial class EditTeacher : BaseUserControl
	{
		private const string ViewState_ID = "ID";
		
		public delegate void SavedEventHandler(object sender, Teacher obj);
		
		public event SavedEventHandler Saved;
		public event EventHandler Cancelled;

		private int? ObjectID { get { return (this.ViewState[ViewState_ID] as int?); } set { this.ViewState[ViewState_ID] = value; } }

		protected TextBox SSNField;
		protected TextBox FirstNameField;
		protected TextBox LastNameField;
		protected CheckBox ActiveField;
		
		protected override void OnLoad(EventArgs e)
		{
		}
		
        public void DataBind(Teacher obj)
        {
            if (obj != null)
            {
                this.ObjectID = obj.ID;
				this.SSNField.Text = obj.SSN;
				this.FirstNameField.Text = obj.FirstName;
				this.LastNameField.Text = obj.LastName;
				this.ActiveField.Checked = obj.Active;
			}
		}

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.ObjectID.HasValue)
            {
            	Teacher obj = TeacherLogic.GetByID(this.DataContext, this.ObjectID.Value);
		
				obj.SSN = this.SSNField.Text;
				obj.FirstName = this.FirstNameField.Text;
				obj.LastName = this.LastNameField.Text;
				obj.Active = this.ActiveField.Checked;
            
				this.DataContext.SubmitChanges();
				OnSaved(obj);
            }
            else
            {
            	Teacher obj = TeacherLogic.CreateTeacher(this.DataContext, this.SSNField.Text, this.FirstNameField.Text, this.LastNameField.Text, this.ActiveField.Checked);
				
				this.DataContext.SubmitChanges();
				OnSaved(obj);
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            OnCancelled();
        }

        private void OnSaved(Teacher obj)
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