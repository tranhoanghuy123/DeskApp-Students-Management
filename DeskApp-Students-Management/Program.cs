using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DeskApp_Students_Management.Model;
using DeskApp_Students_Management.Presenters;
using DeskApp_Students_Management._Repositories;
using DeskApp_Students_Management.Views;
using System.Configuration;
namespace DeskApp_Students_Management
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["DeskApp_Students_Management.Properties.Settings.SqlConnection"].ConnectionString;
            IMainForm view = new MainForm();
            new MainFormPresenter(view, sqlConnectionString);
            Application.Run((Form)view);
            //Application.Run(new MainForm());
        }
    }
}
