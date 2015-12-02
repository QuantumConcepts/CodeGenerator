namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    partial class EditTemplate
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
            this.singleFileOutputPathBrowseButton = new System.Windows.Forms.Button();
            this.singleFileOutputPathTextBox = new System.Windows.Forms.TextBox();
            this.xsltBrowseButton = new System.Windows.Forms.Button();
            this.xsltPathTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.multipleFilesPanel = new System.Windows.Forms.Panel();
            this.templateOutputDefinitionsListBox = new System.Windows.Forms.ListBox();
            this.multipleFilesToolStrip = new System.Windows.Forms.ToolStrip();
            this.addButton = new System.Windows.Forms.ToolStripButton();
            this.editButton = new System.Windows.Forms.ToolStripButton();
            this.removeButton = new System.Windows.Forms.ToolStripButton();
            this.multipleFilesRadioButton = new System.Windows.Forms.RadioButton();
            this.singleFilePanel = new System.Windows.Forms.Panel();
            this.singleFileRadioButton = new System.Windows.Forms.RadioButton();
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.generateByDefaultCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.multipleFilesPanel.SuspendLayout();
            this.multipleFilesToolStrip.SuspendLayout();
            this.singleFilePanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // singleFileOutputPathBrowseButton
            // 
            this.singleFileOutputPathBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.singleFileOutputPathBrowseButton.Location = new System.Drawing.Point(365, 3);
            this.singleFileOutputPathBrowseButton.Name = "singleFileOutputPathBrowseButton";
            this.singleFileOutputPathBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.singleFileOutputPathBrowseButton.TabIndex = 2;
            this.singleFileOutputPathBrowseButton.Text = "&Browse";
            this.singleFileOutputPathBrowseButton.UseVisualStyleBackColor = true;
            this.singleFileOutputPathBrowseButton.Click += new System.EventHandler(this.singleFileOutputPathBrowseButton_Click);
            // 
            // singleFileOutputPathTextBox
            // 
            this.singleFileOutputPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.singleFileOutputPathTextBox.Location = new System.Drawing.Point(3, 5);
            this.singleFileOutputPathTextBox.Name = "singleFileOutputPathTextBox";
            this.singleFileOutputPathTextBox.Size = new System.Drawing.Size(356, 20);
            this.singleFileOutputPathTextBox.TabIndex = 1;
            // 
            // xsltBrowseButton
            // 
            this.xsltBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.xsltBrowseButton.Location = new System.Drawing.Point(428, 10);
            this.xsltBrowseButton.Name = "xsltBrowseButton";
            this.xsltBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.xsltBrowseButton.TabIndex = 2;
            this.xsltBrowseButton.Text = "Browse";
            this.xsltBrowseButton.UseVisualStyleBackColor = true;
            this.xsltBrowseButton.Click += new System.EventHandler(this.xsltBrowseButton_Click);
            // 
            // xsltPathTextBox
            // 
            this.xsltPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xsltPathTextBox.Location = new System.Drawing.Point(83, 12);
            this.xsltPathTextBox.Name = "xsltPathTextBox";
            this.xsltPathTextBox.Size = new System.Drawing.Size(339, 20);
            this.xsltPathTextBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "XSLT Path:";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.generateByDefaultCheckBox);
            this.groupBox1.Controls.Add(this.multipleFilesPanel);
            this.groupBox1.Controls.Add(this.multipleFilesRadioButton);
            this.groupBox1.Controls.Add(this.singleFilePanel);
            this.groupBox1.Controls.Add(this.singleFileRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(491, 331);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output Options";
            // 
            // multipleFilesPanel
            // 
            this.multipleFilesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.multipleFilesPanel.Controls.Add(this.templateOutputDefinitionsListBox);
            this.multipleFilesPanel.Controls.Add(this.multipleFilesToolStrip);
            this.multipleFilesPanel.Enabled = false;
            this.multipleFilesPanel.Location = new System.Drawing.Point(42, 100);
            this.multipleFilesPanel.Name = "multipleFilesPanel";
            this.multipleFilesPanel.Size = new System.Drawing.Size(443, 202);
            this.multipleFilesPanel.TabIndex = 3;
            // 
            // templateOutputDefinitionsListBox
            // 
            this.templateOutputDefinitionsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.templateOutputDefinitionsListBox.FormattingEnabled = true;
            this.templateOutputDefinitionsListBox.Location = new System.Drawing.Point(0, 25);
            this.templateOutputDefinitionsListBox.Name = "templateOutputDefinitionsListBox";
            this.templateOutputDefinitionsListBox.Size = new System.Drawing.Size(443, 173);
            this.templateOutputDefinitionsListBox.TabIndex = 2;
            this.templateOutputDefinitionsListBox.SelectedIndexChanged += new System.EventHandler(this.outputDefinitionsListBox_SelectedIndexChanged);
            // 
            // multipleFilesToolStrip
            // 
            this.multipleFilesToolStrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.multipleFilesToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.multipleFilesToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addButton,
            this.editButton,
            this.removeButton});
            this.multipleFilesToolStrip.Location = new System.Drawing.Point(0, 0);
            this.multipleFilesToolStrip.Name = "multipleFilesToolStrip";
            this.multipleFilesToolStrip.Size = new System.Drawing.Size(195, 25);
            this.multipleFilesToolStrip.TabIndex = 1;
            this.multipleFilesToolStrip.TabStop = true;
            // 
            // addButton
            // 
            this.addButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(42, 22);
            this.addButton.Text = "Add...";
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // editButton
            // 
            this.editButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editButton.Enabled = false;
            this.editButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(40, 22);
            this.editButton.Text = "Edit...";
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.removeButton.Enabled = false;
            this.removeButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(101, 22);
            this.removeButton.Text = "Remove Selected";
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // multipleFilesRadioButton
            // 
            this.multipleFilesRadioButton.AutoSize = true;
            this.multipleFilesRadioButton.Location = new System.Drawing.Point(6, 77);
            this.multipleFilesRadioButton.Name = "multipleFilesRadioButton";
            this.multipleFilesRadioButton.Size = new System.Drawing.Size(85, 17);
            this.multipleFilesRadioButton.TabIndex = 1;
            this.multipleFilesRadioButton.Text = "Multiple Files";
            this.multipleFilesRadioButton.UseVisualStyleBackColor = true;
            this.multipleFilesRadioButton.CheckedChanged += new System.EventHandler(this.multipleFilesRadioButton_CheckedChanged);
            // 
            // singleFilePanel
            // 
            this.singleFilePanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.singleFilePanel.Controls.Add(this.singleFileOutputPathTextBox);
            this.singleFilePanel.Controls.Add(this.singleFileOutputPathBrowseButton);
            this.singleFilePanel.Location = new System.Drawing.Point(42, 42);
            this.singleFilePanel.Name = "singleFilePanel";
            this.singleFilePanel.Size = new System.Drawing.Size(443, 29);
            this.singleFilePanel.TabIndex = 2;
            this.singleFilePanel.TabStop = true;
            // 
            // singleFileRadioButton
            // 
            this.singleFileRadioButton.AutoSize = true;
            this.singleFileRadioButton.Checked = true;
            this.singleFileRadioButton.Location = new System.Drawing.Point(6, 19);
            this.singleFileRadioButton.Name = "singleFileRadioButton";
            this.singleFileRadioButton.Size = new System.Drawing.Size(73, 17);
            this.singleFileRadioButton.TabIndex = 1;
            this.singleFileRadioButton.TabStop = true;
            this.singleFileRadioButton.Text = "Single File";
            this.singleFileRadioButton.UseVisualStyleBackColor = true;
            this.singleFileRadioButton.CheckedChanged += new System.EventHandler(this.singleFileRadioButton_CheckedChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(428, 376);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(347, 376);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 4;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // generateByDefaultCheckBox
            // 
            this.generateByDefaultCheckBox.AutoSize = true;
            this.generateByDefaultCheckBox.Location = new System.Drawing.Point(6, 308);
            this.generateByDefaultCheckBox.Name = "generateByDefaultCheckBox";
            this.generateByDefaultCheckBox.Size = new System.Drawing.Size(125, 17);
            this.generateByDefaultCheckBox.TabIndex = 4;
            this.generateByDefaultCheckBox.Text = "Generate by default?";
            this.generateByDefaultCheckBox.UseVisualStyleBackColor = true;
            // 
            // EditTemplate
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(515, 411);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.xsltBrowseButton);
            this.Controls.Add(this.xsltPathTextBox);
            this.Controls.Add(this.label2);
            this.MinimizeBox = false;
            this.Name = "EditTemplate";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Template";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.multipleFilesPanel.ResumeLayout(false);
            this.multipleFilesPanel.PerformLayout();
            this.multipleFilesToolStrip.ResumeLayout(false);
            this.multipleFilesToolStrip.PerformLayout();
            this.singleFilePanel.ResumeLayout(false);
            this.singleFilePanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button singleFileOutputPathBrowseButton;
        private System.Windows.Forms.TextBox singleFileOutputPathTextBox;
        private System.Windows.Forms.Button xsltBrowseButton;
        private System.Windows.Forms.TextBox xsltPathTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel singleFilePanel;
        private System.Windows.Forms.RadioButton singleFileRadioButton;
        private System.Windows.Forms.Panel multipleFilesPanel;
        private System.Windows.Forms.RadioButton multipleFilesRadioButton;
        private System.Windows.Forms.ToolStrip multipleFilesToolStrip;
        private System.Windows.Forms.ToolStripButton addButton;
        private System.Windows.Forms.ToolStripButton removeButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.ToolStripButton editButton;
        private System.Windows.Forms.ListBox templateOutputDefinitionsListBox;
        private System.Windows.Forms.CheckBox generateByDefaultCheckBox;
    }
}