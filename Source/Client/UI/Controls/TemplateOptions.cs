﻿using System;
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
    internal partial class TemplateOptions : UserControl, IOptionsPanel
    {
        public event SavedDelegate Saved;

        private bool _isLoaded = false;

        private Template Template { get; set; }

        public string Title { get { return this.Template.Name; } }

        public TemplateOptions(Template Template)
        {
            InitializeComponent();

            this.Template = Template;
        }

        private void ProjectOptions_Load(object sender, EventArgs e)
        {
            this.editAttributes.Attributes = this.Template.Attributes;
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

            this.Template.Attributes = this.editAttributes.Attributes.ToList();

            OnSaved();
        }

        protected void OnSaved()
        {
            if (Saved != null)
                Saved(this, EventArgs.Empty);
        }
    }
}