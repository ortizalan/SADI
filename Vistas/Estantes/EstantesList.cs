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

namespace SADI.Vistas.Estantes
{
    public partial class EstantesList : Form
    {
        int opc;
        EstantesModel em = new EstantesModel();
        EstantesController ec = new EstantesController();
        /// <summary>
        /// Constructor sin Parámetros
        /// </summary>
        public EstantesList()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Contructor que recibe Parámetro
        /// </summary>
        /// <param name="opc">Opción a Ejecutar 1)Seleccionar 2)Editar</param>
        public EstantesList(int opc)
        {
            InitializeComponent();
            this.opc = opc;
        }
        //Botón Salir
        private void cmdOUT_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EstantesList_Load(object sender, EventArgs e)
        {
            if(ec.ConsultarRegistros())//Intentar Consultar los Registros
            {
                //Consulta Exisota
                LlenarGridEstantes();
            }
            else// Consulta NO Exitosa, ver Error
            {
                MessageBox.Show("ocurrio el siguiente error :".ToUpper() + "\n" + ec.Error,
                    ":: mensaje desde lista de estantes ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Close();
            }
        }
        /// <summary>
        /// Método para llenar el Grid con información de los Estantes
        /// </summary>
        private void LlenarGridEstantes()
        {
            if(ec.Tabla.Rows.Count > 0)//Verificar que existan registroa
            {
                // Si existen registros
                dgvEstantes.DataSource = ec.Tabla;// Indicarle la fuente de datos
                dgvEstantes.AllowUserToAddRows = false;//No agregar renglones desde diseño
                dgvEstantes.AllowUserToDeleteRows = false;//No borrar renglones desde diseño
                dgvEstantes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//Seleccionar todo el renglón
                dgvEstantes.ReadOnly = true;// Modo de solo lectura
                dgvEstantes.RowHeadersVisible = false;//Ocutar los headers de los renglones
                dgvEstantes.Columns[2].Visible = false;//Ocultar la imagen del grid
                dgvEstantes.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;//LLenar 
            }
            else// NO existen registros
            {
                MessageBox.Show("no existen registros aún.".ToUpper(), ":: mensaje desde listado de estantes ::".ToUpper(),
                   MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
        //Método que se dispara al presionar una tecla
        private void dgvEstantes_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)//Si la tecla presionada es Enter
            {
                e.SuppressKeyPress = true;//Evitar que se dé el salto de renglón

                if(dgvEstantes.SelectedRows.Count == 1)//Asegurarnos que sea un renglón solamente el seleccionado
                {
                    switch(opc)// Evaluar la opción
                    {
                        case 1:// Si es valor 1
                            EstantesDetails estanteVw = new EstantesDetails((int)dgvEstantes.SelectedRows[0].Cells[0].Value);
                            estanteVw.MdiParent = this.MdiParent;
                            estanteVw.Show();
                            Close();
                            break;

                        case 2://Si es valor 2
                            EstanteEdit estanteUp = new EstanteEdit((int)dgvEstantes.SelectedRows[0].Cells[0].Value);
                            estanteUp.MdiParent = this.MdiParent;
                            estanteUp.Show();
                            Close();
                            break;
                    }
                }
            }
        }
    }
}
