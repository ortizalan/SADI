using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using SADI.Vistas.Home;
using SADI.Vistas.Atributos;

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
            //    Application.Run(new Inicio());
            //}

            //Application.Run(new AtributosAdd(4));
            Application.Run(new Inicio());
            //Application.Run(new Vistas.Temas.TemasAdd());
        }
    }
}
