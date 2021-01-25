
namespace D360.Controls
{
    using Controller;
    using System;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    using Binding = Controller.Binding;



    public sealed partial class BindingControl : UserControl
    {
        private class BindingTypeWrapper
        {
            public Type type { get; set; }
            public string displayName { get; set; }
        }

        private enum CreationMethod
        {
            Designer,
            Program,
        }

        private CreationMethod m_CreationMethod;
        private bool m_Initialized;

        private Binding m_Binding;
        public Binding binding
        {
            get => m_Binding;
            set { m_Binding = value; CheckChangedValues(); }
        }
        public Binding tempBinding;

        public BindingTypeChangedEventHandler bindingTypeChangedEvent;
        public CustomTextBox keyBindingTextBox;

        private ComboBox specialComboBox;
        private TextBox scriptTextBox;

        private Keys m_PressedKeys;
        private bool m_EditingKeyBinding;

        public EventHandler upClick;
        public EventHandler downClick;

        public EventHandler deleteClick;

        public Action onValueChanged;
        public int valuesChanged;

        private Color m_AlteredColor = Color.DarkBlue;
        private FontStyle m_AlteredFontStyle = FontStyle.Bold;

        public BindingControl()
        {
            InitializeComponent();

            m_CreationMethod = CreationMethod.Designer;
        }

        public BindingControl(Binding _binding, Binding _tempBinding)
        {
            InitializeComponent();

            m_CreationMethod = CreationMethod.Program;

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            m_Binding = _binding;
            tempBinding = _tempBinding;

            keyBindingTextBox =
                new CustomTextBox
                {
                    Text = tempBinding is KeyBinding keyBinding ? keyBinding.keys.ToString() : "",
                    Dock = DockStyle.Fill,
                    ReadOnly = true,
                    ContextMenu = new ContextMenu(),
                    Visible = tempBinding is KeyBinding,
                };

            tableLayoutPanel1.Controls.Add(keyBindingTextBox, 0, 2);
            tableLayoutPanel1.SetColumnSpan(keyBindingTextBox, 2);

            specialComboBox =
                new ComboBox
                {
                    Text = "Special Text Here",
                    Dock = DockStyle.Fill,
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Visible = tempBinding is SpecialBinding,
                };
            tableLayoutPanel1.Controls.Add(specialComboBox, 0, 2);
            tableLayoutPanel1.SetColumnSpan(specialComboBox, 2);

            scriptTextBox =
                new TextBox
                {
                    Text = tempBinding is ScriptBinding scriptBinding ? scriptBinding.script : "",
                    Dock = DockStyle.Fill,
                    Multiline = true,
                    Visible = tempBinding is ScriptBinding,
                };
            tableLayoutPanel1.Controls.Add(scriptTextBox, 0, 2);
            tableLayoutPanel1.SetColumnSpan(scriptTextBox, 2);

            foreach (var inputMode in Enum.GetValues(typeof(InputMode)))
                inputModeComboBox.Items.Add(inputMode);

            inputModeComboBox.Items.Remove(InputMode.Config);
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (m_CreationMethod == CreationMethod.Designer)
                return;

            var bindingTypes =
                new[]
                {
                    new BindingTypeWrapper{displayName = "Key", type = typeof(KeyBinding)},
                    new BindingTypeWrapper{displayName = "Special", type = typeof(SpecialBinding)},
                    new BindingTypeWrapper{displayName = "Script", type = typeof(ScriptBinding)},
                };
            bindingTypeComboBox.DisplayMember = "displayName";
            bindingTypeComboBox.ValueMember = "type";

            bindingTypeComboBox.DataSource = bindingTypes;

            var matchingIndex = 0;
            for (var i = 0; i < bindingTypeComboBox.Items.Count; i++)
            {
                var item = (BindingTypeWrapper)bindingTypeComboBox.Items[i];
                if (item.type == tempBinding.GetType())
                    matchingIndex = i;
            }

            bindingTypeComboBox.SelectedIndex = matchingIndex;

            inputModeComboBox.SelectedItem = tempBinding.inputMode;

            isHoldActionCheckBox.Checked = tempBinding.isHoldAction;
            isTargetedActionCheckBox.Checked = tempBinding.isTargetedAction;

            keyBindingTextBox.KeyDown += OnKeyBindingTextBoxKeyDown;
            keyBindingTextBox.DoubleClick += OnKeyBindingTextBoxDoubleClick;
            keyBindingTextBox.KeyUp += OnKeyBindingTextBoxKeyUp;
            keyBindingTextBox.MouseDown += OnKeyBindingTextBoxMouseDown;

            foreach (var comboBox in tableLayoutPanel1.Controls.OfType<ComboBox>())
            {
                comboBox.DropDownClosed += ComboBoxOnDropDownClosed;
                comboBox.MouseWheel += OnComboBoxMouseWheel;
            }

            m_Initialized = true;
        }

