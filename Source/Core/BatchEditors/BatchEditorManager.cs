﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.CodeGenerator.Core.Utils;
using log4net;
using System.Collections;

namespace QuantumConcepts.CodeGenerator.Core.BatchEditors
{
    public class BatchEditorManager : IEnumerable<BaseBatchEditor>
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(BatchEditorManager));

        public static BatchEditorManager Instance { get; private set; }

        private Dictionary<Type, BaseBatchEditor> BatchEditorsByType { get; set; }

        public BaseBatchEditor this[Type type]
        {
            get
            {
                if (this.BatchEditorsByType.ContainsKey(type))
                    return this.BatchEditorsByType[type];

                return null;
            }
        }

        static BatchEditorManager()
        {
            BatchEditorManager.Instance = new BatchEditorManager();
        }

        private BatchEditorManager()
        {
            this.BatchEditorsByType = new Dictionary<Type, BaseBatchEditor>();
            LoadBatchEditors();
        }

        /// <summary>This method performs no operation but will cause the static initializer to fire.</summary>
        public static void Initialize() { }

        private void LoadBatchEditors()
        {
            List<string> files = new List<string>();
            Type baseBatchEditorType = typeof(BaseBatchEditor);
            List<Type> typesAdded = new List<Type>();

            files.AddRange(Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "*.dll"));
            files.AddRange(Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "*.exe"));

            this.BatchEditorsByType.Clear();

            foreach (string file in files)
            {
                Assembly assembly = null;

                try
                {
                    assembly = Assembly.LoadFrom(file);
                }
                catch (Exception ex)
                {
                    BatchEditorManager.Logger.Error("While loading batch processors, could not load assembly \"{0}\".".FormatString(file), ex);
                }

                if (assembly != null)
                {
                    foreach (Type type in assembly.GetTypes().Where(t => t != baseBatchEditorType && baseBatchEditorType.IsAssignableFrom(t)))
                    {
                        if (!typesAdded.Contains(type))
                        {
                            BaseBatchEditor instance = (BaseBatchEditor)Activator.CreateInstance(type);

                            if (instance != null)
                            {
                                this.BatchEditorsByType.Add(type, instance);
                                typesAdded.Add(type);
                            }
                        }
                    }
                }
            }
        }

        public T Get<T>()
            where T : BaseBatchEditor
        {
            return (T)this[typeof(T)];
        }

        public List<ComingledXPathExpressionResult> Calculate(Project project, ElementType elementType, string filterXPath, string valueXPath)
        {
            List<IComingledXPathExpressionPart> parts = XmlUtil.ParseComingledXPathExpression(valueXPath);
            List<ComingledXPathExpressionResult> results = XmlUtil.ComputeComingledXPathExpression(project, elementType, filterXPath, parts);

            return results;
        }

        public void Apply(BaseBatchEditor batchEditor, Project project, ElementType elementType, string filterXPath, string valueXPath)
        {
            List<ComingledXPathExpressionResult> results = Calculate(project, elementType, filterXPath, valueXPath);

            if (!results.IsNullOrEmpty())
                foreach (ComingledXPathExpressionResult result in results)
                    batchEditor.Apply(XmlUtil.GetElementForXElement(project, elementType, result.Element), result.Value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.BatchEditorsByType.GetEnumerator();
        }

        public IEnumerator<BaseBatchEditor> GetEnumerator()
        {
            return this.BatchEditorsByType.Values.GetEnumerator();
        }
    }
}
