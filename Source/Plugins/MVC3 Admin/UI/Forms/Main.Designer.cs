namespace QuantumConcepts.CodeGenerator.Plugins.MVC3Admin.UI.Forms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.columnsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.columnsEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.columnsVisibleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnsShowInIndexMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnsFilterableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.columnsSortableMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tablesTabPage = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.tablesListView = new System.Windows.Forms.ListView();
            this.tableNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableDisplayNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tablePluralDisplayNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnsTabPage = new System.Windows.Forms.TabPage();
            this.columnFilter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.columnsListView = new System.Windows.Forms.ListView();
            this.columnNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDisplayNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnShowInIndexColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnIndexOrderColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnFilterableColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnSortableColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDataTypeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tablesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tablesEditMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tablesVisibleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            this.columnsContextMenu.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tablesTabPage.SuspendLayout();
            this.columnsTabPage.SuspendLayout();
            this.tablesContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(732, 10);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(813, 10);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.okButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 426);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(900, 45);
            this.panel1.TabIndex = 3;
            // 
            // columnsContextMenu
            // 
            this.columnsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.columnsEditMenuItem,
            this.toolStripSeparator1,
            this.columnsVisibleMenuItem,
            this.columnsShowInIndexMenuItem,
            this.columnsFilterableMenuItem,
            this.columnsSortableMenuItem});
            this.columnsContextMenu.Name = "columnsContextMenu";
            this.columnsContextMenu.Size = new System.Drawing.Size(148, 120);
            // 
            // columnsEditMenuItem
            // 
            this.columnsEditMenuItem.Name = "columnsEditMenuItem";
            this.columnsEditMenuItem.Size = new System.Drawing.Size(147, 22);
            this.columnsEditMenuItem.Text = "&Edit";
            this.columnsEditMenuItem.Click += new System.EventHandler(this.columnsEditMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(144, 6);
            // 
            // columnsVisibleMenuItem
            // 
            this.columnsVisibleMenuItem.CheckOnClick = true;
            this.columnsVisibleMenuItem.Name = "columnsVisibleMenuItem";
            this.columnsVisibleMenuItem.Size = new System.Drawing.Size(147, 22);
            this.columnsVisibleMenuItem.Text = "&Visible";
            this.columnsVisibleMenuItem.CheckedChanged += new System.EventHandler(this.columnsVisibleMenuItem_CheckedChanged);
            // 
            // columnsShowInIndexMenuItem
            // 
            this.columnsShowInIndexMenuItem.CheckOnClick = true;
            this.columnsShowInIndexMenuItem.Name = "columnsShowInIndexMenuItem";
            this.columnsShowInIndexMenuItem.Size = new System.Drawing.Size(147, 22);
            this.columnsShowInIndexMenuItem.Text = "&Show in Index";
            this.columnsShowInIndexMenuItem.CheckedChanged += new System.EventHandler(this.columnsShowInIndexMenuItem_CheckedChanged);
            // 
            // columnsFilterableMenuItem
            // 
            this.columnsFilterableMenuItem.CheckOnClick = true;
            this.columnsFilterableMenuItem.Name = "columnsFilterableMenuItem";
            this.columnsFilterableMenuItem.Size = new System.Drawing.Size(147, 22);
            this.columnsFilterableMenuItem.Text = "&Filterable";
            this.columnsFilterableMenuItem.CheckedChanged += new System.EventHandler(this.columnsFilterableMenuItem_CheckedChanged);
            // 
            // columnsSortableMenuItem
            // 
            this.columnsSortableMenuItem.CheckOnClick = true;
            this.columnsSortableMenuItem.Name = "columnsSortableMenuItem";
            this.columnsSortableMenuItem.Size = new System.Drawing.Size(147, 22);
            this.columnsSortableMenuItem.Text = "&Sortable";
            this.columnsSortableMenuItem.CheckedChanged += new System.EventHandler(this.columnsSortableMenuItem_CheckedChanged);
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(900, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Choose the tables and columns which should be exposed in administrative controlle" +
    "rs, models and views. The MVC3 Admin templates must also be included in the proj" +
    "ect.";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tablesTabPage);
            this.tabControl.Controls.Add(this.columnsTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 20);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(900, 406);
            this.tabControl.TabIndex = 6;
            // 
            // tablesTabPage
            // 
            this.tablesTabPage.Controls.Add(this.label1);
            this.tablesTabPage.Controls.Add(this.tablesListView);
            this.tablesTabPage.Location = new System.Drawing.Point(4, 22);
            this.tablesTabPage.Name = "tablesTabPage";
            this.tablesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.tablesTabPage.Size = new System.Drawing.Size(892, 380);
            this.tablesTabPage.TabIndex = 0;
            this.tablesTabPage.Text = "Tables";
            this.tablesTabPage.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(880, 20);
            this.label1.TabIndex = 9;
            this.label1.Text = "Place a check mark next to the tables which should be exposed. Select one or more" +
    " rows and right-click for more options.";
            // 
            // tablesListView
            // 
            this.tablesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablesListView.CheckBoxes = true;
            this.tablesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tableNameColumnHeader,
            this.tableDisplayNameColumnHeader,
            this.tablePluralDisplayNameColumnHeader});
            this.tablesListView.FullRowSelect = true;
            this.tablesListView.Location = new System.Drawing.Point(6, 26);
            this.tablesListView.Name = "tablesListView";
            this.tablesListView.Size = new System.Drawing.Size(880, 348);
            this.tablesListView.TabIndex = 8;
            this.tablesListView.UseCompatibleStateImageBehavior = false;
            this.tablesListView.View = System.Windows.Forms.View.Details;
            this.tablesListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.tablesListView_ItemChecked);
            this.tablesListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tablesListView_MouseDown);
            // 
            // tableNameColumnHeader
            // 
            this.tableNameColumnHeader.Text = "Table Name (Class Name)";
            this.tableNameColumnHeader.Width = 400;
            // 
            // tableDisplayNameColumnHeader
            // 
            this.tableDisplayNameColumnHeader.Text = "Display Name";
            this.tableDisplayNameColumnHeader.Width = 150;
            // 
            // tablePluralDisplayNameColumnHeader
            // 
            this.tablePluralDisplayNameColumnHeader.Text = "Plural Display Name";
            this.tablePluralDisplayNameColumnHeader.Width = 150;
            // 
            // columnsTabPage
            // 
            this.columnsTabPage.Controls.Add(this.columnFilter);
            this.columnsTabPage.Controls.Add(this.label4);
            this.columnsTabPage.Controls.Add(this.label2);
            this.columnsTabPage.Controls.Add(this.columnsListView);
            this.columnsTabPage.Location = new System.Drawing.Point(4, 22);
            this.columnsTabPage.Name = "columnsTabPage";
            this.columnsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.columnsTabPage.Size = new System.Drawing.Size(892, 380);
            this.columnsTabPage.TabIndex = 1;
            this.columnsTabPage.Text = "Columns";
            this.columnsTabPage.UseVisualStyleBackColor = true;
            // 
            // columnFilter
            // 
            this.columnFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.columnFilter.Location = new System.Drawing.Point(786, 6);
            this.columnFilter.Name = "columnFilter";
            this.columnFilter.Size = new System.Drawing.Size(100, 20);
            this.columnFilter.TabIndex = 22;
            this.columnFilter.TextChanged += new System.EventHandler(this.columnFilter_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(748, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "Filter:";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(6, 3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(736, 30);
            this.label2.TabIndex = 20;
            this.label2.Text = "Place a check mark next to the columns which you would like to expose in administ" +
    "rative controllers, models and views. Select one or more rows and right-click fo" +
    "r more options.";
            // 
            // columnsListView
            // 
            this.columnsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.columnsListView.CheckBoxes = true;
            this.columnsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnNameColumnHeader,
            this.columnDisplayNameColumnHeader,
            this.columnShowInIndexColumnHeader,
            this.columnIndexOrderColumnHeader,
            this.columnFilterableColumnHeader,
            this.columnSortableColumnHeader,
            this.columnDataTypeColumnHeader});
            this.columnsListView.FullRowSelect = true;
            this.columnsListView.Location = new System.Drawing.Point(6, 36);
            this.columnsListView.Name = "columnsListView";
            this.columnsListView.Size = new System.Drawing.Size(880, 342);
            this.columnsListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.columnsListView.TabIndex = 19;
            this.columnsListView.UseCompatibleStateImageBehavior = false;
            this.columnsListView.View = System.Windows.Forms.View.Details;
            this.columnsListView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.columnsListView_MouseDown);
            // 
            // columnNameColumnHeader
            // 
            this.columnNameColumnHeader.Text = "Column Name (Field Name)";
            this.columnNameColumnHeader.Width = 200;
            // 
            // columnDisplayNameColumnHeader
            // 
            this.columnDisplayNameColumnHeader.Text = "Display Name";
            this.columnDisplayNameColumnHeader.Width = 100;
            // 
            // columnShowInIndexColumnHeader
            // 
            this.columnShowInIndexColumnHeader.Text = "Show in Index";
            this.columnShowInIndexColumnHeader.Width = 100;
            // 
            // columnIndexOrderColumnHeader
            // 
            this.columnIndexOrderColumnHeader.Text = "Index Order";
            this.columnIndexOrderColumnHeader.Width = 100;
            // 
            // columnFilterableColumnHeader
            // 
            this.columnFilterableColumnHeader.Text = "Filterable";
            this.columnFilterableColumnHeader.Width = 100;
            // 
            // columnSortableColumnHeader
            // 
            this.columnSortableColumnHeader.Text = "Sortable";
            this.columnSortableColumnHeader.Width = 100;
            // 
            // columnDataTypeColumnHeader
            // 
            this.columnDataTypeColumnHeader.Text = "Data Type";
            this.columnDataTypeColumnHeader.Width = 100;
            // 
            // tablesContextMenu
            // 
            this.tablesContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tablesEditMenuItem,
            this.toolStripSeparator2,
            this.tablesVisibleMenuItem});
            this.tablesContextMenu.Name = "tablesContextMenu";
            this.tablesContextMenu.Size = new System.Drawing.Size(109, 54);
            // 
            // tablesEditMenuItem
            // 
            this.tablesEditMenuItem.Name = "tablesEditMenuItem";
            this.tablesEditMenuItem.Size = new System.Drawing.Size(108, 22);
            this.tablesEditMenuItem.Text = "&Edit";
            this.tablesEditMenuItem.Click += new System.EventHandler(this.tablesEditMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(105, 6);
            // 
            // tablesVisibleMenuItem
            // 
            this.tablesVisibleMenuItem.CheckOnClick = true;
            this.tablesVisibleMenuItem.Name = "tablesVisibleMenuItem";
            this.tablesVisibleMenuItem.Size = new System.Drawing.Size(108, 22);
            this.tablesVisibleMenuItem.Text = "&Visible";
            this.tablesVisibleMenuItem.CheckedChanged += new System.EventHandler(this.tablesVisibleMenuItem_CheckedChanged);
            // 
            // Main
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(900, 471);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Main";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "MVC3 Admin";
            this.Load += new System.EventHandler(this.MVC3Admin_Load);
            this.panel1.ResumeLayout(false);
            this.columnsContextMenu.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tablesTabPage.ResumeLayout(false);
            this.columnsTabPage.ResumeLayout(false);
            this.columnsTabPage.PerformLayout();
            this.tablesContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ContextMenuStrip columnsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem columnsVisibleMenuItem;
        private System.Windows.Forms.ToolStripMenuItem columnsShowInIndexMenuItem;
        private System.Windows.Forms.ToolStripMenuItem columnsFilterableMenuItem;
        private System.Windows.Forms.ToolStripMenuItem columnsSortableMenuItem;
        private System.Windows.Forms.ToolStripMenuItem columnsEditMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tablesTabPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView tablesListView;
        private System.Windows.Forms.ColumnHeader tableNameColumnHeader;
        private System.Windows.Forms.ColumnHeader tableDisplayNameColumnHeader;
        private System.Windows.Forms.ColumnHeader tablePluralDisplayNameColumnHeader;
        private System.Windows.Forms.TabPage columnsTabPage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView columnsListView;
        private System.Windows.Forms.ColumnHeader columnNameColumnHeader;
        private System.Windows.Forms.ColumnHeader columnDisplayNameColumnHeader;
        private System.Windows.Forms.ColumnHeader columnShowInIndexColumnHeader;
        private System.Windows.Forms.ColumnHeader columnIndexOrderColumnHeader;
        private System.Windows.Forms.ColumnHeader columnFilterableColumnHeader;
        private System.Windows.Forms.ColumnHeader columnSortableColumnHeader;
        private System.Windows.Forms.ContextMenuStrip tablesContextMenu;
        private System.Windows.Forms.ToolStripMenuItem tablesEditMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tablesVisibleMenuItem;
        private System.Windows.Forms.ColumnHeader columnDataTypeColumnHeader;
        private System.Windows.Forms.TextBox columnFilter;
        private System.Windows.Forms.Label label4;

    }
}