        private void ComboBoxOnDropDownClosed(object sender, EventArgs e)
        {
            isHoldActionCheckBox.Focus();
        }

        private void OnComboBoxMouseWheel(object sender, MouseEventArgs e)
        {
            if (sender is ComboBox)
                ((HandledMouseEventArgs)e).Handled = true;
        }

        private void OnKeyBindingTextBoxDoubleClick(object sender, EventArgs e)
        {
            if (m_EditingKeyBinding)
                return;

            m_EditingKeyBinding = true;
            m_PressedKeys = Keys.None;

            keyBindingTextBox.BackColor = Color.White;
            keyBindingTextBox.ForeColor = Color.DodgerBlue;
            keyBindingTextBox.Text = @"<Press Any Key>";

            Refresh();
        }

        private void OnKeyBindingTextBoxKeyDown(object sender, KeyEventArgs e)
        {
            if (m_EditingKeyBinding)
                m_PressedKeys |= e.Modifiers;
        }

        private void OnKeyBindingTextBoxMouseDown(object sender, MouseEventArgs e)
        {
            if (!m_EditingKeyBinding)
                return;

            switch (e.Button)
            {
                case MouseButtons.Left:
                    OnKeyBindingTextBoxKeyUp(sender, new KeyEventArgs(Keys.LButton));
                    break;
                case MouseButtons.Right:
                    OnKeyBindingTextBoxKeyUp(sender, new KeyEventArgs(Keys.RButton));
                    break;
                case MouseButtons.Middle:
                    OnKeyBindingTextBoxKeyUp(sender, new KeyEventArgs(Keys.MButton));
                    break;

                case MouseButtons.XButton1:
                    OnKeyBindingTextBoxKeyUp(sender, new KeyEventArgs(Keys.XButton1));
                    break;
                case MouseButtons.XButton2:
                    OnKeyBindingTextBoxKeyUp(sender, new KeyEventArgs(Keys.XButton2));
                    break;
            }
        }

        private void OnKeyBindingTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            if (!m_EditingKeyBinding || !(tempBinding is KeyBinding keyBinding))
                return;

            var keyBindingKeys = e.KeyData;
            if (m_PressedKeys != Keys.None)
                keyBindingKeys |= m_PressedKeys;

            keyBinding.keys = keyBindingKeys;

            keyBindingTextBox.Text = keyBindingKeys.ToString();
            keyBindingTextBox.BackColor = SystemColors.Control;
            keyBindingTextBox.ForeColor = SystemColors.ControlText;

            m_EditingKeyBinding = false;

            CheckChangedValues();
            Refresh();
        }

        private void OnBindingTypeChanged(object sender, EventArgs e)
        {
            if (!m_Initialized)
                return;

            keyBindingTextBox.Visible = false;
            specialComboBox.Visible = false;
            scriptTextBox.Visible = false;

            if ((Type)bindingTypeComboBox.SelectedValue == typeof(KeyBinding))
                keyBindingTextBox.Visible = true;
            else if ((Type)bindingTypeComboBox.SelectedValue == typeof(SpecialBinding))
                specialComboBox.Visible = true;
            else if ((Type)bindingTypeComboBox.SelectedValue == typeof(ScriptBinding))
                scriptTextBox.Visible = true;

            var eventArgs = new BindingTypeChangedArgs((Type)bindingTypeComboBox.SelectedValue);
            bindingTypeChangedEvent?.Invoke(this, eventArgs);

            CheckChangedValues();
            Refresh();
        }

        private void OnInputModeChanged(object sender, EventArgs e)
        {
            if (!m_Initialized)
                return;

            tempBinding.inputMode = (InputMode)inputModeComboBox.SelectedItem;

            CheckChangedValues();
            Refresh();
        }

