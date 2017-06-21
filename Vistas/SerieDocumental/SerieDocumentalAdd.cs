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
using SADI.Clases.Controladores;
using SADI.Clases.Modelos;

namespace SADI.Vistas.SerieDocumental
{
    public partial class SerieDocumentalAdd : Form
    {
        UsuariosModel um = new UsuariosModel();//Instancia de UsuariosModel
        AtributosModel am = new AtributosModel();//Instancia de AtributosModel
        AtributosController ac = new AtributosController();//Instancia de AtribitosController
        SeccionesController secc = new SeccionesController();//Controlador de las Secciones
        SeriesController serc = new SeriesController();//Controlador de las Series
        SeriesModel serm = new SeriesModel();//Modelo de la Serie
        TemasController tc = new TemasController();//Controlador del Tema
        TemasModel tm = new TemasModel();//Modelo de Temas
        RegistrosModel rm = new RegistrosModel();//Intencia del Modelo Registros
        RegistrosController rc = new RegistrosController();//Instancia del Controlador Registros
        ClasificacionesController cc = new ClasificacionesController();//
        ValoresDoctalesController vdc = new ValoresDoctalesController();//

        /// <summary>
        /// Constructor de la Forma
        /// </summary>
        public SerieDocumentalAdd()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor de la Forma
        /// </summary>
        /// <param name="u">Objeto del tipo UsuariosModel</param>
        public SerieDocumentalAdd(UsuariosModel u)
        {
            InitializeComponent();
            am.Usuario.Id = u.Id;
            LLenarComboSecciones();
        }

