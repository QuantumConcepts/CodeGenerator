﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    public delegate void SavedDelegate(object sender, EventArgs e);

    public interface IOptionsPanel
    {
        event SavedDelegate Saved;

        string Title { get; }
        int SelectedTabIndex { get; set; }

        void SaveOptions();
    }
}
