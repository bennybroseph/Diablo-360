using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Serialization;
using D360.Bindings;
using D360.SystemCode;

namespace D360
{
    public partial class D3BindingsForm : Form
    {
        public InputProcessor inputProcessor;

        private bool EditingBinding;

        private D3Bindings editedBindings;

        public D3BindingsForm()
        {
            InitializeComponent();

        }

        private void D3BindingsForm_Load(object sender, EventArgs e)
        {

        }

        private void bindingTextBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var senderTextBox = sender as TextBox;

            if (EditingBinding || senderTextBox == null)
                return;

            if (editedBindings == null)
                editedBindings = CopyBindings(inputProcessor.d3Bindings);

            EditingBinding = true;

            // Set the color to white to signify it's being edited
            senderTextBox.BackColor = Color.White;
            senderTextBox.ForeColor = Color.DodgerBlue;
            senderTextBox.Text = "<Press Any Key>";

            // Force Redraw
            Refresh();
        }

        private D3Bindings CopyBindings(D3Bindings d3Bindings)
        {
            var result = new D3Bindings
            {
                actionBarSkill1Key = d3Bindings.actionBarSkill1Key,
                actionBarSkill2Key = d3Bindings.actionBarSkill2Key,
                actionBarSkill3Key = d3Bindings.actionBarSkill3Key,
                actionBarSkill4Key = d3Bindings.actionBarSkill4Key,

                forceMoveKey = d3Bindings.forceMoveKey,
                forceStandStillKey = d3Bindings.forceStandStillKey,

                gameMenuKey = d3Bindings.gameMenuKey,

                inventoryKey = d3Bindings.inventoryKey,

                mapKey = d3Bindings.mapKey,

                potionKey = d3Bindings.potionKey,

                townPortalKey = d3Bindings.townPortalKey,

                worldMapKey = d3Bindings.worldMapKey
            };

            return result;
        }

        private void D3BindingsForm_KeyPress(object sender, KeyPressEventArgs e)
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

