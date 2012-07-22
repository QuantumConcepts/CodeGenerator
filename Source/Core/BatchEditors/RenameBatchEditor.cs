using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.Common.Utils;

namespace QuantumConcepts.CodeGenerator.Core.BatchEditors
{
    internal class RenameBatchEditor : BaseBatchEditor
    {
        private const string Field_NewNameXPath = "New Name XPath";

        public override string Name { get { return "Rename"; } }
        public override ElementType[] ElementTypes { get { return new[] { ElementType.Annotation, ElementType.API, ElementType.Attribute, ElementType.Column, ElementType.Table, ElementType.Parameter }; } }
        public override string[] Fields { get { return new[] { Field_NewNameXPath }; } }

        public override bool Apply(IProjectSchemaElement element, string newValue)
        {
            if (element is IAnnotation)
                ((IAnnotation)element).Type = newValue;
            else if (element is API)
                ((API)element).Name = newValue;
            else if (element is IAttribute)
                ((IAttribute)element).Key = newValue;
            else if (element is ColumnMapping)
                ((ColumnMapping)element).FieldName = newValue;
            else if (element is TableMapping)
                ((TableMapping)element).ClassName = newValue;
            else if (element is IParameter)
                ((IParameter)element).Name = newValue;
            else
                throw new ApplicationException("This action is not supported for elements of type \"{0}.\"".FormatString(element.GetType()));

            return true;
        }
    }
}