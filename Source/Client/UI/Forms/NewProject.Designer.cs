namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    partial class NewProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProject));
            this.label1 = new System.Windows.Forms.Label();
            this.packageListView = new System.Windows.Forms.ListView();
            this.packagesImageList = new System.Windows.Forms.ImageList(this.components);
            this.nextButton = new System.Windows.Forms.Button();
            this.packageDescriptionLabel = new System.Windows.Forms.Label();
            this.browseButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.locationTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.packageSelectionPanel = new System.Windows.Forms.Panel();
            this.packageInputsPanel = new System.Windows.Forms.Panel();
            this.packageInputsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.progressPanel = new System.Windows.Forms.Panel();
            this.progressLabel = new System.Windows.Forms.Label();
            this.packageSelectionPanel.SuspendLayout();
            this.packageInputsPanel.SuspendLayout();
            this.progressPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(-3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(535, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "You may create a new project from scratch or start with a package. Packages can o" +
    "ften provide project skeletons and other resources to quickly get a project up a" +
    "nd running.";
            // 
            // packageListView
            // 
            this.packageListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packageListView.LargeImageList = this.packagesImageList;
            this.packageListView.Location = new System.Drawing.Point(0, 35);
            this.packageListView.MultiSelect = false;
            this.packageListView.Name = "packageListView";
            this.packageListView.Size = new System.Drawing.Size(407, 236);
            this.packageListView.SmallImageList = this.packagesImageList;
            this.packageListView.TabIndex = 1;
            this.packageListView.UseCompatibleStateImageBehavior = false;
            this.packageListView.SelectedIndexChanged += new System.EventHandler(this.packageListView_SelectedIndexChanged);
            this.packageListView.DoubleClick += new System.EventHandler(this.packageListView_DoubleClick);
            // 
            // packagesImageList
            // 
            this.packagesImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("packagesImageList.ImageStream")));
            this.packagesImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.packagesImageList.Images.SetKeyName(0, "New.png");
            this.packagesImageList.Images.SetKeyName(1, "Open.png");
            this.packagesImageList.Images.SetKeyName(2, "Package.png");
            // 
            // nextButton
            // 
            this.nextButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextButton.Enabled = false;
            this.nextButton.Location = new System.Drawing.Point(391, 322);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 2;
            this.nextButton.Text = "&Next";
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.nextButton_Click);
            // 
            // packageDescriptionLabel
            // 
            this.packageDescriptionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packageDescriptionLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.packageDescriptionLabel.Location = new System.Drawing.Point(413, 35);
            this.packageDescriptionLabel.Name = "packageDescriptionLabel";
            this.packageDescriptionLabel.Size = new System.Drawing.Size(119, 236);
            this.packageDescriptionLabel.TabIndex = 3;
            // 
            // browseButton
            // 
            this.browseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.browseButton.Location = new System.Drawing.Point(454, 35);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 4;
            this.browseButton.Text = "&Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            this.browseButton.Click += new System.EventHandler(this.browseButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(472, 322);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "C&ancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // locationTextBox
            // 
            this.locationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.locationTextBox.Location = new System.Drawing.Point(112, 37);
            this.locationTextBox.Name = "locationTextBox";
            this.locationTextBox.Size = new System.Drawing.Size(336, 20);
            this.locationTextBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(0, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(106, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Location:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // packageSelectionPanel
            // 
            this.packageSelectionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packageSelectionPanel.Controls.Add(this.label1);
            this.packageSelectionPanel.Controls.Add(this.packageListView);
            this.packageSelectionPanel.Controls.Add(this.packageDescriptionLabel);
            this.packageSelectionPanel.Location = new System.Drawing.Point(15, 9);
            this.packageSelectionPanel.Name = "packageSelectionPanel";
            this.packageSelectionPanel.Size = new System.Drawing.Size(532, 271);
            this.packageSelectionPanel.TabIndex = 8;
            // 
            // packageInputsPanel
            // 
            this.packageInputsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packageInputsPanel.Controls.Add(this.packageInputsFlowPanel);
            this.packageInputsPanel.Controls.Add(this.label2);
            this.packageInputsPanel.Controls.Add(this.locationTextBox);
            this.packageInputsPanel.Controls.Add(this.browseButton);
            this.packageInputsPanel.Controls.Add(this.label3);
            this.packageInputsPanel.Location = new System.Drawing.Point(15, 9);
            this.packageInputsPanel.Name = "packageInputsPanel";
            this.packageInputsPanel.Size = new System.Drawing.Size(532, 271);
            this.packageInputsPanel.TabIndex = 9;
            this.packageInputsPanel.Visible = false;
            // 
            // packageInputsFlowPanel
            // 
            this.packageInputsFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.packageInputsFlowPanel.BackColor = System.Drawing.SystemColors.Control;
            this.packageInputsFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.packageInputsFlowPanel.Location = new System.Drawing.Point(-3, 63);
            this.packageInputsFlowPanel.Name = "packageInputsFlowPanel";
            this.packageInputsFlowPanel.Size = new System.Drawing.Size(535, 208);
            this.packageInputsFlowPanel.TabIndex = 9;
            this.packageInputsFlowPanel.Resize += new System.EventHandler(this.packageInputsFlowPanel_Resize);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(-3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(535, 32);
            this.label2.TabIndex = 8;
            this.label2.Text = "Now you need to choose a location for your new project and complete any other inf" +
    "ormation which may be required for this package.";
            // 
            // backButton
            // 
            this.backButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.backButton.Location = new System.Drawing.Point(310, 322);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 10;
            this.backButton.Text = "&Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Visible = false;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(0, 19);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(535, 14);
            this.progressBar.TabIndex = 11;
            // 
            // progressPanel
            // 
            this.progressPanel.Controls.Add(this.progressBar);
            this.progressPanel.Controls.Add(this.progressLabel);
            this.progressPanel.Location = new System.Drawing.Point(12, 283);
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.Size = new System.Drawing.Size(535, 33);
            this.progressPanel.TabIndex = 12;
            this.progressPanel.Visible = false;
            // 
            // progressLabel
            // 
            this.progressLabel.Location = new System.Drawing.Point(0, 0);
            this.progressLabel.Margin = new System.Windows.Forms.Padding(0);
            this.progressLabel.Name = "progressLabel";
            this.progressLabel.Size = new System.Drawing.Size(535, 14);
            this.progressLabel.TabIndex = 12;
            this.progressLabel.Text = "[Status]";
            // 
            // NewProject
            // 
            this.AcceptButton = this.nextButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(559, 357);
            this.Controls.Add(this.progressPanel);
            this.Controls.Add(this.backButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.nextButton);
            this.Controls.Add(this.packageInputsPanel);
            this.Controls.Add(this.packageSelectionPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NewProject";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "New Project";
            this.Load += new System.EventHandler(this.NewPoject_Load);
            this.packageSelectionPanel.ResumeLayout(false);
            this.packageInputsPanel.ResumeLayout(false);
            this.packageInputsPanel.PerformLayout();
            this.progressPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView packageListView;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Label packageDescriptionLabel;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox locationTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ImageList packagesImageList;
        private System.Windows.Forms.Panel packageSelectionPanel;
        private System.Windows.Forms.Panel packageInputsPanel;
        private System.Windows.Forms.Button backButton;
        private System.Windows.Forms.FlowLayoutPanel packageInputsFlowPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Panel progressPanel;
        private System.Windows.Forms.Label progressLabel;
    }
}