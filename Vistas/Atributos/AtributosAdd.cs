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
using SADI.Vistas.Temas;

namespace SADI.Vistas.Atributos
{
    //public delegate void delegado(int v1, string v2);//Declaración del Delegado
    //public delegado Delegado; //Instancia del Delegado

    public partial class AtributosAdd : Form
    {
        AtributosModel am = new AtributosModel();// Modelo de Atributos
        AtributosController ac = new AtributosController();// Controlador de Atributos
        UsuariosModel um = new UsuariosModel();// Modelo de Usuarios
        UsuariosController uc = new UsuariosController();//Controlador de Usuarios
        SeccionesModel secm = new SeccionesModel();//Modelo de las Secciones
        SeccionesController secc = new SeccionesController();//Controlador de las Secciones
        SeriesModel serm = new SeriesModel();//Modelo de las Series
        SeriesController serc = new SeriesController();//Controlador de las Series
        TemasModel tm = new TemasModel();//Modelo de los Temas
        TemasController tc = new TemasController();//Controlador de los Temas

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public AtributosAdd()
        {
            InitializeComponent();
            cmdADDTema.Enabled = false;
            cmdADDTema.Visible = false;
            //Delegado = new delegado(EnvioValorTemaXSerie);//Asignación del Método al Delegado
            dgvSeries.DataBindings.CollectionChanged += new CollectionChangeEventHandler(Rows_CollectionChanged);
        }

