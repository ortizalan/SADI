using System;
using System.Data;
using System.Windows.Forms;
using SADI.Clases.Controladores;
using SADI.Clases.Modelos;
using SADI.Vistas.Usuarios;
using SADI.Vistas.Filas;
using SADI.Vistas.Estantes;
using SADI.Vistas.Niveles;
using SADI.Vistas.Digitalizacion;
using SADI.Vistas.SerieDocumental;
using SADI.Clases;
using SADI.Reportes.Catalogos;
using SADI.Reportes;
using SADI.DataSets.Catalogos;

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
            um = u;
        }
        private void Inicio_Load(object sender, EventArgs e)
        {
            um.Id = Utilerias.IdUsuario;
            //um.Id = 9;
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
                    //um.Id = (int)uc.Tabla.Rows[0][0];
                    um.Usuario = (string)uc.Tabla.Rows[0][1];
                    um.Contraseña = (string)uc.Tabla.Rows[0][2];
                    um.Nombre = (string)uc.Tabla.Rows[0][3];
                    um.Paterno = (string)uc.Tabla.Rows[0][4];
                    um.Materno = (string)uc.Tabla.Rows[0][5];
                    um.Fondo.Id = (int)uc.Tabla.Rows[0][6];
                    um.SubFondo.Id = (int)uc.Tabla.Rows[0][7];
                    um.Departamento.Id = (int)uc.Tabla.Rows[0][8];
                    um.AreaMedica.Id = (int)uc.Tabla.Rows[0][9];
                    um.SubArea.Id = (int)uc.Tabla.Rows[0][10];
                    um.Servicio.Id = (int)uc.Tabla.Rows[0][11];
                    um.Jerarquia.Id = (int)uc.Tabla.Rows[0][12];
                    um.Email = (string)uc.Tabla.Rows[0][13];
                    um.Estatus = (bool)uc.Tabla.Rows[0][14];
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

        private void AgregarFilaMenu_Click(object sender, EventArgs e)
        {
            FilasAdd filafrm = new FilasAdd();
            filafrm.MdiParent = this;
            filafrm.Show();
        }
        //Mostrar la Lista de Filas para ver Detalles
        private void filasMostrarMenu_Click(object sender, EventArgs e)
        {
            FilasList listaF = new FilasList(1);
            listaF.MdiParent = this;
            listaF.Show();
        }
        // Mostrar la Lista de Filas para Seleccionar para Editar
        private void filasEditarMenu_Click(object sender, EventArgs e)
        {
            FilasList listaF = new FilasList(2);
            listaF.MdiParent = this;
            listaF.Show();
        }
        //Agregar un Estante
        private void agregarEstanteMenu_Click(object sender, EventArgs e)
        {
            EstanteAdd estantafrm = new EstanteAdd();
            estantafrm.MdiParent = this;
            estantafrm.Show();
        }
        //Mostrar listado de Estantes
        private void mostrarEstanteMenu_Click(object sender, EventArgs e)
        {
            EstantesList listaEst = new EstantesList(1);
            listaEst.MdiParent = this;
            listaEst.Show();
        }
        //Mostrar listado de los Estantes, para Edición
        private void editarEstanteMenu_Click(object sender, EventArgs e)
        {
            EstantesList listaEst = new EstantesList(2);
            listaEst.MdiParent = this;
            listaEst.Show();
        }
        //Botón Agregar Registro
        private void agregarNivelesMenu_Click(object sender, EventArgs e)
        {
            NivelAdd nivel = new NivelAdd();// Instancias la Forma
            nivel.MdiParent = this;//Asignar la Forma Padre 
            nivel.Show(); //Mostrar la Forma
        }
        //Listado para ver detalles del registro
        private void mostrarNivelesMenu_Click(object sender, EventArgs e)
        {
            NivelList nivel = new NivelList(1);//Instanciar la forma
            nivel.MdiParent = this;// Indicarle la Forma Padre
            nivel.Show();//MOstrar la Forma
        }
        //Listado para Editar el Registro
        private void editarNivelesMenu_Click(object sender, EventArgs e)
        {
            NivelList nivel = new NivelList(2);//Instanciar la Forma
            nivel.MdiParent = this;// Indicarle la Forma Padre
            nivel.Show();//Mostrar la Forma
        }

        private void GenerarNvaSerieMenu_Click(object sender, EventArgs e)
        {
            //Usuario temporal, es para pruebas
           
            SerieDocumentalAdd nsd = new SerieDocumentalAdd(um);
            nsd.MdiParent = this;
            nsd.Show();
        }

        private void MenuSecciones_Click(object sender, EventArgs e)
        {
            ReportesVista RepoView = new ReportesVista();//Instancia de la Forma
            SeccionesReporte repo = new SeccionesReporte();//Instancia del Reporte
            DSCatalogos DS = new DSCatalogos();//Instancia del DataSet
            SeccionesController sc = new SeccionesController();//Instancia del Controlador
            if(sc.ConsultarRegistros())//Intentamos la COnsulta
            {
                //INtento Exitoso
                foreach(DataRow dtr in sc.Tabla.Rows)//Barremos la Tabla
                {
                    DataRow dsr = DS.Secciones.NewRow();//Renglón de la tabla Secciones
                    dsr[0] = dtr[0];//Identificador
                    dsr[1] = dtr[1];//Descripcion
                    DS.Secciones.Rows.Add(dsr);//Agregamos el Renglón a la Tabla
                }

                repo.SetDataSource(DS);//Indicamos la fuente de datos al reporte
                RepoView.crViewer.ReportSource = repo;//Indicamos el reporte al Viewer
                RepoView.MdiParent = this;//Indicamos la forma contenedora
                RepoView.Show();//Mostramos el Reporte
            }
            else//Intento NO Exitoso, Consultar Error
            {

            }

        }

        private void visorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisorWord frmVwWord = new VisorWord();
            frmVwWord.MdiParent = this;
            frmVwWord.Show();
        }

        private void visorExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VisorExcel frmVwExcel = new VisorExcel();
            frmVwExcel.MdiParent = this;
            frmVwExcel.Show();
        }
    }
}
