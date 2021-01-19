using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace D360.Controls
{
    public partial class RadiusSlider : UserControl
    {
        public event EventHandler TrackBarChanged;
        public event EventHandler CheckChanged;

        [Description("The text of the label"), Category("Data")]
        public string Label
        {
            get => titleLabel.Text;
            set => titleLabel.Text = value;
        }

        public int Value
        {
            get => trackBar.Value;
            set => trackBar.Value = value;
        }

        public string Percent
        {
            get => valueLabel.Text;
            set => valueLabel.Text = value;
        }

        public bool Checked
        {
            get => maxCheck.Checked;
            set => maxCheck.Checked = value;
        }

        public RadiusSlider()
        {
            InitializeComponent();
        }

        private void OnTrackBarChanged(object sender, EventArgs e)
        {
            TrackBarChanged?.Invoke(this, e);
        }

        private void OnCheckChanged(object sender, EventArgs e)
        {
            CheckChanged?.Invoke(this, e);
        }
    }
}
