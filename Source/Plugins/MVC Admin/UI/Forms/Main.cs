using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
using QuantumConcepts.Common.Extensions;
using QuantumConcepts.Common.Forms.UI;
using System.Collections;

namespace QuantumConcepts.CodeGenerator.Plugins.MvcAdmin.UI.Forms
{
    public partial class Main : Form
    {
        private const string Key_MvcAdmin = "MVC-Admin";
        private const string Key_DisplayName = "DisplayName";
        private const string Key_PluralDisplayName = "PluralDisplayName";
        private const string Key_MvcAdminDeletable = "MVC-Admin-Deletable";
        private const string Key_MvcAdminShow = "MVC-Admin-Show";
        private const string Key_MvcAdminIndexColumn = "MVC-Admin-Index-Column";
        private const string Key_MvcAdminIndexColumnOrder = "MVC-Admin-Index-Column-Order";
        private const string Key_MvcAdminSortable = "MVC-Admin-Sortable";
        private const string Key_MvcAdminFilterable = "MVC-Admin-Filterable";
        private const string Key_MvcAdminDataType = "MVC-Admin-DataType";

        private List<Tuple<ListViewItem, ListViewGroup>> HiddenColumnListViewItems = new List<Tuple<ListViewItem, ListViewGroup>>();

        public Main()
        {
            InitializeComponent();
        }

        private void MVC3Admin_Load(object sender, EventArgs e)
        {
            RefreshTables();
        }

        private void tablesListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            columnsListView.BeginUpdate();
            RefreshColumns(e.Item);
            columnsListView.EndUpdate();
        }

