using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.IO;
using Microsoft.Owin.Hosting;
using System.Windows.Threading;

using miroppb;
using System.Text.RegularExpressions;
using System.Linq;

namespace SimpleBibleSongDisplayer
{
    public partial class FrmMain : Form
    {
        public string xml = "", image = "";
        public bool UseXML = true, UseImage = true, secondMonitor = false;
        DataTable dt = null;
        private bool _beginDragDrop = false;
        public static FrmMain outside;
        public int Action = -999;
        public int Action1 = -999;

        string currentSchedule = "";

        public bool Changing = false;

        Project.FrmProject1 f = new Project.FrmProject1();

        public FrmMain()
        {
            InitializeComponent();
            outside = this;

            if (!Directory.Exists(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SimpleBibleSongDisplayer"))
            {
                Directory.CreateDirectory(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SimpleBibleSongDisplayer");
                miroppb.libmiroppb.Log("Created Application folder: " + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\SimpleBibleSongDisplayer");
            }
        }

        private Dispatcher _dispatcher;
        public void SetDispatcher(Dispatcher dispatcher) {
            _dispatcher = dispatcher;
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmSettings frm = new FrmSettings();
            frm.starting = true;
            try
            {
                frm.ChkXML.Checked = UseXML;
                frm.TxtXML.Text = xml;
                frm.ChkUseOverlay.Checked = UseImage;
                frm.txtOverlay.Text = image;
                frm.ChkSecond.Checked = secondMonitor;

                frm.txtFont.Text = "Font: " + SimpleBibleSongDisplayer.Properties.Settings.Default.Font.Name + " " + SimpleBibleSongDisplayer.Properties.Settings.Default.Font.Size;
            }
            catch { }
            frm.starting = false;
            frm.ShowDialog(this);
            Init();

            image = frm.txtOverlay.Text;
        }

        private void Init()
        {
            if (UseXML && xml != "")
            {
                try
                {
                    DataSet ds = new DataSet();
                    ds.ReadXml(xml);
                    DgvVerses.DataSource = ds.Tables[0];
                    dt = (DataTable)DgvVerses.DataSource;

                    DgvVerses.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
                    try { DgvVerses.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill; } catch { }

                    TxtSearch.Enabled = true;

                    LblTotal.Text = DgvVerses.Rows.Count.ToString();
                }
                catch { System.Windows.MessageBox.Show(xml + " was not found. Not loading anything."); }
            }
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            DataView dv = dt.DefaultView;
            try
            {//still need to do something for 2Kings, but it's not that important...
                string[] s = TxtSearch.Text.Split(' ');
                if (s.Length == 1)
                    dv.RowFilter = string.Format(TxtFormat.Text, TxtSearch.Text);
                else if (s.Length == 2)
                {
                    if (int.TryParse(s[1], out int z))
                    {
                        string n = TxtFormat.Text + " AND " + TxtFormat.Text.Replace("{0}", " {1}");
                        dv.RowFilter = string.Format(n, s[0], s[1]);
                    }
                    else
                        dv.RowFilter = string.Format(TxtFormat.Text, s[0], s[1]);
                }
                else if (s.Length == 3)
                {
                    if (int.TryParse(s[1], out int z) && int.TryParse(s[2], out int zz))
                    {
                        string n = TxtFormat.Text + " AND " + TxtFormat.Text.Remove(TxtFormat.Text.LastIndexOf("%")).Replace("{0}", " {1}") + ":" + TxtFormat.Text.Remove(0,TxtFormat.Text.IndexOf("{")).Replace("0","2");
                        dv.RowFilter = string.Format(n, s[0], s[1], s[2]);
                    }
                    else
                        dv.RowFilter = string.Format(TxtFormat.Text, s[0], s[1], s[2]);
                }
                else
                    throw new NotImplementedException();
                DgvVerses.DataSource = dv.ToTable();
            }
            catch (Exception ex) { System.Windows.Forms.MessageBox.Show(ex.ToString()); }
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            UseXML = SimpleBibleSongDisplayer.Properties.Settings.Default.UseXML;
            xml = SimpleBibleSongDisplayer.Properties.Settings.Default.xml;
            UseImage = SimpleBibleSongDisplayer.Properties.Settings.Default.UseImage;
            image = SimpleBibleSongDisplayer.Properties.Settings.Default.image;
            TopMost = SimpleBibleSongDisplayer.Properties.Settings.Default.AOT;
            secondMonitor = SimpleBibleSongDisplayer.Properties.Settings.Default.SecondMonitor;
            Init();

            WebApp.Start<Startup>("http://localhost:1111");
        }

        private void DgvVerses_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow a in DgvVerses.SelectedRows)
            {
                try
                {
                    LstSchedule.Items.Add(a.Cells[0].Value + "\t" + a.Cells[1].Value);
                }
                catch
                {
                    LstSchedule.Items.Add(a.Cells[0].Value);
                }
            }
        }

        private void BtnGo_Click(object sender, EventArgs e)
        {
            //f = new Project.FrmProject1();
            try
            {
                if (!f.IsVisible)
                    f.Show();
            }
            catch { f = new Project.FrmProject1(); f.Show(); }
            if (secondMonitor)
            {
                try
                {
                    System.Drawing.Point l = Screen.AllScreens[1].WorkingArea.Location;
                    f.Margin = new Thickness(l.X, l.Y, 1280, 720);
                    f.WindowState = System.Windows.WindowState.Maximized;
                }
                catch { System.Windows.MessageBox.Show("Second monitor not detected. Disabling..."); secondMonitor = false; SimpleBibleSongDisplayer.Properties.Settings.Default.SecondMonitor = false; }
            }
            if (UseImage)
            {
                f.overlay.Source = new BitmapImage(new Uri(image));
                f.LblTop.Visibility = Visibility.Visible;
                f.LblText.TextAlignment = TextAlignment.Left;
                try
                {
                    f.LblTop.FontFamily = new System.Windows.Media.FontFamily(SimpleBibleSongDisplayer.Properties.Settings.Default.Font.FontFamily.ToString());
                    f.LblText.FontFamily = new System.Windows.Media.FontFamily(SimpleBibleSongDisplayer.Properties.Settings.Default.Font.FontFamily.ToString());
                }
                catch { }
            }
            else
            {
                f.overlay.Source = null;
                f.LblTop.Visibility = Visibility.Hidden;
                f.LblText.TextAlignment = TextAlignment.Center;
                try
                {
                    f.LblText.FontFamily = new System.Windows.Media.FontFamily(SimpleBibleSongDisplayer.Properties.Settings.Default.Font.FontFamily.ToString());
                }
                catch { }
            }

            //here we go
            //this actually sends info to side
            List<string> a = new List<string>();
            int c = 0;
            if (DgvVerses.SelectedRows[0].Index > 4)
            {
                c = 4;
                try
                {
                    a.Add(DgvVerses.Rows[DgvVerses.SelectedRows[0].Index - 4].Cells[0].Value.ToString() + ";;" + DgvVerses.Rows[DgvVerses.SelectedRows[0].Index - 4].Cells[1].Value.ToString());
                    a.Add(DgvVerses.Rows[DgvVerses.SelectedRows[0].Index - 3].Cells[0].Value.ToString() + ";;" + DgvVerses.Rows[DgvVerses.SelectedRows[0].Index - 3].Cells[1].Value.ToString());
                    a.Add(DgvVerses.Rows[DgvVerses.SelectedRows[0].Index - 2].Cells[0].Value.ToString() + ";;" + DgvVerses.Rows[DgvVerses.SelectedRows[0].Index - 2].Cells[1].Value.ToString());
                    a.Add(DgvVerses.Rows[DgvVerses.SelectedRows[0].Index - 1].Cells[0].Value.ToString() + ";;" + DgvVerses.Rows[DgvVerses.SelectedRows[0].Index - 1].Cells[1].Value.ToString());
                }
                catch
                {
                    a.Add(DgvVerses.Rows[DgvVerses.SelectedRows[0].Index - 4].Cells[0].Value.ToString());
                    a.Add(DgvVerses.Rows[DgvVerses.SelectedRows[0].Index - 3].Cells[0].Value.ToString());
                    a.Add(DgvVerses.Rows[DgvVerses.SelectedRows[0].Index - 2].Cells[0].Value.ToString());
                    a.Add(DgvVerses.Rows[DgvVerses.SelectedRows[0].Index - 1].Cells[0].Value.ToString());
                }
            }

            for (int b = 0; b < Nud.Value; b++)
            {
                try { a.Add(DgvVerses.Rows[DgvVerses.SelectedRows[0].Index + b].Cells[0].Value.ToString() + ";;" + DgvVerses.Rows[DgvVerses.SelectedRows[0].Index + b].Cells[1].Value.ToString()); }
                catch { try { a.Add(DgvVerses.Rows[DgvVerses.SelectedRows[0].Index + b].Cells[0].Value.ToString()); } catch { } }
            }

            Changing = true;
            LstShow.Items.Clear();
            LstShow.Items.AddRange(a.ToArray());
            LstShow.SelectedIndex = c;
            Changing = false;

            LstShow.Focus();
            Fade(LstShow.Items[LstShow.SelectedIndex].ToString());
        }


        private void BtnUp_Click(object sender, EventArgs e)
        {
            f.LblText.FontSize++;
        }

        private void BtnDown_Click(object sender, EventArgs e)
        {
            f.LblText.FontSize--;
        }

        private void LstSchedule_DoubleClick(object sender, EventArgs e)
        {
            if (LstSchedule.Items[LstSchedule.SelectedIndex].ToString().StartsWith("Speaker::"))
            {
                if (LstShow.Items.Count == 0)
                {
                    DgvVerses.Rows[0].Selected = true;
                    BtnGo_Click(null, null);
                }
                string[] a = LstSchedule.Items[LstSchedule.SelectedIndex].ToString().Remove(0,9).Split(new string[] { "\t" }, StringSplitOptions.None);
                LstShow.Items.Add(a[0] + ";;" + a[1]);
            }
            else
            {
                TxtSearch.Text = "";
                string[] a = LstSchedule.Items[LstSchedule.SelectedIndex].ToString().Split(new string[] { "\t" }, StringSplitOptions.None);
                String searchValue = a[0];
                int rowIndex = -1;
                foreach (DataGridViewRow row in DgvVerses.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(searchValue))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }

                DgvVerses.Rows[rowIndex].Selected = true;
                DgvVerses.FirstDisplayedScrollingRowIndex = DgvVerses.SelectedRows[0].Index;
            }

        }

        private void updateCurrentSchedule(string path)
        {
            currentSchedule = path;
            TS_CurrentSchedule.Text = "Current Schedule: " + Path.GetFileName(currentSchedule);
        }

        private void openScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "SBSD File|*.sbsd";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader r = new StreamReader(ofd.FileName);
                string[] a = r.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.None);
                LstSchedule.Items.Clear();
                LstSchedule.Items.AddRange(a);
                r.Close();

