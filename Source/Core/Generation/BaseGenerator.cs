using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QuantumConcepts.CodeGenerator.Core.Generation
{
    public abstract class BaseGenerator : IGenerator
    {
        public event GenerationStatusEventHandler GenerationStatus;
        public event ItemGenerationStatusEventHandler ItemGenerationStatus;
        public event TemplateGenerationStatusEventHandler TemplateGenerationStatus;

        private CancellationTokenSource CancellationTokenSource { get; set; }

        public BaseGenerator()
        {
            this.CancellationTokenSource = new CancellationTokenSource();
        }

        public abstract Task GenerateAsync();

        public void Cancel()
        {
            this.CancellationTokenSource.Cancel();
        }

        private void OnGenerationStatus(GenerationStatusEventArgs e)
        {
            if (this.GenerationStatus != null)
                GenerationStatus(this, e);
        }

        private void OnTemplateGenerationStatus(TemplateGenerationStatusEventArgs e)
        {
            if (this.TemplateGenerationStatus != null)
                TemplateGenerationStatus(this, e);
        }

        private void OnItemGenerationStatus(ItemGenerationStatusEventArgs e)
        {
            if (this.ItemGenerationStatus != null)
                ItemGenerationStatus(this, e);
        }
    }
}
