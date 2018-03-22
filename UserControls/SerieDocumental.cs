using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SADI.Clases;
using SADI.Clases.EventsArgs;
using SADI.Clases.Controladores;
using SADI.Clases.Modelos;

namespace SADI.UserControls
{
    public partial class SerieDocumental : UserControl
    {


        #region Propiedades
        private int opc;// -- 1) Ingresar -- 2)Editar -- 3)Detalle
        private DigitalizacionesModel dm = new DigitalizacionesModel();//Instancia del Objeto Digitalizaciones
        private RegistrosModel rm = new RegistrosModel();//Instancia del Modelo de Registro
        private RegistrosController rc = new RegistrosController();//Instancia del Controlador del Registro
        private UsuariosModel _usuario = new UsuariosModel();//Instancia de UsuariosModel
        private AtributosModel _atributos = new AtributosModel();//Instancia de AtributosModel
        private SeriesModel _serie = new SeriesModel();//Modelo de la Serie
        private SeccionesModel _seccion = new SeccionesModel();//Modelo de la Sección
        private TemasModel _tema = new TemasModel();//Modelo de Temas
        private RegistrosModel _registro = new RegistrosModel();//Intencia del Modelo Registros
        private ClasificacionesModel _clasificaion = new ClasificacionesModel();//Modelo de Clasificaciones
        private ValoresDoctalesModel _valordoctal = new ValoresDoctalesModel();//Modelo de ValoresDoctales
        private DataTable _seccionest = new DataTable();//Tabla contenedora de los regitros de las Secciones
        private DataTable _seriest = new DataTable();//Tabla contenedora de las series de las Secciones
        private DataTable _temast = new DataTable();//Tabla contenedora de los temas de las series
        private DataTable _clasificaciont = new DataTable();//Tabla Contenedora de las Clasificaciones
        private DataTable _valorDoctalt = new DataTable();//Tabla contenedora de los valores documentales
        private bool _ctaSevi;//Valor a la Pregunta si cuenta con clave SEVI
        private bool _status; //Valor al Estaus de la Serie Documental
        private DateTime _fechaSerie;//Propiedad de la Fecha de creación de la Serie
        private DateTime _fechaCierreSerie;//Propiedad de la fecha del cierre de la propiedad
        private string _nomexpe;//Propiedad el Nombre del Expediente
        private string _descripcion;//Descripción del Expediente
        private string _otrainfo;//Propiedad de Otra Información del Expediente
        private string _seriedoctal;//Propiedad de la SerieDocumental;
        private string _cvesevi;//Propiedad d ela clave SEVI
        private string _consecutivo;//Propiedad del Consecutivo de la Serie Documental
        private bool _agregarTema;//Propiedad para indicar si se vá a agregar un tema
        private bool _digitalizado;// Propiedad para Verificar si Exiten Documentos Digitalizados
        private string _extension;
        private byte[] _documento;
        private ToolTip _myToolTip;
        private DataTable _DTdigitalizados;
        //private TextBox _txtBoxDesc = new TextBox();
        //private TextBox _txtBoxOtraInf = new TextBox();
        /// 
        /// 
        private OpenFileDialog _ofd;//
        #endregion

        #region Eventos Públicos

        public event EventHandler cboSeccionCambioValor;//Manejar Evento cboSeccionChangedValue
        public event EventHandler cboSerieCambioValor;//Manejar Evento dboSeriesChangedValue
        public event EventHandler CargaDeControl;//Manejar el Evento Load del Control

        #endregion

