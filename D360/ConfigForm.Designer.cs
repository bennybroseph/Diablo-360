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
            System.Windows.Forms.Label backLabel;
            System.Windows.Forms.Button backEditButton;
            System.Windows.Forms.Label startLabel;
            System.Windows.Forms.Button startEditButton;
            System.Windows.Forms.Label leftTriggerLabel;
            System.Windows.Forms.Button leftTriggerEditButton;
            System.Windows.Forms.Label rightTriggerLabel;
            System.Windows.Forms.Button rightTriggerEditButton;
            System.Windows.Forms.Label guideLabel;
            System.Windows.Forms.Button guideEditButton;
            System.Windows.Forms.Label rightShoulderLabel;
            System.Windows.Forms.Button rightShoulderEditButton;
            System.Windows.Forms.Label leftShoulderLabel;
            System.Windows.Forms.Button leftShoulderEditButton;
            System.Windows.Forms.Label xLabel;
            System.Windows.Forms.Button xEditButton;
            System.Windows.Forms.Label yLabel;
            System.Windows.Forms.Button yEditButton;
            System.Windows.Forms.Label bLabel;
            System.Windows.Forms.Button bEditButton;
            System.Windows.Forms.Label aLabel;
            System.Windows.Forms.Button aEditButton;
            System.Windows.Forms.Label leftStickLabel;
            System.Windows.Forms.Button leftStickEditButton;
            System.Windows.Forms.Label upLabel;
            System.Windows.Forms.Button upEditButton;
            System.Windows.Forms.Label leftLabel;
            System.Windows.Forms.Button leftEditButton;
            System.Windows.Forms.Label downLabel;
            System.Windows.Forms.Button downEditButton;
            System.Windows.Forms.Label rightLabel;
            System.Windows.Forms.Button rightEditButton;
            System.Windows.Forms.Label rightStickLabel;
            System.Windows.Forms.Button rightStickEditButton;
            System.Windows.Forms.Label leftStickButtonLabel;
            System.Windows.Forms.Button leftStickButtonEditButton;
            System.Windows.Forms.Label rightStickButtonLabel;
            System.Windows.Forms.Button rightStickButtonEditButton;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveAndCloseButton = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.defaultPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel14 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel15 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel16 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel18 = new System.Windows.Forms.TableLayoutPanel();
            this.cursorLabel = new System.Windows.Forms.Label();
            this.cursorTrackBar = new System.Windows.Forms.TrackBar();
            this.cursorValueLabel = new System.Windows.Forms.Label();
            this.cursorMaxCheck = new System.Windows.Forms.CheckBox();
            this.targetMaxCheck = new System.Windows.Forms.CheckBox();
            this.targetValueLabel = new System.Windows.Forms.Label();
            this.targetTrackBar = new System.Windows.Forms.TrackBar();
            this.targetLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel19 = new System.Windows.Forms.TableLayoutPanel();
            this.offsetLabel = new System.Windows.Forms.Label();
            this.offsetXLabel = new System.Windows.Forms.Label();
            this.offsetYLabel = new System.Windows.Forms.Label();
            this.offsetXValue = new System.Windows.Forms.NumericUpDown();
            this.offsetYValue = new System.Windows.Forms.NumericUpDown();
            defaultEditButton = new System.Windows.Forms.Button();
            defaultLabel = new System.Windows.Forms.Label();
            backLabel = new System.Windows.Forms.Label();
            backEditButton = new System.Windows.Forms.Button();
            startLabel = new System.Windows.Forms.Label();
            startEditButton = new System.Windows.Forms.Button();
            leftTriggerLabel = new System.Windows.Forms.Label();
            leftTriggerEditButton = new System.Windows.Forms.Button();
            rightTriggerLabel = new System.Windows.Forms.Label();
            rightTriggerEditButton = new System.Windows.Forms.Button();
            guideLabel = new System.Windows.Forms.Label();
            guideEditButton = new System.Windows.Forms.Button();
            rightShoulderLabel = new System.Windows.Forms.Label();
            rightShoulderEditButton = new System.Windows.Forms.Button();
            leftShoulderLabel = new System.Windows.Forms.Label();
            leftShoulderEditButton = new System.Windows.Forms.Button();
            xLabel = new System.Windows.Forms.Label();
            xEditButton = new System.Windows.Forms.Button();
            yLabel = new System.Windows.Forms.Label();
            yEditButton = new System.Windows.Forms.Button();
            bLabel = new System.Windows.Forms.Label();
            bEditButton = new System.Windows.Forms.Button();
            aLabel = new System.Windows.Forms.Label();
            aEditButton = new System.Windows.Forms.Button();
            leftStickLabel = new System.Windows.Forms.Label();
            leftStickEditButton = new System.Windows.Forms.Button();
            upLabel = new System.Windows.Forms.Label();
            upEditButton = new System.Windows.Forms.Button();
            leftLabel = new System.Windows.Forms.Label();
            leftEditButton = new System.Windows.Forms.Button();
            downLabel = new System.Windows.Forms.Label();
            downEditButton = new System.Windows.Forms.Button();
            rightLabel = new System.Windows.Forms.Label();
            rightEditButton = new System.Windows.Forms.Button();
            rightStickLabel = new System.Windows.Forms.Label();
            rightStickEditButton = new System.Windows.Forms.Button();
            leftStickButtonLabel = new System.Windows.Forms.Label();
            leftStickButtonEditButton = new System.Windows.Forms.Button();
            rightStickButtonLabel = new System.Windows.Forms.Label();
            rightStickButtonEditButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.defaultPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            this.tableLayoutPanel14.SuspendLayout();
            this.tableLayoutPanel15.SuspendLayout();
            this.tableLayoutPanel16.SuspendLayout();
            this.tableLayoutPanel17.SuspendLayout();
            this.tableLayoutPanel18.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cursorTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetTrackBar)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel19.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.offsetXValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.offsetYValue)).BeginInit();
            this.SuspendLayout();
            // 
            // defaultEditButton
            // 
            defaultEditButton.AutoSize = true;
            defaultEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            defaultEditButton.Location = new System.Drawing.Point(3, 18);
            defaultEditButton.Name = "defaultEditButton";
            defaultEditButton.Size = new System.Drawing.Size(169, 24);
            defaultEditButton.TabIndex = 27;
            defaultEditButton.Text = "Edit";
            defaultEditButton.UseVisualStyleBackColor = true;
            defaultEditButton.Click += new System.EventHandler(this.OnEditClick);
            // 
            // defaultLabel
            // 
            defaultLabel.AutoSize = true;
            defaultLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            defaultLabel.Location = new System.Drawing.Point(3, 0);
            defaultLabel.Name = "defaultLabel";
            defaultLabel.Size = new System.Drawing.Size(169, 15);
            defaultLabel.TabIndex = 28;
            defaultLabel.Text = "Default Label";
            defaultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backLabel
            // 
            backLabel.AutoSize = true;
            backLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            backLabel.Location = new System.Drawing.Point(3, 0);
            backLabel.Name = "backLabel";
            backLabel.Size = new System.Drawing.Size(169, 15);
            backLabel.TabIndex = 28;
            backLabel.Text = "Back";
            backLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // backEditButton
            // 
            backEditButton.AutoSize = true;
            backEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            backEditButton.Location = new System.Drawing.Point(3, 18);
            backEditButton.Name = "backEditButton";
            backEditButton.Size = new System.Drawing.Size(169, 24);
            backEditButton.TabIndex = 27;
            backEditButton.Text = "Edit";
            backEditButton.UseVisualStyleBackColor = true;
            backEditButton.Click += new System.EventHandler(this.OnEditClick);
            // 
            // startLabel
            // 
            startLabel.AutoSize = true;
            startLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            startLabel.Location = new System.Drawing.Point(3, 0);
            startLabel.Name = "startLabel";
            startLabel.Size = new System.Drawing.Size(169, 15);
            startLabel.TabIndex = 28;
            startLabel.Text = "Start";
            startLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startEditButton
            // 
            startEditButton.AutoSize = true;
            startEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            startEditButton.Location = new System.Drawing.Point(3, 18);
            startEditButton.Name = "startEditButton";
            startEditButton.Size = new System.Drawing.Size(169, 24);
            startEditButton.TabIndex = 27;
            startEditButton.Text = "Edit";
            startEditButton.UseVisualStyleBackColor = true;
            startEditButton.Click += new System.EventHandler(this.OnEditClick);
            // 
            // leftTriggerLabel
            // 
            leftTriggerLabel.AutoSize = true;
            leftTriggerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            leftTriggerLabel.Location = new System.Drawing.Point(3, 0);
            leftTriggerLabel.Name = "leftTriggerLabel";
            leftTriggerLabel.Size = new System.Drawing.Size(169, 15);
            leftTriggerLabel.TabIndex = 28;
            leftTriggerLabel.Text = "Left Trigger";
            leftTriggerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leftTriggerEditButton
            // 
            leftTriggerEditButton.AutoSize = true;
            leftTriggerEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            leftTriggerEditButton.Location = new System.Drawing.Point(3, 18);
            leftTriggerEditButton.Name = "leftTriggerEditButton";
            leftTriggerEditButton.Size = new System.Drawing.Size(169, 24);
            leftTriggerEditButton.TabIndex = 27;
            leftTriggerEditButton.Text = "Edit";
            leftTriggerEditButton.UseVisualStyleBackColor = true;
            leftTriggerEditButton.Click += new System.EventHandler(this.OnEditClick);
            // 
            // rightTriggerLabel
            // 
            rightTriggerLabel.AutoSize = true;
            rightTriggerLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            rightTriggerLabel.Location = new System.Drawing.Point(3, 0);
            rightTriggerLabel.Name = "rightTriggerLabel";
            rightTriggerLabel.Size = new System.Drawing.Size(169, 15);
            rightTriggerLabel.TabIndex = 28;
            rightTriggerLabel.Text = "Right Trigger";
            rightTriggerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightTriggerEditButton
            // 
            rightTriggerEditButton.AutoSize = true;
            rightTriggerEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            rightTriggerEditButton.Location = new System.Drawing.Point(3, 18);
            rightTriggerEditButton.Name = "rightTriggerEditButton";
            rightTriggerEditButton.Size = new System.Drawing.Size(169, 24);
            rightTriggerEditButton.TabIndex = 27;
            rightTriggerEditButton.Text = "Edit";
            rightTriggerEditButton.UseVisualStyleBackColor = true;
            rightTriggerEditButton.Click += new System.EventHandler(this.OnEditClick);
            // 
            // guideLabel
            // 
            guideLabel.AutoSize = true;
            guideLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            guideLabel.Location = new System.Drawing.Point(3, 0);
            guideLabel.Name = "guideLabel";
            guideLabel.Size = new System.Drawing.Size(169, 15);
            guideLabel.TabIndex = 28;
            guideLabel.Text = "Guide";
            guideLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // guideEditButton
            // 
            guideEditButton.AutoSize = true;
            guideEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            guideEditButton.Location = new System.Drawing.Point(3, 18);
            guideEditButton.Name = "guideEditButton";
            guideEditButton.Size = new System.Drawing.Size(169, 24);
            guideEditButton.TabIndex = 27;
            guideEditButton.Text = "Edit";
            guideEditButton.UseVisualStyleBackColor = true;
            guideEditButton.Click += new System.EventHandler(this.OnEditClick);
            // 
            // rightShoulderLabel
            // 
            rightShoulderLabel.AutoSize = true;
            rightShoulderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            rightShoulderLabel.Location = new System.Drawing.Point(3, 0);
            rightShoulderLabel.Name = "rightShoulderLabel";
            rightShoulderLabel.Size = new System.Drawing.Size(169, 15);
            rightShoulderLabel.TabIndex = 28;
            rightShoulderLabel.Text = "Right Shoulder";
            rightShoulderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightShoulderEditButton
            // 
            rightShoulderEditButton.AutoSize = true;
            rightShoulderEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            rightShoulderEditButton.Location = new System.Drawing.Point(3, 18);
            rightShoulderEditButton.Name = "rightShoulderEditButton";
            rightShoulderEditButton.Size = new System.Drawing.Size(169, 24);
            rightShoulderEditButton.TabIndex = 27;
            rightShoulderEditButton.Text = "Edit";
            rightShoulderEditButton.UseVisualStyleBackColor = true;
            rightShoulderEditButton.Click += new System.EventHandler(this.OnEditClick);
            // 
            // leftShoulderLabel
            // 
            leftShoulderLabel.AutoSize = true;
            leftShoulderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            leftShoulderLabel.Location = new System.Drawing.Point(3, 0);
            leftShoulderLabel.Name = "leftShoulderLabel";
            leftShoulderLabel.Size = new System.Drawing.Size(169, 15);
            leftShoulderLabel.TabIndex = 28;
            leftShoulderLabel.Text = "Left Shoulder";
            leftShoulderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leftShoulderEditButton
            // 
            leftShoulderEditButton.AutoSize = true;
            leftShoulderEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            leftShoulderEditButton.Location = new System.Drawing.Point(3, 18);
            leftShoulderEditButton.Name = "leftShoulderEditButton";
            leftShoulderEditButton.Size = new System.Drawing.Size(169, 24);
            leftShoulderEditButton.TabIndex = 27;
            leftShoulderEditButton.Text = "Edit";
            leftShoulderEditButton.UseVisualStyleBackColor = true;
            leftShoulderEditButton.Click += new System.EventHandler(this.OnEditClick);
            // 
            // xLabel
            // 
            xLabel.AutoSize = true;
            xLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            xLabel.Location = new System.Drawing.Point(3, 0);
            xLabel.Name = "xLabel";
            xLabel.Size = new System.Drawing.Size(169, 15);
            xLabel.TabIndex = 28;
            xLabel.Text = "X";
            xLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // xEditButton
            // 
            xEditButton.AutoSize = true;
            xEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            xEditButton.Location = new System.Drawing.Point(3, 18);
            xEditButton.Name = "xEditButton";
            xEditButton.Size = new System.Drawing.Size(169, 24);
            xEditButton.TabIndex = 27;
            xEditButton.Text = "Edit";
            xEditButton.UseVisualStyleBackColor = true;
            xEditButton.Click += new System.EventHandler(this.OnEditClick);
            // 
            // yLabel
            // 
            yLabel.AutoSize = true;
            yLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            yLabel.Location = new System.Drawing.Point(3, 0);
            yLabel.Name = "yLabel";
            yLabel.Size = new System.Drawing.Size(169, 15);
            yLabel.TabIndex = 28;
            yLabel.Text = "Y";
            yLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yEditButton
            // 
            yEditButton.AutoSize = true;
            yEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            yEditButton.Location = new System.Drawing.Point(3, 18);
            yEditButton.Name = "yEditButton";
            yEditButton.Size = new System.Drawing.Size(169, 24);
            yEditButton.TabIndex = 27;
            yEditButton.Text = "Edit";
            yEditButton.UseVisualStyleBackColor = true;
            yEditButton.Click += new System.EventHandler(this.OnEditClick);
            // 
            // bLabel
            // 
            bLabel.AutoSize = true;
            bLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            bLabel.Location = new System.Drawing.Point(3, 0);
            bLabel.Name = "bLabel";
            bLabel.Size = new System.Drawing.Size(169, 15);
            bLabel.TabIndex = 28;
            bLabel.Text = "B";
            bLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // bEditButton
            // 
            bEditButton.AutoSize = true;
            bEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            bEditButton.Location = new System.Drawing.Point(3, 18);
            bEditButton.Name = "bEditButton";
            bEditButton.Size = new System.Drawing.Size(169, 24);
            bEditButton.TabIndex = 27;
            bEditButton.Text = "Edit";
            bEditButton.UseVisualStyleBackColor = true;
            bEditButton.Click += new System.EventHandler(this.OnEditClick);
            // 
            // aLabel
            // 
            aLabel.AutoSize = true;
            aLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            aLabel.Location = new System.Drawing.Point(3, 0);
            aLabel.Name = "aLabel";
            aLabel.Size = new System.Drawing.Size(169, 15);
            aLabel.TabIndex = 28;
            aLabel.Text = "A";
            aLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // aEditButton
            // 
            aEditButton.AutoSize = true;
            aEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            aEditButton.Location = new System.Drawing.Point(3, 18);
            aEditButton.Name = "aEditButton";
            aEditButton.Size = new System.Drawing.Size(169, 24);
            aEditButton.TabIndex = 27;
            aEditButton.Text = "Edit";
            aEditButton.UseVisualStyleBackColor = true;
            aEditButton.Click += new System.EventHandler(this.OnEditClick);
            // 
            // leftStickLabel
            // 
            leftStickLabel.AutoSize = true;
            leftStickLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            leftStickLabel.Location = new System.Drawing.Point(3, 0);
            leftStickLabel.Name = "leftStickLabel";
            leftStickLabel.Size = new System.Drawing.Size(169, 15);
            leftStickLabel.TabIndex = 28;
            leftStickLabel.Text = "Left Stick";
            leftStickLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leftStickEditButton
            // 
            leftStickEditButton.AutoSize = true;
            leftStickEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            leftStickEditButton.Location = new System.Drawing.Point(3, 18);
            leftStickEditButton.Name = "leftStickEditButton";
            leftStickEditButton.Size = new System.Drawing.Size(169, 24);
            leftStickEditButton.TabIndex = 27;
            leftStickEditButton.Text = "Edit";
            leftStickEditButton.UseVisualStyleBackColor = true;
            leftStickEditButton.Click += new System.EventHandler(this.OnEditClick);
            // 
            // upLabel
            // 
            upLabel.AutoSize = true;
            upLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            upLabel.Location = new System.Drawing.Point(3, 0);
            upLabel.Name = "upLabel";
            upLabel.Size = new System.Drawing.Size(169, 15);
            upLabel.TabIndex = 28;
            upLabel.Text = "DPad Up";
            upLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // upEditButton
            // 
            upEditButton.AutoSize = true;
            upEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            upEditButton.Location = new System.Drawing.Point(3, 18);
            upEditButton.Name = "upEditButton";
            upEditButton.Size = new System.Drawing.Size(169, 24);
            upEditButton.TabIndex = 27;
            upEditButton.Text = "Edit";
            upEditButton.UseVisualStyleBackColor = true;
            upEditButton.Click += new System.EventHandler(this.OnEditClick);
            // 
            // leftLabel
            // 
            leftLabel.AutoSize = true;
            leftLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            leftLabel.Location = new System.Drawing.Point(3, 0);
            leftLabel.Name = "leftLabel";
            leftLabel.Size = new System.Drawing.Size(169, 15);
            leftLabel.TabIndex = 28;
            leftLabel.Text = "DPad Left";
            leftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leftEditButton
            // 
            leftEditButton.AutoSize = true;
            leftEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            leftEditButton.Location = new System.Drawing.Point(3, 18);
            leftEditButton.Name = "leftEditButton";
            leftEditButton.Size = new System.Drawing.Size(169, 24);
            leftEditButton.TabIndex = 27;
            leftEditButton.Text = "Edit";
            leftEditButton.UseVisualStyleBackColor = true;
            leftEditButton.Click += new System.EventHandler(this.OnEditClick);
            // 
            // downLabel
            // 
            downLabel.AutoSize = true;
            downLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            downLabel.Location = new System.Drawing.Point(3, 0);
            downLabel.Name = "downLabel";
            downLabel.Size = new System.Drawing.Size(169, 15);
            downLabel.TabIndex = 28;
            downLabel.Text = "DPad Down";
            downLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // downEditButton
            // 
            downEditButton.AutoSize = true;
            downEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            downEditButton.Location = new System.Drawing.Point(3, 18);
            downEditButton.Name = "downEditButton";
            downEditButton.Size = new System.Drawing.Size(169, 24);
            downEditButton.TabIndex = 27;
            downEditButton.Text = "Edit";
            downEditButton.UseVisualStyleBackColor = true;
            downEditButton.Click += new System.EventHandler(this.OnEditClick);
            // 
            // rightLabel
            // 
            rightLabel.AutoSize = true;
            rightLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            rightLabel.Location = new System.Drawing.Point(3, 0);
            rightLabel.Name = "rightLabel";
            rightLabel.Size = new System.Drawing.Size(169, 15);
            rightLabel.TabIndex = 28;
            rightLabel.Text = "DPad Right";
            rightLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightEditButton
            // 
            rightEditButton.AutoSize = true;
            rightEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            rightEditButton.Location = new System.Drawing.Point(3, 18);
            rightEditButton.Name = "rightEditButton";
            rightEditButton.Size = new System.Drawing.Size(169, 24);
            rightEditButton.TabIndex = 27;
            rightEditButton.Text = "Edit";
            rightEditButton.UseVisualStyleBackColor = true;
            rightEditButton.Click += new System.EventHandler(this.OnEditClick);
            // 
            // rightStickLabel
            // 
            rightStickLabel.AutoSize = true;
            rightStickLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            rightStickLabel.Location = new System.Drawing.Point(3, 0);
            rightStickLabel.Name = "rightStickLabel";
            rightStickLabel.Size = new System.Drawing.Size(169, 15);
            rightStickLabel.TabIndex = 28;
            rightStickLabel.Text = "Right Stick";
            rightStickLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightStickEditButton
            // 
            rightStickEditButton.AutoSize = true;
            rightStickEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            rightStickEditButton.Location = new System.Drawing.Point(3, 18);
            rightStickEditButton.Name = "rightStickEditButton";
            rightStickEditButton.Size = new System.Drawing.Size(169, 24);
            rightStickEditButton.TabIndex = 27;
            rightStickEditButton.Text = "Edit";
            rightStickEditButton.UseVisualStyleBackColor = true;
            rightStickEditButton.Click += new System.EventHandler(this.OnEditClick);
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
            this.cancelButton.Click += new System.EventHandler(this.OnCancelClick);
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
            this.saveAndCloseButton.Click += new System.EventHandler(this.OnSaveClick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = global::D360.Properties.Resources.XBoxOneControllerOutline1;
            this.pictureBox1.Location = new System.Drawing.Point(98, 99);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1067, 617);
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
            this.defaultPanel.Location = new System.Drawing.Point(419, 18);
            this.defaultPanel.Name = "defaultPanel";
            this.defaultPanel.RowCount = 2;
            this.defaultPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.defaultPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.defaultPanel.Size = new System.Drawing.Size(175, 45);
            this.defaultPanel.TabIndex = 29;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(backLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(backEditButton, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(451, 192);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(175, 45);
            this.tableLayoutPanel2.TabIndex = 30;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(startLabel, 0, 0);
            this.tableLayoutPanel3.Controls.Add(startEditButton, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(632, 192);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(175, 45);
            this.tableLayoutPanel3.TabIndex = 31;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(leftTriggerLabel, 0, 0);
            this.tableLayoutPanel4.Controls.Add(leftTriggerEditButton, 0, 1);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(238, 48);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(175, 45);
            this.tableLayoutPanel4.TabIndex = 32;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(rightTriggerLabel, 0, 0);
            this.tableLayoutPanel5.Controls.Add(rightTriggerEditButton, 0, 1);
            this.tableLayoutPanel5.Location = new System.Drawing.Point(861, 48);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(175, 45);
            this.tableLayoutPanel5.TabIndex = 33;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(guideLabel, 0, 0);
            this.tableLayoutPanel6.Controls.Add(guideEditButton, 0, 1);
            this.tableLayoutPanel6.Location = new System.Drawing.Point(535, 99);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(175, 45);
            this.tableLayoutPanel6.TabIndex = 34;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(rightShoulderLabel, 0, 0);
            this.tableLayoutPanel7.Controls.Add(rightShoulderEditButton, 0, 1);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(964, 198);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(175, 45);
            this.tableLayoutPanel7.TabIndex = 35;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(leftShoulderLabel, 0, 0);
            this.tableLayoutPanel8.Controls.Add(leftShoulderEditButton, 0, 1);
            this.tableLayoutPanel8.Location = new System.Drawing.Point(124, 195);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(175, 45);
            this.tableLayoutPanel8.TabIndex = 36;
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.Controls.Add(xLabel, 0, 0);
            this.tableLayoutPanel9.Controls.Add(xEditButton, 0, 1);
            this.tableLayoutPanel9.Location = new System.Drawing.Point(990, 288);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(175, 45);
            this.tableLayoutPanel9.TabIndex = 37;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.Controls.Add(yLabel, 0, 0);
            this.tableLayoutPanel10.Controls.Add(yEditButton, 0, 1);
            this.tableLayoutPanel10.Location = new System.Drawing.Point(1027, 349);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel10.Size = new System.Drawing.Size(175, 45);
            this.tableLayoutPanel10.TabIndex = 38;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel11.Controls.Add(bLabel, 0, 0);
            this.tableLayoutPanel11.Controls.Add(bEditButton, 0, 1);
            this.tableLayoutPanel11.Location = new System.Drawing.Point(1043, 409);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel11.Size = new System.Drawing.Size(175, 45);
            this.tableLayoutPanel11.TabIndex = 39;
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.ColumnCount = 1;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel12.Controls.Add(aLabel, 0, 0);
            this.tableLayoutPanel12.Controls.Add(aEditButton, 0, 1);
            this.tableLayoutPanel12.Location = new System.Drawing.Point(1046, 472);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 2;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel12.Size = new System.Drawing.Size(175, 45);
            this.tableLayoutPanel12.TabIndex = 40;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 1;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Controls.Add(leftStickLabel, 0, 0);
            this.tableLayoutPanel13.Controls.Add(leftStickEditButton, 0, 1);
            this.tableLayoutPanel13.Location = new System.Drawing.Point(89, 303);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 2;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel13.Size = new System.Drawing.Size(175, 45);
            this.tableLayoutPanel13.TabIndex = 41;
            // 
            // tableLayoutPanel14
            // 
            this.tableLayoutPanel14.ColumnCount = 1;
            this.tableLayoutPanel14.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel14.Controls.Add(upLabel, 0, 0);
            this.tableLayoutPanel14.Controls.Add(upEditButton, 0, 1);
            this.tableLayoutPanel14.Location = new System.Drawing.Point(38, 475);
            this.tableLayoutPanel14.Name = "tableLayoutPanel14";
            this.tableLayoutPanel14.RowCount = 2;
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel14.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel14.Size = new System.Drawing.Size(175, 45);
            this.tableLayoutPanel14.TabIndex = 42;
            // 
            // tableLayoutPanel15
            // 
            this.tableLayoutPanel15.ColumnCount = 1;
            this.tableLayoutPanel15.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel15.Controls.Add(leftLabel, 0, 0);
            this.tableLayoutPanel15.Controls.Add(leftEditButton, 0, 1);
            this.tableLayoutPanel15.Location = new System.Drawing.Point(31, 542);
            this.tableLayoutPanel15.Name = "tableLayoutPanel15";
            this.tableLayoutPanel15.RowCount = 2;
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel15.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel15.Size = new System.Drawing.Size(175, 45);
            this.tableLayoutPanel15.TabIndex = 43;
            // 
            // tableLayoutPanel16
            // 
            this.tableLayoutPanel16.ColumnCount = 1;
            this.tableLayoutPanel16.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel16.Controls.Add(downLabel, 0, 0);
            this.tableLayoutPanel16.Controls.Add(downEditButton, 0, 1);
            this.tableLayoutPanel16.Location = new System.Drawing.Point(269, 685);
            this.tableLayoutPanel16.Name = "tableLayoutPanel16";
            this.tableLayoutPanel16.RowCount = 2;
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel16.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel16.Size = new System.Drawing.Size(175, 45);
            this.tableLayoutPanel16.TabIndex = 44;
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.ColumnCount = 1;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.Controls.Add(rightLabel, 0, 0);
            this.tableLayoutPanel17.Controls.Add(rightEditButton, 0, 1);
            this.tableLayoutPanel17.Location = new System.Drawing.Point(532, 699);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 2;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(175, 45);
            this.tableLayoutPanel17.TabIndex = 45;
            // 
            // tableLayoutPanel18
            // 
            this.tableLayoutPanel18.ColumnCount = 1;
            this.tableLayoutPanel18.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel18.Controls.Add(rightStickLabel, 0, 0);
            this.tableLayoutPanel18.Controls.Add(rightStickEditButton, 0, 1);
            this.tableLayoutPanel18.Location = new System.Drawing.Point(923, 687);
            this.tableLayoutPanel18.Name = "tableLayoutPanel18";
            this.tableLayoutPanel18.RowCount = 2;
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel18.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel18.Size = new System.Drawing.Size(175, 45);
            this.tableLayoutPanel18.TabIndex = 46;
            // 
            // cursorLabel
            // 
            this.cursorLabel.Location = new System.Drawing.Point(13, 13);
            this.cursorLabel.Name = "cursorLabel";
            this.cursorLabel.Size = new System.Drawing.Size(156, 14);
            this.cursorLabel.TabIndex = 47;
            this.cursorLabel.Text = "Cursor Radius";
            this.cursorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cursorTrackBar
            // 
            this.cursorTrackBar.AutoSize = false;
            this.cursorTrackBar.Location = new System.Drawing.Point(13, 30);
            this.cursorTrackBar.Maximum = 100;
            this.cursorTrackBar.Name = "cursorTrackBar";
            this.cursorTrackBar.Size = new System.Drawing.Size(156, 25);
            this.cursorTrackBar.TabIndex = 48;
            this.cursorTrackBar.TickFrequency = 10;
            this.cursorTrackBar.ValueChanged += new System.EventHandler(this.OnRadiusTrackBarChanged);
            // 
            // cursorValueLabel
            // 
            this.cursorValueLabel.Location = new System.Drawing.Point(175, 30);
            this.cursorValueLabel.Name = "cursorValueLabel";
            this.cursorValueLabel.Size = new System.Drawing.Size(60, 25);
            this.cursorValueLabel.TabIndex = 49;
            this.cursorValueLabel.Text = "Value%";
            this.cursorValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cursorMaxCheck
            // 
            this.cursorMaxCheck.AutoSize = true;
            this.cursorMaxCheck.Location = new System.Drawing.Point(13, 62);
            this.cursorMaxCheck.Name = "cursorMaxCheck";
            this.cursorMaxCheck.Size = new System.Drawing.Size(82, 17);
            this.cursorMaxCheck.TabIndex = 50;
            this.cursorMaxCheck.Text = "Always Max";
            this.cursorMaxCheck.UseVisualStyleBackColor = true;
            this.cursorMaxCheck.CheckStateChanged += new System.EventHandler(this.OnMaxCheckChanged);
            // 
            // targetMaxCheck
            // 
            this.targetMaxCheck.AutoSize = true;
            this.targetMaxCheck.Location = new System.Drawing.Point(12, 131);
            this.targetMaxCheck.Name = "targetMaxCheck";
            this.targetMaxCheck.Size = new System.Drawing.Size(82, 17);
            this.targetMaxCheck.TabIndex = 54;
            this.targetMaxCheck.Text = "Always Max";
            this.targetMaxCheck.UseVisualStyleBackColor = true;
            this.targetMaxCheck.CheckStateChanged += new System.EventHandler(this.OnMaxCheckChanged);
            // 
            // targetValueLabel
            // 
            this.targetValueLabel.Location = new System.Drawing.Point(174, 99);
            this.targetValueLabel.Name = "targetValueLabel";
            this.targetValueLabel.Size = new System.Drawing.Size(60, 25);
            this.targetValueLabel.TabIndex = 53;
            this.targetValueLabel.Text = "Value%";
            this.targetValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // targetTrackBar
            // 
            this.targetTrackBar.AutoSize = false;
            this.targetTrackBar.Location = new System.Drawing.Point(12, 99);
            this.targetTrackBar.Maximum = 100;
            this.targetTrackBar.Name = "targetTrackBar";
            this.targetTrackBar.Size = new System.Drawing.Size(156, 25);
            this.targetTrackBar.TabIndex = 52;
            this.targetTrackBar.TickFrequency = 10;
            this.targetTrackBar.ValueChanged += new System.EventHandler(this.OnRadiusTrackBarChanged);
            // 
            // targetLabel
            // 
            this.targetLabel.Location = new System.Drawing.Point(12, 82);
            this.targetLabel.Name = "targetLabel";
            this.targetLabel.Size = new System.Drawing.Size(156, 14);
            this.targetLabel.TabIndex = 51;
            this.targetLabel.Text = "Target Radius";
            this.targetLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(leftStickButtonLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(leftStickButtonEditButton, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(98, 354);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(175, 45);
            this.tableLayoutPanel1.TabIndex = 55;
            // 
            // leftStickButtonLabel
            // 
            leftStickButtonLabel.AutoSize = true;
            leftStickButtonLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            leftStickButtonLabel.Location = new System.Drawing.Point(3, 0);
            leftStickButtonLabel.Name = "leftStickButtonLabel";
            leftStickButtonLabel.Size = new System.Drawing.Size(169, 15);
            leftStickButtonLabel.TabIndex = 28;
            leftStickButtonLabel.Text = "Left Stick Button";
            leftStickButtonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // leftStickButtonEditButton
            // 
            leftStickButtonEditButton.AutoSize = true;
            leftStickButtonEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            leftStickButtonEditButton.Location = new System.Drawing.Point(3, 18);
            leftStickButtonEditButton.Name = "leftStickButtonEditButton";
            leftStickButtonEditButton.Size = new System.Drawing.Size(169, 24);
            leftStickButtonEditButton.TabIndex = 27;
            leftStickButtonEditButton.Text = "Edit";
            leftStickButtonEditButton.UseVisualStyleBackColor = true;
            leftStickButtonEditButton.Click += new System.EventHandler(this.OnEditClick);
            // 
            // tableLayoutPanel19
            // 
            this.tableLayoutPanel19.ColumnCount = 1;
            this.tableLayoutPanel19.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel19.Controls.Add(rightStickButtonLabel, 0, 0);
            this.tableLayoutPanel19.Controls.Add(rightStickButtonEditButton, 0, 1);
            this.tableLayoutPanel19.Location = new System.Drawing.Point(742, 717);
            this.tableLayoutPanel19.Name = "tableLayoutPanel19";
            this.tableLayoutPanel19.RowCount = 2;
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel19.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel19.Size = new System.Drawing.Size(175, 45);
            this.tableLayoutPanel19.TabIndex = 56;
            // 
            // rightStickButtonLabel
            // 
            rightStickButtonLabel.AutoSize = true;
            rightStickButtonLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            rightStickButtonLabel.Location = new System.Drawing.Point(3, 0);
            rightStickButtonLabel.Name = "rightStickButtonLabel";
            rightStickButtonLabel.Size = new System.Drawing.Size(169, 15);
            rightStickButtonLabel.TabIndex = 28;
            rightStickButtonLabel.Text = "Right Stick Button";
            rightStickButtonLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // rightStickButtonEditButton
            // 
            rightStickButtonEditButton.AutoSize = true;
            rightStickButtonEditButton.Dock = System.Windows.Forms.DockStyle.Fill;
            rightStickButtonEditButton.Location = new System.Drawing.Point(3, 18);
            rightStickButtonEditButton.Name = "rightStickButtonEditButton";
            rightStickButtonEditButton.Size = new System.Drawing.Size(169, 24);
            rightStickButtonEditButton.TabIndex = 27;
            rightStickButtonEditButton.Text = "Edit";
            rightStickButtonEditButton.UseVisualStyleBackColor = true;
            rightStickButtonEditButton.Click += new System.EventHandler(this.OnEditClick);
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
            this.offsetXLabel.Location = new System.Drawing.Point(1127, 39);
            this.offsetXLabel.Name = "offsetXLabel";
            this.offsetXLabel.Size = new System.Drawing.Size(15, 20);
            this.offsetXLabel.TabIndex = 60;
            this.offsetXLabel.Text = "X";
            this.offsetXLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // offsetYLabel
            // 
            this.offsetYLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.offsetYLabel.Location = new System.Drawing.Point(1128, 65);
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
            // ConfigForm
            // 
            this.AcceptButton = this.saveAndCloseButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 766);
            this.Controls.Add(this.offsetYValue);
            this.Controls.Add(this.offsetXValue);
            this.Controls.Add(this.offsetYLabel);
            this.Controls.Add(this.offsetXLabel);
            this.Controls.Add(this.offsetLabel);
            this.Controls.Add(this.tableLayoutPanel19);
            this.Controls.Add(this.targetMaxCheck);
            this.Controls.Add(this.targetValueLabel);
            this.Controls.Add(this.targetTrackBar);
            this.Controls.Add(this.targetLabel);
            this.Controls.Add(this.cursorMaxCheck);
            this.Controls.Add(this.cursorValueLabel);
            this.Controls.Add(this.cursorTrackBar);
            this.Controls.Add(this.cursorLabel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel18);
            this.Controls.Add(this.tableLayoutPanel17);
            this.Controls.Add(this.tableLayoutPanel16);
            this.Controls.Add(this.tableLayoutPanel15);
            this.Controls.Add(this.tableLayoutPanel14);
            this.Controls.Add(this.tableLayoutPanel13);
            this.Controls.Add(this.tableLayoutPanel12);
            this.Controls.Add(this.tableLayoutPanel11);
            this.Controls.Add(this.tableLayoutPanel10);
            this.Controls.Add(this.tableLayoutPanel9);
            this.Controls.Add(this.tableLayoutPanel8);
            this.Controls.Add(this.tableLayoutPanel7);
            this.Controls.Add(this.tableLayoutPanel6);
            this.Controls.Add(this.tableLayoutPanel5);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.defaultPanel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveAndCloseButton);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel5.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            this.tableLayoutPanel14.ResumeLayout(false);
            this.tableLayoutPanel14.PerformLayout();
            this.tableLayoutPanel15.ResumeLayout(false);
            this.tableLayoutPanel15.PerformLayout();
            this.tableLayoutPanel16.ResumeLayout(false);
            this.tableLayoutPanel16.PerformLayout();
            this.tableLayoutPanel17.ResumeLayout(false);
            this.tableLayoutPanel17.PerformLayout();
            this.tableLayoutPanel18.ResumeLayout(false);
            this.tableLayoutPanel18.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cursorTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.targetTrackBar)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel19.ResumeLayout(false);
            this.tableLayoutPanel19.PerformLayout();
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
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel5;
        private TableLayoutPanel tableLayoutPanel6;
        private TableLayoutPanel tableLayoutPanel7;
        private TableLayoutPanel tableLayoutPanel8;
        private TableLayoutPanel tableLayoutPanel9;
        private TableLayoutPanel tableLayoutPanel10;
        private TableLayoutPanel tableLayoutPanel11;
        private TableLayoutPanel tableLayoutPanel12;
        private TableLayoutPanel tableLayoutPanel13;
        private TableLayoutPanel tableLayoutPanel14;
        private TableLayoutPanel tableLayoutPanel15;
        private TableLayoutPanel tableLayoutPanel16;
        private TableLayoutPanel tableLayoutPanel17;
        private TableLayoutPanel tableLayoutPanel18;
        private Label cursorLabel;
        private TrackBar cursorTrackBar;
        private Label cursorValueLabel;
        private CheckBox cursorMaxCheck;
        private CheckBox targetMaxCheck;
        private Label targetValueLabel;
        private TrackBar targetTrackBar;
        private Label targetLabel;
        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel19;
        private Label offsetLabel;
        private Label offsetXLabel;
        private Label offsetYLabel;
        private NumericUpDown offsetXValue;
        private NumericUpDown offsetYValue;
    }
}