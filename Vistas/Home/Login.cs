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

namespace SADI.Vistas.Home
{
    /// <summary>
    /// Forma para Ingresar con Usuario y Contraseña al Sistema
    /// </summary>
    public partial class Login : Form
    {
        UsuariosController uc = new UsuariosController();
        UsuariosModel um = new UsuariosModel();

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public Login()
        {
            InitializeComponent();
        }
        //Salir del Sistema
        private void cmdOUT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cmdIN_Click(object sender, EventArgs e)
        {
            if (this.validarControles())
            {
                this.llenarObjetoUsuario();
                if (uc.validarUsuario(um))//Verificar si existe el usuario
                {
                    if (uc.Tabla.Rows.Count > 0)//Ver si existe registro del usuario
                    {
                        if (uc.validarContraseña(um))//Verificar si es correcta la contraseña
                        {
                            if (uc.Tabla.Rows.Count > 0)// SI es correcta la contraseña
                            {
                                if (uc.obtenerId_Estatus(um))//Verificar el Estatus del Usuario
                                {
                                    if ((bool)uc.Tabla.Rows[0][1])//Validar el Estatus
                                    {
                                        Utilerias.IdUsuario = (int)uc.Tabla.Rows[0][0];
                                        this.DialogResult = DialogResult.OK;//Estatus Activo
                                    }
                                    else//Estatus Inactivo
                                    {
                                        MessageBox.Show("usuario desactivado.".ToUpper(),
                                            "..:: mensaje del sistema ::..".ToUpper(),
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return;
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Ocurrió el siguiente error :" +
                                        "\n" + uc.Error, "..:: mensaje desde el login del sistema ::..".ToUpper(),
                                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    this.Close();
                                }
                            }
                            else // No es correcta la contraseña
                            {
                                MessageBox.Show("la contraseña proporcionada es incorrecta.".ToUpper() + "\n" +
                            "intente nuevamente.".ToUpper(), ":: mensaje desde login ::".ToUpper(),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                // Limpiar los campos y enfocar en el usuario
                                txtContraseña.Clear();
                                txtContraseña.Focus();
                                return;
                            }
                        }
                    }
                    else //NO Existe el Usuario en la Base de Datos
                    {
                        MessageBox.Show("no existe el usuario en la base de datos.".ToUpper() + "\n" +
                            "intente nuevamente.".ToUpper(), ":: mensaje desde login ::".ToUpper(),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        // Limpiar los campos y enfocar en el usuario
                        txtUsuario.Clear();
                        txtContraseña.Clear();
                        txtUsuario.Focus();
                        return;
                    }
                }
                else// No Existe Usuario
                {
                    //Mostrar el Error
                    MessageBox.Show("Ocurrió el siguiente error :" +
                        "\n" + uc.Error, "..:: mensaje desde el login del sistema ::..".ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Close();//Cerrar la ventana / aplicación
                }
            }
        }
        /// <summary>
        /// Validaciones de los Controles
        /// </summary>
        /// <returns>Boleano</returns>
        private bool validarControles()
        {
            if (!string.IsNullOrEmpty(txtUsuario.Text))// Qué no esté vacío el campo de usuario
            {
                if (txtUsuario.Text.Length >= 6)// Usuario no puede ser menor a 6 caracteres
                {
                    if (!string.IsNullOrEmpty(txtContraseña.Text))//Que no esté vacío el campo de contraseña
                    {
                        if (txtContraseña.Text.Length >= 6)// si contraseña es menor a 6 Caracteres
                        {
                            return true;// Todo bien
                        }
                        else
                        {
                            MessageBox.Show("la contraseña no puede ser menor a 6 caracteres.".ToUpper(),
                                "..:: mensaje del sistema ::..".ToUpper(),
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtContraseña.SelectAll();
                            txtContraseña.Focus();
                            return false;//Envia Advertencia
                        }
                    }
                    else
                    {
                        MessageBox.Show("no deje vacío el campo de contraseña".ToUpper(),
                            "..:: mensaje del sistema ::..".ToUpper(),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtContraseña.Focus();
                        return false;//Envía Advertencia
                    }
                }
                else//Si está vacío el campo de la contraseña
                {
                    MessageBox.Show("el campo usuario no puede ser menor a 6 caracteres.".ToUpper(),
                        "..:: mensaje del sistema ::..".ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtUsuario.SelectAll();
                    txtUsuario.Focus();
                    return false;
                }
            }
            else
            {
                MessageBox.Show("no deja vacío el campo usuario".ToUpper(),
                    "..:: mensaje del sistema ::..".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus();
                return false;
            }
        }
        /// <summary>
        /// Asignar Usuario y Contraseña al Objeto
        /// </summary>
        private void llenarObjetoUsuario()
        {
            um.Usuario = txtUsuario.Text;
            um.Contraseña = txtContraseña.Text;
        }
    }
}