        #region Getters & Setters
        /// <summary>
        /// Tabla con el Registro de las Secciones
        /// </summary>
        public DataTable SeccionesT
        {
            get { return _seccionest; }
            set { _seccionest = value; LLenarComboSecciones(); }
        }
        /// <summary>
        /// Tabla con el Registro de las Series de la Sección
        /// </summary>
        public DataTable SeriesT
        {
            get { return _seriest; }
            set { _seriest = value; LLenarComboSeries(); }
        }
        /// <summary>
        /// Tabla con el Registro de los Temas de la Serie
        /// </summary>
        public DataTable TemasT
        {
            get { return _temast; }
            set { _temast = value; LLenarComboTemas(); }
        }
        /// <summary>
        /// Tabla con el Registro de las Clasificaciones
        /// </summary>
        public DataTable ClasificacionesT
        {
            get { return _clasificaciont; }
            set { _clasificaciont = value; }
        }
        /// <summary>
        /// Tabla con el Registro de las Valoraciones Documentales
        /// </summary>
        public DataTable ValoracionesDocaltesT
        {
            get { return _valorDoctalt; }
            set { _valorDoctalt = value; }
        }
        /// <summary>
        /// Acceder al Objeto DigitalizacionModel
        /// </summary>
        public DigitalizacionesModel Digitalizacion
        { get { return dm; } set { dm = value; } }
        /// <summary>
        /// Acceder al Obento SeccionesModel
        /// </summary>
        public SeccionesModel Seccion
        {
            get { return _seccion; }
            set { _seccion = value; }
        }
        /// <summary>
        /// Acceder al Objeto SeriesModel
        /// </summary>
        public SeriesModel Serie
        {
            get { return _serie; }
            set { _serie = value; }
        }
        /// <summary>
        /// Acceder al Objeto TemasModel
        /// </summary>
        public TemasModel Tema
        {
            get { return _tema; }
            set { _tema = value; }
        }
        /// <summary>
        /// Acceder al Objeto ClasificaionModel
        /// </summary>
        public ClasificacionesModel Clasificacion
        {
            get { return _clasificaion; }
            set { _clasificaion = value; }
        }
        /// <summary>
        /// Acceder al Objeto ValoresDoctalesModel
        /// </summary>
        public ValoresDoctalesModel ValorDoctal
        {
            get { return _valordoctal; }
            set { _valordoctal = value; }
        }
        /// <summary>
        /// Acceder a la Propiedad Cuenta SEVI
        /// </summary>
        public bool CtaSevi
        {
            get { return _ctaSevi; }
            set { _ctaSevi = value; }
        }
        /// <summary>
        /// Acceder a la Propiedad Estatus de la Serie Documental
        /// </summary>
        public bool Estatus
        {
            get { return _status; }
            set { _status = value; }
        }
        /// <summary>
        /// Acceder a la Propiedad 
        /// </summary>
        public DateTime FechaSerie
        {
            get { return _fechaSerie; }
            set { _fechaSerie = value; }
        }
        /// <summary>
        /// Acceder a la propiedad Fecha del Cierre de la Serie Documental
        /// </summary>
        public DateTime FechaCierreSerie
        {
            get { return _fechaCierreSerie; }
            set { _fechaCierreSerie = value; }
        }
        /// <summary>
        /// Acceder a la Propiedad Nombre Expediente
        /// </summary>
        public string NombreExpediente
        {
            get { return _nomexpe; }
            set { _nomexpe = value; txtNombreExp.Text = _nomexpe; }//Asignar el valor al textbox
        }
        /// <summary>
        /// Acceder a la Descripción de la Serie Documental
        /// </summary>
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        /// <summary>
        /// Acceder a la Propiedad Información Adicional de la Serie
        /// </summary>
        public string OtraInfo
        {
            get { return _otrainfo; }
            set { _otrainfo = value; }
        }
        /// <summary>
        /// Acceder a la Propiedad Número d Serie Documental
        /// </summary>
        public string NumeroSerieDocumental
        {
            get { return _seriedoctal; }
            set { _seriedoctal = value; lblSerieDoctal.Text = _seriedoctal; }
        }
        /// <summary>
        /// Acceder a la ClaveSEVI
        /// </summary>
        public string ClaveSEVI
        {
            get { return _cvesevi; }
            set { _cvesevi = value; }
        }
        /// <summary>
        /// Obtener el Identificador del Fondo
        /// </summary>
        public int Fondo
        {
            get { return _usuario.Fondo.Id; }
        }
        /// <summary>
        /// Obtener el Identificador del SubFondo
        /// </summary>
        public int SubFondo
        {
            get { return _usuario.SubFondo.Id; }
        }
        /// <summary>
        /// Indicar si se vá a agregar tema o no
        /// </summary>
        public bool AgregarTema
        {
            get { return _agregarTema; }
        }
        /// <summary>
        /// Acceso a la Propiedad Digitalizado
        /// </summary>
        public bool Digitalizado
        { get { return _digitalizado; } set { _digitalizado = value; chkDigitalizado.Checked = value; } }
        /// <summary>
        /// Acceder a la Propiedad Formato
        /// </summary>
        public string Extension
        { get { return _extension; } set { _extension = value; } }
        /// <summary>
        /// Acceder a la propiedad Documento
        /// </summary>
        public byte[] Documento
        {
            get { return _documento; }
            set { _documento = value; }
        }
        /// <summary>
        /// Acceso a la Tabla con los archivos Digitalizados
        /// </summary>
        public DataTable DTDigitalizados
        { get { return _DTdigitalizados; } }
        #endregion

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public SerieDocumental()
        {
            InitializeComponent();
            FechaSerie = dtpFecha.Value;
            cmdAddFiles.Visible = false;
            cmdAddFiles.Enabled = false;
            cmdChangeFile.Visible = false;
            cmdChangeFile.Enabled = false;
        }

