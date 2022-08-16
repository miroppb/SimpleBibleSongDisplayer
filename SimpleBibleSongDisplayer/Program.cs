﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using System;
using System.Windows.Forms;

namespace SimpleBibleSongDisplayer
{
    static class Program
    {
        public static FrmMain frm { get; private set; }

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().RunAsync();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            frm = new FrmMain();
            Application.Run(frm);
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
             WebHost.CreateDefaultBuilder(args).UseUrls("http://*:1111")
                 .UseStartup<Startup>();
    }
}
