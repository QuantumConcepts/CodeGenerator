using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Extensions;

namespace QuantumConcepts.CodeGenerator.Core.BatchEditors
{
    public abstract class BaseBatchEditor
    {
        public abstract string Name { get; }
        public abstract ElementType[] ElementTypes { get; }
        public abstract string[] Fields { get; }
        public abstract bool Apply(IProjectSchemaElement element, string newValue);

        public static BatchEditorField GetField(BatchEditorField[] fields, string name)
        {
            if (fields.IsNullOrEmpty())
                return null;

            return fields.FirstOrDefault(f => string.Equals(f.Name, name));
        }

        public static string RunXPath(BatchEditorField[] fields, string fieldName)
        {
            BatchEditorField field = GetField(fields, fieldName);

            if (field == null)
                return null;

            return null;    //TODO
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
