using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SADI.Clases.Controladores;
using SADI.Clases.Modelos;
using SADI.Vistas.Usuarios;
using SADI.Clases;

using DatosBD;


namespace SADI
{
    public partial class Inicio : Form
    {
        UsuariosController uc = new UsuariosController();
        UsuariosModel um = new UsuariosModel();

        public Inicio()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor de la Forma
        /// </summary>
        /// <param name="u">Objeto del tipo UsuariosModel</param>
        public Inicio(UsuariosModel u)
        {
            InitializeComponent();
        }
        private void Inicio_Load(object sender, EventArgs e)
        {
            um.Id = Utilerias.IdUsuario;
            this.llenarObjetoUsuario();
            this.Text = "..:: Sistame de Adminitración Arcivística ISSSTESON ::..";
            this.Text += "\t" + "Usuario :" + um.Nombre + " " + um.Paterno + " " + um.Materno;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string u = Utilerias.UserDomain;
            MessageBox.Show("nombre del equipo : " + Utilerias.ComputerName + "\n\n" +
                 "dirección IP: " + Utilerias.IpAddress + "\n\n" +
                 "nombre del Dominio : " + Utilerias.NombreDominio + "\n\n" +
                 "usuario de Dominio : " + Utilerias.UserDomain);
        }
        /// <summary>
        /// Llenar el Objeto Usuario
        /// </summary>
        private void llenarObjetoUsuario()
        {
            if (uc.ConsultarRegistro(um))// Consultar el Usuario por Identificación
            {
                if (uc.Tabla.Rows.Count > 0)// SI trae el registro
                {
                    um.Usuario = (string)uc.Tabla.Rows[0][1];
                    um.Nombre = (string)uc.Tabla.Rows[0][3];
                    um.Paterno = (string)uc.Tabla.Rows[0][4];
                    um.Materno = (string)uc.Tabla.Rows[0][5];
                    um.Fondo.Id = (int)uc.Tabla.Rows[0][6];
                    um.SubFondo.Id = (int)uc.Tabla.Rows[0][7];
                    um.UnidadAdmva.Id = (int)uc.Tabla.Rows[0][8];
                    um.Jerarquia.Id = (int)uc.Tabla.Rows[0][9];
                    um.Email = (string)uc.Tabla.Rows[0][10];
                    um.Estatus = (bool)uc.Tabla.Rows[0][11];
                }
            }
            else// No se pudo realizar la COnsulta
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() +
                    "\n" + uc.Error, "..:: mensaje desde el inicio del sistema ::..".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nuevoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AgregarUsuarios AddUsr = new AgregarUsuarios();
            AddUsr.MdiParent = this;
            AddUsr.Show();
        }
    }
}
