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
using SADI.Clases.EventsArgs;

namespace SADI.Vistas.Atributos
{

    public partial class AtributosAdd : Form
    {
        AtributosModel amdl = new AtributosModel();//Instancia del Modelo Atribuciones
        AtributosController actr = new AtributosController();// Instancia del Controlador Atribuciones
        object val;

        /// <summary>
        /// Propiedades y Atributos de la Forma
        /// </summary>
        #region Propiedades de la Forma

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
        DataTable TAtrTemp = new DataTable();

        #endregion
        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public AtributosAdd()
        {
            InitializeComponent();
            cmdADDTema.Enabled = false;
            cmdADDTema.Visible = false;
        }

        /// <summary>
        /// Contructor de la Clase
        /// </summary>
        /// <param name="idUsr">Id de Usuario</param>
        public AtributosAdd(int idUsr, object sender)
        {
            val = sender;
            InitializeComponent();
            cmdADDTema.Enabled = false;//Inhabilitar el botón Tema
            cmdADDTema.Visible = false;// Ocultar el Botón Tema
            FormatearTablaAtribuciones();// Formatear la Tabla Atribuciones para la Asignaciones de Atribuciones
            um.Id = idUsr;// Identificador del Usuario
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

        #region Eventos

        #region Eventos de GridViews

        /// <summary>
        /// Cambio de valor del Checkbox en Grid Secciones
        /// </summary> 
        private void dgvSecciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvSecciones.SelectedRows[0].Cells[e.ColumnIndex];
            if (chk.Value == chk.FalseValue || chk.Value == null)
            {
                if (sender.ToString() != "dgvSecciones_CellClick")
                {
                    chk.Value = chk.TrueValue;// Cambiar el Valor a Verdadero
                    if (dgvSeries.Rows.Count > 0) { dgvSeries.DataSource = null; dgvSeries.Columns.Clear(); }//Limpiar el Grid de Series
                    EnvioValorSeriesXSeccion((string)dgvSecciones.SelectedRows[0].Cells["Id"].Value);
                }
            }
            else
            {
                if (sender.ToString() != "dgvSecciones_CellClick")
                {
                    chk.Value = chk.FalseValue;//CAmbiar el Valor a Falso
                    dgvSeries.DataSource = null;
                    dgvSeries.Columns.Clear();
                    dgvTemas.DataSource = null;
                    dgvTemas.Columns.Clear();
                    object send = this.Name;
                    TemasSeriesEventArgs ev = new TemasSeriesEventArgs
                    {
                        IdSeccion = (string)dgvSecciones.SelectedRows[0].Cells["Id"].Value,
                        Opcion = 1
                    };
                    BorrarRenglonTablaAtribuciones(send, ev);
                }
                else
                {
                    EnvioValorSeriesXSeccion((string)dgvSecciones.SelectedRows[0].Cells["Id"].Value);
                }
            }

        }

        /// <summary>
        /// Cambio de Valor del Checkbox en Grid Series
        /// </summary>
        private void dgvSeries_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvTemas.Rows.Count > 0)
            {
                dgvTemas.DataSource = null;
                dgvTemas.Columns.Clear();
            }

