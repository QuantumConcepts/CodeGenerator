using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using System.IO;
using System.Reflection;
using QuantumConcepts.Common.Extensions;
using System.Collections;

namespace QuantumConcepts.CodeGenerator.Core.Data
{
    internal class DatabaseWorkerManager : IEnumerable<DatabaseWorker>
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(DatabaseWorkerManager));

        public static DatabaseWorkerManager Instance { get; private set; }

        private Dictionary<Type, DatabaseWorker> DatabaseWorkersByType { get; set; }
        private Dictionary<string, DatabaseWorker> DatabaseWorkersByName { get; set; }

        public DatabaseWorker this[Type type]
        {
            get
            {
                if (this.DatabaseWorkersByType.ContainsKey(type))
                    return this.DatabaseWorkersByType[type];

                return null;
            }
        }

        public DatabaseWorker this[string name]
        {
            get
            {
                if (name.IsNullOrEmpty())
                    return null;

                if (this.DatabaseWorkersByName.ContainsKey(name))
                    return this.DatabaseWorkersByName[name];

                return null;
            }
        }

        static DatabaseWorkerManager()
        {
            DatabaseWorkerManager.Instance = new DatabaseWorkerManager();
        }

        private DatabaseWorkerManager()
        {
            this.DatabaseWorkersByType = new Dictionary<Type, DatabaseWorker>();
            this.DatabaseWorkersByName = new Dictionary<string, DatabaseWorker>();
            LoadDatabaseWorkers();
        }

        /// <summary>This method performs no operation but will cause the static initializer to fire.</summary>
        public static void Initialize() { }

        private void LoadDatabaseWorkers()
        {
            List<string> files = new List<string>();
            Type baseType = typeof(DatabaseWorker);
            List<Type> typesAdded = new List<Type>();

            files.AddRange(Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "*.dll").ToList());
            files.AddRange(Directory.GetFiles(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "*.exe").ToList());

            this.DatabaseWorkersByType.Clear();
            this.DatabaseWorkersByName.Clear();

            foreach (string file in files)
            {
                Assembly assembly = null;

                try
                {
                    assembly = Assembly.LoadFrom(file);
                }
                catch (Exception ex)
                {
                    DatabaseWorkerManager.Logger.Error("While loading database workers, could not load assembly \"{0}\".".FormatString(file), ex);
                }

                if (assembly != null)
                {
                    foreach (Type type in assembly.GetTypes().Where(t => t != baseType && baseType.IsAssignableFrom(t)))
                    {
                        if (!typesAdded.Contains(type))
                        {
                            DatabaseWorker instance = (DatabaseWorker)Activator.CreateInstance(type);

                            if (instance != null)
                            {
                                this.DatabaseWorkersByType.Add(type, instance);
                                this.DatabaseWorkersByName.Add(instance.Name, instance);
                                typesAdded.Add(type);
                            }
                        }
                    }
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.DatabaseWorkersByType.GetEnumerator();
        }

        public IEnumerator<DatabaseWorker> GetEnumerator()
        {
            return this.DatabaseWorkersByType.Values.GetEnumerator();
        }
    }
}