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

namespace SADI.Vistas.Usuarios
{
    public partial class AgregarUsuarios : Form
    {
        UsuariosModel ModelUsr = new UsuariosModel();// Instancia del Modelo de Usuario
        UsuariosController CtrllUsr = new UsuariosController(); // Instancia del Controlador Usuario
        JerarquiasController CtrllJerarquia = new JerarquiasController(); // Instancia del controlador Jerarquías
        SubFondosController CtrllSubF = new SubFondosController(); // Instancia del Cntrolador SubFondos
        UnidadesAdmvasController CtrllUniAdm = new UnidadesAdmvasController(); // Instancia del Controlador UnidadAdmva

        /// <summary>
        /// Constructor de la Forma
        /// </summary>
        public AgregarUsuarios()
        {
            InitializeComponent();// Inicializar el componente
        }

        private void AgregarUsuarios_Load(object sender, EventArgs e)
        {
            chkEstatus.Checked = true;
            chkEstatus.Enabled = false;
            this.LLenasCombos();// LLenar los combos
        }
        /// <summary>
        /// Salir de la Forma
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Función para LLenar el Combo Jerarquías
        /// </summary>
        /// <returns></returns>
        private DataTable Jerarquias()
        {
            if(CtrllJerarquia.ConsultarRegistros())
            {
                return CtrllJerarquia.Tabla;
            }
            else
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + CtrllJerarquia.Error,"..:: error en base de datos ::..".ToUpper() ,MessageBoxButtons.OK,MessageBoxIcon.Error);
                return null;
            }
        }
        /// <summary>
        /// Función Para llenar el Combo SubFondo
        /// </summary>
        /// <returns></returns>
        private DataTable SubFondo()
        {
            if(CtrllSubF.ConsultarRegistros())
            {
                return CtrllSubF.Tabla;
            }
            else
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + CtrllSubF.Error, "..:: error en base de datos ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        /// <summary>
        /// Función para LLenar el Combo Unidad Administrativa
        /// </summary>
        /// <returns></returns>
        private DataTable UnidadAdmva()
        {
            if(CtrllUniAdm.ConsultarRegistros())
            {
                return CtrllUniAdm.Tabla;
            }
            else
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + CtrllUniAdm.Error, "..:: error en base de datos ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        /// <summary>
        /// Método para el Llenado de los COmbos
        /// </summary>
        private void LLenasCombos()
        {
            cboJerarquia.DataSource = this.Jerarquias();
            cboJerarquia.ValueMember = "Id";
            cboJerarquia.DisplayMember = "Jerarquia";
            cboSubFondo.DataSource = this.SubFondo();
            cboSubFondo.ValueMember = "Id";
            cboSubFondo.DisplayMember = "SubFondo";
            cboUnidadAdmva.DataSource = this.UnidadAdmva();
            cboUnidadAdmva.ValueMember = "Id";
            cboUnidadAdmva.DisplayMember = "Unidad";
        }
        /// <summary>
        /// Función para la validación de los controles dela forma
        /// </summary>
        /// <returns>Boleano</returns>
        private bool validarControles()
        {
            if(!string.IsNullOrEmpty(txtNombre.Text))// Validar que no este vació el campo de Nombre del Usuario
            {
                if(!string.IsNullOrEmpty(txtPaterno.Text))// Validar que no esté vació el campo del Apellido Paterno
                {
                    if(!string.IsNullOrEmpty(txtUsuario.Text))// Validar que no esté vació el campo de Usuario
                    {
                        if(txtUsuario.Text.Length < 6)// Validar que el campos usuario no sea menor a 6 caracteres
                        {
                            if(!string.IsNullOrEmpty(txtContraseña.Text))// Validar que el campo contraseña no esté vació
                            {
                                if(txtContraseña.Text.Length < 6)// Validar que la contraseña no sea menor a 6 caracteres
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

            return false;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(this.validarControles())
            {

            }
        }
    }
}
