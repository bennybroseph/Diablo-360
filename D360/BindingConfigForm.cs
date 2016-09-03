using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using D360.Types;
using D360.Utility;

namespace D360
{
    public partial class BindingConfigForm : Form
    {
        public Form parentForm;
        private int m_TableCount;

        private bool m_EditingConfig;

        public BindingConfig bindings;
        private BindingConfig m_TempBinding;

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

                if (triggerBinding == null)
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

            foreach (Control control in otherTabPage.Controls)
                control.Text = control.Text.TrimEnd('*');

            foreach (var table in bindingsTabPage.Controls.OfType<TableLayoutPanel>())
                foreach (var control in table.Controls.OfType<Control>())
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
            var newBinding = new ControlBinding();
            m_TempBinding.controlBindings.Add(newBinding);
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

            m_TempBinding.controlBindings.RemoveAt(index);

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

            m_TempBinding.controlBindings[index].bindingType = (BindingType)senderComboBox.SelectedItem;

            var isDifferent = bindings.controlBindings.Count <= index ||
                m_TempBinding.controlBindings[index].bindingType != bindings.controlBindings[index].bindingType;

            if (isDifferent)
                changedControls++;
            else
                changedControls--;

            var panel =
                bindingsTabPage.Controls.OfType<TableLayoutPanel>().First(x => x.Contains(senderComboBox));

            var textBox = panel.Controls.OfType<TextBox>().FirstOrDefault(x => !x.Multiline);
            if (textBox != null)
                textBox.Visible = m_TempBinding.controlBindings[index].bindingType == BindingType.Key;

            var multilineBox = panel.Controls.OfType<TextBox>().FirstOrDefault(x => x.Multiline);
            if (multilineBox != null)
                multilineBox.Visible = m_TempBinding.controlBindings[index].bindingType == BindingType.Script;

            var specialComboBox = panel.Controls.OfType<ComboBox>().FirstOrDefault(x => panel.GetRow(x) == 2);
            if (specialComboBox != null)
                specialComboBox.Visible =
                    m_TempBinding.controlBindings[index].bindingType == BindingType.SpecialAction;

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

            m_TempBinding.controlBindings[index].script = senderTextBox.Text;

            var isDifferent = bindings.controlBindings.Count <= index ||
                m_TempBinding.controlBindings[index].script != bindings.controlBindings[index].script;

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

            m_TempBinding.controlBindings[index].specialAction = (SpecialAction)senderComboBox.SelectedItem;

            var isDifferent = bindings.controlBindings.Count <= index ||
                m_TempBinding.controlBindings[index].specialAction != bindings.controlBindings[index].specialAction;

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

            // Set the color and text to signify it's being edited to the user
            senderTextBox.BackColor = Color.White;
            senderTextBox.ForeColor = Color.DodgerBlue;
            senderTextBox.Text = @"<Press Any Key>";

            // Force Redraw
            Refresh();
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

            m_TempBinding.controlBindings[index].keys = e.KeyData;

            var isDifferent =
                bindings.controlBindings.Count <= index ||
                m_TempBinding.controlBindings[index].keys != bindings.controlBindings[index].keys;

            senderTextBox.Text = e.KeyData.ToString();
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

            m_TempBinding.controlBindings[index].onHold = senderCheck.Checked;

            var isDifferent =
                bindings.controlBindings.Count <= index ||
                m_TempBinding.controlBindings[index].onHold != bindings.controlBindings[index].onHold;

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

            m_TempBinding.controlBindings[index].targeted = senderCheck.Checked;

            var isDifferent =
                bindings.controlBindings.Count <= index ||
                m_TempBinding.controlBindings[index].targeted != bindings.controlBindings[index].targeted;

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

            var bindingMode = (BindingMode)(1 << parentTable.GetColumn(senderCheckBox));
            m_TempBinding.controlBindings[index].bindingMode ^= bindingMode;

            var isDifferent =
                bindings.controlBindings.Count <= index ||
                (m_TempBinding.controlBindings[index].bindingMode & bindingMode) !=
                (bindings.controlBindings[index].bindingMode & bindingMode);

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

