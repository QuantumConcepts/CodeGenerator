using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using QuantumConcepts.Common.Utils;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    [XmlRoot]
    public class TemplateOutputDefinition : IProjectSchemaElement
    {
        [XmlIgnore]
        public Template Template { get; private set; }

        [XmlAttribute]
        public ElementType ElementType { get; set; }

        [XmlAttribute]
        public string FilterXPath { get; set; }

        [XmlAttribute]
        public string RootHintPath { get; set; }

        [XmlAttribute]
        public string FilenameXPath { get; set; }

        [XmlIgnore]
        public string RootAbsolutePath { get { return FileSystemUtil.HintPathToAbsolutePath(this.ContainingProject.Path, this.RootHintPath); } set { this.RootHintPath = FileSystemUtil.AbsolutePathToHintPath(this.ContainingProject.Path, value); } }

        [XmlIgnore]
        public Project ContainingProject { get { return this.Template.ContainingProject; } }

        [XmlIgnore]
        public IEnumerable<IAnnotation> AllAnnotations { get { yield break; } }

        [XmlIgnore]
        public IEnumerable<IAttribute> AllAttributes { get { yield break; } }

        public TemplateOutputDefinition() { }

        public TemplateOutputDefinition(Template template, ElementType elementType, string filterXPath, string rootAbsolutePath, string filenameXPath)
        {
            this.Template = template;
            this.ElementType = elementType;
            this.FilterXPath = filterXPath;
            this.RootAbsolutePath = rootAbsolutePath;
            this.FilenameXPath = filenameXPath;
        }

        public void JoinToTemplate(Template template)
        {
            if (this.Template != null)
                throw new ApplicationException("Already joined to a template.");

            this.Template = template;
        }

        public override string ToString()
        {
            return this.ElementType.ToString();
        }
    }
}
