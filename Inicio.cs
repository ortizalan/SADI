using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SiCGA.Clases.Controladores;
using SiCGA.Clases.Modelos;
using DatosBD;

namespace SiCGA
{
    public partial class Inicio : Form
    {
        UsuariosController cUser = new UsuariosController();
        UsuariosModel mUser = new UsuariosModel();
    
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            mUser.Id = 1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Operaciones op = new Operaciones();
            int r = op.multiplicar(int.Parse(textBox1.Text.ToString()), int.Parse(textBox2.Text.ToString()));
            MessageBox.Show("La Multiplicación es :".ToUpper() + r.ToString() );
            
        }
    }
}
