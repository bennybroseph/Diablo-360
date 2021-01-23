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
    using Controller;

    public partial class ConfigForm : Form
    {
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                var myCp = base.CreateParams;
                myCp.ClassStyle |= CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private BindingConfigForm m_BindingConfigForm;

        private Configuration m_TempConfig = new Configuration();

        private InputMode m_OldMode;

        public ConfigForm()
        {
            InitializeComponent();

            cursorSlider.TrackBarChanged += OnRadiusTrackBarChanged;
            cursorSlider.CheckChanged += OnMaxCheckChanged;

            targetSlider.TrackBarChanged += OnRadiusTrackBarChanged;
            targetSlider.CheckChanged += OnMaxCheckChanged;
        }

        public BindingConfigForm CreateBindingConfigForm(string button)
        {
            m_BindingConfigForm?.Close();

            //var control = GamePadUtility.ParseControl(button);

            m_BindingConfigForm = new BindingConfigForm
            {
                parentForm = this,
                //bindings = m_TempConfig.bindingConfigs[control]
            };
            m_BindingConfigForm.Show();

            return m_BindingConfigForm;
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            CopyConfig(m_TempConfig, out Main.self.configuration);
            //inputManager.controllerState.centerOffset = inputManager.configuration.centerOffset;

            File.WriteAllText(
                "Config.json",
                JsonConvert.SerializeObject(
                    Main.self.configuration,
                    new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.All}));

            Hide();
        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            Hide();
        }

        private void OnRadiusTrackBarChanged(object sender, EventArgs e)
        {
            if (sender == cursorSlider)
            {
                m_TempConfig.cursorRadius = cursorSlider.Value / 100f;
                cursorSlider.Percent = cursorSlider.Value + @"%";
            }
            else if (sender == targetSlider)
            {
                m_TempConfig.targetRadius = targetSlider.Value / 100f;
                targetSlider.Percent = targetSlider.Value + @"%";
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
            if (sender == cursorSlider)
                m_TempConfig.cursorAlwaysMax = cursorSlider.Checked;
            else if (sender == targetSlider)
                m_TempConfig.targetAlwaysMax = targetSlider.Checked;
        }

        private void OnVisibleChanged(object sender, EventArgs e)
        {
            if (!Visible)
            {
                Main.self.controllerManager.currentMode = m_OldMode;
                m_BindingConfigForm?.Close();
            }
            else
            {
                m_OldMode = Main.self.controllerManager.currentMode;
                Main.self.controllerManager.currentMode = InputMode.Config;
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
            CopyConfig(Main.self.configuration, out m_TempConfig);

            cursorSlider.Value = (int) Math.Round(m_TempConfig.cursorRadius * 100);
            cursorSlider.Percent = cursorSlider.Value + @"%";
            cursorSlider.Checked = m_TempConfig.cursorAlwaysMax;

            targetSlider.Value = (int) Math.Round(m_TempConfig.targetRadius * 100);
            targetSlider.Percent = targetSlider.Value + @"%";
            targetSlider.Checked = m_TempConfig.targetAlwaysMax;

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
                bindingConfigs = new Dictionary<ControlIndex, ControlConfig>(source.bindingConfigs),

                holdTime = source.holdTime,
                vibrationTime = source.vibrationTime,

                centerOffset = source.centerOffset,

                cursorAlwaysMax = source.cursorAlwaysMax,
                cursorRadius = source.cursorRadius,

                targetAlwaysMax = source.targetAlwaysMax,
                targetRadius = source.targetRadius,
            };
        }
    }
}
