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
using LC = QuantumConcepts.Licensing.Client;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Threading;
using log4net;

namespace QuantumConcepts.CodeGenerator.Core
{
    internal class Generator
    {
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
        private Dictionary<Template, XslCompiledTransform> TemplateXslts { get; set; }

        public Generator(Project project) : this(project, project.Templates) { }

        public Generator(Project project, IEnumerable<Template> templates) : this(project, templates.ToDictionary(o => o, o => o.GetOutputFilenames())) { }

        public Generator(Project project, Dictionary<Template, List<TemplateOutputDefinitionFilenameResult>> templateOutputs)
        {
            if (project == null)
                throw new ArgumentNullException("project");

            if (templateOutputs.IsNullOrEmpty())
                throw new ArgumentNullException("templateOutputs");

            this.Project = project;
            this.TemplateOutputs = templateOutputs;
            this.CancellationTokenSource = new CancellationTokenSource();
            this.TemplateXslts = new Dictionary<Template, XslCompiledTransform>();
        }

        public void Generate()
        {
#if (!DEBUG)
            LC.LicenseManager.ValidateLicense();
#endif

            OnGenerationStatus(GenerationStatusEventArgs.CreateGenerating());

            ThreadPool.QueueUserWorkItem(new WaitCallback(p =>
            {
                XmlSerializer serializer = new XmlSerializer(typeof(Project));
                string projectXml = null;
                ParallelOptions parallelOptions = new ParallelOptions()
                {
                    CancellationToken = this.CancellationTokenSource.Token
                };

                try
                {
                    StringBuilder fileContent = new StringBuilder();

                    //Serialize the project to a StringBuilder.
                    using (StringWriter writer = new StringWriter(fileContent))
                    {
                        serializer.Serialize(writer, this.Project);
                    }

                    projectXml = fileContent.ToString();

                    PerformPreProcessing(projectXml);
                }
                catch (Exception ex)
                {
                    OnGenerationStatus(GenerationStatusEventArgs.CreateError(new ApplicationException("Unable to serialize the project file.", ex)));
                    return;
                }

                Parallel.ForEach(this.TemplateOutputs.Keys, parallelOptions, o =>
                {
                    XslCompiledTransform xslTransform = new XslCompiledTransform();

                    OnTemplateGenerationStatus(TemplateGenerationStatusEventArgs.CreateGenerating(o));

                    try
                    {
                        xslTransform.Load(o.XsltAbsolutePath, new XsltSettings(true, true), new XmlUrlResolver());
                    }
                    catch (Exception ex)
                    {
                        Generator.Logger.Error(ex);
                        OnTemplateGenerationStatus(TemplateGenerationStatusEventArgs.CreateError(o, new ApplicationException("Unable to load XSLT.", ex)));
                        return;
                    }

                    lock (this.TemplateXslts)
                    {
                        this.TemplateXslts.Add(o, xslTransform);
                    }

                    OnTemplateGenerationStatus(TemplateGenerationStatusEventArgs.CreateComplete(o));
                });

                Parallel.ForEach(from t in this.TemplateOutputs.Keys
                                 from o in this.TemplateOutputs[t]
                                 where this.TemplateXslts.ContainsKey(t)
                                 select new
                                 {
                                     Template = t,
                                     Output = o
                                 }, parallelOptions, o => GenerateTemplateOutput(projectXml, o.Template, o.Output));

                OnGenerationStatus(GenerationStatusEventArgs.CreateComplete());
            }), null);
        }

        private void PerformPreProcessing(string projectXml)
        {
        }

        private void GenerateTemplateOutput(string projectXml, Template template, TemplateOutputDefinitionFilenameResult output)
        {
            XslCompiledTransform xslTransform = this.TemplateXslts[template];

            OnItemGenerationStatus(ItemGenerationStatusEventArgs.CreateGenerating(template, output));

            try
            {
                if (File.Exists(output.Value))
                    File.Delete(output.Value);
            }
            catch (Exception ex)
            {
                Generator.Logger.Error(ex);
                OnItemGenerationStatus(ItemGenerationStatusEventArgs.CreateError(template, output, new ApplicationException("Unable to delete existing file.", ex)));
                return;
            }

            try
            {
                if (!Directory.Exists(Path.GetDirectoryName(output.Value)))
                    Directory.CreateDirectory(Path.GetDirectoryName(output.Value));
            }
            catch (Exception ex)
            {
                Generator.Logger.Error(ex);
                OnItemGenerationStatus(ItemGenerationStatusEventArgs.CreateError(template, output, new ApplicationException("Unable to create output directory.", ex)));
                return;
            }

            try
            {
                using (FileStream outputStream = File.Create(output.Value))
                {
                    using (StringReader stringReader = new StringReader(projectXml))
                    {
                        using (XmlReader xmlReader = XmlReader.Create(stringReader))
                        {
                            XsltArgumentList arguments = new XsltArgumentList();

                            arguments.AddParam(Template.Param_Name, string.Empty, template.Name);

                            if (!output.ElementName.IsNullOrEmpty())
                                arguments.AddParam(TemplateOutputDefinitionFilenameResult.Param_ElementName, string.Empty, output.ElementName);

                            using (XmlWriter xmlWriter = XmlWriter.Create(outputStream, xslTransform.OutputSettings))
                            {
                                xslTransform.Transform(xmlReader, arguments, xmlWriter);
                            }
                        }
                    }
                }

                PerformPostProcessing(output.Value);
            }
            catch (Exception ex)
            {
                Generator.Logger.Error(ex);
                OnItemGenerationStatus(ItemGenerationStatusEventArgs.CreateError(template, output, new ApplicationException("Unable to generate, error writing to the specified path or the template or input XML is not valid.", ex)));
                return;
            }

            OnItemGenerationStatus(ItemGenerationStatusEventArgs.CreateComplete(template, output));
        }

        private void PerformPostProcessing(string path)
        {
            string content = File.ReadAllText(path);
            List<string> toRemove = new List<string>();

            foreach (Match match in Regex.Matches(content, " xmlns:(?<NS>.+?)=\"remove\""))
                if (match.Success)
                    toRemove.Add(match.Groups["NS"].Value);

            content = Regex.Replace(content, " xmlns:.+?=\"remove\"", "");

            if (!toRemove.IsNullOrEmpty())
                foreach (string remove in toRemove)
                    content = Regex.Replace(content, " xmlns=\"{0}\"".FormatString(remove), "");

            File.WriteAllText(path, content);
        }

        public void Cancel()
        {
            this.CancellationTokenSource.Cancel();
        }

        private void OnGenerationStatus(GenerationStatusEventArgs e)
        {
            if (GenerationStatus != null)
                GenerationStatus(this, e);
        }

        private void OnTemplateGenerationStatus(TemplateGenerationStatusEventArgs e)
        {
            if (TemplateGenerationStatus != null)
                TemplateGenerationStatus(this, e);
        }

        private void OnItemGenerationStatus(ItemGenerationStatusEventArgs e)
        {
            if (ItemGenerationStatus != null)
                ItemGenerationStatus(this, e);
        }
    }
}
