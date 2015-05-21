using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using Pacman.GameEngine;

namespace Pacman.WinForms
{
    static class Program
    {

        
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // для перехоплення exceptions раджу використати 
            Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException); 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new GameMenu());   
        }
        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message, "Pacman Exception");
        }
    }
}
