using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using D360.Utility;

namespace D360
{
    public partial class BindingConfig : Form
    {
        public Form parentForm;
        private int m_TableCount;

        private bool m_EditingConfig;

        public Configuration.Binding binding;
        private Configuration.Binding m_TempBinding = new Configuration.Binding();

        private Size m_DefaultSize;

        private int m_ChangedControls;
        private int changedControls
        {
            get { return m_ChangedControls; }
            set
            {
                m_ChangedControls = value;
                SetSaveText();
            }
        }

        public BindingConfig()
        {
            InitializeComponent();
            defaultPanel.Hide();

            m_DefaultSize =
                new Size(
                    Size.Width,
                    Size.Height
                    - defaultPanel.Size.Height
                    - defaultPanel.Margin.Bottom * 2);
        }

        private void OnShow(object sender, EventArgs e)
        {
            m_TempBinding.bindings.Clear();
            foreach (var gamePadBinding in binding.bindings)
            {
                m_TempBinding.bindings.Add(
                    new Configuration.GamePadBinding
                    {
                        keys = gamePadBinding.keys,
                        onHold = gamePadBinding.onHold,
                        bindingMode = gamePadBinding.bindingMode
                    });
                Controls.Add(CreateNewBinding(gamePadBinding));
            }

            ProperResize();
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            binding.bindings.Clear();
            foreach (var gamePadBinding in m_TempBinding.bindings)
            {
                binding.bindings.Add(
                    new Configuration.GamePadBinding
                    {
                        keys = gamePadBinding.keys,
                        onHold = gamePadBinding.onHold,
                        bindingMode = gamePadBinding.bindingMode
                    });
            }

            changedControls = 0;

            foreach (var table in Controls.OfType<TableLayoutPanel>())
                foreach (var textBox in table.Controls.OfType<TextBox>())
                    textBox.ForeColor = defaultTextBox.ForeColor;

            Refresh();
        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void OnAddClick(object sender, EventArgs e)
        {
            var newBinding = new Configuration.GamePadBinding();
            m_TempBinding.bindings.Add(newBinding);
            Controls.Add(CreateNewBinding(newBinding));

            ProperResize();
        }

        private void OnDeleteClick(object sender, EventArgs e)
        {
            var senderButton = sender as Button;

            if (senderButton == null)
                return;

            var index =
                Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<Button>().All(button => button != senderButton)).
                        Count() - 1;

            m_TempBinding.bindings.RemoveAt(index);

            Controls.Remove(senderButton.Parent);
            --m_TableCount;

            ProperResize();
        }

        private void OnTextBoxDoubleClick(object sender, EventArgs e)
        {
            var senderTextBox = sender as TextBox;

            if (m_EditingConfig || senderTextBox == null)
                return;

            m_EditingConfig = true;

            // Set the color and text to signify it's being edited to the user
            senderTextBox.BackColor = Color.White;
            senderTextBox.ForeColor = Color.DodgerBlue;
            senderTextBox.Text = @"<Press Any Key>";

            // Force Redraw
            Refresh();
        }

        private void OnKeyUp(object sender, KeyEventArgs e)
        {
            var senderTextBox = sender as TextBox;

            if (!m_EditingConfig || senderTextBox == null)
                return;

            var index =
                Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<TextBox>().All(textBox => textBox != senderTextBox)).
                        Count() - 1;

            m_TempBinding.bindings[index].keys = e.KeyData;

            var isDifferent =
                binding.bindings.Count <= index || m_TempBinding.bindings[index].keys != binding.bindings[index].keys;

            senderTextBox.Text = e.KeyData.ToString();
            senderTextBox.BackColor = defaultTextBox.BackColor;
            senderTextBox.ForeColor = isDifferent ? Color.DodgerBlue : SystemColors.ControlText;

            if (isDifferent)
                changedControls++;
            else
                changedControls--;

            m_EditingConfig = false;

            Refresh();
        }

        private void OnCheckStateChanges(object sender, EventArgs e)
        {
            var senderCheck = sender as CheckBox;

            if (senderCheck == null)
                return;

            var index =
                Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<CheckBox>().All(checkBox => checkBox != senderCheck)).
                        Count() - 1;

            m_TempBinding.bindings[index].onHold = senderCheck.Checked;

            var isDifferent =
                binding.bindings.Count <= index || m_TempBinding.bindings[index].onHold != binding.bindings[index].onHold;

            senderCheck.Text = senderCheck.Text.TrimEnd('*');
            if (isDifferent)
            {
                senderCheck.Text += '*';
                changedControls++;
            }
            else
                changedControls--;

