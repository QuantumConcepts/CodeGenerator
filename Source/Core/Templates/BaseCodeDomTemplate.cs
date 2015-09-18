using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.Common.Extensions;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.IO;

namespace QuantumConcepts.CodeGenerator.Core.Templates {
    public abstract class BaseCodeDomTemplate : BaseCodeTemplate {
        public BaseCodeDomTemplate(Project project) : base(project) { }

        public override void Render(Template template) {
            CodeCompileUnit code = GetCodeCompileUnit(template);
            CodeDomProvider provider = new CSharpCodeProvider();
            CodeGeneratorOptions options = new CodeGeneratorOptions() {
                VerbatimOrder = true
            };

            using (StreamWriter writer = new StreamWriter("DataObjects_CodeDom_Test.cs"))
                provider.GenerateCodeFromCompileUnit(code, writer, options);
        }

        protected abstract CodeCompileUnit GetCodeCompileUnit(Template template);

        protected new CodeNamespace GetNamespace(Template template, string name) {
            return new CodeNamespace(base.GetNamespace(template, name));
        }
    }
}