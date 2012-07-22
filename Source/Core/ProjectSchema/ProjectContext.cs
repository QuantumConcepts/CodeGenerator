using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QuantumConcepts.CodeGenerator.Core.ProjectSchema
{
    public static class ProjectContext
    {
        private static Project _project = null;

        public static Project Project
        {
            get
            {
                if (_project == null)
                    throw new ApplicationException("A project context has not been established.");

                return _project;
            }
        }

        public static bool Exists { get { return (_project != null); } }

        public static void Initialize(Project project)
        {
            _project = project;
        }
    }
}
