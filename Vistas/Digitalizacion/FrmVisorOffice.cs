using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.PowerPoint;

namespace SADI.Vistas.Digitalizacion
{
    public partial class FrmVisorOffice : Form
    {
        public FrmVisorOffice()
        {
            InitializeComponent();
        }

        public FrmVisorOffice(string document)
        {
            InitializeComponent();
            visorOfficexaml1.Path = document;
            
        }

        #region Construtores
        //public FrmVisorOffice(Workbook xdoc)
        //{
        //}

        //public FrmVisorOffice(Document ddoc)
        //{
        //}

        //public FrmVisorOffice(Presentation pdoc)
        //{
        //}

        //public FrmVisorOffice(string path, int opc)
        //{
        //    InitializeComponent();
        //    visorOfficexaml1.Path = path;
        //}
        #endregion

    }
}
