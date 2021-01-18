using System.ComponentModel;
using System.Windows.Forms;

namespace D360
{
    partial class ConfigForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.Windows.Forms.Button defaultEditButton;
            System.Windows.Forms.Label defaultLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveAndCloseButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.defaultPanel = new System.Windows.Forms.TableLayoutPanel();
            this.cursorLabel = new System.Windows.Forms.Label();
            this.cursorTrackBar = new System.Windows.Forms.TrackBar();
            this.cursorValueLabel = new System.Windows.Forms.Label();
            this.cursorMaxCheck = new System.Windows.Forms.CheckBox();
            this.targetMaxCheck = new System.Windows.Forms.CheckBox();
            this.targetValueLabel = new System.Windows.Forms.Label();
            this.targetTrackBar = new System.Windows.Forms.TrackBar();
            this.targetLabel = new System.Windows.Forms.Label();
            this.offsetLabel = new System.Windows.Forms.Label();
            this.offsetXLabel = new System.Windows.Forms.Label();
            this.offsetYLabel = new System.Windows.Forms.Label();
            this.offsetXValue = new System.Windows.Forms.NumericUpDown();
            this.offsetYValue = new System.Windows.Forms.NumericUpDown();
            this.controllerButtonLabel4 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel3 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel2 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel1 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel5 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel6 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel7 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel8 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel9 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel10 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel11 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel12 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel13 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel14 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel15 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel16 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel17 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel18 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel19 = new D360.Controls.ControllerButtonLabel();
            defaultEditButton = new System.Windows.Forms.Button();
            defaultLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.defaultPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cursorTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetXValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetYValue)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultEditButton
            // 
            defaultEditButton.AutoSize = true;
            defaultEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            defaultEditButton.Location = new System.Drawing.Point(4, 29);
            defaultEditButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            defaultEditButton.Name = "defaultEditButton";
            defaultEditButton.Size = new System.Drawing.Size(254, 35);
            defaultEditButton.TabIndex = 27;
            defaultEditButton.Text = "Edit";
            defaultEditButton.UseVisualStyleBackColor = true;
            defaultEditButton.Click += new System.EventHandler(this.OnEditClick);
            // 
            // defaultLabel
            // 
            defaultLabel.AutoSize = true;
            defaultLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            defaultLabel.Location = new System.Drawing.Point(4, 0);
            defaultLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            defaultLabel.Name = "defaultLabel";
            defaultLabel.Size = new System.Drawing.Size(254, 24);
            defaultLabel.TabIndex = 28;
            defaultLabel.Text = "Default Label";
            defaultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(1736, 1125);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(140, 35);
            this.cancelButton.TabIndex = 25;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.OnCancelClick);
            // 
            // saveAndCloseButton
            // 
            this.saveAndCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveAndCloseButton.Location = new System.Drawing.Point(18, 1125);
            this.saveAndCloseButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.saveAndCloseButton.Name = "saveAndCloseButton";
            this.saveAndCloseButton.Size = new System.Drawing.Size(140, 35);
            this.saveAndCloseButton.TabIndex = 24;
            this.saveAndCloseButton.Text = "Save and Close";
            this.saveAndCloseButton.UseVisualStyleBackColor = true;
            this.saveAndCloseButton.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::D360.Properties.Resources.XBoxOneControllerOutline1;
            this.pictureBox1.Location = new System.Drawing.Point(147, 152);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1600, 949);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // defaultPanel
            // 
            this.defaultPanel.ColumnCount = 1;
            this.defaultPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.defaultPanel.Controls.Add(defaultLabel, 0, 0);
            this.defaultPanel.Controls.Add(defaultEditButton, 0, 1);
            this.defaultPanel.Location = new System.Drawing.Point(628, 28);
            this.defaultPanel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.defaultPanel.Name = "defaultPanel";
            this.defaultPanel.RowCount = 2;
            this.defaultPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.defaultPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.defaultPanel.Size = new System.Drawing.Size(262, 69);
            this.defaultPanel.TabIndex = 29;
            // 
            // cursorLabel
            // 
            this.cursorLabel.Location = new System.Drawing.Point(20, 20);
            this.cursorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cursorLabel.Name = "cursorLabel";
            this.cursorLabel.Size = new System.Drawing.Size(234, 22);
            this.cursorLabel.TabIndex = 47;
            this.cursorLabel.Text = "Cursor Radius";
            this.cursorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cursorTrackBar
            // 
            this.cursorTrackBar.AutoSize = false;
            this.cursorTrackBar.Location = new System.Drawing.Point(20, 46);
            this.cursorTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cursorTrackBar.Maximum = 100;
            this.cursorTrackBar.Name = "cursorTrackBar";
            this.cursorTrackBar.Size = new System.Drawing.Size(234, 38);
            this.cursorTrackBar.TabIndex = 48;
            this.cursorTrackBar.TickFrequency = 10;
            this.cursorTrackBar.ValueChanged += new System.EventHandler(this.OnRadiusTrackBarChanged);
            // 
            // cursorValueLabel
            // 
            this.cursorValueLabel.Location = new System.Drawing.Point(262, 46);
            this.cursorValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.cursorValueLabel.Name = "cursorValueLabel";
            this.cursorValueLabel.Size = new System.Drawing.Size(90, 38);
            this.cursorValueLabel.TabIndex = 49;
            this.cursorValueLabel.Text = "Value%";
            this.cursorValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cursorMaxCheck
            // 
            this.cursorMaxCheck.AutoSize = true;
            this.cursorMaxCheck.Location = new System.Drawing.Point(20, 95);
            this.cursorMaxCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cursorMaxCheck.Name = "cursorMaxCheck";
            this.cursorMaxCheck.Size = new System.Drawing.Size(117, 24);
            this.cursorMaxCheck.TabIndex = 50;
            this.cursorMaxCheck.Text = "Always Max";
            this.cursorMaxCheck.UseVisualStyleBackColor = true;
            this.cursorMaxCheck.CheckStateChanged += new System.EventHandler(this.OnMaxCheckChanged);
            // 
            // targetMaxCheck
            // 
            this.targetMaxCheck.AutoSize = true;
            this.targetMaxCheck.Location = new System.Drawing.Point(18, 202);
            this.targetMaxCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.targetMaxCheck.Name = "targetMaxCheck";
            this.targetMaxCheck.Size = new System.Drawing.Size(117, 24);
            this.targetMaxCheck.TabIndex = 54;
            this.targetMaxCheck.Text = "Always Max";
            this.targetMaxCheck.UseVisualStyleBackColor = true;
            this.targetMaxCheck.CheckStateChanged += new System.EventHandler(this.OnMaxCheckChanged);
            // 
            // targetValueLabel
            // 
            this.targetValueLabel.Location = new System.Drawing.Point(261, 152);
            this.targetValueLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.targetValueLabel.Name = "targetValueLabel";
            this.targetValueLabel.Size = new System.Drawing.Size(90, 38);
            this.targetValueLabel.TabIndex = 53;
            this.targetValueLabel.Text = "Value%";
            this.targetValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // targetTrackBar
            // 
            this.targetTrackBar.AutoSize = false;
            this.targetTrackBar.Location = new System.Drawing.Point(18, 152);
            this.targetTrackBar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.targetTrackBar.Maximum = 100;
            this.targetTrackBar.Name = "targetTrackBar";
            this.targetTrackBar.Size = new System.Drawing.Size(234, 38);
            this.targetTrackBar.TabIndex = 52;
            this.targetTrackBar.TickFrequency = 10;
            this.targetTrackBar.ValueChanged += new System.EventHandler(this.OnRadiusTrackBarChanged);
            // 
            // targetLabel
            // 
            this.targetLabel.Location = new System.Drawing.Point(18, 126);
            this.targetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.targetLabel.Name = "targetLabel";
            this.targetLabel.Size = new System.Drawing.Size(234, 22);
            this.targetLabel.TabIndex = 51;
            this.targetLabel.Text = "Target Radius";
            this.targetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // offsetLabel
            // 
            this.offsetLabel.Location = new System.Drawing.Point(1696, 20);
            this.offsetLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.offsetLabel.Name = "offsetLabel";
            this.offsetLabel.Size = new System.Drawing.Size(182, 26);
            this.offsetLabel.TabIndex = 59;
            this.offsetLabel.Text = "Center of Screen Offset";
            this.offsetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // offsetXLabel
            // 
            this.offsetXLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.offsetXLabel.Location = new System.Drawing.Point(1690, 60);
            this.offsetXLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.offsetXLabel.Name = "offsetXLabel";
            this.offsetXLabel.Size = new System.Drawing.Size(22, 31);
            this.offsetXLabel.TabIndex = 60;
            this.offsetXLabel.Text = "X";
            this.offsetXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // offsetYLabel
            // 
            this.offsetYLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.offsetYLabel.Location = new System.Drawing.Point(1692, 100);
            this.offsetYLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.offsetYLabel.Name = "offsetYLabel";
            this.offsetYLabel.Size = new System.Drawing.Size(21, 31);
            this.offsetYLabel.TabIndex = 61;
            this.offsetYLabel.Text = "Y";
            this.offsetYLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // offsetXValue
            // 
            this.offsetXValue.Location = new System.Drawing.Point(1722, 60);
            this.offsetXValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.offsetXValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.offsetXValue.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.offsetXValue.Name = "offsetXValue";
            this.offsetXValue.Size = new System.Drawing.Size(156, 26);
            this.offsetXValue.TabIndex = 63;
            this.offsetXValue.ValueChanged += new System.EventHandler(this.OnOffsetValueChanged);
            // 
            // offsetYValue
            // 
            this.offsetYValue.Location = new System.Drawing.Point(1722, 100);
            this.offsetYValue.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.offsetYValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.offsetYValue.Minimum = new decimal(new int[] {
            10000,
            0,
            0,
            -2147483648});
            this.offsetYValue.Name = "offsetYValue";
            this.offsetYValue.Size = new System.Drawing.Size(156, 26);
            this.offsetYValue.TabIndex = 64;
            this.offsetYValue.ValueChanged += new System.EventHandler(this.OnOffsetValueChanged);
            // 
            // controllerButtonLabel4
            // 
            this.controllerButtonLabel4.Label = "Left Shoulder";
            this.controllerButtonLabel4.Location = new System.Drawing.Point(173, 290);
            this.controllerButtonLabel4.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controllerButtonLabel4.Name = "controllerButtonLabel4";
            this.controllerButtonLabel4.Size = new System.Drawing.Size(262, 69);
            this.controllerButtonLabel4.TabIndex = 68;
            // 
            // controllerButtonLabel3
            // 
            this.controllerButtonLabel3.Label = "Left Trigger";
            this.controllerButtonLabel3.Location = new System.Drawing.Point(360, 79);
            this.controllerButtonLabel3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controllerButtonLabel3.Name = "controllerButtonLabel3";
            this.controllerButtonLabel3.Size = new System.Drawing.Size(262, 69);
            this.controllerButtonLabel3.TabIndex = 67;
            // 
            // controllerButtonLabel2
            // 
            this.controllerButtonLabel2.Label = "Right Trigger";
            this.controllerButtonLabel2.Location = new System.Drawing.Point(1282, 79);
            this.controllerButtonLabel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controllerButtonLabel2.Name = "controllerButtonLabel2";
            this.controllerButtonLabel2.Size = new System.Drawing.Size(262, 69);
            this.controllerButtonLabel2.TabIndex = 66;
            // 
            // controllerButtonLabel1
            // 
            this.controllerButtonLabel1.Label = "Guide";
            this.controllerButtonLabel1.Location = new System.Drawing.Point(806, 157);
            this.controllerButtonLabel1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.controllerButtonLabel1.Name = "controllerButtonLabel1";
            this.controllerButtonLabel1.Size = new System.Drawing.Size(262, 69);
            this.controllerButtonLabel1.TabIndex = 65;
            // 
            // controllerButtonLabel5
            // 
            this.controllerButtonLabel5.Label = "Back";
            this.controllerButtonLabel5.Location = new System.Drawing.Point(678, 290);
            this.controllerButtonLabel5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controllerButtonLabel5.Name = "controllerButtonLabel5";
            this.controllerButtonLabel5.Size = new System.Drawing.Size(262, 69);
            this.controllerButtonLabel5.TabIndex = 69;
            // 
            // controllerButtonLabel6
            // 
            this.controllerButtonLabel6.Label = "Start";
            this.controllerButtonLabel6.Location = new System.Drawing.Point(948, 290);
            this.controllerButtonLabel6.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controllerButtonLabel6.Name = "controllerButtonLabel6";
            this.controllerButtonLabel6.Size = new System.Drawing.Size(262, 69);
            this.controllerButtonLabel6.TabIndex = 70;
            // 
            // controllerButtonLabel7
            // 
            this.controllerButtonLabel7.Label = "Right Shoulder";
            this.controllerButtonLabel7.Location = new System.Drawing.Point(1464, 307);
            this.controllerButtonLabel7.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controllerButtonLabel7.Name = "controllerButtonLabel7";
            this.controllerButtonLabel7.Size = new System.Drawing.Size(262, 69);
            this.controllerButtonLabel7.TabIndex = 71;
            // 
            // controllerButtonLabel8
            // 
            this.controllerButtonLabel8.Label = "X";
            this.controllerButtonLabel8.Location = new System.Drawing.Point(1529, 480);
            this.controllerButtonLabel8.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controllerButtonLabel8.Name = "controllerButtonLabel8";
            this.controllerButtonLabel8.Size = new System.Drawing.Size(262, 69);
            this.controllerButtonLabel8.TabIndex = 72;
            // 
            // controllerButtonLabel9
            // 
            this.controllerButtonLabel9.Label = "Y";
            this.controllerButtonLabel9.Location = new System.Drawing.Point(1547, 559);
            this.controllerButtonLabel9.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controllerButtonLabel9.Name = "controllerButtonLabel9";
            this.controllerButtonLabel9.Size = new System.Drawing.Size(262, 69);
            this.controllerButtonLabel9.TabIndex = 73;
            // 
            // controllerButtonLabel10
            // 
            this.controllerButtonLabel10.Label = "B";
            this.controllerButtonLabel10.Location = new System.Drawing.Point(1573, 638);
            this.controllerButtonLabel10.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controllerButtonLabel10.Name = "controllerButtonLabel10";
            this.controllerButtonLabel10.Size = new System.Drawing.Size(262, 69);
            this.controllerButtonLabel10.TabIndex = 74;
            // 
            // controllerButtonLabel11
            // 
            this.controllerButtonLabel11.Label = "A";
            this.controllerButtonLabel11.Location = new System.Drawing.Point(1573, 717);
            this.controllerButtonLabel11.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controllerButtonLabel11.Name = "controllerButtonLabel11";
            this.controllerButtonLabel11.Size = new System.Drawing.Size(262, 69);
            this.controllerButtonLabel11.TabIndex = 75;
            // 
            // controllerButtonLabel12
            // 
            this.controllerButtonLabel12.Label = "Left Stick";
            this.controllerButtonLabel12.Location = new System.Drawing.Point(147, 466);
            this.controllerButtonLabel12.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controllerButtonLabel12.Name = "controllerButtonLabel12";
            this.controllerButtonLabel12.Size = new System.Drawing.Size(262, 69);
            this.controllerButtonLabel12.TabIndex = 76;
            // 
            // controllerButtonLabel13
            // 
            this.controllerButtonLabel13.Label = "Left Stick Button";
            this.controllerButtonLabel13.Location = new System.Drawing.Point(147, 545);
            this.controllerButtonLabel13.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controllerButtonLabel13.Name = "controllerButtonLabel13";
            this.controllerButtonLabel13.Size = new System.Drawing.Size(262, 69);
            this.controllerButtonLabel13.TabIndex = 77;
            // 
            // controllerButtonLabel14
            // 
            this.controllerButtonLabel14.Label = "DPad Up";
            this.controllerButtonLabel14.Location = new System.Drawing.Point(42, 717);
            this.controllerButtonLabel14.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controllerButtonLabel14.Name = "controllerButtonLabel14";
            this.controllerButtonLabel14.Size = new System.Drawing.Size(262, 69);
            this.controllerButtonLabel14.TabIndex = 78;
            // 
            // controllerButtonLabel15
            // 
            this.controllerButtonLabel15.Label = "DPad Left";
            this.controllerButtonLabel15.Location = new System.Drawing.Point(24, 824);
            this.controllerButtonLabel15.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controllerButtonLabel15.Name = "controllerButtonLabel15";
            this.controllerButtonLabel15.Size = new System.Drawing.Size(262, 69);
            this.controllerButtonLabel15.TabIndex = 79;
            // 
            // controllerButtonLabel16
            // 
            this.controllerButtonLabel16.Label = "Dpad Down";
            this.controllerButtonLabel16.Location = new System.Drawing.Point(396, 1058);
            this.controllerButtonLabel16.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controllerButtonLabel16.Name = "controllerButtonLabel16";
            this.controllerButtonLabel16.Size = new System.Drawing.Size(262, 69);
            this.controllerButtonLabel16.TabIndex = 80;
            // 
            // controllerButtonLabel17
            // 
            this.controllerButtonLabel17.Label = "DPad Right";
            this.controllerButtonLabel17.Location = new System.Drawing.Point(843, 1070);
            this.controllerButtonLabel17.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controllerButtonLabel17.Name = "controllerButtonLabel17";
            this.controllerButtonLabel17.Size = new System.Drawing.Size(262, 69);
            this.controllerButtonLabel17.TabIndex = 81;
            // 
            // controllerButtonLabel18
            // 
            this.controllerButtonLabel18.Label = "Right Stick Button";
            this.controllerButtonLabel18.Location = new System.Drawing.Point(1114, 1111);
            this.controllerButtonLabel18.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controllerButtonLabel18.Name = "controllerButtonLabel18";
            this.controllerButtonLabel18.Size = new System.Drawing.Size(262, 69);
            this.controllerButtonLabel18.TabIndex = 82;
            // 
            // controllerButtonLabel19
            // 
            this.controllerButtonLabel19.Label = "Right Stick";
            this.controllerButtonLabel19.Location = new System.Drawing.Point(1384, 1058);
            this.controllerButtonLabel19.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controllerButtonLabel19.Name = "controllerButtonLabel19";
            this.controllerButtonLabel19.Size = new System.Drawing.Size(262, 69);
            this.controllerButtonLabel19.TabIndex = 83;
            // 
            // ConfigForm
            // 
            this.AcceptButton = this.saveAndCloseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1896, 1178);
            this.Controls.Add(this.controllerButtonLabel19);
            this.Controls.Add(this.controllerButtonLabel18);
            this.Controls.Add(this.controllerButtonLabel17);
            this.Controls.Add(this.controllerButtonLabel16);
            this.Controls.Add(this.controllerButtonLabel15);
            this.Controls.Add(this.controllerButtonLabel14);
            this.Controls.Add(this.controllerButtonLabel13);
            this.Controls.Add(this.controllerButtonLabel12);
            this.Controls.Add(this.controllerButtonLabel11);
            this.Controls.Add(this.controllerButtonLabel10);
            this.Controls.Add(this.controllerButtonLabel9);
            this.Controls.Add(this.controllerButtonLabel8);
            this.Controls.Add(this.controllerButtonLabel7);
            this.Controls.Add(this.controllerButtonLabel6);
            this.Controls.Add(this.controllerButtonLabel5);
            this.Controls.Add(this.controllerButtonLabel4);
            this.Controls.Add(this.controllerButtonLabel3);
            this.Controls.Add(this.controllerButtonLabel2);
            this.Controls.Add(this.controllerButtonLabel1);
            this.Controls.Add(this.offsetYValue);
            this.Controls.Add(this.offsetXValue);
            this.Controls.Add(this.offsetYLabel);
            this.Controls.Add(this.offsetXLabel);
            this.Controls.Add(this.offsetLabel);
            this.Controls.Add(this.targetMaxCheck);
            this.Controls.Add(this.targetValueLabel);
            this.Controls.Add(this.targetTrackBar);
            this.Controls.Add(this.targetLabel);
            this.Controls.Add(this.cursorMaxCheck);
            this.Controls.Add(this.cursorValueLabel);
            this.Controls.Add(this.cursorTrackBar);
            this.Controls.Add(this.cursorLabel);
            this.Controls.Add(this.defaultPanel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveAndCloseButton);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "D360 Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Shown += new System.EventHandler(this.OnShown);
            this.VisibleChanged += new System.EventHandler(this.OnVisibleChanged);
            this.Click += new System.EventHandler(this.OnEditClick);
            this.Move += new System.EventHandler(this.OnMove);
            this.Resize += new System.EventHandler(this.OnResize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.defaultPanel.ResumeLayout(false);
            this.defaultPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cursorTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetXValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetYValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button cancelButton;
        private Button saveAndCloseButton;
        private PictureBox pictureBox1;
        private BackgroundWorker backgroundWorker1;
        private TableLayoutPanel defaultPanel;
        private Label cursorLabel;
        private TrackBar cursorTrackBar;
        private Label cursorValueLabel;
        private CheckBox cursorMaxCheck;
        private CheckBox targetMaxCheck;
        private Label targetValueLabel;
        private TrackBar targetTrackBar;
        private Label targetLabel;
        private Label offsetLabel;
        private Label offsetXLabel;
        private Label offsetYLabel;
        private NumericUpDown offsetXValue;
        private NumericUpDown offsetYValue;
        private Controls.ControllerButtonLabel controllerButtonLabel1;
        private Controls.ControllerButtonLabel controllerButtonLabel2;
        private Controls.ControllerButtonLabel controllerButtonLabel3;
        private Controls.ControllerButtonLabel controllerButtonLabel4;
        private Controls.ControllerButtonLabel controllerButtonLabel5;
        private Controls.ControllerButtonLabel controllerButtonLabel6;
        private Controls.ControllerButtonLabel controllerButtonLabel7;
        private Controls.ControllerButtonLabel controllerButtonLabel8;
        private Controls.ControllerButtonLabel controllerButtonLabel9;
        private Controls.ControllerButtonLabel controllerButtonLabel10;
        private Controls.ControllerButtonLabel controllerButtonLabel11;
        private Controls.ControllerButtonLabel controllerButtonLabel12;
        private Controls.ControllerButtonLabel controllerButtonLabel13;
        private Controls.ControllerButtonLabel controllerButtonLabel14;
        private Controls.ControllerButtonLabel controllerButtonLabel15;
        private Controls.ControllerButtonLabel controllerButtonLabel16;
        private Controls.ControllerButtonLabel controllerButtonLabel17;
        private Controls.ControllerButtonLabel controllerButtonLabel18;
        private Controls.ControllerButtonLabel controllerButtonLabel19;
    }
}