        private TableLayoutPanel CreateNewBinding(ControlBinding controlBinding)
        {
            var newPanel = new TableLayoutPanel
            {
                Name = "newPanel" + m_TableCount,
                Size = new Size(defaultPanel.Size.Width, defaultPanel.Size.Height),
                Location =
                    new Point(
                        defaultPanel.Location.X,
                        defaultPanel.Location.Y
                        + defaultPanel.Size.Height * m_TableCount
                        + defaultPanel.Margin.Bottom * m_TableCount * 2),
                BorderStyle = BorderStyle.FixedSingle
            };
            newPanel.RowStyles.Clear();
            foreach (RowStyle rowStyle in defaultPanel.RowStyles)
                newPanel.RowStyles.Add(new RowStyle(rowStyle.SizeType, rowStyle.Height));
            newPanel.ColumnStyles.Clear();
            foreach (ColumnStyle columnStyle in defaultPanel.ColumnStyles)
                newPanel.ColumnStyles.Add(new ColumnStyle(columnStyle.SizeType, columnStyle.Width));

            var newLabel = new Label
            {
                Text = @"Binding " + (m_TableCount + 1),
                AutoSize = defaultLabel.AutoSize,
                Dock = defaultLabel.Dock,
                TextAlign = defaultLabel.TextAlign
            };

            var newComboBox = new ComboBox
            {
                Name = "newComboBox" + m_TableCount,
                DropDownStyle = defaultComboBox.DropDownStyle,
                AutoSize = defaultComboBox.AutoSize,
                Dock = defaultComboBox.Dock
            };
            foreach (BindingType bindingType in Enum.GetValues(typeof(BindingType)))
                newComboBox.Items.Add(bindingType);
            newComboBox.SelectedItem = controlBinding.bindingType;
            newComboBox.SelectedIndexChanged += OnBindingTypeChanged;

            var newSpecialComboBox = new ComboBox
            {
                Name = "newComboBox" + m_TableCount,
                DropDownStyle = defaultComboBox.DropDownStyle,
                AutoSize = defaultComboBox.AutoSize,
                Dock = defaultComboBox.Dock,
                Visible = controlBinding.bindingType == BindingType.SpecialAction
            };
            foreach (SpecialAction value in Enum.GetValues(typeof(SpecialAction)))
                newSpecialComboBox.Items.Add(value);
            newSpecialComboBox.SelectedItem = controlBinding.specialAction;
            newSpecialComboBox.SelectedIndexChanged += OnSpecialActionChanged;

            var newMultilineBox = new TextBox
            {
                Name = "newMultilineBox" + m_TableCount,
                Text = controlBinding.script,
                AutoSize = defaultTextBox.AutoSize,
                Dock = defaultTextBox.Dock,
                Multiline = true,
                Visible = controlBinding.bindingType == BindingType.Script
            };
            newMultilineBox.TextChanged += OnScriptChanged;

            var newTextBox = new CustomTextBox
            {
                Name = "newTextBox" + m_TableCount,
                Text = controlBinding.keys.ToString(),
                AutoSize = defaultTextBox.AutoSize,
                Dock = defaultTextBox.Dock,
                ReadOnly = defaultTextBox.ReadOnly,
                Cursor = defaultTextBox.Cursor,
                Visible = controlBinding.bindingType == BindingType.Key,
                ContextMenu = new ContextMenu()
            };
            newTextBox.MouseDoubleClick += OnKeysTextBoxDoubleClick;
            newTextBox.MouseDown += OnKeysTextBoxMouseDown;
            newTextBox.KeyUp += OnKeysTextBoxKeyUp;

            var newHoldCheck = new CheckBox
            {
                Name = "newCheck" + m_TableCount,
                Text = defaultHeldCheck.Text,
                Checked = controlBinding.onHold
            };
            newHoldCheck.CheckStateChanged += OnHoldCheckChanged;

            var newTargetedCheck = new CheckBox
            {
                Name = "newCheck" + m_TableCount,
                Text = defaultTargetCheck.Text,
                Checked = controlBinding.targeted
            };
            newTargetedCheck.CheckStateChanged += OnTargetedCheckChanged;

            var newMoveCheck = new CheckBox
            {
                Name = "newMoveCheck" + m_TableCount,
                Text = defaultMoveRadio.Text,
                Checked = controlBinding.bindingMode == BindingMode.Move
            };
            newMoveCheck.CheckStateChanged += OnCheckModeChanged;
            var newPointerCheck = new CheckBox
            {
                Name = "newPointerCheck" + m_TableCount,
                Text = defaultPointerRadio.Text,
                Checked = controlBinding.bindingMode == BindingMode.Pointer
            };
            newPointerCheck.CheckStateChanged += OnCheckModeChanged;

            var newDelete = new Button
            {
                Name = "newDeleteButton" + m_TableCount,
                Text = defaultDelete.Text,
                Dock = defaultDelete.Dock
            };
            newDelete.Click += OnDeleteClick;

            newPanel.Controls.Add(newLabel, 0, 0);
            newPanel.Controls.Add(newComboBox, 0, 1);
            newPanel.Controls.Add(newSpecialComboBox, 0, 2);
            newPanel.Controls.Add(newMultilineBox, 0, 2);
            newPanel.Controls.Add(newTextBox, 0, 2);
            newPanel.Controls.Add(newHoldCheck, 0, 3);
            newPanel.Controls.Add(newTargetedCheck, 1, 3);
            newPanel.Controls.Add(newMoveCheck, 0, 4);
            newPanel.Controls.Add(newPointerCheck, 1, 4);
            newPanel.Controls.Add(newDelete, 0, 5);

            newPanel.SetColumnSpan(newLabel, 2);
            newPanel.SetColumnSpan(newComboBox, 2);
            newPanel.SetColumnSpan(newSpecialComboBox, 2);
            newPanel.SetColumnSpan(newMultilineBox, 2);
            newPanel.SetColumnSpan(newTextBox, 2);
            newPanel.SetColumnSpan(newDelete, 2);

            m_TableCount++;

            return newPanel;
        }

        private void CopyConfig(BindingConfig source, BindingConfig destination)
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

            destination.controlBindings.Clear();
            foreach (var sourceBinding in source.controlBindings)
            {
                destination.controlBindings.Add(
                    new ControlBinding
                    {
                        keys = sourceBinding.keys,
                        specialAction = sourceBinding.specialAction,
                        script = sourceBinding.script,

                        onHold = sourceBinding.onHold,
                        targeted = sourceBinding.targeted,
                        bindingMode = sourceBinding.bindingMode,
                        bindingType = sourceBinding.bindingType
                    });
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
                m_TempBinding = new BindingConfig();
        }
    }
}