        #region LLenado de Combos
        /// <summary>
        /// Método para el Llenado del Combo Secciones
        /// </summary>
        private void LLenarComboSecciones()
        {
            DataTable dt = new DataTable();// Nueva DataTable
            dt = ObtenerSeccionesUsuario();//Asignarle los resultados

            if (dt.Rows.Count > 0)//Verificar que existan registros
            {
                // Si existen registros

                List<Secciones> secciones = new List<Secciones>();//Nueva Lista de Secciones

                foreach(DataRow r in dt.Rows)//BArrer la tabla por los registros
                {
                    secciones.Add(new Secciones((string)r[0]));
                }

                if (secc.ConsultarSeccionesXusuario(secciones))//Intentar la consulta 
                {
                    if (secc.Tabla.Rows.Count > 0)//Intento exitoso
                    {
                        cboSeccion.DataSource = secc.Tabla;//Fuente de la Información del Combo
                        cboSeccion.ValueMember = secc.Tabla.Columns[0].ColumnName;// Valor de la Información
                        cboSeccion.DisplayMember = secc.Tabla.Columns[1].ColumnName;// Información a Mostrar
                    }
                }
                else//Intento NO exitoso
                {
                    MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + secc.Error.ToUpper(),
                        ":: mensaje desde nueva serie documental ::".ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("no existen registros que coincidan.".ToUpper(),
                    ":: mensaje desde nueva serie documental ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
        /// <summary>
        /// Método para el LLenado del Combo Series
        /// </summary>
        private void LLenarComboSeries()
        {
            if (serc.ConsultarSeriesPorSeccion(serm))//Intentar realizar la consulta, por Sección
            {
                //Consulta Exitosa
                if (serc.Tabla.Rows.Count > 0)//Si no está vacía la tabla
                {
                    cboSeries.DataSource = serc.Tabla;//Fuente de datos del combo
                    cboSeries.ValueMember = serc.Tabla.Columns[0].ColumnName;//Valor de la Información
                    cboSeries.DisplayMember = serc.Tabla.Columns[2].ColumnName;//Descripción de la Informanción
                }
            }
            else//Consulta NO Exitosa
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + serc.Error.ToUpper(),
                    ":: mensaje desde nueva serie documental ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Método para el LLenado del Combo Temas
        /// </summary>
        private void LLenarComboTemas()
        {
            if (tc.ConsultarTemaXSerieSeccion(tm))//Intento de la Consulta de los Temas
            {
                //Intento Exitoso
                if (tc.Tabla.Rows.Count > 0)//Ver si tiene valores la tabla
                {
                    cboTema.DataSource = tc.Tabla;
                    cboTema.ValueMember = tc.Tabla.Columns[0].ColumnName;
                    cboTema.DisplayMember = tc.Tabla.Columns[3].ColumnName;
                }

            }
            else//Consulta NO Exitosa
            {
                MessageBox.Show("ocurrió el siguiente error: ".ToUpper() + "\n" + tc.Error.ToUpper(),
                    ":: mensaje desde nueva serie documental ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Método para el LLenado del COmbo Clasificaciones
        /// </summary>
        private void LLenarComboClasificacion()
        {
            if(cc.ConsultarRegistros())//Intentar la consulta
            {
                //Intento Exitoso
                if(cc.Tabla.Rows.Count > 0)//Verificar que tenga registros
                {
                    //Si existen registros
                    cboClasificaciones.DataSource = cc.Tabla;
                    cboClasificaciones.ValueMember = cc.Tabla.Columns[0].ColumnName;
                    cboClasificaciones.DisplayMember = cc.Tabla.Columns[1].ColumnName;

                }
            }
            else//Consulta NO Exitosa
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + cc.Error.ToUpper(),
                    ":: mensaje desde nueva serie documental ::".ToUpper(),
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void LLenarComboValorDoctal()
        {
            //Intentar consultar registro de valores documentales
            if(vdc.ConsultarRegistros())
            {
                if(vdc.Tabla.Rows.Count > 0)//Verificar si existen registros
                {
                    cboValorDoctal.DataSource = vdc.Tabla;//Indicarle la fuente de datos
                    cboValorDoctal.ValueMember = vdc.Tabla.Columns[0].ColumnName;//Valor del Registro
                    cboValorDoctal.DisplayMember = vdc.Tabla.Columns[1].ColumnName;//Descripción del Registro
                }
            }
            else//Intento NO Exitoso
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + vdc.Error.ToUpper(),
                    ":: mensaje desde nueva serie documental ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        #endregion

        #region ComboSelectedIndexChanged

        /// <summary>
        /// Evento de Cambio de Selección en el Combo Sección
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSeccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSeccion.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                serm.Seccion.Id = (string)cboSeccion.SelectedValue;//Agregar la Identificación de la Sección al Objeto
                LLenarComboSeries();//Realizar el LLenado del Combo Series
            }
        }
        /// <summary>
        /// Evento de Cambio de Selección en el Combbo Series
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSeries.SelectedValue.ToString() != "System.Data.DataRowView")//Verificar que exista valor seleccionado
            {
                tm.Seccion.Id = (string)cboSeccion.SelectedValue;//Cargar la Identificación de la Sección
                tm.Serie.Id = (int)cboSeries.SelectedValue;// CArgar la Identificación de la Serie
                LLenarComboTemas();//LLenar el combo Temas
            }
        }
        /// <summary>
        /// Evento de Cambio de Selección en el Combo Temas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTema_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboTema.SelectedValue.ToString() != "System.Data.DataRowView")//Verificar que tenga valor seleccionado
            {
                tm.Id = (int)cboTema.SelectedValue;
            }
        }

        #endregion

        #region Métodos Internos

        private void CargaDeCombos()
        {
            
        }
        /// <summary>
        /// Obtener las Secciones Autorizadas para el Usuario
        /// </summary>
        private DataTable ObtenerSeccionesUsuario()
        {
            //DataTable dtSecc = new DataTable();
            if (ac.ConsultarAtributosSeccionesxUsuario(am))
            {
                if(ac.Tabla.Rows.Count > 0)
                {
                    return ac.Tabla;
                }
                else
                {
                    MessageBox.Show("la consulta no arroja ningún registro.".ToUpper(),
                        ":: mensaje desde nueva seie documental ::".ToUpper(),
                        MessageBoxButtons.OK,MessageBoxIcon.Warning);
                    return null;
                }
            }
            else//Intento NO Existoso, COnsultar Error
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + ac.Error.ToUpper(),
                    ":: mensaje desde nueva serie documental ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

        }

        #endregion
    }
}
