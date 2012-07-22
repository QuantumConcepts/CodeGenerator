using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using QuantumConcepts.CodeGenerator.Sample.DataAccess;
using QuantumConcepts.CodeGenerator.Sample.Logic;
using QuantumConcepts.CodeGenerator.Sample.Web.WebControls;

namespace QuantumConcepts.CodeGenerator.Sample.Web.Teachers
{
	public partial class Edit : BasePage
	{
        	protected EditTeacher EditControl;
			
        	private Teacher Teacher { get; set; }

	        protected override void OnLoad(EventArgs e)
	        {
	            base.OnLoad(e);
	
				string idString = this.Request.QueryString["ID"];
	            int id;
	            
	            if (int.TryParse(idString, out id))
	            {
	            	this.Teacher = TeacherLogic.GetByID(this.DataContext, id);
	
	            	if (!this.IsPostBack)
	                	this.EditControl.DataBind(this.Teacher);
				}
	        }
	
	        protected void EditControl_Saved(object sender, Teacher obj)
	        {
	            this.Response.Redirect("Default.aspx");
	        }
	
	        protected void EditControl_Cancelled(object sender, EventArgs e)
	        {
	            this.Response.Redirect("Default.aspx");
	        }
	}
}