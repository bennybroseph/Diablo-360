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
            System.Windows.Forms.Label defaultLabel;
            System.Windows.Forms.Label backLabel;
            System.Windows.Forms.Label startLabel;
            System.Windows.Forms.Label rightTriggerLable;
            System.Windows.Forms.Label leftTriggerLabel;
            System.Windows.Forms.Label leftBumperLabel;
            System.Windows.Forms.Label rightBumperLabel;
            System.Windows.Forms.Label leftStickLabel;
            System.Windows.Forms.Label xLabel;
            System.Windows.Forms.Label yLabel;
            System.Windows.Forms.Label bLabel;
            System.Windows.Forms.Label aLabel;
            System.Windows.Forms.Label dPadDownLabel;
            System.Windows.Forms.Label dPadRightLabel;
            System.Windows.Forms.Label rightStickLabel;
            System.Windows.Forms.Label dPadUpLabel;
            System.Windows.Forms.Label dPadLeftLabel;
            System.Windows.Forms.Label bigButtonLabel;
            D360.CustomTextBox bigButtonHoldBinding;
            D360.CustomTextBox bigButtonPressBinding;
            D360.CustomTextBox dPadLeftHoldBinding;
            D360.CustomTextBox dPadLeftPressBinding;
            D360.CustomTextBox dPadUpHoldBinding;
            D360.CustomTextBox dPadUpPressBinding;
            D360.CustomTextBox rightStickHoldBinding;
            D360.CustomTextBox rightStickPressBinding;
            D360.CustomTextBox dPadRightHoldBinding;
            D360.CustomTextBox dPadRightPressBinding;
            D360.CustomTextBox dPadDownHoldBinding;
            D360.CustomTextBox dPadDownPressBinding;
            D360.CustomTextBox aHoldBinding;
            D360.CustomTextBox aPressBinding;
            D360.CustomTextBox bButtonHoldKey;
            D360.CustomTextBox bButtonPressKey;
            D360.CustomTextBox yHoldBinding;
            D360.CustomTextBox yPressBinding;
            D360.CustomTextBox xHoldBinding;
            D360.CustomTextBox xPressBinding;
            D360.CustomTextBox leftStickHoldBinding;
            D360.CustomTextBox leftStickPressBinding;
            D360.CustomTextBox rightShoulderHoldBinding;
            D360.CustomTextBox rightShoulderPressBinding;
            D360.CustomTextBox leftBumperHoldKey;
            D360.CustomTextBox leftBumperPressKey;
            D360.CustomTextBox leftTriggerHoldBinding;
            D360.CustomTextBox leftTriggerPressBinding;
            D360.CustomTextBox rightTriggerHoldBinding;
            D360.CustomTextBox rightTriggerPressBinding;
            D360.CustomTextBox startHoldBinding;
            D360.CustomTextBox startPressBinding;
            D360.CustomTextBox backHoldBinding;
            D360.CustomTextBox backPressBinding;
            D360.CustomTextBox defaultHoldBinding;
            D360.CustomTextBox defaultPressBinding;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.OldLeftTriggerLabel = new System.Windows.Forms.Label();
            this.LeftTriggerComboBox = new System.Windows.Forms.ComboBox();
            this.OldRightTriggerLabel = new System.Windows.Forms.Label();
            this.RightTriggerComboBox = new System.Windows.Forms.ComboBox();
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveAndCloseButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.defaultTable = new System.Windows.Forms.TableLayoutPanel();
            this.backPanel = new System.Windows.Forms.TableLayoutPanel();
            this.startPanel = new System.Windows.Forms.TableLayoutPanel();
            this.rightTriggerPanel = new System.Windows.Forms.TableLayoutPanel();
            this.leftTriggerPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.rightShoulderPanel = new System.Windows.Forms.TableLayoutPanel();
            this.leftStickPanel = new System.Windows.Forms.TableLayoutPanel();
            this.xPanel = new System.Windows.Forms.TableLayoutPanel();
            this.yPanel = new System.Windows.Forms.TableLayoutPanel();
            this.bPanel = new System.Windows.Forms.TableLayoutPanel();
            this.aPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dPadDownPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dPadRightPanel = new System.Windows.Forms.TableLayoutPanel();
            this.rightStickPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dPadUpPanel = new System.Windows.Forms.TableLayoutPanel();
            this.dPadLeftPanel = new System.Windows.Forms.TableLayoutPanel();
            this.bigButtonPanel = new System.Windows.Forms.TableLayoutPanel();
            defaultLabel = new System.Windows.Forms.Label();
            backLabel = new System.Windows.Forms.Label();
            startLabel = new System.Windows.Forms.Label();
            rightTriggerLable = new System.Windows.Forms.Label();
            leftTriggerLabel = new System.Windows.Forms.Label();
            leftBumperLabel = new System.Windows.Forms.Label();
            rightBumperLabel = new System.Windows.Forms.Label();
            leftStickLabel = new System.Windows.Forms.Label();
            xLabel = new System.Windows.Forms.Label();
            yLabel = new System.Windows.Forms.Label();
            bLabel = new System.Windows.Forms.Label();
            aLabel = new System.Windows.Forms.Label();
            dPadDownLabel = new System.Windows.Forms.Label();
            dPadRightLabel = new System.Windows.Forms.Label();
            rightStickLabel = new System.Windows.Forms.Label();
            dPadUpLabel = new System.Windows.Forms.Label();
            dPadLeftLabel = new System.Windows.Forms.Label();
            bigButtonLabel = new System.Windows.Forms.Label();
            bigButtonHoldBinding = new D360.CustomTextBox();
            bigButtonPressBinding = new D360.CustomTextBox();
            dPadLeftHoldBinding = new D360.CustomTextBox();
            dPadLeftPressBinding = new D360.CustomTextBox();
            dPadUpHoldBinding = new D360.CustomTextBox();
            dPadUpPressBinding = new D360.CustomTextBox();
            rightStickHoldBinding = new D360.CustomTextBox();
            rightStickPressBinding = new D360.CustomTextBox();
            dPadRightHoldBinding = new D360.CustomTextBox();
            dPadRightPressBinding = new D360.CustomTextBox();
            dPadDownHoldBinding = new D360.CustomTextBox();
            dPadDownPressBinding = new D360.CustomTextBox();
            aHoldBinding = new D360.CustomTextBox();
            aPressBinding = new D360.CustomTextBox();
            bButtonHoldKey = new D360.CustomTextBox();
            bButtonPressKey = new D360.CustomTextBox();
            yHoldBinding = new D360.CustomTextBox();
            yPressBinding = new D360.CustomTextBox();
            xHoldBinding = new D360.CustomTextBox();
            xPressBinding = new D360.CustomTextBox();
            leftStickHoldBinding = new D360.CustomTextBox();
            leftStickPressBinding = new D360.CustomTextBox();
            rightShoulderHoldBinding = new D360.CustomTextBox();
            rightShoulderPressBinding = new D360.CustomTextBox();
            leftBumperHoldKey = new D360.CustomTextBox();
            leftBumperPressKey = new D360.CustomTextBox();
            leftTriggerHoldBinding = new D360.CustomTextBox();
            leftTriggerPressBinding = new D360.CustomTextBox();
            rightTriggerHoldBinding = new D360.CustomTextBox();
            rightTriggerPressBinding = new D360.CustomTextBox();
            startHoldBinding = new D360.CustomTextBox();
            startPressBinding = new D360.CustomTextBox();
            backHoldBinding = new D360.CustomTextBox();
            backPressBinding = new D360.CustomTextBox();
            defaultHoldBinding = new D360.CustomTextBox();
            defaultPressBinding = new D360.CustomTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.defaultTable.SuspendLayout();
            this.backPanel.SuspendLayout();
            this.startPanel.SuspendLayout();
            this.rightTriggerPanel.SuspendLayout();
            this.leftTriggerPanel.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.rightShoulderPanel.SuspendLayout();
            this.leftStickPanel.SuspendLayout();
            this.xPanel.SuspendLayout();
            this.yPanel.SuspendLayout();
            this.bPanel.SuspendLayout();
            this.aPanel.SuspendLayout();
            this.dPadDownPanel.SuspendLayout();
            this.dPadRightPanel.SuspendLayout();
            this.rightStickPanel.SuspendLayout();
            this.dPadUpPanel.SuspendLayout();
            this.dPadLeftPanel.SuspendLayout();
            this.bigButtonPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // defaultLabel
            // 
            defaultLabel.AutoSize = true;
            defaultLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            defaultLabel.Location = new System.Drawing.Point(3, 0);
            defaultLabel.Name = "defaultLabel";
            defaultLabel.Size = new System.Drawing.Size(169, 19);
            defaultLabel.TabIndex = 27;
            defaultLabel.Text = "Default Press Label";
            defaultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backLabel
            // 
            backLabel.AutoSize = true;
            backLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            backLabel.Location = new System.Drawing.Point(3, 0);
            backLabel.Name = "backLabel";
            backLabel.Size = new System.Drawing.Size(169, 19);
            backLabel.TabIndex = 27;
            backLabel.Text = "Default Press Label";
            backLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startLabel
            // 
            startLabel.AutoSize = true;
            startLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            startLabel.Location = new System.Drawing.Point(3, 0);
            startLabel.Name = "startLabel";
            startLabel.Size = new System.Drawing.Size(169, 19);
            startLabel.TabIndex = 27;
            startLabel.Text = "Default Press Label";
            startLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightTriggerLable
            // 
            rightTriggerLable.AutoSize = true;
            rightTriggerLable.Dock = System.Windows.Forms.DockStyle.Fill;
            rightTriggerLable.Location = new System.Drawing.Point(3, 0);
            rightTriggerLable.Name = "rightTriggerLable";
            rightTriggerLable.Size = new System.Drawing.Size(169, 19);
            rightTriggerLable.TabIndex = 27;
            rightTriggerLable.Text = "Default Press Label";
            rightTriggerLable.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leftTriggerLabel
            // 
            leftTriggerLabel.AutoSize = true;
            leftTriggerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            leftTriggerLabel.Location = new System.Drawing.Point(3, 0);
            leftTriggerLabel.Name = "leftTriggerLabel";
            leftTriggerLabel.Size = new System.Drawing.Size(169, 19);
            leftTriggerLabel.TabIndex = 27;
            leftTriggerLabel.Text = "Default Press Label";
            leftTriggerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leftBumperLabel
            // 
            leftBumperLabel.AutoSize = true;
            leftBumperLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            leftBumperLabel.Location = new System.Drawing.Point(3, 0);
            leftBumperLabel.Name = "leftBumperLabel";
            leftBumperLabel.Size = new System.Drawing.Size(169, 19);
            leftBumperLabel.TabIndex = 27;
            leftBumperLabel.Text = "Default Press Label";
            leftBumperLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightBumperLabel
            // 
            rightBumperLabel.AutoSize = true;
            rightBumperLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            rightBumperLabel.Location = new System.Drawing.Point(3, 0);
            rightBumperLabel.Name = "rightBumperLabel";
            rightBumperLabel.Size = new System.Drawing.Size(169, 19);
            rightBumperLabel.TabIndex = 27;
            rightBumperLabel.Text = "Default Press Label";
            rightBumperLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leftStickLabel
            // 
            leftStickLabel.AutoSize = true;
            leftStickLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            leftStickLabel.Location = new System.Drawing.Point(3, 0);
            leftStickLabel.Name = "leftStickLabel";
            leftStickLabel.Size = new System.Drawing.Size(169, 19);
            leftStickLabel.TabIndex = 27;
            leftStickLabel.Text = "Default Press Label";
            leftStickLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xLabel
            // 
            xLabel.AutoSize = true;
            xLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            xLabel.Location = new System.Drawing.Point(3, 0);
            xLabel.Name = "xLabel";
            xLabel.Size = new System.Drawing.Size(169, 19);
            xLabel.TabIndex = 27;
            xLabel.Text = "Default Press Label";
            xLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yLabel
            // 
            yLabel.AutoSize = true;
            yLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            yLabel.Location = new System.Drawing.Point(3, 0);
            yLabel.Name = "yLabel";
            yLabel.Size = new System.Drawing.Size(169, 19);
            yLabel.TabIndex = 27;
            yLabel.Text = "Default Press Label";
            yLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bLabel
            // 
            bLabel.AutoSize = true;
            bLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            bLabel.Location = new System.Drawing.Point(3, 0);
            bLabel.Name = "bLabel";
            bLabel.Size = new System.Drawing.Size(169, 19);
            bLabel.TabIndex = 27;
            bLabel.Text = "Default Press Label";
            bLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aLabel
            // 
            aLabel.AutoSize = true;
            aLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            aLabel.Location = new System.Drawing.Point(3, 0);
            aLabel.Name = "aLabel";
            aLabel.Size = new System.Drawing.Size(169, 19);
            aLabel.TabIndex = 27;
            aLabel.Text = "Default Press Label";
            aLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dPadDownLabel
            // 
            dPadDownLabel.AutoSize = true;
            dPadDownLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            dPadDownLabel.Location = new System.Drawing.Point(3, 0);
            dPadDownLabel.Name = "dPadDownLabel";
            dPadDownLabel.Size = new System.Drawing.Size(169, 19);
            dPadDownLabel.TabIndex = 27;
            dPadDownLabel.Text = "Default Press Label";
            dPadDownLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dPadRightLabel
            // 
            dPadRightLabel.AutoSize = true;
            dPadRightLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            dPadRightLabel.Location = new System.Drawing.Point(3, 0);
            dPadRightLabel.Name = "dPadRightLabel";
            dPadRightLabel.Size = new System.Drawing.Size(169, 19);
            dPadRightLabel.TabIndex = 27;
            dPadRightLabel.Text = "Default Press Label";
            dPadRightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightStickLabel
            // 
            rightStickLabel.AutoSize = true;
            rightStickLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            rightStickLabel.Location = new System.Drawing.Point(3, 0);
            rightStickLabel.Name = "rightStickLabel";
            rightStickLabel.Size = new System.Drawing.Size(169, 19);
            rightStickLabel.TabIndex = 27;
            rightStickLabel.Text = "Default Press Label";
            rightStickLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dPadUpLabel
            // 
            dPadUpLabel.AutoSize = true;
            dPadUpLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            dPadUpLabel.Location = new System.Drawing.Point(3, 0);
            dPadUpLabel.Name = "dPadUpLabel";
            dPadUpLabel.Size = new System.Drawing.Size(169, 19);
            dPadUpLabel.TabIndex = 27;
            dPadUpLabel.Text = "Default Press Label";
            dPadUpLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dPadLeftLabel
            // 
            dPadLeftLabel.AutoSize = true;
            dPadLeftLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            dPadLeftLabel.Location = new System.Drawing.Point(3, 0);
            dPadLeftLabel.Name = "dPadLeftLabel";
            dPadLeftLabel.Size = new System.Drawing.Size(169, 19);
            dPadLeftLabel.TabIndex = 27;
            dPadLeftLabel.Text = "Default Press Label";
            dPadLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // OldLeftTriggerLabel
            // 
            this.OldLeftTriggerLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OldLeftTriggerLabel.AutoSize = true;
            this.OldLeftTriggerLabel.Location = new System.Drawing.Point(12, 41);
            this.OldLeftTriggerLabel.Name = "OldLeftTriggerLabel";
            this.OldLeftTriggerLabel.Size = new System.Drawing.Size(61, 13);
            this.OldLeftTriggerLabel.TabIndex = 0;
            this.OldLeftTriggerLabel.Text = "Left Trigger";
            this.OldLeftTriggerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OldLeftTriggerLabel.Visible = false;
            // 
            // LeftTriggerComboBox
            // 
            this.LeftTriggerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LeftTriggerComboBox.FormattingEnabled = true;
            this.LeftTriggerComboBox.Items.AddRange(new object[] {
            "Action Bar Skill 1",
            "Action Bar Skill 2",
            "Action Bar Skill 3",
            "Action Bar Skill 4",
            "Inventory",
            "Map",
            "Potion",
            "Town Portal"});
            this.LeftTriggerComboBox.Location = new System.Drawing.Point(12, 12);
            this.LeftTriggerComboBox.Name = "LeftTriggerComboBox";
            this.LeftTriggerComboBox.Size = new System.Drawing.Size(186, 21);
            this.LeftTriggerComboBox.TabIndex = 1;
            this.LeftTriggerComboBox.Visible = false;
            this.LeftTriggerComboBox.SelectedIndexChanged += new System.EventHandler(this.LeftTriggerComboBox_SelectedIndexChanged);
            // 
            // OldRightTriggerLabel
            // 
            this.OldRightTriggerLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.OldRightTriggerLabel.AutoSize = true;
            this.OldRightTriggerLabel.Location = new System.Drawing.Point(1182, 41);
            this.OldRightTriggerLabel.Name = "OldRightTriggerLabel";
            this.OldRightTriggerLabel.Size = new System.Drawing.Size(68, 13);
            this.OldRightTriggerLabel.TabIndex = 2;
            this.OldRightTriggerLabel.Text = "Right Trigger";
            this.OldRightTriggerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.OldRightTriggerLabel.Visible = false;
            // 
            // RightTriggerComboBox
            // 
            this.RightTriggerComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.RightTriggerComboBox.FormattingEnabled = true;
            this.RightTriggerComboBox.Items.AddRange(new object[] {
            "Action Bar Skill 1",
            "Action Bar Skill 2",
            "Action Bar Skill 3",
            "Action Bar Skill 4",
            "Inventory",
            "Map",
            "Potion",
            "Town Portal"});
            this.RightTriggerComboBox.Location = new System.Drawing.Point(1066, 12);
            this.RightTriggerComboBox.Name = "RightTriggerComboBox";
            this.RightTriggerComboBox.Size = new System.Drawing.Size(186, 21);
            this.RightTriggerComboBox.TabIndex = 3;
            this.RightTriggerComboBox.Visible = false;
            this.RightTriggerComboBox.SelectedIndexChanged += new System.EventHandler(this.RightTriggerComboBox_SelectedIndexChanged);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(1157, 731);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(93, 23);
            this.cancelButton.TabIndex = 25;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveAndCloseButton
            // 
            this.saveAndCloseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.saveAndCloseButton.Location = new System.Drawing.Point(12, 731);
            this.saveAndCloseButton.Name = "saveAndCloseButton";
            this.saveAndCloseButton.Size = new System.Drawing.Size(93, 23);
            this.saveAndCloseButton.TabIndex = 24;
            this.saveAndCloseButton.Text = "Save and Close";
            this.saveAndCloseButton.UseVisualStyleBackColor = true;
            this.saveAndCloseButton.Click += new System.EventHandler(this.saveAndCloseButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::D360.Properties.Resources.XBoxOneControllerOutline1;
            this.pictureBox1.Location = new System.Drawing.Point(96, 108);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1067, 617);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // defaultTable
            // 
            this.defaultTable.ColumnCount = 1;
            this.defaultTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.defaultTable.Controls.Add(defaultHoldBinding, 0, 2);
            this.defaultTable.Controls.Add(defaultPressBinding, 0, 1);
            this.defaultTable.Controls.Add(defaultLabel, 0, 0);
            this.defaultTable.Location = new System.Drawing.Point(348, 12);
            this.defaultTable.Name = "defaultTable";
            this.defaultTable.RowCount = 3;
            this.defaultTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.22222F));
            this.defaultTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.77778F));
            this.defaultTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.defaultTable.Size = new System.Drawing.Size(175, 66);
            this.defaultTable.TabIndex = 33;
            this.defaultTable.Visible = false;
            // 
            // backPanel
            // 
            this.backPanel.ColumnCount = 1;
            this.backPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.backPanel.Controls.Add(backHoldBinding, 0, 2);
            this.backPanel.Controls.Add(backPressBinding, 0, 1);
            this.backPanel.Controls.Add(backLabel, 0, 0);
            this.backPanel.Location = new System.Drawing.Point(441, 175);
            this.backPanel.Name = "backPanel";
            this.backPanel.RowCount = 3;
            this.backPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.22222F));
            this.backPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.77778F));
            this.backPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.backPanel.Size = new System.Drawing.Size(175, 66);
            this.backPanel.TabIndex = 34;
            // 
            // startPanel
            // 
            this.startPanel.ColumnCount = 1;
            this.startPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.startPanel.Controls.Add(startHoldBinding, 0, 2);
            this.startPanel.Controls.Add(startPressBinding, 0, 1);
            this.startPanel.Controls.Add(startLabel, 0, 0);
            this.startPanel.Location = new System.Drawing.Point(638, 175);
            this.startPanel.Name = "startPanel";
            this.startPanel.RowCount = 3;
            this.startPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.22222F));
            this.startPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.77778F));
            this.startPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.startPanel.Size = new System.Drawing.Size(175, 66);
            this.startPanel.TabIndex = 35;
            // 
            // rightTriggerPanel
            // 
            this.rightTriggerPanel.ColumnCount = 1;
            this.rightTriggerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rightTriggerPanel.Controls.Add(rightTriggerHoldBinding, 0, 2);
            this.rightTriggerPanel.Controls.Add(rightTriggerPressBinding, 0, 1);
            this.rightTriggerPanel.Controls.Add(rightTriggerLable, 0, 0);
            this.rightTriggerPanel.Location = new System.Drawing.Point(949, 75);
            this.rightTriggerPanel.Name = "rightTriggerPanel";
            this.rightTriggerPanel.RowCount = 3;
            this.rightTriggerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.22222F));
            this.rightTriggerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.77778F));
            this.rightTriggerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.rightTriggerPanel.Size = new System.Drawing.Size(175, 66);
            this.rightTriggerPanel.TabIndex = 36;
            // 
            // leftTriggerPanel
            // 
            this.leftTriggerPanel.ColumnCount = 1;
            this.leftTriggerPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.leftTriggerPanel.Controls.Add(leftTriggerHoldBinding, 0, 2);
            this.leftTriggerPanel.Controls.Add(leftTriggerPressBinding, 0, 1);
            this.leftTriggerPanel.Controls.Add(leftTriggerLabel, 0, 0);
            this.leftTriggerPanel.Location = new System.Drawing.Point(155, 75);
            this.leftTriggerPanel.Name = "leftTriggerPanel";
            this.leftTriggerPanel.RowCount = 3;
            this.leftTriggerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.22222F));
            this.leftTriggerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.77778F));
            this.leftTriggerPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leftTriggerPanel.Size = new System.Drawing.Size(175, 66);
            this.leftTriggerPanel.TabIndex = 37;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel6.Controls.Add(leftBumperHoldKey, 0, 2);
            this.tableLayoutPanel6.Controls.Add(leftBumperPressKey, 0, 1);
            this.tableLayoutPanel6.Controls.Add(leftBumperLabel, 0, 0);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(112, 177);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 3;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.22222F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.77778F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(175, 66);
            this.tableLayoutPanel6.TabIndex = 38;
            // 
            // rightShoulderPanel
            // 
            this.rightShoulderPanel.ColumnCount = 1;
            this.rightShoulderPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rightShoulderPanel.Controls.Add(rightShoulderHoldBinding, 0, 2);
            this.rightShoulderPanel.Controls.Add(rightShoulderPressBinding, 0, 1);
            this.rightShoulderPanel.Controls.Add(rightBumperLabel, 0, 0);
            this.rightShoulderPanel.Location = new System.Drawing.Point(970, 179);
            this.rightShoulderPanel.Name = "rightShoulderPanel";
            this.rightShoulderPanel.RowCount = 3;
            this.rightShoulderPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.22222F));
            this.rightShoulderPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.77778F));
            this.rightShoulderPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.rightShoulderPanel.Size = new System.Drawing.Size(175, 66);
            this.rightShoulderPanel.TabIndex = 39;
            // 
            // leftStickPanel
            // 
            this.leftStickPanel.ColumnCount = 1;
            this.leftStickPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.leftStickPanel.Controls.Add(leftStickHoldBinding, 0, 2);
            this.leftStickPanel.Controls.Add(leftStickPressBinding, 0, 1);
            this.leftStickPanel.Controls.Add(leftStickLabel, 0, 0);
            this.leftStickPanel.Location = new System.Drawing.Point(82, 316);
            this.leftStickPanel.Name = "leftStickPanel";
            this.leftStickPanel.RowCount = 3;
            this.leftStickPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.22222F));
            this.leftStickPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.77778F));
            this.leftStickPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.leftStickPanel.Size = new System.Drawing.Size(175, 66);
            this.leftStickPanel.TabIndex = 40;
            // 
            // xPanel
            // 
            this.xPanel.ColumnCount = 1;
            this.xPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.xPanel.Controls.Add(xHoldBinding, 0, 2);
            this.xPanel.Controls.Add(xPressBinding, 0, 1);
            this.xPanel.Controls.Add(xLabel, 0, 0);
            this.xPanel.Location = new System.Drawing.Point(955, 280);
            this.xPanel.Name = "xPanel";
            this.xPanel.RowCount = 3;
            this.xPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.22222F));
            this.xPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.77778F));
            this.xPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.xPanel.Size = new System.Drawing.Size(175, 66);
            this.xPanel.TabIndex = 41;
            // 
            // yPanel
            // 
            this.yPanel.ColumnCount = 1;
            this.yPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.yPanel.Controls.Add(yHoldBinding, 0, 2);
            this.yPanel.Controls.Add(yPressBinding, 0, 1);
            this.yPanel.Controls.Add(yLabel, 0, 0);
            this.yPanel.Location = new System.Drawing.Point(1023, 354);
            this.yPanel.Name = "yPanel";
            this.yPanel.RowCount = 3;
            this.yPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.22222F));
            this.yPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.77778F));
            this.yPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.yPanel.Size = new System.Drawing.Size(175, 66);
            this.yPanel.TabIndex = 42;
            // 
            // bPanel
            // 
            this.bPanel.ColumnCount = 1;
            this.bPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.bPanel.Controls.Add(bButtonHoldKey, 0, 2);
            this.bPanel.Controls.Add(bButtonPressKey, 0, 1);
            this.bPanel.Controls.Add(bLabel, 0, 0);
            this.bPanel.Location = new System.Drawing.Point(1041, 428);
            this.bPanel.Name = "bPanel";
            this.bPanel.RowCount = 3;
            this.bPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.22222F));
            this.bPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.77778F));
            this.bPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.bPanel.Size = new System.Drawing.Size(175, 66);
            this.bPanel.TabIndex = 43;
            // 
            // aPanel
            // 
            this.aPanel.ColumnCount = 1;
            this.aPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.aPanel.Controls.Add(aHoldBinding, 0, 2);
            this.aPanel.Controls.Add(aPressBinding, 0, 1);
            this.aPanel.Controls.Add(aLabel, 0, 0);
            this.aPanel.Location = new System.Drawing.Point(1020, 511);
            this.aPanel.Name = "aPanel";
            this.aPanel.RowCount = 3;
            this.aPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.22222F));
            this.aPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.77778F));
            this.aPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.aPanel.Size = new System.Drawing.Size(175, 66);
            this.aPanel.TabIndex = 44;
            // 
            // dPadDownPanel
            // 
            this.dPadDownPanel.ColumnCount = 1;
            this.dPadDownPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.dPadDownPanel.Controls.Add(dPadDownHoldBinding, 0, 2);
            this.dPadDownPanel.Controls.Add(dPadDownPressBinding, 0, 1);
            this.dPadDownPanel.Controls.Add(dPadDownLabel, 0, 0);
            this.dPadDownPanel.Location = new System.Drawing.Point(264, 688);
            this.dPadDownPanel.Name = "dPadDownPanel";
            this.dPadDownPanel.RowCount = 3;
            this.dPadDownPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.22222F));
            this.dPadDownPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.77778F));
            this.dPadDownPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.dPadDownPanel.Size = new System.Drawing.Size(175, 66);
            this.dPadDownPanel.TabIndex = 45;
            // 
            // dPadRightPanel
            // 
            this.dPadRightPanel.ColumnCount = 1;
            this.dPadRightPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.dPadRightPanel.Controls.Add(dPadRightHoldBinding, 0, 2);
            this.dPadRightPanel.Controls.Add(dPadRightPressBinding, 0, 1);
            this.dPadRightPanel.Controls.Add(dPadRightLabel, 0, 0);
            this.dPadRightPanel.Location = new System.Drawing.Point(587, 688);
            this.dPadRightPanel.Name = "dPadRightPanel";
            this.dPadRightPanel.RowCount = 3;
            this.dPadRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.22222F));
            this.dPadRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.77778F));
            this.dPadRightPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.dPadRightPanel.Size = new System.Drawing.Size(175, 66);
            this.dPadRightPanel.TabIndex = 46;
            // 
            // rightStickPanel
            // 
            this.rightStickPanel.ColumnCount = 1;
            this.rightStickPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.rightStickPanel.Controls.Add(rightStickHoldBinding, 0, 2);
            this.rightStickPanel.Controls.Add(rightStickPressBinding, 0, 1);
            this.rightStickPanel.Controls.Add(rightStickLabel, 0, 0);
            this.rightStickPanel.Location = new System.Drawing.Point(819, 690);
            this.rightStickPanel.Name = "rightStickPanel";
            this.rightStickPanel.RowCount = 3;
            this.rightStickPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.22222F));
            this.rightStickPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.77778F));
            this.rightStickPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.rightStickPanel.Size = new System.Drawing.Size(175, 66);
            this.rightStickPanel.TabIndex = 47;
            // 
            // dPadUpPanel
            // 
            this.dPadUpPanel.ColumnCount = 1;
            this.dPadUpPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.dPadUpPanel.Controls.Add(dPadUpHoldBinding, 0, 2);
            this.dPadUpPanel.Controls.Add(dPadUpPressBinding, 0, 1);
            this.dPadUpPanel.Controls.Add(dPadUpLabel, 0, 0);
            this.dPadUpPanel.Location = new System.Drawing.Point(23, 450);
            this.dPadUpPanel.Name = "dPadUpPanel";
            this.dPadUpPanel.RowCount = 3;
            this.dPadUpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.22222F));
            this.dPadUpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.77778F));
            this.dPadUpPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.dPadUpPanel.Size = new System.Drawing.Size(175, 66);
            this.dPadUpPanel.TabIndex = 48;
            // 
            // dPadLeftPanel
            // 
            this.dPadLeftPanel.ColumnCount = 1;
            this.dPadLeftPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.dPadLeftPanel.Controls.Add(dPadLeftHoldBinding, 0, 2);
            this.dPadLeftPanel.Controls.Add(dPadLeftPressBinding, 0, 1);
            this.dPadLeftPanel.Controls.Add(dPadLeftLabel, 0, 0);
            this.dPadLeftPanel.Location = new System.Drawing.Point(26, 536);
            this.dPadLeftPanel.Name = "dPadLeftPanel";
            this.dPadLeftPanel.RowCount = 3;
            this.dPadLeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.22222F));
            this.dPadLeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.77778F));
            this.dPadLeftPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.dPadLeftPanel.Size = new System.Drawing.Size(175, 66);
            this.dPadLeftPanel.TabIndex = 49;
            // 
            // bigButtonPanel
            // 
            this.bigButtonPanel.ColumnCount = 1;
            this.bigButtonPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.bigButtonPanel.Controls.Add(bigButtonHoldBinding, 0, 2);
            this.bigButtonPanel.Controls.Add(bigButtonPressBinding, 0, 1);
            this.bigButtonPanel.Controls.Add(bigButtonLabel, 0, 0);
            this.bigButtonPanel.Location = new System.Drawing.Point(543, 12);
            this.bigButtonPanel.Name = "bigButtonPanel";
            this.bigButtonPanel.RowCount = 3;
            this.bigButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 42.22222F));
            this.bigButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 57.77778F));
            this.bigButtonPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.bigButtonPanel.Size = new System.Drawing.Size(175, 66);
            this.bigButtonPanel.TabIndex = 50;
            // 
            // bigButtonLabel
            // 
            bigButtonLabel.AutoSize = true;
            bigButtonLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            bigButtonLabel.Location = new System.Drawing.Point(3, 0);
            bigButtonLabel.Name = "bigButtonLabel";
            bigButtonLabel.Size = new System.Drawing.Size(169, 19);
            bigButtonLabel.TabIndex = 27;
            bigButtonLabel.Text = "Default Press Label";
            bigButtonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bigButtonHoldBinding
            // 
            bigButtonHoldBinding.AllowDrop = true;
            bigButtonHoldBinding.Cursor = System.Windows.Forms.Cursors.Default;
            bigButtonHoldBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            bigButtonHoldBinding.Location = new System.Drawing.Point(3, 48);
            bigButtonHoldBinding.Name = "bigButtonHoldBinding";
            bigButtonHoldBinding.Size = new System.Drawing.Size(169, 20);
            bigButtonHoldBinding.TabIndex = 33;
            bigButtonHoldBinding.Text = "Default Text Box";
            // 
            // bigButtonPressBinding
            // 
            bigButtonPressBinding.AllowDrop = true;
            bigButtonPressBinding.Cursor = System.Windows.Forms.Cursors.Default;
            bigButtonPressBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            bigButtonPressBinding.Location = new System.Drawing.Point(3, 22);
            bigButtonPressBinding.Name = "bigButtonPressBinding";
            bigButtonPressBinding.Size = new System.Drawing.Size(169, 20);
            bigButtonPressBinding.TabIndex = 29;
            bigButtonPressBinding.Text = "Default Text Box";
            // 
            // dPadLeftHoldBinding
            // 
            dPadLeftHoldBinding.AllowDrop = true;
            dPadLeftHoldBinding.Cursor = System.Windows.Forms.Cursors.Default;
            dPadLeftHoldBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            dPadLeftHoldBinding.Location = new System.Drawing.Point(3, 48);
            dPadLeftHoldBinding.Name = "dPadLeftHoldBinding";
            dPadLeftHoldBinding.Size = new System.Drawing.Size(169, 20);
            dPadLeftHoldBinding.TabIndex = 33;
            dPadLeftHoldBinding.Text = "Default Text Box";
            // 
            // dPadLeftPressBinding
            // 
            dPadLeftPressBinding.AllowDrop = true;
            dPadLeftPressBinding.Cursor = System.Windows.Forms.Cursors.Default;
            dPadLeftPressBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            dPadLeftPressBinding.Location = new System.Drawing.Point(3, 22);
            dPadLeftPressBinding.Name = "dPadLeftPressBinding";
            dPadLeftPressBinding.Size = new System.Drawing.Size(169, 20);
            dPadLeftPressBinding.TabIndex = 29;
            dPadLeftPressBinding.Text = "Default Text Box";
            // 
            // dPadUpHoldBinding
            // 
            dPadUpHoldBinding.AllowDrop = true;
            dPadUpHoldBinding.Cursor = System.Windows.Forms.Cursors.Default;
            dPadUpHoldBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            dPadUpHoldBinding.Location = new System.Drawing.Point(3, 48);
            dPadUpHoldBinding.Name = "dPadUpHoldBinding";
            dPadUpHoldBinding.Size = new System.Drawing.Size(169, 20);
            dPadUpHoldBinding.TabIndex = 33;
            dPadUpHoldBinding.Text = "Default Text Box";
            // 
            // dPadUpPressBinding
            // 
            dPadUpPressBinding.AllowDrop = true;
            dPadUpPressBinding.Cursor = System.Windows.Forms.Cursors.Default;
            dPadUpPressBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            dPadUpPressBinding.Location = new System.Drawing.Point(3, 22);
            dPadUpPressBinding.Name = "dPadUpPressBinding";
            dPadUpPressBinding.Size = new System.Drawing.Size(169, 20);
            dPadUpPressBinding.TabIndex = 29;
            dPadUpPressBinding.Text = "Default Text Box";
            // 
            // rightStickHoldBinding
            // 
            rightStickHoldBinding.AllowDrop = true;
            rightStickHoldBinding.Cursor = System.Windows.Forms.Cursors.Default;
            rightStickHoldBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            rightStickHoldBinding.Location = new System.Drawing.Point(3, 48);
            rightStickHoldBinding.Name = "rightStickHoldBinding";
            rightStickHoldBinding.Size = new System.Drawing.Size(169, 20);
            rightStickHoldBinding.TabIndex = 33;
            rightStickHoldBinding.Text = "Default Text Box";
            // 
            // rightStickPressBinding
            // 
            rightStickPressBinding.AllowDrop = true;
            rightStickPressBinding.Cursor = System.Windows.Forms.Cursors.Default;
            rightStickPressBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            rightStickPressBinding.Location = new System.Drawing.Point(3, 22);
            rightStickPressBinding.Name = "rightStickPressBinding";
            rightStickPressBinding.Size = new System.Drawing.Size(169, 20);
            rightStickPressBinding.TabIndex = 29;
            rightStickPressBinding.Text = "Default Text Box";
            // 
            // dPadRightHoldBinding
            // 
            dPadRightHoldBinding.AllowDrop = true;
            dPadRightHoldBinding.Cursor = System.Windows.Forms.Cursors.Default;
            dPadRightHoldBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            dPadRightHoldBinding.Location = new System.Drawing.Point(3, 48);
            dPadRightHoldBinding.Name = "dPadRightHoldBinding";
            dPadRightHoldBinding.Size = new System.Drawing.Size(169, 20);
            dPadRightHoldBinding.TabIndex = 33;
            dPadRightHoldBinding.Text = "Default Text Box";
            // 
            // dPadRightPressBinding
            // 
            dPadRightPressBinding.AllowDrop = true;
            dPadRightPressBinding.Cursor = System.Windows.Forms.Cursors.Default;
            dPadRightPressBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            dPadRightPressBinding.Location = new System.Drawing.Point(3, 22);
            dPadRightPressBinding.Name = "dPadRightPressBinding";
            dPadRightPressBinding.Size = new System.Drawing.Size(169, 20);
            dPadRightPressBinding.TabIndex = 29;
            dPadRightPressBinding.Text = "Default Text Box";
            // 
            // dPadDownHoldBinding
            // 
            dPadDownHoldBinding.AllowDrop = true;
            dPadDownHoldBinding.Cursor = System.Windows.Forms.Cursors.Default;
            dPadDownHoldBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            dPadDownHoldBinding.Location = new System.Drawing.Point(3, 48);
            dPadDownHoldBinding.Name = "dPadDownHoldBinding";
            dPadDownHoldBinding.Size = new System.Drawing.Size(169, 20);
            dPadDownHoldBinding.TabIndex = 33;
            dPadDownHoldBinding.Text = "Default Text Box";
            // 
            // dPadDownPressBinding
            // 
            dPadDownPressBinding.AllowDrop = true;
            dPadDownPressBinding.Cursor = System.Windows.Forms.Cursors.Default;
            dPadDownPressBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            dPadDownPressBinding.Location = new System.Drawing.Point(3, 22);
            dPadDownPressBinding.Name = "dPadDownPressBinding";
            dPadDownPressBinding.Size = new System.Drawing.Size(169, 20);
            dPadDownPressBinding.TabIndex = 29;
            dPadDownPressBinding.Text = "Default Text Box";
            // 
            // aHoldBinding
            // 
            aHoldBinding.AllowDrop = true;
            aHoldBinding.Cursor = System.Windows.Forms.Cursors.Default;
            aHoldBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            aHoldBinding.Location = new System.Drawing.Point(3, 48);
            aHoldBinding.Name = "aHoldBinding";
            aHoldBinding.Size = new System.Drawing.Size(169, 20);
            aHoldBinding.TabIndex = 33;
            aHoldBinding.Text = "Default Text Box";
            // 
            // aPressBinding
            // 
            aPressBinding.AllowDrop = true;
            aPressBinding.Cursor = System.Windows.Forms.Cursors.Default;
            aPressBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            aPressBinding.Location = new System.Drawing.Point(3, 22);
            aPressBinding.Name = "aPressBinding";
            aPressBinding.Size = new System.Drawing.Size(169, 20);
            aPressBinding.TabIndex = 29;
            aPressBinding.Text = "Default Text Box";
            // 
            // bButtonHoldKey
            // 
            bButtonHoldKey.AllowDrop = true;
            bButtonHoldKey.Cursor = System.Windows.Forms.Cursors.Default;
            bButtonHoldKey.Dock = System.Windows.Forms.DockStyle.Fill;
            bButtonHoldKey.Location = new System.Drawing.Point(3, 48);
            bButtonHoldKey.Name = "bButtonHoldKey";
            bButtonHoldKey.Size = new System.Drawing.Size(169, 20);
            bButtonHoldKey.TabIndex = 33;
            bButtonHoldKey.Text = "Default Text Box";
            // 
            // bButtonPressKey
            // 
            bButtonPressKey.AllowDrop = true;
            bButtonPressKey.Cursor = System.Windows.Forms.Cursors.Default;
            bButtonPressKey.Dock = System.Windows.Forms.DockStyle.Fill;
            bButtonPressKey.Location = new System.Drawing.Point(3, 22);
            bButtonPressKey.Name = "bButtonPressKey";
            bButtonPressKey.Size = new System.Drawing.Size(169, 20);
            bButtonPressKey.TabIndex = 29;
            bButtonPressKey.Text = "Default Text Box";
            // 
            // yHoldBinding
            // 
            yHoldBinding.AllowDrop = true;
            yHoldBinding.Cursor = System.Windows.Forms.Cursors.Default;
            yHoldBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            yHoldBinding.Location = new System.Drawing.Point(3, 48);
            yHoldBinding.Name = "yHoldBinding";
            yHoldBinding.Size = new System.Drawing.Size(169, 20);
            yHoldBinding.TabIndex = 33;
            yHoldBinding.Text = "Default Text Box";
            // 
            // yPressBinding
            // 
            yPressBinding.AllowDrop = true;
            yPressBinding.Cursor = System.Windows.Forms.Cursors.Default;
            yPressBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            yPressBinding.Location = new System.Drawing.Point(3, 22);
            yPressBinding.Name = "yPressBinding";
            yPressBinding.Size = new System.Drawing.Size(169, 20);
            yPressBinding.TabIndex = 29;
            yPressBinding.Text = "Default Text Box";
            // 
            // xHoldBinding
            // 
            xHoldBinding.AllowDrop = true;
            xHoldBinding.Cursor = System.Windows.Forms.Cursors.Default;
            xHoldBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            xHoldBinding.Location = new System.Drawing.Point(3, 48);
            xHoldBinding.Name = "xHoldBinding";
            xHoldBinding.Size = new System.Drawing.Size(169, 20);
            xHoldBinding.TabIndex = 33;
            xHoldBinding.Text = "Default Text Box";
            // 
            // xPressBinding
            // 
            xPressBinding.AllowDrop = true;
            xPressBinding.Cursor = System.Windows.Forms.Cursors.Default;
            xPressBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            xPressBinding.Location = new System.Drawing.Point(3, 22);
            xPressBinding.Name = "xPressBinding";
            xPressBinding.Size = new System.Drawing.Size(169, 20);
            xPressBinding.TabIndex = 29;
            xPressBinding.Text = "Default Text Box";
            // 
            // leftStickHoldBinding
            // 
            leftStickHoldBinding.AllowDrop = true;
            leftStickHoldBinding.Cursor = System.Windows.Forms.Cursors.Default;
            leftStickHoldBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            leftStickHoldBinding.Location = new System.Drawing.Point(3, 48);
            leftStickHoldBinding.Name = "leftStickHoldBinding";
            leftStickHoldBinding.Size = new System.Drawing.Size(169, 20);
            leftStickHoldBinding.TabIndex = 33;
            leftStickHoldBinding.Text = "Default Text Box";
            // 
            // leftStickPressBinding
            // 
            leftStickPressBinding.AllowDrop = true;
            leftStickPressBinding.Cursor = System.Windows.Forms.Cursors.Default;
            leftStickPressBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            leftStickPressBinding.Location = new System.Drawing.Point(3, 22);
            leftStickPressBinding.Name = "leftStickPressBinding";
            leftStickPressBinding.Size = new System.Drawing.Size(169, 20);
            leftStickPressBinding.TabIndex = 29;
            leftStickPressBinding.Text = "Default Text Box";
            // 
            // rightShoulderHoldBinding
            // 
            rightShoulderHoldBinding.AllowDrop = true;
            rightShoulderHoldBinding.Cursor = System.Windows.Forms.Cursors.Default;
            rightShoulderHoldBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            rightShoulderHoldBinding.Location = new System.Drawing.Point(3, 48);
            rightShoulderHoldBinding.Name = "rightShoulderHoldBinding";
            rightShoulderHoldBinding.Size = new System.Drawing.Size(169, 20);
            rightShoulderHoldBinding.TabIndex = 33;
            rightShoulderHoldBinding.Text = "Default Text Box";
            // 
            // rightShoulderPressBinding
            // 
            rightShoulderPressBinding.AllowDrop = true;
            rightShoulderPressBinding.Cursor = System.Windows.Forms.Cursors.Default;
            rightShoulderPressBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            rightShoulderPressBinding.Location = new System.Drawing.Point(3, 22);
            rightShoulderPressBinding.Name = "rightShoulderPressBinding";
            rightShoulderPressBinding.Size = new System.Drawing.Size(169, 20);
            rightShoulderPressBinding.TabIndex = 29;
            rightShoulderPressBinding.Text = "Default Text Box";
            // 
            // leftBumperHoldKey
            // 
            leftBumperHoldKey.AllowDrop = true;
            leftBumperHoldKey.Cursor = System.Windows.Forms.Cursors.Default;
            leftBumperHoldKey.Dock = System.Windows.Forms.DockStyle.Fill;
            leftBumperHoldKey.Location = new System.Drawing.Point(3, 48);
            leftBumperHoldKey.Name = "leftBumperHoldKey";
            leftBumperHoldKey.Size = new System.Drawing.Size(169, 20);
            leftBumperHoldKey.TabIndex = 33;
            leftBumperHoldKey.Text = "Default Text Box";
            // 
            // leftBumperPressKey
            // 
            leftBumperPressKey.AllowDrop = true;
            leftBumperPressKey.Cursor = System.Windows.Forms.Cursors.Default;
            leftBumperPressKey.Dock = System.Windows.Forms.DockStyle.Fill;
            leftBumperPressKey.Location = new System.Drawing.Point(3, 22);
            leftBumperPressKey.Name = "leftBumperPressKey";
            leftBumperPressKey.Size = new System.Drawing.Size(169, 20);
            leftBumperPressKey.TabIndex = 29;
            leftBumperPressKey.Text = "Default Text Box";
            // 
            // leftTriggerHoldBinding
            // 
            leftTriggerHoldBinding.AllowDrop = true;
            leftTriggerHoldBinding.Cursor = System.Windows.Forms.Cursors.Default;
            leftTriggerHoldBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            leftTriggerHoldBinding.Location = new System.Drawing.Point(3, 48);
            leftTriggerHoldBinding.Name = "leftTriggerHoldBinding";
            leftTriggerHoldBinding.Size = new System.Drawing.Size(169, 20);
            leftTriggerHoldBinding.TabIndex = 33;
            leftTriggerHoldBinding.Text = "Default Text Box";
            // 
            // leftTriggerPressBinding
            // 
            leftTriggerPressBinding.AllowDrop = true;
            leftTriggerPressBinding.Cursor = System.Windows.Forms.Cursors.Default;
            leftTriggerPressBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            leftTriggerPressBinding.Location = new System.Drawing.Point(3, 22);
            leftTriggerPressBinding.Name = "leftTriggerPressBinding";
            leftTriggerPressBinding.Size = new System.Drawing.Size(169, 20);
            leftTriggerPressBinding.TabIndex = 29;
            leftTriggerPressBinding.Text = "Default Text Box";
            // 
            // rightTriggerHoldBinding
            // 
            rightTriggerHoldBinding.AllowDrop = true;
            rightTriggerHoldBinding.Cursor = System.Windows.Forms.Cursors.Default;
            rightTriggerHoldBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            rightTriggerHoldBinding.Location = new System.Drawing.Point(3, 48);
            rightTriggerHoldBinding.Name = "rightTriggerHoldBinding";
            rightTriggerHoldBinding.Size = new System.Drawing.Size(169, 20);
            rightTriggerHoldBinding.TabIndex = 33;
            rightTriggerHoldBinding.Text = "Default Text Box";
            // 
            // rightTriggerPressBinding
            // 
            rightTriggerPressBinding.AllowDrop = true;
            rightTriggerPressBinding.Cursor = System.Windows.Forms.Cursors.Default;
            rightTriggerPressBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            rightTriggerPressBinding.Location = new System.Drawing.Point(3, 22);
            rightTriggerPressBinding.Name = "rightTriggerPressBinding";
            rightTriggerPressBinding.Size = new System.Drawing.Size(169, 20);
            rightTriggerPressBinding.TabIndex = 29;
            rightTriggerPressBinding.Text = "Default Text Box";
            // 
            // startHoldBinding
            // 
            startHoldBinding.AllowDrop = true;
            startHoldBinding.Cursor = System.Windows.Forms.Cursors.Default;
            startHoldBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            startHoldBinding.Location = new System.Drawing.Point(3, 48);
            startHoldBinding.Name = "startHoldBinding";
            startHoldBinding.Size = new System.Drawing.Size(169, 20);
            startHoldBinding.TabIndex = 33;
            startHoldBinding.Text = "Default Text Box";
            // 
            // startPressBinding
            // 
            startPressBinding.AllowDrop = true;
            startPressBinding.Cursor = System.Windows.Forms.Cursors.Default;
            startPressBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            startPressBinding.Location = new System.Drawing.Point(3, 22);
            startPressBinding.Name = "startPressBinding";
            startPressBinding.Size = new System.Drawing.Size(169, 20);
            startPressBinding.TabIndex = 29;
            startPressBinding.Text = "Default Text Box";
            // 
            // backHoldBinding
            // 
            backHoldBinding.AllowDrop = true;
            backHoldBinding.Cursor = System.Windows.Forms.Cursors.Default;
            backHoldBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            backHoldBinding.Location = new System.Drawing.Point(3, 48);
            backHoldBinding.Name = "backHoldBinding";
            backHoldBinding.Size = new System.Drawing.Size(169, 20);
            backHoldBinding.TabIndex = 33;
            backHoldBinding.Text = "Default Text Box";
            // 
            // backPressBinding
            // 
            backPressBinding.AllowDrop = true;
            backPressBinding.Cursor = System.Windows.Forms.Cursors.Default;
            backPressBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            backPressBinding.Location = new System.Drawing.Point(3, 22);
            backPressBinding.Name = "backPressBinding";
            backPressBinding.Size = new System.Drawing.Size(169, 20);
            backPressBinding.TabIndex = 29;
            backPressBinding.Text = "Default Text Box";
            // 
            // defaultHoldBinding
            // 
            defaultHoldBinding.AllowDrop = true;
            defaultHoldBinding.Cursor = System.Windows.Forms.Cursors.Default;
            defaultHoldBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            defaultHoldBinding.Location = new System.Drawing.Point(3, 48);
            defaultHoldBinding.Name = "defaultHoldBinding";
            defaultHoldBinding.Size = new System.Drawing.Size(169, 20);
            defaultHoldBinding.TabIndex = 33;
            defaultHoldBinding.Text = "Default Text Box";
            // 
            // defaultPressBinding
            // 
            defaultPressBinding.AllowDrop = true;
            defaultPressBinding.Cursor = System.Windows.Forms.Cursors.Default;
            defaultPressBinding.Dock = System.Windows.Forms.DockStyle.Fill;
            defaultPressBinding.Location = new System.Drawing.Point(3, 22);
            defaultPressBinding.Name = "defaultPressBinding";
            defaultPressBinding.Size = new System.Drawing.Size(169, 20);
            defaultPressBinding.TabIndex = 29;
            defaultPressBinding.Text = "Default Text Box";
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 766);
            this.Controls.Add(this.bigButtonPanel);
            this.Controls.Add(this.dPadLeftPanel);
            this.Controls.Add(this.dPadUpPanel);
            this.Controls.Add(this.rightStickPanel);
            this.Controls.Add(this.dPadRightPanel);
            this.Controls.Add(this.dPadDownPanel);
            this.Controls.Add(this.aPanel);
            this.Controls.Add(this.bPanel);
            this.Controls.Add(this.yPanel);
            this.Controls.Add(this.xPanel);
            this.Controls.Add(this.leftStickPanel);
            this.Controls.Add(this.rightShoulderPanel);
            this.Controls.Add(this.tableLayoutPanel6);
            this.Controls.Add(this.leftTriggerPanel);
            this.Controls.Add(this.rightTriggerPanel);
            this.Controls.Add(this.startPanel);
            this.Controls.Add(this.backPanel);
            this.Controls.Add(this.defaultTable);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveAndCloseButton);
            this.Controls.Add(this.RightTriggerComboBox);
            this.Controls.Add(this.OldRightTriggerLabel);
            this.Controls.Add(this.LeftTriggerComboBox);
            this.Controls.Add(this.OldLeftTriggerLabel);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "D360 Configuration";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigForm_FormClosing);
            this.VisibleChanged += new System.EventHandler(this.ConfigForm_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.defaultTable.ResumeLayout(false);
            this.defaultTable.PerformLayout();
            this.backPanel.ResumeLayout(false);
            this.backPanel.PerformLayout();
            this.startPanel.ResumeLayout(false);
            this.startPanel.PerformLayout();
            this.rightTriggerPanel.ResumeLayout(false);
            this.rightTriggerPanel.PerformLayout();
            this.leftTriggerPanel.ResumeLayout(false);
            this.leftTriggerPanel.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.rightShoulderPanel.ResumeLayout(false);
            this.rightShoulderPanel.PerformLayout();
            this.leftStickPanel.ResumeLayout(false);
            this.leftStickPanel.PerformLayout();
            this.xPanel.ResumeLayout(false);
            this.xPanel.PerformLayout();
            this.yPanel.ResumeLayout(false);
            this.yPanel.PerformLayout();
            this.bPanel.ResumeLayout(false);
            this.bPanel.PerformLayout();
            this.aPanel.ResumeLayout(false);
            this.aPanel.PerformLayout();
            this.dPadDownPanel.ResumeLayout(false);
            this.dPadDownPanel.PerformLayout();
            this.dPadRightPanel.ResumeLayout(false);
            this.dPadRightPanel.PerformLayout();
            this.rightStickPanel.ResumeLayout(false);
            this.rightStickPanel.PerformLayout();
            this.dPadUpPanel.ResumeLayout(false);
            this.dPadUpPanel.PerformLayout();
            this.dPadLeftPanel.ResumeLayout(false);
            this.dPadLeftPanel.PerformLayout();
            this.bigButtonPanel.ResumeLayout(false);
            this.bigButtonPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Button cancelButton;
        private Button saveAndCloseButton;
        private PictureBox pictureBox1;
        private BackgroundWorker backgroundWorker1;
        private TableLayoutPanel defaultTable;
        private TableLayoutPanel backPanel;
        private TableLayoutPanel startPanel;
        private TableLayoutPanel rightTriggerPanel;
        private TableLayoutPanel leftTriggerPanel;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel rightShoulderPanel;
        private TableLayoutPanel leftStickPanel;
        private TableLayoutPanel xPanel;
        private TableLayoutPanel yPanel;
        private TableLayoutPanel bPanel;
        private TableLayoutPanel aPanel;
        private TableLayoutPanel dPadDownPanel;
        private TableLayoutPanel dPadRightPanel;
        private TableLayoutPanel rightStickPanel;
        private TableLayoutPanel dPadUpPanel;
        private TableLayoutPanel dPadLeftPanel;
        private Label OldLeftTriggerLabel;
        private ComboBox LeftTriggerComboBox;
        private Label OldRightTriggerLabel;
        private ComboBox RightTriggerComboBox;
        private TableLayoutPanel bigButtonPanel;
    }
}