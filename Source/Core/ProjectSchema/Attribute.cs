using QuantumConcepts.Common.Extensions;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema {

    [XmlRoot]
    public class Attribute<T> : IProjectSchemaElement, IAttribute
        where T : IProjectSchemaElement {
        private T _parent;

        [XmlAttribute]
        public string Key { get; set; }

        [XmlAttribute]
        public string Value { get; set; }

        [XmlIgnore]
        public Project ContainingProject { get { return _parent.ContainingProject; } }

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations { get { yield break; } }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes { get { yield break; } }

        public Attribute() {
        }

        public Attribute(string key, string value) {
            this.Key = key;
            this.Value = value;
        }

        public void Rename(string newName) {
            this.Key = newName;
        }

        public void JoinToParent(T parent) {
            if (_parent != null)
                throw new ApplicationException("Already joined to a parent.");

            _parent = parent;
        }

        public override string ToString() {
            return "{0}: {1}".FormatString(this.Key, this.Value);
        }
    }
}