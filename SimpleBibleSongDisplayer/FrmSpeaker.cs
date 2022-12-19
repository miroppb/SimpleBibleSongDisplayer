using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;
using Dapper;
using SimpleBibleSongDisplayer.Dapper;

namespace SimpleBibleSongDisplayer
{
    public partial class FrmSpeaker : Form
    {
        public FrmSpeaker()
        {
            InitializeComponent();

            using (SQLiteConnection db = secrets.GetConnection())
            {
                AutoCompleteStringCollection acs = new AutoCompleteStringCollection();
                List<clsAutoComplete> ac = db.Query<clsAutoComplete>("SELECT text FROM autocomplete").ToList();
                ac.ForEach(c => acs.Add(c.text));
                TxtName.AutoCompleteCustomSource = acs;
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            //save top to db
            //using (SQLiteConnection db = secrets.GetConnection())
            //    if (TxtName.AutoCompleteCustomSource.)
            //    {
            //        db.Execute("INSERT INTO autocomplete VALUES(NULL, @text);", new DynamicParameters(new { text = TxtName.Text }));

            //    }

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
