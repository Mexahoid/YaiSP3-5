using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace AgencySimulator.Main
{
    static class Program
    {
        public static FormMain formMain;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formMain = new FormMain();
            Application.Run(formMain);
        }
    }
}
