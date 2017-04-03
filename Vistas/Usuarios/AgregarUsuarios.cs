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
using SADI.Clases;

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
            usuariosControl1.Jerarquia = this.Jerarquias();// Llenar el combo Jerarquias en el Control
            usuariosControl1.SubFondo = this.SubFondo();// LLenar el combo SubFondo en el Control
            usuariosControl1.UnidadAdmva = this.UnidadAdmva();// Llenar el combo de UnidadesAdmvas en el Control
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(usuariosControl1.ValidarControl())
            {
                // Probando el cifrado de la contraseña
                string cifrado = Seguridad.Encriptar(usuariosControl1.Constraseña);
                MessageBox.Show("el mensaje cifrado es :".ToUpper() + "\n" + cifrado +
                    "\n\n" + "y descifrado es :" + "\n" + Seguridad.Desencriptar(cifrado));
            }
        }
    }
}
