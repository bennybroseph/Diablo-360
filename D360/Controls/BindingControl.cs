
namespace D360.Controls
{
    using Controller;
    using System;
    using System.Windows.Forms;

    using Control = System.Windows.Forms.Control;
    using Binding = Controller.Binding;

    public partial class BindingControl : UserControl
    {
        private Binding m_Binding;

        private class BindingTypeWrapper
        {
            public Type type { get; set; }
            public string displayName { get; set; }
        }

        public BindingControl(Binding pBinding)
        {
            InitializeComponent();

            m_Binding = pBinding;

            var bindingTypes =
                new []
                {
                    new BindingTypeWrapper{displayName = "Key", type = typeof(KeyBinding)},
                    new BindingTypeWrapper{displayName = "Special", type = typeof(SpecialBinding)},
                    new BindingTypeWrapper{displayName = "Script", type = typeof(ScriptBinding)},
                };
            bindingTypeComboBox.DataSource = bindingTypes;

            bindingTypeComboBox.DisplayMember = "displayName";
            bindingTypeComboBox.ValueMember = "type";

            var matchingIndex = 0;
            for (var i = 0; i < bindingTypeComboBox.Items.Count; i++)
            {
                var item = (BindingTypeWrapper)bindingTypeComboBox.Items[i];
                if (item.type == m_Binding.GetType())
                    matchingIndex = i;
            }

            bindingTypeComboBox.SelectedIndex = matchingIndex;

            foreach (var inputMode in Enum.GetValues(typeof(InputMode)))
                inputModeComboBox.Items.Add(inputMode);

            inputModeComboBox.Items.Remove(InputMode.Config);

            inputModeComboBox.SelectedItem = m_Binding.inputMode;

            isHoldActionCheckBox.Checked = m_Binding.isHoldAction;
            isTargetedActionCheckBox.Checked = m_Binding.isTargetedAction;

            Control newControl = new Control();
            if (m_Binding.GetType() == typeof(KeyBinding))
            {
                var keyBinding = m_Binding as KeyBinding;
                newControl =
                    new CustomTextBox
                    {
                        Text = keyBinding.keys.ToString(),
                        Dock = DockStyle.Fill,
                        ReadOnly = true,
                        ContextMenu = new ContextMenu(),
                    };
                tableLayoutPanel1.Controls.Add(newControl, 0, 2);
            }
            else if (m_Binding.GetType() == typeof(SpecialBinding))
            {
                var specialBinding = m_Binding as SpecialBinding;
                newControl =
                    new ComboBox
                    {
                        Text = "Special Text Here",
                        Dock = DockStyle.Fill,
                        DropDownStyle = ComboBoxStyle.DropDownList,
                    };
            }
            else if (m_Binding.GetType() == typeof(ScriptBinding))
            {
                var scriptBinding = m_Binding as ScriptBinding;
                newControl =
                    new TextBox
                    {
                        Text = scriptBinding.script,
                        Dock = DockStyle.Fill,
                        Multiline = true,

                    };
            }
            tableLayoutPanel1.Controls.Add(newControl, 0, 2);
            tableLayoutPanel1.SetColumnSpan(newControl, 2);
        }
    }
}
