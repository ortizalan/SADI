using System.Windows.Forms;
using SADI.Clases;
using SADI.Clases.Modelos;
using SADI.Clases.Controladores;
using System;

namespace SADI.Vistas.Niveles
{
    public partial class NivelEdit : Form
    {
        NivelesController nc = new NivelesController();
        NivelesModel nm = new NivelesModel();

        /// <summary>
        /// Constructor de la Forma
        /// </summary>
        public NivelEdit()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor de la Forma que recibe Parámetro
        /// </summary>
        /// <param name="id">Identificador del Nivel</param>
        public NivelEdit(int id)
        {
            InitializeComponent();

            nm.Id = id;// Indicar el identificador del modelo

            if(nc.ConsultarRegistro(nm))//Intentar la Consulta
            {
                //Consulta Exitosa
                LLenarObjetoNivel();//LLenar el Objeto Niveles
            }
            else//Consulta NO Exitosa, Consultar Error
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + nc.Error,
                    ":: mensaje desde editar nivel ::".ToUpper(),MessageBoxButtons.OK,MessageBoxIcon.Error);
                Close();

            }
        }
        /// <summary>
        /// Método para LLenar el Objeto NivelesModel
        /// </summary>
        private void LLenarObjetoNivel()
        {
            if (nc.Tabla.Rows.Count > 0)//Verificar si tiene registros la tabla
            {
                nm.Id = (int)nc.Tabla.Rows[0][0];// Identificador del Registro del Modeo
                nm.Nivel = nc.Tabla.Rows[0][1].ToString();// Descripción del Registro
                nm.Foto = Utilerias.Base64toImagen(nc.Tabla.Rows[0][2].ToString());// Imagen del Registro

                LLenarControl();
            }
            else//No trae registro la tabla
            {
                MessageBox.Show("no existe registro en el modelo.".ToUpper(),":: mensaje desde editar nivel ::",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
        /// <summary>
        /// Método para LLenar el Control con el Objeto
        /// </summary>
        private void LLenarControl()
        {
            catRegCtrll.Opcion = 3;// Opción a Ejecutar dentro del Control
            catRegCtrll.Id = nm.Id;// Identificador del Registro
            catRegCtrll.Descripcion = nm.Nivel;// Descripción del Registro
            catRegCtrll.Imagen = nm.Foto;//Imagen del registro
        }
        //Botón Cerrar
        private void cmdOUT_Click(object sender, EventArgs e)
        {
            Close();
        }
        // Botón Editar
        private void cmdEdit_Click(object sender, EventArgs e)
        {
            if (catRegCtrll.ValidarControl())//Validar los campos del control
            {
                DeControlAObjeto();//Enviar los datos del Control al Objeto

                if (nm.Formato != null)// Verificar que el Formato de la Imagen no esté vacío
                {
                    if(nc.ActualizarRegistro(nm))
                    {
                        MessageBox.Show("se actualizó el registro con éxito.".ToUpper(),":: mensaje desde editar nivel ::".ToUpper(),
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("ocurrió el siguiente error.".ToUpper(),":: mensaje desde editar nivel ::".ToUpper(),
                            MessageBoxButtons.OK,MessageBoxIcon.Error);
                    }
                }
                else//El Formato de la Imagen está Vacío
                {
                    MessageBox.Show("debe de seleccionar una nueva imagen.".ToUpper(), ":: mensaje desde editar nivel ::".ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DeControlAObjeto()
        {
            nm.Id = catRegCtrll.Id;// Identificador del Registro
            nm.Nivel = catRegCtrll.Descripcion;//Descripción del Registro
            nm.Foto = catRegCtrll.Imagen;//Imagen del Registro
            nm.Formato = catRegCtrll.Formato;//Formato de la Imagen
        }
    }
}
