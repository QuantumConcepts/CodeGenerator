namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.splashTimer = new System.Windows.Forms.Timer(this.components);
            this.copyrightLabel = new System.Windows.Forms.Label();
            this.wwwLink = new System.Windows.Forms.LinkLabel();
            this.bugsLink = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.closeLink = new System.Windows.Forms.LinkLabel();
            this.versionLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // copyrightLabel
            // 
            this.copyrightLabel.BackColor = System.Drawing.Color.Transparent;
            this.copyrightLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.copyrightLabel.Location = new System.Drawing.Point(22, 224);
            this.copyrightLabel.Name = "copyrightLabel";
            this.copyrightLabel.Size = new System.Drawing.Size(306, 20);
            this.copyrightLabel.TabIndex = 2;
            this.copyrightLabel.Text = "© {0} Quantum Concepts Corporation. All rights reserved.";
            this.copyrightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // wwwLink
            // 
            this.wwwLink.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.wwwLink.BackColor = System.Drawing.Color.Transparent;
            this.wwwLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wwwLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.wwwLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.wwwLink.Location = new System.Drawing.Point(22, 141);
            this.wwwLink.Name = "wwwLink";
            this.wwwLink.Size = new System.Drawing.Size(306, 15);
            this.wwwLink.TabIndex = 4;
            this.wwwLink.TabStop = true;
            this.wwwLink.Text = "www.quantumconceptscorp.com";
            this.wwwLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.wwwLink.VisitedLinkColor = System.Drawing.Color.WhiteSmoke;
            this.wwwLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            // 
            // bugsLink
            // 
            this.bugsLink.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bugsLink.BackColor = System.Drawing.Color.Transparent;
            this.bugsLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bugsLink.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bugsLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bugsLink.Location = new System.Drawing.Point(22, 193);
            this.bugsLink.Name = "bugsLink";
            this.bugsLink.Size = new System.Drawing.Size(306, 15);
            this.bugsLink.TabIndex = 5;
            this.bugsLink.TabStop = true;
            this.bugsLink.Text = "bugs.quantumconceptscorp.com";
            this.bugsLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bugsLink.VisitedLinkColor = System.Drawing.Color.WhiteSmoke;
            this.bugsLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.link_LinkClicked);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label2.Location = new System.Drawing.Point(22, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(306, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "For more information, please visit:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(22, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(306, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "To report an issue, please visit:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // closeLink
            // 
            this.closeLink.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.closeLink.AutoSize = true;
            this.closeLink.BackColor = System.Drawing.Color.Transparent;
            this.closeLink.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.closeLink.Location = new System.Drawing.Point(300, 9);
            this.closeLink.Name = "closeLink";
            this.closeLink.Size = new System.Drawing.Size(38, 13);
            this.closeLink.TabIndex = 9;
            this.closeLink.TabStop = true;
            this.closeLink.Text = "Close";
            this.closeLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.closeLink.VisitedLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.closeLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.closeLink_LinkClicked);
            // 
            // versionLabel
            // 
            this.versionLabel.BackColor = System.Drawing.Color.Transparent;
            this.versionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.versionLabel.Location = new System.Drawing.Point(263, 282);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(85, 15);
            this.versionLabel.TabIndex = 10;
            this.versionLabel.Text = "[Version]";
            this.versionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(350, 300);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.closeLink);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bugsLink);
            this.Controls.Add(this.wwwLink);
            this.Controls.Add(this.copyrightLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "About";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Splash";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer splashTimer;
        private System.Windows.Forms.Label copyrightLabel;
        private System.Windows.Forms.LinkLabel wwwLink;
        private System.Windows.Forms.LinkLabel bugsLink;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel closeLink;
        private System.Windows.Forms.Label versionLabel;
    }
}