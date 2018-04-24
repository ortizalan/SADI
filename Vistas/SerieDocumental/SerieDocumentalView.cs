using System;
using System.IO;
using System.IO.IsolatedStorage;
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
using SADI.Vistas.Digitalizacion;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.PowerPoint;

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

            if (rc.SeleccionarSeriesXUsuario(rm))//Intento de Consultar Registros
            {
                if (rc.Tabla.Rows.Count > 0)//Ver si trae resultados la consulta
                {
                    //Si existen registros
                    dgvSeries.DataSource = rc.Tabla;
                    dgvSeries = Utilerias.PropiedadesDataGridView(dgvSeries);//Pro-Formatear el Grid
                    dgvSeries.Columns[0].Width = 180;//tamaño de la primer columna
                    dgvSeries.Columns[1].Width = 250;//Tamaño de la segunda columna
                    dgvSeries.Columns[2].Width = 250;//tamaño de la tercer columna
                    dgvSeries.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;//Auto llenado de la cuarta columna
                    dgvSeries.CurrentCell = dgvSeries[0, 0];//Indicar el renglón seleccionado
                    if (dgvSeries.SelectedRows.Count > 0)
                    { LLenarObjetoDigitalizacion(dgvSeries.SelectedRows[0].Cells[0].Value.ToString()); }
                }
                else//No exiten registros
                {
                    MessageBox.Show("el usuario no tiene series documentales activas en el sistema".ToUpper(), ":: mensaje desde ver series documentales ::",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);//Informarle al Usuario que no existen series documentales acticas en el sistema
                    Close();//Cerrar la ventana
                }
            }
            else//Intento No exitoso
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + rc.Error, ":: mensaje desde lista de registros ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
        //Salir de la Vista
        private void cmdOUT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //Método para el Llenado de los Documento Digitalizados
        private void BuscarDocumentosDigitalizados()
        {
            if (dc.ExpedientesPorSerieDoctal(dm))//Intentar la Consulta
            {
                if (dc.Tabla.Rows.Count > 0)//Verificar si existen registros para esa Serie Documental
                {
                    dgvDigitalizados.DataSource = dc.Tabla;//Asignar la tabla al Grid
                    dgvDigitalizados = Utilerias.PropiedadesDataGridView(dgvDigitalizados);//Pre-Formato del Grid
                    dgvDigitalizados.Columns[0].Visible = false;//Ocultar el identificador del documento
                    dgvDigitalizados.Columns[1].Width = 300;

                    DataGridViewButtonColumn dgvBtn = new DataGridViewButtonColumn();//Creae un botón del tipo datagrdview
                    dgvBtn.HeaderText = "ver archivos".ToUpper();//Texto del encabezado de la columna
                    dgvBtn.Text = "ver archivo".ToUpper();//texto del boton
                    dgvBtn.UseColumnTextForButtonValue = true;//Mostrar el valor de la columna como un Botón
                    dgvBtn.Name = "btn";
                    dgvDigitalizados.Columns.Add(dgvBtn);//Agregar la columna al Grid


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
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;//Salir de 
            }
        }
        /// <summary>
        /// Asignar la Serie Documental al Modelo Digitalizacion
        /// </summary>
        private void LLenarObjetoDigitalizacion(string serie)
        {
            if (!string.IsNullOrEmpty(serie))
            {
                dm.SDoctal.SerieDoctal = serie;
                BuscarDocumentosDigitalizados();
            }
        }
        /// <summary>
        /// Método para Visualizar el Archivo Digitalizado
        /// </summary>
        private void dgvDigitalizados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)//Validar que sea la columna del tipo botón que agregamos
            {
                //MessageBox.Show(dgvDigitalizados.SelectedRows[0].Cells[0].Value.ToString());
                DesencryptarArchivo((int)dgvDigitalizados.SelectedRows[0].Cells[0].Value);
            }
        }
        /// <summary>
        /// Método para la consulta de una nueva serie documental
        /// </summary>
        private void dgvSeries_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSeries.SelectedRows.Count > 0)//Asegurarnos de que exista un renglón seleccionado en el grid
            {
                if (!string.IsNullOrEmpty(dgvSeries.SelectedRows[0].Cells[0].Value.ToString()))//asegurarnos de que exista un serie documental seleccionada
                {
                    dm.SDoctal.SerieDoctal = dgvSeries.SelectedRows[0].Cells[0].Value.ToString();//Agregar la serie al objeto digitalización
                    if (dgvDigitalizados.Columns.Count > 0)//Verificar que no esté vacío el grid digitalizados
                    {
                        dgvDigitalizados.Columns.Clear();//vaciar el grid
                    }
                    this.BuscarDocumentosDigitalizados();//Mandar llenar el grid
                }
            }
        }
        /// <summary>
        /// Función para Desencryptar el Archivo Digitalizado
        /// </summary>
        /// <param name="id">Identificador del Archivo Digitalizado</param>
        /// <returns>Boolean</returns>
        private bool DesencryptarArchivo(int id)
        {
            dm.Id = id;

            if (dc.ConsultarRegistro(dm))
            {

                object objFile = Path.Combine(Path.GetTempPath(), dc.Tabla.Rows[0][3].ToString());
                //object objFile = Path.Combine(Path.GetTempPath(), dc.Tabla.Rows[0][3].ToString());
                byte[] fileBytes = Utilerias.Base64ToBytes(dc.Tabla.Rows[0][2].ToString());
                //var tmpFile = Path.GetTempPath();
                //var doc = File.WriteAllBytes(tmpFile,fileBytes);
                string tmpFile = (string)objFile;

                FileStream fs = new FileStream(tmpFile, FileMode.Create, FileAccess.Write);
                fs.Write(fileBytes, 0, fileBytes.Length);
                //fs.Seek(0, SeekOrigin.Begin);
                Utilerias.Path = fs.Name;
                fs.Close();
                VisorOffice visor = new VisorOffice();
                visor.MdiParent = this.MdiParent;
                visor.Show();

            }
            else
            {
                MessageBox.Show("ocurrió el siguiente error :" + "\n" + dc.Error.ToUpper(),
                    ":: mensaje desde la función desencryptar archivo ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return false;
        }

        private void SerieDocumentalView_Load(object sender, EventArgs e)
        {

        }

        private void SerieDocumentalView_Enter(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        
    }
}