            EditingBinding = false;
            editedBindings = null;
        }

        private void D3BindingsForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (actionBarSkill1TextBox.BackColor == Color.White)
            {
                editedBindings.actionBarSkill1Key = e.KeyCode;
                actionBarSkill1TextBox.Text = editedBindings.actionBarSkill1Key.ToString();
                actionBarSkill1TextBox.BackColor = SystemColors.Control;
            }

            if (actionBarSkill2TextBox.BackColor == Color.White)
            {
                editedBindings.actionBarSkill2Key = e.KeyCode;
                actionBarSkill2TextBox.Text = editedBindings.actionBarSkill2Key.ToString();
                actionBarSkill2TextBox.BackColor = SystemColors.Control;
            }

            if (actionBarSkill3TextBox.BackColor == Color.White)
            {
                editedBindings.actionBarSkill3Key = e.KeyCode;
                actionBarSkill3TextBox.Text = editedBindings.actionBarSkill3Key.ToString();
                actionBarSkill3TextBox.BackColor = SystemColors.Control;
            }

            if (actionBarSkill4TextBox.BackColor == Color.White)
            {
                editedBindings.actionBarSkill4Key = e.KeyCode;
                actionBarSkill4TextBox.Text = editedBindings.actionBarSkill4Key.ToString();
                actionBarSkill4TextBox.BackColor = SystemColors.Control;
            }

            if (inventoryTextBox.BackColor == Color.White)
            {
                editedBindings.inventoryKey = e.KeyCode;
                inventoryTextBox.Text = editedBindings.inventoryKey.ToString();
                inventoryTextBox.BackColor = SystemColors.Control;
            }

            if (mapTextBox.BackColor == Color.White)
            {
                editedBindings.mapKey = e.KeyCode;
                mapTextBox.Text = editedBindings.mapKey.ToString();
                mapTextBox.BackColor = SystemColors.Control;
            }

            if (forceStandStillTextBox.BackColor == Color.White)
            {
                editedBindings.forceStandStillKey = e.KeyCode;
                forceStandStillTextBox.Text = editedBindings.forceStandStillKey.ToString();
                forceStandStillTextBox.BackColor = SystemColors.Control;
            }

            if (forceMoveTextBox.BackColor == Color.White)
            {
                editedBindings.forceMoveKey = e.KeyCode;
                forceMoveTextBox.Text = editedBindings.forceMoveKey.ToString();
                forceMoveTextBox.BackColor = SystemColors.Control;
            }

            if (potionTextBox.BackColor == Color.White)
            {
                editedBindings.potionKey = e.KeyCode;
                potionTextBox.Text = editedBindings.potionKey.ToString();
                potionTextBox.BackColor = SystemColors.Control;
            }

            if (townPortalTextBox.BackColor == Color.White)
            {
                editedBindings.townPortalKey = e.KeyCode;
                townPortalTextBox.Text = editedBindings.townPortalKey.ToString();
                townPortalTextBox.BackColor = SystemColors.Control;
            }

            if (gameMenuTextBox.BackColor == Color.White)
            {
                editedBindings.gameMenuKey = e.KeyCode;
                gameMenuTextBox.Text = editedBindings.gameMenuKey.ToString();
                gameMenuTextBox.BackColor = SystemColors.Control;
            }

            if (worldMapTextBox.BackColor == Color.White)
            {
                editedBindings.worldMapKey = e.KeyCode;
                worldMapTextBox.Text = editedBindings.worldMapKey.ToString();
                worldMapTextBox.BackColor = SystemColors.Control;
            }

            if (EditingBinding)
            {
                EditingBinding = false;
            }
        }

        private void D3BindingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            CancelEditing();
            Hide();
        }

        private void saveAndCloseButton_Click(object sender, EventArgs e)
        {
            if (editedBindings != null)
            {
                inputProcessor.d3Bindings = editedBindings;
                editedBindings = null;
            }
            SaveD3Bindings(inputProcessor.d3Bindings);

            Hide();
        }

        private void SaveD3Bindings(D3Bindings bindings)
        {
            var bindingsFileStream = new FileStream(Application.StartupPath + @"\D3Bindings.xml", FileMode.Create);
            var bindingsXMLSerializer = new XmlSerializer(typeof(D3Bindings));

            bindingsXMLSerializer.Serialize(bindingsFileStream, bindings);
            bindingsFileStream.Close();
        }

        private void D3BindingsForm_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible)
                return;

            actionBarSkill1TextBox.Text = inputProcessor.d3Bindings.actionBarSkill1Key.ToString();
            actionBarSkill2TextBox.Text = inputProcessor.d3Bindings.actionBarSkill2Key.ToString();
            actionBarSkill3TextBox.Text = inputProcessor.d3Bindings.actionBarSkill3Key.ToString();
            actionBarSkill4TextBox.Text = inputProcessor.d3Bindings.actionBarSkill4Key.ToString();

            inventoryTextBox.Text = inputProcessor.d3Bindings.inventoryKey.ToString();

            mapTextBox.Text = inputProcessor.d3Bindings.mapKey.ToString();

            forceStandStillTextBox.Text = inputProcessor.d3Bindings.forceStandStillKey.ToString();
            forceMoveTextBox.Text = inputProcessor.d3Bindings.forceMoveKey.ToString();

            potionTextBox.Text = inputProcessor.d3Bindings.potionKey.ToString();

            townPortalTextBox.Text = inputProcessor.d3Bindings.townPortalKey.ToString();

            gameMenuTextBox.Text = inputProcessor.d3Bindings.gameMenuKey.ToString();

            worldMapTextBox.Text = inputProcessor.d3Bindings.worldMapKey.ToString();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            CancelEditing();
            Hide();
        }

        private void skillsTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void D3BindingsForm_Shown(object sender, EventArgs e)
        {
            editedBindings = CopyBindings(inputProcessor.d3Bindings);
            Refresh();
        }
    }
}
