using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Xsl;
using System.Xml.Serialization;
using System.IO;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.Xml;
using QuantumConcepts.CodeGenerator.Core.Utils;
using QuantumConcepts.Common.Extensions;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Threading;
using log4net;
using System.Collections.Concurrent;

namespace QuantumConcepts.CodeGenerator.Core {
    public class Generator {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Generator));

        public delegate void GenerationStatusEventHandler(Generator generator, GenerationStatusEventArgs e);
        public delegate void TemplateGenerationStatusEventHandler(Generator generator, TemplateGenerationStatusEventArgs e);
        public delegate void ItemGenerationStatusEventHandler(Generator generator, ItemGenerationStatusEventArgs e);

        public event GenerationStatusEventHandler GenerationStatus;
        public event TemplateGenerationStatusEventHandler TemplateGenerationStatus;
        public event ItemGenerationStatusEventHandler ItemGenerationStatus;

        private Project Project { get; set; }
        private Dictionary<Template, List<TemplateOutputDefinitionFilenameResult>> TemplateOutputs { get; set; }
        private CancellationTokenSource CancellationTokenSource { get; set; }

        public Generator(Project project) : this(project, project.Templates) { }

        public Generator(Project project, IEnumerable<Template> templates) : this(project, templates.ToDictionary(o => o, o => o.GetOutputFilenames())) { }

        public Generator(Project project, Dictionary<Template, List<TemplateOutputDefinitionFilenameResult>> templateOutputs) {
            if (project == null)
                throw new ArgumentNullException("project");

            if (templateOutputs.IsNullOrEmpty())
                throw new ArgumentNullException("templateOutputs");

            this.Project = project;
            this.TemplateOutputs = templateOutputs;
            this.CancellationTokenSource = new CancellationTokenSource();
        }

        /// <summary>Generates all outputs.</summary>
        public async Task GenerateAsync() {
            Task<string> projectXml = null;
            IDictionary<Template, Task<XslCompiledTransform>> templateTransformTaskMap = null;

            OnGenerationStatus(GenerationStatusEventArgs.CreateGenerating());

            projectXml = SerializeProjectAsync();
            templateTransformTaskMap = GetTemplateCompilationTaskMap();
            await GenerateOutputsAsync(await projectXml, templateTransformTaskMap);

            OnGenerationStatus(GenerationStatusEventArgs.CreateComplete());
        }

        /// <summary>Serializes the project to XML.</summary>
        private Task<string> SerializeProjectAsync() {
            return Task.Run(() => SerializeProject(), this.CancellationTokenSource.Token);
        }

        /// <summary>Serializes the project to XML.</summary>
        private string SerializeProject() {
            try {
                XmlSerializer serializer = new XmlSerializer(typeof(Project));
                StringBuilder fileContent = new StringBuilder();

                using (StringWriter writer = new StringWriter(fileContent))
                    serializer.Serialize(writer, this.Project);

                return fileContent.ToString();
            }
            catch (Exception ex) {
                OnGenerationStatus(GenerationStatusEventArgs.CreateError(new ApplicationException("Unable to serialize the project file.", ex)));
                return null;
            }
        }

        /// <summary>Compiles the referenced XSLT for all templates.</summary>
        private IDictionary<Template, Task<XslCompiledTransform>> GetTemplateCompilationTaskMap() {
            IDictionary<Template, Task<XslCompiledTransform>> templateTransformTaskMap = new ConcurrentDictionary<Template, Task<XslCompiledTransform>>();

            foreach (Template template in this.TemplateOutputs.Keys) {
                OnTemplateGenerationStatus(TemplateGenerationStatusEventArgs.CreateCompiling(template));

                try {
                    templateTransformTaskMap.Add(template, CompileTemplateAsync(template));
                }
                catch (Exception ex) {
                    Generator.Logger.Error(ex);
                    OnTemplateGenerationStatus(TemplateGenerationStatusEventArgs.CreateError(template, new ApplicationException("Unable to load XSLT.", ex)));
                    break;
                }

                OnTemplateGenerationStatus(TemplateGenerationStatusEventArgs.CreateWaiting(template));
            }

            return templateTransformTaskMap;
        }

        /// <summary>Compiles the XSLT referenced by the provided template.</summary>
        private Task<XslCompiledTransform> CompileTemplateAsync(Template template) {
            if (!File.Exists(template.XsltAbsolutePath))
                throw new FileNotFoundException("The template does not exist.", template.XsltAbsolutePath);

            return Task.Run(() => CompileTemplate(template), this.CancellationTokenSource.Token);
        }

        /// <summary>Compiles the XSLT referenced by the provided template.</summary>
        private XslCompiledTransform CompileTemplate(Template template) {
            XslCompiledTransform xslTransform = new XslCompiledTransform();
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings() {
                DtdProcessing = DtdProcessing.Parse
            };

            using (XmlReader xmlReader = XmlReader.Create(template.XsltAbsolutePath, xmlReaderSettings)) {
                xslTransform.Load(xmlReader, new XsltSettings() {
                    EnableDocumentFunction = true,
                    EnableScript = true
                }, new XmlUrlResolver());
            }

            return xslTransform;
        }

        /// <summary>Processes all provided templates using the provided project XML.</summary>
        private async Task GenerateOutputsAsync(string projectXml, IDictionary<Template, Task<XslCompiledTransform>> templateTransformTaskMap) {
            var outputs = from t in this.TemplateOutputs.Keys
                          join x in templateTransformTaskMap on t equals x.Key
                          from o in this.TemplateOutputs[t]
                          select new {
                              Template = t,
                              CompiledTransformTask = x.Value,
                              Output = o
                          };

            await Task.WhenAll(outputs.Select(async o => await GenerateOutputAsync(projectXml, o.Template, await o.CompiledTransformTask, o.Output)));
        }

        /// <summary>Processes a single template to one or more output files using the provided project XML.</summary>
        private Task GenerateOutputAsync(string projectXml, Template template, XslCompiledTransform compiledTransform, TemplateOutputDefinitionFilenameResult output) {
            // Report status and do sanity checks upfront.
            OnItemGenerationStatus(ItemGenerationStatusEventArgs.CreateGenerating(template, output));

            if (File.Exists(output.Value))
            {
                try
                {
                    File.Delete(output.Value);
                }
                catch (Exception ex)
                {
                    Generator.Logger.Error(ex);
                    OnItemGenerationStatus(ItemGenerationStatusEventArgs.CreateError(template, output, new ApplicationException("Unable to delete existing file.", ex)));
                    return Task.CompletedTask;
                }
            }

            try {
                Directory.CreateDirectory(Path.GetDirectoryName(output.Value));
            }
            catch (Exception ex) {
                Generator.Logger.Error(ex);
                OnItemGenerationStatus(ItemGenerationStatusEventArgs.CreateError(template, output, new ApplicationException("Unable to create output directory.", ex)));
                return Task.CompletedTask;
            }

            // Perform the actual processing async.
            return Task.Run(() => {
                try {
                    using (StringReader stringReader = new StringReader(projectXml)) {
                        XmlReaderSettings xmlReaderSettings = new XmlReaderSettings() {
                            DtdProcessing = DtdProcessing.Parse
                        };

                        using (XmlReader xmlReader = XmlReader.Create(stringReader, xmlReaderSettings)) {
                            XsltArgumentList arguments = new XsltArgumentList();

                            arguments.AddParam(Template.Param_Name, string.Empty, template.Name);

                            if (!output.ElementName.IsNullOrEmpty())
                                arguments.AddParam(TemplateOutputDefinitionFilenameResult.Param_ElementName, string.Empty, output.ElementName);

                            using (FileStream outputStream = File.Create(output.Value))
                            using (XmlWriter xmlWriter = XmlWriter.Create(outputStream, compiledTransform.OutputSettings)) {
                                compiledTransform.Transform(xmlReader, arguments, xmlWriter);
                            }
                        }
                    }

                    PerformPostProcessing(output.Value);
                }
                catch (Exception ex) {
                    Generator.Logger.Error(ex);
                    OnItemGenerationStatus(ItemGenerationStatusEventArgs.CreateError(template, output, new ApplicationException("Unable to generate the output. Error writing to the specified path or the template or input XML is not valid.", ex)));
                    return;
                }

                OnItemGenerationStatus(ItemGenerationStatusEventArgs.CreateComplete(template, output));
            });
        }

        private void PerformPostProcessing(string path) {
            const string Group_NS = "NS";

            string content = File.ReadAllText(path);
            List<string> toRemove = new List<string>();

            foreach (Match match in Regex.Matches(content, $" xmlns:(?<{Group_NS}>.+?)=\"remove\""))
                if (match.Success)
                    toRemove.Add(match.Groups[Group_NS].Value);

            content = Regex.Replace(content, " xmlns:.+?=\"remove\"", "");

            if (!toRemove.IsNullOrEmpty())
                foreach (string remove in toRemove)
                    content = Regex.Replace(content, $" xmlns=\"{remove}\"", "");

            File.WriteAllText(path, content);
        }

        public void Cancel() {
            this.CancellationTokenSource.Cancel();
        }

        private void OnGenerationStatus(GenerationStatusEventArgs e) {
            if (GenerationStatus != null)
                GenerationStatus(this, e);
        }

        private void OnTemplateGenerationStatus(TemplateGenerationStatusEventArgs e) {
            if (TemplateGenerationStatus != null)
                TemplateGenerationStatus(this, e);
        }

        private void OnItemGenerationStatus(ItemGenerationStatusEventArgs e) {
            if (ItemGenerationStatus != null)
                ItemGenerationStatus(this, e);
        }
    }
}
