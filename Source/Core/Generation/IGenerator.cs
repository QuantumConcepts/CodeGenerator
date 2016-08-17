using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantumConcepts.CodeGenerator.Core.Generation
{
    public interface IGenerator
    {
        event GenerationStatusEventHandler GenerationStatus;
        event TemplateGenerationStatusEventHandler TemplateGenerationStatus;
        event ItemGenerationStatusEventHandler ItemGenerationStatus;

        Task GenerateAsync();
    }
}
