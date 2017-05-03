using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SADI.Clases;
using SADI.Clases.Controladores;
using SADI.Clases.Modelos;

namespace SADI.Vistas.Filas
{
    public partial class FilasEdit : Form
    {
        FilasModel fm = new FilasModel();
        FilasController fc = new FilasController();

        /// <summary>
        /// Constructor Sin Parámetros
        /// </summary>
        public FilasEdit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor que Recibe el Identificador del Modelo Filas
        /// </summary>
        /// <param name="id">Entero</param>
        public FilasEdit(int id)
        {
            InitializeComponent();
            fm.Id = id;
            if (fc.ConsultarRegistro(fm))
            {
                this.llenarObjeto();
            }
            else
            {
                MessageBox.Show("error : " + fc.Error);
            }
        }

        //LLenar el Objeto FilasModel
        private void llenarObjeto()
        {

            if (fc.Tabla.Rows.Count > 0)
            {
                fm.Id = (int)fc.Tabla.Rows[0][0];
                fm.Fila = fc.Tabla.Rows[0][1].ToString();
                fm.Foto = Utilerias.Base64toImagen(fc.Tabla.Rows[0][2].ToString());
                this.llenarControlGeo();
            }
            else
            {
                MessageBox.Show("la tabla está vacía");
            }
        }


        //Llenar control con infromación del objeto FilasModel
        private void llenarControlGeo()
        {
            catGeoCtrll.Opcion = 1;
            catGeoCtrll.Id = fm.Id;
            catGeoCtrll.Descripcion = fm.Fila;
            catGeoCtrll.Imagen = fm.Foto;
        }
        //Mandar Editar
        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (catGeoCtrll.ValidarControl())
            {
                this.llenarObjetoDesdeControl();
                if (fc.ActualizarRegistro(fm))
                {
                    DialogResult r;
                    r = MessageBox.Show("¿desea seguir editando registros?".ToUpper(), ":: mensaje desde editar filas ::".ToUpper(),
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {

                    }
                    else
                    { this.Close(); }
                }
                else
                {
                    MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" +
                        fc.Error, "mensaje desde editar fle".ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        //LLenar el Objeto FilasModel desde el COntrol de Usuario
        private void llenarObjetoDesdeControl()
        {
            fm.Id = catGeoCtrll.Id;
            fm.Fila = catGeoCtrll.Descripcion;
            fm.Foto = catGeoCtrll.Imagen;
            fm.Formato = catGeoCtrll.Formato;
        }
        //Salir de la Forma
        private void cmdOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
