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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveAndCloseButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.offsetLabel = new System.Windows.Forms.Label();
            this.offsetXLabel = new System.Windows.Forms.Label();
            this.offsetYLabel = new System.Windows.Forms.Label();
            this.offsetXValue = new System.Windows.Forms.NumericUpDown();
            this.offsetYValue = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.controllerButtonLabel7 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel19 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel18 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel17 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel16 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel15 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel14 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel13 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel12 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel11 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel10 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel9 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel8 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel6 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel5 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel4 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel3 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel2 = new D360.Controls.ControllerButtonLabel();
            this.controllerButtonLabel1 = new D360.Controls.ControllerButtonLabel();
            this.cursorSlider = new D360.Controls.RadiusSlider();
            this.targetSlider = new D360.Controls.RadiusSlider();
            ((System.ComponentModel.ISupportInitialize)(this.offsetXValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetYValue)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(1175, 758);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(93, 23);
            this.cancelButton.TabIndex = 25;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.OnCancelClick);
            // 
            // saveAndCloseButton
            // 
            this.saveAndCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveAndCloseButton.Location = new System.Drawing.Point(3, 758);
            this.saveAndCloseButton.Name = "saveAndCloseButton";
            this.saveAndCloseButton.Size = new System.Drawing.Size(93, 23);
            this.saveAndCloseButton.TabIndex = 24;
            this.saveAndCloseButton.Text = "Save and Close";
            this.saveAndCloseButton.UseVisualStyleBackColor = true;
            this.saveAndCloseButton.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // offsetLabel
            // 
            this.offsetLabel.Location = new System.Drawing.Point(1131, 13);
            this.offsetLabel.Name = "offsetLabel";
            this.offsetLabel.Size = new System.Drawing.Size(121, 17);
            this.offsetLabel.TabIndex = 59;
            this.offsetLabel.Text = "Center of Screen Offset";
            this.offsetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // offsetXLabel
            // 
            this.offsetXLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.offsetXLabel.Location = new System.Drawing.Point(1487, 3);
            this.offsetXLabel.Name = "offsetXLabel";
            this.offsetXLabel.Size = new System.Drawing.Size(15, 20);
            this.offsetXLabel.TabIndex = 60;
            this.offsetXLabel.Text = "X";
            this.offsetXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // offsetYLabel
            // 
            this.offsetYLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.offsetYLabel.Location = new System.Drawing.Point(1489, 42);
            this.offsetYLabel.Name = "offsetYLabel";
            this.offsetYLabel.Size = new System.Drawing.Size(14, 20);
            this.offsetYLabel.TabIndex = 61;
            this.offsetYLabel.Text = "Y";
            this.offsetYLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // offsetXValue
            // 
            this.offsetXValue.Location = new System.Drawing.Point(1148, 39);
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
            this.offsetXValue.Size = new System.Drawing.Size(104, 20);
            this.offsetXValue.TabIndex = 63;
            this.offsetXValue.ValueChanged += new System.EventHandler(this.OnOffsetValueChanged);
            // 
            // offsetYValue
            // 
            this.offsetYValue.Location = new System.Drawing.Point(1148, 65);
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
            this.offsetYValue.Size = new System.Drawing.Size(104, 20);
            this.offsetYValue.TabIndex = 64;
            this.offsetYValue.ValueChanged += new System.EventHandler(this.OnOffsetValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.pictureBox1, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.saveAndCloseButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.cancelButton, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.cursorSlider, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.targetSlider, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1271, 784);
            this.tableLayoutPanel1.TabIndex = 84;
            // 
            // pictureBox1
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.pictureBox1, 2);
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = global::D360.Properties.Resources.XBoxOneControllerOutline1;
            this.pictureBox1.Location = new System.Drawing.Point(257, 159);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(756, 582);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // controllerButtonLabel7
            // 
            this.controllerButtonLabel7.Label = "Right Shoulder";
            this.controllerButtonLabel7.Location = new System.Drawing.Point(942, 255);
            this.controllerButtonLabel7.Margin = new System.Windows.Forms.Padding(2);
            this.controllerButtonLabel7.Name = "controllerButtonLabel7";
            this.controllerButtonLabel7.Size = new System.Drawing.Size(175, 45);
            this.controllerButtonLabel7.TabIndex = 71;
            // 
            // controllerButtonLabel19
            // 
            this.controllerButtonLabel19.Label = "Right Stick";
            this.controllerButtonLabel19.Location = new System.Drawing.Point(923, 717);
            this.controllerButtonLabel19.Margin = new System.Windows.Forms.Padding(2);
            this.controllerButtonLabel19.Name = "controllerButtonLabel19";
            this.controllerButtonLabel19.Size = new System.Drawing.Size(175, 45);
            this.controllerButtonLabel19.TabIndex = 83;
            // 
            // controllerButtonLabel18
            // 
            this.controllerButtonLabel18.Label = "Right Stick Button";
            this.controllerButtonLabel18.Location = new System.Drawing.Point(736, 717);
            this.controllerButtonLabel18.Margin = new System.Windows.Forms.Padding(2);
            this.controllerButtonLabel18.Name = "controllerButtonLabel18";
            this.controllerButtonLabel18.Size = new System.Drawing.Size(175, 45);
            this.controllerButtonLabel18.TabIndex = 82;
            // 
            // controllerButtonLabel17
            // 
            this.controllerButtonLabel17.Label = "DPad Right";
            this.controllerButtonLabel17.Location = new System.Drawing.Point(502, 714);
            this.controllerButtonLabel17.Margin = new System.Windows.Forms.Padding(2);
            this.controllerButtonLabel17.Name = "controllerButtonLabel17";
            this.controllerButtonLabel17.Size = new System.Drawing.Size(175, 45);
            this.controllerButtonLabel17.TabIndex = 81;
            // 
            // controllerButtonLabel16
            // 
            this.controllerButtonLabel16.Label = "Dpad Down";
            this.controllerButtonLabel16.Location = new System.Drawing.Point(290, 702);
            this.controllerButtonLabel16.Margin = new System.Windows.Forms.Padding(2);
            this.controllerButtonLabel16.Name = "controllerButtonLabel16";
            this.controllerButtonLabel16.Size = new System.Drawing.Size(175, 45);
            this.controllerButtonLabel16.TabIndex = 80;
            // 
            // controllerButtonLabel15
            // 
            this.controllerButtonLabel15.Label = "DPad Left";
            this.controllerButtonLabel15.Location = new System.Drawing.Point(71, 555);
            this.controllerButtonLabel15.Margin = new System.Windows.Forms.Padding(2);
            this.controllerButtonLabel15.Name = "controllerButtonLabel15";
            this.controllerButtonLabel15.Size = new System.Drawing.Size(175, 45);
            this.controllerButtonLabel15.TabIndex = 79;
            // 
            // controllerButtonLabel14
            // 
            this.controllerButtonLabel14.Label = "DPad Up";
            this.controllerButtonLabel14.Location = new System.Drawing.Point(71, 488);
            this.controllerButtonLabel14.Margin = new System.Windows.Forms.Padding(2);
            this.controllerButtonLabel14.Name = "controllerButtonLabel14";
            this.controllerButtonLabel14.Size = new System.Drawing.Size(175, 45);
            this.controllerButtonLabel14.TabIndex = 78;
            // 
            // controllerButtonLabel13
            // 
            this.controllerButtonLabel13.Label = "Left Stick Button";
            this.controllerButtonLabel13.Location = new System.Drawing.Point(118, 370);
            this.controllerButtonLabel13.Margin = new System.Windows.Forms.Padding(2);
            this.controllerButtonLabel13.Name = "controllerButtonLabel13";
            this.controllerButtonLabel13.Size = new System.Drawing.Size(175, 45);
            this.controllerButtonLabel13.TabIndex = 77;
            // 
            // controllerButtonLabel12
            // 
            this.controllerButtonLabel12.Label = "Left Stick";
            this.controllerButtonLabel12.Location = new System.Drawing.Point(118, 300);
            this.controllerButtonLabel12.Margin = new System.Windows.Forms.Padding(2);
            this.controllerButtonLabel12.Name = "controllerButtonLabel12";
            this.controllerButtonLabel12.Size = new System.Drawing.Size(175, 45);
            this.controllerButtonLabel12.TabIndex = 76;
            // 
            // controllerButtonLabel11
            // 
            this.controllerButtonLabel11.Label = "A";
            this.controllerButtonLabel11.Location = new System.Drawing.Point(1011, 518);
            this.controllerButtonLabel11.Margin = new System.Windows.Forms.Padding(2);
            this.controllerButtonLabel11.Name = "controllerButtonLabel11";
            this.controllerButtonLabel11.Size = new System.Drawing.Size(175, 45);
            this.controllerButtonLabel11.TabIndex = 75;
            // 
            // controllerButtonLabel10
            // 
            this.controllerButtonLabel10.Label = "B";
            this.controllerButtonLabel10.Location = new System.Drawing.Point(1006, 456);
            this.controllerButtonLabel10.Margin = new System.Windows.Forms.Padding(2);
            this.controllerButtonLabel10.Name = "controllerButtonLabel10";
            this.controllerButtonLabel10.Size = new System.Drawing.Size(175, 45);
            this.controllerButtonLabel10.TabIndex = 74;
            // 
            // controllerButtonLabel9
            // 
            this.controllerButtonLabel9.Label = "Y";
            this.controllerButtonLabel9.Location = new System.Drawing.Point(1001, 399);
            this.controllerButtonLabel9.Margin = new System.Windows.Forms.Padding(2);
            this.controllerButtonLabel9.Name = "controllerButtonLabel9";
            this.controllerButtonLabel9.Size = new System.Drawing.Size(175, 45);
            this.controllerButtonLabel9.TabIndex = 73;
            // 
            // controllerButtonLabel8
            // 
            this.controllerButtonLabel8.Label = "X";
            this.controllerButtonLabel8.Location = new System.Drawing.Point(986, 339);
            this.controllerButtonLabel8.Margin = new System.Windows.Forms.Padding(2);
            this.controllerButtonLabel8.Name = "controllerButtonLabel8";
            this.controllerButtonLabel8.Size = new System.Drawing.Size(175, 45);
            this.controllerButtonLabel8.TabIndex = 72;
            // 
            // controllerButtonLabel6
            // 
            this.controllerButtonLabel6.Label = "Start";
            this.controllerButtonLabel6.Location = new System.Drawing.Point(636, 221);
            this.controllerButtonLabel6.Margin = new System.Windows.Forms.Padding(2);
            this.controllerButtonLabel6.Name = "controllerButtonLabel6";
            this.controllerButtonLabel6.Size = new System.Drawing.Size(175, 45);
            this.controllerButtonLabel6.TabIndex = 70;
            // 
            // controllerButtonLabel5
            // 
            this.controllerButtonLabel5.Label = "Back";
            this.controllerButtonLabel5.Location = new System.Drawing.Point(460, 222);
            this.controllerButtonLabel5.Margin = new System.Windows.Forms.Padding(2);
            this.controllerButtonLabel5.Name = "controllerButtonLabel5";
            this.controllerButtonLabel5.Size = new System.Drawing.Size(175, 45);
            this.controllerButtonLabel5.TabIndex = 69;
            // 
            // controllerButtonLabel4
            // 
            this.controllerButtonLabel4.Label = "Left Shoulder";
            this.controllerButtonLabel4.Location = new System.Drawing.Point(152, 236);
            this.controllerButtonLabel4.Margin = new System.Windows.Forms.Padding(2);
            this.controllerButtonLabel4.Name = "controllerButtonLabel4";
            this.controllerButtonLabel4.Size = new System.Drawing.Size(175, 45);
            this.controllerButtonLabel4.TabIndex = 68;
            // 
            // controllerButtonLabel3
            // 
            this.controllerButtonLabel3.Label = "Left Trigger";
            this.controllerButtonLabel3.Location = new System.Drawing.Point(188, 142);
            this.controllerButtonLabel3.Margin = new System.Windows.Forms.Padding(2);
            this.controllerButtonLabel3.Name = "controllerButtonLabel3";
            this.controllerButtonLabel3.Size = new System.Drawing.Size(175, 45);
            this.controllerButtonLabel3.TabIndex = 67;
            // 
            // controllerButtonLabel2
            // 
            this.controllerButtonLabel2.Label = "Right Trigger";
            this.controllerButtonLabel2.Location = new System.Drawing.Point(917, 144);
            this.controllerButtonLabel2.Margin = new System.Windows.Forms.Padding(2);
            this.controllerButtonLabel2.Name = "controllerButtonLabel2";
            this.controllerButtonLabel2.Size = new System.Drawing.Size(175, 45);
            this.controllerButtonLabel2.TabIndex = 66;
            // 
            // controllerButtonLabel1
            // 
            this.controllerButtonLabel1.Label = "Guide";
            this.controllerButtonLabel1.Location = new System.Drawing.Point(548, 154);
            this.controllerButtonLabel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.controllerButtonLabel1.Name = "controllerButtonLabel1";
            this.controllerButtonLabel1.Size = new System.Drawing.Size(175, 45);
            this.controllerButtonLabel1.TabIndex = 65;
            // 
            // cursorSlider
            // 
            this.cursorSlider.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.cursorSlider.Checked = false;
            this.cursorSlider.Label = "Cursor Radius";
            this.cursorSlider.Location = new System.Drawing.Point(3, 3);
            this.cursorSlider.Name = "cursorSlider";
            this.cursorSlider.Percent = "Value%";
            this.cursorSlider.Size = new System.Drawing.Size(220, 72);
            this.cursorSlider.TabIndex = 27;
            this.cursorSlider.Value = 0;
            // 
            // targetSlider
            // 
            this.targetSlider.Checked = false;
            this.targetSlider.Label = "Target Radius";
            this.targetSlider.Location = new System.Drawing.Point(3, 81);
            this.targetSlider.Name = "targetSlider";
            this.targetSlider.Percent = "Value%";
            this.targetSlider.Size = new System.Drawing.Size(220, 72);
            this.targetSlider.TabIndex = 28;
            this.targetSlider.Value = 0;
            // 
            // ConfigForm
            // 
            this.AcceptButton = this.saveAndCloseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(1271, 784);
            this.Controls.Add(this.controllerButtonLabel7);
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
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "D360 Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnFormClosing);
            this.Shown += new System.EventHandler(this.OnShown);
            this.VisibleChanged += new System.EventHandler(this.OnVisibleChanged);
            this.Move += new System.EventHandler(this.OnMove);
            this.Resize += new System.EventHandler(this.OnResize);
            ((System.ComponentModel.ISupportInitialize)(this.offsetXValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetYValue)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Button cancelButton;
        private Button saveAndCloseButton;
        private BackgroundWorker backgroundWorker1;
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
        private TableLayoutPanel tableLayoutPanel1;
        private PictureBox pictureBox1;
        private Controls.RadiusSlider cursorSlider;
        private Controls.RadiusSlider targetSlider;
    }
}