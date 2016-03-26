namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    partial class TableOrViewOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableOrViewOptions));
            this.apisToolStrip = new System.Windows.Forms.ToolStrip();
            this.addCustomAPIButton = new System.Windows.Forms.ToolStripSplitButton();
            this.addCustomAPIMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCreateAPIMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addDeleteAPIMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editAPIButton = new System.Windows.Forms.ToolStripButton();
            this.removeAPIButton = new System.Windows.Forms.ToolStripButton();
            this.transferAPIToolStripDropDownButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.label4 = new System.Windows.Forms.Label();
            this.tablePluralClassNameTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableReadOnlyModeOptionButton = new System.Windows.Forms.RadioButton();
            this.tableClassNameTextBox = new System.Windows.Forms.TextBox();
            this.tableReadWriteModeOptionButton = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.apisListBox = new System.Windows.Forms.ListBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.apisTabPage = new System.Windows.Forms.TabPage();
            this.annotationsTabPage = new System.Windows.Forms.TabPage();
            this.editAnnotations = new QuantumConcepts.CodeGenerator.Client.UI.Controls.EditTableMappingAnnotations();
            this.attributesTabPage = new System.Windows.Forms.TabPage();
            this.editAttributes = new QuantumConcepts.CodeGenerator.Client.UI.Controls.EditTableMappingAttributes();
            this.apisToolStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.generalTabPage.SuspendLayout();
            this.apisTabPage.SuspendLayout();
            this.annotationsTabPage.SuspendLayout();
            this.attributesTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // apisToolStrip
            // 
            this.apisToolStrip.AutoSize = false;
            this.apisToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCustomAPIButton,
            this.editAPIButton,
            this.removeAPIButton,
            this.transferAPIToolStripDropDownButton});
            this.apisToolStrip.Location = new System.Drawing.Point(3, 3);
            this.apisToolStrip.Name = "apisToolStrip";
            this.apisToolStrip.Size = new System.Drawing.Size(472, 25);
            this.apisToolStrip.TabIndex = 52;
            this.apisToolStrip.Text = "toolStrip1";
            // 
            // addCustomAPIButton
            // 
            this.addCustomAPIButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.addCustomAPIButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCustomAPIMenuItem,
            this.addCreateAPIMenuItem,
            this.addDeleteAPIMenuItem});
            this.addCustomAPIButton.Image = ((System.Drawing.Image)(resources.GetObject("addCustomAPIButton.Image")));
            this.addCustomAPIButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addCustomAPIButton.Name = "addCustomAPIButton";
            this.addCustomAPIButton.Size = new System.Drawing.Size(123, 22);
            this.addCustomAPIButton.Text = "Add Custom API...";
            this.addCustomAPIButton.Click += new System.EventHandler(this.addCustomAPIButton_ButtonClick);
            // 
            // addCustomAPIMenuItem
            // 
            this.addCustomAPIMenuItem.Name = "addCustomAPIMenuItem";
            this.addCustomAPIMenuItem.Size = new System.Drawing.Size(174, 22);
            this.addCustomAPIMenuItem.Text = "Add Custom API...";
            this.addCustomAPIMenuItem.Click += new System.EventHandler(this.addCustomAPIButton_ButtonClick);
            // 
            // addCreateAPIMenuItem
            // 
            this.addCreateAPIMenuItem.Name = "addCreateAPIMenuItem";
            this.addCreateAPIMenuItem.Size = new System.Drawing.Size(174, 22);
            this.addCreateAPIMenuItem.Text = "Add \'Create\' API";
            this.addCreateAPIMenuItem.Click += new System.EventHandler(this.addCreateAPIMenuItem_Click);
            // 
            // addDeleteAPIMenuItem
            // 
            this.addDeleteAPIMenuItem.Name = "addDeleteAPIMenuItem";
            this.addDeleteAPIMenuItem.Size = new System.Drawing.Size(174, 22);
            this.addDeleteAPIMenuItem.Text = "Add \'Delete\' API";
            this.addDeleteAPIMenuItem.Click += new System.EventHandler(this.addDeleteAPIMenuItem_Click);
            // 
            // editAPIButton
            // 
            this.editAPIButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.editAPIButton.Enabled = false;
            this.editAPIButton.Image = ((System.Drawing.Image)(resources.GetObject("editAPIButton.Image")));
            this.editAPIButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.editAPIButton.Name = "editAPIButton";
            this.editAPIButton.Size = new System.Drawing.Size(43, 22);
            this.editAPIButton.Text = "Edit...";
            this.editAPIButton.Click += new System.EventHandler(this.editAPIButton_Click);
            // 
            // removeAPIButton
            // 
            this.removeAPIButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.removeAPIButton.Enabled = false;
            this.removeAPIButton.Image = ((System.Drawing.Image)(resources.GetObject("removeAPIButton.Image")));
            this.removeAPIButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeAPIButton.Name = "removeAPIButton";
            this.removeAPIButton.Size = new System.Drawing.Size(54, 22);
            this.removeAPIButton.Text = "Remove";
            this.removeAPIButton.Click += new System.EventHandler(this.removeAPIButton_Click);
            // 
            // transferAPIToolStripDropDownButton
            // 
            this.transferAPIToolStripDropDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.transferAPIToolStripDropDownButton.Image = ((System.Drawing.Image)(resources.GetObject("transferAPIToolStripDropDownButton.Image")));
            this.transferAPIToolStripDropDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.transferAPIToolStripDropDownButton.Name = "transferAPIToolStripDropDownButton";
            this.transferAPIToolStripDropDownButton.Size = new System.Drawing.Size(89, 22);
            this.transferAPIToolStripDropDownButton.Text = "Transfer to...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 35);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 13);
            this.label4.TabIndex = 48;
            this.label4.Text = "Plural Class Name:";
            // 
            // tablePluralClassNameTextBox
            // 
            this.tablePluralClassNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablePluralClassNameTextBox.Location = new System.Drawing.Point(107, 32);
            this.tablePluralClassNameTextBox.Name = "tablePluralClassNameTextBox";
            this.tablePluralClassNameTextBox.Size = new System.Drawing.Size(365, 20);
            this.tablePluralClassNameTextBox.TabIndex = 1;
            this.tablePluralClassNameTextBox.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 42;
            this.label2.Text = "Class Name:";
            // 
            // tableReadOnlyModeOptionButton
            // 
            this.tableReadOnlyModeOptionButton.AutoSize = true;
            this.tableReadOnlyModeOptionButton.Location = new System.Drawing.Point(194, 56);
            this.tableReadOnlyModeOptionButton.Name = "tableReadOnlyModeOptionButton";
            this.tableReadOnlyModeOptionButton.Size = new System.Drawing.Size(75, 17);
            this.tableReadOnlyModeOptionButton.TabIndex = 3;
            this.tableReadOnlyModeOptionButton.TabStop = true;
            this.tableReadOnlyModeOptionButton.Text = "Read Only";
            this.tableReadOnlyModeOptionButton.UseVisualStyleBackColor = true;
            this.tableReadOnlyModeOptionButton.CheckedChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // tableClassNameTextBox
            // 
            this.tableClassNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableClassNameTextBox.Location = new System.Drawing.Point(107, 6);
            this.tableClassNameTextBox.Name = "tableClassNameTextBox";
            this.tableClassNameTextBox.Size = new System.Drawing.Size(365, 20);
            this.tableClassNameTextBox.TabIndex = 0;
            this.tableClassNameTextBox.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // tableReadWriteModeOptionButton
            // 
            this.tableReadWriteModeOptionButton.AutoSize = true;
            this.tableReadWriteModeOptionButton.Checked = true;
            this.tableReadWriteModeOptionButton.Location = new System.Drawing.Point(107, 56);
            this.tableReadWriteModeOptionButton.Name = "tableReadWriteModeOptionButton";
            this.tableReadWriteModeOptionButton.Size = new System.Drawing.Size(81, 17);
            this.tableReadWriteModeOptionButton.TabIndex = 2;
            this.tableReadWriteModeOptionButton.TabStop = true;
            this.tableReadWriteModeOptionButton.Text = "Read/Write";
            this.tableReadWriteModeOptionButton.UseVisualStyleBackColor = true;
            this.tableReadWriteModeOptionButton.CheckedChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 44;
            this.label1.Text = "Generate As:";
            // 
            // apisListBox
            // 
            this.apisListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.apisListBox.FormattingEnabled = true;
            this.apisListBox.Location = new System.Drawing.Point(3, 28);
            this.apisListBox.Name = "apisListBox";
            this.apisListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.apisListBox.Size = new System.Drawing.Size(472, 145);
            this.apisListBox.TabIndex = 54;
            this.apisListBox.SelectedIndexChanged += new System.EventHandler(this.apisListView_SelectedIndexChanged);
            this.apisListBox.DoubleClick += new System.EventHandler(this.apisListView_DoubleClick);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.generalTabPage);
            this.tabControl.Controls.Add(this.apisTabPage);
            this.tabControl.Controls.Add(this.annotationsTabPage);
            this.tabControl.Controls.Add(this.attributesTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(486, 202);
            this.tabControl.TabIndex = 55;
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.tableClassNameTextBox);
            this.generalTabPage.Controls.Add(this.label1);
            this.generalTabPage.Controls.Add(this.label4);
            this.generalTabPage.Controls.Add(this.tableReadWriteModeOptionButton);
            this.generalTabPage.Controls.Add(this.tablePluralClassNameTextBox);
            this.generalTabPage.Controls.Add(this.tableReadOnlyModeOptionButton);
            this.generalTabPage.Controls.Add(this.label2);
            this.generalTabPage.Location = new System.Drawing.Point(4, 22);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalTabPage.Size = new System.Drawing.Size(478, 176);
            this.generalTabPage.TabIndex = 0;
            this.generalTabPage.Text = "General";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // apisTabPage
            // 
            this.apisTabPage.Controls.Add(this.apisListBox);
            this.apisTabPage.Controls.Add(this.apisToolStrip);
            this.apisTabPage.Location = new System.Drawing.Point(4, 22);
            this.apisTabPage.Name = "apisTabPage";
            this.apisTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.apisTabPage.Size = new System.Drawing.Size(478, 176);
            this.apisTabPage.TabIndex = 1;
            this.apisTabPage.Text = "APIs";
            this.apisTabPage.UseVisualStyleBackColor = true;
            // 
            // annotationsTabPage
            // 
            this.annotationsTabPage.Controls.Add(this.editAnnotations);
            this.annotationsTabPage.Location = new System.Drawing.Point(4, 22);
            this.annotationsTabPage.Name = "annotationsTabPage";
            this.annotationsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.annotationsTabPage.Size = new System.Drawing.Size(478, 176);
            this.annotationsTabPage.TabIndex = 5;
            this.annotationsTabPage.Text = "Annotations";
            this.annotationsTabPage.UseVisualStyleBackColor = true;
            // 
            // editAnnotations
            // 
            this.editAnnotations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editAnnotations.Location = new System.Drawing.Point(3, 3);
            this.editAnnotations.Name = "editAnnotations";
            this.editAnnotations.Size = new System.Drawing.Size(472, 170);
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
            this.attributesTabPage.Size = new System.Drawing.Size(478, 176);
            this.attributesTabPage.TabIndex = 6;
            this.attributesTabPage.Text = "Attributes";
            this.attributesTabPage.UseVisualStyleBackColor = true;
            // 
            // editAttributes
            // 
            this.editAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editAttributes.Location = new System.Drawing.Point(3, 3);
            this.editAttributes.Name = "editAttributes";
            this.editAttributes.Size = new System.Drawing.Size(472, 170);
            this.editAttributes.TabIndex = 0;
            this.editAttributes.AttributeAdded += new System.EventHandler(this.PropertyChanged);
            this.editAttributes.AttributeEdited += new System.EventHandler(this.PropertyChanged);
            this.editAttributes.AttributeRemoved += new System.EventHandler(this.PropertyChanged);
            this.editAttributes.AttributeMoved += new System.EventHandler(this.PropertyChanged);
            // 
            // TableOrViewOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "TableOrViewOptions";
            this.Size = new System.Drawing.Size(486, 202);
            this.Load += new System.EventHandler(this.TableOptions_Load);
            this.apisToolStrip.ResumeLayout(false);
            this.apisToolStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.generalTabPage.ResumeLayout(false);
            this.generalTabPage.PerformLayout();
            this.apisTabPage.ResumeLayout(false);
            this.annotationsTabPage.ResumeLayout(false);
            this.attributesTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip apisToolStrip;
        private System.Windows.Forms.ToolStripSplitButton addCustomAPIButton;
        private System.Windows.Forms.ToolStripMenuItem addCustomAPIMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCreateAPIMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addDeleteAPIMenuItem;
        private System.Windows.Forms.ToolStripButton editAPIButton;
        private System.Windows.Forms.ToolStripButton removeAPIButton;
        private System.Windows.Forms.ToolStripDropDownButton transferAPIToolStripDropDownButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tablePluralClassNameTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton tableReadOnlyModeOptionButton;
        private System.Windows.Forms.TextBox tableClassNameTextBox;
        private System.Windows.Forms.RadioButton tableReadWriteModeOptionButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox apisListBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.TabPage apisTabPage;
        private System.Windows.Forms.TabPage annotationsTabPage;
        private EditTableMappingAnnotations editAnnotations;
        private System.Windows.Forms.TabPage attributesTabPage;
        private EditTableMappingAttributes editAttributes;
    }
}
