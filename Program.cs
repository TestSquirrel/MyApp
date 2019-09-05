using Squirrel;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //var version = typeof(Program).Assembly.GetName().Version.ToString();
            //if(version == "1.0.1")
            //{ }

            //using (var mgr = new UpdateManager("D:\\squirrel\\Project\\MyApp\\Releases"))
            //{
            //    await mgr.UpdateApp();
            //}
            try
            {
                using (var mgr = UpdateManager.GitHubUpdateManager("https://github.com/Sameer2810/MyApp"))
                {
                    await mgr.Result.UpdateApp();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
           
        }
    }
}
