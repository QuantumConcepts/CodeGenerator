using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.CodeGenerator.Client.Plugins;
using QuantumConcepts.CodeGenerator.Client.UI.Forms;
using System.Windows.Forms;

namespace QuantumConcepts.CodeGenerator.Plugins.MvcAdmin
{
    public class MVC3AdminPlugin : IPlugin
    {
        public string Name { get { return "MVC Admin"; } }
        public string Description { get { return "Generates administrative controllers, models and views using the Microsoft ASP.NET MVC framework and the Razor engine."; } }
        public string Publisher { get { return "Quantum Concepts"; } }
        public string PublisherUri { get { return "http://www.quantumconceptscorp.com"; } }

        public void InstallUI(Main main)
        {
            main.ToolsMenu.DropDownItems.Add(new ToolStripSeparator());
            main.ToolsMenu.DropDownItems.Add(new ToolStripMenuItem(this.Name, null, new EventHandler((o, e) =>
            {
                using (Form form = new UI.Forms.Main())
                {
                    form.ShowDialog();
                }
            })));
        }
    }
}
