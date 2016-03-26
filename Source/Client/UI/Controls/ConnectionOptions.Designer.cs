namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    partial class ConnectionOptions
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.parametersGridView = new System.Windows.Forms.DataGridView();
            this.databaseParametersNameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.databaseParametersValueColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.connectionStringTextBox = new System.Windows.Forms.TextBox();
            this.typeComboBox = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabs = new System.Windows.Forms.TabControl();
            this.connectionStringTab = new System.Windows.Forms.TabPage();
            this.parametersTab = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.parametersGridView)).BeginInit();
            this.tabs.SuspendLayout();
            this.connectionStringTab.SuspendLayout();
            this.parametersTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // parametersGridView
            // 
            this.parametersGridView.AllowUserToAddRows = false;
            this.parametersGridView.AllowUserToDeleteRows = false;
            this.parametersGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.parametersGridView.BackgroundColor = System.Drawing.SystemColors.Window;
            this.parametersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.parametersGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.databaseParametersNameColumn,
            this.databaseParametersValueColumn});
            this.parametersGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parametersGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.parametersGridView.Location = new System.Drawing.Point(3, 3);
            this.parametersGridView.MultiSelect = false;
            this.parametersGridView.Name = "parametersGridView";
            this.parametersGridView.ShowCellErrors = false;
            this.parametersGridView.ShowEditingIcon = false;
            this.parametersGridView.ShowRowErrors = false;
            this.parametersGridView.Size = new System.Drawing.Size(429, 182);
            this.parametersGridView.TabIndex = 14;
            this.parametersGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.PropertyChanged);
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
            this.databaseParametersValueColumn.Width = 200;
            // 
            // connectionStringTextBox
            // 
            this.connectionStringTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionStringTextBox.Location = new System.Drawing.Point(3, 3);
            this.connectionStringTextBox.Multiline = true;
            this.connectionStringTextBox.Name = "connectionStringTextBox";
            this.connectionStringTextBox.Size = new System.Drawing.Size(429, 182);
            this.connectionStringTextBox.TabIndex = 16;
            this.connectionStringTextBox.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // typeComboBox
            // 
            this.typeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.typeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeComboBox.FormattingEnabled = true;
            this.typeComboBox.Location = new System.Drawing.Point(103, 30);
            this.typeComboBox.Name = "typeComboBox";
            this.typeComboBox.Size = new System.Drawing.Size(343, 21);
            this.typeComboBox.TabIndex = 15;
            this.typeComboBox.SelectedIndexChanged += new System.EventHandler(this.type_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(83, 13);
            this.label11.TabIndex = 19;
            this.label11.Text = "Database Type:";
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(103, 4);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(343, 20);
            this.nameTextBox.TabIndex = 20;
            this.nameTextBox.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(59, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Name:";
            // 
            // tabs
            // 
            this.tabs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabs.Controls.Add(this.connectionStringTab);
            this.tabs.Controls.Add(this.parametersTab);
            this.tabs.Location = new System.Drawing.Point(3, 57);
            this.tabs.Name = "tabs";
            this.tabs.SelectedIndex = 0;
            this.tabs.Size = new System.Drawing.Size(443, 214);
            this.tabs.TabIndex = 22;
            // 
            // connectionStringTab
            // 
            this.connectionStringTab.Controls.Add(this.connectionStringTextBox);
            this.connectionStringTab.Location = new System.Drawing.Point(4, 22);
            this.connectionStringTab.Name = "connectionStringTab";
            this.connectionStringTab.Padding = new System.Windows.Forms.Padding(3);
            this.connectionStringTab.Size = new System.Drawing.Size(435, 188);
            this.connectionStringTab.TabIndex = 0;
            this.connectionStringTab.Text = "Connection String";
            this.connectionStringTab.UseVisualStyleBackColor = true;
            // 
            // parametersTab
            // 
            this.parametersTab.Controls.Add(this.parametersGridView);
            this.parametersTab.Location = new System.Drawing.Point(4, 22);
            this.parametersTab.Name = "parametersTab";
            this.parametersTab.Padding = new System.Windows.Forms.Padding(3);
            this.parametersTab.Size = new System.Drawing.Size(435, 188);
            this.parametersTab.TabIndex = 1;
            this.parametersTab.Text = "Parameters";
            // 
            // ConnectionOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.typeComboBox);
            this.Controls.Add(this.label11);
            this.Name = "ConnectionOptions";
            this.Size = new System.Drawing.Size(449, 274);
            ((System.ComponentModel.ISupportInitialize)(this.parametersGridView)).EndInit();
            this.tabs.ResumeLayout(false);
            this.connectionStringTab.ResumeLayout(false);
            this.connectionStringTab.PerformLayout();
            this.parametersTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView parametersGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn databaseParametersNameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn databaseParametersValueColumn;
        private System.Windows.Forms.TextBox connectionStringTextBox;
        private System.Windows.Forms.ComboBox typeComboBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabs;
        private System.Windows.Forms.TabPage connectionStringTab;
        private System.Windows.Forms.TabPage parametersTab;
    }
}
