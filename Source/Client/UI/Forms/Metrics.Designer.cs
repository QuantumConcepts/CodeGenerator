namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    partial class Metrics
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
            this.lineCountListView = new System.Windows.Forms.ListView();
            this.fileNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fileCountColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.totalFileSizeColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.characterCountColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lineCountColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.closeButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lineCountListView
            // 
            this.lineCountListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lineCountListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fileNameColumnHeader,
            this.fileCountColumnHeader,
            this.totalFileSizeColumnHeader,
            this.characterCountColumnHeader,
            this.lineCountColumnHeader});
            this.lineCountListView.Location = new System.Drawing.Point(12, 32);
            this.lineCountListView.Name = "lineCountListView";
            this.lineCountListView.Size = new System.Drawing.Size(640, 256);
            this.lineCountListView.TabIndex = 0;
            this.lineCountListView.UseCompatibleStateImageBehavior = false;
            this.lineCountListView.View = System.Windows.Forms.View.Details;
            // 
            // fileNameColumnHeader
            // 
            this.fileNameColumnHeader.Text = "File Name";
            this.fileNameColumnHeader.Width = 207;
            // 
            // fileCountColumnHeader
            // 
            this.fileCountColumnHeader.Text = "# Files";
            this.fileCountColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.fileCountColumnHeader.Width = 100;
            // 
            // totalFileSizeColumnHeader
            // 
            this.totalFileSizeColumnHeader.Text = "Total Size";
            this.totalFileSizeColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.totalFileSizeColumnHeader.Width = 100;
            // 
            // characterCountColumnHeader
            // 
            this.characterCountColumnHeader.Text = "# Characters";
            this.characterCountColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.characterCountColumnHeader.Width = 100;
            // 
            // lineCountColumnHeader
            // 
            this.lineCountColumnHeader.Text = "# Lines";
            this.lineCountColumnHeader.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.lineCountColumnHeader.Width = 100;
            // 
            // closeButton
            // 
            this.closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(577, 294);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 1;
            this.closeButton.Text = "&Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(586, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "This tool calculates the metrics for all files which have been generated for this" +
    " project.";
            // 
            // Metrics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(664, 329);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.lineCountListView);
            this.MinimizeBox = false;
            this.Name = "Metrics";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Metrics";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lineCountListView;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.ColumnHeader fileNameColumnHeader;
        private System.Windows.Forms.ColumnHeader lineCountColumnHeader;
        private System.Windows.Forms.ColumnHeader characterCountColumnHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader fileCountColumnHeader;
        private System.Windows.Forms.ColumnHeader totalFileSizeColumnHeader;
    }
}