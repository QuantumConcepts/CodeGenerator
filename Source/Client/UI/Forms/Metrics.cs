using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.CodeGenerator.Core.Utils;
using System.IO;
using QuantumConcepts.Common.Forms.UI;
using QuantumConcepts.Common.Extensions;

namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    internal partial class Metrics : Form
    {
        public Metrics()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        
            using (new Wait())
            {
                List<TemplateMetrics> templateMetrics = Tools.GetMetricsForTemplates(ProjectContext.Project.Templates.ToArray());

                foreach (TemplateMetrics item in templateMetrics.OrderByDescending(o => o.TotalFileSize))
                {
                    lineCountListView.Items.Add(new ListViewItem(new string[] 
                    {
                        item.Template.Name, 
                        item.FileCount.ToString("N0"), 
                        item.TotalFileSize.ToFileSize(),
                        item.CharacterCount.ToString("N0"), 
                        item.LineCount.ToString("N0") 
                    }));
                }

                lineCountListView.Items.Add(new ListViewItem(new string[] 
                {
                    "Total", 
                    templateMetrics.Sum(i=>i.FileCount).ToString("N0"), 
                    templateMetrics.Sum(i=>i.TotalFileSize).ToFileSize(),
                    templateMetrics.Sum(i=>i.CharacterCount).ToString("N0"), 
                    templateMetrics.Sum(i=>i.LineCount).ToString("N0") 
                })
                {
                    Font = new Font(this.Font, FontStyle.Bold)
                });
            }
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
