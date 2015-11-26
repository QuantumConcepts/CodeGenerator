using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Linq;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    [XmlRoot]
    public class EnumerationMapping : IProjectSchemaElement, IHasAnnotations<EnumerationMapping>, IHasAttributes<EnumerationMapping>
    {
        [XmlIgnore]
        public Project ContainingProject
        {
            get { return (this.ColumnMapping == null ? ProjectContext.Project : this.ColumnMapping.ContainingProject); }
        }

        [XmlIgnore]
        public ColumnMapping ColumnMapping { get; set; }

        [XmlAttribute]
        public string Name { get; set; }

        [XmlAttribute]
        public bool IsReference { get; set; }

        [XmlAttribute]
        public string ReferencedConnectionName { get; set; }

        [XmlAttribute]
        public string ReferencedTableMappingSchemaName { get; set; }

        [XmlAttribute]
        public string ReferencedTableMappingName { get; set; }

        [XmlAttribute]
        public string ReferencedColumnName { get; set; }

        [XmlArray]
        [XmlArrayItem]
        public List<EnumerationValueMapping> Values { get; set; } = new List<EnumerationValueMapping>();

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public List<Annotation<EnumerationMapping>> Annotations { get; set; } = new List<Annotation<EnumerationMapping>>();

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<EnumerationMapping>> Attributes { get; set; } = new List<Attribute<EnumerationMapping>>();

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations
        {
            get
            {
                foreach (IAnnotation annotation in this.Annotations.Union(this.Values.SelectMany(v => v.AllAnnotations)))
                    yield return annotation;
            }
        }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes
        {
            get
            {
                foreach (IAttribute attribute in this.Attributes.Union(this.Values.SelectMany(o => o.AllAttributes)).Union(this.Annotations.SelectMany(o => o.AllAttributes)))
                    yield return attribute;
            }
        }

        public EnumerationMapping() { }

        public EnumerationMapping(string name, List<EnumerationValueMapping> enumerationValueMappings, List<Annotation<EnumerationMapping>> annotations, List<Attribute<EnumerationMapping>> attributes)
        {
            this.Name = name;
            this.Values = (enumerationValueMappings ?? new List<EnumerationValueMapping>());
            this.Annotations = (annotations ?? new List<Annotation<EnumerationMapping>>());
            this.Attributes = (attributes ?? new List<Attribute<EnumerationMapping>>());
        }

        /// <summary>This constructor creates a referenced enumeration mapping from the supplied EnumerationMapping.</summary>
        public EnumerationMapping(EnumerationMapping reference)
        {
            UpdateReference(reference);
        }

        public void JoinToColumnMapping(ColumnMapping columnMapping)
        {
            if (this.ColumnMapping != null)
                throw new ApplicationException("Already joined to a column mapping.");

            this.ColumnMapping = columnMapping;

            if (this.Values != null)
                this.Values.ForEach(ev => ev.JoinToEnumerationMapping(this));

            if (this.Annotations != null)
                this.Annotations.ForEach(a => a.JoinToParent(this));

            if (this.Attributes != null)
                this.Attributes.ForEach(a => a.JoinToParent(this));
        }

        public EnumerationMapping GetReferencedEnumerationMapping()
        {
            if (!this.IsReference)
                return null;

            return ContainingProject
                .FindTableMapping(this.ReferencedConnectionName, this.ReferencedTableMappingSchemaName, this.ReferencedTableMappingName)
                .FindColumnMapping(this.ReferencedColumnName)
                .EnumerationMapping;
        }

        public void UpdateReference(EnumerationMapping reference)
        {
            this.Name = reference.Name;
            this.IsReference = true;
            this.ReferencedTableMappingSchemaName = reference.ColumnMapping.TableMapping.SchemaName;
            this.ReferencedTableMappingName = reference.ColumnMapping.TableMapping.TableName;
            this.ReferencedColumnName = reference.ColumnMapping.ColumnName;
            this.Values = null;
            this.Annotations = null;
            this.Attributes = null;
        }

        public bool References(EnumerationMapping reference)
        {
            return (object.Equals(reference.Name, this.Name) && object.Equals(reference.ColumnMapping.TableMapping.TableName, this.ReferencedTableMappingName) && object.Equals(reference.ColumnMapping.ColumnName, this.ReferencedColumnName));
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
