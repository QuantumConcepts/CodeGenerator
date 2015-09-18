using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Extensions;
using System.Linq;

namespace QuantumConcepts.CodeGenerator.Core.Templates {
    public abstract class BaseCodeTemplate {
        public Project Project { get; private set; }

        public BaseCodeTemplate(Project project) {
            this.Project = project;
        }

        public abstract void Render(Template template);

        protected virtual string GetNamespace(Template template, string name) {
            Attribute<Template> attr = template.Attributes.SingleOrDefault(o => "Namespace".Equals(o.Key));
            string fullNamespace = (
                attr != null
                    ? attr.Value
                    : (!this.Project.RootNamespace.IsNullOrEmpty()
                        ? "{0}.{1}".FormatString(this.Project.RootNamespace, name)
                        : name));

            return fullNamespace;
        }
    }
}
