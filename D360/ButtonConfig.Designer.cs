namespace D360
{
    partial class ButtonConfig
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ButtonConfig));
            this.defaultLabel = new System.Windows.Forms.Label();
            this.defaultHeldCheck = new System.Windows.Forms.CheckBox();
            this.defaultPointerRadio = new System.Windows.Forms.RadioButton();
            this.defaultMoveRadio = new System.Windows.Forms.RadioButton();
            this.defaultPanel = new System.Windows.Forms.TableLayoutPanel();
            this.defaultBinding = new D360.CustomTextBox();
            this.defaultDelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
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
            this.defaultPointerRadio.Location = new System.Drawing.Point(3, 80);
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
            this.defaultMoveRadio.Location = new System.Drawing.Point(107, 80);
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
            this.defaultPanel.Controls.Add(this.defaultBinding, 0, 1);
            this.defaultPanel.Controls.Add(this.defaultLabel, 0, 0);
            this.defaultPanel.Controls.Add(this.defaultHeldCheck, 0, 2);
            this.defaultPanel.Controls.Add(this.defaultPointerRadio, 0, 3);
            this.defaultPanel.Controls.Add(this.defaultMoveRadio, 1, 3);
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
            // defaultBinding
            // 
            this.defaultBinding.AllowDrop = true;
            this.defaultPanel.SetColumnSpan(this.defaultBinding, 2);
            this.defaultBinding.Cursor = System.Windows.Forms.Cursors.Default;
            this.defaultBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultBinding.Location = new System.Drawing.Point(3, 22);
            this.defaultBinding.Name = "defaultBinding";
            this.defaultBinding.ReadOnly = true;
            this.defaultBinding.Size = new System.Drawing.Size(202, 20);
            this.defaultBinding.TabIndex = 29;
            this.defaultBinding.Text = "Default Binding";
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 13);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(208, 23);
            this.button1.TabIndex = 37;
            this.button1.Text = "Add New Binding";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ButtonConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(232, 185);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.defaultPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ButtonConfig";
            this.Text = "Button Config";
            this.Load += new System.EventHandler(this.OnLoad);
            this.Shown += new System.EventHandler(this.OnShow);
            this.defaultPanel.ResumeLayout(false);
            this.defaultPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel defaultPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label defaultLabel;
        private CustomTextBox defaultBinding;
        private System.Windows.Forms.CheckBox defaultHeldCheck;
        private System.Windows.Forms.RadioButton defaultPointerRadio;
        private System.Windows.Forms.RadioButton defaultMoveRadio;
        private System.Windows.Forms.Button defaultDelete;
    }
}