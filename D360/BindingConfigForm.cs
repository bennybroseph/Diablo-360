using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using D360.Bindings;
using D360.Utility;

namespace D360
{
    public partial class BindingConfigForm : Form
    {
        public Form parentForm;
        private int m_TableCount;

        private bool m_EditingConfig;

        public BindingConfig bindings;
        private BindingConfig m_TempBinding = new BindingConfig();

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

        public BindingConfigForm()
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
            m_TempBinding.controlBindings.Clear();
            foreach (var binding in bindings.controlBindings)
            {
                m_TempBinding.controlBindings.Add(
                    new ControlBinding
                    {
                        keys = binding.keys,
                        script = binding.script,

                        onHold = binding.onHold,
                        bindingMode = binding.bindingMode,
                        bindingType = binding.bindingType
                    });
                bindingsTabPage.Controls.Add(CreateNewBinding(binding));
            }

            ProperResize();
        }

        private void OnSaveClick(object sender, EventArgs e)
        {
            bindings.controlBindings.Clear();
            foreach (var binding in m_TempBinding.controlBindings)
            {
                bindings.controlBindings.Add(
                    new ControlBinding
                    {
                        keys = binding.keys,
                        script = binding.script,

                        onHold = binding.onHold,
                        bindingMode = binding.bindingMode,
                        bindingType = binding.bindingType
                    });
            }

            changedControls = 0;

            foreach (var table in bindingsTabPage.Controls.OfType<TableLayoutPanel>())
                foreach (var textBox in table.Controls.OfType<Control>())
                {
                    if (textBox is TextBox)
                        textBox.ForeColor = defaultTextBox.ForeColor;

                    textBox.Text = textBox.Text.TrimEnd('*');
                }

            Refresh();
        }

        private void OnCancelClick(object sender, EventArgs e)
        {
            Close();
        }

        private void OnAddClick(object sender, EventArgs e)
        {
            var newBinding = new ControlBinding();
            m_TempBinding.controlBindings.Add(newBinding);
            bindingsTabPage.Controls.Add(CreateNewBinding(newBinding));

            ProperResize();
        }

        private void OnDeleteClick(object sender, EventArgs e)
        {
            var senderButton = sender as Button;

            if (senderButton == null)
                return;

            var index =
                bindingsTabPage.Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<Button>().All(button => button != senderButton)).
                        Count() - 1;

            m_TempBinding.controlBindings.RemoveAt(index);

            bindingsTabPage.Controls.Remove(senderButton.Parent);
            --m_TableCount;

