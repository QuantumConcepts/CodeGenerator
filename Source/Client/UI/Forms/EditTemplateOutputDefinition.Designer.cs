namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    partial class EditTemplateOutputDefinition
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
            this.filterXPathTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.elementTypeComboBox = new System.Windows.Forms.ComboBox();
            this.filenameXPathTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.rootPathTextBox = new System.Windows.Forms.TextBox();
            this.rootPathBrowseButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.previewListView = new System.Windows.Forms.ListView();
            this.elementNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.outputPathColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.updatePreviewButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // filterXPathTextBox
            // 
            this.filterXPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filterXPathTextBox.Location = new System.Drawing.Point(102, 41);
            this.filterXPathTextBox.Name = "filterXPathTextBox";
            this.filterXPathTextBox.Size = new System.Drawing.Size(520, 20);
            this.filterXPathTextBox.TabIndex = 2;
            this.filterXPathTextBox.Text = "@Exclude=\'false\'";
            this.filterXPathTextBox.Leave += new System.EventHandler(this.field_Changed);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Filter XPath:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Element Type:";
            // 
            // elementTypeComboBox
            // 
            this.elementTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.elementTypeComboBox.FormattingEnabled = true;
            this.elementTypeComboBox.Location = new System.Drawing.Point(102, 14);
            this.elementTypeComboBox.Name = "elementTypeComboBox";
            this.elementTypeComboBox.Size = new System.Drawing.Size(150, 21);
            this.elementTypeComboBox.TabIndex = 1;
            // 
            // filenameXPathTextBox
            // 
            this.filenameXPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filenameXPathTextBox.Location = new System.Drawing.Point(102, 96);
            this.filenameXPathTextBox.Name = "filenameXPathTextBox";
            this.filenameXPathTextBox.Size = new System.Drawing.Size(520, 20);
            this.filenameXPathTextBox.TabIndex = 5;
            this.filenameXPathTextBox.Leave += new System.EventHandler(this.field_Changed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Filename XPath:";
            // 
            // rootPathTextBox
            // 
            this.rootPathTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rootPathTextBox.Location = new System.Drawing.Point(102, 69);
            this.rootPathTextBox.Name = "rootPathTextBox";
            this.rootPathTextBox.Size = new System.Drawing.Size(439, 20);
            this.rootPathTextBox.TabIndex = 3;
            this.rootPathTextBox.Leave += new System.EventHandler(this.field_Changed);
            // 
            // rootPathBrowseButton
            // 
            this.rootPathBrowseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rootPathBrowseButton.Location = new System.Drawing.Point(547, 67);
            this.rootPathBrowseButton.Name = "rootPathBrowseButton";
            this.rootPathBrowseButton.Size = new System.Drawing.Size(75, 23);
            this.rootPathBrowseButton.TabIndex = 4;
            this.rootPathBrowseButton.Text = "&Browse";
            this.rootPathBrowseButton.UseVisualStyleBackColor = true;
            this.rootPathBrowseButton.Click += new System.EventHandler(this.rootPathBrowseButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Root Path:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(99, 119);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(243, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Multiple XPath queries are supported, for example:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(147, 135);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(12, 3, 0, 0);
            this.label7.Size = new System.Drawing.Size(49, 16);
            this.label7.TabIndex = 20;
            this.label7.Text = "Table:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(202, 135);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label8.Size = new System.Drawing.Size(86, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "meta.Description";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(202, 151);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label9.Size = new System.Drawing.Size(184, 16);
            this.label9.TabIndex = 23;
            this.label9.Text = "{@SchemaName}\\{@ClassName}.cs";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(100, 151);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(12, 3, 0, 0);
            this.label10.Size = new System.Drawing.Size(96, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "Filename XPath:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(202, 167);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(0, 3, 0, 0);
            this.label11.Size = new System.Drawing.Size(161, 16);
            this.label11.TabIndex = 25;
            this.label11.Text = "[Root Path]\\meta\\Description.cs";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(105, 167);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(12, 3, 0, 0);
            this.label12.Size = new System.Drawing.Size(91, 16);
            this.label12.TabIndex = 24;
            this.label12.Text = "Resulting Path:";
            // 
            // previewListView
            // 
            this.previewListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.elementNameColumnHeader,
            this.outputPathColumnHeader});
            this.previewListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewListView.FullRowSelect = true;
            this.previewListView.Location = new System.Drawing.Point(3, 16);
            this.previewListView.Name = "previewListView";
            this.previewListView.Size = new System.Drawing.Size(604, 191);
            this.previewListView.TabIndex = 0;
            this.previewListView.TabStop = false;
            this.previewListView.UseCompatibleStateImageBehavior = false;
            this.previewListView.View = System.Windows.Forms.View.Details;
            // 
            // elementNameColumnHeader
            // 
            this.elementNameColumnHeader.Text = "ElementName";
            this.elementNameColumnHeader.Width = 150;
            // 
            // outputPathColumnHeader
            // 
            this.outputPathColumnHeader.Text = "Ouput Path";
            this.outputPathColumnHeader.Width = 299;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.previewListView);
            this.groupBox1.Location = new System.Drawing.Point(12, 186);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(610, 210);
            this.groupBox1.TabIndex = 27;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Preview";
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Enabled = false;
            this.okButton.Location = new System.Drawing.Point(466, 402);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 7;
            this.okButton.Text = "&Ok";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(547, 402);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // updatePreviewButton
            // 
            this.updatePreviewButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.updatePreviewButton.Location = new System.Drawing.Point(12, 402);
            this.updatePreviewButton.Name = "updatePreviewButton";
            this.updatePreviewButton.Size = new System.Drawing.Size(100, 23);
            this.updatePreviewButton.TabIndex = 6;
            this.updatePreviewButton.Text = "&Update Preview";
            this.updatePreviewButton.UseVisualStyleBackColor = true;
            this.updatePreviewButton.Click += new System.EventHandler(this.updatePreviewButton_Click);
            // 
            // EditTemplateOutputDefinition
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(634, 437);
            this.Controls.Add(this.updatePreviewButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.rootPathTextBox);
            this.Controls.Add(this.rootPathBrowseButton);
            this.Controls.Add(this.filenameXPathTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.elementTypeComboBox);
            this.Controls.Add(this.filterXPathTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditTemplateOutputDefinition";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Template Output Definition";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filterXPathTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox elementTypeComboBox;
        private System.Windows.Forms.TextBox filenameXPathTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox rootPathTextBox;
        private System.Windows.Forms.Button rootPathBrowseButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListView previewListView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.ColumnHeader elementNameColumnHeader;
        private System.Windows.Forms.ColumnHeader outputPathColumnHeader;
        private System.Windows.Forms.Button updatePreviewButton;
    }
}