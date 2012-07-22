using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI.HtmlControls;

namespace QuantumConcepts.CodeGenerator.Sample.Web
{
    public partial class ViewCode : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string path = Request.QueryString["Path"];

            if (!string.IsNullOrEmpty(path))
            {
                string fullPath = Server.MapPath(string.Format("~/App_Resources/Source/{0}", path));

                this.Title = string.Format("View Code for {0}", path);
                pathLiteral.Text = path;

                if (File.Exists(fullPath))
                {
                    HtmlGenericControl pre = new HtmlGenericControl("pre");

                    pre.Attributes.Add("class", string.Format("brush: {0}", GetBrush(Path.GetExtension(fullPath).Substring(1))));
                    pre.InnerText = File.ReadAllText(fullPath);

                    codePlaceHolder.Controls.Add(pre);
                }
            }
        }

        private string GetBrush(string extension)
        {
            if ("ascx".Equals(extension))
                return "xml";
            else if ("aspx".Equals(extension))
                return "xml";
            else if ("cs".Equals(extension))
                return "csharp";

            throw new ArgumentOutOfRangeException("extension");
        }
    }
}