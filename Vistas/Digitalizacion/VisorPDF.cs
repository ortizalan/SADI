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
            pdfViewer1.LoadFile(Utilerias.Path);
        }
    }
}
