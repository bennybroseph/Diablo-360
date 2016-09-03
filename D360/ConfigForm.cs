using System;
using System.Collections.Generic;
using System.Windows.Forms;
using D360.Types;
using D360.Utility;

namespace D360
{
    public partial class ConfigForm : Form
    {

        private BindingConfigForm m_BindingConfigForm;
        public InputManager inputManager;

        private Configuration m_TempConfig = new Configuration();

        private BindingMode m_OldMode;

        public ConfigForm()
        {
            InitializeComponent();

            defaultPanel.Hide();
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            if (m_TempConfig != null)
                inputManager.configuration = m_TempConfig;

            BinarySerializer.SaveObject(inputManager.configuration, "Config.dat");
            
            Hide();
        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            Hide();
        }

        private void OnEditClick(object sender, EventArgs e)
        {
            var senderButton = sender as Button;

            if (senderButton == null)
                return;

            m_BindingConfigForm?.Close();

            var control = GamePadUtility.ParseControl(senderButton.Name);

            m_BindingConfigForm = new BindingConfigForm
            {
                parentForm = this,
                bindings = m_TempConfig.bindingConfigs[control]
            };
            m_BindingConfigForm.Show();
        }

        private void OnVisibleChanged(object sender, EventArgs e)
        {
            if (!Visible)
            {
                inputManager.controllerState.currentMode = m_OldMode;
                m_BindingConfigForm?.Close();
            }
            else
            {
                m_OldMode = inputManager.controllerState.currentMode;
                inputManager.controllerState.currentMode = BindingMode.Config;
                BringToFront();
            }

        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            m_BindingConfigForm.Close();
            Hide();
        }

        private void OnShown(object sender, EventArgs e)
        {
            m_TempConfig.bindingConfigs =
                new Dictionary<GamePadControl, BindingConfig>(inputManager.configuration.bindingConfigs);

            Refresh();
        }

        private void OnMove(object sender, EventArgs e)
        {
            m_BindingConfigForm?.OnParentMove();
        }

        private void OnResize(object sender, EventArgs e)
        {
            if (m_BindingConfigForm != null)
                m_BindingConfigForm.WindowState = WindowState;
        }
    }
}
