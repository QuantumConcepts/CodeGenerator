using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;
using QuantumConcepts.CodeGenerator.Sample.DataAccess;
using QuantumConcepts.CodeGenerator.Sample.Logic;
using QuantumConcepts.CodeGenerator.Sample.Web.WebControls;

namespace QuantumConcepts.CodeGenerator.Sample.Web.Semesters
{
	public partial class Edit : BasePage
	{
        	protected EditSemester EditControl;
			
        	private Semester Semester { get; set; }

	        protected override void OnLoad(EventArgs e)
	        {
	            base.OnLoad(e);
	
				string idString = this.Request.QueryString["ID"];
	            int id;
	            
	            if (int.TryParse(idString, out id))
	            {
	            	this.Semester = SemesterLogic.GetByID(this.DataContext, id);
	
	            	if (!this.IsPostBack)
	                	this.EditControl.DataBind(this.Semester);
				}
	        }
	
	        protected void EditControl_Saved(object sender, Semester obj)
	        {
	            this.Response.Redirect("Default.aspx");
	        }
	
	        protected void EditControl_Cancelled(object sender, EventArgs e)
	        {
	            this.Response.Redirect("Default.aspx");
	        }
	}
}