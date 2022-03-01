using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace SimpleBibleSongDisplayer
{
    public partial class FrmTxt2Xml : Form
    {
        public string filename = "";

        public FrmTxt2Xml()
        {
            InitializeComponent();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            string a = "";
            List<string> c = new List<string>();
            for (int b = 0; b < LstIn.SelectedIndices.Count; b++)
            {
                c.Add(LstIn.SelectedItems[b].ToString());
            }
            a = String.Join(Environment.NewLine, c);
            LstOut.Items.Add(a);
            while (LstIn.SelectedItems.Count > 0)
            {
                LstIn.Items.Remove(LstIn.SelectedItems[0]);
            }
        }

        private void LstIn_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                for (int a = 0; a < LstIn.SelectedItems.Count; a++)
                    LstIn.Items.Remove(LstIn.SelectedItems[a]);
            }
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            for (int c = 0; c < LstOut.SelectedItems.Count; c++)
            {
                string b = LstOut.SelectedItems[c].ToString();
                if (b.Contains(Environment.NewLine))
                {
                    string[] d = b.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                    Array.Reverse(d, 0, d.Length);
                    foreach (string f in d)
                    {
                        LstIn.Items.Insert(0, f);
                    }
                }
                else
                    LstIn.Items.Insert(0, b);
                LstOut.Items.RemoveAt(LstOut.SelectedIndex);
            }
        }

        private void LstOut_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "XML File|*.xml";
            sfd.InitialDirectory = "C:\\Users\\miro\\Desktop\\Schedules\\";
            sfd.FileName = GetNextWeekday(DateTime.Now, DayOfWeek.Sunday).ToString("yMMdd") + ".xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter w = new StreamWriter(sfd.FileName);
                w.WriteLine("<song>");
                for (int a = 0; a < LstOut.Items.Count; a++)
                {
                    w.WriteLine("\t<line>" + LstOut.Items[a].ToString() + "</line>");
                }
                w.WriteLine("</song>");
                w.Close();

                filename = sfd.FileName;
            }
        }

        public static DateTime GetNextWeekday(DateTime start, DayOfWeek day)
        {
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }
    }
}
