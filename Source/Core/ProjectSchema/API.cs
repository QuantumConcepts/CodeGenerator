using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    [XmlRoot("API")]
    public class API : IProjectSchemaElement, IHasReturnParameter<API>, IHasParameters<API>, IHasAnnotations<API>, IHasAttributes<API>
    {
        public enum APIType
        {
            Create, Delete, Custom
        }

        private TableMapping _tableMapping = null;
        private APIType _type = APIType.Custom;
        private string _name = null;
        private Parameter<API> _returnParameter = Parameter<API>.CreateVoidReturnParameter(null, null);
        private List<Parameter<API>> _parameters = new List<Parameter<API>>();
        private List<Annotation<API>> _annotations = new List<Annotation<API>>();
        private List<Attribute<API>> _attributes = new List<Attribute<API>>();

        [XmlIgnore]
        public Project ContainingProject
        {
            get { return (_tableMapping == null ? ProjectContext.Project : _tableMapping.ContainingProject); }
        }

        [XmlAttribute("APIType")]
        public APIType Type
        {
            get { return _type; }
            set { _type = value; }
        }

        [XmlAttribute]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        [XmlElement]
        public Parameter<API> ReturnParameter
        {
            get { return _returnParameter; }
            set { _returnParameter = value; }
        }

        [XmlArray]
        [XmlArrayItem("Parameter")]
        public List<Parameter<API>> Parameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public List<Annotation<API>> Annotations
        {
            get { return _annotations; }
            set { _annotations = value; }
        }

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<API>> Attributes
        {
            get { return _attributes; }
            set { _attributes = value; }
        }

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations
        {
            get
            {
                foreach (IAnnotation annotation in _annotations.Union(_returnParameter.AllAnnotations).Union(_parameters.SelectMany(o => o.AllAnnotations)))
                    yield return annotation;
            }
        }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes
        {
            get
            {
                foreach (IAttribute attribute in this.Attributes.Union(_returnParameter.AllAttributes).Union(_parameters.SelectMany(o => o.AllAttributes)).Union(_annotations.SelectMany(o => o.AllAttributes)))
                    yield return attribute;
            }
        }

        public API() { }

        public API(string name, Parameter<API> returnParameter)
            : this(APIType.Custom, name, returnParameter, null, null, null)
        { }

        public API(APIType apiType, string name, Parameter<API> returnParameter, List<Parameter<API>> parameters, List<Annotation<API>> annotations, List<Attribute<API>> attributes)
        {
            _type = apiType;
            _name = name;
            _returnParameter = returnParameter;
            _parameters = (parameters ?? new List<Parameter<API>>());
            _annotations = (annotations ?? new List<Annotation<API>>());
            _attributes = (attributes ?? new List<Attribute<API>>());
        }

        public void JoinToTableMapping(TableMapping tableMapping)
        {
            if (_tableMapping != null)
                throw new ApplicationException("Already joined to a table mapping.");

            _tableMapping = tableMapping;
            _returnParameter.JoinToParent(this);
            _parameters.ForEach(p => p.JoinToParent(this));
            _annotations.ForEach(a => a.JoinToParent(this));
            _attributes.ForEach(a => a.JoinToParent(this));
        }

        public override string ToString()
        {
            StringBuilder description = new StringBuilder();
            bool first = true;

            description.Append(_returnParameter.ToString() + " ");
            description.Append(_name + "(");

            foreach (Parameter<API> thisParameter in _parameters)
            {
                description.Append((first ? "" : ", ") + thisParameter.ToString());
                first = false;
            }

            description.Append(")");

            return description.ToString();
        }

        public static API CreateValueTypeCreateAPI(TableMapping tableMapping)
        {
            API api = new API(API.APIType.Create, "Create" + tableMapping.ClassName, Parameter<API>.CreateDataObjectReturnParameter(tableMapping, Parameter<API>.ParameterQuantifier.Single, null, null), null, new List<Annotation<API>> { new Annotation<API>("summary", "Creates a new " + tableMapping.ClassName + " using the passed-in parameter value(s).", null) }, null);

            api.JoinToTableMapping(tableMapping);

            foreach (ColumnMapping cm in (from cm in tableMapping.NonPrimaryKeyColumnMappings
                                          where !cm.IsEncryptionColumn
                                          select cm))
            {
                Parameter<API> parameter = null;

                if (cm.IsEnumeration)
                    parameter = Parameter<API>.CreateEnumParameter(cm.FieldName, Parameter<API>.ParameterModifier.None, cm, cm.Nullable, null, null);
                else if (cm.IsEncrypted)
                    parameter = Parameter<API>.CreateOtherParameter(cm.DecryptionPropertyName, Parameter<API>.ParameterModifier.None, Parameter<API>.ParameterQuantifier.Single, "string", false, null, null);
                else
                    parameter = Parameter<API>.CreateOtherParameter(cm.FieldName, Parameter<API>.ParameterModifier.None, Parameter<API>.ParameterQuantifier.Single, cm.DataType, cm.Nullable, null, null);

                api.Parameters.Add(parameter);
                parameter.JoinToParent(api);
            }

            return api;
        }

        public static API CreateObjectCreateAPI(TableMapping tableMapping)
        {
            API api = new API(API.APIType.Create, "Create" + tableMapping.ClassName, Parameter<API>.CreateDataObjectReturnParameter(tableMapping, Parameter<API>.ParameterQuantifier.Single, null, null), null, new List<Annotation<API>> { new Annotation<API>("summary", "Creates a new " + tableMapping.ClassName + " using the passed-in parameter value(s).", null) }, null);

            api.JoinToTableMapping(tableMapping);

            foreach (ColumnMapping cm in (from cm in tableMapping.NonPrimaryKeyColumnMappings
                                          where !cm.IsEncryptionColumn
                                          select cm))
            {
                Parameter<API> parameter = null;
                ForeignKeyMapping foreignKeyMapping=tableMapping.ContainingProject.ForeignKeyMappings.Where(fkm=>fkm.ReferencedColumnMapping==cm).SingleOrDefault();

                if (cm.IsEnumeration)
                    parameter = Parameter<API>.CreateEnumParameter(cm.FieldName, Parameter<API>.ParameterModifier.None, cm, cm.Nullable, null, null);
                else if (cm.IsEncrypted)
                    parameter = Parameter<API>.CreateOtherParameter(cm.DecryptionPropertyName, Parameter<API>.ParameterModifier.None, Parameter<API>.ParameterQuantifier.Single, "string", false, null, null);
                else if (foreignKeyMapping != null)
                    parameter = Parameter<API>.CreateOtherParameter(foreignKeyMapping.FieldName, Parameter<API>.ParameterModifier.None, Parameter<API>.ParameterQuantifier.Single, cm.TableMapping.ClassName, false, null, null);
                else
                    parameter = Parameter<API>.CreateOtherParameter(cm.FieldName, Parameter<API>.ParameterModifier.None, Parameter<API>.ParameterQuantifier.Single, cm.DataType, cm.Nullable, null, null);

                api.Parameters.Add(parameter);
                parameter.JoinToParent(api);
            }

            return api;
        }

        public static API CreateDeleteAPI(TableMapping tableMapping)
        {
            API api = new API(API.APIType.Delete, "Delete" + tableMapping.ClassName, Parameter<API>.CreateVoidReturnParameter(null, null), null, new List<Annotation<API>> { new Annotation<API>("summary", "Deletes the " + tableMapping.ClassName + " identified by the passed-in parameter value(s).", null) }, null);

            foreach (ColumnMapping cm in tableMapping.PrimaryKeyColumnMappings)
            {
                Parameter<API> parameter = Parameter<API>.CreateOtherParameter(cm.FieldName, Parameter<API>.ParameterModifier.None, Parameter<API>.ParameterQuantifier.Single, cm.DataType, cm.Nullable, null, null);

                api.Parameters.Add(parameter);
                parameter.JoinToParent(api);
            }

            return api;
        }

        public void TransferTo(TableMapping tableMapping)
        {
            _tableMapping.APIs.Remove(this);
            _tableMapping = tableMapping;
            _tableMapping.APIs.Add(this);
        }
    }
}
