namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    partial class Generate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Generate));
            this.outputsListView = new System.Windows.Forms.ListView();
            this.pathColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.elementColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.messageColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.generateAllButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.autoCloseCheckBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // outputsListView
            // 
            this.outputsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputsListView.CheckBoxes = true;
            this.outputsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.pathColumn,
            this.elementColumn,
            this.statusColumn,
            this.messageColumn});
            this.outputsListView.FullRowSelect = true;
            this.outputsListView.Location = new System.Drawing.Point(12, 42);
            this.outputsListView.Name = "outputsListView";
            this.outputsListView.Size = new System.Drawing.Size(724, 357);
            this.outputsListView.TabIndex = 1;
            this.outputsListView.UseCompatibleStateImageBehavior = false;
            this.outputsListView.View = System.Windows.Forms.View.Details;
            this.outputsListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.outputsListView_ItemChecked);
            this.outputsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.outputsListView_MouseDoubleClick);
            // 
            // pathColumn
            // 
            this.pathColumn.Text = "Path";
            this.pathColumn.Width = 300;
            // 
            // elementColumn
            // 
            this.elementColumn.Text = "Element";
            this.elementColumn.Width = 150;
            // 
            // statusColumn
            // 
            this.statusColumn.Text = "Status";
            this.statusColumn.Width = 100;
            // 
            // messageColumn
            // 
            this.messageColumn.Text = "Message";
            this.messageColumn.Width = 150;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(724, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // generateButton
            // 
            this.generateButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.generateButton.Enabled = false;
            this.generateButton.Location = new System.Drawing.Point(499, 428);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(75, 23);
            this.generateButton.TabIndex = 3;
            this.generateButton.Text = "&Generate";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // generateAllButton
            // 
            this.generateAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.generateAllButton.Location = new System.Drawing.Point(580, 428);
            this.generateAllButton.Name = "generateAllButton";
            this.generateAllButton.Size = new System.Drawing.Size(75, 23);
            this.generateAllButton.TabIndex = 4;
            this.generateAllButton.Text = "Generate &All";
            this.generateAllButton.UseVisualStyleBackColor = true;
            this.generateAllButton.Click += new System.EventHandler(this.generateAllButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.Location = new System.Drawing.Point(661, 428);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "&Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(12, 431);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(481, 16);
            this.progressBar.TabIndex = 5;
            this.progressBar.Visible = false;
            // 
            // autoCloseCheckBox
            // 
            this.autoCloseCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.autoCloseCheckBox.AutoSize = true;
            this.autoCloseCheckBox.Location = new System.Drawing.Point(12, 405);
            this.autoCloseCheckBox.Name = "autoCloseCheckBox";
            this.autoCloseCheckBox.Size = new System.Drawing.Size(246, 17);
            this.autoCloseCheckBox.TabIndex = 2;
            this.autoCloseCheckBox.Text = "Close this window upon successful generation.";
            this.autoCloseCheckBox.UseVisualStyleBackColor = true;
            // 
            // Generate
            // 
            this.AcceptButton = this.generateButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 463);
            this.Controls.Add(this.autoCloseCheckBox);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.generateAllButton);
            this.Controls.Add(this.generateButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.outputsListView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "Generate";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generate";
            this.Load += new System.EventHandler(this.Generate_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView outputsListView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.Button generateAllButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ColumnHeader elementColumn;
        private System.Windows.Forms.ColumnHeader pathColumn;
        private System.Windows.Forms.ColumnHeader statusColumn;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.ColumnHeader messageColumn;
        private System.Windows.Forms.CheckBox autoCloseCheckBox;

    }
}