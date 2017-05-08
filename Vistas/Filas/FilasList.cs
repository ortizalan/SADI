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

namespace SADI.Vistas.Filas
{
    public partial class FilasList : Form
    {
        int opc;
        FilasController fc = new FilasController();
        public FilasList()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor que Recibe Parametro para Seleccionar la Opción a Ejecutar
        /// </summary>
        /// <param name="opc">1) Mostar, 2) Editar</param>
        public FilasList(int opc)
        {
            InitializeComponent();
            this.opc = opc;
        }
        //Al Cargar la Forma
        private void listaFilas_Load(object sender, EventArgs e)
        {
            if (fc.ConsultarRegistros())//
            {
                this.llenarGrid();// Método para llenar el grid
            }
            else
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + fc.Error,
                    ":: mensaje desde listado de filas ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        //Método para llenar la Forma
        private void llenarGrid()
        {
            if (fc.Tabla.Rows.Count > 0)//Verificar que la Tabla contenga registros
            {
                dgvFilas.DataSource = fc.Tabla;//Indicarle la fuente de datos al Grid
                dgvFilas.AllowUserToAddRows = false;// Que no se puedan agregar renglones desde diseño
                dgvFilas.AllowUserToDeleteRows = false;// Que no se puedan borran renglones desde diseño
                dgvFilas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;// Seleccionar todo el renglón
                dgvFilas.ReadOnly = true;// Modo de solo leer
                dgvFilas.RowHeadersVisible = false;//Ocultar las cabeceras de los renglones
                dgvFilas.MultiSelect = false;// Seleccionar Renglón por Renglón
                dgvFilas.Columns[2].Visible = false;//Imagen no visible en el Grid
                dgvFilas.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;// LLenar todo el espacio del Grid
            }
            else
            {
                MessageBox.Show("no existen registros aún.".ToUpper(),":: mensaje desde listado de filas ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
        }
        //Método que se dispara al presionar una tecla
        private void dgvFilas_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)//Si la tecla presionada es Enter
            {
                e.SuppressKeyPress = true;// Evitar el salto de Renglón

                if (dgvFilas.SelectedRows.Count == 1)
                {
                    switch(opc)
                    {
                        case 1:
                            FilasDetails filasd = new FilasDetails((int)dgvFilas.SelectedRows[0].Cells[0].Value);
                            filasd.MdiParent = this.MdiParent;
                            filasd.Show();
                            this.Close();
                            break;
                        case 2:
                            FilasEdit filase = new FilasEdit((int)dgvFilas.SelectedRows[0].Cells[0].Value);
                            filase.MdiParent = this.MdiParent;
                            filase.Show();
                            this.Close();
                            break;
                    }
                    
                }
            }
        }

        private void cmdOUT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
