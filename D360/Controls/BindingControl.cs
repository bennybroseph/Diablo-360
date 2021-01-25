
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

        public Binding binding;
        public Binding tempBinding;

        public BindingTypeChangedEventHandler bindingTypeChangedEvent;
        private readonly CustomTextBox m_KeyBindingTextBox;
        public Keys keyBindingKeys;

        private ComboBox specialComboBox;
        private TextBox scriptTextBox;

        private Keys m_PressedKeys;
        private bool m_EditingKeyBinding;

        public EventHandler upClick;
        public EventHandler downClick;

        public EventHandler deleteClick;

        public BindingControl()
        {
            InitializeComponent();
        }

        public BindingControl(Binding pBinding)
        {
            InitializeComponent();

            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            binding = pBinding;
            tempBinding = binding.Clone();

            m_KeyBindingTextBox =
                new CustomTextBox
                {
                    Text = tempBinding is KeyBinding keyBinding ? keyBinding.keys.ToString() : "",
                    Dock = DockStyle.Fill,
                    ReadOnly = true,
                    ContextMenu = new ContextMenu(),
                    Visible = tempBinding is KeyBinding,
                };
            m_KeyBindingTextBox.KeyDown += OnKeyBindingTextBoxKeyDown;
            m_KeyBindingTextBox.DoubleClick += OnKeyBindingTextBoxDoubleClick;
            m_KeyBindingTextBox.KeyUp += OnKeyBindingTextBoxKeyUp;
            m_KeyBindingTextBox.MouseDown += OnKeyBindingTextBoxMouseDown;

            tableLayoutPanel1.Controls.Add(m_KeyBindingTextBox, 0, 2);
            tableLayoutPanel1.SetColumnSpan(m_KeyBindingTextBox, 2);

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
                    Dock = DockStyle.Fill,
                    Multiline = true,
                    Visible = tempBinding is ScriptBinding,
                };
            tableLayoutPanel1.Controls.Add(scriptTextBox, 0, 2);
            tableLayoutPanel1.SetColumnSpan(scriptTextBox, 2);

            foreach (var comboBox in tableLayoutPanel1.Controls.OfType<ComboBox>())
                comboBox.MouseWheel += OnComboBoxMouseWheel;
        }

        private void OnLoad(object sender, EventArgs e)
        {
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

            foreach (var inputMode in Enum.GetValues(typeof(InputMode)))
                inputModeComboBox.Items.Add(inputMode);

            inputModeComboBox.Items.Remove(InputMode.Config);

            inputModeComboBox.SelectedItem = tempBinding.inputMode;

            isHoldActionCheckBox.Checked = tempBinding.isHoldAction;
            isTargetedActionCheckBox.Checked = tempBinding.isTargetedAction;
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

            m_KeyBindingTextBox.BackColor = Color.White;
            m_KeyBindingTextBox.ForeColor = Color.DodgerBlue;
            m_KeyBindingTextBox.Text = @"<Press Any Key>";

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
            if (!m_EditingKeyBinding || !(binding is KeyBinding keyBinding))
                return;

            keyBindingKeys = e.KeyData;
            if (m_PressedKeys != Keys.None)
                keyBindingKeys |= m_PressedKeys;

            keyBinding.keys = keyBindingKeys;

            m_KeyBindingTextBox.Text = keyBindingKeys.ToString();
            m_KeyBindingTextBox.BackColor = SystemColors.Control;
            m_KeyBindingTextBox.ForeColor = SystemColors.ControlText;

            m_EditingKeyBinding = false;

            Refresh();
        }

        private void OnBindingTypeChanged(object sender, EventArgs e)
        {
            m_KeyBindingTextBox.Visible = false;
            specialComboBox.Visible = false;
            scriptTextBox.Visible = false;

            if ((Type)bindingTypeComboBox.SelectedValue == typeof(KeyBinding))
                m_KeyBindingTextBox.Visible = true;
            else if ((Type)bindingTypeComboBox.SelectedValue == typeof(SpecialBinding))
                specialComboBox.Visible = true;
            else if ((Type)bindingTypeComboBox.SelectedValue == typeof(ScriptBinding))
                scriptTextBox.Visible = true;

            var eventArgs = new BindingTypeChangedArgs((Type)bindingTypeComboBox.SelectedValue);
            bindingTypeChangedEvent.Invoke(this, eventArgs);

            Refresh();
        }

        private void OnInputModeChanged(object sender, EventArgs e)
        {

        }

        private void OnHoldCheckChanged(object sender, EventArgs e)
        {

        }

        private void OnTargetedCheckChanged(object sender, EventArgs e)
        {

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
            GotFocus += OnGotFocus;
        }

        private void OnGotFocus(object sender, EventArgs e)
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
