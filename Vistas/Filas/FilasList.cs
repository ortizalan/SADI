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

        private void listaFilas_Load(object sender, EventArgs e)
        {
            if (fc.ConsultarRegistros())
            {
                this.llenarGrid();
            }
            else
            {
                MessageBox.Show("hay pedo");

            }
        }

        private void llenarGrid()
        {
            if (fc.Tabla.Rows.Count > 0)
            {
                dgvFilas.DataSource = fc.Tabla;
                dgvFilas.AllowUserToAddRows = false;
                dgvFilas.AllowUserToDeleteRows = false;
                dgvFilas.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                dgvFilas.ReadOnly = true;
                dgvFilas.RowHeadersVisible = false;
                dgvFilas.MultiSelect = false;
                dgvFilas.Columns[2].Visible = false;
                dgvFilas.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            else
            {
                MessageBox.Show("no hay registro");
            }
        }


        private void dgvFilas_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

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
