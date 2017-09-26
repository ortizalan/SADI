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
using SADI.Clases.Modelos;
using SADI.Clases.Controladores;

namespace SADI.Vistas.Estantes
{
    public partial class EstanteAdd : Form
    {
        EstantesModel em = new EstantesModel();
        EstantesController ec = new EstantesController();

        public EstanteAdd()
        {
            InitializeComponent();
        }
        //Botón Ingresar
        private void cmdIn_Click(object sender, EventArgs e)
        {
           if(catGeoCtrll.ValidarControl())//Validar los Campos del Control
            {
                DeCtrlaObjeto();// Llenar el Objeto con los datos del control
                
                if(ec.IngresarRegisto(em))//Intentar ingresar el registro
                {
                    //Intento Exitoso
                    DialogResult r;// Guardar respuesta de pregunta a realizar
                    //Realizar la pregunta
                    r = MessageBox.Show("se ingresó el registro exitosamente.".ToUpper() + "\n" +
                        "¿desea ingresar otro registro?".ToUpper(),":: mensaje desde agregar estante ::",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if(r == DialogResult.Yes)//Respuesta
                    {
                        //Respuesta afirmativa
                        catGeoCtrll.LimpiarControl();//Limpiar el contro
                        this.EstanteAdd_Load(sender, e);// Reecargar la forma
                    }
                    else//Respuesta Negativa
                    {
                        Close();
                    }
                }
                else// Intento fallido, Consulte Error
                {
                    MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + ec.Error,
                        ":: mensaje desde agregar estante ::".ToUpper(),
                        MessageBoxButtons.OK,MessageBoxIcon.Error);
                    Close();
                }
                
            }
        }
        //Botón Salir
        private void cmdOut_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EstanteAdd_Load(object sender, EventArgs e)
        {
            catGeoCtrll.Opcion = 2;

            if (ec.ObtenerUltimoId())//Obtener el Último ID en el Modelo de Estantes
            {
                if (ec.Tabla.Rows.Count > 0)// Si cuenta con registros la tabla
                {
                    catGeoCtrll.Id = ((int)ec.Tabla.Rows[0][0]) + 1;
                }
                else// Si no cuenta con registros la tabla
                {
                    catGeoCtrll.Id = 1;
                }
            }
            else// Intento Fallido
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + ec.Error,
                    ":: mensaje desde agregar estante ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            catGeoCtrll.ReLoad();
        }
        /// <summary>
        /// Método para cargar la Información del Control al Objeto
        /// </summary>
        private void DeCtrlaObjeto()
        {
            em.Id = catGeoCtrll.Id;
            em.Estante = catGeoCtrll.Descripcion;
            em.Foto = catGeoCtrll.Imagen;
            em.Formato = catGeoCtrll.Formato;
        }
      
    }
}
