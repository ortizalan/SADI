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
        SeccionesController CtrllSeccion = new SeccionesController();// Instancia del Controlador Secciones

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
        /// <returns>DataTable</returns>
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
        /// <returns>DataTable</returns>
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
        /// <returns>DataTable</returns>
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
        /// Funcion Para LLenar el COmbo Secciones
        /// </summary>
        /// <returns>DataTable</returns>
        private DataTable Secciones()
        {
            if(CtrllSeccion.ConsultarRegistros())
            {
                return CtrllSeccion.Tabla;
            }
            else
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + CtrllSeccion.Error, "..:: error en base de datos ::..".ToUpper()
                    ,MessageBoxButtons.OK,MessageBoxIcon.Error);
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
            usuariosControl1.Seccion = this.Secciones(); // Llenar el combo Secciones en el control
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if(usuariosControl1.ValidarControl())
            {
                // Probando el cifrado de la contraseña
                string cifrado = Seguridad.Encriptar(usuariosControl1.Constraseña);
                MessageBox.Show("el mensaje cifrado es :".ToUpper() + "\n" + cifrado +
                    "\n\n" + "y descifrado es :" + "\n" + Seguridad.Desencriptar(cifrado));

                usuariosControl1.CargaDeDatosControl();
                MessageBox.Show("datos en el control :".ToUpper() + "\n\n" +
                    "nombre :" + usuariosControl1.Nombre + "\n" +
                    "paterno :" + usuariosControl1.Paterno + "\n" +
                    "materno :" + usuariosControl1.Materno + "\n" +
                    "usuario :" + usuariosControl1.Usuario + "\n" +
                    "email :" + usuariosControl1.Email + "\n" +
                    "Estatus :" + usuariosControl1.Estatus + "\n" +
                    "jerarquia :" + usuariosControl1.IdJerarquia.ToString() + "\n" +
                    "subfondo :" + usuariosControl1.IdSubFondo.ToString() + "\n" +
                    "Unidad Administrativa:" + usuariosControl1.IdUnidadAdmva.ToString() + "\n" +
                    "Sección :" + usuariosControl1.IdSeccion.ToString());
            }
        }
    }
}
