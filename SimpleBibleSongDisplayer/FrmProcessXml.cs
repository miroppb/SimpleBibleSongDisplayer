using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
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

        SQLiteConnection dbConnection = new SQLiteConnection("Data Source=songs.sqlite;Version=3;");

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
            DataTable dt = GetDataTable("SELECT * FROM songs ORDER BY song");
            ids.Clear(); text.Clear();
            CmbSongs.SelectedIndex = -1;
            CmbSongs.Items.Clear();
            AutoCompleteStringCollection acs = new AutoCompleteStringCollection();

            foreach (DataRow r in dt.Rows)
            {
                ids.Add(Convert.ToInt32(r.ItemArray[0].ToString()));
                text.Add(r.ItemArray[1].ToString());

                string firstLine = r.ItemArray[1].ToString().Replace("\n\r", "").Substring(0, r.ItemArray[1].ToString().IndexOf(Environment.NewLine)).Replace("\t<line>", "");
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

        #region SQLite code
        public DataTable GetDataTable(string sql)
        {
            DataTable dt = new DataTable();
            try
            {
                SQLiteConnection conn = new SQLiteConnection(dbConnection);
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand(sql, conn);
                SQLiteDataReader reader = comm.ExecuteReader();
                dt.Load(reader);
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return dt;
        }

        public int ExecuteNonQuery(string sql)
        {
            try
            {
                SQLiteConnection conn = new SQLiteConnection(dbConnection);
                conn.Open();
                SQLiteCommand comm = new SQLiteCommand(conn);
                comm.CommandText = sql;
                int rowsUpdated = comm.ExecuteNonQuery();
                conn.Close();
                return rowsUpdated;
            }
            catch
            {
                return -1;
            }
        }

        public int ExecuteNonQueryWithBlob(string sql, string blobFieldName, byte[] blob)
        {
            SQLiteConnection con = new SQLiteConnection(dbConnection);
            SQLiteCommand cmd = con.CreateCommand();
            cmd.CommandText = String.Format(sql);
            SQLiteParameter param = new SQLiteParameter("@" + blobFieldName, System.Data.DbType.Binary);
            param.Value = blob;
            cmd.Parameters.Add(param);
            con.Open();

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception exc1)
            {
                MessageBox.Show(exc1.Message);
            }
            con.Close();
            return 0;
        }

        public bool Update(string tableName, Dictionary<string, string> data, string where)
        {
            string vals = "";
            bool returnCode = true;
            if (data.Count >= 1)
            {
                foreach (KeyValuePair<string, string> val in data)
                {
                    vals += String.Format(" {0} = '{1}',", val.Key.ToString(), val.Value.ToString());
                }
                vals = vals.Substring(0, vals.Length - 1);
            }
            try
            {
                this.ExecuteNonQuery(String.Format("UPDATE {0} SET {1} WHERE {2}", tableName, vals, where));
            }
            catch
            {
                returnCode = false;
            }
            return returnCode;
        }

        public bool Delete(string tableName, string where)
        {
            bool returnCode = true;
            try
            {
                this.ExecuteNonQuery(String.Format("DELETE FROM {0} WHERE {1}", tableName, where));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                returnCode = false;
            }
            return returnCode;
        }

        public bool Insert(string tableName, Dictionary<string, string> data)
        {
            string columns = "";
            string values = "";
            bool returnCode = true;
            foreach (KeyValuePair<string, string> val in data)
            {
                columns += String.Format(" {0},", val.Key.ToString());
                values += String.Format(" '{0}',", val.Value);
            }
            columns = columns.Substring(0, columns.Length - 1);
            values = values.Substring(0, values.Length - 1);
            try
            {
                this.ExecuteNonQuery(String.Format("INSERT INTO {0}({1}) VALUES({2});", tableName, columns, values));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                returnCode = false;
            }
            return returnCode;
        }

        public void Prepare(string sql, List<SQLiteParameter> data)
        {
            SQLiteConnection conn = new SQLiteConnection(dbConnection);
            conn.Open();
            SQLiteCommand comm = new SQLiteCommand(conn);
            comm.CommandText = sql;
            for (int c = 0; c < data.Count(); c++)
                comm.Parameters.Add(data[c]);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        #endregion SQLite code

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
                    per = CalculateSimilarity(firstLine, CmbSongs.Items[a].ToString());
                    if ((per*100) > 90)
                    {
                        MessageBox.Show("The first line" + Environment.NewLine + Environment.NewLine + firstLine + Environment.NewLine + Environment.NewLine + "is similiar to the song" + Environment.NewLine + Environment.NewLine + CmbSongs.Items[a].ToString());
                    }
                }    

                if (MessageBox.Show("Are you sure you want to save this song into the database?", "For Real?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExecuteNonQuery("INSERT INTO songs VALUES(NULL, '" + TxtSong.Text.Replace("'", "''") + "');");

                    RefreshDropDown();
                }
            }
            else
            {
                if (MessageBox.Show("Are you sure you want to save this song back into the database?", "For Real?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ExecuteNonQuery("UPDATE songs SET song = '" + TxtSong.Text.Replace("'", "''") + "' WHERE id = " + ids[CmbSongs.SelectedIndex] + ";");

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

        #region Percentage
        /// <summary>
        /// Returns the number of steps required to transform the source string
        /// into the target string.
        /// </summary>
        int ComputeLevenshteinDistance(string source, string target)
        {
            if ((source == null) || (target == null)) return 0;
            if ((source.Length == 0) || (target.Length == 0)) return 0;
            if (source == target) return source.Length;

            int sourceWordCount = source.Length;
            int targetWordCount = target.Length;

            // Step 1
            if (sourceWordCount == 0)
                return targetWordCount;

            if (targetWordCount == 0)
                return sourceWordCount;

            int[,] distance = new int[sourceWordCount + 1, targetWordCount + 1];

            // Step 2
            for (int i = 0; i <= sourceWordCount; distance[i, 0] = i++) ;
            for (int j = 0; j <= targetWordCount; distance[0, j] = j++) ;

            for (int i = 1; i <= sourceWordCount; i++)
            {
                for (int j = 1; j <= targetWordCount; j++)
                {
                    // Step 3
                    int cost = (target[j - 1] == source[i - 1]) ? 0 : 1;

                    // Step 4
                    distance[i, j] = Math.Min(Math.Min(distance[i - 1, j] + 1, distance[i, j - 1] + 1), distance[i - 1, j - 1] + cost);
                }
            }
            return distance[sourceWordCount, targetWordCount];
        }

        /// <summary>
        /// Calculate percentage similarity of two strings
        /// <param name="source">Source String to Compare with</param>
        /// <param name="target">Targeted String to Compare</param>
        /// <returns>Return Similarity between two strings from 0 to 1.0</returns>
        /// </summary>
        double CalculateSimilarity(string source, string target)
        {
            if ((source == null) || (target == null)) return 0.0;
            if ((source.Length == 0) || (target.Length == 0)) return 0.0;
            if (source == target)
                return 1.0;

            int stepsToSame = ComputeLevenshteinDistance(source, target);
            return (1.0 - ((double)stepsToSame / (double)Math.Max(source.Length, target.Length)));
        }

        #endregion
    }
}
