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

namespace SADI.Vistas.Usuarios
{
    public partial class modificarUsuariocs : Form
    {
        JerarquiasController CtrllJera = new JerarquiasController();
        SubFondosController CtrllSubF = new SubFondosController();
        public modificarUsuariocs()
        {
            InitializeComponent();
        }

        private void modificarUsuariocs_Load(object sender, EventArgs e)
        {
           if(CtrllJera.ConsultarRegistros())
            {
                usuariosControl1.Jerarquia = CtrllJera.Tabla;
                usuariosControl1.Estatus = true;
            }
           else
            {
                MessageBox.Show("ooops");
            }
            if (CtrllSubF.ConsultarRegistros())
            {

            }
            else
            {
                MessageBox.Show("ooops, I did it again!!!");
            }
        }
    }
}
