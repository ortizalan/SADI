using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SADI.Clases.Modelos;
using SADI.Clases.Controladores;
using SADI.Clases;

namespace SADI.Vistas.SerieDocumental
{
    public partial class SerieDocumentalView : Form
    {
        #region Porpiedades de la Vista
        UsuariosModel um = new UsuariosModel();//Objeto del Modelo de Usuarios
        RegistrosModel rm = new RegistrosModel();//Objeto del Model de Registros
        RegistrosController rc = new RegistrosController();//Objeto del Controlador de Registros
        DigitalizacionesModel dm = new DigitalizacionesModel();//Objeto del tipo Digializaciones
        DigitalizacionesController dc = new DigitalizacionesController();//Objeto del Controlador Digitalizaciones
        #endregion

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public SerieDocumentalView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        /// <param name="u">Objeto del Tipo UsuarioModel</param>
        public SerieDocumentalView(UsuariosModel u)
        {
            InitializeComponent();
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            um = u;
            LLenarGridSeries();//Ir al método inicial
        }
        /// <summary>
        /// Método para LLenar el Grid de Series
        /// </summary>
        private void LLenarGridSeries()
        {
            rm.Usuario = um;//Asignar la propiedad Usuario al Modelo Registro

            if(rc.SeleccionarSeriesXUsuario(rm))//Intento de Consultar Registros
            {
                if (rc.Tabla.Rows.Count > 0)//Ver si trae resultados la consulta
                {
                    //Si existen registros
                    dgvSeries.DataSource = rc.Tabla;
                    dgvSeries = Utilerias.PropiedadesDataGridView(dgvSeries);//Pro-Formatear el Grid
                    dgvSeries.Columns[0].Width = 180;//tamaño de la primer columna
                    dgvSeries.Columns[1].Width = 250;//Tamaño de la segunda columna
                    dgvSeries.Columns[2].Width = 130;//tamaño de la tercer columna
                    dgvSeries.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;//Auto llenado de la cuarta columna
                    dgvSeries.CurrentCell = dgvSeries[0, 0];//Indicar el renglón seleccionado
                    if (dgvSeries.SelectedRows.Count > 0)
                    { LLenarObjetoDigitalizacion(dgvSeries.SelectedRows[0].Cells[0].Value.ToString()); }
                }
                else//No exiten registros
                {
                    MessageBox.Show("el usuario no tiene series documentales activas en el sistema".ToUpper(),":: mensaje desde ver series documentales ::",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);//Informarle al Usuario que no existen series documentales acticas en el sistema
                    Close();//Cerrar la ventana
                }
            }
            else//Intento No exitoso
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + rc.Error, ":: mensaje desde lista de registros ::".ToUpper(),
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            
        }
        //Salir de la Vista
        private void cmdOUT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Cambio de Selección
        private void dgvSeries_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //Método para el Llenado de los Documento Digitalizados
        private void BuscarDocumentosDigitalizados()
        {
            if(dc.ExpedientesPorSerieDoctal(dm))//Intentar la Consulta
            {
                if(dc.Tabla.Rows.Count > 0)//Verificar si existen registros para esa Serie Documental
                {
                    dgvDigitalizados.DataSource = dc.Tabla;
                    dgvDigitalizados = Utilerias.PropiedadesDataGridView(dgvDigitalizados);
                }
                else//NO se econtró registro
                {
                    MessageBox.Show("no existen documentos digitalizados para esta serie documental".ToUpper(),
                        ":: mensaje desde cosultar series doumentales ::".ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }
            else//Consulta NO Exitosa
            {
                MessageBox.Show("ocurrió el siguienre error :".ToUpper() + "\n" + rc.Error,
                    ":: mensaje desde consultar series documentales ::".ToUpper(),
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;//Salir de 
            }
        }
        /// <summary>
        /// Asignar la Serie Documental al Modelo Digitalizacion
        /// </summary>
        private void LLenarObjetoDigitalizacion(string serie)
        {
            if(!string.IsNullOrEmpty(serie))
            {
                dm.SDoctal.SerieDoctal = serie;
                BuscarDocumentosDigitalizados();
            }
        }
    }
}

