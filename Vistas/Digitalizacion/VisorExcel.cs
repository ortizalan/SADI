using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SADI.Vistas.Digitalizacion
{
    public partial class VisorExcel : Form
    {
        public VisorExcel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos Excel(*.xls)|*.xls|Archivos Excel(*.xlsx)|*xlsx";
            ofd.Title = "SELECCIONA ARCHIVO EXCEL";
            DialogResult r = ofd.ShowDialog();

            if(r == DialogResult.OK)
            {
                ctrlExcelViewer.LoadDocument(ofd.FileName);
            }

        }
    }
}
