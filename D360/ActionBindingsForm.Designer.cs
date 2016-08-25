namespace D360
{
    partial class ActionBindingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActionBindingsForm));
            this.defaultLabel = new System.Windows.Forms.Label();
            this.defaultTextBox = new System.Windows.Forms.TextBox();
            this.saveAndCloseButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // defaultLabel
            // 
            this.defaultLabel.AutoSize = true;
            this.defaultLabel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.defaultLabel.Location = new System.Drawing.Point(12, 9);
            this.defaultLabel.Name = "defaultLabel";
            this.defaultLabel.Size = new System.Drawing.Size(114, 13);
            this.defaultLabel.TabIndex = 0;
            this.defaultLabel.Text = "Force_Stand_Still_Key";
            this.defaultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // defaultTextBox
            // 
            this.defaultTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.defaultTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.defaultTextBox.Enabled = false;
            this.defaultTextBox.Location = new System.Drawing.Point(137, 6);
            this.defaultTextBox.Name = "defaultTextBox";
            this.defaultTextBox.ReadOnly = true;
            this.defaultTextBox.Size = new System.Drawing.Size(120, 20);
            this.defaultTextBox.TabIndex = 1;
            // 
            // saveAndCloseButton
            // 
            this.saveAndCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveAndCloseButton.Location = new System.Drawing.Point(163, 60);
            this.saveAndCloseButton.Name = "saveAndCloseButton";
            this.saveAndCloseButton.Size = new System.Drawing.Size(93, 23);
            this.saveAndCloseButton.TabIndex = 22;
            this.saveAndCloseButton.Text = "Save and Close";
            this.saveAndCloseButton.UseVisualStyleBackColor = true;
            this.saveAndCloseButton.Click += new System.EventHandler(this.OnSaveAndCloseButtonClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cancelButton.Location = new System.Drawing.Point(12, 60);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(93, 23);
            this.cancelButton.TabIndex = 23;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.OnCancelButtonClick);
            // 
            // ActionBindingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(269, 95);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveAndCloseButton);
            this.Controls.Add(this.defaultTextBox);
            this.Controls.Add(this.defaultLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "ActionBindingsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Diablo 3 Key Bindings";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Shown += new System.EventHandler(this.OnShown);
            this.VisibleChanged += new System.EventHandler(this.OnVisibleChanged);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.OnKeyPress);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnKeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label defaultLabel;
        private System.Windows.Forms.TextBox defaultTextBox;
        private System.Windows.Forms.Button saveAndCloseButton;
        private System.Windows.Forms.Button cancelButton;
    }
}