            Refresh();
        }

        private void OnRadioChanged(object sender, EventArgs e)
        {
            var senderRadio = sender as RadioButton;

            if (senderRadio == null || senderRadio.Checked)
                return;

            var parentTable = senderRadio.Parent as TableLayoutPanel;

            if (parentTable == null)
                return;

            var index =
                Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<RadioButton>().All(radioButton => radioButton != senderRadio)).
                        Count() - 1;

            m_TempBinding.bindings[index].bindingMode = (Configuration.BindingMode)parentTable.GetColumn(senderRadio) + 1;

            var isDifferent =
                binding.bindings.Count <= index ||
                m_TempBinding.bindings[index].bindingMode != binding.bindings[index].bindingMode;

            var panel =
                Controls.OfType<TableLayoutPanel>().ElementAt(index);

            var otherRadio = panel.Controls.OfType<RadioButton>().
                First(radio => radio != senderRadio);

            otherRadio.Text = otherRadio.Text.TrimEnd('*');
            if (isDifferent)
            {
                otherRadio.Text += '*';
                changedControls++;
            }
            else
            {
                changedControls--;
            }

            Refresh();
        }

        private void SetSaveText()
        {
            saveButton.Text = saveButton.Text.TrimEnd('*');
            if (m_ChangedControls > 0)
                saveButton.Text += '*';
        }

        private void OnLoad(object sender, EventArgs e)
        {
            AnchorToParent();
        }

        public void OnParentMove()
        {
            AnchorToParent();
        }

        private void AnchorToParent()
        {
            if (parentForm != null)
                Location = new Point(parentForm.Location.X + parentForm.Size.Width, parentForm.Location.Y);
        }

        private void ProperResize()
        {
            Size =
                new Size(
                    m_DefaultSize.Width,
                    m_DefaultSize.Height
                    + defaultPanel.Size.Height * m_TableCount
                    + defaultPanel.Margin.Bottom * m_TableCount * 2);

            var tables = Controls.OfType<TableLayoutPanel>().Where(x => x.Name != "defaultPanel").ToArray();
            for (var i = 0; i < tables.Length; ++i)
            {
                tables[i].Name = @"Binding " + (i + 1);
                tables[i].Location =
                    new Point(
                        defaultPanel.Location.X,
                        defaultPanel.Location.Y
                        + defaultPanel.Size.Height * i
                        + defaultPanel.Margin.Bottom * i * 2);
            }
        }

        private TableLayoutPanel CreateNewBinding(Configuration.GamePadBinding gamePadBinding)
        {
            var newPanel = new TableLayoutPanel
            {
                Name = "newPanel" + m_TableCount,
                Size = new Size(defaultPanel.Size.Width, defaultPanel.Size.Height),
                Location =
                    new Point(
                        defaultPanel.Location.X,
                        defaultPanel.Location.Y
                        + defaultPanel.Size.Height * m_TableCount
                        + defaultPanel.Margin.Bottom * m_TableCount * 2),
                BorderStyle = BorderStyle.FixedSingle
            };
            newPanel.RowStyles.Clear();
            foreach (RowStyle rowStyle in defaultPanel.RowStyles)
                newPanel.RowStyles.Add(new RowStyle(rowStyle.SizeType, rowStyle.Height));
            newPanel.ColumnStyles.Clear();
            foreach (ColumnStyle columnStyle in defaultPanel.ColumnStyles)
                newPanel.ColumnStyles.Add(new ColumnStyle(columnStyle.SizeType, columnStyle.Width));

            var newLabel = new Label
            {
                Text = @"Binding " + (m_TableCount + 1),
                AutoSize = defaultLabel.AutoSize,
                Dock = defaultLabel.Dock,
                TextAlign = defaultLabel.TextAlign
            };

            var newTextBox = new CustomTextBox
            {
                Name = "newTextBox" + m_TableCount,
                Text = gamePadBinding.keys.ToString(),
                AutoSize = defaultTextBox.AutoSize,
                Dock = defaultTextBox.Dock,
                ReadOnly = defaultTextBox.ReadOnly,
                Cursor = defaultTextBox.Cursor,
            };
            newTextBox.MouseDoubleClick += OnTextBoxDoubleClick;
            newTextBox.KeyUp += OnKeyUp;

            var newCheck = new CheckBox
            {
                Name = "newCheck" + m_TableCount,
                Text = defaultHeldCheck.Text,
                Checked = gamePadBinding.onHold
            };
            newCheck.CheckStateChanged += OnCheckStateChanges;

            var newMoveRadio = new RadioButton
            {
                Name = "newMoveRadio" + m_TableCount,
                Text = defaultMoveRadio.Text,
                Checked = gamePadBinding.bindingMode == Configuration.BindingMode.Move
            };
            newMoveRadio.CheckedChanged += OnRadioChanged;
            var newPointerRadio = new RadioButton
            {
                Name = "newPointerRadio" + m_TableCount,
                Text = defaultPointerRadio.Text,
                Checked = gamePadBinding.bindingMode == Configuration.BindingMode.Pointer
            };
            newPointerRadio.CheckedChanged += OnRadioChanged;

            var newDelete = new Button
            {
                Name = "newDeleteButton" + m_TableCount,
                Text = defaultDelete.Text,
                Dock = defaultDelete.Dock
            };
            newDelete.Click += OnDeleteClick;

            newPanel.Controls.Add(newLabel, 0, 0);
            newPanel.Controls.Add(newTextBox, 0, 1);
            newPanel.Controls.Add(newCheck, 0, 2);
            newPanel.Controls.Add(newMoveRadio, 0, 3);
            newPanel.Controls.Add(newPointerRadio, 1, 3);
            newPanel.Controls.Add(newDelete, 0, 4);

            newPanel.SetColumnSpan(newLabel, 2);
            newPanel.SetColumnSpan(newTextBox, 2);
            newPanel.SetColumnSpan(newDelete, 2);

            m_TableCount++;

            return newPanel;
        }
    }
}
