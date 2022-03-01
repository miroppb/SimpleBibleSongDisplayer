using System;
using System.Windows.Forms;

namespace SimpleBibleSongDisplayer
{
    public partial class FrmSettings : Form
    {
        public bool starting = false;

        public FrmSettings()
        {
            InitializeComponent();
        }

        private void TxtXML_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "XML file|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                TxtXML.Text = ofd.FileName;
                ((FrmMain)this.Owner).xml = TxtXML.Text;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            SimpleBibleSongDisplayer.Properties.Settings.Default.UseXML = ChkXML.Checked;
            SimpleBibleSongDisplayer.Properties.Settings.Default.xml = TxtXML.Text;
            SimpleBibleSongDisplayer.Properties.Settings.Default.UseImage = ChkUseOverlay.Checked;
            SimpleBibleSongDisplayer.Properties.Settings.Default.image = txtOverlay.Text;
            SimpleBibleSongDisplayer.Properties.Settings.Default.AOT = ChkAOT.Checked;
            SimpleBibleSongDisplayer.Properties.Settings.Default.SecondMonitor = ChkSecond.Checked;
            SimpleBibleSongDisplayer.Properties.Settings.Default.Save();
            this.Close();
        }

        private void ChkXML_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkXML.Checked)
            {
                groupBox1.Enabled = true;
            }
            else
            {
                groupBox1.Enabled = false;
            }
            if (!starting)
            {
                ((FrmMain)this.Owner).UseXML = ChkXML.Checked;
            }
        }

        private void txtImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Images|*.png;*.jpg*.jpeg*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
                txtOverlay.Text = ofd.FileName;
        }

        private void ChkUseImage_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkUseOverlay.Checked)
            {
                groupBox2.Enabled = true;
            }
            else
            {
                groupBox2.Enabled = false;
            }
            if (!starting)
            {
                ((FrmMain)this.Owner).UseImage = ChkUseOverlay.Checked;
            }
        }

        private void ChkAOT_CheckedChanged(object sender, EventArgs e)
        {
            ((FrmMain)this.Owner).TopMost = ChkAOT.Checked;
        }

        private void txtFont_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtFont.Text = "Font: " + fd.Font.Name + " " + fd.Font.Size.ToString();
                SimpleBibleSongDisplayer.Properties.Settings.Default.Font = fd.Font;
            }
        }
    }
}
