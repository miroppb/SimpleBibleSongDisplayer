using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBibleSongDisplayer
{
    public class secrets
    {
        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection("Data Source=db.sqlite;Version=3;");
        }
    }
}
