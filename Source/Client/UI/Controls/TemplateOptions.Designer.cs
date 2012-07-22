namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    partial class TemplateOptions
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.attributesTabPage = new System.Windows.Forms.TabPage();
            this.editAttributes = new QuantumConcepts.CodeGenerator.Client.UI.Controls.EditTemplateAttributes();
            this.tabControl.SuspendLayout();
            this.attributesTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.attributesTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(536, 248);
            this.tabControl.TabIndex = 1;
            // 
            // attributesTabPage
            // 
            this.attributesTabPage.Controls.Add(this.editAttributes);
            this.attributesTabPage.Location = new System.Drawing.Point(4, 22);
            this.attributesTabPage.Name = "attributesTabPage";
            this.attributesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.attributesTabPage.Size = new System.Drawing.Size(528, 222);
            this.attributesTabPage.TabIndex = 4;
            this.attributesTabPage.Text = "Attributes";
            this.attributesTabPage.UseVisualStyleBackColor = true;
            // 
            // editAttributes
            // 
            this.editAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editAttributes.Location = new System.Drawing.Point(3, 3);
            this.editAttributes.Name = "editAttributes";
            this.editAttributes.Size = new System.Drawing.Size(522, 216);
            this.editAttributes.TabIndex = 1;
            this.editAttributes.AttributeAdded += new System.EventHandler(this.PropertyChanged);
            this.editAttributes.AttributeEdited += new System.EventHandler(this.PropertyChanged);
            this.editAttributes.AttributeRemoved += new System.EventHandler(this.PropertyChanged);
            this.editAttributes.AttributeMoved += new System.EventHandler(this.PropertyChanged);
            // 
            // ProjectOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "ProjectOptions";
            this.Size = new System.Drawing.Size(536, 248);
            this.Load += new System.EventHandler(this.ProjectOptions_Load);
            this.tabControl.ResumeLayout(false);
            this.attributesTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage attributesTabPage;
        private EditTemplateAttributes editAttributes;

    }
}
