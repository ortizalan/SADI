using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace SADI.UserControls
{
    public partial class ExcelViewerControl : UserControl
    {

        private WebBrowser webBrowser1;

        delegate void ConvertDocumentDelegate(string FileName);

        public ExcelViewerControl()
        {
            InitializeComponent();

            webBrowser1 = new WebBrowser();
            webBrowser1.Dock = DockStyle.Fill;
            webBrowser1.Location = new System.Drawing.Point(0, 0);
            webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            webBrowser1.Size = new Size(532, 514);
            webBrowser1.TabIndex = 0;

            Controls.Add(webBrowser1);

            //webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
        }

        //public LoadDocument(string FileName)
        //{

        //}

    }
}
