using QuantumConcepts.CodeGenerator.Core.ProjectSchema;

namespace QuantumConcepts.CodeGenerator.Core.Data
{
    public class DatabaseUtil
    {
        public delegate void ProgressUpdate(string status, int itemsProcessed, int totalItems);

        public static void RefreshMappings(Project project, ProgressUpdate progressUpdate)
        {
            int currentItem = -1;
            int totalItems = (2 * project.UserSettings.Connections.Count);

            foreach (var connection in project.UserSettings.Connections){
                string description = connection.GetDescription();
                DatabaseWorker worker = DatabaseWorker.GetInstance(connection);

                if (progressUpdate != null)
                    progressUpdate($"{description}: Refreshing mappings....", ++currentItem, totalItems);

                worker.Refresh(project, connection);

                if (progressUpdate != null)
                    progressUpdate($"{description}: Sorting....", ++currentItem, totalItems);

                project.SortAll();

                if (progressUpdate != null)
                    progressUpdate($"{description}: Refresh complete.", ++currentItem, totalItems);
            } }
    }
}
