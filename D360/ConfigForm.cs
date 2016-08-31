using System;
using System.Collections.Generic;
using System.Windows.Forms;
using D360.Types;
using D360.Utility;

namespace D360
{
    public partial class ConfigForm : Form
    {

        private BindingConfig m_BindingConfig;
        public InputManager inputManager;


        private Configuration m_TempConfig = new Configuration();

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

            m_BindingConfig?.Close();

            var button = GamePadUtility.ParseButton<GamePadButton>(senderButton.Name);
            var dPadButton = GamePadUtility.ParseButton<GamePadDPadButton>(senderButton.Name);

            m_BindingConfig = new BindingConfig
            {
                parentForm = this,
                bindings =
                    button != GamePadButton.None ?
                        m_TempConfig.buttonBindings[button] :
                        m_TempConfig.dPadBindings[dPadButton]
            };
            m_BindingConfig.Show();
        }

        private void OnVisibleChanged(object sender, EventArgs e)
        {
            if (!Visible)
                m_BindingConfig?.Close();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;

            m_BindingConfig.Close();
            Hide();
        }

        private void OnShown(object sender, EventArgs e)
        {
            m_TempConfig.buttonBindings =
                new Dictionary<GamePadButton, List<ButtonBinding>>(inputManager.configuration.buttonBindings);

            Refresh();
        }

        private void OnMove(object sender, EventArgs e)
        {
            m_BindingConfig?.OnParentMove();
        }

        private void OnResize(object sender, EventArgs e)
        {
            if (m_BindingConfig != null)
                m_BindingConfig.WindowState = WindowState;
        }
    }
}
