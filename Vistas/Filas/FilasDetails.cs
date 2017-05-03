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
using SADI.Clases;

namespace SADI.Vistas.Filas
{
    public partial class FilasDetails : Form
    {
        FilasController fc = new FilasController();
        FilasModel fm = new FilasModel();
        public FilasDetails()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Contructor que recibe el identificador de la Fila
        /// </summary>
        /// <param name="id">Entero</param>
        public FilasDetails(int id)
        {
            InitializeComponent();

            fm.Id = id;
            if (fc.ConsultarRegistro(fm))
            {
                this.LlenarObjeto();
            }
            else
            {
                MessageBox.Show("error : " + fc.Error);
            }
        }

        private void LlenarObjeto()
        {
            if (fc.Tabla.Rows.Count > 0)
            {
                fm.Id = (int)fc.Tabla.Rows[0][0];
                fm.Fila = fc.Tabla.Rows[0][1].ToString();
                fm.Foto = Utilerias.Base64toImagen(fc.Tabla.Rows[0][2].ToString());
                this.LlenarControl();
            }
            else
            {
                MessageBox.Show("quiubo, no hay ni madre");
            }
        }

        private void LlenarControl()
        {
            catGeoCtrll.Opcion = 1;
            catGeoCtrll.Id = fm.Id;
            catGeoCtrll.Descripcion = fm.Fila;
            catGeoCtrll.Imagen = fm.Foto;
        }

        private void cmdOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
