using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using QuantumConcepts.CodeGenerator.Sample.DataAccess;

namespace QuantumConcepts.CodeGenerator.Sample.Web.WebControls
{
    public class BasePage : Page
    {
        public SampleObjectContext DataContext { get; private set; }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.DataContext = new SampleObjectContext();
        }
    }
}