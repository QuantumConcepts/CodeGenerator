using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantumConcepts.CodeGenerator.Core.Templates;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;

namespace Tests {
    [TestClass]
    public class CodeDomTests {
        [TestMethod]
        public void DataObjectsGenerationViaCodeDomWorks() {
            TestHelper helper = new TestHelper(1);
            Project project = helper.CreateProject();
            DataObjects template = new DataObjects(project);

            template.Render(new Template(project, @"C:\Nothing.xslt", TemplateOutputMode.SingleFile, @"C:\Nothing", null));
        }
    }
}
