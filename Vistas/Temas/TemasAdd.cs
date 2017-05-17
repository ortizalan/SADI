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

namespace SADI.Vistas.Temas
{
    public partial class TemasAdd : Form
    {
        TemasModel tm = new TemasModel();// Modelo de Temas
        TemasController tc = new TemasController();// Controlador de Temas
        SeccionesModel secm = new SeccionesModel();// Modelo de Secciones
        SeccionesController secc = new SeccionesController();//Controlador Secciones
        SeriesModel serm = new SeriesModel();//Modelo de Secciones
        SeriesController serc = new SeriesController();//Controlador de Secciones

        //Constructor de la Clase
        public TemasAdd()
        {
            InitializeComponent();

            LLenarComboSecciones();
        }
        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        /// <param name="sec">ID de la Sección</param>
        /// <param name="ser">ID de la Serie</param>
        public TemasAdd(string sec, int ser)
        {
            InitializeComponent();

            secm.Id = sec;
            serm.Id = ser;

            LLenarComboSecciones();
            cboSecciones.SelectedValue = sec;
            LLenarComboSeries(secm);

        }
        /// <summary>
        /// Método para LLenar el Combo Secciones
        /// </summary>
        private void LLenarComboSecciones()
        {
            if (secc.ConsultarRegistros())//Intentar la Consulta de las Secciones
            {
                //Consulta Exitosa
                if (secc.Tabla.Rows.Count > 0)//Si consulta cuenta con regisotrs
                {
                    //Si cuenta con registros
                    cboSecciones.DataSource = secc.Tabla;
                    cboSecciones.ValueMember = secc.Tabla.Columns[0].ColumnName;
                    cboSecciones.DisplayMember = secc.Tabla.Columns[1].ColumnName;
                }
                else//NO cuenta con registros
                {
                    MessageBox.Show("no existen registros para la selección.".ToUpper(),
                        ":: mensaje desde agregar tema ::".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else//Consulta NO Exitosa
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + secc.Error,
                    ":: mensaje desde agregar tema ::".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
        /// <summary>
        /// Método para LLenar el Combo Series
        /// </summary>
        /// <param name="o">Objeto del tipo Secciones</param>
        private void LLenarComboSeries(object o)
        {

            // Si son del mismo tipo
            if (serc.ConsultarSeriesPorSeccion(o))//Intentar la consultaq
            {
                //Consulta Exitosa
                if (serc.Tabla.Rows.Count > 0)//Verificar que la consulta cuente con Registros
                {
                    //Si cuenta con registro
                    cboSeries.DataSource = serc.Tabla;
                    cboSeries.ValueMember = serc.Tabla.Columns[0].ColumnName;
                    cboSeries.DisplayMember = serc.Tabla.Columns[2].ColumnName;
                }
                else//NO cuenta con registros
                {
                    MessageBox.Show("no existen registros para la búsqueda solicitada.".ToUpper(), ":: mensaje desde agregar temas ::".ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else//Consulta NO Exitosa
            {
                MessageBox.Show("Ocurrió el siguiente error :".ToUpper() + "\n" + secc.Error, ":: mensaje desde agregar temas ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }

        }
        //Cuando Cambie la Selección del Combo
        private void cboSecciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboSecciones.SelectedValue.ToString() != "System.Data.DataRowView")//Verificar Exista algún Valor Seleccionado
            {
                serm.Seccion.Id = cboSecciones.SelectedValue.ToString();//Asignar el indicador al modelo Secciones
                LLenarComboSeries(serm);//Enviar el Valor al Método 
            }
        }

        private void cmdOUT_Click(object sender, EventArgs e)
        {
            Close();
        }
        /// <summary>
        /// Método para Ingresar un Nuevo Tema
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdIN_Click(object sender, EventArgs e)
        {
            if(ValidarControles())//Validar los Controles de la Forma
            {
                LLenarObjetoTema();
                IngresarTema();
            }
        }

        /// <summary>
        /// Función Para Validar Controles de la Forma
        /// Qué no Estén Vacíos
        /// </summary>
        /// <returns>Boleano</returns>
        private bool ValidarControles()
        {
            if (cboSecciones.SelectedValue.ToString() != "System.Data.DataRowView")// Que esté seleccionado un valor en el combo Secciones
            {
                if (cboSeries.SelectedValue.ToString() != "System.Data.DataRowView")//Verificar que esté seleccionado algin valor en las  series
                {
                    if (!string.IsNullOrEmpty(txtTema.Text))//Verificar que no esté vacío el campo del Tema
                    {
                        return true;
                    }
                    else//Si está vacío
                    {
                        MessageBox.Show("eliga un valor en las series.".ToUpper(), ":: mensaje desde agregar temas ::".ToUpper(),
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtTema.Focus();
                        return false;
                    }
                }
                else//No Hay Seleccionado ningun valor
                {
                    MessageBox.Show("eliga un valor en las series.".ToUpper(), ":: mensaje desde agregar temas ::".ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cboSeries.Focus();
                    return false;
                }
            }
            else//NO hay valor seleccionado
            {
                MessageBox.Show("eliga un valor en las secciones.".ToUpper(), ":: mensaje desde agregar temas ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboSecciones.Focus();
                return false;
            }
        }
        /// <summary>
        /// LLenado del Objeto TemasModel
        /// </summary>
        private void LLenarObjetoTema()
        {
            tm.Seccion.Id = cboSecciones.SelectedValue.ToString();
            tm.Serie.Id = (int)cboSeries.SelectedValue;
            tm.Tema = txtTema.Text;
        }
        /// <summary>
        /// Ingresar el Registro a la base de datos
        /// </summary>
        private void IngresarTema()
        {
            if(tc.IngresarRegisto(tm))//Intentar el Ingreso del Registro
            {
                //Se ingresó Correctamente..
                DialogResult r;
                r = MessageBox.Show("se ingresó el registro exitosamente,".ToUpper() + "\n" + "¿desea agregar otro registro?".ToUpper(),
                    ":: mensaje desde agregar tema ::".ToUpper(),MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if(r == DialogResult.Yes)//Si la respuesta es si
                {
                    LimpiarControles();
                }
                else//Si la respuesta es NO
                {
                    Close();
                }
            }
            else//Ingreso NO Exitoso
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + tc.Error, ":: mensaje desde agregar tema ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
        /// <summary>
        /// Limpiar los Controles, verificando si traen valor los modelos
        /// </summary>
        private void LimpiarControles()
        {
            if (!string.IsNullOrEmpty(tm.Seccion.Id) && tm.Serie.Id > 0)
            {
                cboSecciones.SelectedValue = tm.Seccion.Id;
                cboSeries.SelectedValue = tm.Serie.Id;
                txtTema.Text = string.Empty;
            }
            else//Están vacios los campos 
            {
                LLenarComboSecciones();
                cboSeries.DataSource = null;
                txtTema.Text = string.Empty;
            }
        }
    }
}
