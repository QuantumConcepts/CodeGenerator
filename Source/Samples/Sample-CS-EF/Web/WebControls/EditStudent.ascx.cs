using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using QuantumConcepts.CodeGenerator.Sample.DataAccess;
using QuantumConcepts.CodeGenerator.Sample.Logic;

namespace QuantumConcepts.CodeGenerator.Sample.Web.WebControls
{
	public partial class EditStudent : BaseUserControl
	{
		private const string ViewState_ID = "ID";
		
		public delegate void SavedEventHandler(object sender, Student obj);
		
		public event SavedEventHandler Saved;
		public event EventHandler Cancelled;

		private int? ObjectID { get { return (this.ViewState[ViewState_ID] as int?); } set { this.ViewState[ViewState_ID] = value; } }

		protected DropDownList MajorField;
		protected TextBox SSNField;
		protected TextBox FirstNameField;
		protected TextBox LastNameField;
		protected CheckBox ActiveField;
		
		protected override void OnLoad(EventArgs e)
		{
			this.MajorField.DataSource = MajorLogic.GetAll();
			this.MajorField.DataBind();
		}
		
        public void DataBind(Student obj)
        {
            if (obj != null)
            {
                this.ObjectID = obj.ID;
				this.MajorField.SelectedValue = obj.MajorID.ToString();
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
            	Student obj = StudentLogic.GetByID(this.DataContext, this.ObjectID.Value);
		
				obj.MajorID = int.Parse(this.MajorField.SelectedValue);
				obj.SSN = this.SSNField.Text;
				obj.FirstName = this.FirstNameField.Text;
				obj.LastName = this.LastNameField.Text;
				obj.Active = this.ActiveField.Checked;
            
				this.DataContext.AcceptAllChanges();
				OnSaved(obj);
            }
            else
            {
            	Student obj = StudentLogic.CreateStudent(this.DataContext, int.Parse(this.MajorField.SelectedValue), this.SSNField.Text, this.FirstNameField.Text, this.LastNameField.Text, this.ActiveField.Checked);
				
				this.DataContext.AcceptAllChanges();
				OnSaved(obj);
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            OnCancelled();
        }

        private void OnSaved(Student obj)
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