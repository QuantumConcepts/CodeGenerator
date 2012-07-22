using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using QuantumConcepts.CodeGenerator.Sample.DataAccess;
using QuantumConcepts.CodeGenerator.Sample.Logic;

namespace QuantumConcepts.CodeGenerator.Sample.Web.WebControls
{
	public partial class EditSemester : BaseUserControl
	{
		private const string ViewState_ID = "ID";
		
		public delegate void SavedEventHandler(object sender, Semester obj);
		
		public event SavedEventHandler Saved;
		public event EventHandler Cancelled;

		private int? ObjectID { get { return (this.ViewState[ViewState_ID] as int?); } set { this.ViewState[ViewState_ID] = value; } }

		protected Calendar BeginField;
		protected Calendar EndField;
		protected TextBox NameField;
		
		protected override void OnLoad(EventArgs e)
		{
		}
		
        public void DataBind(Semester obj)
        {
            if (obj != null)
            {
                this.ObjectID = obj.ID;
				this.BeginField.SelectedDate = obj.Begin;
				this.EndField.SelectedDate = obj.End;
				this.NameField.Text = obj.Name;
			}
		}

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.ObjectID.HasValue)
            {
            	Semester obj = SemesterLogic.GetByID(this.DataContext, this.ObjectID.Value);
		
				obj.Begin = this.BeginField.SelectedDate;
				obj.End = this.EndField.SelectedDate;
				obj.Name = this.NameField.Text;
            
				this.DataContext.SubmitChanges();
				OnSaved(obj);
            }
            else
            {
            	Semester obj = SemesterLogic.CreateSemester(this.DataContext, this.BeginField.SelectedDate, this.EndField.SelectedDate, this.NameField.Text);
				
				this.DataContext.SubmitChanges();
				OnSaved(obj);
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            OnCancelled();
        }

        private void OnSaved(Semester obj)
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