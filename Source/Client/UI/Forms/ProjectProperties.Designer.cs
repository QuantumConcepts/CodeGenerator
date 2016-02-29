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
            this.connectionTabPage = new System.Windows.Forms.TabPage();
            this.connectionOptions = new QuantumConcepts.CodeGenerator.Client.UI.Controls.ConnectionOptions();
            this.newConnectionButton = new System.Windows.Forms.Button();
            this.connectionsComboBox = new System.Windows.Forms.ComboBox();
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.showExcludedItemsCheckBox = new System.Windows.Forms.CheckBox();
            this.rootNamespaceTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.propertiesTabControl = new System.Windows.Forms.TabControl();
            this.buttonPanel.SuspendLayout();
            this.templatesListViewContextMenuStrip.SuspendLayout();
            this.dataTypesListViewContextMenuStrip.SuspendLayout();
            this.dataTypesTabPage.SuspendLayout();
            this.dataTypesToolStrip.SuspendLayout();
            this.addDataTypeGroupBox.SuspendLayout();
            this.connectionTabPage.SuspendLayout();
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
            // connectionTabPage
            // 
            this.connectionTabPage.Controls.Add(this.connectionOptions);
            this.connectionTabPage.Controls.Add(this.newConnectionButton);
            this.connectionTabPage.Controls.Add(this.connectionsComboBox);
            this.connectionTabPage.Location = new System.Drawing.Point(4, 22);
            this.connectionTabPage.Name = "connectionTabPage";
            this.connectionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.connectionTabPage.Size = new System.Drawing.Size(599, 319);
            this.connectionTabPage.TabIndex = 0;
            this.connectionTabPage.Text = "Connections";
            this.connectionTabPage.UseVisualStyleBackColor = true;
            // 
            // connectionOptions
            // 
            this.connectionOptions.Location = new System.Drawing.Point(8, 35);
            this.connectionOptions.Name = "connectionOptions";
            this.connectionOptions.SelectedTabIndex = 0;
            this.connectionOptions.Size = new System.Drawing.Size(585, 278);
            this.connectionOptions.TabIndex = 2;
            this.connectionOptions.Saved += new QuantumConcepts.CodeGenerator.Client.UI.Controls.SavedDelegate(this.connectionOptions_Saved);
            // 
            // newConnectionButton
            // 
            this.newConnectionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newConnectionButton.Location = new System.Drawing.Point(518, 7);
            this.newConnectionButton.Name = "newConnectionButton";
            this.newConnectionButton.Size = new System.Drawing.Size(75, 23);
            this.newConnectionButton.TabIndex = 1;
            this.newConnectionButton.Text = "New...";
            this.newConnectionButton.UseVisualStyleBackColor = true;
            this.newConnectionButton.Click += new System.EventHandler(this.newConnectionButton_Click);
            // 
            // connectionsComboBox
            // 
            this.connectionsComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.connectionsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.connectionsComboBox.FormattingEnabled = true;
            this.connectionsComboBox.Location = new System.Drawing.Point(8, 8);
            this.connectionsComboBox.Name = "connectionsComboBox";
            this.connectionsComboBox.Size = new System.Drawing.Size(504, 21);
            this.connectionsComboBox.TabIndex = 0;
            this.connectionsComboBox.SelectedIndexChanged += new System.EventHandler(this.connectionsComboBox_SelectedIndexChanged);
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.showExcludedItemsCheckBox);
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
            // showExcludedItemsCheckBox
            // 
            this.showExcludedItemsCheckBox.AutoSize = true;
            this.showExcludedItemsCheckBox.Location = new System.Drawing.Point(107, 32);
            this.showExcludedItemsCheckBox.Name = "showExcludedItemsCheckBox";
            this.showExcludedItemsCheckBox.Size = new System.Drawing.Size(193, 17);
            this.showExcludedItemsCheckBox.TabIndex = 24;
            this.showExcludedItemsCheckBox.Text = "&Show excluded items in project tree";
            this.showExcludedItemsCheckBox.UseVisualStyleBackColor = true;
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
            this.propertiesTabControl.Controls.Add(this.connectionTabPage);
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
            this.connectionTabPage.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage connectionTabPage;
        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.TabControl propertiesTabControl;
        private System.Windows.Forms.TextBox rootNamespaceTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStrip dataTypesToolStrip;
        private System.Windows.Forms.ToolStripDropDownButton resetToDefaultDataTypesButton;
        private System.Windows.Forms.ToolStripButton clearDataTypesButton;
        private System.Windows.Forms.CheckBox showExcludedItemsCheckBox;
        private System.Windows.Forms.Button newConnectionButton;
        private System.Windows.Forms.ComboBox connectionsComboBox;
        private Controls.ConnectionOptions connectionOptions;
    }
}