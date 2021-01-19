using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using D360.Types;
using D360.Utility;
using Newtonsoft.Json;

namespace D360
{
    using System.Runtime.InteropServices;

    public partial class ConfigForm : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private BindingConfigForm m_BindingConfigForm;
        public InputManager inputManager;

        private Configuration m_TempConfig = new Configuration();

        private BindingMode m_OldMode;

        public ConfigForm()
        {
            InitializeComponent();
        }

        public void CreateBindingConfigForm(Button button)
        {
            m_BindingConfigForm?.Close();

            var control = GamePadUtility.ParseControl(button.Name);

            m_BindingConfigForm = new BindingConfigForm
            {
                parentForm = this,
                bindings = m_TempConfig.bindingConfigs[control]
            };
            m_BindingConfigForm.Show();
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            CopyConfig(m_TempConfig, out inputManager.configuration);
            inputManager.controllerState.centerOffset = inputManager.configuration.centerOffset;

            File.WriteAllText(
                "Config.json",
                JsonConvert.SerializeObject(
                    inputManager.configuration,
                    new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All}));

            Hide();
        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            Hide();
        }

        private void OnEditClick(object sender, EventArgs e)
        {
            if (!(sender is Button senderButton))
                return;

            CreateBindingConfigForm(senderButton);
        }

        private void OnRadiusTrackBarChanged(object sender, EventArgs e)
        {
            if (sender == cursorTrackBar)
            {
                m_TempConfig.cursorRadius = cursorTrackBar.Value / 100f;
                cursorValueLabel.Text = cursorTrackBar.Value + @"%";
            }
            else if (sender == targetTrackBar)
            {
                m_TempConfig.targetRadius = targetTrackBar.Value / 100f;
                targetValueLabel.Text = targetTrackBar.Value + @"%";
            }
        }

        private void OnOffsetValueChanged(object sender, EventArgs e)
        {
            if (sender == offsetXValue)
                m_TempConfig.centerOffset.X = (float) offsetXValue.Value;
            if (sender == offsetYValue)
                m_TempConfig.centerOffset.Y = (float) offsetYValue.Value;
        }

        private void OnMaxCheckChanged(object sender, EventArgs e)
        {
            if (sender == cursorMaxCheck)
                m_TempConfig.cursorAlwaysMax = cursorMaxCheck.Checked;
            else if (sender == targetMaxCheck)
                m_TempConfig.targetAlwaysMax = targetMaxCheck.Checked;
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
            //e.Cancel = true;

            m_BindingConfigForm?.Close();
            //Hide();
        }

        private void OnShown(object sender, EventArgs e)
        {
            CopyConfig(inputManager.configuration, out m_TempConfig);

            cursorTrackBar.Value = (int) Math.Round(m_TempConfig.cursorRadius * 100);
            cursorValueLabel.Text = cursorTrackBar.Value + @"%";
            cursorMaxCheck.Checked = m_TempConfig.cursorAlwaysMax;

            targetTrackBar.Value = (int) Math.Round(m_TempConfig.targetRadius * 100);
            targetValueLabel.Text = targetTrackBar.Value + @"%";
            targetMaxCheck.Checked = m_TempConfig.targetAlwaysMax;

            offsetXValue.Value = (decimal) m_TempConfig.centerOffset.X;
            offsetYValue.Value = (decimal) m_TempConfig.centerOffset.Y;

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

        private void CopyConfig(Configuration source, out Configuration destination)
        {
            destination = new Configuration
            {
                bindingConfigs = new Dictionary<GamePadControl, BindingConfig>(source.bindingConfigs),

                holdTime = source.holdTime,
                vibrationTime = source.vibrationTime,

                centerOffset = source.centerOffset,

                cursorAlwaysMax = source.cursorAlwaysMax,
                cursorRadius = source.cursorRadius,

                targetAlwaysMax = source.targetAlwaysMax,
                targetRadius = source.targetRadius,
            };
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
