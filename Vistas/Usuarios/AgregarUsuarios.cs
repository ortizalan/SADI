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
using SADI.Vistas.Atributos;

namespace SADI.Vistas.Usuarios
{
    public partial class AgregarUsuarios : Form
    {
        UsuariosModel um = new UsuariosModel();// Instancia del Modelo de Usuario
        UsuariosController uc = new UsuariosController(); // Instancia del Controlador Usuario
        JerarquiasController jc = new JerarquiasController(); // Instancia del controlador Jerarquías
        SubFondosController sfc = new SubFondosController(); // Instancia del Cntrolador SubFondos
        SeccionesController sc = new SeccionesController();// Instancia del Controlador Secciones
        AreasController ac = new AreasController();//Instancia del Controlador de Áreas Médicas
        AreasModel am = new AreasModel();//Instancia del Modelo de Áreas Médicas
        SubAreasController sac = new SubAreasController();// Instancia del Controlador SubÁreas
        SubAreasModel sam = new SubAreasModel();//Instancia del Modelo SubAreas
        ServiciosController sec = new ServiciosController();//Instancia del Controlador Servicios
        ServiciosModel sem = new ServiciosModel();//Instancia del Modelo de Servicios

        /// <summary>
        /// Constructor de la Forma
        /// </summary>
        public AgregarUsuarios()
        {
            InitializeComponent();// Inicializar el componente
        }

