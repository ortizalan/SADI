using System.Windows.Forms;
using SADI.Clases;
using SADI.Clases.Modelos;
using SADI.Clases.Controladores;
using System;

namespace SADI.Vistas.Niveles
{
    public partial class NivelAdd : Form
    {
        NivelesModel nm = new NivelesModel();
        NivelesController nc = new NivelesController();

        /// <summary>
        /// Constructor sin Recibir Parámetros
        /// </summary>
        public NivelAdd()
        {
            InitializeComponent();
        }

        private void NivelAdd_Load(object sender, System.EventArgs e)
        {
            catGeoCtrll.Opcion = 3;// Opción de Niveles en el Control

            if (nc.ObtenerUltimoId())//Consultar Sentencia SQL
            {
                //Consulta Exitosa
                if(nc.Tabla.Rows.Count > 0)// Verificar que existan registros
                {
                    catGeoCtrll.Id = ((int)nc.Tabla.Rows[0][0] + 1);// Si existen registros
                }
                else
                {
                    catGeoCtrll.Id = 1;// NO existen registros
                }
            }
            else//Consulta NO Exitosa
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + nc.Error,
                  ":: mensaje desde agregar nivel ::".ToUpper(),
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

            catGeoCtrll.ReLoad();//Cargar el control
        }
        //Botón Cerrar
        private void cmdOUT_Click(object sender, System.EventArgs e)
        {
            Close();
        }
        //Botón Agregar
        private void cmdIN_Click(object sender, System.EventArgs e)
        {
            if(catGeoCtrll.ValidarControl())//Validar el Control
            {
                LLenarObjetoNiveles();//LLenar el Objeto Niveles

                if(nc.IngresarRegisto(nm))//Ejecutar el Procedimiento
                {
                    //Ejecución Exitosa
                    DialogResult r = MessageBox.Show("se ingresó correctamente el registro.".ToUpper() + "\n" +
                        "¿desea ingresar otro registro?".ToUpper(), ":: mensaje desde agregar nivel ::".ToUpper(),
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question);// Preguntar si se ingresará otro registro
                    if(r == DialogResult.Yes)// Si se ingresará otro registro
                    {
                        catGeoCtrll.LimpiarControl();
                    }
                    else//No se ingresará otro registro
                    {
                        Close();
                    }
                }
                else//Ejecución NO Exitosa
                {
                    MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + nc.Error,
                        ":: mensaje desde agregar niveles::".ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
        }
        //Método para LLenar el Objeto Niveles
        private void LLenarObjetoNiveles()
        {
            nm.Id = catGeoCtrll.Id;// Identificador del Registro
            nm.Nivel = catGeoCtrll.Descripcion;//Descripción del Registro del Modelo
            nm.Foto = catGeoCtrll.Imagen;//Imagen del Registro
            nm.Formato = catGeoCtrll.Formato;//Formato de la Imagen del Registro
        }
    }
}
