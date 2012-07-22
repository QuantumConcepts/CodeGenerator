using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace QuantumConcepts.CodeGenerator.Core.PackageSchema
{
    public enum InputDataType { String }

    [XmlRoot]
    public class Input : IComparable<Input>, IEquatable<Input>
    {
        [XmlAttribute]
        public string ID { get; set; }

        [XmlAttribute]
        public string Label { get; set; }

        [XmlAttribute]
        public InputDataType DataType { get; set; }

        [XmlAttribute]
        public bool Required { get; set; }

        [XmlAttribute]
        public string Validation { get; set; }

        public int CompareTo(Input other)
        {
            return string.Compare(this.ID, other.ID);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Input);
        }

        public bool Equals(Input other)
        {
            return (other != null && other.ID == this.ID);
        }
    }
}
