﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
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

        private ButtonConfig m_ButtonConfig;
        public InputProcessor inputProcessor;

        private bool m_EditingConfig;
        private BindingGUI m_CurrentlyEditingBindingGUI;

        private Configuration m_TempConfig = new Configuration();

        public ConfigForm()
        {
            InitializeComponent();

            defaultPanel.Hide();
        }

        private void saveAndCloseButton_Click(object sender, EventArgs e)
        {
            if (m_TempConfig != null)
            {
                inputProcessor.config = m_TempConfig;
                m_TempConfig = null;
            }

            m_EditingConfig = false;

            BinarySerializer.SaveObject(inputProcessor.config, "Config.dat");

            inputProcessor.loadChanges();

            Hide();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CancelEditing();
            Hide();
        }

        private void OnTextBoxMouseDoubleClick(object sender, MouseEventArgs e)
        {
            var senderTextBox = sender as TextBox;

            if (m_EditingConfig || senderTextBox == null)
                return;

            m_EditingConfig = true;

            // Set the color and text to signify it's being edited to the user
            senderTextBox.BackColor = Color.White;
            senderTextBox.ForeColor = Color.DodgerBlue;
            senderTextBox.Text = @"<Press Any Key>";

            var foundItem = false;
            foreach (var control in Controls.OfType<TableLayoutPanel>())
            {
                m_CurrentlyEditingBindingGUI = new BindingGUI { panel = control };
                foreach (var childControl in control.Controls.OfType<TextBox>())
                {
                    if (childControl != senderTextBox)
                        continue;

                    if (childControl.Name.Contains("Press"))
                    {
                        m_CurrentlyEditingBindingGUI.textBox = childControl;
                        foundItem = true;
                        break;
                    }
                    if (childControl.Name.Contains("Hold"))
                    {
                        m_CurrentlyEditingBindingGUI.textBox = childControl;
                        foundItem = true;
                        break;
                    }
                }
                if (foundItem)
                    break;
            }

            // Force Redraw
            Refresh();
        }

        private void OnKeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.F12)
            {
                CancelEditing();

                Hide();
                e.Handled = true;
                return;
            }

            e.Handled = true;
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

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (!m_EditingConfig)
                return;

            var buttons = m_CurrentlyEditingBindingGUI.panel.Name.ParseButtons();

            m_TempConfig.gamepadBindings[buttons] = e.KeyData;

            m_CurrentlyEditingBindingGUI.textBox.Text = e.KeyData.ToString();
            m_CurrentlyEditingBindingGUI.textBox.BackColor = SystemColors.Control;
            m_CurrentlyEditingBindingGUI.textBox.ForeColor =
                m_TempConfig.gamepadBindings[buttons] ==
                inputProcessor.config.gamepadBindings[buttons]
                ? SystemColors.ControlText : Color.DodgerBlue;

            m_EditingConfig = false;
        }

        private void ConfigForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible)
                return;

            foreach (var table in Controls.OfType<TableLayoutPanel>())
            {
                //foreach (Control control in table.Controls)
                //{
                //    if (control.GetType() == typeof(Label))
                //        control.Text = control.Name.ParseButtonsDisplayName();
                //    else
                //    {
                //        if (inputProcessor.config.gamepadBindings.ContainsKey(table.Name.ParseButtons()))
                //        {
                //            control.Text =
                //                inputProcessor.config.gamepadBindings[table.Name.ParseButtons()].ToString();
                //            control.MouseDoubleClick += OnTextBoxMouseDoubleClick;
                //            control.KeyUp += OnKeyUp;
                //        }
                //    }
                //}
            }
        }

        private void ConfigForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            CancelEditing();
            m_ButtonConfig.Hide();
            Hide();
        }

        private void OnShown(object sender, EventArgs e)
        {
            m_TempConfig.gamepadBindings = new Dictionary<Buttons, Keys>(inputProcessor.config.gamepadBindings);

            m_ButtonConfig = new ButtonConfig { parentForm = this };
            m_ButtonConfig.Show();

            Refresh();
        }

        private void OnMove(object sender, EventArgs e)
        {
            m_ButtonConfig?.OnParentMove();
        }

        private void OnResize(object sender, EventArgs e)
        {
            if (m_ButtonConfig != null)
                m_ButtonConfig.WindowState = WindowState;
        }
    }
}
