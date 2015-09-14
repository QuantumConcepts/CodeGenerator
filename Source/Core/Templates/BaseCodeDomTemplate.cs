using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.Common.Extensions;

namespace QuantumConcepts.CodeGenerator.Core.Templates {
    public abstract class BaseCodeDomTemplate {
        public Project Project { get; private set; }

        public BaseCodeDomTemplate(Project project) {
            this.Project = project;
        }

        public abstract CodeCompileUnit Render(Template template);

        protected CodeNamespace GetNamespace(Template template, string name) {
            Attribute<Template> attr = template.Attributes.SingleOrDefault(o => "Namespace".Equals(o.Key));
            string namespaceName = (
                attr != null
                    ? attr.Value
                    : (!this.Project.RootNamespace.IsNullOrEmpty()
                        ? "{0}.{1}".FormatString(this.Project.RootNamespace, name)
                        : name));

            return new CodeNamespace(namespaceName);
        }
    }
}
