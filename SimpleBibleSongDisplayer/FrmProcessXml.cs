using Dapper;
using MySql.Data.MySqlClient;
using SimpleBibleSongDisplayer.Dapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SimpleBibleSongDisplayer
{
    public partial class FrmProcessXml : Form
    {
        public List<string> songs = new List<string>();
        private int cur = 0;
        List<int> ids = new List<int>();
        List<string> text = new List<string>(); //we'll do both, adding new songs, and editing
        public string SaveFile = "";

        /// <summary>
        /// Initialize form for editing text inside an XML file
        /// </summary>
        /// <param name="s">List of strings containing the text of songs</param>
        public FrmProcessXml(List<string> s)
        {
            InitializeComponent();

            songs = s;

            if (songs.Count > 0)
            {
                TxtSong.Text = songs[cur].TrimEnd();
            }

            RefreshDropDown();
        }

        /// <summary>
        /// Initialize the form to edit the songs already in the database
        /// </summary>
        public FrmProcessXml()
        {
            InitializeComponent();

            BtnAddDb.Text = "Save to db";
            RefreshDropDown();
        }

        private void RefreshDropDown()
        {
            List<clsSongs> songs = null;
            using (MySqlConnection db = secrets.GetConnectionString())
                songs = db.Query<clsSongs>("SELECT * FROM songs ORDER BY song").ToList();

            ids.Clear(); text.Clear();
            CmbSongs.SelectedIndex = -1;
            CmbSongs.Items.Clear();
            AutoCompleteStringCollection acs = new AutoCompleteStringCollection();

            foreach (clsSongs song in songs)
            {
                ids.Add(song.id);
                text.Add(song.text);

                string firstLine = song.text.Replace("\n\r", "").Substring(0, song.text.IndexOf(Environment.NewLine)).Replace("\t<line>", "");
                CmbSongs.Items.Add(firstLine);
                acs.Add(firstLine);
            }
            CmbSongs.AutoCompleteCustomSource = acs;
        }

        private void BtnRemSpac_Click(object sender, EventArgs e)
        {
            //lets try to remove extra spaces...
            TxtSong.Text = Regex.Replace(TxtSong.Text, "\\s+?\\n", Environment.NewLine);
            TxtSong.Text = Regex.Replace(TxtSong.Text, "\\s+?<\\/line>", "</line>");
        }

        private void BtnNext_Click(object sender, EventArgs e)
        {
            if (cur < songs.Count-1)
            {
                cur++;
                TxtSong.Text = songs[cur].TrimEnd();
            }
            else
                MessageBox.Show("You can't go forward");
        }

        private void BtnPrev_Click(object sender, EventArgs e)
        {
            if (cur > 0)
            {
                cur--;
                TxtSong.Text = songs[cur].TrimEnd();
            }
            else
                MessageBox.Show("You can't go back");
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Xml File|*.xml";
            sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (TxtXML.Lines[TxtXML.Lines.Length-1].Contains("---"))
                    TxtXML.Text = TxtXML.Text.Remove(TxtXML.Text.LastIndexOf(Environment.NewLine));
                TxtXML.Text += Environment.NewLine + "</song>";

                StreamWriter w = new StreamWriter(sfd.FileName);
                w.Write(TxtXML.Text);
                w.Close();

                SaveFile = sfd.FileName;
            }
        }

        private void BtnAddXML_Click(object sender, EventArgs e)
        {
            if (TxtXML.Text == "")
                TxtXML.Text = "<song>" + Environment.NewLine;
            else
                TxtXML.Text += Environment.NewLine;

            TxtXML.Text += Regex.Replace(TxtSong.Text, "^<line", "\t<line");
            TxtXML.Text += Environment.NewLine + "\t<line>-------</line>";
        }

        private void BtnAddDB_Click(object sender, EventArgs e)
        {
            if (songs.Count > 0)
            {
                //lets see if we can compare song titles?
                double per = 0;
                for (int a = 0; a < CmbSongs.Items.Count; a++)
                {
                    string firstLine = TxtSong.Text.Substring(0, TxtSong.Text.IndexOf(Environment.NewLine)).Replace("\t<line>", "");
                    per = ComputePercentage.CalculateSimilarity(firstLine, CmbSongs.Items[a].ToString());
                    if ((per*100) > 90)
                    {
                        MessageBox.Show("The first line" + Environment.NewLine + Environment.NewLine + firstLine + Environment.NewLine + Environment.NewLine + "is similiar to the song" + Environment.NewLine + Environment.NewLine + CmbSongs.Items[a].ToString());
                    }
                }    

                if (MessageBox.Show("Are you sure you want to save this song into the database?", "For Real?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (MySqlConnection db = secrets.GetConnectionString())
                        db.Execute("INSERT INTO songs VALUES(NULL, '" + TxtSong.Text.Replace("'", "''") + "');");

                    RefreshDropDown();
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to save this song back into the database?", "For Real?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    using (MySqlConnection db = secrets.GetConnectionString())
                        db.Execute("UPDATE songs SET song = '" + TxtSong.Text.Replace("'", "''") + "' WHERE id = " + ids[CmbSongs.SelectedIndex] + ";");

                    int cur = CmbSongs.SelectedIndex;
                    CmbSongs.SelectedIndex = -1;
                    RefreshDropDown();
                    try
                    {
                        CmbSongs.SelectedIndex = cur;
                    }
                    catch { }
                }
            }
        }

        private void CmbSongs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CmbSongs.SelectedIndex >= 0)
                TxtSong.Text = text[CmbSongs.SelectedIndex];
        }

        
    }
}
