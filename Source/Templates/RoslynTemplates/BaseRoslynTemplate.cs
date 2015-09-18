using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using QuantumConcepts.CodeGenerator.Core.Templates;
using System.IO;
using PS = QuantumConcepts.CodeGenerator.Core.ProjectSchema;

namespace QuantumConcepts.CodeGenerator.RoslynTemplates {
    public abstract class BaseRoslynTemplate : BaseCodeTemplate {
        public BaseRoslynTemplate(PS.Project project) : base(project) { }

        public override void Render(PS.Template template) {
            CompilationUnitSyntax code = GetCompilationUnit(template);

            using (StreamWriter writer = new StreamWriter("DataObjects_Roslyn_Test.cs"))
                code.WriteTo(writer);
        }

        protected abstract CompilationUnitSyntax GetCompilationUnit(PS.Template template);

        protected new NamespaceDeclarationSyntax GetNamespace(PS.Template template, string name) {
            return SyntaxFactory.NamespaceDeclaration(SyntaxFactory.IdentifierName(base.GetNamespace(template, name)));
        }
    }
}