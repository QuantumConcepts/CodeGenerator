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
    internal partial class UniqueIndexOptions : UserControl, IOptionsPanel
    {
        public event SavedDelegate Saved;

        private bool _isLoaded = false;

        private UniqueIndexMapping UniqueIndexMapping { get; set; }

        public string Title { get { return this.UniqueIndexMapping.UniqueIndexName; } }

        public int SelectedTabIndex
        {
            get { return tabControl.SelectedIndex; }
            set
            {
                if (value < tabControl.TabPages.Count)
                    tabControl.SelectedIndex = value;
            }
        }

        public UniqueIndexOptions(UniqueIndexMapping UniqueIndexMapping)
        {
            InitializeComponent();

            this.UniqueIndexMapping = UniqueIndexMapping;
        }

        private void ProjectOptions_Load(object sender, EventArgs e)
        {
            this.editAnnotations.Annotations = this.UniqueIndexMapping.Annotations;
            this.editAttributes.Attributes = this.UniqueIndexMapping.Attributes;
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

            this.UniqueIndexMapping.Annotations = this.editAnnotations.Annotations.ToList();
            this.UniqueIndexMapping.Attributes = this.editAttributes.Attributes.ToList();

            OnSaved();
        }

        protected void OnSaved()
        {
            if (Saved != null)
                Saved(this, EventArgs.Empty);
        }
    }
}
