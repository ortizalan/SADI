using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SADI.Vistas.Atributos
{
    public partial class Presumir : Form
    {
        DataTable tab = new DataTable();
        public Presumir()
        {
            InitializeComponent();
        }

        public Presumir(DataTable dt)
        {
            InitializeComponent();
            tab = dt;
            LLenarGrid();
        }

        private void LLenarGrid()
        {
            if(tab.Rows.Count > 0)
            {
                dgvDatos.DataSource = tab;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Presumir_Load(object sender, EventArgs e)
        {

        }
    }
}
