using System.ComponentModel;
using System.Windows.Forms;

namespace D360.Controls
{
    public partial class ControllerButtonLabel : UserControl
    {
        [Description("The text of the label"), Category("Data")]
        public string Label
        {
            get => label1.Text;
            set
            {
                label1.Text = value;
                editButton.Name = value + "EditButton";
            }
        }

        public ControllerButtonLabel()
        {
            InitializeComponent();
        }

        private void onEditClick(object sender, System.EventArgs e)
        {
            if (!(ParentForm is ConfigForm configForm))
                return;

            if (!(sender is Button senderButton))
                return;

            configForm.CreateBindingConfigForm(senderButton);
        }
    }
}