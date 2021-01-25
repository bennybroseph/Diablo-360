namespace D360.Controls
{
    sealed partial class BindingControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.bindingNumberLabel = new System.Windows.Forms.Label();
            this.bindingTypeComboBox = new System.Windows.Forms.ComboBox();
            this.inputModeComboBox = new System.Windows.Forms.ComboBox();
            this.isHoldActionCheckBox = new System.Windows.Forms.CheckBox();
            this.isTargetedActionCheckBox = new System.Windows.Forms.CheckBox();
            this.moveUpButton = new System.Windows.Forms.Button();
            this.moveDownButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.bindingNumberLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.bindingTypeComboBox, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.inputModeComboBox, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.isHoldActionCheckBox, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.isTargetedActionCheckBox, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.moveUpButton, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.moveDownButton, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.deleteButton, 0, 6);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(215, 200);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // bindingNumberLabel
            // 
            this.bindingNumberLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.bindingNumberLabel, 2);
            this.bindingNumberLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bindingNumberLabel.Location = new System.Drawing.Point(3, 0);
            this.bindingNumberLabel.Name = "bindingNumberLabel";
            this.bindingNumberLabel.Size = new System.Drawing.Size(209, 28);
            this.bindingNumberLabel.TabIndex = 0;
            this.bindingNumberLabel.Text = "Binding Number Here";
            this.bindingNumberLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bindingTypeComboBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.bindingTypeComboBox, 2);
            this.bindingTypeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bindingTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bindingTypeComboBox.FormattingEnabled = true;
            this.bindingTypeComboBox.Location = new System.Drawing.Point(3, 31);
            this.bindingTypeComboBox.Name = "bindingTypeComboBox";
            this.bindingTypeComboBox.Size = new System.Drawing.Size(209, 21);
            this.bindingTypeComboBox.TabIndex = 1;
            this.bindingTypeComboBox.SelectedIndexChanged += new System.EventHandler(this.OnBindingTypeChanged);
            // 
            // inputModeComboBox
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.inputModeComboBox, 2);
            this.inputModeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.inputModeComboBox.FormattingEnabled = true;
            this.inputModeComboBox.Location = new System.Drawing.Point(3, 87);
            this.inputModeComboBox.Name = "inputModeComboBox";
            this.inputModeComboBox.Size = new System.Drawing.Size(209, 21);
            this.inputModeComboBox.TabIndex = 2;
            this.inputModeComboBox.SelectedIndexChanged += new System.EventHandler(this.OnInputModeChanged);
            // 
            // isHoldActionCheckBox
            // 
            this.isHoldActionCheckBox.AutoSize = true;
            this.isHoldActionCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.isHoldActionCheckBox.Location = new System.Drawing.Point(3, 115);
            this.isHoldActionCheckBox.Name = "isHoldActionCheckBox";
            this.isHoldActionCheckBox.Size = new System.Drawing.Size(101, 22);
            this.isHoldActionCheckBox.TabIndex = 3;
            this.isHoldActionCheckBox.Text = "On Hold";
            this.isHoldActionCheckBox.UseVisualStyleBackColor = true;
            this.isHoldActionCheckBox.CheckedChanged += new System.EventHandler(this.OnHoldCheckChanged);
            // 
            // isTargetedActionCheckBox
            // 
            this.isTargetedActionCheckBox.AutoSize = true;
            this.isTargetedActionCheckBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.isTargetedActionCheckBox.Location = new System.Drawing.Point(110, 115);
            this.isTargetedActionCheckBox.Name = "isTargetedActionCheckBox";
            this.isTargetedActionCheckBox.Size = new System.Drawing.Size(102, 22);
            this.isTargetedActionCheckBox.TabIndex = 4;
            this.isTargetedActionCheckBox.Text = "Targeted";
            this.isTargetedActionCheckBox.UseVisualStyleBackColor = true;
            this.isTargetedActionCheckBox.CheckedChanged += new System.EventHandler(this.OnTargetedCheckChanged);
            // 
            // moveUpButton
            // 
            this.moveUpButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moveUpButton.Location = new System.Drawing.Point(3, 143);
            this.moveUpButton.Name = "moveUpButton";
            this.moveUpButton.Size = new System.Drawing.Size(101, 22);
            this.moveUpButton.TabIndex = 5;
            this.moveUpButton.Text = "▲";
            this.moveUpButton.UseVisualStyleBackColor = true;
            this.moveUpButton.Click += new System.EventHandler(this.OnUpClick);
            // 
            // moveDownButton
            // 
            this.moveDownButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.moveDownButton.Location = new System.Drawing.Point(110, 143);
            this.moveDownButton.Name = "moveDownButton";
            this.moveDownButton.Size = new System.Drawing.Size(102, 22);
            this.moveDownButton.TabIndex = 6;
            this.moveDownButton.Text = "▼";
            this.moveDownButton.UseVisualStyleBackColor = true;
            this.moveDownButton.Click += new System.EventHandler(this.OnDownClick);
            // 
            // deleteButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.deleteButton, 2);
            this.deleteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteButton.Location = new System.Drawing.Point(3, 171);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(209, 26);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Delete Binding";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.OnDeleteClick);
            // 
            // BindingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "BindingControl";
            this.Size = new System.Drawing.Size(215, 200);
            this.Load += new System.EventHandler(this.OnLoad);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label bindingNumberLabel;
        private System.Windows.Forms.ComboBox bindingTypeComboBox;
        private System.Windows.Forms.ComboBox inputModeComboBox;
        private System.Windows.Forms.CheckBox isHoldActionCheckBox;
        private System.Windows.Forms.CheckBox isTargetedActionCheckBox;
        private System.Windows.Forms.Button moveUpButton;
        private System.Windows.Forms.Button moveDownButton;
        private System.Windows.Forms.Button deleteButton;
    }
}
