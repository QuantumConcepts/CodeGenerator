using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PS = QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.Collections.Generic;
using System.Linq;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;

namespace QuantumConcepts.CodeGenerator.RoslynTemplates {
    public class DataObjects : BaseRoslynTemplate {
        public DataObjects(PS.Project project) : base(project) { }

        protected override CompilationUnitSyntax GetCompilationUnit(PS.Template template) {
            CompilationUnitSyntax code = CompilationUnit();

            code = code.AddMembers(GetNamespace(template, "DataObjects"));

            CreateUsings(template, code);
            CreateClasses(template, code);

            return code;
        }

        private void CreateUsings(PS.Template template, CompilationUnitSyntax code) {
            code.AddUsings(
                UsingDirective(ParseName("System")),
                UsingDirective(ParseName("System.Collections.Generic")),
                UsingDirective(ParseName("System.Runtime.Serialization")));

            foreach (PS.Attribute<PS.Template> attr in template.Attributes.Where(o => "Using".Equals(o.Key)))
                code.AddUsings(UsingDirective(ParseName(attr.Value)));
        }

        private void CreateClasses(PS.Template template, CompilationUnitSyntax code) {
            foreach (PS.TableMapping table in this.Project.TableMappings.Where(o => !o.Exclude))
                CreateClass(template, table, code);
        }

        private void CreateClass(PS.Template template, PS.TableMapping table, CompilationUnitSyntax code) {
            ClassDeclarationSyntax cls = ClassDeclaration(table.ClassName);
            IEnumerable<PS.ColumnMapping> columns = table.ColumnMappings.Where(o => !o.Exclude);

            // Create the class.
            cls.AddModifiers(Token(SyntaxKind.PartialKeyword));
            cls.AddAttributeLists(AttributeList().AddAttributes(Attribute(ParseName("DataContract"))));

            foreach (PS.ColumnMapping column in columns) {
                PropertyDeclarationSyntax property = PropertyDeclaration(ParseTypeName(column.DataType), column.FieldName);

                CreateComments(column, property.GetLeadingTrivia());
                property.AddAttributeLists(AttributeList().AddAttributes(Attribute(ParseName("DataMember"))));
                property.Modifiers.Add(Token(SyntaxKind.PublicKeyword));

                cls.Members.Add(property);
            }

            code.AddMembers(cls);
        }

        private void CreateComments<T>(T element, SyntaxTriviaList comments)
            where T : PS.IProjectSchemaElement, PS.IHasAnnotations<T> {
            PS.Annotation<T> summary = element.Annotations.SingleOrDefault(o => "summary".Equals(o.Type));

            if (summary != null)
                comments.Add(SyntaxFactory.Comment($"<summary>{summary.Text}</summary>"));
        }
    }
}
