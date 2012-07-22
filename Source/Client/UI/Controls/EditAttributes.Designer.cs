using QuantumConcepts.CodeGenerator.Core.ProjectSchema;
namespace QuantumConcepts.CodeGenerator.Client.UI.Controls
{
    partial class EditAttributes<T>
        where T : IProjectSchemaElement, IHasAttributes<T>, new()
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
            this.moveUpButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.removeButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.attributesListView = new System.Windows.Forms.ListView();
            this.keyColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.valueColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // moveUpButton
            // 
            this.moveUpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveUpButton.Enabled = false;
            this.moveUpButton.Font = new System.Drawing.Font("Wingdings", 8.25F);
            this.moveUpButton.Location = new System.Drawing.Point(345, 87);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(35, 23);
            this.moveUpButton.TabIndex = 52;
            this.moveUpButton.Text = "á";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.moveUpButton_Click);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.moveDownButton.Enabled = false;
            this.moveDownButton.Font = new System.Drawing.Font("Wingdings", 8.25F);
            this.moveDownButton.Location = new System.Drawing.Point(385, 87);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(35, 23);
            this.moveDownButton.TabIndex = 51;
            this.moveDownButton.Text = "â";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.moveDownButton_Click);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editButton.Enabled = false;
            this.editButton.Location = new System.Drawing.Point(345, 29);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 50;
            this.editButton.Text = "&Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Enabled = false;
            this.removeButton.Location = new System.Drawing.Point(345, 58);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(76, 23);
            this.removeButton.TabIndex = 49;
            this.removeButton.Text = "&Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(345, 0);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(76, 23);
            this.addButton.TabIndex = 48;
            this.addButton.Text = "&Add";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // attributesListView
            // 
            this.attributesListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.attributesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.keyColumnHeader,
            this.valueColumnHeader});
            this.attributesListView.FullRowSelect = true;
            this.attributesListView.Location = new System.Drawing.Point(0, 0);
            this.attributesListView.MultiSelect = false;
            this.attributesListView.Name = "attributesListView";
            this.attributesListView.Size = new System.Drawing.Size(339, 197);
            this.attributesListView.TabIndex = 47;
            this.attributesListView.UseCompatibleStateImageBehavior = false;
            this.attributesListView.View = System.Windows.Forms.View.Details;
            this.attributesListView.SelectedIndexChanged += new System.EventHandler(this.attributesListView_SelectedIndexChanged);
            this.attributesListView.DoubleClick += new System.EventHandler(this.attributesListView_DoubleClick);
            // 
            // keyColumnHeader
            // 
            this.keyColumnHeader.Text = "Key";
            // 
            // valueColumnHeader
            // 
            this.valueColumnHeader.Text = "Value";
            this.valueColumnHeader.Width = 384;
            // 
            // EditAttributes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.moveUpButton);
            this.Controls.Add(this.moveDownButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.removeButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.attributesListView);
            this.Name = "EditAttributes";
            this.Size = new System.Drawing.Size(421, 197);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.ListView attributesListView;
        private System.Windows.Forms.ColumnHeader keyColumnHeader;
        private System.Windows.Forms.ColumnHeader valueColumnHeader;
    }
}
