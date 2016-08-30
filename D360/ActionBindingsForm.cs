using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;
using D360.Bindings;
using D360.Utility;
using D360.Types;

using Action = D360.Types.Action;

namespace D360
{
    public partial class ActionBindingsForm : Form
    {
        private class BindingGUI
        {
            public TextBox textBox;
            public Label label;

            public Action action;
        }

        public InputProcessor inputProcessor;

        private readonly List<BindingGUI> m_BindingGuis = new List<BindingGUI>();

        private bool m_EditingBinding;
        private BindingGUI m_CurrentlyEditingBindingGui;

        private ActionBindings m_TempBindings = new ActionBindings();

        public ActionBindingsForm()
        {
            InitializeComponent();
        }

        private void OnTextBoxMouseDoubleClick(object sender, MouseEventArgs e)
        {
            var senderTextBox = sender as TextBox;

            if (m_EditingBinding || senderTextBox == null)
                return;

            m_EditingBinding = true;

            // Set the color and text to signify it's being edited to the user
            senderTextBox.BackColor = Color.White;
            senderTextBox.ForeColor = Color.DodgerBlue;
            senderTextBox.Text = @"<Press Any Key>";

            foreach (var bindingGUI in m_BindingGuis)
                if (bindingGUI.textBox == senderTextBox)
                    m_CurrentlyEditingBindingGui = bindingGUI;

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

            m_EditingBinding = false;
            m_TempBindings = null;
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            if (!m_EditingBinding)
                return;

            var action = m_CurrentlyEditingBindingGui.action;

            m_TempBindings.bindings[action] = e.KeyData;
            m_CurrentlyEditingBindingGui.textBox.Text = e.KeyData.ToString();
            m_CurrentlyEditingBindingGui.textBox.BackColor = SystemColors.Control;
            m_CurrentlyEditingBindingGui.textBox.ForeColor =
                m_TempBindings.bindings[action] ==
                inputProcessor.actionBindings.bindings[action]
                ? SystemColors.ControlText : Color.DodgerBlue;

            m_EditingBinding = false;
        }

        private void OnFormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            CancelEditing();
            Hide();
        }

        private void OnSaveAndCloseButtonClick(object sender, EventArgs e)
        {
            if (m_TempBindings != null)
            {
                inputProcessor.actionBindings = m_TempBindings;
                m_TempBindings = null;
            }
            SaveActionBindings(inputProcessor.actionBindings);

            Hide();
        }

        private void SaveActionBindings(ActionBindings bindings)
        {
            var bindingsFileStream = new FileStream(Application.StartupPath + @"\ActionBindings.dat", FileMode.Create);
            var bindingsBinaryFormatter = new BinaryFormatter();

            bindingsBinaryFormatter.Serialize(bindingsFileStream, bindings);
            bindingsFileStream.Close();
        }

        private void OnVisibleChanged(object sender, EventArgs e)
        {
            if (!Visible || m_BindingGuis.Count != inputProcessor.actionBindings.bindings.Count)
                return;

            var i = 0;
            foreach (var pair in inputProcessor.actionBindings.bindings)
            {
                m_BindingGuis[i].textBox.Text = Enum.GetName(typeof(Keys), pair.Value);
                m_BindingGuis[i].label.Text = pair.Key.ParseDisplayName();

                ++i;
            }
        }

        private void OnCancelButtonClick(object sender, EventArgs e)
        {
            CancelEditing();
            Hide();
        }

        private void OnShown(object sender, EventArgs e)
        {
            m_TempBindings.bindings = new Dictionary<Action, Keys>(inputProcessor.actionBindings.bindings);
            var i = 0;
            foreach (var pair in inputProcessor.actionBindings.bindings)
            {
                var bindingGUI = new BindingGUI
                {
                    textBox = new CustomTextBox(),
                    label = new Label(),
                    action = pair.Key
                };

                bindingGUI.textBox.Text = Enum.GetName(typeof(Keys), pair.Value);
                bindingGUI.textBox.Size = new Size(defaultTextBox.Width, defaultTextBox.Height);
                bindingGUI.textBox.Anchor = defaultTextBox.Anchor;
                bindingGUI.textBox.Location =
                    new Point(
                        defaultTextBox.Location.X,
                        defaultTextBox.Location.Y + (defaultTextBox.Size.Height + defaultTextBox.Location.Y) * i);

                bindingGUI.textBox.MouseDoubleClick += OnTextBoxMouseDoubleClick;

                bindingGUI.label.Text = pair.Key.ParseDisplayName();
                bindingGUI.label.TextAlign = defaultLabel.TextAlign;
                bindingGUI.label.Size = new Size(defaultLabel.Width, defaultLabel.Height);
                bindingGUI.label.Anchor = defaultLabel.Anchor;
                bindingGUI.label.Location =
                    new Point(
                        defaultLabel.Location.X,
                        bindingGUI.textBox.Location.Y);

                m_BindingGuis.Add(bindingGUI);

                Controls.Add(bindingGUI.textBox);
                Controls.Add(bindingGUI.label);

                ++i;
            }
            Size =
                new Size(
                    Size.Width,
                    (i + 3) * (defaultTextBox.Height + defaultTextBox.Location.Y) + defaultTextBox.Location.Y);

            defaultTextBox.Hide();
            defaultLabel.Hide();

            Refresh();
        }
    }

    public class CustomTextBox : TextBox
    {
        protected override bool IsInputKey(Keys keyData)
        {
            if (keyData == Keys.Tab)
                return true;

            return base.IsInputKey(keyData);
        }
    }
}