            ProperResize();
        }

        private void OnBindingTypeChanged(object sender, EventArgs e)
        {
            var senderComboBox = sender as ComboBox;

            if (senderComboBox == null)
                return;

            var index =
                bindingsTabPage.Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<ComboBox>().
                    All(comboBox => comboBox != senderComboBox)).
                        Count() - 1;

            m_TempBinding.controlBindings[index].bindingType = (BindingType)senderComboBox.SelectedItem;

            var isDifferent = bindings.controlBindings.Count <= index ||
                m_TempBinding.controlBindings[index].bindingType != bindings.controlBindings[index].bindingType;

            if (isDifferent)
                changedControls++;
            else
                changedControls--;

            foreach (var table in bindingsTabPage.Controls.OfType<TableLayoutPanel>())
            {
                var textBox = table.Controls.OfType<TextBox>().FirstOrDefault(x => !x.Multiline);
                if (textBox != null)
                    textBox.Visible = m_TempBinding.controlBindings[index].bindingType == BindingType.Key;

                var multilineBox = table.Controls.OfType<TextBox>().FirstOrDefault(x => x.Multiline);
                if (multilineBox != null)
                    multilineBox.Visible = m_TempBinding.controlBindings[index].bindingType == BindingType.Script;

                var specialComboBox = table.Controls.OfType<ComboBox>().FirstOrDefault(x => table.GetRow(x) == 2);
                if (specialComboBox != null)
                    specialComboBox.Visible =
                        m_TempBinding.controlBindings[index].bindingType == BindingType.SpecialAction;
            }

            Refresh(); ;
        }

        private void OnScriptChanged(object sender, EventArgs e)
        {
            var senderTextBox = sender as TextBox;

            if (senderTextBox == null || senderTextBox.Multiline == false)
                return;

            var index =
                bindingsTabPage.Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<TextBox>().All(textBox => textBox != senderTextBox)).
                        Count() - 1;

            m_TempBinding.controlBindings[index].script = senderTextBox.Text;

            var isDifferent = bindings.controlBindings.Count <= index ||
                m_TempBinding.controlBindings[index].script != bindings.controlBindings[index].script;

            senderTextBox.ForeColor = isDifferent ? Color.DodgerBlue : SystemColors.ControlText;
            if (isDifferent)
                changedControls++;
            else
                changedControls--;

            Refresh();
        }

        private void OnKeysTextBoxDoubleClick(object sender, EventArgs e)
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

        private void OnKeysTextBoxKeyUp(object sender, KeyEventArgs e)
        {
            var senderTextBox = sender as TextBox;

            if (!m_EditingConfig || senderTextBox == null)
                return;

            var index =
                bindingsTabPage.Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<TextBox>().All(textBox => textBox != senderTextBox)).
                        Count() - 1;

            m_TempBinding.controlBindings[index].keys = e.KeyData;

            var isDifferent =
                bindings.controlBindings.Count <= index ||
                m_TempBinding.controlBindings[index].keys != bindings.controlBindings[index].keys;

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

        private void OnHoldCheckChanges(object sender, EventArgs e)
        {
            var senderCheck = sender as CheckBox;

            if (senderCheck == null)
                return;

            var index =
                bindingsTabPage.Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<CheckBox>().All(checkBox => checkBox != senderCheck)).
                        Count() - 1;

            m_TempBinding.controlBindings[index].onHold = senderCheck.Checked;

            var isDifferent =
                bindings.controlBindings.Count <= index ||
                m_TempBinding.controlBindings[index].onHold != bindings.controlBindings[index].onHold;

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

        private void OnCheckModeChanged(object sender, EventArgs e)
        {
            var senderCheckBox = sender as CheckBox;

            if (senderCheckBox == null)
                return;

            var parentTable = senderCheckBox.Parent as TableLayoutPanel;

            if (parentTable == null)
                return;

            var index =
                bindingsTabPage.Controls.OfType<TableLayoutPanel>().
                    TakeWhile(table => table.Controls.OfType<CheckBox>().
                        All(radioButton => radioButton != senderCheckBox)).
                    Count() - 1;

            var bindingMode = (BindingMode)(1 << parentTable.GetColumn(senderCheckBox));
            m_TempBinding.controlBindings[index].bindingMode ^= bindingMode;

            var isDifferent =
                bindings.controlBindings.Count <= index ||
                (m_TempBinding.controlBindings[index].bindingMode & bindingMode) !=
                (bindings.controlBindings[index].bindingMode & bindingMode);

            senderCheckBox.Text = senderCheckBox.Text.TrimEnd('*');
            if (isDifferent)
            {
                senderCheckBox.Text += '*';
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
            var sizeCoefficient = (m_TableCount >= 1) ? m_TableCount : 1;
            Size =
                new Size(
                    m_DefaultSize.Width,
                    m_DefaultSize.Height
                    + defaultPanel.Size.Height * sizeCoefficient
                    + defaultPanel.Margin.Bottom * sizeCoefficient * 2);

            var tables =
                bindingsTabPage.Controls.OfType<TableLayoutPanel>().Where(x => x.Name != "defaultPanel").ToArray();
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

        private TableLayoutPanel CreateNewBinding(ControlBinding controlBinding)
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

            var newComboBox = new ComboBox
            {
                Name = "newComboBox" + m_TableCount,
                DropDownStyle = defaultComboBox.DropDownStyle,
                AutoSize = defaultComboBox.AutoSize,
                Dock = defaultComboBox.Dock
            };
            foreach (BindingType bindingType in Enum.GetValues(typeof(BindingType)))
                newComboBox.Items.Add(bindingType);
            newComboBox.SelectedItem = controlBinding.bindingType;
            newComboBox.SelectedIndexChanged += OnBindingTypeChanged;

            var newSpecialComboBox = new ComboBox
            {
                Name = "newComboBox" + m_TableCount,
                DropDownStyle = defaultComboBox.DropDownStyle,
                AutoSize = defaultComboBox.AutoSize,
                Dock = defaultComboBox.Dock,
                Visible = controlBinding.bindingType == BindingType.SpecialAction
            };

            var newMultilineBox = new TextBox
            {
                Name = "newMultilineBox" + m_TableCount,
                Text = controlBinding.script,
                AutoSize = defaultTextBox.AutoSize,
                Dock = defaultTextBox.Dock,
                Multiline = true,
                Visible = controlBinding.bindingType == BindingType.Script
            };
            newMultilineBox.TextChanged += OnScriptChanged;

            var newTextBox = new CustomTextBox
            {
                Name = "newTextBox" + m_TableCount,
                Text = controlBinding.keys.ToString(),
                AutoSize = defaultTextBox.AutoSize,
                Dock = defaultTextBox.Dock,
                ReadOnly = defaultTextBox.ReadOnly,
                Cursor = defaultTextBox.Cursor,
                Visible = controlBinding.bindingType == BindingType.Key
            };
            newTextBox.MouseDoubleClick += OnKeysTextBoxDoubleClick;
            newTextBox.KeyUp += OnKeysTextBoxKeyUp;

            var newCheck = new CheckBox
            {
                Name = "newCheck" + m_TableCount,
                Text = defaultHeldCheck.Text,
                Checked = controlBinding.onHold
            };
            newCheck.CheckStateChanged += OnHoldCheckChanges;

            var newMoveCheck = new CheckBox
            {
                Name = "newMoveCheck" + m_TableCount,
                Text = defaultMoveRadio.Text,
                Checked = controlBinding.bindingMode == BindingMode.Move
            };
            newMoveCheck.CheckedChanged += OnCheckModeChanged;
            var newPointerCheck = new CheckBox
            {
                Name = "newPointerCheck" + m_TableCount,
                Text = defaultPointerRadio.Text,
                Checked = controlBinding.bindingMode == BindingMode.Pointer
            };
            newPointerCheck.CheckedChanged += OnCheckModeChanged;

            var newDelete = new Button
            {
                Name = "newDeleteButton" + m_TableCount,
                Text = defaultDelete.Text,
                Dock = defaultDelete.Dock
            };
            newDelete.Click += OnDeleteClick;

            newPanel.Controls.Add(newLabel, 0, 0);
            newPanel.Controls.Add(newComboBox, 0, 1);
            newPanel.Controls.Add(newSpecialComboBox, 0, 2);
            newPanel.Controls.Add(newMultilineBox, 0, 2);
            newPanel.Controls.Add(newTextBox, 0, 2);
            newPanel.Controls.Add(newCheck, 0, 3);
            newPanel.Controls.Add(newMoveCheck, 0, 4);
            newPanel.Controls.Add(newPointerCheck, 1, 4);
            newPanel.Controls.Add(newDelete, 0, 5);

            newPanel.SetColumnSpan(newLabel, 2);
            newPanel.SetColumnSpan(newComboBox, 2);
            newPanel.SetColumnSpan(newSpecialComboBox, 2);
            newPanel.SetColumnSpan(newMultilineBox, 2);
            newPanel.SetColumnSpan(newTextBox, 2);
            newPanel.SetColumnSpan(newDelete, 2);

            m_TableCount++;

            return newPanel;
        }
    }
}
