using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using QuantumConcepts.CodeGenerator.Sample.DataAccess;
using QuantumConcepts.CodeGenerator.Sample.Logic;

namespace QuantumConcepts.CodeGenerator.Sample.Web.WebControls
{
	public partial class EditMajor : BaseUserControl
	{
		private const string ViewState_ID = "ID";
		
		public delegate void SavedEventHandler(object sender, Major obj);
		
		public event SavedEventHandler Saved;
		public event EventHandler Cancelled;

		private int? ObjectID { get { return (this.ViewState[ViewState_ID] as int?); } set { this.ViewState[ViewState_ID] = value; } }

		protected TextBox NameField;
		
		protected override void OnLoad(EventArgs e)
		{
		}
		
        public void DataBind(Major obj)
        {
            if (obj != null)
            {
                this.ObjectID = obj.ID;
				this.NameField.Text = obj.Name;
			}
		}

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            if (this.ObjectID.HasValue)
            {
            	Major obj = MajorLogic.GetByID(this.DataContext, this.ObjectID.Value);
		
				obj.Name = this.NameField.Text;
            
				this.DataContext.AcceptAllChanges();
				OnSaved(obj);
            }
            else
            {
            	Major obj = MajorLogic.CreateMajor(this.DataContext, this.NameField.Text);
				
				this.DataContext.AcceptAllChanges();
				OnSaved(obj);
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            OnCancelled();
        }

        private void OnSaved(Major obj)
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