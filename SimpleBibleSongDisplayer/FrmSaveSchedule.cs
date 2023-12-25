using System;
using System.Windows.Forms;

namespace SimpleBibleSongDisplayer
{
	public partial class FrmSaveSchedule : Form
	{
		public FrmSaveSchedule()
		{
			InitializeComponent();
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void BtnCancel_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
