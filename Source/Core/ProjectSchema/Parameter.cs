using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    [XmlRoot("Parameter")]
    public class Parameter<T> : IProjectSchemaElement, IParameter, IHasAnnotations<Parameter<T>>, IHasAttributes<Parameter<T>>
        where T : IProjectSchemaElement
    {
        public enum ParameterModifier
        {
            None, Out, Params, Ref
        }

        public enum ParameterQuantifier
        {
            Single, Array, List, IEnumerable
        }

        public enum ParameterType
        {
            Void, DataObject, Enum, Other
        }

        private T _parentObject = default(T);
        private string _name = null;
        private bool _isReturnParameter = true;
        private ParameterModifier _modifier = ParameterModifier.None;
        private ParameterQuantifier _quantifier = ParameterQuantifier.Single;
        private ParameterType _type = ParameterType.Void;
        private string _dataTypeReferencedTableMappingSchemaName;
        private string _dataTypeReferencedTableMappingName;
        private string _dataTypeReferencedEnumColumnMappingName;
        private string _otherDataType = null;
        private bool _nullable = false;
        private List<Annotation<Parameter<T>>> _annotations = new List<Annotation<Parameter<T>>>();
        private List<Attribute<Parameter<T>>> _attributes = new List<Attribute<Parameter<T>>>();
        private Entity _dataTypeReferencedTableMapping = null;
        private Property _dataTypeReferencedEnumColumnMapping = null;

        [XmlIgnore]
        public Project ContainingProject
        {
            get { return (_parentObject == null ? ProjectContext.Project : _parentObject.ContainingProject); }
        }

        [XmlAttribute]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [XmlAttribute]
        public bool IsReturnParameter
        {
            get { return _isReturnParameter; }
            set { _isReturnParameter = value; }
        }

        [XmlAttribute]
        public ParameterModifier Modifier
        {
            get { return _modifier; }
            set { _modifier = value; }
        }

        [XmlAttribute]
        public ParameterQuantifier Quantifier
        {
            get { return _quantifier; }
            set { _quantifier = value; }
        }

        [XmlAttribute]
        public ParameterType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        [XmlAttribute]
        public string DataTypeReferencedTableMappingSchemaName
        {
            get { return _dataTypeReferencedTableMappingSchemaName; }
            set { _dataTypeReferencedTableMappingSchemaName = value; }
        }

        [XmlAttribute]
        public string DataTypeReferencedTableMappingName
        {
            get { return _dataTypeReferencedTableMappingName; }
            set { _dataTypeReferencedTableMappingName = value; }
        }

        [XmlAttribute]
        public string DataTypeReferencedEnumColumnMappingName
        {
            get { return _dataTypeReferencedEnumColumnMappingName; }
            set { _dataTypeReferencedEnumColumnMappingName = value; }
        }

        [XmlAttribute]
        public string OtherDataType
        {
            get { return _otherDataType; }
            set { _otherDataType = value; }
        }

        [XmlAttribute]
        public bool Nullable
        {
            get { return _nullable; }
            set { _nullable = value; }
        }

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public List<Annotation<Parameter<T>>> Annotations
        {
            get { return _annotations; }
            set { _annotations = value; }
        }

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<Parameter<T>>> Attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }

        [XmlIgnore]
        public Entity DataTypeReferencedTableMapping
        {
            get
            {
                if (string.IsNullOrEmpty(_dataTypeReferencedTableMappingSchemaName) || string.IsNullOrEmpty(_dataTypeReferencedTableMappingName))
                    throw new ApplicationException("Data Type Schema or Table Name is not known.");

                if (_dataTypeReferencedTableMapping == null || !_dataTypeReferencedTableMapping.SchemaName.Equals(_dataTypeReferencedTableMappingSchemaName) || !_dataTypeReferencedTableMapping.Name.Equals(_dataTypeReferencedTableMappingName))
                    _dataTypeReferencedTableMapping = ContainingProject.FindTableMapping(_dataTypeReferencedTableMappingSchemaName, _dataTypeReferencedTableMappingName);

                return _dataTypeReferencedTableMapping;
            }
            set
            {
                _dataTypeReferencedTableMappingName = value.Name;
                _dataTypeReferencedTableMapping = value;
            }
        }

        [XmlIgnore]
        public Property DataTypeReferencedEnumColumnMapping
        {
            get
            {
                if (string.IsNullOrEmpty(_dataTypeReferencedEnumColumnMappingName))
                    throw new ApplicationException("Data Type Enum Column Mapping Name is not known.");

                if (_dataTypeReferencedEnumColumnMapping == null || !_dataTypeReferencedEnumColumnMapping.Name.Equals(_dataTypeReferencedEnumColumnMappingName))
                    _dataTypeReferencedEnumColumnMapping = DataTypeReferencedTableMapping.FindColumnMapping(_dataTypeReferencedEnumColumnMappingName);

                return _dataTypeReferencedEnumColumnMapping;
            }
            set
            {
                _dataTypeReferencedTableMappingSchemaName = value.Entity.SchemaName;
                _dataTypeReferencedTableMappingName = value.Entity.Name;
                _dataTypeReferencedEnumColumnMappingName = value.Name;
                _dataTypeReferencedEnumColumnMapping = value;
            }
        }

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations
        {
            get
            {
                foreach (IAnnotation annotation in _annotations)
                    yield return annotation;
            }
        }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes
        {
            get
            {
                foreach (IAttribute attribute in this.Attributes.Union(_annotations.SelectMany(o => o.AllAttributes)))
                    yield return attribute;
            }
        }

        public Parameter() { }

        private Parameter(string name, bool isReturnParameter, ParameterModifier modifier, ParameterQuantifier quantifier, ParameterType dataType, string dataTypeReferencedTableMappingSchemaName, string dataTypeReferencedTableMappingName, string dataTypeReferencedEnumColumnMappingName, string otherDataType, bool nullable, List<Annotation<Parameter<T>>> annotations, List<Attribute<Parameter<T>>> attributes)
        {
            _name = name;
            _isReturnParameter = isReturnParameter;
            _modifier = modifier;
            _quantifier = quantifier;
            _type = dataType;
            _dataTypeReferencedTableMappingSchemaName = dataTypeReferencedTableMappingSchemaName;
            _dataTypeReferencedTableMappingName = dataTypeReferencedTableMappingName;
            _dataTypeReferencedEnumColumnMappingName = dataTypeReferencedEnumColumnMappingName;
            _otherDataType = otherDataType;
            _nullable = nullable;
            _annotations = new List<Annotation<Parameter<T>>>(annotations ?? new List<Annotation<Parameter<T>>>());
            _attributes = new List<Attribute<Parameter<T>>>(attributes ?? new List<Attribute<Parameter<T>>>());
        }

        public override string ToString()
        {
            if (_type == Parameter<T>.ParameterType.Void)
                return "void";
            else
            {
                StringBuilder description = new StringBuilder();

                if (_modifier != Parameter<T>.ParameterModifier.None)
                    description.Append(_modifier.ToString().ToLower() + " ");

                switch(_quantifier)
                {
                    case Parameter<T>.ParameterQuantifier.List:
                        description.Append("List<");
                        break;
                    case Parameter<T>.ParameterQuantifier.IEnumerable:
                        description.Append("IEnumerable<");
                        break;
                }

                if (_type == Parameter<T>.ParameterType.DataObject)
                {
                    if (this.DataTypeReferencedTableMapping != null)
                        description.Append(DataTypeReferencedTableMapping.ClassName);
                    else
                        description.Append("Unknown DataObject");
                }
                else if (_type == Parameter<T>.ParameterType.Enum)
                {
                    if (this.DataTypeReferencedEnumColumnMapping != null && DataTypeReferencedEnumColumnMapping.EnumerationMapping != null)
                        description.Append(DataTypeReferencedEnumColumnMapping.EnumerationMapping.Name + (_nullable ? "?" : ""));
                    else
                        description.Append("Unknown Enum" + (_nullable ? "?" : ""));
                }
                else if (_type == Parameter<T>.ParameterType.Other)
                    description.Append(_otherDataType + (_nullable ? "?" : ""));

                if (_quantifier == Parameter<T>.ParameterQuantifier.Array)
                    description.Append("[]");
                else if (_quantifier == Parameter<T>.ParameterQuantifier.List || _quantifier == Parameter<T>.ParameterQuantifier.IEnumerable)
                    description.Append(">");

                if (!string.IsNullOrEmpty(_name))
                    description.Append(" " + _name);

                return description.ToString();
            }
        }

        public void JoinToParent(T parentObject)
        {
            if (_parentObject != null)
                throw new ApplicationException("Already joined to an object.");

            _parentObject = parentObject;
            _annotations.ForEach(a => a.JoinToParent(this));
            _attributes.ForEach(a => a.JoinToParent(this));
        }

        public static Parameter<T> CreateVoidReturnParameter(List<Annotation<Parameter<T>>> annotations, List<Attribute<Parameter<T>>> attributes)
        {
            return new Parameter<T>(null, true, Parameter<T>.ParameterModifier.None, Parameter<T>.ParameterQuantifier.Single, Parameter<T>.ParameterType.Void, null, null, null, null, false, annotations, attributes);
        }

        public static Parameter<T> CreateDataObjectReturnParameter(Entity dataTypeReferencedTableMapping, ParameterQuantifier quantifier, List<Annotation<Parameter<T>>> annotations, List<Attribute<Parameter<T>>> attributes)
        {
            return new Parameter<T>(null, true, Parameter<T>.ParameterModifier.None, quantifier, Parameter<T>.ParameterType.DataObject, dataTypeReferencedTableMapping.SchemaName, dataTypeReferencedTableMapping.Name, null, null, false, annotations, attributes);
        }

        public static Parameter<T> CreateEnumReturnParameter(Property dataTypeReferencedColumnMapping, bool isNullable, List<Annotation<Parameter<T>>> annotations, List<Attribute<Parameter<T>>> attributes)
        {
            return new Parameter<T>(null, true, Parameter<T>.ParameterModifier.None, Parameter<T>.ParameterQuantifier.Single, Parameter<T>.ParameterType.Enum, dataTypeReferencedColumnMapping.Entity.SchemaName, dataTypeReferencedColumnMapping.Entity.Name, dataTypeReferencedColumnMapping.Name, null, isNullable, annotations, attributes);
        }

        public static Parameter<T> CreateOtherReturnParameter(string dataType, ParameterQuantifier quantifier, bool isNullable, List<Annotation<Parameter<T>>> annotations, List<Attribute<Parameter<T>>> attributes)
        {
            return new Parameter<T>(null, true, Parameter<T>.ParameterModifier.None, quantifier, Parameter<T>.ParameterType.Other, null, null, null, dataType, isNullable, annotations, attributes);
        }

        public static Parameter<T> CreateDataObjectParameter(string name, Parameter<T>.ParameterModifier modifier, ParameterQuantifier quantifier, Entity dataTypeReferencedTableMapping, List<Annotation<Parameter<T>>> annotations, List<Attribute<Parameter<T>>> attributes)
        {
            return new Parameter<T>(name, false, modifier, quantifier, Parameter<T>.ParameterType.DataObject, dataTypeReferencedTableMapping.SchemaName, dataTypeReferencedTableMapping.Name, null, null, false, annotations, attributes);
        }

        public static Parameter<T> CreateEnumParameter(string name, Parameter<T>.ParameterModifier modifier, Property dataTypeReferencedColumnMapping, bool nullable, List<Annotation<Parameter<T>>> annotations, List<Attribute<Parameter<T>>> attributes)
        {
            return new Parameter<T>(name, false, modifier, Parameter<T>.ParameterQuantifier.Single, Parameter<T>.ParameterType.Enum, dataTypeReferencedColumnMapping.Entity.SchemaName, dataTypeReferencedColumnMapping.Entity.Name, dataTypeReferencedColumnMapping.Name, null, nullable, annotations, attributes);
        }

        public static Parameter<T> CreateOtherParameter(string name, Parameter<T>.ParameterModifier modifier, ParameterQuantifier quantifier, string dataType, bool nullable, List<Annotation<Parameter<T>>> annotations, List<Attribute<Parameter<T>>> attributes)
        {
            return new Parameter<T>(name, false, modifier, quantifier, Parameter<T>.ParameterType.Other, null, null, null, dataType, nullable, annotations, attributes);
        }
    }
}
