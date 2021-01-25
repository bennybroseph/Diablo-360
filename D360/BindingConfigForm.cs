using System;
using System.Drawing;

namespace D360
{
    using System.Diagnostics.Eventing.Reader;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
    using Controller;
    using Controls;
    using SharpDX;
    using Binding = Controller.Binding;
    using Color = System.Drawing.Color;
    using Point = System.Drawing.Point;
    using WinControl = System.Windows.Forms.Control;

    public sealed partial class BindingConfigForm : Form
    {
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);

        private const int WM_SETREDRAW = 11;

        public event EventHandler ClosedEvent;

        public Form parentForm;
        private int m_TableCount;

        private bool m_EditingConfig;
        private Keys m_PressedKeys;

        public ControlConfig bindings;
        private ControlConfig m_TempControlConfig;

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

        public BindingConfigForm(Form _parentForm, ControlConfig _controlConfig)
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            parentForm = _parentForm;
            bindings = _controlConfig;

            m_DefaultSize =
                    new Size(
                        Size.Width,
                        Size.Height
                        - defaultBindingControl.Size.Height
                        - defaultBindingControl.Margin.Bottom * 2);

            InitializeTempConfig();

            CopyConfig(bindings, m_TempControlConfig);
            UpdateBindingControls();

            ProperResize();

            var triggerBinding = m_TempControlConfig as TriggerConfig;
            var stickConfig = m_TempControlConfig as StickConfig;
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
            CopyConfig(m_TempControlConfig, bindings);

            changedControls = 0;

            foreach (WinControl control in otherTabPage.Controls)
                control.Text = control.Text.TrimEnd('*');

            foreach (var table in bindingsFlowLayoutPanel.Controls.OfType<TableLayoutPanel>())
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
            SuspendDrawing(this);

            AddNewBinding(new KeyBinding());
            ProperResize();

