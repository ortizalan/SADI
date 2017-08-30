using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SADI.Clases;


namespace SADI.UserControls
{
    /// <summary>
    /// Control para el Modelo Usuarios
    /// </summary>
    public partial class UsuariosControl : UserControl
    {
        #region Propiedades
        private int _opcion; //Opcion para Validar Las Operaciones a Realizar con el Control
        private DataTable _jerarquias;// Tabla para llenar el Combo Jerarquías
        private DataTable _subfondos;// Tabla para llenar el Combo SubFondos
        private DataTable _departamentos;//Tabla para llenar combo Departamentos
        private DataTable _areasmedicas;//Tabla para llenar las Áreas Médicas
        private DataTable _subareas;// Tabla para llenar las SubÁreas Médicas
        private DataTable _servicios;//Tabla para llenar los Servicios de las SubAreas
        private string _nombre;// Propiedad para el nombre del Usuario
        private string _paterno;// Propiedad para el Apellido Paterno del Usuario
        private string _materno;// Propiedad para el Apellido Materno del Usuario
        private string _email; // Propiedad para el correo electrónico del Usuario
        private bool _estatus;// Propiedad para Indicar el Estatus del Usuario
        private string _usuario;// Propiedad del Usuario
        private string _contraseña;// Propiedad Contraseña
        private int _idJerarquia;// Identificador de la Jerarquia
        private int _idSubFondo;// Identificador del SubFondo
        private int _idDepartamento;//Identificadoe del Departamento
        private int _idAreaMedica;//Identificador del Área Médica
        private int _idSubArea;//Identificador de la SubÁrea Médica
        private int _idServicios;//Identificador del Servicio

        #endregion

        #region Eventos Públicos

        public event EventHandler cboSubFondosChange;//Manejador del Evento
        public event EventHandler cboDepartamentosChange;//Manejador del Evento
        public event EventHandler cboAreasMedicasChange;//Manejador del Evento
        public event EventHandler cboSubAreasChange;//Manejador del Evento
        public event EventHandler cboServiciosChange;//Manejador del Evento

        #endregion

        /// <summary>
        /// Constructor del Control
        /// </summary>
        public UsuariosControl()
        {
            InitializeComponent();
        }

        # region getters / setters
        /// <summary>
        /// Acceder a la Propiedad Opción del Control para evaluar
        /// Operaciones a Efectuar
        /// Opcion: 1) Ingresar Nuevo, 2) Modificar Usuario, 3) Ver Detalles Usuario
        /// </summary>
        public int Opcion
        {
            get { return _opcion; }
            set { _opcion = value; if (value == 1) { chkEstatus.Checked = true; } }
        }
        /// <summary> 
        /// Asignar los Valores de Jerarquia
        /// </summary>
        public DataTable Jerarquia
        {
            set
            {
                _jerarquias = value;
                this.LLenarJerarquias();
            }
        }
        /// <summary>
        /// Asignar lod Valores a SubFondos
        /// </summary>
        public DataTable SubFondo
        {
            set
            {
                _subfondos = value;
                this.LLenarSubfondos();
            }
        }
        /// <summary>
        /// Acceder a los Valores de los Departamentos
        /// </summary>
        public DataTable Departamentos
        { set { _departamentos = value; LLenarDepartamentos(); } }
        /// <summary>
        /// Acceder a los Valores de las Áreas Médicas
        /// </summary>
        public DataTable AreasMedicas
        { set { _areasmedicas = value; LLenarAreasMedicas(); } }
        /// <summary>
        /// Acceder a los Valores de las SubÁreas Méidcas
        /// </summary>
        public DataTable SubAreas
        { set { _subareas = value; LLenarSubAreaMedica(); } }
        /// <summary>
        /// Acceder a los Valores de los Serevicios de las SubÁreas
        /// </summary>
        public DataTable Servicios
        { set { _servicios = value; LLenarServicios(); } }

