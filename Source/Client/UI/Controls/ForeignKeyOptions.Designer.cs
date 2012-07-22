namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    partial class ForeignKeyOptions
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
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.foreignKeyFieldNameTextBox = new System.Windows.Forms.TextBox();
            this.foreignKeyFieldPluralPropertyNameTextBox = new System.Windows.Forms.TextBox();
            this.foreignKeyFieldPropertyNameTextBox = new System.Windows.Forms.TextBox();
            this.foreignKeyFieldPluralFieldNameTextBox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.annotationsTabPage = new System.Windows.Forms.TabPage();
            this.editAnnotations = new QuantumConcepts.CodeGenerator.Client.UI.Controls.EditForeignKeyMappingAnnotations();
            this.attributesTabPage = new System.Windows.Forms.TabPage();
            this.editAttributes = new QuantumConcepts.CodeGenerator.Client.UI.Controls.EditForeignKeyMappingAttributes();
            this.generalTabPage.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.annotationsTabPage.SuspendLayout();
            this.attributesTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.foreignKeyFieldNameTextBox);
            this.generalTabPage.Controls.Add(this.foreignKeyFieldPluralPropertyNameTextBox);
            this.generalTabPage.Controls.Add(this.foreignKeyFieldPropertyNameTextBox);
            this.generalTabPage.Controls.Add(this.foreignKeyFieldPluralFieldNameTextBox);
            this.generalTabPage.Controls.Add(this.label10);
            this.generalTabPage.Controls.Add(this.label3);
            this.generalTabPage.Controls.Add(this.label11);
            this.generalTabPage.Controls.Add(this.label9);
            this.generalTabPage.Location = new System.Drawing.Point(4, 22);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalTabPage.Size = new System.Drawing.Size(490, 244);
            this.generalTabPage.TabIndex = 0;
            this.generalTabPage.Text = "General";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // foreignKeyFieldNameTextBox
            // 
            this.foreignKeyFieldNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.foreignKeyFieldNameTextBox.Location = new System.Drawing.Point(124, 6);
            this.foreignKeyFieldNameTextBox.Name = "foreignKeyFieldNameTextBox";
            this.foreignKeyFieldNameTextBox.Size = new System.Drawing.Size(360, 20);
            this.foreignKeyFieldNameTextBox.TabIndex = 35;
            this.foreignKeyFieldNameTextBox.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // foreignKeyFieldPluralPropertyNameTextBox
            // 
            this.foreignKeyFieldPluralPropertyNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.foreignKeyFieldPluralPropertyNameTextBox.Location = new System.Drawing.Point(124, 84);
            this.foreignKeyFieldPluralPropertyNameTextBox.Name = "foreignKeyFieldPluralPropertyNameTextBox";
            this.foreignKeyFieldPluralPropertyNameTextBox.Size = new System.Drawing.Size(360, 20);
            this.foreignKeyFieldPluralPropertyNameTextBox.TabIndex = 41;
            this.foreignKeyFieldPluralPropertyNameTextBox.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // foreignKeyFieldPropertyNameTextBox
            // 
            this.foreignKeyFieldPropertyNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.foreignKeyFieldPropertyNameTextBox.Location = new System.Drawing.Point(124, 32);
            this.foreignKeyFieldPropertyNameTextBox.Name = "foreignKeyFieldPropertyNameTextBox";
            this.foreignKeyFieldPropertyNameTextBox.Size = new System.Drawing.Size(360, 20);
            this.foreignKeyFieldPropertyNameTextBox.TabIndex = 37;
            this.foreignKeyFieldPropertyNameTextBox.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // foreignKeyFieldPluralFieldNameTextBox
            // 
            this.foreignKeyFieldPluralFieldNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.foreignKeyFieldPluralFieldNameTextBox.Location = new System.Drawing.Point(124, 58);
            this.foreignKeyFieldPluralFieldNameTextBox.Name = "foreignKeyFieldPluralFieldNameTextBox";
            this.foreignKeyFieldPluralFieldNameTextBox.Size = new System.Drawing.Size(360, 20);
            this.foreignKeyFieldPluralFieldNameTextBox.TabIndex = 39;
            this.foreignKeyFieldPluralFieldNameTextBox.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 87);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(106, 13);
            this.label10.TabIndex = 42;
            this.label10.Text = "Child Property Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Parent Field Name:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(29, 61);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(89, 13);
            this.label11.TabIndex = 40;
            this.label11.Text = "Child Field Name:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 35);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(114, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Parent Property Name:";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.generalTabPage);
            this.tabControl.Controls.Add(this.annotationsTabPage);
            this.tabControl.Controls.Add(this.attributesTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(498, 270);
            this.tabControl.TabIndex = 43;
            // 
            // annotationsTabPage
            // 
            this.annotationsTabPage.Controls.Add(this.editAnnotations);
            this.annotationsTabPage.Location = new System.Drawing.Point(4, 22);
            this.annotationsTabPage.Name = "annotationsTabPage";
            this.annotationsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.annotationsTabPage.Size = new System.Drawing.Size(490, 244);
            this.annotationsTabPage.TabIndex = 4;
            this.annotationsTabPage.Text = "Annotations";
            this.annotationsTabPage.UseVisualStyleBackColor = true;
            // 
            // editAnnotations
            // 
            this.editAnnotations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editAnnotations.Location = new System.Drawing.Point(3, 3);
            this.editAnnotations.Name = "editAnnotations";
            this.editAnnotations.Size = new System.Drawing.Size(484, 238);
            this.editAnnotations.TabIndex = 0;
            this.editAnnotations.AnnotationAdded += new System.EventHandler(this.PropertyChanged);
            this.editAnnotations.AnnotationEdited += new System.EventHandler(this.PropertyChanged);
            this.editAnnotations.AnnotationRemoved += new System.EventHandler(this.PropertyChanged);
            this.editAnnotations.AnnotationMoved += new System.EventHandler(this.PropertyChanged);
            // 
            // attributesTabPage
            // 
            this.attributesTabPage.Controls.Add(this.editAttributes);
            this.attributesTabPage.Location = new System.Drawing.Point(4, 22);
            this.attributesTabPage.Name = "attributesTabPage";
            this.attributesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.attributesTabPage.Size = new System.Drawing.Size(490, 244);
            this.attributesTabPage.TabIndex = 5;
            this.attributesTabPage.Text = "Attributes";
            this.attributesTabPage.UseVisualStyleBackColor = true;
            // 
            // editAttributes
            // 
            this.editAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editAttributes.Location = new System.Drawing.Point(3, 3);
            this.editAttributes.Name = "editAttributes";
            this.editAttributes.Size = new System.Drawing.Size(484, 238);
            this.editAttributes.TabIndex = 0;
            this.editAttributes.AttributeAdded += new System.EventHandler(this.PropertyChanged);
            this.editAttributes.AttributeEdited += new System.EventHandler(this.PropertyChanged);
            this.editAttributes.AttributeRemoved += new System.EventHandler(this.PropertyChanged);
            this.editAttributes.AttributeMoved += new System.EventHandler(this.PropertyChanged);
            // 
            // ForeignKeyOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "ForeignKeyOptions";
            this.Size = new System.Drawing.Size(498, 270);
            this.Load += new System.EventHandler(this.ForeignKeyOptions_Load);
            this.generalTabPage.ResumeLayout(false);
            this.generalTabPage.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.annotationsTabPage.ResumeLayout(false);
            this.attributesTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.TextBox foreignKeyFieldNameTextBox;
        private System.Windows.Forms.TextBox foreignKeyFieldPluralPropertyNameTextBox;
        private System.Windows.Forms.TextBox foreignKeyFieldPropertyNameTextBox;
        private System.Windows.Forms.TextBox foreignKeyFieldPluralFieldNameTextBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage annotationsTabPage;
        private EditForeignKeyMappingAnnotations editAnnotations;
        private System.Windows.Forms.TabPage attributesTabPage;
        private EditForeignKeyMappingAttributes editAttributes;

    }
}
