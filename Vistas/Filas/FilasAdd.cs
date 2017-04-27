using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SADI.Clases.Controladores;
using SADI.Clases.Modelos;


namespace SADI.Vistas.Filas
{
    public partial class FilasAdd : Form
    {
        FilasModel fm = new FilasModel();
        FilasController fc = new FilasController();

        public FilasAdd()
        {
            InitializeComponent();
        }

        private void FilasAdd_Load(object sender, EventArgs e)
        {
            catGeoCtrl.Opcion = 1;
            catGeoCtrl.ReLoad();
        }
        //Gaurdar los Datos
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if(catGeoCtrl.ValidarControl())
            {

            }
        }
        //Cerrar la forma
        private void cmdOUT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
