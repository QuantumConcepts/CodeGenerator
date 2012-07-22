using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using QuantumConcepts.Common.Extensions;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    [XmlRoot]
    public class Annotation<T> : IProjectSchemaElement, IAnnotation, IHasAttributes<Annotation<T>>
        where T : IProjectSchemaElement
    {
        private T _parent;

        [XmlAttribute]
        public string Type { get; set; }

        [XmlElement]
        public string Text { get; set; }

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<Annotation<T>>> Attributes { get; set; }

        [XmlIgnore]
        public Project ContainingProject { get { return _parent.ContainingProject; } }

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations { get { yield break; } }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes
        {
            get
            {
                foreach (IAttribute attribute in this.Attributes)
                    yield return attribute;
            }
        }

        public Annotation()
        {
            this.Attributes = new List<Attribute<Annotation<T>>>();
        }

        public Annotation(string type, string text, List<Attribute<Annotation<T>>> attributes)
            : this()
        {
            this.Type = type;
            this.Text = text;
            this.Attributes=(attributes??new List<Attribute<Annotation<T>>>());
        }

        public void JoinToParent(T parent)
        {
            if (_parent != null)
                throw new ApplicationException("Already joined to a parent.");

            _parent = parent;
            this.Attributes.ForEach(a => a.JoinToParent(this));
        }

        public override string ToString()
        {
            return "{0}: {1}".FormatString(this.Type, this.Text);
        }
    }
}
