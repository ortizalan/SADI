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

namespace SADI.Vistas.Digitalizacion
{
    public partial class FrmVisorOffice : Form
    {

        private Object oDocument;
        private WebBrowser webBrowser1;
        OpenFileDialog openFileDialog1 = new OpenFileDialog();
        Object missing = Missing.Value;

        public FrmVisorOffice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String strFileName;

            //Find the Office document.
            openFileDialog1.FileName = "";
            openFileDialog1.ShowDialog();
            strFileName = openFileDialog1.FileName;

        
            //If the user does not cancel, open the document.
            if (strFileName.Length != 0)
            {
               
                this.OpenFile(strFileName);
            }
        }

        private void FrmVisorOffice_Load(object sender, EventArgs e)
        {
            button1.Text = "Browse";
            openFileDialog1.Filter = "Office Documents(*.doc, *.xls, *.ppt)|*.doc;*.xls;*.ppt";
            openFileDialog1.FilterIndex = 1;
        }

        public void webBrowser1_NavigateComplete2(object sender,AxSHDocVw.DWebBrowserEvents2_NavigateComplete2Event e)
        {
            //Object o = e.pDisp;
            //oDocument = o.GetType().InvokeMember("Document", BindingFlags.GetProperty, null, o, null);
            //Object oApplication = o.GetType().InvokeMember("Name",BindingFlags.GetProperty,null,oApplication,null);
        }

        private void OpenFile(string excel)
        {
            if (!System.IO.File.Exists(excel)) throw new Exception();
            this.webBrowser1.Navigate(excel);
        }
    }
}
