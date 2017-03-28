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
using SiCGA.Clases.ViewModelos;
namespace SiCGA
{
    public partial class Inicio : Form
    {
        UsuariosController cUser = new UsuariosController();
        UsuariosModel mUser = new UsuariosModel();
        ViewUsuariosModel vUser = new ViewUsuariosModel();
    
        public Inicio()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            mUser.Id = 1;

            vUser.Edad = 33;

            
        }

        private void btnPruebas_Click(object sender, EventArgs e)
        {
            MessageBox.Show(vUser.Edad.ToString());
        }
    }
}
