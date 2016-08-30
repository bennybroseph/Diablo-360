using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using D360.Types;
using D360.Utility;
using Microsoft.Xna.Framework.Input;

using Keys = System.Windows.Forms.Keys;

namespace D360
{
    public partial class ConfigForm : Form
    {
        private class BindingGUI
        {
            public TableLayoutPanel panel;

            public TextBox textBox;
        }

        private BindingConfig m_BindingConfig;
        public InputManager inputManager;

        private bool m_EditingConfig;
        private BindingGUI m_CurrentlyEditingBindingGUI;

        private Configuration m_TempConfig = new Configuration();

        public ConfigForm()
        {
            InitializeComponent();

            defaultPanel.Hide();
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            if (m_TempConfig != null)
            {
                inputManager.configuration = m_TempConfig;
                m_TempConfig = null;
            }

            m_EditingConfig = false;

            BinarySerializer.SaveObject(inputManager.configuration, "Config.dat");

            Hide();
        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            CancelEditing();
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
                binding =
                    button != GamePadButton.None ?
                        m_TempConfig.buttonBindings[button] :
                        m_TempConfig.dPadBindings[dPadButton]
            };
            m_BindingConfig.Show();
        }

        private void CancelEditing()
        {
            foreach (Control control in Controls)
            {
                if (!(control is TextBox))
                    continue;

                var controlTextBox = control as TextBox;
                controlTextBox.BackColor = SystemColors.Control;
            }

            m_EditingConfig = false;
            m_TempConfig = null;
        }

        private void OnVisibleChanged(object sender, EventArgs e)
        {
            if (!Visible)
                return;

            m_BindingConfig?.Show();
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            CancelEditing();

            m_BindingConfig.Close();
            Hide();
        }

        private void OnShown(object sender, EventArgs e)
        {
            m_TempConfig.buttonBindings =
                new Dictionary<GamePadButton, Configuration.Binding>(inputManager.configuration.buttonBindings);

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
