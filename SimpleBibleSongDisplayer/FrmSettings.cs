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
            Properties.Settings.Default.UseXML = ChkXML.Checked;
            Properties.Settings.Default.xml = TxtXML.Text;
            Properties.Settings.Default.UseImage = ChkUseOverlay.Checked;
			Properties.Settings.Default.image = txtOverlay.Text;
            Properties.Settings.Default.AOT = ChkAOT.Checked;
			Properties.Settings.Default.SecondMonitor = ChkSecond.Checked;
			Properties.Settings.Default.Save();
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
                ((FrmMain)Owner).UseImage = ChkUseOverlay.Checked;
            }
        }

        private void ChkAOT_CheckedChanged(object sender, EventArgs e)
        {
            ((FrmMain)Owner).TopMost = ChkAOT.Checked;
        }

        private void txtFont_Click(object sender, EventArgs e)
        {
            FontDialog fd = new FontDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtFont.Text = "Font: " + fd.Font.Name + " " + fd.Font.Size.ToString();
				Properties.Settings.Default.Font = fd.Font;
            }
        }
    }
}