            ResumeDrawing(this);
        }

        private void OnBindingControlUpClick(object sender, EventArgs e)
        {

        }

        private void OnBindingControlDownClick(object sender, EventArgs e)
        {

        }

        private void OnDeleteClick(object sender, EventArgs e)
        {
            SuspendDrawing(this);

            if (sender is BindingControl bindingControl)
                RemoveBinding(bindingControl.binding);

            ProperResize();

            ResumeDrawing(this);
        }

        private void OnBindingTypeChanged(object sender, BindingTypeChangedArgs e)
        {
            if (!(sender is BindingControl bindingControl))
                return;

            var index = m_TempControlConfig.bindings.IndexOf(bindingControl.binding);
            if (e.newBindingType == typeof(KeyBinding))
                m_TempControlConfig.bindings[index] = new KeyBinding { keys = bindingControl.keyBindingKeys };
            else if (e.newBindingType == typeof(SpecialBinding))
                m_TempControlConfig.bindings[index] = new SpecialBinding();
            else if (e.newBindingType == typeof(ScriptBinding))
                m_TempControlConfig.bindings[index] = new ScriptBinding();

            bindingControl.binding = m_TempControlConfig.bindings[index];
        }

        private void OnScriptChanged(object sender, EventArgs e)
        {
            var senderTextBox = sender as TextBox;
            if (senderTextBox == null || senderTextBox.Multiline == false || !m_Initialized)
                return;

            var index =
                bindingsFlowLayoutPanel.Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<TextBox>().All(textBox => textBox != senderTextBox)).
                        Count() - 1;

            var scriptBinding = (ScriptBinding)bindings.bindings[index];
            var tempScriptBinding = (ScriptBinding)m_TempControlConfig.bindings[index];
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
                bindingsFlowLayoutPanel.Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<ComboBox>().
                    All(comboBox => comboBox != senderComboBox)).
                        Count() - 1;

            var scriptBinding = (SpecialBinding)bindings.bindings[index];
            var tempScriptBinding = (SpecialBinding)m_TempControlConfig.bindings[index];
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
                bindingsFlowLayoutPanel.Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<TextBox>().All(textBox => textBox != senderTextBox)).
                        Count() - 1;

            var parsedKeys = e.KeyData;
            if (m_PressedKeys != Keys.None)
                parsedKeys |= m_PressedKeys;

            var scriptBinding = (KeyBinding)bindings.bindings[index];
            var tempScriptBinding = (KeyBinding)m_TempControlConfig.bindings[index];
            tempScriptBinding.keys = parsedKeys;

            var isDifferent =
                bindings.bindings.Count <= index ||
                tempScriptBinding.keys != scriptBinding.keys;

            senderTextBox.Text = tempScriptBinding.keys.ToString();
            //senderTextBox.BackColor = defaultTextBox.BackColor;
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
                bindingsFlowLayoutPanel.Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<CheckBox>().All(checkBox => checkBox != senderCheck)).
                        Count() - 1;

            m_TempControlConfig.bindings[index].isHoldAction = senderCheck.Checked;

            var isDifferent =
                bindings.bindings.Count <= index ||
                m_TempControlConfig.bindings[index].isHoldAction != bindings.bindings[index].isHoldAction;

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
                bindingsFlowLayoutPanel.Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<CheckBox>().All(checkBox => checkBox != senderCheck)).
                        Count() - 1;

            m_TempControlConfig.bindings[index].isTargetedAction = senderCheck.Checked;

            var isDifferent =
                bindings.bindings.Count <= index ||
                m_TempControlConfig.bindings[index].isTargetedAction != bindings.bindings[index].isTargetedAction;

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
                bindingsFlowLayoutPanel.Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<CheckBox>().
                        All(radioButton => radioButton != senderCheckBox)).
                    Count() - 1;

            var bindingMode = (InputMode)(1 << parentTable.GetColumn(senderCheckBox));
            m_TempControlConfig.bindings[index].inputMode ^= bindingMode;

            var isDifferent =
                bindings.bindings.Count <= index ||
                (m_TempControlConfig.bindings[index].inputMode & bindingMode) !=
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
            var tempTriggerConfig = m_TempControlConfig as TriggerConfig;
            var tempStickConfig = m_TempControlConfig as StickConfig;
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
            var tempStickConfig = m_TempControlConfig as StickConfig;
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
            var tempStickConfig = m_TempControlConfig as StickConfig;
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
            var height =
                Math.Min(
                    m_DefaultSize.Height
                        + defaultBindingControl.Size.Height * m_TableCount
                        + defaultBindingControl.Margin.Bottom * m_TableCount * 2,
                    parentForm.Height);
            var width = height == parentForm.Height ? m_DefaultSize.Width + 20 : m_DefaultSize.Width;

            Size = new Size(width, height);

            var tables =
                bindingsFlowLayoutPanel.Controls.
                    OfType<BindingControl>().
                    Where(x => x.Name != "defaultBindingControl").ToArray();

            for (var i = 0; i < tables.Length; ++i)
            {
                tables[i].Name = @"Binding " + (i + 1);
                //tables[i].Location =
                //    new Point(
                //        defaultBindingControl.Location.X,
                //        defaultBindingControl.Location.Y
                //        + defaultBindingControl.Size.Height * i
                //        + defaultBindingControl.Margin.Bottom * i * 2);
            }

            Refresh();
        }

        private void UpdateBindingControls()
        {
            var bindingControls =
                bindingsFlowLayoutPanel.Controls.
                    OfType<BindingControl>().
                    Where(x => x.Name != "defaultBindingControl").ToList();

            foreach (var bindingControl in bindingControls)
                RemoveBindingControl(bindingControl);

            foreach (var tempBinding in m_TempControlConfig.bindings)
                AddNewBindingControl(tempBinding);

            ProperResize();
        }

        private void AddNewBinding(Binding binding)
        {
            m_TempControlConfig.bindings.Add(binding);
            AddNewBindingControl(binding);
        }
        private void AddNewBindingControl(Binding binding)
        {
            var newBindingControl = new BindingControl(binding);

            newBindingControl.deleteClick += OnDeleteClick;

            newBindingControl.upClick += OnBindingControlUpClick;
            newBindingControl.downClick += OnBindingControlDownClick;

            newBindingControl.bindingTypeChangedEvent += OnBindingTypeChanged;

            bindingsFlowLayoutPanel.Controls.Add(newBindingControl);

            ++m_TableCount;
        }

        private void RemoveBinding(Binding binding)
        {
            m_TempControlConfig.bindings.Remove(binding);
            RemoveBindingControl(
                bindingsFlowLayoutPanel.Controls.
                    OfType<BindingControl>().
                    First(x => x.binding == binding));
        }
        private void RemoveBindingControl(BindingControl bindingControl)
        {
            --m_TableCount;
            bindingsFlowLayoutPanel.Controls.Remove(bindingControl);
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
                destination.bindings.Add(sourceBinding.Clone());
        }
        private void InitializeTempConfig()
        {
            var triggerBinding = bindings as TriggerConfig;
            var stickConfig = bindings as StickConfig;

            if (triggerBinding != null)
                m_TempControlConfig = new TriggerConfig();
            else if (stickConfig != null)
                m_TempControlConfig = new StickConfig();
            else
                m_TempControlConfig = new ControlConfig();
        }

        private void OnClosed(object sender, FormClosedEventArgs e)
        {
            ClosedEvent?.Invoke(this, e);
        }

        public static void SuspendDrawing(WinControl parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, false, 0);
        }

        public static void ResumeDrawing(WinControl parent)
        {
            SendMessage(parent.Handle, WM_SETREDRAW, true, 0);
            parent.Refresh();
        }
    }

    public sealed class DoubleBufferedFlowLayoutPanel : FlowLayoutPanel
    {
        public DoubleBufferedFlowLayoutPanel()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            Scroll += (sender, args) => Refresh();
        }
    }
}
