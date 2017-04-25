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

namespace SADI.Vistas.Usuarios
{
    public partial class listaUsuarios : Form
    {
        UsuariosController uc = new UsuariosController();
       
        public listaUsuarios()
        {
            InitializeComponent();
        }

        private void listaUsuarios_Load(object sender, EventArgs e)
        {
            if(uc.ConsultarRegistros())
            {
                //foreach( DataRow r in uc.Tabla.Rows)
                //{
                //    r["Contraseña"] = Seguridad.Desencriptar(r["Contraseña"].ToString());
                //}

                this.llenarGrid();
            }
            else
            {
                MessageBox.Show("Error :" + "\n" + uc.Error);
            }

            //this.llenarGrid();
        }

        private void llenarGrid()
        {
            dataGridView1.DataSource = uc.Tabla;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.MultiSelect = false;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblPwd.Text = Seguridad.Desencriptar(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if(dataGridView1.SelectedRows.Count > 0)
            {
                lblPwd.Text = Seguridad.Desencriptar(dataGridView1.SelectedRows[0].Cells[2].Value.ToString());
            }
        }
    }
}
