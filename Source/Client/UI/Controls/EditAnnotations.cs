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
    internal partial class EditAnnotations<T> : UserControl
        where T : IProjectSchemaElement, IHasAnnotations<T>, new()
    {
        public event EventHandler AnnotationAdded;
        public event EventHandler AnnotationEdited;
        public event EventHandler AnnotationRemoved;
        public event EventHandler AnnotationMoved;

        public IEnumerable<Annotation<T>> Annotations
        {
            get
            {
                foreach (ListViewItem lvi in annotationsListView.Items)
                    yield return (Annotation<T>)lvi.Tag;
            }
            set
            {
                if (value != null)
                {
                    foreach (Annotation<T> annotation in value)
                        AddAnnotation(annotation, true);
                }
            }
        }

        public EditAnnotations()
        {
            InitializeComponent();
        }

        private void annotationsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            editButton.Enabled = (annotationsListView.SelectedItems.Count == 1);
            removeButton.Enabled = (annotationsListView.SelectedItems.Count > 0);
            moveUpButton.Enabled = (annotationsListView.SelectedItems.Count == 1 && annotationsListView.Items.Count > 1 && annotationsListView.SelectedIndices[0] != 0);
            moveDownButton.Enabled = (annotationsListView.SelectedItems.Count == 1 && annotationsListView.Items.Count > 1 && annotationsListView.SelectedIndices[0] != (annotationsListView.Items.Count - 1));
        }

        private void annotationsListView_DoubleClick(object sender, EventArgs e)
        {
            Edit();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (EditAnnotation<T> dialog = new EditAnnotation<T>())
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                    AddAnnotation(dialog.Annotation, false);
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            Edit();
        }

        private void removeButton_Click(object sender, EventArgs e)
        {
            annotationsListView.Items.Remove(annotationsListView.SelectedItems[0]);
            OnAnnotationRemoved();
        }

        private void moveUpButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = annotationsListView.SelectedIndices[0];

            ListViewUtil.SwapListViewItems(annotationsListView.Items[selectedIndex - 1], annotationsListView.Items[selectedIndex]);
            annotationsListView.Focus();
            annotationsListView.Items[selectedIndex - 1].Selected = true;

            OnAnnotationMoved();
        }

        private void moveDownButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = annotationsListView.SelectedIndices[0];

            ListViewUtil.SwapListViewItems(annotationsListView.Items[selectedIndex], annotationsListView.Items[selectedIndex + 1]);
            annotationsListView.Focus();
            annotationsListView.Items[selectedIndex + 1].Selected = true;

            OnAnnotationMoved();
        }

        private void AddAnnotation(Annotation<T> annotation, bool suppressEvent)
        {
            ListViewItem item = new ListViewItem(annotation.Type);

            item.Tag = annotation;
            item.SubItems.Add(annotation.Text);
            annotationsListView.Items.Add(item);

            if (!suppressEvent)
                OnAnnotationAdded();
        }

        private void Edit()
        {
            Annotation<T> annotation = (Annotation<T>)annotationsListView.SelectedItems[0].Tag;

            using (EditAnnotation<T> dialog = new EditAnnotation<T>(annotation))
            {
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    ListViewItem item = annotationsListView.SelectedItems[0];

                    item.Tag = dialog.Annotation;
                    item.Text = dialog.Annotation.Type;
                    item.SubItems[1].Text = dialog.Annotation.Text;

                    OnAnnotationEdited();
                }
            }
        }

        private void OnAnnotationAdded()
        {
            if (AnnotationAdded != null)
                AnnotationAdded(this, EventArgs.Empty);
        }

        private void OnAnnotationEdited()
        {
            if (AnnotationEdited != null)
                AnnotationEdited(this, EventArgs.Empty);
        }

        private void OnAnnotationRemoved()
        {
            if (AnnotationRemoved != null)
                AnnotationRemoved(this, EventArgs.Empty);
        }

        private void OnAnnotationMoved()
        {
            if (AnnotationMoved != null)
                AnnotationMoved(this, EventArgs.Empty);
        }
    }

    internal class EditAPIAnnotations : EditAnnotations<API> { }
    internal class EditAPIParameterAnnotations : EditAnnotations<Parameter<API>> { }
    internal class EditColumnMappingAnnotations : EditAnnotations<ColumnMapping> { }
    internal class EditEnumerationMappingAnnotations : EditAnnotations<EnumerationMapping> { }
    internal class EditEnumerationValueMappingAnnotations : EditAnnotations<EnumerationValueMapping> { }
    internal class EditForeignKeyMappingAnnotations : EditAnnotations<ForeignKeyMapping> { }
    internal class EditTableMappingAnnotations : EditAnnotations<TableMapping> { }
    internal class EditUniqueIndexMappingAnnotations : EditAnnotations<UniqueIndexMapping> { }
}
