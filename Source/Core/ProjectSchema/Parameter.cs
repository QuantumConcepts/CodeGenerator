using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema {
    [XmlRoot("Parameter")]
    public class Parameter<T> : BaseProjectSchemaElement, IParameter, IHasAnnotations<Parameter<T>>, IHasAttributes<Parameter<T>>
        where T : IProjectSchemaElement {
        public enum ParameterModifier {
            None, Out, Params, Ref
        }

        public enum ParameterQuantifier {
            Single, Array, List, IEnumerable
        }

        public enum ParameterType {
            Void, DataObject, Enum, Other
        }

        private T ParentElement { get; set; }
        private Entity _dataTypeReferencedEntity = null;
        private Property _dataTypeReferencedEnumProperty = null;

        [XmlIgnore]
        public override Project ContainingProject {
            get {
                return (this.ParentElement?.ContainingProject ?? ProjectContext.Project);
            }
        }
        
        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public bool IsReturnParameter { get; set; }

        [XmlAttribute]
        public ParameterModifier Modifier { get; set; } = ParameterModifier.None;

        [XmlAttribute]
        public ParameterQuantifier Quantifier { get; set; } = ParameterQuantifier.Single;

        [XmlAttribute]
        public ParameterType Type { get; set; } = ParameterType.Void;

        [XmlAttribute]
        public string DataTypeReferencedTableMappingSchemaName { get; set; }

        [XmlAttribute]
        public string DataTypeReferencedTableMappingName { get; set; }

        [XmlAttribute]
        public string DataTypeReferencedEnumColumnMappingName { get; set; }

        [XmlAttribute]
        public string OtherDataType { get; set; }

        [XmlAttribute]
        public bool Nullable { get; set; }

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public List<Annotation<Parameter<T>>> Annotations { get; set; } = new List<Annotation<Parameter<T>>>();

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<Parameter<T>>> Attributes { get; set; } = new List<Attribute<Parameter<T>>>();

        [XmlIgnore]
        public Entity DataTypeReferencedTableMapping {
            get {
                if (string.IsNullOrEmpty(_dataTypeReferencedEntitySchemaName) || string.IsNullOrEmpty(_dataTypeReferencedEntityName))
                    throw new ApplicationException("Data Type Schema or Table Name is not known.");

                if (_dataTypeReferencedEntity == null || !_dataTypeReferencedEntity.SchemaName.Equals(_dataTypeReferencedEntitySchemaName) || !_dataTypeReferencedEntity.Name.Equals(_dataTypeReferencedEntityName))
                    _dataTypeReferencedEntity = ContainingProject.FindTableMapping(_dataTypeReferencedEntitySchemaName, _dataTypeReferencedEntityName);

                return _dataTypeReferencedEntity;
            }
            set {
                _dataTypeReferencedEntityName = value.Name;
                _dataTypeReferencedEntity = value;
            }
        }

        [XmlIgnore]
        public Property DataTypeReferencedEnumColumnMapping {
            get {
                if (string.IsNullOrEmpty(_dataTypeReferencedEnumPropertyName))
                    throw new ApplicationException("Data Type Enum Column Mapping Name is not known.");

                if (_dataTypeReferencedEnumProperty == null || !_dataTypeReferencedEnumProperty.Name.Equals(_dataTypeReferencedEnumPropertyName))
                    _dataTypeReferencedEnumProperty = DataTypeReferencedTableMapping.FindColumnMapping(_dataTypeReferencedEnumPropertyName);

                return _dataTypeReferencedEnumProperty;
            }
            set {
                _dataTypeReferencedEntitySchemaName = value.Entity.SchemaName;
                _dataTypeReferencedEntityName = value.Entity.Name;
                _dataTypeReferencedEnumPropertyName = value.Name;
                _dataTypeReferencedEnumProperty = value;
            }
        }

        [XmlIgnore]
        public override IEnumerable<IAnnotation> AllAnnotations {
            get {
                foreach (IAnnotation annotation in this.Annotations)
                    yield return annotation;
            }
        }

        [XmlIgnore]
        public override IEnumerable<IAttribute> AllAttributes {
            get {
                foreach (IAttribute attribute in this.Attributes.Union(this.Annotations.SelectMany(o => o.AllAttributes)))
                    yield return attribute;
            }
        }

        public Parameter() { }

        private Parameter(string name, bool isReturnParameter, ParameterModifier modifier, ParameterQuantifier quantifier, ParameterType dataType, string dataTypeReferencedTableMappingSchemaName, string dataTypeReferencedTableMappingName, string dataTypeReferencedEnumColumnMappingName, string otherDataType, bool nullable, List<Annotation<Parameter<T>>> annotations, List<Attribute<Parameter<T>>> attributes) {
            this.Name = name;
            this.IsReturnParameter = isReturnParameter;
            this.Modifier = modifier;
            this.Quantifier = quantifier;
            this.Type = dataType;
            _dataTypeReferencedEntitySchemaName = dataTypeReferencedTableMappingSchemaName;
            _dataTypeReferencedEntityName = dataTypeReferencedTableMappingName;
            _dataTypeReferencedEnumPropertyName = dataTypeReferencedEnumColumnMappingName;
            _otherDataType = otherDataType;
            this.Nullable = nullable;
            this.Annotations = new List<Annotation<Parameter<T>>>(annotations ?? new List<Annotation<Parameter<T>>>());
            this.Attributes = new List<Attribute<Parameter<T>>>(attributes ?? new List<Attribute<Parameter<T>>>());
        }

        public void Rename(string newName) {
            this.Name = newName;
        }

        public override string ToString() {
            if (this.Type == Parameter<T>.ParameterType.Void)
                return "void";
            else {
                StringBuilder description = new StringBuilder();

                if (this.Modifier != Parameter<T>.ParameterModifier.None)
                    description.Append(this.Modifier.ToString().ToLower() + " ");

                switch (this.Quantifier) {
                    case Parameter<T>.ParameterQuantifier.List:
                        description.Append("List<");
                        break;
                    case Parameter<T>.ParameterQuantifier.IEnumerable:
                        description.Append("IEnumerable<");
                        break;
                }

                if (this.Type == Parameter<T>.ParameterType.DataObject) {
                    if (this.DataTypeReferencedTableMapping != null)
                        description.Append(this.DataTypeReferencedTableMapping.Name);
                    else
                        description.Append("Unknown DataObject");
                }
                else if (this.Type == Parameter<T>.ParameterType.Enum) {
                    if (this.DataTypeReferencedEnumColumnMapping != null && this.DataTypeReferencedEnumColumnMapping.EnumerationMapping != null)
                        description.Append(this.DataTypeReferencedEnumColumnMapping.EnumerationMapping.Name + (this.Nullable ? "?" : ""));
                    else
                        description.Append("Unknown Enum" + (this.Nullable ? "?" : ""));
                }
                else if (this.Type == Parameter<T>.ParameterType.Other)
                    description.Append(_otherDataType + (this.Nullable ? "?" : ""));

                if (this.Quantifier == Parameter<T>.ParameterQuantifier.Array)
                    description.Append("[]");
                else if (this.Quantifier == Parameter<T>.ParameterQuantifier.List || this.Quantifier == Parameter<T>.ParameterQuantifier.IEnumerable)
                    description.Append(">");

                if (!string.IsNullOrEmpty(this.Name))
                    description.Append(" " + this.Name);

                return description.ToString();
            }
        }

        public void JoinToParent(T parentObject) {
            if (this.ParentElement != null)
                throw new ApplicationException("Already joined to an object.");

            this.ParentElement = parentObject;
            this.Annotations.ForEach(o => o.JoinToParent(this));
            this.Attributes.ForEach(o => o.JoinToParent(this));
        }

        public static Parameter<T> CreateVoidReturnParameter(List<Annotation<Parameter<T>>> annotations, List<Attribute<Parameter<T>>> attributes) {
            return new Parameter<T>(null, true, Parameter<T>.ParameterModifier.None, Parameter<T>.ParameterQuantifier.Single, Parameter<T>.ParameterType.Void, null, null, null, null, false, annotations, attributes);
        }

        public static Parameter<T> CreateDataObjectReturnParameter(Entity dataTypeReferencedTableMapping, ParameterQuantifier quantifier, List<Annotation<Parameter<T>>> annotations, List<Attribute<Parameter<T>>> attributes) {
            return new Parameter<T>(null, true, Parameter<T>.ParameterModifier.None, quantifier, Parameter<T>.ParameterType.DataObject, dataTypeReferencedTableMapping.SchemaName, dataTypeReferencedTableMapping.Name, null, null, false, annotations, attributes);
        }

        public static Parameter<T> CreateEnumReturnParameter(Property dataTypeReferencedColumnMapping, bool isNullable, List<Annotation<Parameter<T>>> annotations, List<Attribute<Parameter<T>>> attributes) {
            return new Parameter<T>(null, true, Parameter<T>.ParameterModifier.None, Parameter<T>.ParameterQuantifier.Single, Parameter<T>.ParameterType.Enum, dataTypeReferencedColumnMapping.Entity.SchemaName, dataTypeReferencedColumnMapping.Entity.Name, dataTypeReferencedColumnMapping.Name, null, isNullable, annotations, attributes);
        }

        public static Parameter<T> CreateOtherReturnParameter(string dataType, ParameterQuantifier quantifier, bool isNullable, List<Annotation<Parameter<T>>> annotations, List<Attribute<Parameter<T>>> attributes) {
            return new Parameter<T>(null, true, Parameter<T>.ParameterModifier.None, quantifier, Parameter<T>.ParameterType.Other, null, null, null, dataType, isNullable, annotations, attributes);
        }

        public static Parameter<T> CreateDataObjectParameter(string name, Parameter<T>.ParameterModifier modifier, ParameterQuantifier quantifier, Entity dataTypeReferencedTableMapping, List<Annotation<Parameter<T>>> annotations, List<Attribute<Parameter<T>>> attributes) {
            return new Parameter<T>(name, false, modifier, quantifier, Parameter<T>.ParameterType.DataObject, dataTypeReferencedTableMapping.SchemaName, dataTypeReferencedTableMapping.Name, null, null, false, annotations, attributes);
        }

        public static Parameter<T> CreateEnumParameter(string name, Parameter<T>.ParameterModifier modifier, Property dataTypeReferencedColumnMapping, bool nullable, List<Annotation<Parameter<T>>> annotations, List<Attribute<Parameter<T>>> attributes) {
            return new Parameter<T>(name, false, modifier, Parameter<T>.ParameterQuantifier.Single, Parameter<T>.ParameterType.Enum, dataTypeReferencedColumnMapping.Entity.SchemaName, dataTypeReferencedColumnMapping.Entity.Name, dataTypeReferencedColumnMapping.Name, null, nullable, annotations, attributes);
        }

        public static Parameter<T> CreateOtherParameter(string name, Parameter<T>.ParameterModifier modifier, ParameterQuantifier quantifier, string dataType, bool nullable, List<Annotation<Parameter<T>>> annotations, List<Attribute<Parameter<T>>> attributes) {
            return new Parameter<T>(name, false, modifier, quantifier, Parameter<T>.ParameterType.Other, null, null, null, dataType, nullable, annotations, attributes);
        }
    }
}
