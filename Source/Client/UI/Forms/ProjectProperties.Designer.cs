namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    partial class ProjectProperties
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProjectProperties));
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.closeButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.templatesListViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteTemplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataTypesListViewContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteDataTypeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataTypesTabPage = new System.Windows.Forms.TabPage();
            this.dataTypesToolStrip = new System.Windows.Forms.ToolStrip();
            this.resetToDefaultDataTypesButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.clearDataTypesButton = new System.Windows.Forms.ToolStripButton();
            this.addDataTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.addDataTypeNullableCheckBox = new System.Windows.Forms.CheckBox();
            this.addDataTypeSaveButton = new System.Windows.Forms.Button();
            this.addDataTypeApplicationDataTypeTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.addDataTypeDatabaseDataTypeTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataTypesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.databaseTabPage = new System.Windows.Forms.TabPage();
            this.databaseParametersGridView = new System.Windows.Forms.DataGridView();
            this.databaseParametersNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.databaseParametersValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.databaseConnectionStringTextBox = new System.Windows.Forms.TextBox();
            this.databaseTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.rootNamespaceTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.propertiesTabControl = new System.Windows.Forms.TabControl();
            this.buttonPanel.SuspendLayout();
            this.templatesListViewContextMenuStrip.SuspendLayout();
            this.dataTypesListViewContextMenuStrip.SuspendLayout();
            this.dataTypesTabPage.SuspendLayout();
            this.dataTypesToolStrip.SuspendLayout();
            this.addDataTypeGroupBox.SuspendLayout();
            this.databaseTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseParametersGridView)).BeginInit();
            this.generalTabPage.SuspendLayout();
            this.propertiesTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.closeButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonPanel.Location = new System.Drawing.Point(0, 345);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(607, 37);
            this.buttonPanel.TabIndex = 1;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(522, 6);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 13;
            this.closeButton.Text = "C&lose";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // templatesListViewContextMenuStrip
            // 
            this.templatesListViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteTemplateToolStripMenuItem});
            this.templatesListViewContextMenuStrip.Name = "templatesListViewContextMenuStrip";
            this.templatesListViewContextMenuStrip.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteTemplateToolStripMenuItem
            // 
            this.deleteTemplateToolStripMenuItem.Name = "deleteTemplateToolStripMenuItem";
            this.deleteTemplateToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteTemplateToolStripMenuItem.Text = "Delete";
            // 
            // dataTypesListViewContextMenuStrip
            // 
            this.dataTypesListViewContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteDataTypeToolStripMenuItem});
            this.dataTypesListViewContextMenuStrip.Name = "templatesListViewContextMenuStrip";
            this.dataTypesListViewContextMenuStrip.Size = new System.Drawing.Size(108, 26);
            // 
            // deleteDataTypeToolStripMenuItem
            // 
            this.deleteDataTypeToolStripMenuItem.Name = "deleteDataTypeToolStripMenuItem";
            this.deleteDataTypeToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.deleteDataTypeToolStripMenuItem.Text = "Delete";
            this.deleteDataTypeToolStripMenuItem.Click += new System.EventHandler(this.deleteDataTypeToolStripMenuItem_Click);
            // 
            // dataTypesTabPage
            // 
            this.dataTypesTabPage.Controls.Add(this.dataTypesToolStrip);
            this.dataTypesTabPage.Controls.Add(this.addDataTypeGroupBox);
            this.dataTypesTabPage.Controls.Add(this.dataTypesListView);
            this.dataTypesTabPage.Location = new System.Drawing.Point(4, 22);
            this.dataTypesTabPage.Name = "dataTypesTabPage";
            this.dataTypesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.dataTypesTabPage.Size = new System.Drawing.Size(599, 319);
            this.dataTypesTabPage.TabIndex = 2;
            this.dataTypesTabPage.Text = "Data Types";
            this.dataTypesTabPage.UseVisualStyleBackColor = true;
            // 
            // dataTypesToolStrip
            // 
            this.dataTypesToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToDefaultDataTypesButton,
            this.clearDataTypesButton});
            this.dataTypesToolStrip.Location = new System.Drawing.Point(3, 3);
            this.dataTypesToolStrip.Name = "dataTypesToolStrip";
            this.dataTypesToolStrip.Size = new System.Drawing.Size(593, 25);
            this.dataTypesToolStrip.TabIndex = 10;
            this.dataTypesToolStrip.Text = "toolStrip1";
            // 
            // resetToDefaultDataTypesButton
            // 
            this.resetToDefaultDataTypesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.resetToDefaultDataTypesButton.Image = ((System.Drawing.Image)(resources.GetObject("resetToDefaultDataTypesButton.Image")));
            this.resetToDefaultDataTypesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.resetToDefaultDataTypesButton.Name = "resetToDefaultDataTypesButton";
            this.resetToDefaultDataTypesButton.Size = new System.Drawing.Size(103, 22);
            this.resetToDefaultDataTypesButton.Text = "Reset to Default";
            // 
            // clearDataTypesButton
            // 
            this.clearDataTypesButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.clearDataTypesButton.Image = ((System.Drawing.Image)(resources.GetObject("clearDataTypesButton.Image")));
            this.clearDataTypesButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.clearDataTypesButton.Name = "clearDataTypesButton";
            this.clearDataTypesButton.Size = new System.Drawing.Size(38, 22);
            this.clearDataTypesButton.Text = "Clear";
            this.clearDataTypesButton.Click += new System.EventHandler(this.clearDataTypesButton_Click);
            // 
            // addDataTypeGroupBox
            // 
            this.addDataTypeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addDataTypeGroupBox.Controls.Add(this.addDataTypeNullableCheckBox);
            this.addDataTypeGroupBox.Controls.Add(this.addDataTypeSaveButton);
            this.addDataTypeGroupBox.Controls.Add(this.addDataTypeApplicationDataTypeTextBox);
            this.addDataTypeGroupBox.Controls.Add(this.label5);
            this.addDataTypeGroupBox.Controls.Add(this.addDataTypeDatabaseDataTypeTextBox);
            this.addDataTypeGroupBox.Controls.Add(this.label4);
            this.addDataTypeGroupBox.Location = new System.Drawing.Point(6, 213);
            this.addDataTypeGroupBox.Name = "addDataTypeGroupBox";
            this.addDataTypeGroupBox.Size = new System.Drawing.Size(587, 100);
            this.addDataTypeGroupBox.TabIndex = 1;
            this.addDataTypeGroupBox.TabStop = false;
            this.addDataTypeGroupBox.Text = "Add/Edit Data Type";
            // 
            // addDataTypeNullableCheckBox
            // 
            this.addDataTypeNullableCheckBox.AutoSize = true;
            this.addDataTypeNullableCheckBox.Location = new System.Drawing.Point(127, 72);
            this.addDataTypeNullableCheckBox.Name = "addDataTypeNullableCheckBox";
            this.addDataTypeNullableCheckBox.Size = new System.Drawing.Size(64, 17);
            this.addDataTypeNullableCheckBox.TabIndex = 7;
            this.addDataTypeNullableCheckBox.Text = "Nullable";
            this.addDataTypeNullableCheckBox.UseVisualStyleBackColor = true;
            // 
            // addDataTypeSaveButton
            // 
            this.addDataTypeSaveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addDataTypeSaveButton.Location = new System.Drawing.Point(506, 72);
            this.addDataTypeSaveButton.Name = "addDataTypeSaveButton";
            this.addDataTypeSaveButton.Size = new System.Drawing.Size(75, 23);
            this.addDataTypeSaveButton.TabIndex = 6;
            this.addDataTypeSaveButton.Text = "Save";
            this.addDataTypeSaveButton.UseVisualStyleBackColor = true;
            this.addDataTypeSaveButton.Click += new System.EventHandler(this.addDataTypeSaveButton_Click);
            // 
            // addDataTypeApplicationDataTypeTextBox
            // 
            this.addDataTypeApplicationDataTypeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addDataTypeApplicationDataTypeTextBox.Location = new System.Drawing.Point(127, 46);
            this.addDataTypeApplicationDataTypeTextBox.Name = "addDataTypeApplicationDataTypeTextBox";
            this.addDataTypeApplicationDataTypeTextBox.Size = new System.Drawing.Size(454, 20);
            this.addDataTypeApplicationDataTypeTextBox.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 49);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Application Data Type:";
            // 
            // addDataTypeDatabaseDataTypeTextBox
            // 
            this.addDataTypeDatabaseDataTypeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addDataTypeDatabaseDataTypeTextBox.Location = new System.Drawing.Point(127, 19);
            this.addDataTypeDatabaseDataTypeTextBox.Name = "addDataTypeDatabaseDataTypeTextBox";
            this.addDataTypeDatabaseDataTypeTextBox.Size = new System.Drawing.Size(454, 20);
            this.addDataTypeDatabaseDataTypeTextBox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Database Data Type:";
            // 
            // dataTypesListView
            // 
            this.dataTypesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataTypesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.dataTypesListView.ContextMenuStrip = this.dataTypesListViewContextMenuStrip;
            this.dataTypesListView.FullRowSelect = true;
            this.dataTypesListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.dataTypesListView.Location = new System.Drawing.Point(6, 31);
            this.dataTypesListView.MultiSelect = false;
            this.dataTypesListView.Name = "dataTypesListView";
            this.dataTypesListView.Size = new System.Drawing.Size(587, 145);
            this.dataTypesListView.TabIndex = 0;
            this.dataTypesListView.UseCompatibleStateImageBehavior = false;
            this.dataTypesListView.View = System.Windows.Forms.View.Details;
            this.dataTypesListView.SelectedIndexChanged += new System.EventHandler(this.dataTypesListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Database Data Type";
            this.columnHeader1.Width = 262;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Application Data Type";
            this.columnHeader2.Width = 262;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Nullable?";
            this.columnHeader3.Width = 59;
            // 
            // databaseTabPage
            // 
            this.databaseTabPage.Controls.Add(this.databaseParametersGridView);
            this.databaseTabPage.Controls.Add(this.databaseConnectionStringTextBox);
            this.databaseTabPage.Controls.Add(this.databaseTypeComboBox);
            this.databaseTabPage.Controls.Add(this.label1);
            this.databaseTabPage.Controls.Add(this.label9);
            this.databaseTabPage.Controls.Add(this.label11);
            this.databaseTabPage.Location = new System.Drawing.Point(4, 22);
            this.databaseTabPage.Name = "databaseTabPage";
            this.databaseTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.databaseTabPage.Size = new System.Drawing.Size(599, 319);
            this.databaseTabPage.TabIndex = 0;
            this.databaseTabPage.Text = "Database";
            this.databaseTabPage.UseVisualStyleBackColor = true;
            // 
            // databaseParametersGridView
            // 
            this.databaseParametersGridView.AllowUserToAddRows = false;
            this.databaseParametersGridView.AllowUserToDeleteRows = false;
            this.databaseParametersGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.databaseParametersGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.databaseParametersGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.databaseParametersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.databaseParametersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.databaseParametersNameColumn,
            this.databaseParametersValueColumn});
            this.databaseParametersGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.databaseParametersGridView.Location = new System.Drawing.Point(108, 139);
            this.databaseParametersGridView.MultiSelect = false;
            this.databaseParametersGridView.Name = "databaseParametersGridView";
            this.databaseParametersGridView.ShowCellErrors = false;
            this.databaseParametersGridView.ShowEditingIcon = false;
            this.databaseParametersGridView.ShowRowErrors = false;
            this.databaseParametersGridView.Size = new System.Drawing.Size(483, 174);
            this.databaseParametersGridView.TabIndex = 0;
            this.databaseParametersGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.databaseParametersGridView_CellValueChanged);
            // 
            // databaseParametersNameColumn
            // 
            this.databaseParametersNameColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.databaseParametersNameColumn.Frozen = true;
            this.databaseParametersNameColumn.HeaderText = "Name";
            this.databaseParametersNameColumn.Name = "databaseParametersNameColumn";
            this.databaseParametersNameColumn.ReadOnly = true;
            // 
            // databaseParametersValueColumn
            // 
            this.databaseParametersValueColumn.HeaderText = "Value";
            this.databaseParametersValueColumn.Name = "databaseParametersValueColumn";
            this.databaseParametersValueColumn.Width = 300;
            // 
            // databaseConnectionStringTextBox
            // 
            this.databaseConnectionStringTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.databaseConnectionStringTextBox.Location = new System.Drawing.Point(108, 33);
            this.databaseConnectionStringTextBox.Multiline = true;
            this.databaseConnectionStringTextBox.Name = "databaseConnectionStringTextBox";
            this.databaseConnectionStringTextBox.Size = new System.Drawing.Size(483, 100);
            this.databaseConnectionStringTextBox.TabIndex = 2;
            // 
            // databaseTypeComboBox
            // 
            this.databaseTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.databaseTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.databaseTypeComboBox.FormattingEnabled = true;
            this.databaseTypeComboBox.Location = new System.Drawing.Point(108, 6);
            this.databaseTypeComboBox.Name = "databaseTypeComboBox";
            this.databaseTypeComboBox.Size = new System.Drawing.Size(483, 21);
            this.databaseTypeComboBox.TabIndex = 1;
            this.databaseTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.databaseType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 139);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Parameters:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 36);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 13);
            this.label9.TabIndex = 12;
            this.label9.Text = "Connection String:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 13;
            this.label11.Text = "Database Type:";
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.rootNamespaceTextBox);
            this.generalTabPage.Controls.Add(this.label2);
            this.generalTabPage.Location = new System.Drawing.Point(4, 22);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalTabPage.Size = new System.Drawing.Size(599, 319);
            this.generalTabPage.TabIndex = 3;
            this.generalTabPage.Text = "General";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // rootNamespaceTextBox
            // 
            this.rootNamespaceTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rootNamespaceTextBox.Location = new System.Drawing.Point(107, 6);
            this.rootNamespaceTextBox.Name = "rootNamespaceTextBox";
            this.rootNamespaceTextBox.Size = new System.Drawing.Size(486, 20);
            this.rootNamespaceTextBox.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "Root Namespace:";
            // 
            // propertiesTabControl
            // 
            this.propertiesTabControl.Controls.Add(this.generalTabPage);
            this.propertiesTabControl.Controls.Add(this.databaseTabPage);
            this.propertiesTabControl.Controls.Add(this.dataTypesTabPage);
            this.propertiesTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertiesTabControl.Location = new System.Drawing.Point(0, 0);
            this.propertiesTabControl.Name = "propertiesTabControl";
            this.propertiesTabControl.SelectedIndex = 0;
            this.propertiesTabControl.Size = new System.Drawing.Size(607, 345);
            this.propertiesTabControl.TabIndex = 2;
            // 
            // ProjectProperties
            // 
            this.AcceptButton = this.closeButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 382);
            this.Controls.Add(this.propertiesTabControl);
            this.Controls.Add(this.buttonPanel);
            this.Name = "ProjectProperties";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Project Properties";
            this.buttonPanel.ResumeLayout(false);
            this.templatesListViewContextMenuStrip.ResumeLayout(false);
            this.dataTypesListViewContextMenuStrip.ResumeLayout(false);
            this.dataTypesTabPage.ResumeLayout(false);
            this.dataTypesTabPage.PerformLayout();
            this.dataTypesToolStrip.ResumeLayout(false);
            this.dataTypesToolStrip.PerformLayout();
            this.addDataTypeGroupBox.ResumeLayout(false);
            this.addDataTypeGroupBox.PerformLayout();
            this.databaseTabPage.ResumeLayout(false);
            this.databaseTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.databaseParametersGridView)).EndInit();
            this.generalTabPage.ResumeLayout(false);
            this.generalTabPage.PerformLayout();
            this.propertiesTabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ContextMenuStrip templatesListViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteTemplateToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip dataTypesListViewContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem deleteDataTypeToolStripMenuItem;
        private System.Windows.Forms.TabPage dataTypesTabPage;
        private System.Windows.Forms.GroupBox addDataTypeGroupBox;
        private System.Windows.Forms.CheckBox addDataTypeNullableCheckBox;
        private System.Windows.Forms.Button addDataTypeSaveButton;
        private System.Windows.Forms.TextBox addDataTypeApplicationDataTypeTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox addDataTypeDatabaseDataTypeTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView dataTypesListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.TabPage databaseTabPage;
        private System.Windows.Forms.TextBox databaseConnectionStringTextBox;
        private System.Windows.Forms.ComboBox databaseTypeComboBox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.TabControl propertiesTabControl;
        private System.Windows.Forms.TextBox rootNamespaceTextBox;
        private System.Windows.Forms.Label label2;
        private Controls.EditProjectAttributes editAttributes;
        private System.Windows.Forms.ToolStrip dataTypesToolStrip;
        private System.Windows.Forms.ToolStripDropDownButton resetToDefaultDataTypesButton;
        private System.Windows.Forms.ToolStripButton clearDataTypesButton;
        private System.Windows.Forms.DataGridView databaseParametersGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn databaseParametersNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn databaseParametersValueColumn;
    }
}