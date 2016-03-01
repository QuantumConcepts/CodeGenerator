using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using QuantumConcepts.CodeGenerator.Sample.DataAccess;

namespace QuantumConcepts.CodeGenerator.Sample.Web.WebControls
{
    public class BaseUserControl : UserControl
    {
        public SampleDataContext DataContext { get { return this.Page.DataContext; } }
        public new BasePage Page { get { return (BasePage)base.Page; } }
    }
}