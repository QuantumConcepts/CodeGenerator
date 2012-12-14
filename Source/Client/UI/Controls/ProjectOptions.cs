using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal partial class ProjectOptions : UserControl, IOptionsPanel
    {
        public event SavedDelegate Saved;

        private bool _isLoaded = false;

        private Project Project { get; set; }

        public string Title { get { return "Project"; } }
        
        public int SelectedTabIndex
        {
            get { return tabControl.SelectedIndex; }
            set
            {
                if (value < tabControl.TabPages.Count)
                    tabControl.SelectedIndex = value;
            }
        }

        public ProjectOptions(Project project)
        {
            InitializeComponent();

            this.Project = project;
        }

        private void ProjectOptions_Load(object sender, EventArgs e)
        {
            this.editAttributes.Attributes = this.Project.Attributes;
            _isLoaded = true;
        }

        private void PropertyChanged(object sender, EventArgs e)
        {
            SaveOptions();
        }

        public void SaveOptions()
        {
            if (!_isLoaded)
                return;

            this.Project.Attributes = this.editAttributes.Attributes.ToList();

            OnSaved();
        }

        protected void OnSaved()
        {
            if (Saved != null)
                Saved(this, EventArgs.Empty);
        }
    }
}
