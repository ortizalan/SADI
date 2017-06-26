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
            LLenarComboClasificacion();
            LLenarComboValorDoctal();
            cboTema.Enabled = false;
        }

        #region LLenado de Combos
        /// <summary>
        /// Método para el Llenado del Combo Secciones
        /// </summary>
        private void LLenarComboSecciones()
        {
            if(secc.ConsultarSeccionesXusuario(am))//Intentar la Consulta
            {
                //Consulta Exitosa
                if(secc.Tabla.Rows.Count > 0)//Verificar que existen registros
                {
                    //Si existen Registros
                    cboSeccion.DataSource = secc.Tabla;//Indicarle la Fuente de la Información
                    cboSeccion.ValueMember = secc.Tabla.Columns[0].ColumnName;//Indice
                    cboSeccion.DisplayMember = secc.Tabla.Columns[1].ColumnName;//Valor
                }
                
            }
            else//Consulta no Exitosa
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + serc.Error.ToUpper(),
                    ":: mensaje desde nueva serie documental ::",
                    MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
           
        }
        /// <summary>
        /// Método para el LLenado del Combo Series
        /// </summary>
        private void LLenarComboSeries()
        {
           if(serc.ConsultarSeriexSeccionUsuario(am))//Intentar la Consulta
            {
                //Intento Exitoso
                if(serc.Tabla.Rows.Count > 0)//Verificar que existan registros
                {
                    cboSeries.DataSource = serc.Tabla;//Indicarle la fuente de la información
                    cboSeries.ValueMember = serc.Tabla.Columns[0].ColumnName;
                    cboSeries.DisplayMember = serc.Tabla.Columns[2].ColumnName;
                }
            }
           else//Intento NO Exitoso
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + serc.Error.ToUpper(),
                    ":: mensaje desde nueva serie documental ::",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Método para el LLenado del Combo Temas
        /// </summary>
        private void LLenarComboTemas()
        {
            if (tc.ConsultarTemaXSerieSeccion(am))//Intento de la Consulta de los Temas
            {
                //Intento Exitoso
                if (tc.Tabla.Rows.Count > 0)//Ver si tiene valores la tabla
                {
                    cboTema.DataSource = tc.Tabla;//Indicarle la Fuente de datos
                    cboTema.ValueMember = tc.Tabla.Columns[0].ColumnName;//Valor del registro
                    cboTema.DisplayMember = tc.Tabla.Columns[3].ColumnName;//Descripción del registro
                    if ((int)tc.Tabla.Rows[0][0] == 0)//Si el valor es 0
                    { cboTema.Enabled = false; }//no Habilitar combo
                    else//No es 0, habilitar combo
                    { cboTema.Enabled = true; }
                }
                else//No tiene registro la tabla
                {
                    cboTema.Enabled = false;//No Habilitar COmbo
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
        /// <summary>
        /// Método para el LLenado del Combo ValorDoctal
        /// </summary>
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

        #region ComboSelectedValuesChanged

        /// <summary>
        /// Evento de Cambio de Selección en el Combo Sección
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSeccion_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboSeccion.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                am.Seccion.Id = (string)cboSeccion.SelectedValue;//Agregar la Identificación de la Sección al Objeto
                LLenarComboSeries();//Realizar el LLenado del Combo Series
            }
        }
        /// <summary>
        /// Evento de Cambio de Selección en el Combbo Series
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSeries_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboSeries.SelectedValue.ToString() != "System.Data.DataRowView")//Verificar que exista valor seleccionado
            {
                am.Seccion.Id = (string)cboSeccion.SelectedValue;//Cargar la Identificación de la Sección
                am.Serie.Id = (int)cboSeries.SelectedValue;// CArgar la Identificación de la Serie
                LLenarComboTemas();//LLenar el combo Temas
            }
        }
        /// <summary>
        /// Evento de Cambio de Selección en el Combo Temas
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboTema_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cboTema.SelectedValue.ToString() != "System.Data.DataRowView")//Verificar que tenga valor seleccionado
            {
                tm.Id = (int)cboTema.SelectedValue;
            }
        }

        #endregion

        #region Métodos Internos

        private void CargaDeCombos()
        {
            
        }

        #endregion

        private void cmdOUT_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
