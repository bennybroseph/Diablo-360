namespace D360
{
    partial class BindingConfigForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BindingConfigForm));
            this.defaultLabel = new System.Windows.Forms.Label();
            this.defaultHeldCheck = new System.Windows.Forms.CheckBox();
            this.defaultPointerRadio = new System.Windows.Forms.RadioButton();
            this.defaultMoveRadio = new System.Windows.Forms.RadioButton();
            this.defaultPanel = new System.Windows.Forms.TableLayoutPanel();
            this.defaultTargetCheck = new System.Windows.Forms.CheckBox();
            this.defaultTextBox = new D360.CustomTextBox();
            this.defaultDelete = new System.Windows.Forms.Button();
            this.defaultComboBox = new System.Windows.Forms.ComboBox();
            this.addButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.bindingsTabPage = new System.Windows.Forms.TabPage();
            this.otherTabPage = new System.Windows.Forms.TabPage();
            this.actionZoneLabel = new System.Windows.Forms.Label();
            this.modeLabel = new System.Windows.Forms.Label();
            this.actionZoneValueLabel = new System.Windows.Forms.Label();
            this.deadZoneValueLabel = new System.Windows.Forms.Label();
            this.modeComboBox = new System.Windows.Forms.ComboBox();
            this.actionZoneTrackBar = new System.Windows.Forms.TrackBar();
            this.deadZoneLabel = new System.Windows.Forms.Label();
            this.deadZoneTrackBar = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.defaultPanel.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.bindingsTabPage.SuspendLayout();
            this.otherTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionZoneTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deadZoneTrackBar)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // defaultLabel
            // 
            this.defaultLabel.AutoSize = true;
            this.defaultPanel.SetColumnSpan(this.defaultLabel, 2);
            this.defaultLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultLabel.Location = new System.Drawing.Point(4, 0);
            this.defaultLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.defaultLabel.Name = "defaultLabel";
            this.defaultLabel.Size = new System.Drawing.Size(306, 36);
            this.defaultLabel.TabIndex = 27;
            this.defaultLabel.Text = "Default Label";
            this.defaultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // defaultHeldCheck
            // 
            this.defaultHeldCheck.AutoSize = true;
            this.defaultHeldCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultHeldCheck.Location = new System.Drawing.Point(4, 133);
            this.defaultHeldCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.defaultHeldCheck.Name = "defaultHeldCheck";
            this.defaultHeldCheck.Size = new System.Drawing.Size(149, 26);
            this.defaultHeldCheck.TabIndex = 30;
            this.defaultHeldCheck.Text = "On Hold";
            this.defaultHeldCheck.UseVisualStyleBackColor = true;
            // 
            // defaultPointerRadio
            // 
            this.defaultPointerRadio.AutoSize = true;
            this.defaultPointerRadio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultPointerRadio.Location = new System.Drawing.Point(4, 169);
            this.defaultPointerRadio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.defaultPointerRadio.Name = "defaultPointerRadio";
            this.defaultPointerRadio.Size = new System.Drawing.Size(149, 26);
            this.defaultPointerRadio.TabIndex = 31;
            this.defaultPointerRadio.TabStop = true;
            this.defaultPointerRadio.Text = "Pointer";
            this.defaultPointerRadio.UseVisualStyleBackColor = true;
            // 
            // defaultMoveRadio
            // 
            this.defaultMoveRadio.AutoSize = true;
            this.defaultMoveRadio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultMoveRadio.Location = new System.Drawing.Point(161, 169);
            this.defaultMoveRadio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.defaultMoveRadio.Name = "defaultMoveRadio";
            this.defaultMoveRadio.Size = new System.Drawing.Size(149, 26);
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
            this.defaultPanel.Controls.Add(this.defaultTargetCheck, 1, 3);
            this.defaultPanel.Controls.Add(this.defaultTextBox, 0, 2);
            this.defaultPanel.Controls.Add(this.defaultLabel, 0, 0);
            this.defaultPanel.Controls.Add(this.defaultHeldCheck, 0, 3);
            this.defaultPanel.Controls.Add(this.defaultPointerRadio, 0, 4);
            this.defaultPanel.Controls.Add(this.defaultMoveRadio, 0, 4);
            this.defaultPanel.Controls.Add(this.defaultDelete, 0, 5);
            this.defaultPanel.Controls.Add(this.defaultComboBox, 0, 1);
            this.defaultPanel.Location = new System.Drawing.Point(9, 49);
            this.defaultPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.defaultPanel.Name = "defaultPanel";
            this.defaultPanel.RowCount = 6;
            this.defaultPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.defaultPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.defaultPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.defaultPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.defaultPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.defaultPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 17.5F));
            this.defaultPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.defaultPanel.Size = new System.Drawing.Size(314, 246);
            this.defaultPanel.TabIndex = 36;
            this.defaultPanel.Visible = false;
            // 
            // defaultTargetCheck
            // 
            this.defaultTargetCheck.AutoSize = true;
            this.defaultTargetCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultTargetCheck.Location = new System.Drawing.Point(161, 133);
            this.defaultTargetCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.defaultTargetCheck.Name = "defaultTargetCheck";
            this.defaultTargetCheck.Size = new System.Drawing.Size(149, 26);
            this.defaultTargetCheck.TabIndex = 35;
            this.defaultTargetCheck.Text = "Targeted";
            this.defaultTargetCheck.UseVisualStyleBackColor = true;
            // 
            // defaultTextBox
            // 
            this.defaultTextBox.AllowDrop = true;
            this.defaultPanel.SetColumnSpan(this.defaultTextBox, 2);
            this.defaultTextBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.defaultTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultTextBox.Location = new System.Drawing.Point(4, 90);
            this.defaultTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.defaultTextBox.Name = "defaultTextBox";
            this.defaultTextBox.ReadOnly = true;
            this.defaultTextBox.Size = new System.Drawing.Size(306, 20);
            this.defaultTextBox.TabIndex = 29;
            this.defaultTextBox.Text = "Default Binding";
            // 
            // defaultDelete
            // 
            this.defaultPanel.SetColumnSpan(this.defaultDelete, 2);
            this.defaultDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultDelete.Location = new System.Drawing.Point(4, 205);
            this.defaultDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.defaultDelete.Name = "defaultDelete";
            this.defaultDelete.Size = new System.Drawing.Size(306, 36);
            this.defaultDelete.TabIndex = 33;
            this.defaultDelete.Text = "Delete Binding";
            this.defaultDelete.UseVisualStyleBackColor = true;
            // 
            // defaultComboBox
            // 
            this.defaultPanel.SetColumnSpan(this.defaultComboBox, 2);
            this.defaultComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.defaultComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.defaultComboBox.FormattingEnabled = true;
            this.defaultComboBox.Location = new System.Drawing.Point(4, 41);
            this.defaultComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.defaultComboBox.Name = "defaultComboBox";
            this.defaultComboBox.Size = new System.Drawing.Size(306, 28);
            this.defaultComboBox.TabIndex = 34;
            // 
            // addButton
            // 
            this.addButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addButton.Location = new System.Drawing.Point(4, 5);
            this.addButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(328, 35);
            this.addButton.TabIndex = 37;
            this.addButton.Text = "Add New Binding";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.OnAddClick);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Location = new System.Drawing.Point(4, 5);
            this.saveButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(112, 35);
            this.saveButton.TabIndex = 38;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(226, 5);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(112, 35);
            this.cancelButton.TabIndex = 39;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.OnCancelClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.bindingsTabPage);
            this.tabControl1.Controls.Add(this.otherTabPage);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(344, 383);
            this.tabControl1.TabIndex = 40;
            // 
            // bindingsTabPage
            // 
            this.bindingsTabPage.Controls.Add(this.defaultPanel);
            this.bindingsTabPage.Controls.Add(this.addButton);
            this.bindingsTabPage.Location = new System.Drawing.Point(4, 29);
            this.bindingsTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bindingsTabPage.Name = "bindingsTabPage";
            this.bindingsTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bindingsTabPage.Size = new System.Drawing.Size(336, 350);
            this.bindingsTabPage.TabIndex = 0;
            this.bindingsTabPage.Text = "Bindings";
            this.bindingsTabPage.UseVisualStyleBackColor = true;
            // 
            // otherTabPage
            // 
            this.otherTabPage.Controls.Add(this.actionZoneLabel);
            this.otherTabPage.Controls.Add(this.modeLabel);
            this.otherTabPage.Controls.Add(this.actionZoneValueLabel);
            this.otherTabPage.Controls.Add(this.deadZoneValueLabel);
            this.otherTabPage.Controls.Add(this.modeComboBox);
            this.otherTabPage.Controls.Add(this.actionZoneTrackBar);
            this.otherTabPage.Controls.Add(this.deadZoneLabel);
            this.otherTabPage.Controls.Add(this.deadZoneTrackBar);
            this.otherTabPage.Location = new System.Drawing.Point(4, 29);
            this.otherTabPage.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.otherTabPage.Name = "otherTabPage";
            this.otherTabPage.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.otherTabPage.Size = new System.Drawing.Size(336, 350);
            this.otherTabPage.TabIndex = 1;
            this.otherTabPage.Text = "Other";
            this.otherTabPage.UseVisualStyleBackColor = true;
            // 
            // actionZoneLabel
            // 
            this.actionZoneLabel.Location = new System.Drawing.Point(9, 111);
            this.actionZoneLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.actionZoneLabel.Name = "actionZoneLabel";
            this.actionZoneLabel.Size = new System.Drawing.Size(314, 20);
            this.actionZoneLabel.TabIndex = 1;
            this.actionZoneLabel.Text = "Action Dead Zone";
            this.actionZoneLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.actionZoneLabel.Visible = false;
            // 
            // modeLabel
            // 
            this.modeLabel.Location = new System.Drawing.Point(9, 212);
            this.modeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(314, 20);
            this.modeLabel.TabIndex = 6;
            this.modeLabel.Text = "Mode";
            this.modeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.modeLabel.Visible = false;
            // 
            // actionZoneValueLabel
            // 
            this.actionZoneValueLabel.Location = new System.Drawing.Point(9, 140);
            this.actionZoneValueLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.actionZoneValueLabel.Name = "actionZoneValueLabel";
            this.actionZoneValueLabel.Size = new System.Drawing.Size(314, 20);
            this.actionZoneValueLabel.TabIndex = 5;
            this.actionZoneValueLabel.Text = "Value%";
            this.actionZoneValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.actionZoneValueLabel.Visible = false;
            // 
            // deadZoneValueLabel
            // 
            this.deadZoneValueLabel.Location = new System.Drawing.Point(9, 29);
            this.deadZoneValueLabel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.deadZoneValueLabel.Name = "deadZoneValueLabel";
            this.deadZoneValueLabel.Size = new System.Drawing.Size(314, 20);
            this.deadZoneValueLabel.TabIndex = 4;
            this.deadZoneValueLabel.Text = "Value%";
            this.deadZoneValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.deadZoneValueLabel.Visible = false;
            // 
            // modeComboBox
            // 
            this.modeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeComboBox.FormattingEnabled = true;
            this.modeComboBox.Location = new System.Drawing.Point(9, 237);
            this.modeComboBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.modeComboBox.Name = "modeComboBox";
            this.modeComboBox.Size = new System.Drawing.Size(312, 28);
            this.modeComboBox.TabIndex = 3;
            this.modeComboBox.Visible = false;
            this.modeComboBox.SelectedIndexChanged += new System.EventHandler(this.OnStickModeChanged);
            // 
            // actionZoneTrackBar
            // 
            this.actionZoneTrackBar.AutoSize = false;
            this.actionZoneTrackBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.actionZoneTrackBar.Location = new System.Drawing.Point(9, 169);
            this.actionZoneTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.actionZoneTrackBar.Maximum = 100;
            this.actionZoneTrackBar.Name = "actionZoneTrackBar";
            this.actionZoneTrackBar.Size = new System.Drawing.Size(314, 38);
            this.actionZoneTrackBar.TabIndex = 2;
            this.actionZoneTrackBar.TickFrequency = 10;
            this.actionZoneTrackBar.Visible = false;
            this.actionZoneTrackBar.ValueChanged += new System.EventHandler(this.OnActionZoneValueChanged);
            // 
            // deadZoneLabel
            // 
            this.deadZoneLabel.Location = new System.Drawing.Point(9, 0);
            this.deadZoneLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 5);
            this.deadZoneLabel.Name = "deadZoneLabel";
            this.deadZoneLabel.Size = new System.Drawing.Size(314, 20);
            this.deadZoneLabel.TabIndex = 0;
            this.deadZoneLabel.Text = "Dead Zone";
            this.deadZoneLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.deadZoneLabel.Visible = false;
            // 
            // deadZoneTrackBar
            // 
            this.deadZoneTrackBar.AutoSize = false;
            this.deadZoneTrackBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.deadZoneTrackBar.Location = new System.Drawing.Point(9, 58);
            this.deadZoneTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 9);
            this.deadZoneTrackBar.Maximum = 100;
            this.deadZoneTrackBar.Name = "deadZoneTrackBar";
            this.deadZoneTrackBar.Size = new System.Drawing.Size(314, 38);
            this.deadZoneTrackBar.TabIndex = 0;
            this.deadZoneTrackBar.TickFrequency = 10;
            this.deadZoneTrackBar.Visible = false;
            this.deadZoneTrackBar.ValueChanged += new System.EventHandler(this.OnDeadZoneValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 338);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(344, 45);
            this.panel1.TabIndex = 41;
            // 
            // BindingConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 383);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BindingConfigForm";
            this.Text = "Binding Config";
            this.Load += new System.EventHandler(this.OnLoad);
            this.Shown += new System.EventHandler(this.OnShow);
            this.defaultPanel.ResumeLayout(false);
            this.defaultPanel.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.bindingsTabPage.ResumeLayout(false);
            this.otherTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.actionZoneTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deadZoneTrackBar)).EndInit();
            this.panel1.ResumeLayout(false);
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
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage bindingsTabPage;
        private System.Windows.Forms.TabPage otherTabPage;
        private System.Windows.Forms.ComboBox defaultComboBox;
        private System.Windows.Forms.Label deadZoneLabel;
        private System.Windows.Forms.TrackBar deadZoneTrackBar;
        private System.Windows.Forms.ComboBox modeComboBox;
        private System.Windows.Forms.Label actionZoneLabel;
        private System.Windows.Forms.TrackBar actionZoneTrackBar;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.Label actionZoneValueLabel;
        private System.Windows.Forms.Label deadZoneValueLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox defaultTargetCheck;
    }
}