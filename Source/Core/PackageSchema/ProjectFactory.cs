using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using System.IO;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.Common;

namespace QuantumConcepts.CodeGenerator.Core.PackageSchema
{
    public class ProjectFactory : IReportsProgress
    {
        public event ReportProgressEventHandler ReportProgress;

        public Project CreateProject(PackageContext packageContext)
        {
            ManifestItem projectFileManifestItem = null;
            string projectFilePath = null;
            Project project = null;
            long actionCount = 0;
            long currentAction = 0;

            this.ReportProgress("Initializing", null, null);
            actionCount += packageContext.InputResults.CountOrDefault();
            actionCount += packageContext.Package.PackageReferences.SumOrDefault(o => o.Package.Actions.CountOrDefault());
            actionCount += packageContext.Package.Actions.CountOrDefault();

            //Create the output path.
            this.ReportProgress("Validating Path", null, null);

            if (!Directory.Exists(packageContext.OutputPath))
                Directory.CreateDirectory(packageContext.OutputPath);

            //Validate the inputs.
            this.ReportProgress("Validating Inputs", null, null);

            if (!packageContext.InputResults.IsNullOrEmpty())
            {
                packageContext.InputResults.ForEach(o =>
                {
                    o.Validate();
                    this.OnReportProgress("Validating Inputs", currentAction++, actionCount);
                });
            }

            //Execute the actions.
            this.ReportProgress("Executing Actions", null, null);

            if (!packageContext.Package.PackageReferences.IsNullOrEmpty())
            {
                packageContext.Package.PackageReferences.ForEach(pr => pr.Package.Actions.ForEach(a =>
                {
                    a.Apply(packageContext);
                    this.OnReportProgress("Executing Actions", currentAction++, actionCount);
                }));
            }

            packageContext.Package.Actions.ForEach(a =>
            {
                a.Apply(packageContext);
                this.OnReportProgress("Executing Actions", currentAction++, actionCount);
            });

            this.ReportProgress("Opening Project", null, null);

            //Find the project file manifest item.
            projectFileManifestItem = packageContext.Package.GetManifestItemByID(packageContext.Package.Manifest.ProjectFileManifestItemID);

            if (projectFileManifestItem == null)
                throw new ApplicationException("Could not locate manifest item with ID \"{0}\".".FormatString(projectFileManifestItem.ID));

            //Check if the project file was renamed.
            foreach (RenameAction action in packageContext.Package.Actions.OfType<RenameAction>().Where(o => string.Equals(o.ManifestItemID, projectFileManifestItem.ID)))
                projectFilePath = ApplyAllInputReplacementsAction.Apply(packageContext, action.NewName);

            //Open the project.
            projectFilePath = Path.Combine(packageContext.GetAbsoluteOutputPath(Path.GetDirectoryName(projectFileManifestItem.RelativePath)), projectFilePath);
            project = Project.Open(projectFilePath);

            return project;
        }

        private void OnReportProgress(string message, long? current, long? total)
        {
            if (this.ReportProgress != null)
                this.ReportProgress(message, current, total);
        }
    }
}