                updateCurrentSchedule(ofd.FileName);
            }
        }

        private void saveScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "SBSD File|*.sbsd";
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            sfd.FileName = GetNextWeekday(DateTime.Now, DayOfWeek.Sunday).ToString("yMMdd") + ".sbsd";

            if (currentSchedule != "")
            {
                sfd.InitialDirectory = Path.GetDirectoryName(currentSchedule);
                sfd.FileName = Path.GetFileName(currentSchedule);
            }
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter w = new StreamWriter(sfd.FileName);
                string a = "";
                foreach (string l in LstSchedule.Items)
                {
                    a += l + Environment.NewLine;
                }
                w.Write(a.Trim());
                w.Write("\t");
                w.Close();

                updateCurrentSchedule(sfd.FileName);
            }
        }

        public static DateTime GetNextWeekday(DateTime start, DayOfWeek day)
        {
            // The (... + 7) % 7 ensures we end up with a value in the range [0, 6]
            int daysToAdd = ((int)day - (int)start.DayOfWeek + 7) % 7;
            return start.AddDays(daysToAdd);
        }

        private void LstSchedule_KeyDown(object sender, KeyEventArgs e)
        {
            if (LstSchedule.SelectedItems.Count > 0 && e.KeyCode == Keys.Delete)
            {
                LstSchedule.Items.RemoveAt(LstSchedule.SelectedIndex);
            }
        }

        private void LstSchedule_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (_beginDragDrop == true))
            {
                // Replace this with the object you want to Drag & Drop
                object draggedObject = this;
                this.DoDragDrop(draggedObject, System.Windows.Forms.DragDropEffects.Move);
                _beginDragDrop = false;
            }
        }

        private void LstSchedule_MouseDown(object sender, MouseEventArgs e)
        {
            if ((e.Button == MouseButtons.Left) && (e.Clicks == 1))
                _beginDragDrop = true;
            else
                _beginDragDrop = false;
        }

        private void LstSchedule_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
        {
            e.Effect = System.Windows.Forms.DragDropEffects.Move;
        }

        private void LstSchedule_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            System.Drawing.Point point = LstSchedule.PointToClient(new System.Drawing.Point(e.X, e.Y));
            int index = this.LstSchedule.IndexFromPoint(point);
            if (index < 0) index = this.LstSchedule.Items.Count - 1;
            //object data = e.Data.GetData(typeof(string));
            string data = ((ListBox)sender).SelectedItem.ToString();
            this.LstSchedule.Items.Remove(data);
            this.LstSchedule.Items.Insert(index, data);
        }

        private void addSpeakerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool a = this.TopMost;
            this.TopMost = false;
            FrmSpeaker frm = new FrmSpeaker();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                LstSchedule.Items.Add("Speaker::" + frm.TxtName.Text + "\t" + frm.TxtLower.Text);
            }
            this.TopMost = a;
        }

        private void processtxtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text file|*.txt";
            ofd.InitialDirectory = "\\\\192.168.3.4\\Users\\BFGC\\Desktop\\";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                FrmTxt2Xml frm = new FrmTxt2Xml();

                StreamReader r = new StreamReader(ofd.FileName);
                string[] s = r.ReadToEnd().Split(new[] { Environment.NewLine }, StringSplitOptions.None);

                for (int a = 0; a < s.Length; a++)
                    frm.LstIn.Items.Add(s[a]);

                this.TopMost = false;
                frm.ShowDialog();
                this.TopMost = SimpleBibleSongDisplayer.Properties.Settings.Default.AOT;
                r.Close();

                //ask if want to set the XML as the current XML
                if (frm.filename != "")
                {
                    if (System.Windows.Forms.MessageBox.Show("Set " + frm.filename + " as current XML file?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SimpleBibleSongDisplayer.Properties.Settings.Default.xml = frm.filename;
                        SimpleBibleSongDisplayer.Properties.Settings.Default.Save();
                        xml = frm.filename;
                        Init();
                    }
                }
            }
        }

        private void processxmlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Xml file|*.xml";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string f = ofd.FileName;
                StreamReader r = new StreamReader(f);
                string rr = r.ReadToEnd();
                r.Close();

                rr = rr.Replace("<song>", "").Replace("</song>", "");

                FrmProcessXml frm = new FrmProcessXml(Regex.Split(rr, "<line>[-_]*?<\\/line>").ToList());
                this.TopMost = false; //in case the window is set to being Top
                frm.ShowDialog();

                TopMost = SimpleBibleSongDisplayer.Properties.Settings.Default.AOT; //return the setting
                if (frm.SaveFile != "")
                {
                    if (System.Windows.Forms.MessageBox.Show("Set " + frm.SaveFile + " as current XML file?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SimpleBibleSongDisplayer.Properties.Settings.Default.xml = frm.SaveFile;
                        SimpleBibleSongDisplayer.Properties.Settings.Default.Save();
                        xml = frm.SaveFile;
                        Init();
                    }
                }
            }
            else
            {
                //show the window without getting file
                FrmProcessXml frm = new FrmProcessXml
                {
                    Text = "Edit Songs..."
                };
                this.TopMost = false; //in case the window is set to being Top

                frm.BtnNext.Visible = false;
                frm.BtnPrev.Visible = false;

                frm.ShowDialog();

                TopMost = SimpleBibleSongDisplayer.Properties.Settings.Default.AOT; //return the setting
                if (frm.SaveFile != "")
                {
                    if (System.Windows.Forms.MessageBox.Show("Set " + frm.SaveFile + " as current XML file?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SimpleBibleSongDisplayer.Properties.Settings.Default.xml = frm.SaveFile;
                        xml = frm.SaveFile;
                        Init();
                    }
                }
            }
        }

        private void LstShow_KeyPress(object sender, KeyPressEventArgs e)
        {
            int i;
            if (int.TryParse(e.KeyChar.ToString(), out i))
            {
                try
                {
                    LstShow.SelectedIndex = LstShow.SelectedIndex - i;
                }
                catch { }
            }
        }

        private void LblTotal_Click(object sender, EventArgs e)
        {
            if (LblTotal.Text != "")
            {
                try
                {
                    Nud.Value = Convert.ToInt32(LblTotal.Text);
                }
                catch { }
            }
        }

        private void LstSchedule_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (LstSchedule.Items[LstSchedule.SelectedIndex].ToString().StartsWith("Speaker::"))
            {
                if (LstShow.Items.Count == 0)
                {
                    DgvVerses.Rows[0].Selected = true;
                    BtnGo_Click(null, null);
                }
                string[] a = LstSchedule.Items[LstSchedule.SelectedIndex].ToString().Remove(0, 9).Split(new string[] { "\t" }, StringSplitOptions.None);
                LstShow.Items.Add(a[0] + ";;" + a[1]);
            }
            else
            {
                TxtSearch.Text = "";
                string[] a = LstSchedule.Items[LstSchedule.SelectedIndex].ToString().Split(new string[] { "\t" }, StringSplitOptions.None);
                String searchValue = a[0];
                int rowIndex = -1;
                foreach (DataGridViewRow row in DgvVerses.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(searchValue))
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }

                DgvVerses.Rows[rowIndex].Selected = true;
                DgvVerses.FirstDisplayedScrollingRowIndex = DgvVerses.SelectedRows[0].Index;
            }
        }

        private void timerAction_Tick(object sender, EventArgs e)
        {
            if (Action != -999)
            {
                if (Action > 0)
                {
                    LstSchedule.SelectedIndex = Action - 1;
                    LstSchedule_MouseDoubleClick(null, null);
                }
                else if (Action == 0)
                    BtnGo_Click(null, null);
                else if (Action < 0 && Action > -999)
                {
                    LstShow.SelectedIndex = (Action * -1) - 1;
                }
            }
            if (Action1 != -999)
            {
                if (Action1 >= 0)
                {
                    DgvVerses.Rows[Action1].Selected = true;
                }
            }
            Action = -999;
            Action1 = -999;
        }

        private void newScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentSchedule != "")
            {
                if (System.Windows.MessageBox.Show("Are you sure you want to start a new schedule?", "Simple Bible/Song Displayer", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    LstSchedule.Items.Clear();
                    currentSchedule = "";
                }
            }
        }

        private void FrmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.S)
            {
                //save
                saveScheduleToolStripMenuItem_Click(null, null);
            }
            else if (e.Control && e.KeyCode == Keys.A)
            {
                //add speaker
                addSpeakerToolStripMenuItem_Click(null, null);
            }
        }

        private async void Fade(string newText, int milliseconds)
        {
            //try to divide the text
            string[] a = newText.Split(new string[] { ";;" }, StringSplitOptions.None);

            DoubleAnimation da = new DoubleAnimation
            {
                From = 1,
                To = 0,
                Duration = new System.Windows.Duration(TimeSpan.FromMilliseconds(milliseconds)),
                AutoReverse = true
            };
            f.LblText.BeginAnimation(UIElement.OpacityProperty, da);

            await Task.Delay(milliseconds);
            if (a.Length == 1)
                f.LblText.Text = a[0];
            else
            {
                f.LblTop.Text = a[0];
                f.LblText.Text = a[1];
            }
        }

        private void Fade(string newText)
        {
            Fade(newText, 500);
        }

        private void LstShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!Changing)
            {
                //should be easy, right?
                Fade(LstShow.Items[LstShow.SelectedIndex].ToString());
            }
        }
    }
}
