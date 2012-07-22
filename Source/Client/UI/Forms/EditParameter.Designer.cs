namespace QuantumConcepts.CodeGenerator.Client.UI.Forms
{
    partial class EditParameterDialog<T>
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
            this.nameTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dataTypeGroupBox = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.arrayOfDataTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.singleDataTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.enumerableOfDataTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.listOfDataTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.nullableDataTypeCheckBox = new System.Windows.Forms.CheckBox();
            this.dataObjectDataTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.tablesComboBox = new System.Windows.Forms.ComboBox();
            this.enumTypeComboBox = new System.Windows.Forms.ComboBox();
            this.enumTableComboBox = new System.Windows.Forms.ComboBox();
            this.enumDataTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.otherDataTypeComboBox = new System.Windows.Forms.ComboBox();
            this.otherDataTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.voidDataTypeRadioButton = new System.Windows.Forms.RadioButton();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.noneModifierRadioButton = new System.Windows.Forms.RadioButton();
            this.outModifierRadioButton = new System.Windows.Forms.RadioButton();
            this.paramsModifierRadioButton = new System.Windows.Forms.RadioButton();
            this.modifierGroupBox = new System.Windows.Forms.GroupBox();
            this.refModifierRadioButton = new System.Windows.Forms.RadioButton();
            this.attributesButton = new System.Windows.Forms.Button();
            this.editAnnotationsButton = new System.Windows.Forms.Button();
            this.dataTypeGroupBox.SuspendLayout();
            this.panel1.SuspendLayout();
            this.modifierGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameTextBox
            // 
            this.nameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameTextBox.Location = new System.Drawing.Point(59, 246);
            this.nameTextBox.Name = "nameTextBox";
            this.nameTextBox.Size = new System.Drawing.Size(439, 20);
            this.nameTextBox.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 249);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataTypeGroupBox
            // 
            this.dataTypeGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataTypeGroupBox.Controls.Add(this.panel1);
            this.dataTypeGroupBox.Controls.Add(this.nullableDataTypeCheckBox);
            this.dataTypeGroupBox.Controls.Add(this.dataObjectDataTypeRadioButton);
            this.dataTypeGroupBox.Controls.Add(this.tablesComboBox);
            this.dataTypeGroupBox.Controls.Add(this.enumTypeComboBox);
            this.dataTypeGroupBox.Controls.Add(this.enumTableComboBox);
            this.dataTypeGroupBox.Controls.Add(this.enumDataTypeRadioButton);
            this.dataTypeGroupBox.Controls.Add(this.otherDataTypeComboBox);
            this.dataTypeGroupBox.Controls.Add(this.otherDataTypeRadioButton);
            this.dataTypeGroupBox.Controls.Add(this.voidDataTypeRadioButton);
            this.dataTypeGroupBox.Location = new System.Drawing.Point(12, 60);
            this.dataTypeGroupBox.Name = "dataTypeGroupBox";
            this.dataTypeGroupBox.Size = new System.Drawing.Size(486, 180);
            this.dataTypeGroupBox.TabIndex = 11;
            this.dataTypeGroupBox.TabStop = false;
            this.dataTypeGroupBox.Text = "Data Type";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.arrayOfDataTypeRadioButton);
            this.panel1.Controls.Add(this.singleDataTypeRadioButton);
            this.panel1.Controls.Add(this.enumerableOfDataTypeRadioButton);
            this.panel1.Controls.Add(this.listOfDataTypeRadioButton);
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 30);
            this.panel1.TabIndex = 30;
            // 
            // arrayOfDataTypeRadioButton
            // 
            this.arrayOfDataTypeRadioButton.AutoSize = true;
            this.arrayOfDataTypeRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.arrayOfDataTypeRadioButton.Location = new System.Drawing.Point(84, 1);
            this.arrayOfDataTypeRadioButton.Name = "arrayOfDataTypeRadioButton";
            this.arrayOfDataTypeRadioButton.Size = new System.Drawing.Size(73, 17);
            this.arrayOfDataTypeRadioButton.TabIndex = 6;
            this.arrayOfDataTypeRadioButton.Text = "Array of....";
            this.arrayOfDataTypeRadioButton.UseVisualStyleBackColor = false;
            // 
            // singleDataTypeRadioButton
            // 
            this.singleDataTypeRadioButton.AutoSize = true;
            this.singleDataTypeRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.singleDataTypeRadioButton.Checked = true;
            this.singleDataTypeRadioButton.Location = new System.Drawing.Point(0, 1);
            this.singleDataTypeRadioButton.Name = "singleDataTypeRadioButton";
            this.singleDataTypeRadioButton.Size = new System.Drawing.Size(78, 17);
            this.singleDataTypeRadioButton.TabIndex = 5;
            this.singleDataTypeRadioButton.TabStop = true;
            this.singleDataTypeRadioButton.Text = "Single of....";
            this.singleDataTypeRadioButton.UseVisualStyleBackColor = false;
            // 
            // enumerableOfDataTypeRadioButton
            // 
            this.enumerableOfDataTypeRadioButton.AutoSize = true;
            this.enumerableOfDataTypeRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.enumerableOfDataTypeRadioButton.Location = new System.Drawing.Point(234, 1);
            this.enumerableOfDataTypeRadioButton.Name = "enumerableOfDataTypeRadioButton";
            this.enumerableOfDataTypeRadioButton.Size = new System.Drawing.Size(105, 17);
            this.enumerableOfDataTypeRadioButton.TabIndex = 8;
            this.enumerableOfDataTypeRadioButton.Text = "Enumerable of....";
            this.enumerableOfDataTypeRadioButton.UseVisualStyleBackColor = false;
            // 
            // listOfDataTypeRadioButton
            // 
            this.listOfDataTypeRadioButton.AutoSize = true;
            this.listOfDataTypeRadioButton.BackColor = System.Drawing.Color.Transparent;
            this.listOfDataTypeRadioButton.Location = new System.Drawing.Point(163, 1);
            this.listOfDataTypeRadioButton.Name = "listOfDataTypeRadioButton";
            this.listOfDataTypeRadioButton.Size = new System.Drawing.Size(65, 17);
            this.listOfDataTypeRadioButton.TabIndex = 7;
            this.listOfDataTypeRadioButton.Text = "List of....";
            this.listOfDataTypeRadioButton.UseVisualStyleBackColor = false;
            // 
            // nullableDataTypeCheckBox
            // 
            this.nullableDataTypeCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nullableDataTypeCheckBox.AutoSize = true;
            this.nullableDataTypeCheckBox.Location = new System.Drawing.Point(91, 158);
            this.nullableDataTypeCheckBox.Name = "nullableDataTypeCheckBox";
            this.nullableDataTypeCheckBox.Size = new System.Drawing.Size(64, 17);
            this.nullableDataTypeCheckBox.TabIndex = 17;
            this.nullableDataTypeCheckBox.Text = "Nullable";
            this.nullableDataTypeCheckBox.UseVisualStyleBackColor = true;
            // 
            // dataObjectDataTypeRadioButton
            // 
            this.dataObjectDataTypeRadioButton.AutoSize = true;
            this.dataObjectDataTypeRadioButton.Location = new System.Drawing.Point(6, 78);
            this.dataObjectDataTypeRadioButton.Name = "dataObjectDataTypeRadioButton";
            this.dataObjectDataTypeRadioButton.Size = new System.Drawing.Size(79, 17);
            this.dataObjectDataTypeRadioButton.TabIndex = 10;
            this.dataObjectDataTypeRadioButton.Text = "DataObject";
            this.dataObjectDataTypeRadioButton.UseVisualStyleBackColor = true;
            this.dataObjectDataTypeRadioButton.CheckedChanged += new System.EventHandler(this.DataType_CheckChanged);
            // 
            // tablesComboBox
            // 
            this.tablesComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tablesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tablesComboBox.FormattingEnabled = true;
            this.tablesComboBox.Location = new System.Drawing.Point(91, 77);
            this.tablesComboBox.Name = "tablesComboBox";
            this.tablesComboBox.Size = new System.Drawing.Size(389, 21);
            this.tablesComboBox.TabIndex = 11;
            this.tablesComboBox.Visible = false;
            // 
            // enumTypeComboBox
            // 
            this.enumTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.enumTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.enumTypeComboBox.FormattingEnabled = true;
            this.enumTypeComboBox.Location = new System.Drawing.Point(214, 104);
            this.enumTypeComboBox.Name = "enumTypeComboBox";
            this.enumTypeComboBox.Size = new System.Drawing.Size(266, 21);
            this.enumTypeComboBox.TabIndex = 14;
            this.enumTypeComboBox.Visible = false;
            this.enumTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.enumTypeComboBox_SelectedIndexChanged);
            // 
            // enumTableComboBox
            // 
            this.enumTableComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.enumTableComboBox.FormattingEnabled = true;
            this.enumTableComboBox.Location = new System.Drawing.Point(91, 104);
            this.enumTableComboBox.Name = "enumTableComboBox";
            this.enumTableComboBox.Size = new System.Drawing.Size(117, 21);
            this.enumTableComboBox.TabIndex = 13;
            this.enumTableComboBox.Visible = false;
            this.enumTableComboBox.SelectedIndexChanged += new System.EventHandler(this.enumTableComboBox_SelectedIndexChanged);
            // 
            // enumDataTypeRadioButton
            // 
            this.enumDataTypeRadioButton.AutoSize = true;
            this.enumDataTypeRadioButton.Location = new System.Drawing.Point(6, 105);
            this.enumDataTypeRadioButton.Name = "enumDataTypeRadioButton";
            this.enumDataTypeRadioButton.Size = new System.Drawing.Size(52, 17);
            this.enumDataTypeRadioButton.TabIndex = 12;
            this.enumDataTypeRadioButton.Text = "Enum";
            this.enumDataTypeRadioButton.UseVisualStyleBackColor = true;
            this.enumDataTypeRadioButton.CheckedChanged += new System.EventHandler(this.DataType_CheckChanged);
            // 
            // otherDataTypeComboBox
            // 
            this.otherDataTypeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.otherDataTypeComboBox.FormattingEnabled = true;
            this.otherDataTypeComboBox.Items.AddRange(new object[] {
            "bool",
            "bool?",
            "char",
            "char?",
            "decimal",
            "decimal?",
            "double",
            "double?",
            "int",
            "int?",
            "string"});
            this.otherDataTypeComboBox.Location = new System.Drawing.Point(91, 131);
            this.otherDataTypeComboBox.Name = "otherDataTypeComboBox";
            this.otherDataTypeComboBox.Size = new System.Drawing.Size(389, 21);
            this.otherDataTypeComboBox.TabIndex = 16;
            // 
            // otherDataTypeRadioButton
            // 
            this.otherDataTypeRadioButton.AutoSize = true;
            this.otherDataTypeRadioButton.Location = new System.Drawing.Point(6, 132);
            this.otherDataTypeRadioButton.Name = "otherDataTypeRadioButton";
            this.otherDataTypeRadioButton.Size = new System.Drawing.Size(51, 17);
            this.otherDataTypeRadioButton.TabIndex = 15;
            this.otherDataTypeRadioButton.Text = "Other";
            this.otherDataTypeRadioButton.UseVisualStyleBackColor = true;
            this.otherDataTypeRadioButton.CheckedChanged += new System.EventHandler(this.DataType_CheckChanged);
            // 
            // voidDataTypeRadioButton
            // 
            this.voidDataTypeRadioButton.AutoSize = true;
            this.voidDataTypeRadioButton.Location = new System.Drawing.Point(6, 55);
            this.voidDataTypeRadioButton.Name = "voidDataTypeRadioButton";
            this.voidDataTypeRadioButton.Size = new System.Drawing.Size(80, 17);
            this.voidDataTypeRadioButton.TabIndex = 9;
            this.voidDataTypeRadioButton.Text = "None (void)";
            this.voidDataTypeRadioButton.UseVisualStyleBackColor = true;
            this.voidDataTypeRadioButton.CheckedChanged += new System.EventHandler(this.DataType_CheckChanged);
            // 
            // okButton
            // 
            this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.okButton.Location = new System.Drawing.Point(342, 274);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 21;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(423, 274);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 22;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // noneModifierRadioButton
            // 
            this.noneModifierRadioButton.AutoSize = true;
            this.noneModifierRadioButton.Checked = true;
            this.noneModifierRadioButton.Location = new System.Drawing.Point(6, 19);
            this.noneModifierRadioButton.Name = "noneModifierRadioButton";
            this.noneModifierRadioButton.Size = new System.Drawing.Size(51, 17);
            this.noneModifierRadioButton.TabIndex = 1;
            this.noneModifierRadioButton.TabStop = true;
            this.noneModifierRadioButton.Text = "None";
            this.noneModifierRadioButton.UseVisualStyleBackColor = true;
            // 
            // outModifierRadioButton
            // 
            this.outModifierRadioButton.AutoSize = true;
            this.outModifierRadioButton.Location = new System.Drawing.Point(106, 19);
            this.outModifierRadioButton.Name = "outModifierRadioButton";
            this.outModifierRadioButton.Size = new System.Drawing.Size(40, 17);
            this.outModifierRadioButton.TabIndex = 3;
            this.outModifierRadioButton.Text = "out";
            this.outModifierRadioButton.UseVisualStyleBackColor = true;
            // 
            // paramsModifierRadioButton
            // 
            this.paramsModifierRadioButton.AutoSize = true;
            this.paramsModifierRadioButton.Location = new System.Drawing.Point(154, 19);
            this.paramsModifierRadioButton.Name = "paramsModifierRadioButton";
            this.paramsModifierRadioButton.Size = new System.Drawing.Size(59, 17);
            this.paramsModifierRadioButton.TabIndex = 4;
            this.paramsModifierRadioButton.Text = "params";
            this.paramsModifierRadioButton.UseVisualStyleBackColor = true;
            // 
            // modifierGroupBox
            // 
            this.modifierGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.modifierGroupBox.Controls.Add(this.refModifierRadioButton);
            this.modifierGroupBox.Controls.Add(this.noneModifierRadioButton);
            this.modifierGroupBox.Controls.Add(this.paramsModifierRadioButton);
            this.modifierGroupBox.Controls.Add(this.outModifierRadioButton);
            this.modifierGroupBox.Location = new System.Drawing.Point(12, 12);
            this.modifierGroupBox.Name = "modifierGroupBox";
            this.modifierGroupBox.Size = new System.Drawing.Size(486, 42);
            this.modifierGroupBox.TabIndex = 19;
            this.modifierGroupBox.TabStop = false;
            this.modifierGroupBox.Text = "Modifier";
            // 
            // refModifierRadioButton
            // 
            this.refModifierRadioButton.AutoSize = true;
            this.refModifierRadioButton.Location = new System.Drawing.Point(63, 19);
            this.refModifierRadioButton.Name = "refModifierRadioButton";
            this.refModifierRadioButton.Size = new System.Drawing.Size(37, 17);
            this.refModifierRadioButton.TabIndex = 2;
            this.refModifierRadioButton.Text = "ref";
            this.refModifierRadioButton.UseVisualStyleBackColor = true;
            // 
            // attributesButton
            // 
            this.attributesButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.attributesButton.Location = new System.Drawing.Point(92, 274);
            this.attributesButton.Name = "attributesButton";
            this.attributesButton.Size = new System.Drawing.Size(75, 23);
            this.attributesButton.TabIndex = 20;
            this.attributesButton.Text = "&Attributes";
            this.attributesButton.UseVisualStyleBackColor = true;
            this.attributesButton.Click += new System.EventHandler(this.attributesButton_Click);
            // 
            // editAnnotationsButton
            // 
            this.editAnnotationsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.editAnnotationsButton.Location = new System.Drawing.Point(11, 274);
            this.editAnnotationsButton.Name = "editAnnotationsButton";
            this.editAnnotationsButton.Size = new System.Drawing.Size(75, 23);
            this.editAnnotationsButton.TabIndex = 19;
            this.editAnnotationsButton.Text = "A&nnotations";
            this.editAnnotationsButton.UseVisualStyleBackColor = true;
            this.editAnnotationsButton.Click += new System.EventHandler(this.editAnnotationsButton_Click);
            // 
            // EditParameterDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(510, 309);
            this.Controls.Add(this.attributesButton);
            this.Controls.Add(this.editAnnotationsButton);
            this.Controls.Add(this.nameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.modifierGroupBox);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.dataTypeGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "EditParameterDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Parameter";
            this.Load += new System.EventHandler(this.EditParameterDialog_Load);
            this.dataTypeGroupBox.ResumeLayout(false);
            this.dataTypeGroupBox.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.modifierGroupBox.ResumeLayout(false);
            this.modifierGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nameTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox dataTypeGroupBox;
        private System.Windows.Forms.RadioButton otherDataTypeRadioButton;
        private System.Windows.Forms.RadioButton voidDataTypeRadioButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.RadioButton noneModifierRadioButton;
        private System.Windows.Forms.RadioButton outModifierRadioButton;
        private System.Windows.Forms.RadioButton paramsModifierRadioButton;
        private System.Windows.Forms.RadioButton dataObjectDataTypeRadioButton;
        private System.Windows.Forms.ComboBox tablesComboBox;
        private System.Windows.Forms.ComboBox otherDataTypeComboBox;
        private System.Windows.Forms.RadioButton enumDataTypeRadioButton;
        private System.Windows.Forms.ComboBox enumTypeComboBox;
        private System.Windows.Forms.ComboBox enumTableComboBox;
        private System.Windows.Forms.GroupBox modifierGroupBox;
        private System.Windows.Forms.CheckBox nullableDataTypeCheckBox;
        private System.Windows.Forms.RadioButton listOfDataTypeRadioButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton singleDataTypeRadioButton;
        private System.Windows.Forms.RadioButton enumerableOfDataTypeRadioButton;
        private System.Windows.Forms.RadioButton arrayOfDataTypeRadioButton;
        private System.Windows.Forms.Button attributesButton;
        private System.Windows.Forms.Button editAnnotationsButton;
        private System.Windows.Forms.RadioButton refModifierRadioButton;
    }
}