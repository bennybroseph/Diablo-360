﻿using System;
using System.Drawing;

namespace D360
{
    using System.Linq;
    using System.Windows.Forms;
    using Controller;
    using Controls;
    using Binding = Controller.Binding;
    using WinControl = System.Windows.Forms.Control;

    public partial class BindingConfigForm : Form
    {
        public event EventHandler ClosedEvent;

        public Form parentForm;
        private int m_TableCount;

        private bool m_EditingConfig;
        private Keys m_PressedKeys;

        public ControlConfig bindings;
        private ControlConfig m_TempBinding;

        private Size m_DefaultSize;

        private int m_ChangedControls;
        private int changedControls
        {
            get { return m_ChangedControls; }
            set
            {
                m_ChangedControls = value;
                SetSaveText();
            }
        }

        private bool m_Initialized;

        public BindingConfigForm()
        {
            InitializeComponent();

            m_DefaultSize =
                    new Size(
                        Size.Width,
                        Size.Height
                        - defaultPanel.Size.Height
                        - defaultPanel.Margin.Bottom * 2);
        }

        private void OnShow(object sender, EventArgs e)
        {
            InitializeTempConfig();
            CopyConfig(bindings, m_TempBinding);

            ProperResize();

            var triggerBinding = m_TempBinding as TriggerConfig;
            var stickConfig = m_TempBinding as StickConfig;
            if (triggerBinding != null || stickConfig != null)
            {
                deadZoneLabel.Visible = true;
                deadZoneValueLabel.Visible = true;
                deadZoneTrackBar.Visible = true;

                deadZoneTrackBar.Value =
                    (triggerBinding != null)
                        ? (int)(triggerBinding.deadzone * 100f)
                        : (int)Math.Round(stickConfig.moveDeadzone * 100f);
                deadZoneValueLabel.Text = deadZoneTrackBar.Value + @"%";

                if (stickConfig != null)
                {
                    actionZoneLabel.Visible = true;
                    actionZoneValueLabel.Visible = true;
                    actionZoneTrackBar.Visible = true;
                    actionZoneTrackBar.Value = (int)(stickConfig.actionDeadzone * 100f);
                    actionZoneValueLabel.Text = actionZoneTrackBar.Value + @"%";

                    modeLabel.Visible = true;
                    modeComboBox.Visible = true;
                    foreach (StickMode stickMode in Enum.GetValues(typeof(StickMode)))
                        modeComboBox.Items.Add(stickMode);
                    modeComboBox.SelectedItem = stickConfig.mode;
                }
            }

            m_Initialized = true;
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            CopyConfig(m_TempBinding, bindings);

            changedControls = 0;

            foreach (WinControl control in otherTabPage.Controls)
                control.Text = control.Text.TrimEnd('*');

            foreach (var table in bindingsTabPage.Controls.OfType<TableLayoutPanel>())
                foreach (var control in table.Controls.OfType<WinControl>())
                {
                    control.ForeColor = DefaultForeColor;
                    control.Text = control.Text.TrimEnd('*');
                }

            Refresh();
        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void OnAddClick(object sender, EventArgs e)
        {
            var newBinding = new KeyBinding();
            m_TempBinding.bindings.Add(newBinding);
            bindingsTabPage.Controls.Add(CreateNewBinding(newBinding));

            ProperResize();
        }

        private void OnDeleteClick(object sender, EventArgs e)
        {
            var senderButton = sender as Button;
            if (senderButton == null)
                return;

            var index =
                bindingsTabPage.Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<Button>().All(button => button != senderButton)).
                        Count() - 1;

            m_TempBinding.bindings.RemoveAt(index);

            bindingsTabPage.Controls.Remove(senderButton.Parent);
            --m_TableCount;

            ProperResize();
        }

        private void OnBindingTypeChanged(object sender, EventArgs e)
        {
            var senderComboBox = sender as ComboBox;
            if (senderComboBox == null || !m_Initialized)
                return;

            var index =
                bindingsTabPage.Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<ComboBox>().
                    All(comboBox => comboBox != senderComboBox)).
                        Count() - 1;

            m_TempBinding.bindings[index].inputMode = (InputMode)senderComboBox.SelectedItem;

