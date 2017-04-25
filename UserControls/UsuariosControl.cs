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
        private int _oopcion; //Opcion para Validar Las Operaciones a Realizar con el Control
        private DataTable _jerarquias;// Tabla para llenar el Combo Jerarquías
        private DataTable _subfondo;// Tabla para llenar el Combo SubFondos
        private DataTable _unidadAdmva; // Tabla para llenar la Unidad Administrativa
        private DataTable _seccion; // Tabla para llenar la Sección del Usuario
        private string _nombre;// Propiedad para el nombre del Usuario
        private string _paterno;// Propiedad para el Apellido Paterno del Usuario
        private string _materno;// Propiedad para el Apellido Materno del Usuario
        private string _email; // Propiedad para el correo electrónico del Usuario
        private bool _estatus;// Propiedad para Indicar el Estatus del Usuario
        private string _usuario;// Propiedad del Usuario
        private string _contraseña;// Propiedad Contraseña
        private int _idJerarquia;// Identificador de la Jerarquia
        private int _idSubFondo;// Identificador del Subfondo
        private int _idUnidadAdmva;// Identificador de la Unidad Administrativa
        private string _idSeccion;// Identificador de la Sección
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
            get { return _oopcion; }
            set { _oopcion = value; if (value == 1) { chkEstatus.Checked = true; } }
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
        /// Asignar los Valores a Subfondo
        /// </summary>
        public DataTable SubFondo
        {
            set
            {
                _subfondo = value;
                this.LLenarSubFondo();
            }
        }
        /// <summary>
        /// Asignar Valores a la Unidad Administrativa
        /// </summary>
        public DataTable UnidadAdmva
        {
            set
            {
                _unidadAdmva = value;
                this.LLenarUnidadAdmva();
            }
        }
        /// <summary>
        /// Asignar Valores a la Sección
        /// </summary>
        public DataTable Seccion
        {
            set
            {
                _seccion = value;
                this.LLenarSeccion();
            }
        }
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
        /// Identificador de la Unidad Administrativa
        /// </summary>
        public int IdUnidadAdmva
        {
            get { return _idUnidadAdmva; }
            set { _idUnidadAdmva = value; }
        }
        /// <summary>
        /// Identificador de la Sección
        /// </summary>
        public string IdSeccion
        {
            get { return _idSeccion; }
            set { _idSeccion = value; }
        }
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
                                    if(!string.IsNullOrEmpty(txtEmail.Text))// Validar que no esté vació el campo del correo electrónico
                                    {
                                        if (Utilerias.ValidarEmail(txtEmail.Text))// Validar que sea válida la dirección de correo electrónico
                                        {
                                            return true;// Todos los campos validos
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
                MessageBox.Show("No deje vaío el campo nombre.".ToUpper(), "..:: advertencia del control usuario ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
        }
        // Método para Llenar el Combo SubFondos
        private void LLenarSubFondo()
        {
            if (_subfondo != null)
            {
                if (_subfondo.Rows.Count > 0)
                {
                    cboSubFondo.DataSource = _subfondo;
                    cboSubFondo.ValueMember = "Id";
                    cboSubFondo.DisplayMember = "SubFondo";
                }
            }
        }
        //  Método para Llenar el Combo UnidadesAdmvas
        private void LLenarUnidadAdmva()
        {
            if (_unidadAdmva != null)
            {
                if (_unidadAdmva.Rows.Count > 0)
                {
                    cboUnidadAdmva.DataSource = _unidadAdmva;
                    cboUnidadAdmva.ValueMember = "Id";
                    cboUnidadAdmva.DisplayMember = "Unidad";
                }
            }
        }
        // Método para Llenar el Combo Seccion
        private void LLenarSeccion()
        {
            if(_seccion != null)// Que no esté vacia la tabla
            {
                if(_seccion.Rows.Count > 0)// Que contenga al menos 1 registro
                {
                    cboSeccion.DataSource = _seccion;
                    cboSeccion.ValueMember = "Id";
                    cboSeccion.DisplayMember = "Seccion";
                }
            }
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
            if (_oopcion == 1)// Si la opción es Ingresar un Nuevo Usuario
            {
                chkEstatus.Enabled = false;
                chkEstatus.Checked = true;
            }
            else
            {
                chkEstatus.Enabled = true;
                chkEstatus.Checked = false;
            }
        }
        //Cambio de Valor Seleccionado en ComboBox Jerarquias
        private void cboJerarquia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboJerarquia.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                _idJerarquia = (int)cboJerarquia.SelectedValue;
            }
        }
        //Cambio de Valor Seleccionado en ComboBox SubFondos
        private void cboSubFondo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSubFondo.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                _idSubFondo = (int)cboSubFondo.SelectedValue;
            }
        }
        // Cambio de Valor Seleccionado en ComboBox UnidadAdmva
        private void cboUnidadAdmva_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboUnidadAdmva.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                _idUnidadAdmva = (int)cboUnidadAdmva.SelectedValue;
            }
        }
        // Cambio de Valor Seleccionado en ComboBox Sección
        private void cboSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboSeccion.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                _idSeccion = (string)cboSeccion.SelectedValue;
            }
        }
        // Cambio de valor CheckBox Estatus
        private void chkEstatus_CheckedChanged(object sender, EventArgs e)
        {
            if (_oopcion == 1)// Si es ingreso de nuevo Usuario, siempre será Activo
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

            if (_oopcion == 0)
            {
                switch (_oopcion)
                {
                    case 1:// Ingresar Usuario
                        this.chkEstatus_CheckedChanged(o, e);
                        return true;

                    case 2:// Modificar Usuario
                        if (_idJerarquia != 0 && _idSubFondo != 0 && _idUnidadAdmva != 0)// Verificar que tenga valores asignado el usuario
                        {
                            if (_jerarquias.Rows.Count > 0 && _subfondo.Rows.Count > 0 &&
                                _unidadAdmva.Rows.Count > 0)// Verificar que exista información para cargar a los combos
                            {
                                txtNombre.Text = _nombre;// Asignar el Nombre
                                txtPaterno.Text = _paterno;// Asignar el Apellido Paterno
                                txtMaterno.Text = (!string.IsNullOrEmpty(_materno) ? _materno : string.Empty); // Asignar Materno
                                txtUsuario.Text = _usuario;//Asignar Usuario
                                txtContraseña.Text = _contraseña;// Asignar contraseña
                                txtEmail.Text = _email;// Asignar el correo electrónico
                                chkEstatus.Checked = _estatus;// Asignar Estatus
                                cboJerarquia.SelectedValue = _idJerarquia;// Indicarle la Jerarquía
                                cboSubFondo.SelectedValue = _idSubFondo;// Indicarle el SubFondo
                                cboUnidadAdmva.SelectedValue = _idUnidadAdmva;// Indicarle la Unidad Adsministrativa
                                return true;
                            }
                            else
                            {
                                MessageBox.Show("Debe enviar información a los combobox".ToUpper(),
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
                        if (_idJerarquia != 0 && _idSubFondo != 0 && _idUnidadAdmva != 0)// Verificar que tenga valores asignado el usuario
                        {
                            if (_jerarquias.Rows.Count > 0 && _subfondo.Rows.Count > 0 &&
                                _unidadAdmva.Rows.Count > 0)// Verificar que exista información para cargar a los combos
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
                                cboSubFondo.SelectedValue = _idSubFondo;// Indicarle el SubFondo
                                cboSubFondo.Enabled = false;// Inhabilitar control
                                cboUnidadAdmva.SelectedValue = _idUnidadAdmva;// Indicarle la Unidad Adsministrativa
                                cboUnidadAdmva.Enabled = false;// Inhabilitar control
                                return true;
                            }

                            else
                            {
                                MessageBox.Show("Debe enviar información a los combobox".ToUpper(),
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
            switch(_oopcion)
            {
                case 1:
                    this.chkEstatus.Checked = true;
                    break;
            }
        }
    }
}
