using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using QuantumConcepts.Common.Extensions;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    [XmlRoot]
    public class DataTypeMapping : IProjectSchemaElement
    {
        private string _databaseDataType;
        private string _applicationDataType;
        private bool _nullable;

        [XmlAttribute]
        public string DatabaseDataType
        {
            get { return _databaseDataType; }
            set { _databaseDataType = value; }
        }

        [XmlAttribute]
        public string ApplicationDataType
        {
            get { return _applicationDataType; }
            set { _applicationDataType = value; }
        }

        [XmlAttribute]
        public bool Nullable
        {
            get { return _nullable; }
            set { _nullable = value; }
        }

        [XmlIgnore]
        public Project ContainingProject { get; private set; }

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations { get { yield break; } }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes { get { yield break; } }

        public DataTypeMapping() { }

        public DataTypeMapping(string databaseDataType, string applicationDataType, bool nullable)
        {
            _databaseDataType = databaseDataType;
            _applicationDataType = applicationDataType;
            _nullable = nullable;
        }

        public Type GetApplicationDataTypeReference() {
            if (this.ApplicationDataType.IsNullOrEmpty())
                return null;

            return Type.GetType(this.ApplicationDataType);
        }

        public void JoinToProject(Project project)
        {
            if (this.ContainingProject != null)
                throw new ApplicationException("Already joined to a project.");

            this.ContainingProject = project;
        }
    }
}