            var isDifferent = bindings.bindings.Count <= index ||
                m_TempBinding.bindings[index].inputMode != bindings.bindings[index].inputMode;

            if (isDifferent)
                changedControls++;
            else
                changedControls--;

            var panel =
                bindingsTabPage.Controls.OfType<TableLayoutPanel>().First(x => x.Contains(senderComboBox));

            var textBox = panel.Controls.OfType<TextBox>().FirstOrDefault(x => !x.Multiline);
            if (textBox != null)
                textBox.Visible = m_TempBinding.bindings[index].GetType() == typeof(KeyBinding);

            var multilineBox = panel.Controls.OfType<TextBox>().FirstOrDefault(x => x.Multiline);
            if (multilineBox != null)
                multilineBox.Visible = m_TempBinding.bindings[index].GetType() == typeof(ScriptBinding);

            var specialComboBox = panel.Controls.OfType<ComboBox>().FirstOrDefault(x => panel.GetRow(x) == 2);
            if (specialComboBox != null)
                specialComboBox.Visible =
                    m_TempBinding.bindings[index].GetType() == typeof(SpecialBinding);

            Refresh();
        }

        private void OnScriptChanged(object sender, EventArgs e)
        {
            var senderTextBox = sender as TextBox;
            if (senderTextBox == null || senderTextBox.Multiline == false || !m_Initialized)
                return;

            var index =
                bindingsTabPage.Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<TextBox>().All(textBox => textBox != senderTextBox)).
                        Count() - 1;

            var scriptBinding = (ScriptBinding)bindings.bindings[index];
            var tempScriptBinding = (ScriptBinding)m_TempBinding.bindings[index];
            tempScriptBinding.script = senderTextBox.Text;

            var isDifferent = bindings.bindings.Count <= index ||
                tempScriptBinding.script != scriptBinding.script;

            senderTextBox.ForeColor = isDifferent ? Color.DodgerBlue : SystemColors.ControlText;
            if (isDifferent)
                changedControls++;
            else
                changedControls--;

