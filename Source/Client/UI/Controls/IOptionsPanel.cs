using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal delegate void SavedDelegate(object sender, EventArgs e);

    internal interface IOptionsPanel
    {
        event SavedDelegate Saved;

        string Title { get; }

        void SaveOptions();
    }
}
