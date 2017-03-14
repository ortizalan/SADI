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
            mUser.Id = 1;
            Object u = mUser;

            if (cUser.ConsultarRegistro(u))
            {
                MessageBox.Show("el usuario es :".ToUpper() + cUser.Tabla.Rows[0]["Nombre"].ToString());
            }
            else
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + cUser.Error);
            }
           
            
        }
    }
}
