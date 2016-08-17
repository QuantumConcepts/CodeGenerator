using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.Collections.Generic;
using System.Linq;

namespace QuantumConcepts.CodeGenerator.Core.Generation
{
    public class TemplateOutputMap : Dictionary<Template, List<TemplateOutputDefinitionFilenameResult>>
    {
        public TemplateOutputMap() { }
        public TemplateOutputMap(IEnumerable<Template> templates)
        {
            foreach (var item in templates.ToDictionary(o => o, o => o.GetOutputFilenames()))
                Add(item.Key, item.Value);
        }
    }
}
