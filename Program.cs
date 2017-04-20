using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SADI.Vistas.Home;

namespace SADI
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

            //Inicio inicio = new Inicio();
            //Login logon = new Login();
            //DialogResult result = logon.ShowDialog();

            //if (result == DialogResult.OK)
            //{
                Application.Run(new Inicio());
            //}
        }
    }
}
