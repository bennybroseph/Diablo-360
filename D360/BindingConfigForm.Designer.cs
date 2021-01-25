namespace D360
{
    sealed partial class BindingConfigForm
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
            this.addButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.bindingsTabPage = new System.Windows.Forms.TabPage();
            this.defaultBindingControl = new D360.Controls.BindingControl();
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
            this.bindingsFlowLayoutPanel = new D360.DoubleBufferedFlowLayoutPanel();
            this.tabControl1.SuspendLayout();
            this.bindingsTabPage.SuspendLayout();
            this.otherTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actionZoneTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deadZoneTrackBar)).BeginInit();
            this.panel1.SuspendLayout();
            this.bindingsFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            //
            // addButton
            //
            this.addButton.Dock = System.Windows.Forms.DockStyle.Top;
            this.addButton.Location = new System.Drawing.Point(0, 0);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(221, 23);
            this.addButton.TabIndex = 37;
            this.addButton.Text = "Add New Binding";
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.OnAddClick);
            //
            // saveButton
            //
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveButton.Location = new System.Drawing.Point(3, 3);
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
            this.cancelButton.Location = new System.Drawing.Point(151, 3);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
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
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(229, 260);
            this.tabControl1.TabIndex = 40;
            //
            // bindingsTabPage
            //
            this.bindingsTabPage.Controls.Add(this.bindingsFlowLayoutPanel);
            this.bindingsTabPage.Controls.Add(this.addButton);
            this.bindingsTabPage.Location = new System.Drawing.Point(4, 22);
            this.bindingsTabPage.Name = "bindingsTabPage";
            this.bindingsTabPage.Size = new System.Drawing.Size(221, 234);
            this.bindingsTabPage.TabIndex = 0;
            this.bindingsTabPage.Text = "Bindings";
            this.bindingsTabPage.UseVisualStyleBackColor = true;
            //
            // defaultBindingControl
            //
            this.defaultBindingControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.defaultBindingControl.Location = new System.Drawing.Point(3, 3);
            this.defaultBindingControl.Name = "defaultBindingControl";
            this.defaultBindingControl.Size = new System.Drawing.Size(215, 200);
            this.defaultBindingControl.TabIndex = 38;
            this.defaultBindingControl.Visible = false;
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
            this.otherTabPage.Location = new System.Drawing.Point(4, 22);
            this.otherTabPage.Name = "otherTabPage";
            this.otherTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.otherTabPage.Size = new System.Drawing.Size(221, 234);
            this.otherTabPage.TabIndex = 1;
            this.otherTabPage.Text = "Other";
            this.otherTabPage.UseVisualStyleBackColor = true;
            //
            // actionZoneLabel
            //
            this.actionZoneLabel.Location = new System.Drawing.Point(6, 72);
            this.actionZoneLabel.Margin = new System.Windows.Forms.Padding(3);
            this.actionZoneLabel.Name = "actionZoneLabel";
            this.actionZoneLabel.Size = new System.Drawing.Size(209, 13);
            this.actionZoneLabel.TabIndex = 1;
            this.actionZoneLabel.Text = "Action Dead Zone";
            this.actionZoneLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.actionZoneLabel.Visible = false;
            //
            // modeLabel
            //
            this.modeLabel.Location = new System.Drawing.Point(6, 138);
            this.modeLabel.Name = "modeLabel";
            this.modeLabel.Size = new System.Drawing.Size(209, 13);
            this.modeLabel.TabIndex = 6;
            this.modeLabel.Text = "Mode";
            this.modeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.modeLabel.Visible = false;
            //
            // actionZoneValueLabel
            //
            this.actionZoneValueLabel.Location = new System.Drawing.Point(6, 91);
            this.actionZoneValueLabel.Margin = new System.Windows.Forms.Padding(3);
            this.actionZoneValueLabel.Name = "actionZoneValueLabel";
            this.actionZoneValueLabel.Size = new System.Drawing.Size(209, 13);
            this.actionZoneValueLabel.TabIndex = 5;
            this.actionZoneValueLabel.Text = "Value%";
            this.actionZoneValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.actionZoneValueLabel.Visible = false;
            //
            // deadZoneValueLabel
            //
            this.deadZoneValueLabel.Location = new System.Drawing.Point(6, 19);
            this.deadZoneValueLabel.Margin = new System.Windows.Forms.Padding(3);
            this.deadZoneValueLabel.Name = "deadZoneValueLabel";
            this.deadZoneValueLabel.Size = new System.Drawing.Size(209, 13);
            this.deadZoneValueLabel.TabIndex = 4;
            this.deadZoneValueLabel.Text = "Value%";
            this.deadZoneValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.deadZoneValueLabel.Visible = false;
            //
            // modeComboBox
            //
            this.modeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.modeComboBox.FormattingEnabled = true;
            this.modeComboBox.Location = new System.Drawing.Point(6, 154);
            this.modeComboBox.Name = "modeComboBox";
            this.modeComboBox.Size = new System.Drawing.Size(209, 21);
            this.modeComboBox.TabIndex = 3;
            this.modeComboBox.Visible = false;
            this.modeComboBox.SelectedIndexChanged += new System.EventHandler(this.OnStickModeChanged);
            //
            // actionZoneTrackBar
            //
            this.actionZoneTrackBar.AutoSize = false;
            this.actionZoneTrackBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.actionZoneTrackBar.Location = new System.Drawing.Point(6, 110);
            this.actionZoneTrackBar.Maximum = 100;
            this.actionZoneTrackBar.Name = "actionZoneTrackBar";
            this.actionZoneTrackBar.Size = new System.Drawing.Size(209, 25);
            this.actionZoneTrackBar.TabIndex = 2;
            this.actionZoneTrackBar.TickFrequency = 10;
            this.actionZoneTrackBar.Visible = false;
            this.actionZoneTrackBar.ValueChanged += new System.EventHandler(this.OnActionZoneValueChanged);
            //
            // deadZoneLabel
            //
            this.deadZoneLabel.Location = new System.Drawing.Point(6, 0);
            this.deadZoneLabel.Margin = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.deadZoneLabel.Name = "deadZoneLabel";
            this.deadZoneLabel.Size = new System.Drawing.Size(209, 13);
            this.deadZoneLabel.TabIndex = 0;
            this.deadZoneLabel.Text = "Dead Zone";
            this.deadZoneLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.deadZoneLabel.Visible = false;
            //
            // deadZoneTrackBar
            //
            this.deadZoneTrackBar.AutoSize = false;
            this.deadZoneTrackBar.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.deadZoneTrackBar.Location = new System.Drawing.Point(6, 38);
            this.deadZoneTrackBar.Margin = new System.Windows.Forms.Padding(3, 3, 3, 6);
            this.deadZoneTrackBar.Maximum = 100;
            this.deadZoneTrackBar.Name = "deadZoneTrackBar";
            this.deadZoneTrackBar.Size = new System.Drawing.Size(209, 25);
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
            this.panel1.Location = new System.Drawing.Point(0, 260);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(229, 29);
            this.panel1.TabIndex = 41;
            //
            // bindingsFlowLayoutPanel
            //
            this.bindingsFlowLayoutPanel.AutoScroll = true;
            this.bindingsFlowLayoutPanel.Controls.Add(this.defaultBindingControl);
            this.bindingsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bindingsFlowLayoutPanel.Location = new System.Drawing.Point(0, 23);
            this.bindingsFlowLayoutPanel.Name = "bindingsFlowLayoutPanel";
            this.bindingsFlowLayoutPanel.Size = new System.Drawing.Size(221, 211);
            this.bindingsFlowLayoutPanel.TabIndex = 38;
            //
            // BindingConfigForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(229, 289);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BindingConfigForm";
            this.Text = "Binding Config";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnClosed);
            this.Load += new System.EventHandler(this.OnLoad);
            this.tabControl1.ResumeLayout(false);
            this.bindingsTabPage.ResumeLayout(false);
            this.otherTabPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.actionZoneTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deadZoneTrackBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.bindingsFlowLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage bindingsTabPage;
        private System.Windows.Forms.TabPage otherTabPage;
        private System.Windows.Forms.Label deadZoneLabel;
        private System.Windows.Forms.TrackBar deadZoneTrackBar;
        private System.Windows.Forms.ComboBox modeComboBox;
        private System.Windows.Forms.Label actionZoneLabel;
        private System.Windows.Forms.TrackBar actionZoneTrackBar;
        private System.Windows.Forms.Label modeLabel;
        private System.Windows.Forms.Label actionZoneValueLabel;
        private System.Windows.Forms.Label deadZoneValueLabel;
        private System.Windows.Forms.Panel panel1;
        private Controls.BindingControl defaultBindingControl;
        private DoubleBufferedFlowLayoutPanel bindingsFlowLayoutPanel;
    }
}