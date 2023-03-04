using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Dapper;
using MySqlConnector;
using SimpleBibleSongDisplayer.Dapper;

namespace SimpleBibleSongDisplayer
{
    public partial class FrmSpeaker : Form
    {
        List<string> ACList = new List<string>();
        public bool DBOnline = true;

        public FrmSpeaker(bool _db)
        {
            InitializeComponent();
            DBOnline = _db;

            if (_db)
            {
                using (MySqlConnection db = secrets.GetConnectionString())
                {
                    AutoCompleteStringCollection acs = new AutoCompleteStringCollection();
                    List<clsAutoComplete> ac = db.Query<clsAutoComplete>("SELECT text FROM autocomplete").ToList();
                    ac.ForEach(c => acs.Add(c.text));
                    ac.ForEach(c => ACList.Add(c.text));
                    TxtName.AutoCompleteCustomSource = acs;
                }
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            //save top to db
            if (DBOnline)
            {
                using (MySqlConnection db = secrets.GetConnectionString())
                {
                    double per = 0;
                    foreach (string a in ACList)
                    {
                        per = ComputePercentage.CalculateSimilarity(a, TxtName.Text);
                        if ((per * 100) > 90)
                            break;
                    }
                    if ((per * 100) < 90)
                        db.Execute("INSERT INTO autocomplete VALUES(NULL, @text);", new DynamicParameters(new { text = TxtName.Text }));
                }
            }
            

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
