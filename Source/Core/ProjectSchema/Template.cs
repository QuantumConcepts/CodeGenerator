using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using QuantumConcepts.Common.Utils;
using System.IO;
using System.Linq;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    [XmlRoot("Template")]
    public class Template : IProjectSchemaElement, IHasAttributes<Template>
    {
        public const string Param_Name = "templateName";

        private Project _project;

        [XmlAttribute]
        public string Name { get { return this.XsltHintPath.Substring(this.XsltHintPath.LastIndexOf(@"\") + 1); } set { } }

        [XmlAttribute]
        public string XsltHintPath { get; set; }

        [XmlAttribute]
        public TemplateOutputMode OutputMode { get; set; }

        [XmlAttribute]
        public string OutputHintPath { get; set; }

        [XmlArray]
        [XmlArrayItem]
        public List<TemplateOutputDefinition> TemplateOutputDefinitions { get; set; }

        [XmlArray]
        [XmlArrayItem("Attribute")]
        public List<Attribute<Template>> Attributes { get; set; }

        [XmlIgnore]
        public string XsltAbsolutePath { get { return FileSystemUtil.HintPathToAbsolutePath(this.ContainingProject.Path, this.XsltHintPath); } set { this.XsltHintPath = FileSystemUtil.AbsolutePathToHintPath(this.ContainingProject.Path, value); } }

        [XmlIgnore]
        public string OutputAbsolutePath { get { return FileSystemUtil.HintPathToAbsolutePath(this.ContainingProject.Path, this.OutputHintPath); } set { this.OutputHintPath = FileSystemUtil.AbsolutePathToHintPath(this.ContainingProject.Path, value); } }

        [XmlIgnore]
        public Project ContainingProject { get { return _project; } }

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

        public Template() { }

        public Template(Project project, string xsltAbsolutePath, TemplateOutputMode outputMode, string outputAbsolutePath, List<TemplateOutputDefinition> outputDefinitions)
        {
            _project = project;

            this.XsltAbsolutePath = xsltAbsolutePath;
            this.OutputMode = outputMode;
            this.OutputAbsolutePath = outputAbsolutePath;
            this.TemplateOutputDefinitions = outputDefinitions;
        }

        public void JoinToProject(Project project)
        {
            _project = project;

            this.TemplateOutputDefinitions.ForEach(od => od.JoinToTemplate(this));
        }

        internal List<TemplateOutputDefinitionFilenameResult> GetOutputFilenames()
        {
            List<TemplateOutputDefinitionFilenameResult> outputFilenames = new List<TemplateOutputDefinitionFilenameResult>();

            if (this.OutputMode == TemplateOutputMode.SingleFile)
                outputFilenames.Add(new TemplateOutputDefinitionFilenameResult(null, null, this.OutputAbsolutePath));
            else
            {
                foreach (TemplateOutputDefinition definition in this.TemplateOutputDefinitions)
                {
                    TemplateOutputDefinitionFilename filename = TemplateOutputDefinitionFilename.Parse(definition.FilenameXPath);

                    outputFilenames.AddRange(filename.Compute(definition));
                }
            }

            return outputFilenames;
        }
    }
}
