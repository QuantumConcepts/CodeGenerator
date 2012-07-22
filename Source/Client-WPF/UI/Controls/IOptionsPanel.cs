using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.DAOGenerator.Core.ProjectSchema;

namespace QuantumConcepts.DAOGenerator.Client.UI.Controls
{
    public delegate void SavedDelegate(object sender, EventArgs e);

    public interface IOptionsPanel
    {
        event SavedDelegate Saved;

        string Title { get; }
    }
}
