using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Xsl;

namespace QuantumConcepts.CodeGenerator.Core.Generation
{
    public class XslTemplateGenerator : BaseGenerator
    {
        public override async Task GenerateAsync()
        {
            Task<string> projectXml = null;
            IDictionary<Template, Task<XslCompiledTransform>> templateTransformTaskMap = null;

            OnGenerationStatus(GenerationStatusEventArgs.CreateGenerating());

            projectXml = SerializeProjectAsync();
            templateTransformTaskMap = GetTemplateCompilationTaskMap();
            await GenerateOutputsAsync(await projectXml, templateTransformTaskMap);

            OnGenerationStatus(GenerationStatusEventArgs.CreateComplete());
        }

        /// <summary>Serializes the project to XML.</summary>
        private Task<string> SerializeProjectAsync()
        {
            return Task.Run(() =>
            {
                try
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(Project));
                    StringBuilder fileContent = new StringBuilder();

                    using (StringWriter writer = new StringWriter(fileContent))
                        serializer.Serialize(writer, this.Project);

                    return fileContent.ToString();
                }
                catch (Exception ex)
                {
                    OnGenerationStatus(GenerationStatusEventArgs.CreateError(new ApplicationException("Unable to serialize the project file.", ex)));
                    return null;
                }
            }, this.CancellationTokenSource.Token);
        }

        /// <summary>Compiles the referenced XSLT for all templates.</summary>
        private IDictionary<Template, Task<XslCompiledTransform>> GetTemplateCompilationTaskMap()
        {
            IDictionary<Template, Task<XslCompiledTransform>> templateTransformTaskMap = new ConcurrentDictionary<Template, Task<XslCompiledTransform>>();

            foreach (Template template in this.TemplateOutputs.Keys)
            {
                OnTemplateGenerationStatus(TemplateGenerationStatusEventArgs.CreateCompiling(template));

                try
                {
                    templateTransformTaskMap.Add(template, CompileTemplateAsync(template));
                }
                catch (Exception ex)
                {
                    GenerationContext.Logger.Error(ex);
                    OnTemplateGenerationStatus(TemplateGenerationStatusEventArgs.CreateError(template, new ApplicationException("Unable to load XSLT.", ex)));
                    break;
                }

                OnTemplateGenerationStatus(TemplateGenerationStatusEventArgs.CreateWaiting(template));
            }

            return templateTransformTaskMap;
        }

        /// <summary>Compiles the XSLT referenced by the provided template.</summary>
        private Task<XslCompiledTransform> CompileTemplateAsync(Template template)
        {
            if (!File.Exists(template.XsltAbsolutePath))
                throw new FileNotFoundException("The template does not exist.", template.XsltAbsolutePath);

            return Task.Run(() => CompileTemplate(template), this.CancellationTokenSource.Token);
        }

        /// <summary>Compiles the XSLT referenced by the provided template.</summary>
        private XslCompiledTransform CompileTemplate(Template template)
        {
            XslCompiledTransform xslTransform = new XslCompiledTransform();
            XmlReaderSettings xmlReaderSettings = new XmlReaderSettings()
            {
                DtdProcessing = DtdProcessing.Parse
            };

            using (XmlReader xmlReader = XmlReader.Create(template.XsltAbsolutePath, xmlReaderSettings))
            {
                xslTransform.Load(xmlReader, new XsltSettings()
                {
                    EnableDocumentFunction = true,
                    EnableScript = true
                }, new XmlUrlResolver());
            }

            return xslTransform;
        }

        /// <summary>Processes all provided templates using the provided project XML.</summary>
        private async Task GenerateOutputsAsync(string projectXml, IDictionary<Template, Task<XslCompiledTransform>> templateTransformTaskMap)
        {
            var outputs = from t in this.TemplateOutputs.Keys
                          join x in templateTransformTaskMap on t equals x.Key
                          from o in this.TemplateOutputs[t]
                          select new
                          {
                              Template = t,
                              CompiledTransformTask = x.Value,
                              Output = o
                          };

            await Task.WhenAll(outputs.Select(async o => await GenerateOutputAsync(projectXml, o.Template, await o.CompiledTransformTask, o.Output)));
        }

        /// <summary>Processes a single template to one or more output files using the provided project XML.</summary>
        private Task GenerateOutputAsync(string projectXml, Template template, XslCompiledTransform compiledTransform, TemplateOutputDefinitionFilenameResult output)
        {
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
                    GenerationContext.Logger.Error(ex);
                    OnItemGenerationStatus(ItemGenerationStatusEventArgs.CreateError(template, output, new ApplicationException("Unable to delete existing file.", ex)));
                    return Task.CompletedTask;
                }
            }

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(output.Value));
            }
            catch (Exception ex)
            {
                GenerationContext.Logger.Error(ex);
                OnItemGenerationStatus(ItemGenerationStatusEventArgs.CreateError(template, output, new ApplicationException("Unable to create output directory.", ex)));
                return Task.CompletedTask;
            }

            // Perform the actual processing async.
            return Task.Run(() => {
                try
                {
                    using (StringReader stringReader = new StringReader(projectXml))
                    {
                        XmlReaderSettings xmlReaderSettings = new XmlReaderSettings()
                        {
                            DtdProcessing = DtdProcessing.Parse
                        };

                        using (XmlReader xmlReader = XmlReader.Create(stringReader, xmlReaderSettings))
                        {
                            XsltArgumentList arguments = new XsltArgumentList();

                            arguments.AddParam(Template.Param_Name, string.Empty, template.Name);

                            if (!output.ElementName.IsNullOrEmpty())
                                arguments.AddParam(TemplateOutputDefinitionFilenameResult.Param_ElementName, string.Empty, output.ElementName);

                            using (FileStream outputStream = File.Create(output.Value))
                            using (XmlWriter xmlWriter = XmlWriter.Create(outputStream, compiledTransform.OutputSettings))
                            {
                                compiledTransform.Transform(xmlReader, arguments, xmlWriter);
                            }
                        }
                    }

                    PerformPostProcessing(output.Value);
                }
                catch (Exception ex)
                {
                    GenerationContext.Logger.Error(ex);
                    OnItemGenerationStatus(ItemGenerationStatusEventArgs.CreateError(template, output, new ApplicationException("Unable to generate the output. Error writing to the specified path or the template or input XML is not valid.", ex)));
                    return;
                }

                OnItemGenerationStatus(ItemGenerationStatusEventArgs.CreateComplete(template, output));
            });
        }

        private void PerformPostProcessing(string path)
        {
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
    }
}
