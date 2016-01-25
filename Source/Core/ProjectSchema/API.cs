using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema {

    [XmlRoot("API")]
    public class API : IProjectSchemaElement, IHasReturnParameter<API>, IHasParameters<API>, IHasAnnotations<API>, IHasAttributes<API>, IRenameable {

        public enum APIType {
            Create, Delete, Custom
        }

        private Entity TableMapping { get; set; }

        [XmlIgnore]
        public Project ContainingProject {
            get { return (this.TableMapping == null ? ProjectContext.Project : this.TableMapping.ContainingProject); }
        }

        [XmlAttribute("APIType")]
        public APIType Type { get; set; } = APIType.Custom;

        [XmlAttribute]
        public string Name { get; set; }

        [XmlElement]
        public Parameter<API> ReturnParameter { get; set; } = Parameter<API>.CreateVoidReturnParameter(null, null);

        [XmlArray]
        [XmlArrayItem("Parameter")]
        public List<Parameter<API>> Parameters { get; set; } = new List<Parameter<API>>();

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public List<Annotation<API>> Annotations { get; set; } = new List<Annotation<API>>();

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<API>> Attributes { get; set; } = new List<Attribute<API>>();

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations {
            get {
                foreach (IAnnotation annotation in this.Annotations.Union(this.ReturnParameter.AllAnnotations).Union(this.Parameters.SelectMany(o => o.AllAnnotations)))
                    yield return annotation;
            }
        }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes {
            get {
                foreach (IAttribute attribute in this.Attributes.Union(this.ReturnParameter.AllAttributes).Union(this.Parameters.SelectMany(o => o.AllAttributes)).Union(this.Annotations.SelectMany(o => o.AllAttributes)))
                    yield return attribute;
            }
        }

        public API() {
            this.Annotations = new List<Annotation<API>>();
            this.Attributes = new List<Attribute<API>>();
        }

        public API(string name, Parameter<API> returnParameter)
            : this(APIType.Custom, name, returnParameter, null, null, null) { }

        public API(APIType apiType, string name, Parameter<API> returnParameter, List<Parameter<API>> parameters, List<Annotation<API>> annotations, List<Attribute<API>> attributes) {
            this.Type = apiType;
            this.Name = name;
            this.ReturnParameter = returnParameter;
            this.Parameters = (parameters ?? new List<Parameter<API>>());
            this.Annotations = (annotations ?? new List<Annotation<API>>());
            this.Attributes = (attributes ?? new List<Attribute<API>>());
        }

        public void Rename(string newName) {
            this.Name = newName;
        }

        public void JoinToTableMapping(Entity tableMapping) {
            if (this.TableMapping != null)
                throw new ApplicationException("Already joined to a table mapping.");

            this.TableMapping = tableMapping;
            this.ReturnParameter.JoinToParent(this);
            this.Parameters.ForEach(p => p.JoinToParent(this));
            this.Annotations.ForEach(a => a.JoinToParent(this));
            this.Attributes.ForEach(a => a.JoinToParent(this));
        }

        public override string ToString() {
            StringBuilder description = new StringBuilder();
            bool first = true;

            description.Append(this.ReturnParameter.ToString() + " ");
            description.Append(this.Name + "(");

            foreach (Parameter<API> thisParameter in this.Parameters) {
                description.Append((first ? "" : ", ") + thisParameter.ToString());
                first = false;
            }

            description.Append(")");

            return description.ToString();
        }

        public static API CreateValueTypeCreateAPI(Entity entity) {
            API api = new API(API.APIType.Create, "Create" + entity.Name, Parameter<API>.CreateDataObjectReturnParameter(entity, Parameter<API>.ParameterQuantifier.Single, null, null), null, new List<Annotation<API>> { new Annotation<API>("summary", "Creates a new " + entity.Name + " using the passed-in parameter value(s).", null) }, null);

            api.JoinToTableMapping(entity);

            foreach (Property cm in (from cm in entity.NonIdentityProperties
                                     where !cm.IsEncryptionColumn
                                     select cm)) {
                Parameter<API> parameter = null;

                if (cm.IsEnumeration)
                    parameter = Parameter<API>.CreateEnumParameter(cm.Name, Parameter<API>.ParameterModifier.None, cm, cm.Nullable, null, null);
                else if (cm.IsEncrypted)
                    parameter = Parameter<API>.CreateOtherParameter(cm.DecryptionPropertyName, Parameter<API>.ParameterModifier.None, Parameter<API>.ParameterQuantifier.Single, "string", false, null, null);
                else
                    parameter = Parameter<API>.CreateOtherParameter(cm.Name, Parameter<API>.ParameterModifier.None, Parameter<API>.ParameterQuantifier.Single, cm.DataType, cm.Nullable, null, null);

                api.Parameters.Add(parameter);
                parameter.JoinToParent(api);
            }

            return api;
        }

        public static API CreateObjectCreateAPI(Entity entity) {
            API api = new API(API.APIType.Create, "Create" + entity.Name, Parameter<API>.CreateDataObjectReturnParameter(entity, Parameter<API>.ParameterQuantifier.Single, null, null), null, new List<Annotation<API>> { new Annotation<API>("summary", "Creates a new " + entity.Name + " using the passed-in parameter value(s).", null) }, null);

            api.JoinToTableMapping(entity);

            foreach (Property property in (from p in entity.NonIdentityProperties
                                           where !p.IsEncryptionColumn
                                           select p)) {
                Parameter<API> parameter = null;
                EntityRelationship foreignKeyMapping = entity.ContainingProject.EntityRelationships.Where(o => {
                    Property p = o.ReferencingEnd.PropertyResolver.Resolve();

                    return (p == property);
                }).SingleOrDefault();

                if (property.IsEnumeration)
                    parameter = Parameter<API>.CreateEnumParameter(property.Name, Parameter<API>.ParameterModifier.None, property, property.Nullable, null, null);
                else if (property.IsEncrypted)
                    parameter = Parameter<API>.CreateOtherParameter(property.DecryptionPropertyName, Parameter<API>.ParameterModifier.None, Parameter<API>.ParameterQuantifier.Single, "string", false, null, null);
                else if (foreignKeyMapping != null)
                    parameter = Parameter<API>.CreateOtherParameter(foreignKeyMapping.Name, Parameter<API>.ParameterModifier.None, Parameter<API>.ParameterQuantifier.Single, property.Entity.Name, false, null, null);
                else
                    parameter = Parameter<API>.CreateOtherParameter(property.Name, Parameter<API>.ParameterModifier.None, Parameter<API>.ParameterQuantifier.Single, property.DataType, property.Nullable, null, null);

                api.Parameters.Add(parameter);
                parameter.JoinToParent(api);
            }

            return api;
        }

        public static API CreateDeleteAPI(Entity entity) {
            API api = new API(API.APIType.Delete, "Delete" + entity.Name, Parameter<API>.CreateVoidReturnParameter(null, null), null, new List<Annotation<API>> { new Annotation<API>("summary", "Deletes the " + entity.Name + " identified by the passed-in parameter value(s).", null) }, null);

            foreach (Property cm in entity.IdentityProperties) {
                Parameter<API> parameter = Parameter<API>.CreateOtherParameter(cm.Name, Parameter<API>.ParameterModifier.None, Parameter<API>.ParameterQuantifier.Single, cm.DataType, cm.Nullable, null, null);

                api.Parameters.Add(parameter);
                parameter.JoinToParent(api);
            }

            return api;
        }

        public void TransferTo(Entity tableMapping) {
            this.TableMapping.APIs.Remove(this);
            this.TableMapping = tableMapping;
            this.TableMapping.APIs.Add(this);
        }
    }
}