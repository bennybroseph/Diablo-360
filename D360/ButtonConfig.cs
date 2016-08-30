using System.Drawing;
using System.Windows.Forms;

namespace D360
{
    public partial class ButtonConfig : Form
    {
        public Form parentForm;
        private int m_TableCount; 

        public ButtonConfig()
        {
            InitializeComponent();
            defaultPanel.Hide();

            Controls.Add(CreateNewBinding());
            Controls.Add(CreateNewBinding());
        }

        private void OnShow(object sender, System.EventArgs e)
        {

        }

        private void OnLoad(object sender, System.EventArgs e)
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

        private TableLayoutPanel CreateNewBinding()
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
                Text = defaultBinding.Text,
                AutoSize = defaultBinding.AutoSize,
                Dock = defaultBinding.Dock,
                ReadOnly = defaultBinding.ReadOnly,
                Cursor = defaultBinding.Cursor
            };
            var newCheck = new CheckBox
            {
                Text = defaultHeldCheck.Text
            };
            var newPointerRadio = new RadioButton
            {
                Text = defaultPointerRadio.Text,
                Checked = true
            };
            var newMoveRadio = new RadioButton
            {
                Text = defaultMoveRadio.Text
            };
            var newDelete = new Button
            {
                Text = defaultDelete.Text,
                Dock = defaultDelete.Dock
            };

            newPanel.Controls.Add(newLabel, 0, 0);
            newPanel.Controls.Add(newTextBox, 0, 1);
            newPanel.Controls.Add(newCheck, 0, 2);
            newPanel.Controls.Add(newPointerRadio, 0, 3);
            newPanel.Controls.Add(newMoveRadio, 1, 3);
            newPanel.Controls.Add(newDelete, 0, 4);

            newPanel.SetColumnSpan(newLabel, 2);
            newPanel.SetColumnSpan(newTextBox, 2);
            newPanel.SetColumnSpan(newDelete, 2);

            Size =
                new Size(
                    Size.Width,
                    Size.Height
                    + defaultPanel.Size.Height * m_TableCount
                    + defaultPanel.Margin.Bottom * m_TableCount * 2);

            m_TableCount++;
            return newPanel;
        }
    }
}