        private void Rows_CollectionChanged(object sender, CollectionChangeEventArgs e)
        {
            if(dgvSeries.Rows.Count == 0)
            {
                dgvTemas.DataSource = null;
                dgvTemas.Columns.Clear();
            }
        }
        /// <summary>
        /// Contructor de la Clase
        /// </summary>
        /// <param name="idUsr">Id de Usuario</param>
        public AtributosAdd(int idUsr)
        {
            InitializeComponent();
            cmdADDTema.Enabled = false;
            cmdADDTema.Visible = false;
            um.Id = idUsr;
            if (uc.ConsultarRegistro(um))//Intentar la consulta del Registro del Usuario
            { LLenarObjetoUsuario(); }//Intento Exitoso
            else//Intento NO Exitoso, consultar Error
            {
                MessageBox.Show("ócurrió el sigueinte error :".ToUpper() + "\n" + uc.Error, ":: mensaje desde agregar atributos ::".ToUpper(),
                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();//Cerrar ventana
            }
            if (secc.ConsultarRegistros())//Intentar consultar los registros
            {
                //Intento Exitoso
                if (secc.Tabla.Rows.Count > 0)//Verificar que existen 
                { LLenarGridSecciones(); }
                else
                {
                    MessageBox.Show("no existen registros.".ToUpper(), ":: mensaje desde agregar atributos ::",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            else//Intento NO Exitoso
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + secc.Error, ":: mensaje desde agregar atributos ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

        }
        /// <summary>
        /// Método para LLenar el Grid Secciones
        /// </summary>
        private void LLenarGridSecciones()
        {
            //AgergarValidacionTabla();//Mandar agregar columna Validación a la Tabla Secciones
            dgvSecciones.DataSource = secc.Tabla;
            dgvSecciones = Utilerias.PropiedadesDataGridView(dgvSecciones);
            AgregarColumnaValidarGridSecciones();
            dgvSecciones.Columns[0].Visible = false;
            dgvSecciones.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        }
        /// <summary>
        /// Agregar Columna para Validaciones
        /// </summary>
        private void AgregarColumnaValidarGridSecciones()
        {
            DataGridViewCheckBoxColumn dgvCol = new DataGridViewCheckBoxColumn();
            dgvCol.ValueType = typeof(bool);
            dgvCol.TrueValue = true;
            dgvCol.FalseValue = false;
            dgvCol.Name = "Sel";
            dgvCol.HeaderText = "Selección";
            dgvCol.ReadOnly = false;
            dgvSecciones.Columns.Insert(2, dgvCol);
            //DataGridViewColumn col = new DataGridViewColumn();
            //col..
            //col.Name = "Sel";
            //dgvSecciones.Columns.Insert(2, col);
            //foreach(DataRow row in dgvSecciones.Rows)
            //{
            //    row["Sel"] = false;
            //}
        }
        /// <summary>
        /// LLenar el Objeto Usuario
        /// </summary>
        private void LLenarObjetoUsuario()
        {
            if (uc.Tabla.Rows.Count > 0)//Verificar que se cuente con un registro
            {
                um.Id = (int)uc.Tabla.Rows[0][0];//Identificador del Usuario
                um.Usuario = uc.Tabla.Rows[0][1].ToString();//Usuario
                um.Nombre = uc.Tabla.Rows[0][3].ToString();//Nombre del Usuario
                um.Paterno = uc.Tabla.Rows[0][4].ToString();//Apellido Paterno
                um.Materno = uc.Tabla.Rows[0][5].ToString();//Apellido Materno

                lblUsuario.Text += um.Nombre + ' ' + um.Paterno + ' ' + um.Materno;
            }
            else//NO existen registros
            {
                MessageBox.Show("no existen registros con ese identificador.".ToUpper(), ":: mensaje desde agregar atributos ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Close();//Cerrar la Forma
            }
        }
        /// <summary>
        /// Cerrar la Forma
        /// </summary>
        private void cmdOUT_Click(object sender, EventArgs e)
        {
            
            Close();
        }
        /// <summary>
        /// LLenar el Grid de las Series
        /// </summary>
        /// <param name="value"></param>
        private void EnvioValorSeriesXSeccion(string value)
        {
            serm.Seccion.Id = value;//Agregar el Identificador de la Sección al Modelo Series

            if (serc.ConsultarSeriesPorSeccion(serm))//Intentar la Cosnulta
            {
                //Intento Exitoso
                if (serc.Tabla.Rows.Count > 0)//Verificar que la Tabla tenga registros
                {
                    //Si cuenta con Registros
                    LLenarGridSeries();
                }
                else//No cuenta con Registros
                {
                    MessageBox.Show("no se cuenta con registros de series para la sección.".ToUpper(),
                        ":: mensaje desde agregar atributos ::".ToUpper(), MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            else//Intento NO Exitoso
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + serc.Error, ":: mensaje desde ingresar atributos ::",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
        /// <summary>
        /// Método LLenar el Grid de Series
        /// </summary>
        private void LLenarGridSeries()
        {
            dgvSeries.DataSource = serc.Tabla;
            dgvSeries = Utilerias.PropiedadesDataGridView(dgvSeries);
            AgregarColumnaValidarGridSeires();
            dgvSeries.Columns[0].Visible = false;
            dgvSeries.Columns[1].Width = 50;
            dgvSeries.Columns[2].Width = 267;
            dgvSeries.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        /// <summary>
        /// Método para Agregar Cpumna con Valores de CheckBoc
        /// </summary>
        private void AgregarColumnaValidarGridSeires()
        {
            DataGridViewCheckBoxColumn dgvColSer = new DataGridViewCheckBoxColumn();
            dgvColSer.ValueType = typeof(bool);
            dgvColSer.TrueValue = true;
            dgvColSer.FalseValue = false;
            dgvColSer.Name = "Sel";
            dgvColSer.HeaderText = "Selección";
            dgvSeries.Columns.Insert(3, dgvColSer);
        }
        /// <summary>
        /// Cambio de valor del Checkbox en Grid Secciones
        /// </summary> 
        private void dgvSecciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvSecciones.SelectedRows[0].Cells[e.ColumnIndex];
            if (chk.Value == chk.FalseValue || chk.Value == null)
            {
                chk.Value = chk.TrueValue;// Cambiar el Valor a Verdadero
                EnvioValorSeriesXSeccion((string)dgvSecciones.SelectedRows[0].Cells["Id"].Value);
            }
            else
            {
                chk.Value = chk.FalseValue;//CAmbiar el Valor a Falso
                dgvSeries.DataSource = null;
                dgvSeries.Columns.Clear();
                dgvTemas.DataSource = null;
                dgvTemas.Columns.Clear();
            }
        }
        /// <summary>
        /// Cambio de Valor del Checkbox en Grid Series
        /// </summary>
        private void dgvSeries_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell chkSer = (DataGridViewCheckBoxCell)dgvSeries.SelectedRows[0].Cells[e.ColumnIndex];
            if (chkSer.Value == chkSer.FalseValue || chkSer.Value == null)
            {
                chkSer.Value = chkSer.TrueValue;//Cambiar el Valor a Verdadero
                EnvioValorTemaXSerie((int)dgvSeries.SelectedRows[0].Cells["idSerie"].Value,
                    (string)dgvSeries.SelectedRows[0].Cells["Seccion"].Value);
            }
            else
            {
                chkSer.Value = chkSer.FalseValue;//Cambiar del Valor a Falso
                dgvTemas.DataSource = null;
                dgvTemas.Columns.Clear();
            }
        }
        /// <summary>
        /// Enviar los Parámetros para Seleccionar Tema por Serie y Sección
        /// </summary>
        /// <param name="value1">Id de la Serie</param>
        /// <param name="value2">Id de la Sección</param>
        private void EnvioValorTemaXSerie(int value1, string value2)
        {
            tm.Serie.Id = value1;//Indicar la Serie
            tm.Seccion.Id = value2;//Indicar la Sección

            if (tc.ConsultarTemaXSerieSeccion(tm))//Intentar la Consulta
            {
                //Intento Exitoso
                if (tc.Tabla.Rows.Count > 0)//Ver que existan registros
                {
                    LLenarGridTemas();
                    cmdADDTema.Enabled = true;
                    cmdADDTema.Visible = true;
                }
                else// NO existen registros
                {
                    if (!cmdADDTema.Enabled)
                    {
                        DialogResult r;
                        r = MessageBox.Show("no existen registros para esa sección y serie".ToUpper() + "\n" +
                            "¿desea ingresar un tema a la serie?".ToUpper(),
                            ":: mensaje desde ingresar atributos ::".ToUpper(),
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (r == DialogResult.Yes)
                        {
                            if (cmdADDTema.Enabled == false)
                            {
                                cmdADDTema.Enabled = true;
                                cmdADDTema.Visible = true;
                                EventArgs ev = null;
                                cmdADDTema_Click(this, ev);
                            }

                            //this.Enabled = false;
                        }
                        else
                        {
                            Close();
                        }
                    }
                }
            }
            else//Intento NO Exitoso, Consultar Error
            {
                MessageBox.Show("ocurrió el sigueinte error :".ToUpper() + "\n" + tc.Error, ":: mensaje desde ingresar atributos ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
        /// <summary>
        /// Método para llenar el Grid Temas con las Opciones Seleccionadas
        /// </summary>
        private void LLenarGridTemas()
        {
            dgvTemas.DataSource = tc.Tabla;
            dgvTemas = Utilerias.PropiedadesDataGridView(dgvTemas);
            AgregarColumnaValidarGridTemas();
            dgvTemas.Columns[0].Visible = false;
            dgvTemas.Columns[1].Width = 50;
            dgvTemas.Columns[1].HeaderText = "Id Serie";
            dgvTemas.Columns[2].Width = 50;
            dgvTemas.Columns[3].Width = 210;
            dgvTemas.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
        /// <summary>
        /// Método para Ingresar una Columna
        /// </summary>
        private void AgregarColumnaValidarGridTemas()
        {
            DataGridViewCheckBoxColumn dgvcolt = new DataGridViewCheckBoxColumn();
            dgvcolt.TrueValue = typeof(bool);
            dgvcolt.TrueValue = true;
            dgvcolt.FalseValue = false;
            dgvcolt.Name = "Sel";
            dgvcolt.HeaderText = "Selección";
            dgvTemas.Columns.Insert(4, dgvcolt);
        }
        //Botón para ingresar los atributos del Usuario
        //Si no es administrador, debe de Tener Atributos Designados
        private void cmdIN_Click(object sender, EventArgs e)
        {
            LLenarTablaAtribuciones();
        }
        /// <summary>
        /// Validar las selecciones de los Grids de los Atributos
        /// y agregarlos a la tabla
        /// </summary>
        private void LLenarTablaAtribuciones()
        {
            foreach (DataGridViewRow rsecc in dgvSecciones.Rows)
            {
                if (rsecc.Cells["Sel"].Value != null)// Validar que contenga valor la celda
                {
                    if ((bool)rsecc.Cells["Sel"].Value)//
                    {
                        foreach (DataGridViewRow rser in dgvSeries.Rows)
                        {
                            if (rser.Cells["Sel"].Value != null)//Validar que contenga Valor la Celda
                            {
                                if ((bool)rser.Cells["Sel"].Value)
                                {

                                }
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Agregar Tema 
        /// </summary>
        private void cmdADDTema_Click(object sender, EventArgs e)
        {
            TemasAdd tForm = new TemasAdd(tm.Seccion.Id, tm.Serie.Id);
            tForm.PasarTema += new TemasAdd.LLenarTemas(EnvioValorTemaXSerie);
            tForm.Show();
        }
    }
}