        #region Métdos Internos

        /// <summary>
        /// Carga Inicial de los Combos
        /// </summary>
        private void CargaInicial()
        {
            LLenarComboSecciones();
            LLenarComboClasificaciones();
            LLenarComboValoracionDoctal();
        }
        /// <summary>
        /// Publicar que Opción se seleccionó
        /// </summary>
        private string Opciones()
        {
            switch (opc)
            {
                case 1:
                    return "ingresar serie documental.";
                case 2:
                    return "editar serie documental.";
                case 3:
                    return "detalle serie documental.";
                default:
                    return string.Empty;
            }
        }
        /// <summary>
        /// Método para llenar el Combo Secciones
        /// </summary>
        private void LLenarComboSecciones()
        {
            if (SeccionesT.Rows.Count > 0)//Verificar que existen registros
            {
                //Si existen Registros

                cboSeccion.DataSource = SeccionesT;//
                cboSeccion.ValueMember = SeccionesT.Columns[0].ColumnName;//
                cboSeccion.DisplayMember = SeccionesT.Columns[1].ColumnName;//

            }
            else//No existen Registros
            {
                MessageBox.Show("no se encontraron registros de la selección.",
                    ":: mensaje desde el contro serie documental, opción :".ToUpper() + Opciones().ToUpper() + " ::",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// LLenar combo Clasificaciones
        /// </summary>
        private void LLenarComboClasificaciones()
        {
            if (ClasificacionesT.Rows.Count > 0)//Verificar que la tabla contenga registros
            {
                //Si Tiene registros
                cboClasificaciones.DataSource = ClasificacionesT;//Fuente de datos del Combo
                cboClasificaciones.ValueMember = ClasificacionesT.Columns[0].ColumnName;//Valor del Registro
                cboClasificaciones.DisplayMember = ClasificacionesT.Columns[1].ColumnName;//Descripción del Registro
            }
            else//NO tiene tegistros
            {
                MessageBox.Show("no existen resgistros en la consulta.".ToUpper(),
                    ":: mensaje desde el control serie documental, opción :".ToUpper() + Opciones().ToUpper() + " ::",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// LLenar el Combo Valoracion Documental
        /// </summary>
        private void LLenarComboValoracionDoctal()
        {
            if (ValoracionesDocaltesT.Rows.Count > 0)//Verificar que existen registros
            {
                // SI existen registro
                cboValorDoctal.DataSource = ValoracionesDocaltesT;//Fuente de la Información del Combo
                cboValorDoctal.ValueMember = ValoracionesDocaltesT.Columns[0].ColumnName;//Valor del Registro
                cboValorDoctal.DisplayMember = ValoracionesDocaltesT.Columns[1].ColumnName;//Descripción del Registro
            }
            else//NO existen registros
            {
                MessageBox.Show("no existen registros en la consulta.".ToUpper(),
                    ":: mensaje desde el control serie documental, opción :".ToUpper() + Opciones().ToUpper() + " ::",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// LLenar el Combo Series
        /// </summary>
        private void LLenarComboSeries()
        {
            if (SeriesT.Rows.Count > 0)//Verificar que contenga registros
            {
                //SI contiene registros
                cboSeries.Enabled = true;
                cboSeries.DataSource = SeriesT;//Fuente de la Información
                cboSeries.ValueMember = SeriesT.Columns[0].ColumnName;//Valor del Registro
                cboSeries.DisplayMember = SeriesT.Columns[2].ColumnName;//Descripción del Registro
            }
            else//NO contiene registros
            {
                cboSeries.Enabled = false;
                MessageBox.Show("no existen registros en la consulta.".ToUpper(),
                    ":: mensaje desde el control serie documental, opción : ".ToUpper() + Opciones().ToUpper() + " ::",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// LLenar el Combo Temas
        /// </summary>
        private void LLenarComboTemas()
        {
            if (TemasT.Rows.Count > 0)//Verificar si cuenta con registros
            {
                //SI centa con registros
                if ((int)TemasT.Rows[0][0] == 0) { cboTema.Enabled = false; }//Habilitar el Combo
                else { cboTema.Enabled = true; }//Habilitar el Combo
                cboTema.DataSource = TemasT;//Indicarle las fuente de la Información
                cboTema.ValueMember = TemasT.Columns[0].ColumnName;//Valor del registro
                cboTema.DisplayMember = TemasT.Columns[3].ColumnName;//Descripción del registro
            }
            else//NO cuenta con registros
            {
                cboTema.Enabled = false;
                MessageBox.Show("no existen registros en la consulta.".ToUpper(),
                    ":: mensaje desde el control seride documental, opción : ".ToUpper() + Opciones().ToUpper() + "::",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        /// <summary>
        /// Asegurarnos que sean puros números en el campo consecutivo
        /// </summary>
        private void txtConsecutivo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("ingrese sólo números.".ToUpper(),
                    ":: mensaje desde el control geolocalización ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Handled = true;
                return;
            }
            //else
            //{
            //    //Consecutivo();
            //    ActualizarSerieDocumental();
            //}
        }
        /// <summary>
        /// Método para Ir Actualizando la Serie Documental
        /// </summary>
        private void ActualizarSerieDocumental()
        {
            _seriedoctal = (_usuario.Fondo.Id.ToString().Length == 1 ? "0" + _usuario.Fondo.Id.ToString() : _usuario.Fondo.Id.ToString()) + ".";
            _seriedoctal += (_usuario.SubFondo.Id.ToString().Length == 1 ? "0" + _usuario.SubFondo.Id.ToString() : _usuario.SubFondo.Id.ToString()) + ".";
            _seriedoctal += (_usuario.Area.Id.ToString().Length == 1 ? "0" + _usuario.Area.Id.ToString() : _usuario.Area.Id.ToString()) + ".";
            _seriedoctal += (_usuario.SubArea.Id.ToString().Length == 1 ? "0" + _usuario.SubArea.Id.ToString() : _usuario.SubArea.Id.ToString()) + ".";
            _seriedoctal += (_usuario.Servicio.Id.ToString().Length == 1 ? "0" + _usuario.Servicio.Id.ToString() : _usuario.Servicio.Id.ToString()) + ".";
            _seriedoctal += (cboSeccion.SelectedValue.ToString() != "System.Data.DataRowView" ? cboSeccion.SelectedValue.ToString() : "XX") + ".";
            _seriedoctal += (cboSeries.SelectedValue != null ? (cboSeries.SelectedValue.ToString() != "System.Data.DataRowView" ? cboSeries.SelectedValue.ToString() : "00") : "00") + ".";
            _seriedoctal += Consecutivo() + ".";
            _seriedoctal += dtpFecha.Value.Year.ToString();
            NumeroSerieDocumental = _seriedoctal;

        }

        #endregion

        #region Métodos Públicos
        /// <summary>
        /// Método Público para Cargar los Datos en el Control
        /// </summary>
        public void CargarDatos()
        {
            FechaSerie = dtpFecha.Value;
            FechaCierreSerie = (opc == 1 ? dtpFecha.Value : DateTime.Now);
            Seccion.Id = (string)cboSeccion.SelectedValue;
            Serie.Id = (int)cboSeries.SelectedValue;
            Tema.Id = (cboTema.Enabled ? (cboTema.SelectedValue.ToString() != "System.Data.DataRowView" ? (int)cboTema.SelectedValue : 0) : 0);
            NumeroSerieDocumental = _seriedoctal;
            Clasificacion.Id = (int)cboClasificaciones.SelectedValue;
            ValorDoctal.Id = (int)cboValorDoctal.SelectedValue;
            NombreExpediente = txtNombreExp.Text;
            Descripcion = txtDescExpe.Text;
            OtraInfo = (!string.IsNullOrEmpty(txtOtraInfo.Text) ? txtOtraInfo.Text : null);
            Estatus = chkStatus.Checked;
        }

        #endregion

        #region CombosValueChanged

        /// <summary>
        /// Cambio de Seleccion del Combo Seccion
        /// </summary>
        private void cboSeccion_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboSeccionCambioValor != null)
            {
                if (cboSeccion.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    Seccion.Id = (string)cboSeccion.SelectedValue;
                    ActualizarSerieDocumental();
                    cboSeccionCambioValor(this, e);
                }
            }
            else
            {
                if (cboSeccion.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    Seccion.Id = (string)cboSeccion.SelectedValue;
                    ActualizarSerieDocumental();
                }
            }
        }
        /// <summary>
        /// Cambio de Selección del Combo Series
        /// </summary>
        private void cboSeries_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboSerieCambioValor != null)//Que el evento público no venga sin argumntos
            {
                if (cboSeries.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    Serie.Id = (int)cboSeries.SelectedValue;
                    ActualizarSerieDocumental();
                    cboSerieCambioValor(this, e);//Diparar el Evento
                }
            }
            else
            {
                if (cboSeries.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    Serie.Id = (int)cboSeries.SelectedValue;
                    ActualizarSerieDocumental();
                }
            }
        }
        /// <summary>
        /// Cambio de Selección del Combo Tema
        /// </summary>
        private void cboTema_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboTema.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                Tema.Id = (int)cboTema.SelectedValue;
                if (TemasT.Rows.Count > 0)
                {
                    txtNombreExp.Enabled = false;
                    if (cboTema.Text != "System.Data.DataRowView")
                    {
                        NombreExpediente = cboTema.Text;
                        txtNombreExp.Text = NombreExpediente;
                        chkAddTema.Checked = false;
                    }
                }
                else
                {
                    txtNombreExp.Text = string.Empty;
                    NombreExpediente = string.Empty;
                    txtNombreExp.Enabled = true;
                }
            }
        }
        /// <summary>
        /// Acceder al Objeto ClasificacionModel
        /// </summary>
        private void cboClasificaciones_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboClasificaciones.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                Clasificacion.Id = (int)cboClasificaciones.SelectedValue;
            }
        }
        /// <summary>
        /// Acceder al Objeto Valores>doctalesModel
        /// </summary>
        private void cboValorDoctal_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboValorDoctal.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                ValorDoctal.Id = (int)cboValorDoctal.SelectedValue;
            }
        }
        /// <summary>
        /// Cambio del Valor del Check Cuenta Sevi
        /// </summary>
        private void chkTieneSevi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkTieneSevi.Checked)
            {
                CtaSevi = chkTieneSevi.Checked;
                txtCveSevi.Enabled = true;
            }
            else
            {
                CtaSevi = chkTieneSevi.Checked;
                txtCveSevi.Enabled = false;
            }
        }

        #endregion

        #region Funciones Públicas

        /// <summary>
        /// Función para Validar los campos dentro del control
        /// </summary>
        /// <returns>Boleano</returns>
        public bool ValidarCampos()
        {
            //Asignar la Fecha de la Serie
            FechaSerie = dtpFecha.Value;
            //Asignar el Nombre de Expediente
            if (!string.IsNullOrEmpty(txtNombreExp.Text)) { NombreExpediente = txtNombreExp.Text; }

            if (!string.IsNullOrEmpty(Seccion.Id))//VAlidar que no venga vacío el identificador de Seccion
            {
                if (Serie.Id > 0)// VAlidar que la serie seleccionada sea válida
                {
                    if (Clasificacion.Id > 0)
                    {
                        if (ValorDoctal.Id > 0)
                        {
                            if (!string.IsNullOrEmpty(txtDescExpe.Text))
                            {
                                Descripcion = txtDescExpe.Text;

                                if (!string.IsNullOrEmpty(txtOtraInfo.Text)) { OtraInfo = txtOtraInfo.Text; }

                                if (chkTieneSevi.Checked)// Si está seleccionado la opción de clave SEVI
                                {
                                    if (string.IsNullOrEmpty(txtCveSevi.Text))//Validar que se ingrese clave SEVI
                                    {
                                        MessageBox.Show("debe de ingresar una clave sevi".ToUpper(),
                                        ":: mensaje desde el control serie documental, opció ; ".ToUpper() + Opciones().ToUpper() + " ::",
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        return false;
                                    }
                                }
                                if(chkAddTema.Checked)// Si está seleccionado el Agregar el Tema/Nombre Expediente
                                {
                                    if(string.IsNullOrEmpty(txtNombreExp.Text))
                                    {
                                        MessageBox.Show("debe de ingresar un tema".ToUpper(),
                                        ":: mensae desde el control serie documental".ToUpper() + Opciones().ToUpper() + " ::",
                                        MessageBoxButtons.OK,MessageBoxIcon.Error);
                                        return false;
                                    }
                                }


                                return true;
                            }
                            else
                            {
                                MessageBox.Show("debe de ingresar una descripción de la serie documental.".ToUpper(),
                                ":: mensaje desde control serie documental, opción : ".ToUpper() + Opciones().ToUpper() + " ::",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("debe seleccionar un valor documental de la serie documental.".ToUpper(),
                            ":: mensaje desde control serie documental, opción : ".ToUpper() + Opciones().ToUpper() + " ::",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("debe seleccionar una clasificación de la serie documental.".ToUpper(),
                        ":: mensaje desde control serie documental, opción : ".ToUpper() + Opciones().ToUpper() + " ::",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }

                }
                else
                {
                    MessageBox.Show("seleccione una opción de las Series.".ToUpper(),
                    ":: mensaje desde control serie documental, opción : ".ToUpper() + Opciones().ToUpper() + " ::",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else
            {
                MessageBox.Show("seleccione una opción de la secciones.".ToUpper(),
                ":: mensaje desde control serie documental, opción : ".ToUpper() + Opciones().ToUpper() + " ::",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }

        #endregion

        #region Funciones Privadas

        /// <summary>
        /// Generar el Consecutivo para la Serie Documental
        /// </summary>
        /// <returns>string</returns>
        private string Consecutivo()
        {
            if (chkConsecutivo.Checked)
            {
                if (string.IsNullOrEmpty(txtConsecutivo.Text))//Si el campo Consecutivo es vacío
                {
                    return "0000";//Rellenar con el valor de ceros
                }
                else
                {
                    switch (txtConsecutivo.Text.Length)//Si no es vacío, ver el tamaño el consecutivo
                    {
                        case 1:
                            return "000" + txtConsecutivo.Text;
                        case 2:
                            return "00" + txtConsecutivo.Text;
                        case 3:
                            return "0" + txtConsecutivo.Text;
                        case 4:
                            return txtConsecutivo.Text;
                        default:
                            return "0000";
                    }
                }
            }
            else
            {
                if (GetConsecutivo())
                { return _consecutivo; }
                else
                { return "0001"; }
            }
        }
        /// <summary>
        /// Obtener el Consecutivo de la Serie Documental
        /// </summary>
        /// <returns></returns>
        public bool GetConsecutivo()
        {
            rm.SerieDoctal = NumeroSerieDocumental;
            rm.FechaInicio = dtpFecha.Value;

            if (rc.ConsecutivoRegistroSeries(rm))//Intentar la Consulta del Procedimiento
            {
                //_consecutivo = "0000";
                if(rc.Tabla.Rows.Count > 0)
                {
                    int valcons = ((int)rc.Tabla.Rows[0][0]) + 1;
                    string cons = valcons.ToString();

                    switch(cons.Length)
                    {
                        case 1:
                            _consecutivo = "000" + cons;
                            break;
                        case 2:
                            _consecutivo = "00" + cons;
                            break;
                        case 3:
                            _consecutivo = "0" + cons;
                            break;
                        case 4:
                            _consecutivo = cons;
                            break;
                        default:
                            _consecutivo = "0000";
                            break;
                    }
                    return true;
                }
                else
                { _consecutivo = "0000"; return false; }
                
            }
            else//Intento NO Exitoso
            {
                MessageBox.Show("ocurrió el siguiente error : ".ToUpper() + "\n" +
                    rc.Error.ToUpper(), ":: mensaje de control serie documental, opción : ".ToUpper() + Opciones().ToUpper() + " ::",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
        #endregion

        public void SerieDocumental_Load(object sender, SerieControlEventArgs e)
        {
            var u = (UsuariosModel)sender;
            opc = e.Opcion;
            _usuario = u;
            cboSeries.Enabled = false;
            cboSeries.Enabled = false;
            txtCveSevi.Enabled = false;
            txtConsecutivo.Enabled = false;
            switch (opc)//Validar las Opciones enviadas
            {
                case 1:
                    chkStatus.Checked = true;
                    chkStatus.Enabled = false;
                    break;
                default:

                    break;
            }
            CargaInicial();
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            FechaSerie = dtpFecha.Value;
            ActualizarSerieDocumental();
        }

        private void chkConsecutivo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkConsecutivo.Checked)//Verificar si está seleccionado
            {
                //Si lo está
                txtConsecutivo.Enabled = true;
                txtConsecutivo.Focus();
            }
            else//No lo está
            {
                txtConsecutivo.Text = string.Empty;
                txtConsecutivo.Enabled = false;
            }
        }

        private void txtConsecutivo_TextChanged(object sender, EventArgs e)
        {
            ActualizarSerieDocumental();
        }
        ///<summary>
        /// Cambio del valor del CheckBox Agregar Tema
        ///</summary>
        private void chkAddTema_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAddTema.Checked)
            {
                if (_temast.Rows.Count > 0)
                {
                    txtNombreExp.Enabled = true;
                    txtNombreExp.Text = string.Empty;
                    cboTema.Enabled = false;
                }
            }
            else
            {
                txtNombreExp.Enabled = false;
                if (_temast.Rows.Count < 1)
                {
                    cboTema.Enabled = true;
                }
            }

            _agregarTema = chkAddTema.Checked;
        }
        /// <summary>
        /// Método para indicar si la serie cuenta con archivo Digitalizado
        /// </summary>
        private void chkDigitalizado_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDigitalizado.Checked)
            {
                formatDigitalizados();
                _ofd = new OpenFileDialog();
                _ofd.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif|" +
                    "PDF Files(*.pdf)|*.pdf|Documento Word(*.doc)|*.doc|Documento Word(*.docx)|*.docx|" +
                    "Hoja de Cálculo(*.xls)|*.xls|Hoja de Cálculo(*.xlsx)|*.xlsx|Todos Los Archivos(*.*)|*.*";
                _ofd.Title = "eliga archivo a guardar".ToUpper();
                if (_ofd.ShowDialog() == DialogResult.OK)
                {
                    byte[] docu = File.ReadAllBytes(_ofd.FileName);
                    DataRow r = _DTdigitalizados.NewRow();
                    r["extension"] = Path.GetExtension(_ofd.FileName);
                    r["documento"] = docu;
                    r["nombredoc"] = Path.GetFileName(_ofd.FileName);
                    r["tamaño"] = File.ReadAllBytes(_ofd.FileName).Length;
                    r["folio"] = _DTdigitalizados.Rows.Count + 1;
                    _DTdigitalizados.Rows.Add(r);
                }
                cmdAddFiles.Enabled = true;
                cmdAddFiles.Visible = true;
                lblArchivoDig.Text = Path.GetFileName(_ofd.FileName);
            }
            else // No Agregar Archivo Digitalizado, eliminar todos los que hayamos Cargado
            {
                _DTdigitalizados.Clear();
                cmdAddFiles.Enabled = false;
                cmdAddFiles.Visible = false;
                lblArchivoDig.Text = "::";
            }


            _digitalizado = chkDigitalizado.Checked;//Asignar valor a propiedad Digitalizado
        }
        /// <summary>
        /// Agregar más Archivos Digitalizados
        /// </summary>
        private void cmdAddFiles_Click(object sender, EventArgs e)
        {
            DataRow[] foundRows = null;
            _myToolTip = new ToolTip();
            _myToolTip.ToolTipIcon = ToolTipIcon.None;
            _myToolTip.IsBalloon = true;
            _myToolTip.ShowAlways = true;

            if (_ofd.ShowDialog() == DialogResult.OK)
            {
                //Stream myStream;
                //myStream = _ofd.OpenFile();
                byte[] docu = File.ReadAllBytes(_ofd.FileName);

                DataRow r = _DTdigitalizados.NewRow();
                r["extension"] = Path.GetExtension(_ofd.FileName);
                r["documento"] = docu;
                r["nombredoc"] = Path.GetFileName(_ofd.FileName);
                r["tamaño"] = File.ReadAllBytes(_ofd.FileName).Length;
                r["folio"] = _DTdigitalizados.Rows.Count + 1;
                string expression = "nombredoc = " + "'" + r["nombredoc"].ToString() + "'";
                foundRows = _DTdigitalizados.Select(expression);
                if (foundRows.Length == 0)
                {
                    _DTdigitalizados.Rows.Add(r);
                }
                else
                {
                    MessageBox.Show("ya existe este archivo.".ToUpper(), ":: mensaje desde el control seire documental ::".ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

            string _archivos = string.Empty;

            foreach (DataRow r in _DTdigitalizados.Rows)
            {
                _archivos += r["nombredoc"].ToString() + "\n";
            }

            _myToolTip.SetToolTip(lblArchivoDig, _archivos);
        }
        /// <summary>
        /// Formato de la tabla que guarda los documentos digitalizados
        /// </summary>
        private void formatDigitalizados()
        {
            _DTdigitalizados = new DataTable();//Inicializar la tabla
            _DTdigitalizados.Columns.Add("extension");
            _DTdigitalizados.Columns.Add("documento",typeof(byte[]));
            _DTdigitalizados.Columns.Add("nombredoc");
            _DTdigitalizados.Columns.Add("tamaño");
            _DTdigitalizados.Columns.Add("folio");
        }
        /// <summary>
        /// Dejar el Control de Nombre de Expediente
        /// </summary>
        private void txtNombreExp_Leave(object sender, EventArgs e)
        {
            if (chkAddTema.Checked)//Si está seleccionado 
            {
                if (!string.IsNullOrEmpty(txtNombreExp.Text))//Que no esté vació el campo
                {
                    this.Tema.Tema = txtNombreExp.Text;
                }
            }
        }
    }
}
