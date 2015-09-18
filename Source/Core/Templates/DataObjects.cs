using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.CodeDom;
using QuantumConcepts.Common.Extensions;

namespace QuantumConcepts.CodeGenerator.Core.Templates {
    public class DataObjects : BaseCodeDomTemplate {
        public DataObjects(Project project) : base(project) { }

        protected override CodeCompileUnit GetCodeCompileUnit(Template template) {
            CodeCompileUnit code = new CodeCompileUnit();
            CodeNamespace ns = GetNamespace(template, "DataObjects");

            code.Namespaces.Add(ns);
            CreateUsings(template, ns);
            CreateClasses(template, ns);

            return code;
        }

        private void CreateUsings(Template template, CodeNamespace ns) {
            ns.Imports.Add(new CodeNamespaceImport("System"));
            ns.Imports.Add(new CodeNamespaceImport("System.Collections.Generic"));
            ns.Imports.Add(new CodeNamespaceImport("System.Runtime.Serialization"));

            foreach (Attribute<Template> attr in template.Attributes.Where(o => "Using".Equals(o.Key)))
                ns.Imports.Add(new CodeNamespaceImport(attr.Value));
        }

        private void CreateClasses(Template template, CodeNamespace ns) {
            foreach (TableMapping table in this.Project.TableMappings.Where(o => !o.Exclude))
                CreateClass(template, table, ns);
        }

        private void CreateClass(Template template, TableMapping table, CodeNamespace ns) {
            CodeTypeDeclaration cls = new CodeTypeDeclaration(table.ClassName);
            IEnumerable<ColumnMapping> columns = table.ColumnMappings.Where(o => !o.Exclude);

            // Create the class.
            cls.IsClass = true;
            cls.IsPartial = true;
            cls.CustomAttributes.Add(new CodeAttributeDeclaration(new CodeTypeReference("DataContract")));

            foreach (ColumnMapping column in columns) {
                CodeMemberField field = new CodeMemberField();
                CodeMemberProperty property = new CodeMemberProperty();

                // Create the backing field.
                field.Attributes = MemberAttributes.Family;
                field.Type = new CodeTypeReference(column.DataType);
                field.Name = "_{0}".FormatString(column.FieldName);

                cls.Members.Add(field);

                // Create the property.
                CreateComments(column, property.Comments);
                property.CustomAttributes.Add(new CodeAttributeDeclaration(new CodeTypeReference("DataMember")));
                property.Attributes = MemberAttributes.Public;
                property.Type = field.Type;
                property.Name = column.FieldName;
                property.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), field.Name)));
                property.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), field.Name), new CodePropertySetValueReferenceExpression()));

                cls.Members.Add(property);
            }

            ns.Types.Add(cls);
        }

        private void CreateComments<T>(T element, CodeCommentStatementCollection comments)
            where T : IProjectSchemaElement, IHasAnnotations<T> {
            Annotation<T> summary = element.Annotations.SingleOrDefault(o => "summary".Equals(o.Type));

            if (summary != null)
                comments.Add(new CodeCommentStatement("<summary>{0}</summary>".FormatString(summary.Text), true));
        }
    }
}
