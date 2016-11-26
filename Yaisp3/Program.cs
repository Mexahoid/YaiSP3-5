using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Yaisp3
{
    static class Program
    {
        public static FormAgency formCreateAgency;
        public static FormMain formMain;
        public static FormCity formCity;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            formMain = new FormMain();
            formCreateAgency = new FormAgency();
            formCity = new FormCity();
            Application.Run(formMain);
        }
    }
}