            if (sender.ToString() == "LLenarGridSeries")//Verificar si se Envia desde el Método 
            {
                EnvioValorTemaXSerie((int)dgvSeries.SelectedRows[0].Cells["idSerie"].Value,
                    (string)dgvSeries.SelectedRows[0].Cells["Seccion"].Value);

            }
            else//No es enviado desde ese método
            {
                try
                {
                    DataGridViewCheckBoxCell chkSer = (DataGridViewCheckBoxCell)dgvSeries.SelectedRows[0].Cells[e.ColumnIndex];

                    if (chkSer.Value == chkSer.FalseValue || chkSer.Value == null)
                    {
                        chkSer.Value = chkSer.TrueValue;//Cambiar el Valor a Verdadero
                        TablaEventArgs et = new TablaEventArgs
                        {
                            Seccion = (string)dgvSecciones.SelectedRows[0].Cells["Id"].Value,
                            SelSeccion = true,
                            Serie = (int)dgvSeries.SelectedRows[0].Cells["IdSerie"].Value,
                            SelSerie = true
                        };
                        LLenarTablaAtribuciones("SeriesChk", et);//LLenar Tabla Temporal
                        EnvioValorTemaXSerie((int)dgvSeries.SelectedRows[0].Cells["idSerie"].Value,
                            (string)dgvSeries.SelectedRows[0].Cells["Seccion"].Value);
                    }
                    else
                    {
                        chkSer.Value = chkSer.FalseValue;//Cambiar del Valor a Falso
                        dgvTemas.DataSource = null;
                        dgvTemas.Columns.Clear();
                        object send = this;
                        TemasSeriesEventArgs ev = new TemasSeriesEventArgs
                        {
                            IdSeccion = (string)dgvSecciones.SelectedRows[0].Cells["Id"].Value,
                            IdSerie = (int)dgvSeries.SelectedRows[0].Cells["IdSerie"].Value,
                            Opcion = 2
                        };
                        BorrarRenglonTablaAtribuciones(send, ev);
                    }
                }
                catch (Exception ex) { ex.Message.ToString(); }
            }
        }

        /// <summary>
        /// Cambio de Valor al CheckBox de la Celda
        /// </summary>
        private void dgvTemas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvTemas.SelectedRows[0].Cells[e.ColumnIndex];//Instancia de la Columna Checkbox
            if (chk.Value == chk.FalseValue || chk.Value == null)//Si su valor original es Null O False
            {
                chk.Value = chk.TrueValue;//Cambiar a True
                TablaEventArgs et = new TablaEventArgs
                {
                    Seccion = (string)dgvSecciones.SelectedRows[0].Cells["Id"].Value,
                    SelSeccion = true,
                    Serie = (int)dgvSeries.SelectedRows[0].Cells["IdSerie"].Value,
                    SelSerie = true,
                    Tema = (int)dgvTemas.SelectedRows[0].Cells["IdTema"].Value,
                    SelTema = true
                };
                LLenarTablaAtribuciones("TemasChk", et);//Agregar el valor a la Tabla
            }
            else
            {
                object send = this;//Indicarle de dónde se envía la información
                // Enviarle los Argumentos al Método
                TemasSeriesEventArgs ev = new TemasSeriesEventArgs
                {
                    IdSeccion = (string)dgvSecciones.SelectedRows[0].Cells["Id"].Value,
                    IdSerie = (int)dgvSeries.SelectedRows[0].Cells["IdSerie"].Value,
                    IdTema = (int)dgvTemas.SelectedRows[0].Cells["IdTema"].Value,
                    Opcion = 3
                };
                chk.Value = chk.FalseValue;// Cambiar a False
                BorrarRenglonTablaAtribuciones(send, ev);//Eliminar el Valor de la Tabla
            }
        }

        #endregion//Cierre de Región Eventos de GridViews

        #region Eventos Propios
        /// <summary>
        /// Eliminar o cambiar el Valor de las Selecciones de la Tabla
        /// </summary>
        private void BorrarRenglonTablaAtribuciones(object sernder, TemasSeriesEventArgs e)
        {
            ///<summary>
            ///Evaluar la Opción para elimiar el registro
            /// </summary>
            switch (e.Opcion)
            {
                case 1://Eliminar los registros de la Sección
                    if (!(bool)dgvSecciones.SelectedRows[0].Cells["Sel"].Value)
                    {
                        DataRow[] sec = TAtrTemp.Select("Seccion = '" + e.IdSeccion + "'");
                        foreach (var rs in sec)
                        {
                            rs.Delete();
                            TAtrTemp.AcceptChanges();
                        }
                    }
                    break;
                case 2://Eliminar los registros de la Serie
                    if (!(bool)dgvSeries.SelectedRows[0].Cells["Sel"].Value)
                    {
                        DataRow[] ser = TAtrTemp.Select("Seccion = '" + e.IdSeccion + "' AND Serie =" + e.IdSerie);
                        foreach (var rs in ser)
                        {
                            rs.Delete();
                            TAtrTemp.AcceptChanges();
                        }
                    }
                    break;
                case 3:
                    if (!(bool)dgvTemas.SelectedRows[0].Cells["Sel"].Value)
                    {
                        DataRow[] tem = TAtrTemp.Select("Seccion = '" + e.IdSeccion + "' AND Serie = " + e.IdSerie.ToString() +
                        " AND Tema = " + e.IdTema.ToString() + "");
                        foreach (var rs in tem)
                        {
                            rs["Tema"] = 0;
                            TAtrTemp.AcceptChanges();
                        }

                    }
                    break;
                default:

                    break;
            }

        }
        #endregion

        #region Eventos de Botón

        //Botón para ingresar los atributos del Usuario
        //Si no es administrador, debe de Tener Atributos Designados
        private void cmdIN_Click(object sender, EventArgs e)
        {
            GuardarAtribuciones();
            //Presumir fp = new Presumir(TAtrTemp);
            //fp.ShowDialog();

        }

        /// <summary>
        /// Abrir la Agregar Tema 
        /// </summary>
        private void cmdADDTema_Click(object sender, EventArgs e)
        {
            TemasAdd tForm = new TemasAdd(tm.Seccion.Id, tm.Serie.Id);//Instanciar al Servicio Delegado
            tForm.PasarTema += new TemasAdd.LLenarTemas(EnvioValorTemaXSerie);//Manejar el evento del servicio
            tForm.Show();// Mostrar la Instancia
        }

        /// <summary>
        /// Cerrar la Forma
        /// </summary>
        private void cmdOUT_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #endregion// Cierre de Región de Eventos

        #region Métodos Internos

        #region LLenado de Grids

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
        /// Método LLenar el Grid de Series
        /// </summary>
        private void LLenarGridSeries()
        {
            if (dgvSeries.Rows.Count > 0)
            { dgvSeries.DataSource = null; dgvSeries.Columns.Clear(); }
            dgvSeries.DataSource = serc.Tabla;// Asignar la Fuente de Datos al Grid
            dgvSeries = Utilerias.PropiedadesDataGridView(dgvSeries);// Formato Predefinido del Grid
            AgregarColumnaValidarGridSeires();//Agregar Columna de CheckBox al Grid
            dgvSeries.Columns[0].Visible = false;// Ocultar el Identificaro de Modelo
            dgvSeries.Columns[1].Width = 50;//Ancho de la Columna
            dgvSeries.Columns[2].Width = 267;// ------
            dgvSeries.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;//------
            if (um.Jerarquia.Id == 6 || um.Jerarquia.Id == 1)// Verificar que el Usuario sea Responsable de Trámite
            {
                int c = 0;
                //Si es Responsable de Tramite
                foreach (DataGridViewRow r in dgvSeries.Rows)
                {
                    dgvSeries.Rows[c].Selected = true;//Cambiar de Selección de Renglón
                    r.Cells["Sel"].Value = true;//Seleccionar la Serie
                    DataGridViewCellEventArgs ce = null;//Evento de Selección de Celda del GridView
                    TablaEventArgs et = new TablaEventArgs//Nueva instancia de Argumentos de Eventos de la Tabla
                    {
                        Seccion = (string)dgvSecciones.SelectedRows[0].Cells["Id"].Value,//Valor del Indetificador de la Sección
                        SelSeccion = true,//Selección de la Sección
                        Serie = (int)dgvSeries.SelectedRows[0].Cells["IdSerie"].Value,//Valor del Identificador de la Serie
                        SelSerie = true//Selección Serie
                    };
                    LLenarTablaAtribuciones(null, et);//LLamar al Método
                    dgvSeries_CellContentClick("LLenarGridSeries", ce);//LLamar al Evento
                    c += 1;
                    if (dgvTemas.Rows.Count > 0) { dgvTemas.DataSource = null; }//Limpiar el Grid Temas
                }
            }
        }
        /// <summary>
        /// Método para llenar el Grid Temas con las Opciones Seleccionadas
        /// </summary>
        private void LLenarGridTemas()
        {
            if (dgvTemas.Columns.Count > 0)//Si cuenta con Datos el datagrid
            { dgvTemas.DataSource = null; dgvTemas.Columns.Clear(); }//Limpiar el Grid Temas
            dgvTemas.DataSource = tc.Tabla;//Agregarle la Fuente de Datos
            dgvTemas = Utilerias.PropiedadesDataGridView(dgvTemas);//Formato predeterminado
            AgregarColumnaValidarGridTemas();//Agregar los CheckBox
            dgvTemas.Columns[0].Visible = false;
            dgvTemas.Columns[1].Width = 50;
            dgvTemas.Columns[1].HeaderText = "Id Serie";
            dgvTemas.Columns[2].Width = 50;
            dgvTemas.Columns[3].Width = 210;
            dgvTemas.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            if (um.Jerarquia.Id == 1 || um.Jerarquia.Id == 6)//Validar Usuario sea Admin/Responsable Trámite
            {
                int c2 = 0;
                foreach (DataGridViewRow rt in dgvTemas.Rows)//Crear un renglón del tipo DataGridVew de Temas
                {
                    dgvTemas.Rows[c2].Selected = true;//Renglón seleccionado
                    rt.Cells["Sel"].Value = true;//Asignarle el Valor Verdadero al Campo Selección del Tema
                    TablaEventArgs et = new TablaEventArgs
                    {
                        Seccion = (string)dgvSecciones.SelectedRows[0].Cells["Id"].Value,//Valor del Identificador de la Seccion
                        SelSeccion = true,//Indicar Selección se Sección
                        Serie = (int)dgvSeries.SelectedRows[0].Cells["IdSerie"].Value,//Valor del Identificador de la Serie
                        SelSerie = true,//Indicar selección de Serie
                        Tema = (int)dgvTemas.SelectedRows[0].Cells["IdTema"].Value,//Valor del Identificador del Tema
                        SelTema = true//Indicar Selección de Tema
                    };
                    LLenarTablaAtribuciones(null, et);//LLenar Tabla Atribuciones
                    c2 += 1;// Incrementar el Índice 
                }
            }
        }

        #endregion //LLenado de Grids

        #region GridViews y Métodos de GridViews

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
        /// Método para Ingresar una Columna
        /// </summary>
        private void AgregarColumnaValidarGridTemas()
        {
            DataGridViewCheckBoxColumn dgvcolt = new DataGridViewCheckBoxColumn();
            dgvcolt.TrueValue = typeof(bool);
            dgvcolt.TrueValue = true;
            dgvcolt.FalseValue = typeof(bool);
            dgvcolt.FalseValue = false;
            dgvcolt.Name = "Sel";
            dgvcolt.HeaderText = "Selección";
            dgvTemas.Columns.Insert(4, dgvcolt);
        }

        #endregion // GridViews y Métodos de GridViews

        #region LLenado de Objetos y Manejo de Tablas

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
                um.Jerarquia.Id = (int)uc.Tabla.Rows[0][7];//Asignación de la Identificación de la Jerarquía del Usuario

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
        /// Validar las selecciones de los Grids de los Atributos
        /// y agregarlos a la tabla
        /// </summary>
        private void LLenarTablaAtribuciones(object sender, TablaEventArgs e)
        {
            if (TAtrTemp.Rows.Count == 0)//Verificar que la tabla no tenga ningún renglón 
            {
                DataRow nr = TAtrTemp.NewRow();//Agregar Nuevo Renglón
                if (e.SelSeccion)//Si cuenta con Valor de La Sección
                {
                    if (e.SelSerie)//Si cuenta con Valor de la Serie
                    {
                        if (dgvTemas.Rows.Count > 0)//Veridificar que tenga datos el grid Temas
                        {
                            if (e.SelTema)//Si cuenta con valor el tema
                            {
                                nr["usuario"] = um.Id;//Identificador del Usuario
                                nr["Seccion"] = e.Seccion;//Identificador de la Sección
                                nr["Serie"] = e.Serie;//Identificador de la Serie
                                nr["Tema"] = e.Tema;//Identificador del Tema

                                TAtrTemp.Rows.Add(nr);//Agregar el Renglón
                            }
                            else
                            {
                                nr["usuario"] = um.Id;//Identificador del Usuario
                                nr["Seccion"] = e.Seccion;//Identificador de la Sección
                                nr["Serie"] = e.Serie;//Identificador de la Serie
                                nr["Tema"] = 0;//Identificador del Tema

                                TAtrTemp.Rows.Add(nr);//Agregar el Renglón
                            }
                        }
                        else//NO tiene datos el Grid Temas
                        {
                            nr["usuario"] = um.Id;//Identificador del Usuario
                            nr["Seccion"] = e.Seccion;//Identificador de la Sección
                            nr["Serie"] = e.Serie;//Identificador de la Serie
                            nr["Tema"] = 0;//Identificador del Tema

                            TAtrTemp.Rows.Add(nr);//Agregar el Renglón
                        }
                    }// Grid Series
                }// Grid Secciones
            }
            else// La tabla no esta Vacía
            {
                if (e.SelSeccion && e.SelSerie)//Si está Seleccionado Sección y Tema
                {
                    int tema = 0;//Asignarle el identificador del Tema
                    bool valida = true;// Validar si se realizó cambio de IdTema
                    string expresion = string.Empty;// Guardar le Expresión a Buscar
                    DataRow[] result;// Dónde se guardan los resultados, si existen
                    if (dgvTemas.Rows.Count > 0)// Verificar que tenga Valores el Grid Temas
                    {
                        if (e.SelTema)//Si seleccionaro el Tema
                        {///Indicar de dónde viene
                            foreach (DataRow r0 in TAtrTemp.Rows)//Barrer la tabla
                            {
                                if ((string)r0["Seccion"] == e.Seccion &&
                                    (int)r0["Serie"] == e.Serie &&
                                    (int)r0["Tema"] == 0)//Validar que sean el registro único a modificar
                                {
                                    r0["Tema"] = e.Tema;//Identificador del Tema
                                    valida = false;//Ya no es necesario ingresarle nada a la tabla

                                    TAtrTemp.AcceptChanges();//Guardar los cambios en la tabla Atributos
                                }
                            }
                            //Expresión a buscar en la tabla
                            expresion = "Seccion = " + "'" + e.Seccion + "'" + " AND ";
                            expresion += "Serie = " + e.Serie + " AND ";
                            expresion += "Tema = " + e.Tema + "";
                            tema = e.Tema;//Cambiarle el valor al tema
                        }
                        else
                        {
                            //Expresión a buscar en la tabla
                            expresion = "Seccion = " + "'" + e.Seccion + "'" + " AND ";
                            expresion += "Serie = " + e.Serie + " AND ";
                            expresion += "Tema = " + e.Tema + "";
                        }
                    }
                    else// NO tiene valores el Grid Temas
                    {
                        //Verificar si no se nos pasa un valor en tabla
                        tm.Seccion.Id = e.Seccion;
                        tm.Serie.Id = e.Serie;
                        if (tc.ConsultarTemaXSerieSeccion(tm))
                        {
                            if (tc.Tabla.Rows.Count > 0)
                            {
                                e.Tema = (int)tc.Tabla.Rows[0]["IdTema"];
                            }
                        }
                        expresion = "Seccion = " + "'" + e.Seccion + "'" + " AND ";
                        expresion += "Serie = " + e.Serie + " AND ";
                        expresion += "Tema = " + e.Tema + "";
                    }

                    if (valida)//Ver si no se modificó el mismo registro
                    {
                        result = TAtrTemp.Select(expresion);//Indicarle la Búsqueda a la Tabla

                        if (result.Length == 0)//Asegurarnos que no existen coincidencias en la tabla
                        {
                            DataRow ri = TAtrTemp.NewRow();//Crear renglón nuevo de Tabla Atributos
                            ri["usuario"] = um.Id;//Ientificador del Usuario
                            ri["Seccion"] = e.Seccion;//Identificador de la Sección
                            ri["Serie"] = e.Serie;//Identificador de la Serie
                            ri["Tema"] = tema;//Identificadoe del Tema

                            TAtrTemp.Rows.Add(ri);//Agregar el Renglón
                        }

                    }
                }
            }// Validación de la Tabla

        }
        /// <summary>
        /// Agregar las Columnas a la Tabla Atributos
        /// </summary>
        private void FormatearTablaAtribuciones()
        {
            if (TAtrTemp.Columns.Count == 0)//Verificar que no cuente con columnas la taba
            {
                TAtrTemp.Columns.Add("usuario", typeof(int));//Idetificado del usuario
                TAtrTemp.Columns.Add("Seccion", typeof(string));//Identificador de la Sección
                TAtrTemp.Columns.Add("Serie", typeof(int));//Identificador de la Serie
                TAtrTemp.Columns.Add("Tema", typeof(int));//Identificador del Tema
            }
        }

        #endregion // LLenado de Objetos y Manejo de Tablas

        #region Métodos Varios

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
        /// Enviar los Parámetros para Seleccionar Tema por Serie y Sección
        /// </summary>
        /// <param name="value1">Id de la Serie</param>
        /// <param name="value2">Id de la Sección</param>
        private void EnvioValorTemaXSerie(int value1, string value2)
        {
            //tm.Serie.Id = value1;//Indicar la Serie
            //tm.Seccion.Id = value2;//Indicar la Sección

            am.Serie.Id = value1;//Indicar la Serie
            am.Seccion.Id = value2;//Indicar la Sección

            if (tc.ConsultarTemaXSerieSeccion(am))//Intentar la Consulta
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
                    // Verificar Si el Usuaior es Administrado o Responsable de Trámite
                    if (um.Jerarquia.Id == 1 || um.Jerarquia.Id == 6)
                    {
                        TablaEventArgs et = new TablaEventArgs//Instancia de Argumentos del Evento Tabla
                        {
                            Seccion = (string)dgvSecciones.SelectedRows[0].Cells["Id"].Value,
                            SelSeccion = true,
                            Serie = (int)dgvSeries.SelectedRows[0].Cells["IdSerie"].Value,
                            SelSerie = true
                        };
                        LLenarTablaAtribuciones(null, et);//LLenar tabla Atribuciones
                        // Si es Administrador/Responsable de Trámite

                    }
                    else//NO lo es
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
                                //Que no venga de Usuarios para cerrar
                                if (val == null)
                                { Close(); }
                            }
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
        /// Guardar las Atribuciones del Usuario
        /// </summary>
        private void GuardarAtribuciones()
        {

            if (TAtrTemp.Rows.Count > 0)//Que la tabla tenga registros
            {
                DataTable valida = new DataTable();//Tabla
                valida.Columns.Add("val", typeof(bool));
                valida.Columns.Add("msg", typeof(string));

                foreach (DataRow rt in TAtrTemp.Rows)
                {
                    DataRow nr = valida.NewRow();//Nuevo renglón de tabla valid
                    amdl.Usuario.Id = (int)rt["usuario"];//Identificador del Usuario
                    amdl.Seccion.Id = (string)rt["Seccion"];//Identificador de la Sección
                    amdl.Serie.Id = (int)rt["Serie"];//Identificador de la Serie
                    amdl.Temas.Id = (int)rt["Tema"];//Identificador del Tema

                    if (actr.IngresarRegisto(amdl))//Intentar Ingresar el Registro
                    {
                        nr["val"] = true;
                        nr["msg"] = string.Empty;
                    }
                    else// 
                    {
                        nr["val"] = true;
                        nr["msg"] = actr.Error;
                    }
                    valida.Rows.Add(nr);//Agregar el Renglón
                }//Fin del For...

                foreach (DataRow rc in valida.Rows)
                {
                    if ((bool)rc["val"] == false)
                    {
                        MessageBox.Show("ocurrió el sieguiente error :".ToUpper() + "\n" + (string)rc["msg"],
                            ":: mensaje desde agregar atributos ::".ToUpper(), MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        Close();
                    }
                }

                MessageBox.Show("se ingresaron los registros con éxito.".ToUpper(), ":: mensaje desde agregar atributos ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }

        #endregion // Métodos Internos/Mëtodos Varios

        #endregion// Métodos Internos
        /// <summary>
        /// Validar Cuando se seleccione un renglón de el GridSeries
        /// que los temas estén seleccionados
        /// </summary>
        private void dgvSeries_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (TAtrTemp.Rows.Count > 0)//Verificar que se tenga información en la tabla
            {
                foreach (DataRow r in TAtrTemp.Rows)//
                {
                    if ((int)dgvSeries.SelectedRows[0].Cells["IdSerie"].Value == (int)r["Serie"])//Validar que se tenga valores iguales
                    {
                        dgvSeries.CurrentCell = dgvSeries.Rows[e.RowIndex].Cells["Sel"];
                        DataGridViewCellEventArgs ev = new DataGridViewCellEventArgs(dgvSeries.CurrentCell.ColumnIndex,
                            dgvSeries.CurrentCell.RowIndex);
                        dgvSeries_CellContentClick("LLenarGridSeries", ev);
                        break;
                    }
                }
            }
        }
        /// <summary>
        /// Validar Cuando se seleccione un renglón de el GridSecciones
        /// que los temas estén seleccionados
        /// </summary>
        private void dgvSecciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0)
            {
                if (TAtrTemp.Rows.Count > 0)
                {
                    foreach (DataRow r in TAtrTemp.Rows)
                    {
                        if ((string)dgvSecciones.SelectedRows[0].Cells["Id"].Value == (string)r["Seccion"])
                        {
                            dgvSecciones.CurrentCell = dgvSecciones.Rows[e.RowIndex].Cells["Sel"];
                            DataGridViewCellEventArgs ev = new DataGridViewCellEventArgs(dgvSecciones.CurrentCell.ColumnIndex,
                                dgvSecciones.CurrentCell.RowIndex);
                            dgvSecciones_CellContentClick("dgvSecciones_CellClick", ev);
                            break;
                        }
                    }
                }
            }
        }
    }

}
