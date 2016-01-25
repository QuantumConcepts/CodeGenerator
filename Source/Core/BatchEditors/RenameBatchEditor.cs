using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Extensions;
using System;

namespace QuantumConcepts.CodeGenerator.Core.BatchEditors {

    public class RenameBatchEditor : BaseBatchEditor {
        private const string Field_NewNameXPath = "New Name XPath";

        public override string Name { get { return "Rename"; } }
        public override ElementType[] ElementTypes { get { return new[] { ElementType.Annotation, ElementType.API, ElementType.Attribute, ElementType.Column, ElementType.Table, ElementType.Parameter }; } }
        public override string[] Fields { get { return new[] { Field_NewNameXPath }; } }

        public override bool Apply(IProjectSchemaElement element, string newValue) {
            IRenameable renameable = (element as IRenameable);

            if (renameable != null) {
                renameable.Rename(newValue);

                return true;
            }

            return false;
        }
    }
}