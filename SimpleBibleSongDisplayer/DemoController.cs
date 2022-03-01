using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Windows;

namespace SimpleBibleSongDisplayer
{
    public class DemoController : ApiController
    {
        // GET api/demo
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello" };
        }

        // GET api/demo/5
        public HttpResponseMessage Get(string id)
        {
            FrmMain frm = FrmMain.outside;

            string a = "a";
            if (id == "schedule")
            {
                a = "{\"schedule\":[";
                for (int b = 0; b < frm.LstSchedule.Items.Count; b++)
                {
                    a += "\"" + frm.LstSchedule.Items[b].ToString().Replace(Environment.NewLine,"").Replace("\"", "\\\"") + "\",";
                }
                a = a.TrimEnd(',');
                a += "]}";
            }
            else if (id == "show")
            {
                try
                {
                    frm.Action = 0;
                }
                catch { }
            }
            else if (id == "showshow")
            {
                a = "{\"show\":[";
                for (int b = 0; b < frm.LstShow.Items.Count; b++)
                {
                    a += "\"" + frm.LstShow.Items[b].ToString().Replace(Environment.NewLine, "").Replace("\"","\\\"") + "\",";
                }
                a = a.TrimEnd(',');
                a += "]}";
            }
            else if (id.StartsWith("a"))
            {
                int b = Convert.ToInt32(id.Remove(0, 1));
                frm.Action = b;
            }
            else if (id.StartsWith("srch-"))
            {
                //Searching bible
                string b = id.Remove(0, 5);
                frm.TxtSearch.Text = "";
                frm.TxtSearch.Text = b;

                a = "{\"search\":[";
                for (int c = 0; c < frm.DgvVerses.Rows.Count; c++)
                {
                    string d = frm.DgvVerses.Rows[c].Cells[0].Value + " " + frm.DgvVerses.Rows[c].Cells[1].Value;
                    d = d.Replace(Environment.NewLine, "").Replace("\"", "\\\"");
                    a += "\"" + d + "\",";
                }
                a = a.TrimEnd(',');
                a += "]}";
            }
            else if (id.StartsWith("s-"))
            {
                //Select bible
                try
                {
                    int b = Convert.ToInt32(id.Remove(0,2));
                    frm.Action1 = b;
                }
                catch { }
            }
            else
            {
                //Select
                try
                {
                    int b = Convert.ToInt32(id);
                    frm.Action = b + 1;
                }
                catch { }
            }

            a = a.Replace("\t", "\\t");

            return new HttpResponseMessage()
            {
                Content = new StringContent(a, Encoding.UTF8, "application/json")
            };
        }

        // POST api/demo
        public void Post([FromBody]string value)
        {
        }

        // PUT api/demo/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/demo/5
        public void Delete(int id)
        {
        }
    }
}
