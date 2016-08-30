namespace D360
{
    partial class BindingConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BindingConfig));
            this.defaultLabel = new System.Windows.Forms.Label();
            this.defaultHeldCheck = new System.Windows.Forms.CheckBox();
            this.defaultPointerRadio = new System.Windows.Forms.RadioButton();
            this.defaultMoveRadio = new System.Windows.Forms.RadioButton();
            this.defaultPanel = new System.Windows.Forms.TableLayoutPanel();
            this.defaultTextBox = new D360.CustomTextBox();
            this.defaultDelete = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.defaultPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // defaultLabel
            // 
            this.defaultLabel.AutoSize = true;
            this.defaultPanel.SetColumnSpan(this.defaultLabel, 2);
            this.defaultLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultLabel.Location = new System.Drawing.Point(3, 0);
            this.defaultLabel.Name = "defaultLabel";
            this.defaultLabel.Size = new System.Drawing.Size(202, 19);
            this.defaultLabel.TabIndex = 27;
            this.defaultLabel.Text = "Default Label";
            this.defaultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // defaultHeldCheck
            // 
            this.defaultHeldCheck.AutoSize = true;
            this.defaultHeldCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultHeldCheck.Location = new System.Drawing.Point(3, 54);
            this.defaultHeldCheck.Name = "defaultHeldCheck";
            this.defaultHeldCheck.Size = new System.Drawing.Size(98, 20);
            this.defaultHeldCheck.TabIndex = 30;
            this.defaultHeldCheck.Text = "On Hold";
            this.defaultHeldCheck.UseVisualStyleBackColor = true;
            // 
            // defaultPointerRadio
            // 
            this.defaultPointerRadio.AutoSize = true;
            this.defaultPointerRadio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultPointerRadio.Location = new System.Drawing.Point(107, 80);
            this.defaultPointerRadio.Name = "defaultPointerRadio";
            this.defaultPointerRadio.Size = new System.Drawing.Size(98, 20);
            this.defaultPointerRadio.TabIndex = 31;
            this.defaultPointerRadio.TabStop = true;
            this.defaultPointerRadio.Text = "Pointer";
            this.defaultPointerRadio.UseVisualStyleBackColor = true;
            // 
            // defaultMoveRadio
            // 
            this.defaultMoveRadio.AutoSize = true;
            this.defaultMoveRadio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultMoveRadio.Location = new System.Drawing.Point(3, 80);
            this.defaultMoveRadio.Name = "defaultMoveRadio";
            this.defaultMoveRadio.Size = new System.Drawing.Size(98, 20);
            this.defaultMoveRadio.TabIndex = 32;
            this.defaultMoveRadio.TabStop = true;
            this.defaultMoveRadio.Text = "Move";
            this.defaultMoveRadio.UseVisualStyleBackColor = true;
            // 
            // defaultPanel
            // 
            this.defaultPanel.ColumnCount = 2;
            this.defaultPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.defaultPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.defaultPanel.Controls.Add(this.defaultTextBox, 0, 1);
            this.defaultPanel.Controls.Add(this.defaultLabel, 0, 0);
            this.defaultPanel.Controls.Add(this.defaultHeldCheck, 0, 2);
            this.defaultPanel.Controls.Add(this.defaultPointerRadio, 0, 3);
            this.defaultPanel.Controls.Add(this.defaultMoveRadio, 0, 3);
            this.defaultPanel.Controls.Add(this.defaultDelete, 0, 4);
            this.defaultPanel.Location = new System.Drawing.Point(12, 42);
            this.defaultPanel.Name = "defaultPanel";
            this.defaultPanel.RowCount = 5;
            this.defaultPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.defaultPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.defaultPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.defaultPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.defaultPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.defaultPanel.Size = new System.Drawing.Size(208, 131);
            this.defaultPanel.TabIndex = 36;
            // 
            // defaultTextBox
            // 
            this.defaultTextBox.AllowDrop = true;
            this.defaultPanel.SetColumnSpan(this.defaultTextBox, 2);
            this.defaultTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.defaultTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultTextBox.Location = new System.Drawing.Point(3, 22);
            this.defaultTextBox.Name = "defaultTextBox";
            this.defaultTextBox.ReadOnly = true;
            this.defaultTextBox.Size = new System.Drawing.Size(202, 20);
            this.defaultTextBox.TabIndex = 29;
            this.defaultTextBox.Text = "Default Binding";
            // 
            // defaultDelete
            // 
            this.defaultPanel.SetColumnSpan(this.defaultDelete, 2);
            this.defaultDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultDelete.Location = new System.Drawing.Point(3, 106);
            this.defaultDelete.Name = "defaultDelete";
            this.defaultDelete.Size = new System.Drawing.Size(202, 22);
            this.defaultDelete.TabIndex = 33;
            this.defaultDelete.Text = "Delete Binding";
            this.defaultDelete.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            this.addButton.Location = new System.Drawing.Point(12, 13);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(208, 23);
            this.addButton.TabIndex = 37;
            this.addButton.Text = "Add New Binding";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.OnAddClick);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Location = new System.Drawing.Point(13, 184);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 38;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(145, 184);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 39;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.OnCancelClick);
            // 
            // BindingConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 219);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.addButton);
            this.Controls.Add(this.defaultPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BindingConfig";
            this.Text = "Binding Config";
            this.Load += new System.EventHandler(this.OnLoad);
            this.Shown += new System.EventHandler(this.OnShow);
            this.defaultPanel.ResumeLayout(false);
            this.defaultPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel defaultPanel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Label defaultLabel;
        private CustomTextBox defaultTextBox;
        private System.Windows.Forms.CheckBox defaultHeldCheck;
        private System.Windows.Forms.RadioButton defaultPointerRadio;
        private System.Windows.Forms.RadioButton defaultMoveRadio;
        private System.Windows.Forms.Button defaultDelete;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}