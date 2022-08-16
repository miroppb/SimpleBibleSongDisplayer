using System;
using System.Collections.Generic;
using System.Windows;
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

        [HttpGet("{endpoint}")]
        public ActionResult<string> Get(string endpoint)
        {
            object ret = null;
            Program.frm.Invoke(new System.Action(() =>
            {
                switch(endpoint)
                {
                    case "schedule":
                        List<string> schlist = new List<string>();
                        foreach (Object o in Program.frm.LstSchedule.Items)
                            schlist.Add(o.ToString());
                        int selected = Program.frm.LstSchedule.SelectedIndex;

                        ret = new { schedule = schlist, selected = selected };
                        break;
                    case "go":
                        Program.frm.DoStuff(Action.show);
                        break;
                    case "show":
                        List<string> showlist = new List<string>();
                        foreach (Object o in Program.frm.LstShow.Items)
                            showlist.Add(o.ToString());
                        selected = Program.frm.LstShow.SelectedIndex;

                        ret = new { show = showlist, selected = selected };
                        break;
                }
            }));
            return Ok(ret);
        }

        [HttpGet("{_action}/{change}")]
        public ActionResult<string> Get(string _action, string change)
        {
            object ret = null;
            Program.frm.Invoke(new System.Action(() =>
            {
                if (_action == "search")
                {
                    //Searching bible
                    Program.frm.TxtSearch.Text = "";
                    Program.frm.TxtSearch.Text = change;

                    List<string> list = new List<string>();
                    foreach (System.Windows.Forms.DataGridViewRow row in Program.frm.DgvVerses.Rows)
                        list.Add(row.Cells[0].Value + " " + row.Cells[1].Value);

                    ret = new { search = list };
                }
                else
                {
                    Enum.TryParse(_action, out Action _act);
                    Program.frm.DoStuff(_act, Convert.ToInt32(change));
                    ret = "success";
                }
            }));
            return Ok(ret);
        }
    }
}