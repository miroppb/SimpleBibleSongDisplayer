using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace SimpleBibleSongDisplayer.Controllers
{
    [EnableCors("Policy")]
    [Route("api")]
    [ApiController]
    public class SBSDController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Hello" };
        }

        [HttpGet("{id}")]
        public IActionResult Get(string id)
        {
            Object ret = null;
            Program.frm.Invoke(new Action(() =>
            {
                if (id == "schedule")
                {
                    List<string> list = new List<string>();
                    foreach (Object o in Program.frm.LstSchedule.Items)
                        list.Add(o.ToString());

                    ret = new { schedule = list };
                }
                else if (id == "show")
                {
                    try
                    {
                        Program.frm.Action = 0;
                    }
                    catch { }
                }
                else if (id == "showshow")
                {
                    List<string> list = new List<string>();
                    foreach (Object o in Program.frm.LstShow.Items)
                        list.Add(o.ToString());

                    ret = new { show = list };
                }
                else if (id.StartsWith("a"))
                {
                    int b = Convert.ToInt32(id.Remove(0, 1));
                    Program.frm.Action = b;
                }
                else if (id.StartsWith("srch-"))
                {
                    //Searching bible
                    string b = id.Remove(0, 5);
                    Program.frm.TxtSearch.Text = "";
                    Program.frm.TxtSearch.Text = b;

                    List<string> list = new List<string>();
                    foreach (System.Windows.Forms.DataGridViewRow row in Program.frm.DgvVerses.Rows)
                        list.Add(row.Cells[0].Value + " " + row.Cells[1].Value);

                    ret = new { search = list };
                }
                else if (id.StartsWith("s-"))
                {
                    //Select bible
                    try
                    {
                        int b = Convert.ToInt32(id.Remove(0, 2));
                        Program.frm.Action1 = b;
                    }
                    catch { }
                }
                else
                {
                    //Select
                    try
                    {
                        int b = Convert.ToInt32(id);
                        Program.frm.Action = b + 1;
                    }
                    catch { }
                }
            }));
            return Ok(ret);
        }
    }
}