namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    partial class EditAPI
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
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.parametersListView = new System.Windows.Forms.ListView();
            this.parameterColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.editParameterButton = new System.Windows.Forms.Button();
            this.removeParameterButton = new System.Windows.Forms.Button();
            this.addParameterButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.editReturnParameterButton = new System.Windows.Forms.Button();
            this.returnParameterLabel = new System.Windows.Forms.Label();
            this.editAnnotationsButton = new System.Windows.Forms.Button();
            this.attributesButton = new System.Windows.Forms.Button();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(312, 356);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(393, 356);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // nameTextBox
            // 
            this.nameTextBox.Location = new System.Drawing.Point(108, 12);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(360, 20);
            this.nameTextBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(64, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.moveUpButton);
            this.groupBox2.Controls.Add(this.moveDownButton);
            this.groupBox2.Controls.Add(this.parametersListView);
            this.groupBox2.Controls.Add(this.editParameterButton);
            this.groupBox2.Controls.Add(this.removeParameterButton);
            this.groupBox2.Controls.Add(this.addParameterButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 67);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(456, 283);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parameters";
            // 
            // moveUpButton
            // 
            this.moveUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveUpButton.Enabled = false;
            this.moveUpButton.Font = new System.Drawing.Font("Wingdings", 8.25F);
            this.moveUpButton.Location = new System.Drawing.Point(374, 106);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(35, 23);
            this.moveUpButton.TabIndex = 44;
            this.moveUpButton.Text = "á";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveDownButton.Enabled = false;
            this.moveDownButton.Font = new System.Drawing.Font("Wingdings", 8.25F);
            this.moveDownButton.Location = new System.Drawing.Point(414, 106);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(35, 23);
            this.moveDownButton.TabIndex = 43;
            this.moveDownButton.Text = "â";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // parametersListView
            // 
            this.parametersListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.parametersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.parameterColumnHeader});
            this.parametersListView.FullRowSelect = true;
            this.parametersListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.parametersListView.Location = new System.Drawing.Point(6, 19);
            this.parametersListView.MultiSelect = false;
            this.parametersListView.Name = "parametersListView";
            this.parametersListView.Size = new System.Drawing.Size(362, 258);
            this.parametersListView.TabIndex = 42;
            this.parametersListView.UseCompatibleStateImageBehavior = false;
            this.parametersListView.View = System.Windows.Forms.View.Details;
            this.parametersListView.SelectedIndexChanged += new System.EventHandler(this.parametersListView_SelectedIndexChanged);
            this.parametersListView.DoubleClick += new System.EventHandler(this.parametersListView_DoubleClick);
            // 
            // parameterColumnHeader
            // 
            this.parameterColumnHeader.Text = "Parameter";
            this.parameterColumnHeader.Width = 358;
            // 
            // editParameterButton
            // 
            this.editParameterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editParameterButton.Enabled = false;
            this.editParameterButton.Location = new System.Drawing.Point(374, 48);
            this.editParameterButton.Name = "editParameterButton";
            this.editParameterButton.Size = new System.Drawing.Size(75, 23);
            this.editParameterButton.TabIndex = 41;
            this.editParameterButton.Text = "&Edit";
            this.editParameterButton.UseVisualStyleBackColor = true;
            this.editParameterButton.Click += new System.EventHandler(this.editParameterButton_Click);
            // 
            // removeParameterButton
            // 
            this.removeParameterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeParameterButton.Enabled = false;
            this.removeParameterButton.Location = new System.Drawing.Point(374, 77);
            this.removeParameterButton.Name = "removeParameterButton";
            this.removeParameterButton.Size = new System.Drawing.Size(76, 23);
            this.removeParameterButton.TabIndex = 40;
            this.removeParameterButton.Text = "&Remove";
            this.removeParameterButton.UseVisualStyleBackColor = true;
            this.removeParameterButton.Click += new System.EventHandler(this.removeParameterButton_Click);
            // 
            // addParameterButton
            // 
            this.addParameterButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addParameterButton.Location = new System.Drawing.Point(374, 19);
            this.addParameterButton.Name = "addParameterButton";
            this.addParameterButton.Size = new System.Drawing.Size(76, 23);
            this.addParameterButton.TabIndex = 39;
            this.addParameterButton.Text = "&Add";
            this.addParameterButton.UseVisualStyleBackColor = true;
            this.addParameterButton.Click += new System.EventHandler(this.addParameterButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Return Parameter:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // editReturnParameterButton
            // 
            this.editReturnParameterButton.Location = new System.Drawing.Point(431, 38);
            this.editReturnParameterButton.Name = "editReturnParameterButton";
            this.editReturnParameterButton.Size = new System.Drawing.Size(37, 23);
            this.editReturnParameterButton.TabIndex = 14;
            this.editReturnParameterButton.Text = "&Edit";
            this.editReturnParameterButton.UseVisualStyleBackColor = true;
            this.editReturnParameterButton.Click += new System.EventHandler(this.editReturnParameterButton_Click);
            // 
            // returnParameterLabel
            // 
            this.returnParameterLabel.Location = new System.Drawing.Point(108, 39);
            this.returnParameterLabel.Name = "returnParameterLabel";
            this.returnParameterLabel.Size = new System.Drawing.Size(317, 20);
            this.returnParameterLabel.TabIndex = 15;
            this.returnParameterLabel.Text = "None";
            this.returnParameterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // editAnnotationsButton
            // 
            this.editAnnotationsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editAnnotationsButton.Location = new System.Drawing.Point(12, 356);
            this.editAnnotationsButton.Name = "editAnnotationsButton";
            this.editAnnotationsButton.Size = new System.Drawing.Size(75, 23);
            this.editAnnotationsButton.TabIndex = 16;
            this.editAnnotationsButton.Text = "A&nnotations";
            this.editAnnotationsButton.UseVisualStyleBackColor = true;
            this.editAnnotationsButton.Click += new System.EventHandler(this.editAnnotationsButton_Click);
            // 
            // attributesButton
            // 
            this.attributesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.attributesButton.Location = new System.Drawing.Point(93, 356);
            this.attributesButton.Name = "attributesButton";
            this.attributesButton.Size = new System.Drawing.Size(75, 23);
            this.attributesButton.TabIndex = 17;
            this.attributesButton.Text = "&Attributes";
            this.attributesButton.UseVisualStyleBackColor = true;
            this.attributesButton.Click += new System.EventHandler(this.attributesButton_Click);
            // 
            // EditAPI
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(480, 391);
            this.Controls.Add(this.attributesButton);
            this.Controls.Add(this.editAnnotationsButton);
            this.Controls.Add(this.returnParameterLabel);
            this.Controls.Add(this.editReturnParameterButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Name = "EditAPI";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit API";
            this.Load += new System.EventHandler(this.EditAPIDialog_Load);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button editReturnParameterButton;
        private System.Windows.Forms.Label returnParameterLabel;
        private System.Windows.Forms.Button editParameterButton;
        private System.Windows.Forms.Button removeParameterButton;
        private System.Windows.Forms.Button addParameterButton;
        private System.Windows.Forms.ListView parametersListView;
        private System.Windows.Forms.ColumnHeader parameterColumnHeader;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button editAnnotationsButton;
        private System.Windows.Forms.Button attributesButton;
    }
}