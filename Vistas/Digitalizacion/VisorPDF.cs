using System;
using System.Windows.Forms;
using SADI.Clases;

namespace SADI.Vistas
{
    public partial class VisorPdf : Form
    {
        public VisorPdf()
        {
            InitializeComponent();
        }

        private void VisorPdf_Load(object sender, EventArgs e)
        {
            //axAcroPDF1.LoadFile(Utilerias.Path);
            axAcroPDF1.src = Utilerias.Path;
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "Archivos PDF(*.pdf)|*.pdf";
            //DialogResult r = ofd.ShowDialog();
            //if(r == DialogResult.OK)
            //{
            //    axAcroPDF1.LoadFile(ofd.FileName);
            //}
            axAcroPDF1.setShowToolbar(true);
        }

       
    }
}