        private void AgregarUsuarios_Load(object sender, EventArgs e)
        {
            this.LLenarCombos();// LLenar los combos
            usrCtrl.Opcion = 1;
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
            if (jc.ConsultarRegistros())
            {
                return jc.Tabla;
            }
            else
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + jc.Error, "..:: error en base de datos ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        /// <summary>
        /// Función Para llenar el Combo SubFondo
        /// </summary>
        /// <returns>DataTable</returns>
        private DataTable SubFondos()
        {
            if (sfc.ConsultarRegistros())
            {
                return sfc.Tabla;
            }
            else
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + sfc.Error, "..:: error en base de datos ::..".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        private DataTable Departamentos()
        {
            return null;
        }
        /// <summary>
        /// Funcion Para LLenar el COmbo Secciones
        /// </summary>
        /// <returns>DataTable</returns>
        private DataTable Secciones()
        {
            if (sc.ConsultarRegistros())
            {
                return sc.Tabla;
            }
            else
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + sc.Error, "..:: error en base de datos ::..".ToUpper()
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }
        /// <summary>
        /// Método para el Llenado de los COmbos
        /// </summary>
        private void LLenarCombos()
        {
            usrCtrl.Jerarquia = this.Jerarquias();// Llenar el combo Jerarquias en el Control
            usrCtrl.SubFondo = this.SubFondos();// LLenar el combo SubFondo en el Control
        }
        /// <summary>
        /// Método para el LLenado del Objeto Usuario
        /// </summary>
        private void LlenarObjetoUsuario()
        {
            usrCtrl.CargaDeDatosControl();
            um.Nombre = usrCtrl.Nombre;
            um.Paterno = usrCtrl.Paterno;
            um.Materno = usrCtrl.Materno;
            um.Usuario = usrCtrl.Usuario;
            um.Contraseña = usrCtrl.Contraseña;
            um.Email = usrCtrl.Email;
            um.Jerarquia.Id = usrCtrl.IdJerarquia;
            um.SubFondo.Id = usrCtrl.IdSubFondo;
            um.Fondo.Id = 63;
            um.Departamento.Id = usrCtrl.IdDepartamento;
            um.Area.Id = usrCtrl.IdAreaMedica;
            um.SubArea.Id = usrCtrl.IdSubAreaMedica;
            um.Servicio.Id = usrCtrl.IdServicios;
            um.Estatus = true;
        }
        /// <summary>
        /// Agregar el Usuario a la Lista
        /// </summary>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            //Asegurar que los parámetros estén correctos
            if (usrCtrl.ValidarControl())
            {
                //LLenar el Objeto Usuario
                 this.LlenarObjetoUsuario();

                if (uc.IngresarRegisto(um))//Ingresar el Usuario
                {
                    um.Id = ObtenerRegistroUsuarioIngresado();//Obtener su ID
                    if(um.Id == 0) { Close(); }//Si existió Error, Cerrar la Forma
                    AtributosAdd fat = new AtributosAdd(um.Id, this.Text.ToString());//Instancia de la Forma Agregar Atributos
                    fat.ShowDialog();//Mostrar la Forma
                    DialogResult r;
                    r = MessageBox.Show("se ingresó el registro correctamente,".ToUpper() +
                         "\n" + "¿desea ingresar otro usuario?".ToUpper(),
                         "..:: mensaja desde agreagar usuario ::..",
                         MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (r == DialogResult.Yes)
                    {
                        usrCtrl.LimpiarControl();
                    }
                    else
                    {
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("ocurrió el siguiente error :".ToUpper() +
                        "\n" + uc.Error, "..:: mensaje desde agregar usuario ::..".ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Función para Obtener el Último Registro Ingresado
        /// </summary>
        /// <returns></returns>
        private int ObtenerRegistroUsuarioIngresado()
        {
            //Intentar la Consulta del Último Registro Ingresado
            if(uc.ObtenerUltimoUsuarioIngresado())
            {
                //Intento Exitoso
                return (int)uc.Tabla.Rows[0][0];
            }
            else//Intento No Existoso
            {
                MessageBox.Show("ocurrió el sieguiente error :".ToUpper() + "\n" +
                    uc.Error,":: mensaje desde el controlador de usuarios ::".ToUpper(),
                    MessageBoxButtons.OK,MessageBoxIcon.Error);// Error
                return 0;
            }
        }
        /// <summary>
        /// Cambio de Selección en SubFondos
        /// </summary>
        private void usrCtrl_cboSubFondosChange(object sender, EventArgs e)
        {
            am.SUBFondo.Id = usrCtrl.IdSubFondo;//Asignar el identificador del SubFondo

            if (ac.SeleccionarAreaXsubFondo(am))//Intentar Selección de Áreas Específicas
            {
                //Intento Exitoso
                usrCtrl.Areas = ac.Tabla;//Tabla con las Áreas del SubFondo
            }
            else//Intento NO Exitoso
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + ac.Error.ToUpper(),
                    ":: mensaje desde agregar usuario ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Cambio de Selección de Áreas Médicas 
        /// </summary>
        private void usrCtrl_cboAreasMedicasChange(object sender, EventArgs e)
        {
            sam.SUBFondo.Id = usrCtrl.IdSubFondo;
            sam.AreaId.Id = usrCtrl.IdAreaMedica;

            if(sac.SeleccionarSubAreaXSubFondoAreaDepartamentoArea(sam))
            {
                usrCtrl.SubAreas = sac.Tabla;
                usrCtrl_cboSubAreasChange(sender, e);
                usrCtrl_cboServiciosChange(sender, e);
            }
            else
            {
                MessageBox.Show("ocurrió el siguiente error : ".ToUpper() + "\n" + sac.Error.ToUpper(),
                    ":: mensaje desde agregar usuario ::".ToUpper(),
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// Cambio de Selección de SubAreas Médicas
        /// </summary>
        private void usrCtrl_cboSubAreasChange(object sender, EventArgs e)
        {
            sem.SUBFondo.Id = usrCtrl.IdSubFondo;
            sem.AreaId.Id = usrCtrl.IdAreaMedica;
            sem.SubAreaId.Id = usrCtrl.IdSubAreaMedica;

            if(sec.SeleccionarSeccionXSubFondoDeptoAreaSubArea(sem))
            {
                usrCtrl.Servicios = sec.Tabla;
                usrCtrl_cboServiciosChange(sender, e);
            }
            else
            {
                MessageBox.Show("ocurrió el siguiente error : ".ToUpper() + "\n" + sac.Error.ToUpper(),
                    ":: mensaje desde agregar usuario  ::".ToUpper(),
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Cambio de Selección de los Servicios de las SubAreas
        /// </summary>
        private void usrCtrl_cboServiciosChange(object sender, EventArgs e)
        {
            usrCtrl.Servicios = sec.Tabla;
        }

    }
}
