using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuantumConcepts.DAOGenerator.Core.ProjectSchema;
using System.IO;

namespace QuantumConcepts.DAOGenerator.Client.UI.Controls
{
    public class TemplateTreeNode : ProjectSchemaNode
    {
        private Template _template;

        public new Template Template { get { return _template; } }

        public TemplateTreeNode(Template template)
        {
            _template = template;

            UpdateNode();
        }

        public override void UpdateNode()
        {
            this.Header = Path.GetFileNameWithoutExtension(_template.XsltPath);
        }
    }
}
