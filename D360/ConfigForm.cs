using System;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using System.Xml.Serialization;
using D360.Bindings;
using D360.SystemCode;
using Action = D360.Bindings.Action;

namespace D360
{
    public partial class ConfigForm : Form
    {
        public InputProcessor inputProcessor;

        private bool EditingConfig;

        private Configuration editedConfig;

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
            if (editedConfig != null)
            {

                inputProcessor.config = editedConfig;
                editedConfig = null;
            }

            EditingConfig = false;

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
            Configuration resultConfig = new Configuration();
            resultConfig.leftTriggerBinding = config.leftTriggerBinding;
            resultConfig.rightTriggerBinding = config.rightTriggerBinding;

            return resultConfig;

        }

        private void CancelEditing()
        {
            EditingConfig = false;
            editedConfig = null;
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
                EditingConfig = true;

                if (editedConfig == null)
                {
                    editedConfig = copyConfig(inputProcessor.config);
                }

                editedConfig.leftTriggerBinding = (LeftTriggerComboBox.SelectedItem as string).ParseAction();
            }
        }

        private void RightTriggerComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RightTriggerComboBox.SelectedItem != null)
            {
                EditingConfig = true;

                if (editedConfig == null)
                {
                    editedConfig = copyConfig(inputProcessor.config);
                }

                editedConfig.rightTriggerBinding = (RightTriggerComboBox.SelectedItem as string).ParseAction();
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
