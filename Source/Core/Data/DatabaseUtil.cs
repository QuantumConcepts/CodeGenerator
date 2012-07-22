using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Configuration;

namespace QuantumConcepts.CodeGenerator.Core.Data
{
    internal class DatabaseUtil
    {
        public delegate void ProgressUpdate(string status, int itemsProcessed, int totalItems);

        public static void RefreshMappings(Project project, ProgressUpdate progressUpdate)
        {
            DatabaseWorker worker = DatabaseWorker.GetInstance(project);

            if (progressUpdate != null)
                progressUpdate("Refreshing mappings....", 0, 0);

            worker.Refresh(project);

            if (progressUpdate != null)
                progressUpdate("Sorting....", 0, 0);

            project.SortAll();

            if (progressUpdate != null)
                progressUpdate("Refresh complete.", 0, 0);
        }
    }
}