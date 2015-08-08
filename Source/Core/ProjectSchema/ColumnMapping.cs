using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Text.RegularExpressions;
using System.Linq;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    [XmlRoot]
    public class ColumnMapping : IProjectSchemaElement, IHasAnnotations<ColumnMapping>, IHasAttributes<ColumnMapping>
    {
        [XmlIgnore]
        public Project ContainingProject
        {
            get { return (this.TableMapping == null ? ProjectContext.Project : this.TableMapping.ContainingProject); }
        }

        [XmlIgnore]
        public TableMapping TableMapping { get; private set; }

        [XmlAttribute]
        public string ColumnName { get; set; }

        [XmlAttribute]
        public decimal Sequence { get; set; }

        [XmlAttribute]
        public string DataType { get; set; }

        [XmlAttribute]
        public string DatabaseDataType { get; set; }

        [XmlAttribute]
        public decimal Length { get; set; }

        [XmlAttribute]
        public string DefaultValue { get; set; }

        [XmlAttribute]
        public bool Nullable { get; set; }

        [XmlAttribute]
        public bool NullableInDatabase { get; set; }

        [XmlAttribute]
        public bool PrimaryKey { get; set; }

        [XmlAttribute]
        public string FieldName { get; set; }

        [XmlAttribute]
        public bool TreatAsYesNoIndicator { get; set; }

        [XmlAttribute]
        public bool Exclude { get; set; }

        [XmlAttribute]
        public string EncryptionVectorColumnName { get; set; }

        [XmlAttribute]
        public string DecryptionPropertyName { get; set; }

        [XmlElement]
        public EnumerationMapping EnumerationMapping { get; set; }

        [XmlArray]
        [XmlArrayItem("Annotation")]
        public List<Annotation<ColumnMapping>> Annotations { get; set; }

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<ColumnMapping>> Attributes { get; set; }

        [XmlIgnore]
        public bool IsEncrypted { get { return !string.IsNullOrEmpty(this.EncryptionVectorColumnName); } }

        [XmlIgnore]
        public bool IsEncryptionColumn
        {
            get
            {
                foreach (ColumnMapping cm in this.TableMapping.ColumnMappings)
                    if (cm.IsEncrypted && cm.EncryptionVectorColumnName.Equals(this.ColumnName))
                        return true;

                return false;
            }
        }

        [XmlIgnore]
        public bool IsEnumeration { get { return this.EnumerationMapping != null; } }

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations
        {
            get
            {
                foreach (IAnnotation annotation in this.Annotations)
                    yield return annotation;
            }
        }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes
        {
            get
            {
                foreach (IAttribute attribute in this.Attributes.Union(this.Annotations.SelectMany(o => o.AllAttributes)))
                    yield return attribute;
            }
        }

        public ColumnMapping() {
            this.Annotations = new List<Annotation<ColumnMapping>>();
            this.Attributes = new List<Attribute<ColumnMapping>>();
        }

        public ColumnMapping(TableMapping tableMapping, string columnName, decimal sequence, string dataType, string databaseDataType, decimal length, string defaultValue, bool nullable, bool nullableInDatabase, bool primaryKey, List<Annotation<ColumnMapping>> annotations, List<Attribute<ColumnMapping>> attributes)
        {
            this.TableMapping = tableMapping;
            this.ColumnName = columnName;
            this.FieldName = columnName;
            this.Sequence = sequence;
            this.DataType = dataType;
            this.DatabaseDataType = databaseDataType;
            this.Length = length;
            this.Nullable = nullable;
            this.NullableInDatabase = nullableInDatabase;
            this.PrimaryKey = primaryKey;
            this.Annotations = (annotations ?? new List<Annotation<ColumnMapping>>());
            this.Attributes = (attributes ?? new List<Attribute<ColumnMapping>>());
        }

        public void JoinToTableMapping(TableMapping tableMapping)
        {
            if (this.TableMapping != null)
                throw new ApplicationException("Already joined to a table mapping.");

            this.TableMapping = tableMapping;

            if (this.EnumerationMapping != null)
                this.EnumerationMapping.JoinToColumnMapping(this);

            this.Annotations.ForEach(a => a.JoinToParent(this));
            this.Attributes.ForEach(a => a.JoinToParent(this));
        }

        public override string ToString()
        {
            return this.TableMapping.ToString() + "." + this.FieldName;
        }
    }
}
