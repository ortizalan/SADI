using System.Windows.Forms;
using SADI.Clases;
using SADI.Clases.Modelos;
using SADI.Clases.Controladores;
using System;

namespace SADI.Vistas.Estantes
{
   
    public partial class EstanteEdit : Form
    {
        EstantesModel em = new EstantesModel();
        EstantesController ec = new EstantesController();

        /// <summary>
        /// Constructor sin Parámetros
        /// </summary>
        public EstanteEdit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor que recibe Parámetros
        /// </summary>
        /// <param name="id">Identificador del Modleo</param>
        public EstanteEdit(int id)
        {
            InitializeComponent();
            em.Id = id;// Indicarle el identificador al Modelo
            if(ec.ConsultarRegistro(em))//Consultar el registro
            {
                //Consulta Exitosa
                LLenarObjetoEstante();
            }
            else
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + ec.Error,
                    ":: mensaje desde editar estante ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
        /// <summary>
        /// LLenar el Objeto Estante
        /// </summary>
        private void LLenarObjetoEstante()
        {
            if(ec.Tabla.Rows.Count > 0)// Verificar que cuenta con registro
            {
                // Si existe el registro
                em.Id = (int)ec.Tabla.Rows[0][0];
                em.Estante = ec.Tabla.Rows[0][1].ToString();
                em.Foto = Utilerias.Base64toImagen(ec.Tabla.Rows[0][2].ToString());

                LLenarControlCerGeo();
            }
            else//No existe el registro
            {
                MessageBox.Show("no existe registro.".ToUpper(), ":: mensaje desde editar estante ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
        /// <summary>
        /// LLenar el Control del Catálogo
        /// </summary>
        private void LLenarControlCerGeo()
        {
            catGeoCtrll.Opcion = 2;
            catGeoCtrll.Id = em.Id;
            catGeoCtrll.Descripcion = em.Estante;
            catGeoCtrll.Imagen = em.Foto;
            catGeoCtrll.ReLoad();// Llenar el control
        }
        /// <summary>
        /// Botón Editar
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdEDIT_Click(object sender, EventArgs e)
        {
            if(catGeoCtrll.ValidarControl())//Validar los campos del Control
            {
                DeControlAObjeto();//Llenar el Objeto

                if(ec.ActualizarRegistro(em))
                {
                    MessageBox.Show("se actualizaron los datos con éxito.".ToUpper(), ":: mensaje desde editar estante ::".ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                else
                {
                    MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + ec.Error,
                        ":: mensaje desde editar estante ::".ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                }
            }
            
        }
        // LLenar el Objeto Estante desde el Modelo
        private void DeControlAObjeto()
        {
            em.Id = catGeoCtrll.Id;//Identificador del Modelo
            em.Estante = catGeoCtrll.Descripcion;//Descripción del Estante
            em.Foto = catGeoCtrll.Imagen;// Imagen del Estante
            em.Formato = catGeoCtrll.Formato;//Formato de la Imagen
        }
        //Botón Cerrar
        private void cmdOUT_Click(object sender, EventArgs e)
        {
            Close();//Cerrar
        }
    }
}