        private void OnHoldCheckChanged(object sender, EventArgs e)
        {
            if (!m_Initialized)
                return;

            tempBinding.isHoldAction = isHoldActionCheckBox.Checked;

            CheckChangedValues();
            Refresh();
        }

        private void OnTargetedCheckChanged(object sender, EventArgs e)
        {
            if (!m_Initialized)
                return;

            tempBinding.isTargetedAction = isTargetedActionCheckBox.Checked;

            CheckChangedValues();
            Refresh();
        }

        private void OnDeleteClick(object sender, EventArgs e)
        {
            deleteClick.Invoke(this, e);
        }

        private void OnUpClick(object sender, EventArgs e)
        {
            upClick.Invoke(this, e);
        }

        private void OnDownClick(object sender, EventArgs e)
        {
            downClick.Invoke(this, e);
        }

        private void CheckChangedValues()
        {
            valuesChanged = 0;

            if (m_Binding.GetType() != tempBinding.GetType())
            {
                bindingTypeComboBox.ForeColor = m_AlteredColor;
                bindingTypeComboBox.Font =
                    new Font(
                        bindingTypeComboBox.Font.FontFamily,
                        bindingTypeComboBox.Font.Size,
                        m_AlteredFontStyle);

                valuesChanged++;
            }
            else
            {
                bindingTypeComboBox.ResetForeColor();
                bindingTypeComboBox.ResetFont();
            }

            if (m_Binding is KeyBinding keyBinding && tempBinding is KeyBinding tempKeyBinding)
            {
                if (keyBinding.keys != tempKeyBinding.keys)
                {
                    keyBindingTextBox.ForeColor = m_AlteredColor;
                    keyBindingTextBox.Font =
                        new Font(
                            keyBindingTextBox.Font.FontFamily,
                            keyBindingTextBox.Font.Size,
                            m_AlteredFontStyle);

                    valuesChanged++;
                }
                else
                {
                    keyBindingTextBox.ResetForeColor();
                    keyBindingTextBox.ResetFont();
                }
            }

            if (m_Binding.inputMode != tempBinding.inputMode)
            {
                inputModeComboBox.ForeColor = m_AlteredColor;
                inputModeComboBox.Font =
                    new Font(
                        inputModeComboBox.Font.FontFamily,
                        inputModeComboBox.Font.Size,
                        m_AlteredFontStyle);

                valuesChanged++;
            }
            else
            {
                inputModeComboBox.ResetForeColor();
                inputModeComboBox.ResetFont();
            }

            if (m_Binding.isHoldAction != isHoldActionCheckBox.Checked)
            {
                isHoldActionCheckBox.ForeColor = m_AlteredColor;
                isHoldActionCheckBox.Font =
                    new Font(
                        isHoldActionCheckBox.Font.FontFamily,
                        isHoldActionCheckBox.Font.Size,
                        m_AlteredFontStyle);

                valuesChanged++;
            }
            else
            {
                isHoldActionCheckBox.ResetForeColor();
                isHoldActionCheckBox.ResetFont();
            }

            if (m_Binding.isTargetedAction != isTargetedActionCheckBox.Checked)
            {
                isTargetedActionCheckBox.ForeColor = m_AlteredColor;
                isTargetedActionCheckBox.Font =
                    new Font(
                        isTargetedActionCheckBox.Font.FontFamily,
                        isTargetedActionCheckBox.Font.Size,
                        m_AlteredFontStyle);

                valuesChanged++;
            }
            else
            {
                isTargetedActionCheckBox.ResetForeColor();
                isTargetedActionCheckBox.ResetFont();
            }

            onValueChanged.Invoke();
        }
    }

    public delegate void BindingTypeChangedEventHandler(object sender, BindingTypeChangedArgs e);
    public class BindingTypeChangedArgs : EventArgs
    {
        public Type newBindingType;

        public BindingTypeChangedArgs(Type _newBindingType)
        {
            newBindingType = _newBindingType;
        }
    }

    public sealed class CustomTextBox : TextBox
    {
        [DllImport("user32.dll")]
        private static extern bool HideCaret(IntPtr hWnd);

        public CustomTextBox()
        {
            Cursor = Cursors.Arrow;
            GotFocus += NeedCaretHide;
            FontChanged += NeedCaretHide;
        }

        private void NeedCaretHide(object sender, EventArgs e)
        {
            HideCaret(Handle);
        }

        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Tab)
                return true;

            return base.IsInputKey(keyData);
        }
    }
}
