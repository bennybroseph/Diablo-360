using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using D360.SystemCode;
using D360.Types;

using Action = D360.Types.Action;

namespace D360
{
    public partial class ConfigForm : Form
    {
        public InputProcessor inputProcessor;

        private bool m_EditingConfig;

        private Configuration m_EditedConfig;

        public ConfigForm()
        {
            InitializeComponent();

            LeftTriggerComboBox.Items.Clear();
            RightTriggerComboBox.Items.Clear();

            foreach (Action name in Enum.GetValues(typeof(Action)))
            {
                LeftTriggerComboBox.Items.Add(name.ParseDisplayName());
                RightTriggerComboBox.Items.Add(name.ParseDisplayName());
            }
        }

        private void saveAndCloseButton_Click(object sender, EventArgs e)
        {
            if (m_EditedConfig != null)
            {

                inputProcessor.config = m_EditedConfig;
                m_EditedConfig = null;
            }

            m_EditingConfig = false;

            SaveConfig(inputProcessor.config);

            inputProcessor.loadChanges();

            Hide();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

            CancelEditing();
            Hide();
        }

        private Configuration copyConfig(Configuration config)
        {
            var resultConfig = new Configuration
            {
                leftTriggerBinding = config.leftTriggerBinding,
                rightTriggerBinding = config.rightTriggerBinding
            };

            return resultConfig;

        }

        private void CancelEditing()
        {
            m_EditingConfig = false;
            m_EditedConfig = null;
        }

        private void SaveConfig(Configuration configuration)
        {
            var configurationFileStream = new FileStream(Application.StartupPath + @"\Config.dat", FileMode.Create);
            var bindingsXMLSerializer = new BinaryFormatter();
            bindingsXMLSerializer.Serialize(configurationFileStream, configuration);
            configurationFileStream.Close();
        }

        private void LeftTriggerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (LeftTriggerComboBox.SelectedItem != null)
            {
                m_EditingConfig = true;

                if (m_EditedConfig == null)
                {
                    m_EditedConfig = copyConfig(inputProcessor.config);
                }

                m_EditedConfig.leftTriggerBinding = (LeftTriggerComboBox.SelectedItem as string).ParseAction();
            }
        }

        private void RightTriggerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RightTriggerComboBox.SelectedItem != null)
            {
                m_EditingConfig = true;

                if (m_EditedConfig == null)
                {
                    m_EditedConfig = copyConfig(inputProcessor.config);
                }

                m_EditedConfig.rightTriggerBinding = (RightTriggerComboBox.SelectedItem as string).ParseAction();
            }
        }

        private void ConfigForm_VisibleChanged(object sender, EventArgs e)
        {
            if (Visible)
            {
                LeftTriggerComboBox.SelectedIndex =
                    LeftTriggerComboBox.Items.IndexOf(inputProcessor.config.leftTriggerBinding.ParseDisplayName());
                RightTriggerComboBox.SelectedIndex =
                    RightTriggerComboBox.Items.IndexOf(inputProcessor.config.rightTriggerBinding.ParseDisplayName());
            }
        }

        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            CancelEditing();
            Hide();
        }
    }
}
