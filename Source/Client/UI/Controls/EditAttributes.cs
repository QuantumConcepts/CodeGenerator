using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Forms.Utils;
using QuantumConcepts.CodeGenerator.Client.UI.Forms;

namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    internal partial class EditAttributes<T> : UserControl
        where T : IProjectSchemaElement, IHasAttributes<T>, new()
    {
        public event EventHandler AttributeAdded;
        public event EventHandler AttributeEdited;
        public event EventHandler AttributeRemoved;
        public event EventHandler AttributeMoved;

        public IEnumerable<Attribute<T>> Attributes
        {
            get
            {
                foreach (ListViewItem lvi in attributesListView.Items)
                    yield return (Attribute<T>)lvi.Tag;
            }
            set
            {
                if (value != null)
                {
                    foreach (Attribute<T> attribute in value)
                        AddAttribute(attribute, true);
                }
            }
        }

        public EditAttributes()
        {
            InitializeComponent();
        }

        private void attributesListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            editButton.Enabled = (attributesListView.SelectedItems.Count == 1);
            removeButton.Enabled = (attributesListView.SelectedItems.Count > 0);
            moveUpButton.Enabled = (attributesListView.SelectedItems.Count == 1 && attributesListView.Items.Count > 1 && attributesListView.SelectedIndices[0] != 0);
            moveDownButton.Enabled = (attributesListView.SelectedItems.Count == 1 && attributesListView.Items.Count > 1 && attributesListView.SelectedIndices[0] != (attributesListView.Items.Count - 1));
        }

        private void attributesListView_DoubleClick(object sender, EventArgs e)
        {
            Edit();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (EditAttribute<T> dialog = new EditAttribute<T>())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    AddAttribute(dialog.Attribute, false);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            attributesListView.Items.Remove(attributesListView.SelectedItems[0]);
            OnAttributeRemoved();
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = attributesListView.SelectedIndices[0];

            ListViewUtil.SwapListViewItems(attributesListView.Items[selectedIndex - 1], attributesListView.Items[selectedIndex]);
            attributesListView.Focus();
            attributesListView.Items[selectedIndex - 1].Selected = true;

            OnAttributeMoved();
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = attributesListView.SelectedIndices[0];

            ListViewUtil.SwapListViewItems(attributesListView.Items[selectedIndex], attributesListView.Items[selectedIndex + 1]);
            attributesListView.Focus();
            attributesListView.Items[selectedIndex + 1].Selected = true;

            OnAttributeMoved();
        }

        private void AddAttribute(Attribute<T> attribute, bool suppressEvent)
        {
            ListViewItem item = new ListViewItem(attribute.Key);

            item.Tag = attribute;
            item.SubItems.Add(attribute.Value);
            attributesListView.Items.Add(item);

            if (!suppressEvent)
                OnAttributeAdded();
        }

        private void Edit()
        {
            Attribute<T> attribute = (Attribute<T>)attributesListView.SelectedItems[0].Tag;

            using (EditAttribute<T> dialog = new EditAttribute<T>(attribute))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ListViewItem item = attributesListView.SelectedItems[0];

                    item.Tag = dialog.Attribute;
                    item.Text = dialog.Attribute.Key;
                    item.SubItems[1].Text = dialog.Attribute.Value;

                    OnAttributeEdited();
                }
            }
        }

        private void OnAttributeAdded()
        {
            if (AttributeAdded != null)
                AttributeAdded(this, EventArgs.Empty);
        }

        private void OnAttributeEdited()
        {
            if (AttributeEdited != null)
                AttributeEdited(this, EventArgs.Empty);
        }

        private void OnAttributeRemoved()
        {
            if (AttributeRemoved != null)
                AttributeRemoved(this, EventArgs.Empty);
        }

        private void OnAttributeMoved()
        {
            if (AttributeMoved != null)
                AttributeMoved(this, EventArgs.Empty);
        }
    }

    internal class EditAPIAttributes : EditAttributes<API> { }
    internal class EditAPIParameterAttributes : EditAttributes<Parameter<API>> { }
    internal class EditColumnMappingAttributes : EditAttributes<ColumnMapping> { }
    internal class EditEnumerationMappingAttributes : EditAttributes<EnumerationMapping> { }
    internal class EditEnumerationValueMappingAttributes : EditAttributes<EnumerationValueMapping> { }
    internal class EditForeignKeyMappingAttributes : EditAttributes<ForeignKeyMapping> { }
    internal class EditProjectAttributes : EditAttributes<Project> { }
    internal class EditTableMappingAttributes : EditAttributes<TableMapping> { }
    internal class EditTemplateAttributes : EditAttributes<Template> { }
    internal class EditUniqueIndexMappingAttributes : EditAttributes<UniqueIndexMapping> { }
}
