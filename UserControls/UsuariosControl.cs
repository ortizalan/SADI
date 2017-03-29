using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
        private string _nombre;// Propiedad para el nombre del Usuario
        private string _paterno;// Propiedad para el Apellido Paterno del Usuario
        private string _materno;// Propiedad para el Apellido Materno del Usuario
        private bool _estatus;// Propiedad para Indicar el Estatus del Usuario
        private string _usuario;// Propiedad del Usuario
        private string _contraseña;// Propiedad Contraseña
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
        /// </summary>
        public int Opcion
        {
            get { return _oopcion; }
            set { _oopcion = value; }
        }
        /// <summary>
        /// Asignar los Valores de Jerarquia
        /// </summary>
        public DataTable Jerarquia
        {
            set
            {
                _jerarquias = value;
            }
        }
        /// <summary>
        /// Asignar los Valores a Subfondo
        /// </summary>
        public DataTable SubFondo
        {
            set { _subfondo = value; }
        }
        /// <summary>
        /// Asignar Valores a la Unidad Administrativa
        /// </summary>
        public DataTable UnidadAdmva
        {
            set { _unidadAdmva = value; }
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
        public string Constraseña
        {
            get { return _contraseña; }
            set
            {
                _contraseña = value;
                txtContraseña.Text = _contraseña;
            }
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
                        if (txtUsuario.Text.Length < 6)// Validar que el campos usuario no sea menor a 6 caracteres
                        {
                            if (!string.IsNullOrEmpty(txtContraseña.Text))// Validar que el campo contraseña no esté vació
                            {
                                if (txtContraseña.Text.Length < 6)// Validar que la contraseña no sea menor a 6 caracteres
                                {
                                    return true;// Todos los campos validos
                                }
                                else
                                {
                                    MessageBox.Show("la contraseña no puede ser menor a 6 caracteres.".ToUpper(), "..:: advertencia del sistema ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    txtContraseña.SelectAll();
                                    txtContraseña.Focus();
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("No deje vaío el campo contraseña.".ToUpper(), "..:: advertencia del sistema ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txtContraseña.Focus();
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("el usuario no puede ser menor a 6 caracteres.".ToUpper(), "..:: advertencia del sistema ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtUsuario.SelectAll();
                            txtUsuario.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("No deje vaío el campo Usuario.".ToUpper(), "..:: advertencia del sistema ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtUsuario.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("No deje vaío el campo apellido paterno.".ToUpper(), "..:: advertencia del sistema ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPaterno.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("No deje vaío el campo nombre.".ToUpper(), "..:: advertencia del sistema ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombre.Focus();
                return false;
            }
        }

        //Si cambia el Valor Nombre
        private void txtNombre_Leave(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(this.txtNombre.Text))
            { this.Nombre = txtNombre.Text; }
        }
        //Si cambia el Valor Paterno
        private void txtPaterno_Leave(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtPaterno.Text))
            {
                this.Paterno = txtPaterno.Text;
            }
        }
        // Si cambia el Valor Materno
        private void txtMaterno_Leave(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtMaterno.Text))
            {
                this.Materno = txtMaterno.Text;
            }
        }
        // Si cambia el Valor de Usuario
        private void txtUsuario_Leave(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtUsuario.Text))
            {
                this.Usuario = txtUsuario.Text;
            }
        }
        // Si cambia el Valor
        private void txtContraseña_Leave(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(txtContraseña.Text))
            {
                this.Constraseña = txtContraseña.Text;
            }
        }
    }
}