            Refresh();
        }

        private void OnSpecialActionChanged(object sender, EventArgs e)
        {
            var senderComboBox = sender as ComboBox;
            if (senderComboBox == null || !m_Initialized)
                return;

            var index =
                bindingsTabPage.Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<ComboBox>().
                    All(comboBox => comboBox != senderComboBox)).
                        Count() - 1;

            var scriptBinding = (SpecialBinding)bindings.bindings[index];
            var tempScriptBinding = (SpecialBinding)m_TempBinding.bindings[index];
            //tempScriptBinding = (SpecialAction)senderComboBox.SelectedItem;

            var isDifferent = bindings.bindings.Count <= index ||
                tempScriptBinding != scriptBinding;

            if (isDifferent)
                changedControls++;
            else
                changedControls--;

            Refresh();
        }

        private void OnKeysTextBoxDoubleClick(object sender, EventArgs e)
        {
            var senderTextBox = sender as TextBox;
            if (m_EditingConfig || senderTextBox == null)
                return;

            m_EditingConfig = true;
            m_PressedKeys = Keys.None;

            // Set the color and text to signify it's being edited to the user
            senderTextBox.BackColor = Color.White;
            senderTextBox.ForeColor = Color.DodgerBlue;
            senderTextBox.Text = @"<Press Any Key>";

            // Force Redraw
            Refresh();
        }

        private void OnKeysTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (m_EditingConfig)
                m_PressedKeys = e.Modifiers;
        }

        private void OnKeysTextBoxMouseDown(object sender, EventArgs e)
        {
            var mouseEvent = e as MouseEventArgs;
            var senderTextBox = sender as TextBox;
            if (!m_EditingConfig || mouseEvent == null || senderTextBox == null)
                return;

            switch (mouseEvent.Button)
            {
                case MouseButtons.Left:
                    OnKeysTextBoxKeyUp(senderTextBox, new KeyEventArgs(Keys.LButton));
                    break;
                case MouseButtons.Right:
                    OnKeysTextBoxKeyUp(senderTextBox, new KeyEventArgs(Keys.RButton));
                    break;
                case MouseButtons.Middle:
                    OnKeysTextBoxKeyUp(senderTextBox, new KeyEventArgs(Keys.MButton));
                    break;

                case MouseButtons.XButton1:
                    OnKeysTextBoxKeyUp(senderTextBox, new KeyEventArgs(Keys.XButton1));
                    break;
                case MouseButtons.XButton2:
                    OnKeysTextBoxKeyUp(senderTextBox, new KeyEventArgs(Keys.XButton2));
                    break;
            }
        }

        private void OnKeysTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            var senderTextBox = sender as TextBox;
            if (!m_EditingConfig || senderTextBox == null || !m_Initialized)
                return;

            var index =
                bindingsTabPage.Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<TextBox>().All(textBox => textBox != senderTextBox)).
                        Count() - 1;

            var parsedKeys = e.KeyData;
            if (m_PressedKeys != Keys.None)
                parsedKeys |= m_PressedKeys;

            var scriptBinding = (KeyBinding)bindings.bindings[index];
            var tempScriptBinding = (KeyBinding)m_TempBinding.bindings[index];
            tempScriptBinding.keys = parsedKeys;

            var isDifferent =
                bindings.bindings.Count <= index ||
                tempScriptBinding.keys != scriptBinding.keys;

            senderTextBox.Text = tempScriptBinding.keys.ToString();
            senderTextBox.BackColor = defaultTextBox.BackColor;
            senderTextBox.ForeColor = isDifferent ? Color.DodgerBlue : SystemColors.ControlText;

            if (isDifferent)
                changedControls++;
            else
                changedControls--;

            m_EditingConfig = false;

            Refresh();
        }

        private void OnHoldCheckChanged(object sender, EventArgs e)
        {
            var senderCheck = sender as CheckBox;
            if (senderCheck == null || !m_Initialized)
                return;

            var index =
                bindingsTabPage.Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<CheckBox>().All(checkBox => checkBox != senderCheck)).
                        Count() - 1;

            m_TempBinding.bindings[index].isHoldAction = senderCheck.Checked;

            var isDifferent =
                bindings.bindings.Count <= index ||
                m_TempBinding.bindings[index].isHoldAction != bindings.bindings[index].isHoldAction;

            senderCheck.Text = senderCheck.Text.TrimEnd('*');
            if (isDifferent)
            {
                senderCheck.Text += '*';
                changedControls++;
            }
            else
                changedControls--;

            Refresh();
        }

        private void OnTargetedCheckChanged(object sender, EventArgs e)
        {
            var senderCheck = sender as CheckBox;
            if (senderCheck == null || !m_Initialized)
                return;

            var index =
                bindingsTabPage.Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<CheckBox>().All(checkBox => checkBox != senderCheck)).
                        Count() - 1;

            m_TempBinding.bindings[index].isTargetedAction = senderCheck.Checked;

            var isDifferent =
                bindings.bindings.Count <= index ||
                m_TempBinding.bindings[index].isTargetedAction != bindings.bindings[index].isTargetedAction;

            senderCheck.Text = senderCheck.Text.TrimEnd('*');
            if (isDifferent)
            {
                senderCheck.Text += '*';
                changedControls++;
            }
            else
                changedControls--;

            Refresh();
        }

        private void OnCheckModeChanged(object sender, EventArgs e)
        {
            var senderCheckBox = sender as CheckBox;
            if (senderCheckBox == null || !m_Initialized)
                return;

            var parentTable = senderCheckBox.Parent as TableLayoutPanel;

            if (parentTable == null)
                return;

            var index =
                bindingsTabPage.Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<CheckBox>().
                        All(radioButton => radioButton != senderCheckBox)).
                    Count() - 1;

            var bindingMode = (InputMode)(1 << parentTable.GetColumn(senderCheckBox));
            m_TempBinding.bindings[index].inputMode ^= bindingMode;

            var isDifferent =
                bindings.bindings.Count <= index ||
                (m_TempBinding.bindings[index].inputMode & bindingMode) !=
                (bindings.bindings[index].inputMode & bindingMode);

            senderCheckBox.Text = senderCheckBox.Text.TrimEnd('*');
            if (isDifferent)
            {
                senderCheckBox.Text += '*';
                changedControls++;
            }
            else
                changedControls--;

            Refresh();
        }

        private void OnDeadZoneValueChanged(object sender, EventArgs e)
        {
            var tempTriggerConfig = m_TempBinding as TriggerConfig;
            var tempStickConfig = m_TempBinding as StickConfig;
            if (tempTriggerConfig == null && tempStickConfig == null || !m_Initialized)
                return;

            deadZoneValueLabel.Text = deadZoneTrackBar.Value + @"%";

            var isDifferent = false;
            if (tempTriggerConfig != null)
            {
                tempTriggerConfig.deadzone = deadZoneTrackBar.Value / 100f;

                var triggerConfig = bindings as TriggerConfig;
                if (triggerConfig != null)
                    isDifferent = Math.Abs(tempTriggerConfig.deadzone - triggerConfig.deadzone) > float.Epsilon;
            }
            if (tempStickConfig != null)
            {
                tempStickConfig.moveDeadzone = deadZoneTrackBar.Value / 100f;

                var stickConfig = bindings as StickConfig;
                if (stickConfig != null)
                    isDifferent = Math.Abs(tempStickConfig.moveDeadzone - stickConfig.moveDeadzone) > float.Epsilon;
            }

            if (isDifferent && !deadZoneLabel.Text.Contains("*"))
            {
                changedControls++;
                deadZoneLabel.Text += '*';
            }
            else if (!isDifferent)
            {
                changedControls--;
                deadZoneLabel.Text = deadZoneLabel.Text.TrimEnd('*');
            }

            Refresh();
        }

        private void OnActionZoneValueChanged(object sender, EventArgs e)
        {
            var tempStickConfig = m_TempBinding as StickConfig;
            var stickConfig = bindings as StickConfig;
            if (tempStickConfig == null || stickConfig == null || !m_Initialized)
                return;

            actionZoneValueLabel.Text = actionZoneTrackBar.Value + @"%";

            tempStickConfig.actionDeadzone = actionZoneTrackBar.Value / 100f;

            var isDifferent = Math.Abs(tempStickConfig.actionDeadzone - stickConfig.actionDeadzone) > float.Epsilon;
            if (isDifferent && !actionZoneLabel.Text.Contains("*"))
            {
                changedControls++;
                actionZoneLabel.Text += '*';
            }
            else if (!isDifferent)
            {
                changedControls--;
                actionZoneLabel.Text = actionZoneLabel.Text.TrimEnd('*');
            }

            Refresh();
        }

        private void OnStickModeChanged(object sender, EventArgs e)
        {
            var tempStickConfig = m_TempBinding as StickConfig;
            var stickConfig = bindings as StickConfig;
            if (tempStickConfig == null || stickConfig == null || !m_Initialized)
                return;

            tempStickConfig.mode = (StickMode)modeComboBox.SelectedItem;

            var isDifferent = tempStickConfig.mode != stickConfig.mode;
            if (isDifferent)
                changedControls++;
            else
                changedControls--;

            Refresh();
        }

        private void SetSaveText()
        {
            saveButton.Text = saveButton.Text.TrimEnd('*');
            if (m_ChangedControls > 0)
                saveButton.Text += '*';
        }

        private void OnLoad(object sender, EventArgs e)
        {
            AnchorToParent();
        }

        public void OnParentMove()
        {
            AnchorToParent();
        }

        private void AnchorToParent()
        {
            if (parentForm != null)
                Location = new Point(parentForm.Location.X + parentForm.Size.Width, parentForm.Location.Y);
        }

        private void ProperResize()
        {
            var sizeCoefficient = (m_TableCount >= 1) ? m_TableCount : 1;
            Size =
                new Size(
                    m_DefaultSize.Width,
                    m_DefaultSize.Height
                    + defaultPanel.Size.Height * sizeCoefficient
                    + defaultPanel.Margin.Bottom * sizeCoefficient * 2);

            var tables =
                bindingsTabPage.Controls.OfType<TableLayoutPanel>().Where(x => x.Name != "defaultPanel").ToArray();
            for (var i = 0; i < tables.Length; ++i)
            {
                tables[i].Name = @"Binding " + (i + 1);
                tables[i].Location =
                    new Point(
                        defaultPanel.Location.X,
                        defaultPanel.Location.Y
                        + defaultPanel.Size.Height * i
                        + defaultPanel.Margin.Bottom * i * 2);
            }
        }

        private BindingControl CreateNewBinding(Binding binding)
        {
            return new BindingControl(binding);
            //var newPanel = new TableLayoutPanel
            //{
            //    Name = "newPanel" + m_TableCount,
            //    Size = new Size(defaultPanel.Size.Width, defaultPanel.Size.Height),
            //    Location =
            //        new Point(
            //            defaultPanel.Location.X,
            //            defaultPanel.Location.Y
            //            + defaultPanel.Size.Height * m_TableCount
            //            + defaultPanel.Margin.Bottom * m_TableCount * 2),
            //    BorderStyle = BorderStyle.FixedSingle
            //};
            //newPanel.RowStyles.Clear();
            //foreach (RowStyle rowStyle in defaultPanel.RowStyles)
            //    newPanel.RowStyles.Add(new RowStyle(rowStyle.SizeType, rowStyle.Height));
            //newPanel.ColumnStyles.Clear();
            //foreach (ColumnStyle columnStyle in defaultPanel.ColumnStyles)
            //    newPanel.ColumnStyles.Add(new ColumnStyle(columnStyle.SizeType, columnStyle.Width));

            //var newLabel = new Label
            //{
            //    Text = @"Binding " + (m_TableCount + 1),
            //    AutoSize = defaultLabel.AutoSize,
            //    Dock = defaultLabel.Dock,
            //    TextAlign = defaultLabel.TextAlign
            //};

            //var newComboBox = new ComboBox
            //{
            //    Name = "newComboBox" + m_TableCount,
            //    DropDownStyle = defaultComboBox.DropDownStyle,
            //    AutoSize = defaultComboBox.AutoSize,
            //    Dock = defaultComboBox.Dock
            //};
            //foreach (InputMode bindingType in Enum.GetValues(typeof(InputMode)))
            //    newComboBox.Items.Add(bindingType);
            //newComboBox.SelectedItem = controlBinding.inputMode;
            //newComboBox.SelectedIndexChanged += OnBindingTypeChanged;

            //var newSpecialComboBox = new ComboBox
            //{
            //    Name = "newComboBox" + m_TableCount,
            //    DropDownStyle = defaultComboBox.DropDownStyle,
            //    AutoSize = defaultComboBox.AutoSize,
            //    Dock = defaultComboBox.Dock,
            //    //Visible = controlBinding.inputMode == InputMode.SpecialAction
            //};
            ////foreach (SpecialAction value in Enum.GetValues(typeof(SpecialAction)))
            ////    newSpecialComboBox.Items.Add(value);
            ////newSpecialComboBox.SelectedItem = controlBinding.specialAction;
            ////newSpecialComboBox.SelectedIndexChanged += OnSpecialActionChanged;

            //var newMultilineBox = new TextBox
            //{
            //    Name = "newMultilineBox" + m_TableCount,
            //    //Text = controlBinding.script,
            //    AutoSize = defaultTextBox.AutoSize,
            //    Dock = defaultTextBox.Dock,
            //    Multiline = true,
            //    //Visible = controlBinding.inputMode == InputMode.Script
            //};
            //newMultilineBox.TextChanged += OnScriptChanged;

            //var newTextBox = new CustomTextBox
            //{
            //    Name = "newTextBox" + m_TableCount,
            //    //Text = controlBinding.keys.ToString(),
            //    AutoSize = defaultTextBox.AutoSize,
            //    Dock = defaultTextBox.Dock,
            //    ReadOnly = defaultTextBox.ReadOnly,
            //    Cursor = defaultTextBox.Cursor,
            //    //Visible = controlBinding.inputMode == InputMode,
            //    ContextMenu = new ContextMenu()
            //};
            //newTextBox.MouseDoubleClick += OnKeysTextBoxDoubleClick;
            //newTextBox.KeyDown += OnKeysTextBoxKeyDown;
            //newTextBox.MouseDown += OnKeysTextBoxMouseDown;
            //newTextBox.KeyUp += OnKeysTextBoxKeyUp;

            //var newHoldCheck = new CheckBox
            //{
            //    Name = "newCheck" + m_TableCount,
            //    Text = defaultHeldCheck.Text,
            //    Checked = controlBinding.isHoldAction
            //};
            //newHoldCheck.CheckStateChanged += OnHoldCheckChanged;

            //var newTargetedCheck = new CheckBox
            //{
            //    Name = "newCheck" + m_TableCount,
            //    Text = defaultTargetCheck.Text,
            //    Checked = controlBinding.isTargetedAction
            //};
            //newTargetedCheck.CheckStateChanged += OnTargetedCheckChanged;

            //var newMoveCheck = new CheckBox
            //{
            //    Name = "newMoveCheck" + m_TableCount,
            //    Text = defaultMoveRadio.Text,
            //    //Checked = (controlBinding.inputMode & BindingMode.Move) == BindingMode.Move
            //};
            //newMoveCheck.CheckStateChanged += OnCheckModeChanged;
            //var newPointerCheck = new CheckBox
            //{
            //    Name = "newPointerCheck" + m_TableCount,
            //    Text = defaultPointerRadio.Text,
            //    //Checked = (controlBinding.bindingMode & BindingMode.Pointer) == BindingMode.Pointer
            //};
            //newPointerCheck.CheckStateChanged += OnCheckModeChanged;

            //var newDelete = new Button
            //{
            //    Name = "newDeleteButton" + m_TableCount,
            //    Text = defaultDelete.Text,
            //    Dock = defaultDelete.Dock
            //};
            //newDelete.Click += OnDeleteClick;

            //newPanel.Controls.Add(newLabel, 0, 0);
            //newPanel.Controls.Add(newComboBox, 0, 1);
            //newPanel.Controls.Add(newSpecialComboBox, 0, 2);
            //newPanel.Controls.Add(newMultilineBox, 0, 2);
            //newPanel.Controls.Add(newTextBox, 0, 2);
            //newPanel.Controls.Add(newHoldCheck, 0, 3);
            //newPanel.Controls.Add(newTargetedCheck, 1, 3);
            //newPanel.Controls.Add(newMoveCheck, 0, 4);
            //newPanel.Controls.Add(newPointerCheck, 1, 4);
            //newPanel.Controls.Add(newDelete, 0, 5);

            //newPanel.SetColumnSpan(newLabel, 2);
            //newPanel.SetColumnSpan(newComboBox, 2);
            //newPanel.SetColumnSpan(newSpecialComboBox, 2);
            //newPanel.SetColumnSpan(newMultilineBox, 2);
            //newPanel.SetColumnSpan(newTextBox, 2);
            //newPanel.SetColumnSpan(newDelete, 2);

            //m_TableCount++;

            //return newPanel;
        }

        private void CopyConfig(ControlConfig source, ControlConfig destination)
        {
            var triggerBinding = source as TriggerConfig;
            var destTriggerBinding = destination as TriggerConfig;

            var stickConfig = source as StickConfig;
            var destStickConfig = destination as StickConfig;

            if (triggerBinding != null && destTriggerBinding != null)
                destTriggerBinding.deadzone = triggerBinding.deadzone;
            else if (stickConfig != null && destStickConfig != null)
            {
                destStickConfig.moveDeadzone = stickConfig.moveDeadzone;
                destStickConfig.actionDeadzone = stickConfig.actionDeadzone;
                destStickConfig.mode = stickConfig.mode;
            }

            destination.bindings.Clear();
            foreach (var sourceBinding in source.bindings)
            {
                destination.bindings.Add(sourceBinding.Clone());
                bindingsTabPage.Controls.Add(CreateNewBinding(sourceBinding));
            }
        }
        private void InitializeTempConfig()
        {
            var triggerBinding = bindings as TriggerConfig;
            var stickConfig = bindings as StickConfig;

            if (triggerBinding != null)
                m_TempBinding = new TriggerConfig();
            else if (stickConfig != null)
                m_TempBinding = new StickConfig();
            else
                m_TempBinding = new ControlConfig();
        }

        private void OnClosed(object sender, FormClosedEventArgs e)
        {
            ClosedEvent?.Invoke(this, e);
        }
    }

    public class CustomTextBox : TextBox
    {
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Tab)
                return true;

            return base.IsInputKey(keyData);
        }
    }
}
