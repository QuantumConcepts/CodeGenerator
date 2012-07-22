using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.Common.Utils;

namespace QuantumConcepts.CodeGenerator.Core.BatchEditors
{
    //internal class RenameBatchEditor : BaseBatchEditor
    //{
    //    private const string Field_NewNameXPath = "New Name XPath";

    //    public override string Name { get { return "Rename"; } }
    //    public override ElementType[] ElementTypes { get { return new[] { ElementType.Annotation, ElementType.API, ElementType.Attribute, ElementType.Column, ElementType.Table, ElementType.Parameter }; } }
    //    public override string[] Fields { get { return new[] { Field_NewNameXPath }; } }

    //    public override bool Apply(IProjectSchemaElement element, BatchEditorField[] fields)
    //    {
    //        //string newName = RunXPath(element, Field_NewNameXPath);

    //        //if (element is IAnnotation)
    //        //    ((IAnnotation)element).Type = newNameXPath;
    //        //else if (element is API)
    //        //    ((API)element).Name = newNameXPath;
    //        //else if (element is IAttribute)
    //        //    ((IAttribute)element).Key = newNameXPath;
    //        //else if (element is ColumnMapping)
    //        //    ((ColumnMapping)element).FieldName = newNameXPath;
    //        //else if (element is TableMapping)
    //        //    ((TableMapping)element).ClassName = newNameXPath;
    //        //else if (element is IParameter)
    //        //    ((IParameter)element).Name = newNameXPath;
    //        //else
    //        //    throw new ApplicationException("This action is not supported for elements of type \"{0}.\"".FormatString(element.GetType()));

    //        return true;
    //    }
    //}
}