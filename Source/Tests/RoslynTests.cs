﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.CodeGenerator.RoslynTemplates;

namespace Tests {
    [TestClass]
    public class RoslynTests {
        [TestMethod]
        public void TestDataObjects() {
            TestHelper helper = new TestHelper(1);
            Project project = helper.CreateProject();
            DataObjects template = new DataObjects(project);

            template.Render(new Template(project, @"C:\Nothing.xslt", TemplateOutputMode.SingleFile, @"C:\Nothing", null));
        }
    }
}