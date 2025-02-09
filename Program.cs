﻿using Squirrel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace MyApp
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Update();
            Application.Run(new Form1());

        }
        static async Task Update()
        {
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            ServicePointManager.Expect100Continue = true;
            //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            //var version = typeof(Program).Assembly.GetName().Version.ToString();
            //if(version == "1.0.1")
            //{ }

            //using (var mgr = new UpdateManager("D:\\squirrel\\Project\\MyApp\\Releases"))
            //{
            //    await mgr.UpdateApp();
            //} test
            //https://github.com/TestSquirrel/MyApp
            try  
            {
                using (var mgr = UpdateManager.GitHubUpdateManager("https://github.com/TestSquirrel/MyApp", prerelease:true /*accessToken: "672e669504503a78358577280343cbdd2fb19dea"*/))
                {
                    var update = await mgr.Result.CheckForUpdate();
                    var gitversion = update.CurrentlyInstalledVersion.Version;
                    if(update.ReleasesToApply.Count() > 0)
                    {
                        await mgr.Result.UpdateApp();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
    }
}
