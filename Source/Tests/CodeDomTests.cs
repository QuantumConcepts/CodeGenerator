using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantumConcepts.CodeGenerator.Core.Templates;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.IO;
using Microsoft.CSharp;

namespace Tests {
    [TestClass]
    public class CodeDomTests {
        [TestMethod]
        public void TestDataObjects() {
            TestHelper helper = new TestHelper(1);
            Project project = helper.CreateProject();
            DataObjects template = new DataObjects(project);
            CodeCompileUnit code = template.Render(new Template(project, @"C:\Nothing.xslt", TemplateOutputMode.SingleFile, @"C:\Nothing", null));
            CodeDomProvider provider = new CSharpCodeProvider();
            CodeGeneratorOptions options = new CodeGeneratorOptions() {
                VerbatimOrder = true
            };

            using (StreamWriter writer = new StreamWriter("C:\\DataObjects_Test.cs"))
                provider.GenerateCodeFromCompileUnit(code, writer, options);
        }
    }
}
