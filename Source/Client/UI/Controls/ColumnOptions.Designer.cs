namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    partial class ColumnOptions
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
            this.generalTabPage = new System.Windows.Forms.TabPage();
            this.columnPrimaryKeyCheckBox = new System.Windows.Forms.CheckBox();
            this.columnTreatAsYesNoIndicatorCheckBox = new System.Windows.Forms.CheckBox();
            this.columnNullableCheckBox = new System.Windows.Forms.CheckBox();
            this.columnDataTypeTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.columnFieldNameTextBox = new System.Windows.Forms.TextBox();
            this.encryptionTabPage = new System.Windows.Forms.TabPage();
            this.encryptionPropertyNameTextBox = new System.Windows.Forms.TextBox();
            this.encryptionVectorColumnComboBox = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.encryptionCheckBox = new System.Windows.Forms.CheckBox();
            this.enumerationTabPage = new System.Windows.Forms.TabPage();
            this.enumerationAttributesButton = new System.Windows.Forms.Button();
            this.enumerationAnnotationsButton = new System.Windows.Forms.Button();
            this.enumerationValuesListBox = new System.Windows.Forms.ListBox();
            this.enumerationIsReferenceCheckBox = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.enumerationNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.referencedEnumerationComboBox = new System.Windows.Forms.ComboBox();
            this.addEnumerationValueButton = new System.Windows.Forms.Button();
            this.editEnumerationValueButton = new System.Windows.Forms.Button();
            this.removeEnumerationValueButton = new System.Windows.Forms.Button();
            this.enumerationCheckBox = new System.Windows.Forms.CheckBox();
            this.annotationsTabPage = new System.Windows.Forms.TabPage();
            this.attributesTabPage = new System.Windows.Forms.TabPage();
            this.editAnnotations = new QuantumConcepts.CodeGenerator.Client.UI.Controls.EditColumnMappingAnnotations();
            this.editAttributes = new QuantumConcepts.CodeGenerator.Client.UI.Controls.EditColumnMappingAttributes();
            this.tabControl.SuspendLayout();
            this.generalTabPage.SuspendLayout();
            this.encryptionTabPage.SuspendLayout();
            this.enumerationTabPage.SuspendLayout();
            this.annotationsTabPage.SuspendLayout();
            this.attributesTabPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.generalTabPage);
            this.tabControl.Controls.Add(this.encryptionTabPage);
            this.tabControl.Controls.Add(this.enumerationTabPage);
            this.tabControl.Controls.Add(this.annotationsTabPage);
            this.tabControl.Controls.Add(this.attributesTabPage);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(584, 289);
            this.tabControl.TabIndex = 0;
            // 
            // generalTabPage
            // 
            this.generalTabPage.Controls.Add(this.columnPrimaryKeyCheckBox);
            this.generalTabPage.Controls.Add(this.columnTreatAsYesNoIndicatorCheckBox);
            this.generalTabPage.Controls.Add(this.columnNullableCheckBox);
            this.generalTabPage.Controls.Add(this.columnDataTypeTextBox);
            this.generalTabPage.Controls.Add(this.label7);
            this.generalTabPage.Controls.Add(this.label8);
            this.generalTabPage.Controls.Add(this.columnFieldNameTextBox);
            this.generalTabPage.Location = new System.Drawing.Point(4, 22);
            this.generalTabPage.Name = "generalTabPage";
            this.generalTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.generalTabPage.Size = new System.Drawing.Size(576, 263);
            this.generalTabPage.TabIndex = 0;
            this.generalTabPage.Text = "General";
            this.generalTabPage.UseVisualStyleBackColor = true;
            // 
            // columnPrimaryKeyCheckBox
            // 
            this.columnPrimaryKeyCheckBox.AutoSize = true;
            this.columnPrimaryKeyCheckBox.Enabled = false;
            this.columnPrimaryKeyCheckBox.Location = new System.Drawing.Point(80, 58);
            this.columnPrimaryKeyCheckBox.Name = "columnPrimaryKeyCheckBox";
            this.columnPrimaryKeyCheckBox.Size = new System.Drawing.Size(81, 17);
            this.columnPrimaryKeyCheckBox.TabIndex = 37;
            this.columnPrimaryKeyCheckBox.Text = "Primary Key";
            this.columnPrimaryKeyCheckBox.UseVisualStyleBackColor = true;
            this.columnPrimaryKeyCheckBox.CheckedChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // columnTreatAsYesNoIndicatorCheckBox
            // 
            this.columnTreatAsYesNoIndicatorCheckBox.AutoSize = true;
            this.columnTreatAsYesNoIndicatorCheckBox.Location = new System.Drawing.Point(80, 104);
            this.columnTreatAsYesNoIndicatorCheckBox.Name = "columnTreatAsYesNoIndicatorCheckBox";
            this.columnTreatAsYesNoIndicatorCheckBox.Size = new System.Drawing.Size(149, 17);
            this.columnTreatAsYesNoIndicatorCheckBox.TabIndex = 36;
            this.columnTreatAsYesNoIndicatorCheckBox.Text = "Treat as Yes/No Indicator";
            this.columnTreatAsYesNoIndicatorCheckBox.UseVisualStyleBackColor = true;
            this.columnTreatAsYesNoIndicatorCheckBox.CheckedChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // columnNullableCheckBox
            // 
            this.columnNullableCheckBox.AutoSize = true;
            this.columnNullableCheckBox.Location = new System.Drawing.Point(80, 81);
            this.columnNullableCheckBox.Name = "columnNullableCheckBox";
            this.columnNullableCheckBox.Size = new System.Drawing.Size(64, 17);
            this.columnNullableCheckBox.TabIndex = 35;
            this.columnNullableCheckBox.Text = "Nullable";
            this.columnNullableCheckBox.UseVisualStyleBackColor = true;
            this.columnNullableCheckBox.CheckedChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // columnDataTypeTextBox
            // 
            this.columnDataTypeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.columnDataTypeTextBox.Location = new System.Drawing.Point(74, 32);
            this.columnDataTypeTextBox.Name = "columnDataTypeTextBox";
            this.columnDataTypeTextBox.Size = new System.Drawing.Size(496, 20);
            this.columnDataTypeTextBox.TabIndex = 34;
            this.columnDataTypeTextBox.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 13);
            this.label7.TabIndex = 32;
            this.label7.Text = "Data Type:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(5, 9);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 13);
            this.label8.TabIndex = 33;
            this.label8.Text = "Field Name:";
            // 
            // columnFieldNameTextBox
            // 
            this.columnFieldNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.columnFieldNameTextBox.Location = new System.Drawing.Point(74, 6);
            this.columnFieldNameTextBox.Name = "columnFieldNameTextBox";
            this.columnFieldNameTextBox.Size = new System.Drawing.Size(498, 20);
            this.columnFieldNameTextBox.TabIndex = 31;
            this.columnFieldNameTextBox.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // encryptionTabPage
            // 
            this.encryptionTabPage.Controls.Add(this.encryptionPropertyNameTextBox);
            this.encryptionTabPage.Controls.Add(this.encryptionVectorColumnComboBox);
            this.encryptionTabPage.Controls.Add(this.label14);
            this.encryptionTabPage.Controls.Add(this.label13);
            this.encryptionTabPage.Controls.Add(this.encryptionCheckBox);
            this.encryptionTabPage.Location = new System.Drawing.Point(4, 22);
            this.encryptionTabPage.Name = "encryptionTabPage";
            this.encryptionTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.encryptionTabPage.Size = new System.Drawing.Size(576, 263);
            this.encryptionTabPage.TabIndex = 1;
            this.encryptionTabPage.Text = "Encryption";
            this.encryptionTabPage.UseVisualStyleBackColor = true;
            // 
            // encryptionPropertyNameTextBox
            // 
            this.encryptionPropertyNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.encryptionPropertyNameTextBox.Enabled = false;
            this.encryptionPropertyNameTextBox.Location = new System.Drawing.Point(92, 29);
            this.encryptionPropertyNameTextBox.Name = "encryptionPropertyNameTextBox";
            this.encryptionPropertyNameTextBox.Size = new System.Drawing.Size(478, 20);
            this.encryptionPropertyNameTextBox.TabIndex = 55;
            this.encryptionPropertyNameTextBox.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // encryptionVectorColumnComboBox
            // 
            this.encryptionVectorColumnComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.encryptionVectorColumnComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encryptionVectorColumnComboBox.Enabled = false;
            this.encryptionVectorColumnComboBox.FormattingEnabled = true;
            this.encryptionVectorColumnComboBox.Location = new System.Drawing.Point(92, 55);
            this.encryptionVectorColumnComboBox.Name = "encryptionVectorColumnComboBox";
            this.encryptionVectorColumnComboBox.Size = new System.Drawing.Size(478, 21);
            this.encryptionVectorColumnComboBox.TabIndex = 52;
            this.encryptionVectorColumnComboBox.SelectedIndexChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 32);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(80, 13);
            this.label14.TabIndex = 54;
            this.label14.Text = "Property Name:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(45, 58);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(41, 13);
            this.label13.TabIndex = 53;
            this.label13.Text = "Vector:";
            // 
            // encryptionCheckBox
            // 
            this.encryptionCheckBox.AutoSize = true;
            this.encryptionCheckBox.Location = new System.Drawing.Point(92, 6);
            this.encryptionCheckBox.Name = "encryptionCheckBox";
            this.encryptionCheckBox.Size = new System.Drawing.Size(185, 17);
            this.encryptionCheckBox.TabIndex = 44;
            this.encryptionCheckBox.Text = "Enable encryption for this column.";
            this.encryptionCheckBox.UseVisualStyleBackColor = true;
            this.encryptionCheckBox.CheckedChanged += new System.EventHandler(this.encryptionCheckBox_CheckedChanged);
            // 
            // enumerationTabPage
            // 
            this.enumerationTabPage.Controls.Add(this.enumerationAttributesButton);
            this.enumerationTabPage.Controls.Add(this.enumerationAnnotationsButton);
            this.enumerationTabPage.Controls.Add(this.enumerationValuesListBox);
            this.enumerationTabPage.Controls.Add(this.enumerationIsReferenceCheckBox);
            this.enumerationTabPage.Controls.Add(this.label12);
            this.enumerationTabPage.Controls.Add(this.enumerationNameTextBox);
            this.enumerationTabPage.Controls.Add(this.label5);
            this.enumerationTabPage.Controls.Add(this.label6);
            this.enumerationTabPage.Controls.Add(this.referencedEnumerationComboBox);
            this.enumerationTabPage.Controls.Add(this.addEnumerationValueButton);
            this.enumerationTabPage.Controls.Add(this.editEnumerationValueButton);
            this.enumerationTabPage.Controls.Add(this.removeEnumerationValueButton);
            this.enumerationTabPage.Controls.Add(this.enumerationCheckBox);
            this.enumerationTabPage.Location = new System.Drawing.Point(4, 22);
            this.enumerationTabPage.Name = "enumerationTabPage";
            this.enumerationTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.enumerationTabPage.Size = new System.Drawing.Size(576, 263);
            this.enumerationTabPage.TabIndex = 2;
            this.enumerationTabPage.Text = "Enumeration";
            this.enumerationTabPage.UseVisualStyleBackColor = true;
            // 
            // enumerationAttributesButton
            // 
            this.enumerationAttributesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.enumerationAttributesButton.Location = new System.Drawing.Point(154, 232);
            this.enumerationAttributesButton.Name = "enumerationAttributesButton";
            this.enumerationAttributesButton.Size = new System.Drawing.Size(75, 23);
            this.enumerationAttributesButton.TabIndex = 65;
            this.enumerationAttributesButton.Text = "&Attributes";
            this.enumerationAttributesButton.UseVisualStyleBackColor = true;
            this.enumerationAttributesButton.Click += new System.EventHandler(this.attributesButton_Click);
            // 
            // enumerationAnnotationsButton
            // 
            this.enumerationAnnotationsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.enumerationAnnotationsButton.Location = new System.Drawing.Point(73, 232);
            this.enumerationAnnotationsButton.Name = "enumerationAnnotationsButton";
            this.enumerationAnnotationsButton.Size = new System.Drawing.Size(75, 23);
            this.enumerationAnnotationsButton.TabIndex = 64;
            this.enumerationAnnotationsButton.Text = "A&nnotations";
            this.enumerationAnnotationsButton.UseVisualStyleBackColor = true;
            this.enumerationAnnotationsButton.Click += new System.EventHandler(this.editAnnotationsButton_Click);
            // 
            // enumerationValuesListBox
            // 
            this.enumerationValuesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.enumerationValuesListBox.Enabled = false;
            this.enumerationValuesListBox.FormattingEnabled = true;
            this.enumerationValuesListBox.Location = new System.Drawing.Point(73, 105);
            this.enumerationValuesListBox.Name = "enumerationValuesListBox";
            this.enumerationValuesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.enumerationValuesListBox.Size = new System.Drawing.Size(423, 121);
            this.enumerationValuesListBox.TabIndex = 63;
            this.enumerationValuesListBox.SelectedIndexChanged += new System.EventHandler(this.enumerationValuesListBox_SelectedIndexChanged);
            this.enumerationValuesListBox.DoubleClick += new System.EventHandler(this.enumerationValuesListBox_DoubleClick);
            // 
            // enumerationIsReferenceCheckBox
            // 
            this.enumerationIsReferenceCheckBox.AutoSize = true;
            this.enumerationIsReferenceCheckBox.Enabled = false;
            this.enumerationIsReferenceCheckBox.Location = new System.Drawing.Point(73, 29);
            this.enumerationIsReferenceCheckBox.Name = "enumerationIsReferenceCheckBox";
            this.enumerationIsReferenceCheckBox.Size = new System.Drawing.Size(166, 17);
            this.enumerationIsReferenceCheckBox.TabIndex = 60;
            this.enumerationIsReferenceCheckBox.Text = "Use Referenced Enumeration";
            this.enumerationIsReferenceCheckBox.UseVisualStyleBackColor = true;
            this.enumerationIsReferenceCheckBox.CheckedChanged += new System.EventHandler(this.enumerationIsReferenceCheckBox_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(7, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(60, 13);
            this.label12.TabIndex = 62;
            this.label12.Text = "Reference:";
            // 
            // enumerationNameTextBox
            // 
            this.enumerationNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.enumerationNameTextBox.Enabled = false;
            this.enumerationNameTextBox.Location = new System.Drawing.Point(73, 79);
            this.enumerationNameTextBox.Name = "enumerationNameTextBox";
            this.enumerationNameTextBox.Size = new System.Drawing.Size(497, 20);
            this.enumerationNameTextBox.TabIndex = 61;
            this.enumerationNameTextBox.TextChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(29, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 13);
            this.label5.TabIndex = 54;
            this.label5.Text = "Name:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 55;
            this.label6.Text = "Values:";
            // 
            // referencedEnumerationComboBox
            // 
            this.referencedEnumerationComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.referencedEnumerationComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.referencedEnumerationComboBox.Enabled = false;
            this.referencedEnumerationComboBox.FormattingEnabled = true;
            this.referencedEnumerationComboBox.Location = new System.Drawing.Point(73, 52);
            this.referencedEnumerationComboBox.Name = "referencedEnumerationComboBox";
            this.referencedEnumerationComboBox.Size = new System.Drawing.Size(497, 21);
            this.referencedEnumerationComboBox.TabIndex = 59;
            this.referencedEnumerationComboBox.SelectedIndexChanged += new System.EventHandler(this.PropertyChanged);
            // 
            // addEnumerationValueButton
            // 
            this.addEnumerationValueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addEnumerationValueButton.Enabled = false;
            this.addEnumerationValueButton.Location = new System.Drawing.Point(502, 106);
            this.addEnumerationValueButton.Name = "addEnumerationValueButton";
            this.addEnumerationValueButton.Size = new System.Drawing.Size(68, 23);
            this.addEnumerationValueButton.TabIndex = 56;
            this.addEnumerationValueButton.Text = "&Add";
            this.addEnumerationValueButton.UseVisualStyleBackColor = true;
            this.addEnumerationValueButton.Click += new System.EventHandler(this.addEnumerationValueButton_Click);
            // 
            // editEnumerationValueButton
            // 
            this.editEnumerationValueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editEnumerationValueButton.Enabled = false;
            this.editEnumerationValueButton.Location = new System.Drawing.Point(502, 135);
            this.editEnumerationValueButton.Name = "editEnumerationValueButton";
            this.editEnumerationValueButton.Size = new System.Drawing.Size(67, 23);
            this.editEnumerationValueButton.TabIndex = 58;
            this.editEnumerationValueButton.Text = "&Edit";
            this.editEnumerationValueButton.UseVisualStyleBackColor = true;
            this.editEnumerationValueButton.Click += new System.EventHandler(this.editEnumerationValueButton_Click);
            // 
            // removeEnumerationValueButton
            // 
            this.removeEnumerationValueButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeEnumerationValueButton.Enabled = false;
            this.removeEnumerationValueButton.Location = new System.Drawing.Point(502, 164);
            this.removeEnumerationValueButton.Name = "removeEnumerationValueButton";
            this.removeEnumerationValueButton.Size = new System.Drawing.Size(68, 23);
            this.removeEnumerationValueButton.TabIndex = 57;
            this.removeEnumerationValueButton.Text = "&Remove";
            this.removeEnumerationValueButton.UseVisualStyleBackColor = true;
            this.removeEnumerationValueButton.Click += new System.EventHandler(this.removeEnumerationValueButton_Click);
            // 
            // enumerationCheckBox
            // 
            this.enumerationCheckBox.AutoSize = true;
            this.enumerationCheckBox.Location = new System.Drawing.Point(73, 6);
            this.enumerationCheckBox.Name = "enumerationCheckBox";
            this.enumerationCheckBox.Size = new System.Drawing.Size(174, 17);
            this.enumerationCheckBox.TabIndex = 32;
            this.enumerationCheckBox.Text = "This column is an emumeration.";
            this.enumerationCheckBox.UseVisualStyleBackColor = true;
            this.enumerationCheckBox.CheckedChanged += new System.EventHandler(this.enumerationCheckBox_CheckedChanged);
            // 
            // annotationsTabPage
            // 
            this.annotationsTabPage.Controls.Add(this.editAnnotations);
            this.annotationsTabPage.Location = new System.Drawing.Point(4, 22);
            this.annotationsTabPage.Name = "annotationsTabPage";
            this.annotationsTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.annotationsTabPage.Size = new System.Drawing.Size(576, 263);
            this.annotationsTabPage.TabIndex = 3;
            this.annotationsTabPage.Text = "Annotations";
            this.annotationsTabPage.UseVisualStyleBackColor = true;
            // 
            // attributesTabPage
            // 
            this.attributesTabPage.Controls.Add(this.editAttributes);
            this.attributesTabPage.Location = new System.Drawing.Point(4, 22);
            this.attributesTabPage.Name = "attributesTabPage";
            this.attributesTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.attributesTabPage.Size = new System.Drawing.Size(576, 263);
            this.attributesTabPage.TabIndex = 4;
            this.attributesTabPage.Text = "Attributes";
            this.attributesTabPage.UseVisualStyleBackColor = true;
            // 
            // editAnnotations
            // 
            this.editAnnotations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editAnnotations.Location = new System.Drawing.Point(3, 3);
            this.editAnnotations.Name = "editAnnotations";
            this.editAnnotations.Size = new System.Drawing.Size(570, 257);
            this.editAnnotations.TabIndex = 0;
            this.editAnnotations.AnnotationAdded += new System.EventHandler(this.PropertyChanged);
            this.editAnnotations.AnnotationEdited += new System.EventHandler(this.PropertyChanged);
            this.editAnnotations.AnnotationRemoved += new System.EventHandler(this.PropertyChanged);
            this.editAnnotations.AnnotationMoved += new System.EventHandler(this.PropertyChanged);
            // 
            // editAttributes
            // 
            this.editAttributes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editAttributes.Location = new System.Drawing.Point(3, 3);
            this.editAttributes.Name = "editAttributes";
            this.editAttributes.Size = new System.Drawing.Size(570, 257);
            this.editAttributes.TabIndex = 0;
            this.editAttributes.AttributeAdded += new System.EventHandler(this.PropertyChanged);
            this.editAttributes.AttributeEdited += new System.EventHandler(this.PropertyChanged);
            this.editAttributes.AttributeRemoved += new System.EventHandler(this.PropertyChanged);
            this.editAttributes.AttributeMoved += new System.EventHandler(this.PropertyChanged);
            // 
            // ColumnOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "ColumnOptions";
            this.Size = new System.Drawing.Size(584, 289);
            this.Load += new System.EventHandler(this.Form_Load);
            this.tabControl.ResumeLayout(false);
            this.generalTabPage.ResumeLayout(false);
            this.generalTabPage.PerformLayout();
            this.encryptionTabPage.ResumeLayout(false);
            this.encryptionTabPage.PerformLayout();
            this.enumerationTabPage.ResumeLayout(false);
            this.enumerationTabPage.PerformLayout();
            this.annotationsTabPage.ResumeLayout(false);
            this.attributesTabPage.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage generalTabPage;
        private System.Windows.Forms.TabPage encryptionTabPage;
        private System.Windows.Forms.TabPage enumerationTabPage;
        private System.Windows.Forms.CheckBox columnPrimaryKeyCheckBox;
        private System.Windows.Forms.CheckBox columnTreatAsYesNoIndicatorCheckBox;
        private System.Windows.Forms.CheckBox columnNullableCheckBox;
        private System.Windows.Forms.TextBox columnDataTypeTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox columnFieldNameTextBox;
        private System.Windows.Forms.CheckBox encryptionCheckBox;
        private System.Windows.Forms.CheckBox enumerationCheckBox;
        private System.Windows.Forms.TextBox encryptionPropertyNameTextBox;
        private System.Windows.Forms.ComboBox encryptionVectorColumnComboBox;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ListBox enumerationValuesListBox;
        private System.Windows.Forms.CheckBox enumerationIsReferenceCheckBox;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox enumerationNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox referencedEnumerationComboBox;
        private System.Windows.Forms.Button addEnumerationValueButton;
        private System.Windows.Forms.Button editEnumerationValueButton;
        private System.Windows.Forms.Button removeEnumerationValueButton;
        private System.Windows.Forms.TabPage annotationsTabPage;
        private EditColumnMappingAnnotations editAnnotations;
        private System.Windows.Forms.TabPage attributesTabPage;
        private EditColumnMappingAttributes editAttributes;
        private System.Windows.Forms.Button enumerationAttributesButton;
        private System.Windows.Forms.Button enumerationAnnotationsButton;
    }
}