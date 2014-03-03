using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace QuantumConcepts.CodeGenerator.Sample.Service.ServiceObjects.REST
{
    [DataContract]
    public class Link
    {
        [DataMember]
        public string Relationship { get; set; }

        [DataMember]
        public LinkType Type { get; set; }

        [DataMember]
        public string Href { get; set; }

        public Link() { }

        public Link(string relationship, LinkType type, string href)
        {
            this.Relationship = relationship;
            this.Type = type;
            this.Href = href;
        }
    }
}
