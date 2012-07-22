using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using QuantumConcepts.CodeGenerator.Sample.DataAccess;
using QuantumConcepts.CodeGenerator.Sample.Logic;
using QuantumConcepts.CodeGenerator.Sample.Web.WebControls;

namespace QuantumConcepts.CodeGenerator.Sample.Web.Students
{
	public partial class Default : BasePage
	{
        protected StudentList ListControl;
        
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!this.IsPostBack)
                BindList();
        }

        protected void ListControl_NeedsDataBinding(object sender, EventArgs e)
        {
            BindList();
        }

        protected void ListControl_Edit(object sender, Student obj)
        {
            Response.Redirect(string.Format("Edit.aspx?ID={0}", obj.ID));
        }

        protected void ListControl_Delete(object sender, Student obj)
        {
            StudentLogic.DeleteStudent(this.DataContext, obj.ID);
            this.DataContext.SubmitChanges();
            BindList();
        }

        private void BindList()
        {
            ListControl.DataBind(StudentLogic.GetAll().ToList());
        }
    }
}