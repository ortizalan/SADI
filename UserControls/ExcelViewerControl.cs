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

        string tempFileName = null;

        public void LoadDocument(string FileName)
        {
            ConvertDocumentDelegate del = new ConvertDocumentDelegate(ConvertDocument);

            del.BeginInvoke(FileName, DocumentConversionComplete, null);
        }

        private void DocumentConversionComplete(IAsyncResult ar)
        {
            //throw new NotImplementedException();

            webBrowser1.Navigate(tempFileName);
        }

        private void ConvertDocument(string FileName)
        {
            object m = System.Reflection.Missing.Value;
            object oldFileName = (object)FileName;
            object readOnly = (object)false;
            XlSaveAsAccessMode acces = XlSaveAsAccessMode.xlNoChange;

            Microsoft.Office.Interop.Excel.Application app = null;

            try
            {
                app = new Microsoft.Office.Interop.Excel.Application();

                //Microsoft.Office.Interop.Excel.Page

                _Workbook xls =(_Workbook)(app.Workbooks.Open(FileName, 0, false, 5, m, m, true, XlPlatform.xlWindows, "\t", true, false, 0, m, m, m));
                //, false, true, 5, "", "", true, XlPlatform.xlWindows, "\t", 
                                                                                                                                                                               //false, false, 0, false, 1, 0);

                _Worksheet ws = (Worksheet)xls.ActiveSheet; 


                object newFileName = (object)tempFileName;

                object fileType = (object)XlFileFormat.xlHtml;

                xls.SaveAs(newFileName, fileType, m, m, readOnly, m, acces, m, m, m, m, m);
            }
            catch (ArgumentException e)
            {
                MessageBox.Show(e.Message.ToString().ToUpper(), ":: argumentexcetion ::".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString().ToUpper(), ":: exception ::".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (app != null)
                { app.Quit(); }
            }
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //throw new NotImplementedException();
            if (tempFileName != string.Empty)
            {
                // delete the temp file we created. 
                if (!string.IsNullOrEmpty(tempFileName))
                { File.Delete(tempFileName); }

                // set the tempFileName to an empty string. 
                tempFileName = string.Empty;
            }
        }
    }
}
