
namespace D360.Controls
{
    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    using Types;

    public partial class ControllerButtonLabel : UserControl
    {
        [Description("The text of the label"), Category("Data")]
        public string Label
        {
            get => button.Text;
            set
            {
                button.Text = value;
                button.Name = value.Replace(" ", "");
            }
        }

        public ControllerButtonLabel()
        {
            InitializeComponent();
        }

        private void OnLoad(object sender, EventArgs e)
        {
            if (!(ParentForm is ConfigForm configForm))
                return;
            var control = GamePadUtility.ParseControl(button.Name);

            hotkeyLabel.Text = configForm.inputManager.configuration.bindingConfigs[control].ToString();
        }

        private void OnBindingConfigClosed(object sender, EventArgs e)
        {
            if (!(ParentForm is ConfigForm configForm))
                return;
            var control = GamePadUtility.ParseControl(button.Name);

            hotkeyLabel.Text = configForm.inputManager.configuration.bindingConfigs[control].ToString();
        }

        private void OnClick(object sender, EventArgs e)
        {
            if (!(ParentForm is ConfigForm configForm))
                return;

            var bindingConfigForm = configForm.CreateBindingConfigForm(button.Name);
            bindingConfigForm.ClosedEvent += OnBindingConfigClosed;
        }
    }
}