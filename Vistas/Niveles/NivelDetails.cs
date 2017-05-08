using System.Windows.Forms;
using SADI.Clases;
using SADI.Clases.Modelos;
using SADI.Clases.Controladores;
using System;

namespace SADI.Vistas.Niveles
{
    public partial class NivelDetails : Form
    {
        NivelesController nc = new NivelesController();//Instancia del Controlador
        NivelesModel nm = new NivelesModel();// Instancia del Modelo

        /// <summary>
        /// Constructor de la Forma 
        /// </summary>
        public NivelDetails()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Costructor que recibe parámetro 
        /// </summary>
        /// <param name="id">Identificador del Modelo Niveles</param>
        public NivelDetails(int id)
        {
            InitializeComponent();

            nm.Id = id;//Asignar el Identificador del modelo
            if(nc.ConsultarRegistro(nm))// Intentar la Consulta del Modelo
            {
                //Intento Exitoso
                LLenarObjetoNiveles();
            }
            else//Intento NO Exitoso, Consultar Error
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + nc.Error,":: mensaje desde detalles nivel ::".ToUpper(),
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                Close();
            }
        }
        /// <summary>
        /// Método para llenar el Objeto Niveles
        /// </summary>
        private void LLenarObjetoNiveles()
        {
           if(nc.Tabla.Rows.Count > 0)//Verificar si existe registro
            {
                nm.Id = (int)nc.Tabla.Rows[0][0];//Obtener el Identificador
                nm.Nivel = nc.Tabla.Rows[0][1].ToString();//Obtener la descripción
                nm.Foto = Utilerias.Base64toImagen(nc.Tabla.Rows[0][2].ToString());//Obtener la Imagen

                LLenarControl();//LLenar el Control
            }
           else//No existe Registro
            {
                MessageBox.Show("no existe registro solicitado.".ToUpper(),":: mensaje desde detalles nivel ::".ToUpper(),
                    MessageBoxButtons.OK,MessageBoxIcon.Information);
                Close();
            }
        }
        /// <summary>
        /// Método para llenar el Control
        /// </summary>
        private void LLenarControl()
        {
            catGeoCtrll.Opcion = 3;//Indicar la Opción
            catGeoCtrll.Id = nm.Id;// Indicarel Identificador
            catGeoCtrll.Descripcion = nm.Nivel;// Indicar el Nivel
            catGeoCtrll.Imagen = nm.Foto;//Enviarle la Imagen   
            catGeoCtrll.ReLoad();//Cargar la infromación al control
        }
        // Botón Cerrar Forma
        private void cmdOUT_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