        /// <summary>
        /// Acceder a la Propiedad Nombre
        /// </summary>
        public string Nombre
        {
            get { return _nombre; }
            set
            {
                _nombre = value;
                txtNombre.Text = _nombre;
            }
        }
        /// <summary>
        /// Acceder a la Propiedad Paterno
        /// </summary>
        public string Paterno
        {
            get { return _paterno; }
            set
            {
                _paterno = value;
                txtPaterno.Text = _paterno;
            }
        }
        /// <summary>
        /// Acceder ala Propiedad Materno
        /// </summary>
        public string Materno
        {
            get { return _materno; }
            set
            {
                _materno = value;
                txtMaterno.Text = _materno;
            }
        }
        /// <summary>
        /// Acceder a la Propiedad Usuario
        /// </summary>
        public string Usuario
        {
            get { return _usuario; }
            set
            {
                _usuario = value;
                txtUsuario.Text = _usuario;
            }
        }
        /// <summary>
        /// Acceder a la Propiedad Contraseña
        /// </summary>
        public string Contraseña
        {
            get { return _contraseña; }
            set
            {
                _contraseña = value;
                txtContraseña.Text = _contraseña;
            }
        }
        /// <summary>
        /// Acceder a la propiedad de correo electrónico
        /// </summary>
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                txtEmail.Text = _email;
            }
        }
        /// <summary>
        /// Accerder a la Propiedad Estatus
        /// </summary>
        public bool Estatus
        {
            get { return _estatus; }
            set
            {
                _estatus = value;
                chkEstatus.Checked = _estatus;
            }
        }
        /// <summary>
        /// Identificador de la jerarquía
        /// </summary>
        public int IdJerarquia
        {
            get { return _idJerarquia; }
            set { _idJerarquia = value; }
        }
        /// <summary>
        /// Identificador del SubFondo
        /// </summary>
        public int IdSubFondo
        {
            get { return _idSubFondo; }
            set { _idSubFondo = value; }
        }
        /// <summary>
        /// Identificador del Departamento
        /// </summary>
        public int IdDepartamento
        { get { return _idDepartamento; } set { _idDepartamento = value; } }
        /// <summary>
        /// Identificador del Area Médica
        /// </summary>
        public int IdAreaMedica
        { get { return _idAreaMedica; } set { _idAreaMedica = value; } }
        /// <summary>
        /// Identificador de la SubArea Médica
        /// </summary>
        public int IdSubAreaMedica
        { get { return _idSubArea; } set { _idSubArea = value; } }
        /// <summary>
        /// Identificador de los Servicios
        /// </summary>
        public int IdServicios
        { get { return _idServicios; } set { _idServicios = value; } }
        #endregion
        /// <summary>
        /// Validar el Control Para su Utilización en la Base de Datos
        /// </summary>
        /// <returns>Boleano</returns>
        public bool ValidarControl()
        {
            if (!string.IsNullOrEmpty(txtNombre.Text))// Validar que no este vació el campo de Nombre del Usuario
            {
                if (!string.IsNullOrEmpty(txtPaterno.Text))// Validar que no esté vació el campo del Apellido Paterno
                {
                    if (!string.IsNullOrEmpty(txtUsuario.Text))// Validar que no esté vació el campo de Usuario
                    {
                        if (txtUsuario.Text.Length >= 6)// Validar que el campos usuario no sea menor a 6 caracteres
                        {
                            if (!string.IsNullOrEmpty(txtContraseña.Text))// Validar que el campo contraseña no esté vació
                            {
                                if (txtContraseña.Text.Length >= 6)// Validar que la contraseña no sea menor a 6 caracteres
                                {
                                    if (!string.IsNullOrEmpty(txtEmail.Text))// Validar que no esté vació el campo del correo electrónico
                                    {
                                        if (Utilerias.ValidarEmail(txtEmail.Text))// Validar que sea válida la dirección de correo electrónico
                                        {
                                            if(_idSubFondo >0)//Validar que esté seleccionado algún subfondo
                                            {
                                                if(_idDepartamento > 0)//Validar que esté seleccionado algún departamento
                                                {
                                                    return true;
                                                }
                                                else
                                                {
                                                    MessageBox.Show("selecciones un departamento.".ToUpper(), "..:: advertencia del control usuario ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                    cboDepartamento.SelectedIndex = 0;
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("selecciones un sunfondo.".ToUpper(), "..:: advertencia del control usuario ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                                cboSubFondo.SelectedIndex = 0;
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("ingrese una dirección de correo electrónico válida.".ToUpper(), "..:: advertencia del control usuario ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            txtEmail.SelectAll();
                                            txtEmail.Focus();
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("no deje vació el campo del correo electrónico".ToUpper(), "..:: advertencia del control usuario ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                        txtEmail.Focus();
                                        return false;
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("la contraseña no puede ser menor a 6 caracteres.".ToUpper(), "..:: advertencia del control usuario ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtContraseña.SelectAll();
                                    txtContraseña.Focus();
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("No deje vaío el campo contraseña.".ToUpper(), "..:: advertencia del control usuario ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtContraseña.Focus();
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("el usuario no puede ser menor a 6 caracteres.".ToUpper(), "..:: advertencia del control usuario ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtUsuario.SelectAll();
                            txtUsuario.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No deje vaío el campo Usuario.".ToUpper(), "..:: advertencia del control usuario ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUsuario.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("No deje vaío el campo apellido paterno.".ToUpper(), "..:: advertencia del control usuario ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPaterno.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("No deje vacío el campo nombre.".ToUpper(), "..:: advertencia del control usuario ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
        }

        //Si cambia el Valor Nombre
        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtNombre.Text))
            { this.Nombre = txtNombre.Text; }
        }
        //Si cambia el Valor Paterno
        private void txtPaterno_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPaterno.Text))
            {
                this.Paterno = txtPaterno.Text;
            }
        }
        // Si cambia el Valor Materno
        private void txtMaterno_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMaterno.Text))
            {
                this.Materno = txtMaterno.Text;
            }
        }
        // Si cambia el Valor de Usuario
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUsuario.Text))
            {
                this.Usuario = txtUsuario.Text;
            }
        }
        // Si cambia el Valor
        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtContraseña.Text))
            {
                this.Contraseña = txtContraseña.Text;
            }
        }
        // Si cambia el valor en el control
        private void txtEmail_Leave_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                _email = txtEmail.Text;// Asignar el valor de correo electrónico
            }
        }
        // Método para Llenar el combo Jerarquías
        private void LLenarJerarquias()
        {
            if (_jerarquias != null)
            {
                if (_jerarquias.Rows.Count > 0)
                {
                    cboJerarquia.DataSource = _jerarquias;
                    cboJerarquia.ValueMember = "Id";
                    cboJerarquia.DisplayMember = "Jerarquia";
                }
            }
            else { cboJerarquia.DataSource = null; }
        }
        //Método para llenar el combo SubFondo
        private void LLenarSubfondos()
        {
            if (_subfondos != null)
            {
                if (_subfondos.Rows.Count > 0)
                {
                    cboSubFondo.DataSource = _subfondos;
                    cboSubFondo.ValueMember = _subfondos.Columns[0].ColumnName;
                    cboSubFondo.DisplayMember = _subfondos.Columns[2].ColumnName;
                }
            }
            else
            { cboSubFondo.DataSource = null; }
        }
        //Método para llenar el Combobox de los Departamentos
        private void LLenarDepartamentos()
        {
            if (_departamentos != null)
            {
                if (_departamentos.Rows.Count > 0)
                {
                    cboDepartamento.DataSource = _departamentos;
                    cboDepartamento.ValueMember = _departamentos.Columns[0].ColumnName;
                    cboDepartamento.DisplayMember = _departamentos.Columns[2].ColumnName;
                }
                else
                {
                    cboDepartamento.DataSource = null;
                }

            }
            else
            {
                cboDepartamento.DataSource = null;
            }

        }
        //Método para llenar el Combobox de las Áreas Médicas
        private void LLenarAreasMedicas()
        {
            if (_areasmedicas != null)
            {
                if (_areasmedicas.Rows.Count > 0)
                {
                    cboArea.DataSource = _areasmedicas;
                    cboArea.ValueMember = _areasmedicas.Columns[0].ColumnName;
                    cboArea.DisplayMember = _areasmedicas.Columns[3].ColumnName;
                }
                else
                {
                    cboArea.DataSource = null;
                }
            }
            else
            {
                cboArea.DataSource = null;
            }

        }
        //Método para llenar el Combobox de las SubÁreas Médicas
        private void LLenarSubAreaMedica()
        {
            if (_subareas != null)
            {
                if (_subareas.Rows.Count > 0)
                {
                    cboSubArea.DataSource = _subareas;
                    cboSubArea.ValueMember = _subareas.Columns[0].ColumnName;
                    cboSubArea.DisplayMember = _subareas.Columns[4].ColumnName;
                }
                else
                {
                    cboSubArea.DataSource = null;
                }
            }
            else
            {
                cboSubArea.DataSource = null;
            }

        }
        //Método pra llenar el Combobox de los Servicios
        private void LLenarServicios()
        {
            if (_servicios != null)
            {
                if (_servicios.Rows.Count > 0)
                {
                    cboServicios.DataSource = _servicios;
                    cboServicios.ValueMember = _servicios.Columns[0].ColumnName;
                    cboServicios.DisplayMember = _servicios.Columns[5].ColumnName;
                }
                else
                {
                    cboServicios.DataSource = null;
                }
            }
            else
            { cboServicios.DataSource = null; }

        }

        /// <summary>
        /// Método para Limpiar el Control Usuario
        /// </summary>
        public void LimpiarControl()
        {
            txtNombre.Text = string.Empty;// Limpiar campo Nombre
            txtPaterno.Text = string.Empty;// Limpiar Campo Paterno
            txtMaterno.Text = string.Empty;// Limpiar Campo Maerno
            txtUsuario.Text = string.Empty;// Limpiar Campo Usuario
            txtContraseña.Text = string.Empty;// Limpiar Campo Contraseña
            txtEmail.Text = string.Empty;// Limpiar el Campo Email
            if (_opcion == 1)// Si la opción es Ingresar un Nuevo Usuario
            {
                chkEstatus.Enabled = false;
                chkEstatus.Checked = true;
            }
            else
            {
                chkEstatus.Enabled = true;
                chkEstatus.Checked = false;
            }
            if (_jerarquias.Rows.Count > 0)// Que no esté vacía la tabla
            {
                if (cboJerarquia.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    cboJerarquia.SelectedIndex = 0;//Seleccionar el primero registro
                }
            }
            if (_subfondos.Rows.Count > 0)//Que no esté vacía la tabla
            {
                if (cboSubFondo.SelectedValue.ToString() != "System.Data.DataRowView")
                {
                    cboSubFondo.SelectedIndex = 0;//Seleccionar el primero registro
                }
            }
        }
        // Cambio de valor CheckBox Estatus
        private void chkEstatus_CheckedChanged(object sender, EventArgs e)
        {
            if (_opcion == 1)// Si es ingreso de nuevo Usuario, siempre será Activo
            {
                chkEstatus.Checked = true;
                chkEstatus.Enabled = false;
            }
            _estatus = chkEstatus.Checked;// Adquirir el valor Boelanos de la operación
        }
        /// <summary>
        /// Método Público para Asegurarnos que se carga el control con la información Enviada
        /// </summary>
        /// <returns>Boleano</returns>
        public bool CargaDeDatosControl()
        {
            object o = string.Empty;
            EventArgs e = null;

            if (_opcion != 0)
            {
                switch (_opcion)
                {
                    case 1:// Ingresar Usuario
                        this.chkEstatus_CheckedChanged(o, e);
                        return true;

                    case 2:// Modificar Usuario
                        if (_idJerarquia != 0)// Verificar que tenga valores asignado el usuario
                        {
                            if (_jerarquias.Rows.Count > 0)// Verificar que exista información para cargar a los combos
                            {
                                txtNombre.Text = _nombre;// Asignar el Nombre
                                txtPaterno.Text = _paterno;// Asignar el Apellido Paterno
                                txtMaterno.Text = (!string.IsNullOrEmpty(_materno) ? _materno : string.Empty); // Asignar Materno
                                txtUsuario.Text = _usuario;//Asignar Usuario
                                txtContraseña.Text = _contraseña;// Asignar contraseña
                                txtEmail.Text = _email;// Asignar el correo electrónico
                                chkEstatus.Checked = _estatus;// Asignar Estatus
                                cboJerarquia.SelectedValue = _idJerarquia;// Indicarle la Jerarquía
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("no existe información de jerarquías.".ToUpper(),
                                    ":: mensaje desde el control usuarios ::".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("debe de enviar la información del usuario al control".ToUpper(),
                                ":: mensaje del contro ::".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                    case 3:// Mostrar Detalles del Usuario
                        if (_idJerarquia != 0)// Verificar que tenga valores asignado el usuario
                        {
                            if (_jerarquias.Rows.Count > 0)// Verificar que exista información para cargar a los combos
                            {
                                txtNombre.Text = _nombre;// Asignar el Nombre
                                txtNombre.Enabled = false;// Deshabilitar el control
                                txtPaterno.Text = _paterno;// Asignar el Apellido Paterno
                                txtPaterno.Enabled = false;//Deshabilitar el control
                                txtMaterno.Text = (!string.IsNullOrEmpty(_materno) ? _materno : string.Empty); // Asignar Materno
                                txtMaterno.Enabled = false;//Deshabilitar el control
                                txtUsuario.Text = _usuario;//Asignar Usuario
                                txtUsuario.Enabled = false;//Deshabilitar el control
                                txtContraseña.Text = _contraseña;// Asignar contraseña
                                txtContraseña.Enabled = false;// Deshabilitar el control
                                txtEmail.Text = _email;// Asignar el correo electrónico
                                txtEmail.Enabled = false;//Deshabilitar el control
                                chkEstatus.Checked = _estatus;// Asignar Estatus
                                chkEstatus.Enabled = false;//Deshabilitar el control
                                cboJerarquia.SelectedValue = _idJerarquia;// Indicarle la Jerarquía
                                cboJerarquia.Enabled = false;// Inhabilitar Combo

                                return true;
                            }

                            else
                            {
                                MessageBox.Show("Debe enviar información de jerarquía".ToUpper(),
                                       ":: mensaje desde el control usuarios ::".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("debe de enviar la información del usuario al control".ToUpper(),
                                   ":: mensaje del contro ::".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return false;
                        }

                    default:
                        return false;
                }
            }
            else
            {
                MessageBox.Show("debe de enviar un valor en opción.".ToUpper(), ":: mensaje desde el control usuarios ::".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
        }
        /// <summary>
        /// Eventos a Cargar el Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UsuariosControl_Load(object sender, EventArgs e)
        {
            switch (_opcion)
            {
                case 1:
                    this.chkEstatus.Checked = true;
                    break;
            }
        }
        //Cambio de Valor Seleccionado en Combo Jerarquía
        private void cboJerarquia_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboJerarquia.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                _idJerarquia = (int)cboJerarquia.SelectedValue;
            }
        }
        //Cambio de Valor Seleccionado en Combobox Subfondos
        private void cboSubFondo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboSubFondosChange != null)//Validar que el evento no sea vacío
            {
                if (cboSubFondo.SelectedValue.ToString() != "System.Data.DataRowView")//Validar que tenga valor el combo
                {
                    _idSubFondo = (int)cboSubFondo.SelectedValue;//Guardar el Identificador
                    cboSubFondosChange(this, e);//Enviarle los parámetros
                }
            }
            else
            {
                if (cboSubFondo.SelectedValue.ToString() != "System.Data.DataRowView")//Validar que tenga valor el combo
                {
                    _idSubFondo = (int)cboSubFondo.SelectedValue;//Guardar el Identificador
                }
            }
        }
        //Cambio de Valor Seleccionado en Combobox Departamentos
        private void cboDepartamento_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboDepartamentosChange != null)
            {
                if (cboDepartamento.SelectedValue != null)
                {
                    if (cboDepartamento.SelectedValue.ToString() != "System.Data.DataRowView")
                    {
                        _idDepartamento = (int)cboDepartamento.SelectedValue;
                        cboDepartamentosChange(this, e);
                    }
                }
            }
            else
            {
                if (cboDepartamento.SelectedValue != null)
                {
                    if (cboDepartamento.SelectedValue.ToString() != "System.Data.DataRowView")
                    {
                        _idDepartamento = (int)cboDepartamento.SelectedValue;
                    }
                }
            }
        }
        //Cambio de Valor Selecionado en Combobox Área Médica
        private void cboArea_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboAreasMedicasChange != null)
            {
                if (cboArea.SelectedValue != null)
                {
                    if (cboArea.SelectedValue.ToString() != "System.Data.DataRowView")
                    {
                        _idAreaMedica = (int)cboArea.SelectedValue;
                        cboAreasMedicasChange(this, e);
                    }
                }
            }
            else
            {
                if (cboArea.SelectedValue != null)
                {
                    if (cboArea.SelectedValue.ToString() != "System.Data.DataRowView")
                    {
                        _idAreaMedica = (int)cboArea.SelectedValue;
                    }
                }
            }
        }
        //Cambio de Valor Seleccionado en Combobox SubÁrea Médica
        private void cboSubArea_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboSubAreasChange != null)
            {
                if (cboSubArea.SelectedValue != null)
                {
                    if (cboSubArea.SelectedValue.ToString() != "System.Data.DataRowView")
                    {
                        _idSubArea = (int)cboSubArea.SelectedValue;
                        cboSubAreasChange(this, e);
                    }
                }
            }
            else
            {
                if (cboSubArea.SelectedValue != null)
                {
                    if (cboSubArea.SelectedValue.ToString() != "System.Data.DataRowView")
                    {
                        _idSubArea = (int)cboSubArea.SelectedValue;
                    }
                }
            }
        }
        //Cmabio de Valor Seleccionado en el ComboBox Servicios
        private void cboServicios_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboServiciosChange != null)
            {
                if (cboServicios.SelectedValue != null)
                {
                    if (cboServicios.SelectedValue.ToString() != "System.Data.DataRowView")
                    {
                        _idServicios = (int)cboServicios.SelectedValue;
                        cboServiciosChange(this, e);
                    }
                }
            }
            else
            {
                if (cboSubArea.SelectedValue != null)
                {
                    if (cboServicios.SelectedValue.ToString() != "System.Data.DataRowView")
                    {
                        _idServicios = (int)cboServicios.SelectedValue;
                    }
                }
            }
        }
    }
}

