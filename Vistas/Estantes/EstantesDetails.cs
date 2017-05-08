using System.Windows.Forms;
using SADI.Clases;
using SADI.Clases.Modelos;
using SADI.Clases.Controladores;

namespace SADI.Vistas.Estantes
{
    public partial class EstantesDetails : Form
    {
        //int id;
        EstantesModel em = new EstantesModel();
        EstantesController ec = new EstantesController(); 
        /// <summary>
        /// Constructor que no Recibe Parámetros
        /// </summary>
        public EstantesDetails()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor que Recibe Parámetros
        /// </summary>
        /// <param name="id">Entero, Identificador del Estante</param>
        public EstantesDetails(int ID)
        {
            InitializeComponent();
            em.Id = ID;// Indicar el ID al Modelo
            if (ec.ConsultarRegistro(em))// Intentar consultar el registro del modelo
            {
                // Intento exitoso
                this.LLenarObjeto();
            }
            else// Intento NO exitoso, Consultar Error
            {
                MessageBox.Show("ocurrió elsiguiente error :".ToUpper() + "\n" + ec.Error,
                    ":: mensaje desde detalles del estante ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
        //Método para llenar el Objeto Estante
        private void LLenarObjeto()
        {
            if(ec.Tabla.Rows.Count > 0)// Si tiene registro
            {
                em.Id = (int)ec.Tabla.Rows[0][0];
                em.Estante = ec.Tabla.Rows[0][1].ToString();
                em.Foto = Utilerias.Base64toImagen(ec.Tabla.Rows[0][2].ToString());

                this.DeObjetoaControl();
            }
            else// Si no tiene registro
            {
                MessageBox.Show("no existen registros.".ToUpper(), ":: mensaje desde detalles de estante ::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
        //Del Objeto al Control
        private void DeObjetoaControl()
        {
            catGeoCtrll.Opcion = 2;// Indicarle la Opción al Control
            catGeoCtrll.Id = em.Id;// Identificador del Estante
            catGeoCtrll.Descripcion = em.Estante;//Descripción del Estante
            catGeoCtrll.Imagen = em.Foto;// Imagen del Estante
        }
        //Botón Salir
        private void cmdOUT_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
