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
            if(this.validarControles())
            {
                this.llenarObjetoUsuario();
                if(uc.validarUsuario(um))
                {
                    if(uc.validarContraseña(um))
                    {
                        if (uc.obtenerId_Estatus(um))
                        {
                            if ((bool)uc.Tabla.Rows[0][14])
                            {
                                Utilerias.IdUsuario = (int)uc.Tabla.Rows[0][0];
                                this.DialogResult = DialogResult.OK;
                            }
                            else
                            {
                                MessageBox.Show("usuario desactivado.".ToUpper(),
                                    "..:: mensaje del sistema ::..".ToUpper(),
                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Ocurrió el siguiente error :" +
                                "\n" + uc.Error, "..:: mensaje desde el login del sistema ::..".ToUpper(),
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Ocurrió el siguiente error :" +
                        "\n" + uc.Error,"..:: mensaje desde el login del sistema ::..".ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
       /// <summary>
       /// Validaciones de los Controles
       /// </summary>
       /// <returns>Boleano</returns>
        private bool validarControles()
        {
            if(!string.IsNullOrEmpty(txtUsuario.Text))// Qué no esté vacío el campo de usuario
            {
                if(txtUsuario.Text.Length >= 6)// Usuario no puede ser menor a 6 caracteres
                {
                    if(!string.IsNullOrEmpty(txtContraseña.Text))//Que no esté vacío el campo de contraseña
                    {
                        if(txtContraseña.Text.Length >= 6)// si contraseña es menor a 6 Caracteres
                        {
                            return true;
                        }
                        else
                        {
                            MessageBox.Show("la contraseña no puede ser menor a 6 caracteres.".ToUpper(),
                                "..:: mensaje del sistema ::..".ToUpper(),
                                MessageBoxButtons.OK,MessageBoxIcon.Warning);
                            txtContraseña.SelectAll();
                            txtContraseña.Focus();
                            return false;
                        }
                    }
                    else
                    {
                        MessageBox.Show("no deje vacío el campo de contraseña".ToUpper(),
                            "..:: mensaje del sistema ::..".ToUpper(),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtContraseña.Focus();
                        return false;
                    }
                }
                else
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