        private void tablesListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !tablesListView.SelectedItems.IsNullOrEmpty())
            {
                IEnumerable<ListViewItem> selectedItems = tablesListView.SelectedItems.Cast<ListViewItem>();

                tablesVisibleMenuItem.Checked = selectedItems.All(o => o.Checked);
                tablesDeletableMenuItem.Checked = selectedItems.All(o => string.Equals(o.SubItems[tableDeletableColumnHeader.Index].Text, bool.TrueString));

                ShowContextMenu(tablesContextMenu, e.Location, tablesListView);
            }
        }

        private void tablesEditMenuItem_Click(object sender, EventArgs e)
        {
            EditTable();
        }

        private void tablesVisibleMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in tablesListView.SelectedItems)
                item.Checked = tablesVisibleMenuItem.Checked;
        }

        private void tablesDeletableMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in tablesListView.SelectedItems)
                item.SubItems[tableDeletableColumnHeader.Index].Text = tablesDeletableMenuItem.Checked.ToString();
        }

        private void columnsListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right && !columnsListView.SelectedItems.IsNullOrEmpty())
            {
                IEnumerable<ListViewItem> selectedItems = columnsListView.SelectedItems.Cast<ListViewItem>();

                columnsVisibleMenuItem.Checked = selectedItems.All(o => o.Checked);
                columnsShowInIndexMenuItem.Checked = selectedItems.All(o => string.Equals(o.SubItems[columnShowInIndexColumnHeader.Index].Text, bool.TrueString));
                columnsFilterableMenuItem.Checked = selectedItems.All(o => string.Equals(o.SubItems[columnFilterableColumnHeader.Index].Text, bool.TrueString));
                columnsSortableMenuItem.Checked = selectedItems.All(o => string.Equals(o.SubItems[columnSortableColumnHeader.Index].Text, bool.TrueString));

                ShowContextMenu(columnsContextMenu, e.Location, columnsListView);
            }
        }

        private void columnsEditMenuItem_Click(object sender, EventArgs e)
        {
            EditColumn();
        }

        private void columnsVisibleMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in columnsListView.SelectedItems)
                item.Checked = columnsVisibleMenuItem.Checked;
        }

        private void columnsShowInIndexMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in columnsListView.SelectedItems)
                item.SubItems[columnShowInIndexColumnHeader.Index].Text = columnsShowInIndexMenuItem.Checked.ToString();
        }

        private void columnsFilterableMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in columnsListView.SelectedItems)
                item.SubItems[columnFilterableColumnHeader.Index].Text = columnsFilterableMenuItem.Checked.ToString();
        }

        private void columnsSortableMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in columnsListView.SelectedItems)
                item.SubItems[columnSortableColumnHeader.Index].Text = columnsSortableMenuItem.Checked.ToString();
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            RemoveColumnFilter();
            Save();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void RefreshTables()
        {
            using (new Wait())
            {
                tablesListView.BeginUpdate();
                columnsListView.BeginUpdate();

                ProjectContext.Project.Entities.Where(t => !t.Exclude).OrderBy(t => t.ToString()).ForEach(t =>
                {
                    bool showTable = t.Attributes.Any(a => Key_MvcAdmin.EqualsIgnoreCase(a.Key));
                    string tableDisplayName = t.Attributes.SingleOrDefault(a => Key_DisplayName.EqualsIgnoreCase(a.Key)).ValueOrDefault(a => a.Value);
                    string tablePluralDisplayName = t.Attributes.SingleOrDefault(a => Key_PluralDisplayName.EqualsIgnoreCase(a.Key)).ValueOrDefault(a => a.Value);
                    bool editable = t.Attributes.Any(a => Key_MvcAdminDeletable.EqualsIgnoreCase(a.Key));
                    ListViewItem listViewItem = new ListViewItem(new[] { t.ClassName, tableDisplayName, tablePluralDisplayName, editable.ToString() })
                    {
                        Name = t.ToString(),
                        Checked = showTable,
                        Tag = t
                    };

                    tablesListView.Items.Add(listViewItem);
                });

                columnsListView.ListViewItemSorter = new ColumnsListViewItemSorter();

                tablesListView.EndUpdate();
                columnsListView.EndUpdate();
            }
        }

        private void RefreshColumns(ListViewItem item)
        {
            Entity tableMapping = (item.Tag as Entity);

            if (tableMapping != null)
            {
                ListViewGroup group = columnsListView.Groups[tableMapping.ToString()];

                if (!item.Checked)
                {
                    if (group != null)
                    {
                        for (int i = (group.Items.Count - 1); i >= 0; i--)
                            columnsListView.Items.Remove(group.Items[i]);

                        columnsListView.Groups.Remove(group);
                    }

                    return;
                }

                if (group == null)
                {
                    group = new ListViewGroup(tableMapping.ToString(), tableMapping.ToString())
                    {
                        Tag = tableMapping
                    };
                    columnsListView.Groups.Add(group);
                }

                tableMapping.Properties.Where(c => !c.Exclude).OrderBy(c => c.ToString()).ForEach(c =>
                {
                    bool showColumn = c.Attributes.Any(a => Key_MvcAdminShow.EqualsIgnoreCase(a.Key));
                    string columnDisplayName = c.Attributes.SingleOrDefault(a => Key_DisplayName.EqualsIgnoreCase(a.Key)).ValueOrDefault(a => a.Value);
                    bool showInIndex = c.Attributes.Any(a => Key_MvcAdminIndexColumn.EqualsIgnoreCase(a.Key));
                    int? indexOrder = null;
                    bool filterable = c.Attributes.Any(a => Key_MvcAdminFilterable.EqualsIgnoreCase(a.Key));
                    bool sortable = c.Attributes.Any(a => Key_MvcAdminSortable.EqualsIgnoreCase(a.Key));
                    string dataType = c.Attributes.SingleOrDefault(a => Key_MvcAdminDataType.EqualsIgnoreCase(a.Key)).ValueOrDefault(a => a.Value);
                    ListViewItem listViewItem = (columnsListView.Items.Count > 0 ? columnsListView.FindItemWithText(c.ToString(), false, 0) : null);

                    if (c.Attributes.SingleOrDefault(a => Key_MvcAdminIndexColumnOrder.EqualsIgnoreCase(a.Key)).ValueOrDefault(a => a.Value).IsInt())
                        indexOrder = int.Parse(c.Attributes.Single(a => Key_MvcAdminIndexColumnOrder.EqualsIgnoreCase(a.Key)).Value);

                    if (listViewItem != null)
                        columnsListView.Items.Remove(listViewItem);

                    listViewItem = new ListViewItem(new[] { c.FieldName, columnDisplayName, showInIndex.ToString(), indexOrder.HasValue ? indexOrder.Value.ToString() : null, filterable.ToString(), sortable.ToString(), dataType })
                    {
                        Checked = showColumn,
                        Group = group,
                        Tag = c
                    };
                    columnsListView.Items.Add(listViewItem);
                });
            }
        }

        private void ShowContextMenu(ContextMenuStrip contextMenu, Point relativeLocation, ListView relativeTo)
        {
            Point location = relativeLocation;
            Control currentControl = relativeTo;

            while (currentControl != null)
            {
                location.X += currentControl.Location.X;
                location.Y += currentControl.Location.Y;
                currentControl = currentControl.Parent;
            }

            contextMenu.Show(location);
        }

        private void EditTable()
        {
            using (EditTable dialog = new EditTable())
            {
                List<ListViewItem> selectedItems = tablesListView.SelectedItems.Cast<ListViewItem>().ToList();

                if (columnsListView.SelectedItems.Count > 1)
                {
                    //Multiple rows were selected so set the "unanimous" values only and disable entry on "non-unanimous" values.
                    if (selectedItems.GroupBy(o => o.Checked).Count() == 1)
                        dialog.Visible = selectedItems[0].Checked;
                    else
                        dialog.VisibleEnabled = false;

                    if (selectedItems.GroupBy(o => o.SubItems[tableDisplayNameColumnHeader.Index].Text).Count() == 1)
                        dialog.DisplayName = selectedItems[0].SubItems[tableDisplayNameColumnHeader.Index].Text;
                    else
                        dialog.DisplayNameEnabled = false;

                    if (selectedItems.GroupBy(o => o.SubItems[tablePluralDisplayNameColumnHeader.Index].Text.ToBool()).Count() == 1)
                        dialog.PluralDisplayName = selectedItems[0].SubItems[tablePluralDisplayNameColumnHeader.Index].Text;
                    else
                        dialog.PluralDisplayNameEnabled = false;

                    if (selectedItems.GroupBy(o => o.SubItems[tableDeletableColumnHeader.Index].Text.ToBool()).Count() == 1)
                        dialog.Enabled = selectedItems[0].SubItems[tableDeletableColumnHeader.Index].Text.ToBool();
                    else
                        dialog.DeletableEnabled = false;
                }
                else
                {
                    dialog.Visible = selectedItems[0].Checked;
                    dialog.DisplayName = selectedItems[0].SubItems[tableDisplayNameColumnHeader.Index].Text;
                    dialog.PluralDisplayName = selectedItems[0].SubItems[tablePluralDisplayNameColumnHeader.Index].Text;
                    dialog.Deletable = selectedItems[0].SubItems[tableDeletableColumnHeader.Index].Text.ToBool();
                }

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    foreach (ListViewItem listViewItem in selectedItems)
                    {
                        listViewItem.Checked = dialog.Visible;
                        listViewItem.SubItems[tableDisplayNameColumnHeader.Index].Text = dialog.DisplayName;
                        listViewItem.SubItems[tablePluralDisplayNameColumnHeader.Index].Text = dialog.PluralDisplayName;
                        listViewItem.SubItems[tableDeletableColumnHeader.Index].Text = dialog.Deletable.ToString();
                    }
                }
            }
        }

        private void EditColumn()
        {
            using (EditColumn dialog = new EditColumn())
            {
                List<ListViewItem> selectedItems = columnsListView.SelectedItems.Cast<ListViewItem>().ToList();

                if (columnsListView.SelectedItems.Count > 1)
                {
                    //Multiple rows were selected so set the "unanimous" values only.
                    if (selectedItems.GroupBy(o => o.Checked).Count() == 1)
                        dialog.Visible = selectedItems[0].Checked;
                    else
                        dialog.VisibleEnabled = false;

                    if (selectedItems.GroupBy(o => o.SubItems[columnDisplayNameColumnHeader.Index].Text).Count() == 1)
                        dialog.DisplayName = selectedItems[0].SubItems[columnDisplayNameColumnHeader.Index].Text;
                    else
                        dialog.DisplayNameEnabled = false;

                    if (selectedItems.GroupBy(o => o.SubItems[columnShowInIndexColumnHeader.Index].Text.ToBool()).Count() == 1)
                        dialog.ShowInIndex = selectedItems[0].SubItems[columnShowInIndexColumnHeader.Index].Text.ToBool();
                    else
                        dialog.ShowInIndexEnabled = false;

                    if (selectedItems.GroupBy(o => o.SubItems[columnIndexOrderColumnHeader.Index].Text.ToNullableInt()).Count() == 1)
                        dialog.IndexOrder = selectedItems[0].SubItems[columnIndexOrderColumnHeader.Index].Text.ToNullableInt();
                    else
                        dialog.IndexOrderEnabled = false;

                    if (selectedItems.GroupBy(o => o.SubItems[columnFilterableColumnHeader.Index].Text.ToBool()).Count() == 1)
                        dialog.Filterable = selectedItems[0].SubItems[columnFilterableColumnHeader.Index].Text.ToBool();
                    else
                        dialog.FilterableEnabled = false;

                    if (selectedItems.GroupBy(o => o.SubItems[columnSortableColumnHeader.Index].Text.ToBool()).Count() == 1)
                        dialog.Sortable = selectedItems[0].SubItems[columnSortableColumnHeader.Index].Text.ToBool();
                    else
                        dialog.SortableEnabled = false;

                    if (selectedItems.GroupBy(o => o.SubItems[columnDataTypeColumnHeader.Index].Text).Count() == 1)
                        dialog.DataType = selectedItems[0].SubItems[columnDataTypeColumnHeader.Index].Text;
                    else
                        dialog.DataTypeEnabled = false;
                }
                else
                {
                    dialog.Visible = selectedItems[0].Checked;
                    dialog.DisplayName = selectedItems[0].SubItems[columnDisplayNameColumnHeader.Index].Text;
                    dialog.ShowInIndex = selectedItems[0].SubItems[columnShowInIndexColumnHeader.Index].Text.ToBool();
                    dialog.IndexOrder = selectedItems[0].SubItems[columnIndexOrderColumnHeader.Index].Text.ToNullableInt();
                    dialog.Filterable = selectedItems[0].SubItems[columnFilterableColumnHeader.Index].Text.ToBool();
                    dialog.Sortable = selectedItems[0].SubItems[columnSortableColumnHeader.Index].Text.ToBool();
                    dialog.DataType = selectedItems[0].SubItems[columnDataTypeColumnHeader.Index].Text;
                }

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (ListViewItem listViewItem in selectedItems)
                    {
                        listViewItem.Checked = dialog.Visible;
                        listViewItem.SubItems[columnDisplayNameColumnHeader.Index].Text = dialog.DisplayName;
                        listViewItem.SubItems[columnShowInIndexColumnHeader.Index].Text = dialog.ShowInIndex.ToString();
                        listViewItem.SubItems[columnIndexOrderColumnHeader.Index].Text = (dialog.IndexOrder.HasValue ? dialog.IndexOrder.Value.ToString() : null);
                        listViewItem.SubItems[columnFilterableColumnHeader.Index].Text = dialog.Filterable.ToString();
                        listViewItem.SubItems[columnSortableColumnHeader.Index].Text = dialog.Sortable.ToString();
                        listViewItem.SubItems[columnDataTypeColumnHeader.Index].Text = dialog.DataType.ToString();
                    }
                }
            }
        }

        private void ApplyColumnFilter(string filter)
        {
            RemoveColumnFilter();

            if (!filter.IsNullOrEmpty())
            {
                columnsListView.BeginUpdate();

                foreach (ListViewItem item in columnsListView.Items.Cast<ListViewItem>())
                    if (!item.Text.Contains(filter))
                        this.HiddenColumnListViewItems.Add(new Tuple<ListViewItem, ListViewGroup>(item, item.Group));

                foreach (var item in this.HiddenColumnListViewItems)
                    columnsListView.Items.Remove(item.Item1);

                columnsListView.EndUpdate();
            }
        }

        private void RemoveColumnFilter()
        {
            columnsListView.BeginUpdate();

            foreach (var item in this.HiddenColumnListViewItems)
            {
                item.Item2.Items.Add(item.Item1);
                columnsListView.Items.Add(item.Item1);
            }

            this.HiddenColumnListViewItems.Clear();

            columnsListView.EndUpdate();
        }

        private void Save()
        {
            using (new Wait())
            {
                foreach (ListViewItem item in tablesListView.Items)
                {
                    Entity tableMapping = (Entity)item.Tag;

                    RemoveAttribute(tableMapping, Key_MvcAdminDeletable);

                    if (item.Checked)
                        AddAttribute(tableMapping, Key_MvcAdmin);
                    else
                        RemoveAttribute(tableMapping, Key_MvcAdmin);

                    if (!item.SubItems[tableDisplayNameColumnHeader.Index].Text.IsNullOrEmpty())
                        AddAttribute(tableMapping, Key_DisplayName, item.SubItems[tableDisplayNameColumnHeader.Index].Text);

                    if (!item.SubItems[tablePluralDisplayNameColumnHeader.Index].Text.IsNullOrEmpty())
                        AddAttribute(tableMapping, Key_PluralDisplayName, item.SubItems[tablePluralDisplayNameColumnHeader.Index].Text);

                    if (bool.Parse(item.SubItems[tableDeletableColumnHeader.Index].Text))
                        AddAttribute(tableMapping, Key_MvcAdminDeletable);
                }

                foreach (ListViewItem item in columnsListView.Items)
                {
                    Property columnMapping = (Property)item.Tag;

                    //Remove all attributes first.
                    RemoveAttribute(columnMapping, Key_MvcAdminShow);
                    RemoveAttribute(columnMapping, Key_MvcAdminIndexColumn);
                    RemoveAttribute(columnMapping, Key_MvcAdminIndexColumnOrder);
                    RemoveAttribute(columnMapping, Key_MvcAdminSortable);
                    RemoveAttribute(columnMapping, Key_MvcAdminFilterable);
                    RemoveAttribute(columnMapping, Key_MvcAdminDataType);

                    //Add the attributes back if the item is checked.
                    if (item.Checked)
                    {
                        AddAttribute(columnMapping, Key_MvcAdminShow);

                        if (bool.Parse(item.SubItems[columnShowInIndexColumnHeader.Index].Text))
                            AddAttribute(columnMapping, Key_MvcAdminIndexColumn);

                        if (item.SubItems[columnIndexOrderColumnHeader.Index].Text.IsInt())
                            AddAttribute(columnMapping, Key_MvcAdminIndexColumnOrder, item.SubItems[columnIndexOrderColumnHeader.Index].Text);

                        if (bool.Parse(item.SubItems[columnSortableColumnHeader.Index].Text))
                            AddAttribute(columnMapping, Key_MvcAdminSortable);

                        if (bool.Parse(item.SubItems[columnFilterableColumnHeader.Index].Text))
                            AddAttribute(columnMapping, Key_MvcAdminFilterable);

                        if (!item.SubItems[columnDataTypeColumnHeader.Index].Text.IsNullOrEmpty())
                            AddAttribute(columnMapping, Key_MvcAdminDataType, item.SubItems[columnDataTypeColumnHeader.Index].Text);
                    }

                    if (!item.SubItems[columnDisplayNameColumnHeader.Index].Text.IsNullOrEmpty())
                        AddAttribute(columnMapping, Key_DisplayName, item.SubItems[columnDisplayNameColumnHeader.Index].Text);
                }
            }
        }

        private void AddAttribute<T>(IHasAttributes<T> container, string key, string value = null)
            where T : IProjectSchemaElement
        {
            Attribute<T> attribute = container.Attributes.SingleOrDefault(o => string.Equals(key, o.Key, StringComparison.InvariantCultureIgnoreCase));

            if (attribute == null)
                container.Attributes.Add(new Attribute<T>(key, value));
            else
                attribute.Value = value;
        }

        private void RemoveAttribute<T>(IHasAttributes<T> container, string key)
            where T : IProjectSchemaElement
        {
            container.Attributes.RemoveAll(new Predicate<Attribute<T>>(o => string.Equals(key, o.Key, StringComparison.InvariantCultureIgnoreCase)));
        }

        private class ColumnsListViewItemSorter : IComparer, IComparer<ListViewItem>
        {
            public int Compare(object x, object y)
            {
                return Compare(x as ListViewItem, y as ListViewItem);
            }

            public int Compare(ListViewItem x, ListViewItem y)
            {
                if (x == null && y == null)
                    return 0;
                else if (x == null)
                    return -1;
                else if (y == null)
                    return 1;
                else if (x.Group != y.Group)
                {
                    if (x.Group == null)
                        return -1;
                    else if (y.Group == null)
                        return 1;
                    else
                        return string.Compare(x.Group.Name, y.Group.Name);
                }
                else
                {
                    Property xCM = (Property)x.Tag;
                    Property yCM = (Property)y.Tag;

                    return xCM.Sequence.CompareTo(yCM.Sequence);
                }
            }
        }

        private void columnFilter_TextChanged(object sender, EventArgs e)
        {
            ApplyColumnFilter(columnFilter.Text);
        }
    }
}