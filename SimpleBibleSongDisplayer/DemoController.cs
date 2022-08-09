using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Web.Http;

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
            Object ret = null;
            if (id == "schedule")
            {
                List<string> list = new List<string>();
                foreach (Object o in frm.LstSchedule.Items)
                    list.Add(o.ToString());

                ret = new { schedule = String.Join(",", list) };
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
                List<string> list = new List<string>();
                foreach (Object o in frm.LstShow.Items)
                    list.Add(o.ToString());

                ret = new { show = String.Join(",", list) };
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

                List<string> list = new List<string>();
                foreach (System.Windows.Forms.DataGridViewRow row in frm.DgvVerses.Rows)
                    list.Add(row.Cells[0].Value + " " + row.Cells[1].Value);

                ret = new { search = String.Join(",", list) };
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
                Content = new StringContent(JsonConvert.SerializeObject(ret), Encoding.UTF8, "application/json")
                //Content = new StringContent(a, Encoding.UTF8, "application/json")
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
