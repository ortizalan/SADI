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
    public partial class VisorWord : Form
    {
        public VisorWord()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivos Word(*.doc)|*.doc|Archivos Word(*.docx)|*.docx";
            ofd.Title = "SELECCIONA ARCHIVO WORD";
            DialogResult r = ofd.ShowDialog();

            if(r == DialogResult.OK)
            {
                ctrlVisorWord.LoadDocument(ofd.FileName);
            }
        }
    }
}
