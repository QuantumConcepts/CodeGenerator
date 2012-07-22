using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.CodeGenerator.Client.UI.Forms;

namespace QuantumConcepts.CodeGenerator.Client.Plugins
{
    public interface IPlugin
    {
        string Name { get; }
        string Description { get; }
        string Publisher { get; }
        string PublisherUri { get; }

        void InstallUI(Main main);
    }
}
