using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.Windows.Forms;
using System.IO;

namespace SADI.UserControls
{
    public partial class WordViewerControl : UserControl
    {
        private WebBrowser webBrowser1;

        delegate void ConvertDocumentDelegate(string FileName);

        public WordViewerControl()
        {
            InitializeComponent();

            webBrowser1 = new WebBrowser();
            webBrowser1.Dock = DockStyle.Fill;
            webBrowser1.Location = new System.Drawing.Point(0, 0);
            webBrowser1.MinimumSize = new System.Drawing.Size(20,20);
            webBrowser1.Size = new Size(532, 514);
            webBrowser1.TabIndex = 0;

            Controls.Add(webBrowser1);

            webBrowser1.DocumentCompleted += webBrowser1_DocumentCompleted;
        }

        string tempFileName = null;

        public void LoadDocument(string FileName)
        {
            ConvertDocumentDelegate del = new ConvertDocumentDelegate(ConvertDocument);

            del.BeginInvoke(FileName, DocumentConversionComplete, null);
        }

        private void ConvertDocument(string FileName)
        {
            object m = System.Reflection.Missing.Value;
            object oldFileName = (object)FileName;
            object readOnly = (object)false;

            ApplicationClass ac = null;
            
            try
            {
                ac = new ApplicationClass();

                Document doc = ac.Documents.Open(ref oldFileName, ref m, ref readOnly, ref m, ref m,
                    ref m, ref m, ref m, ref m, ref m, ref m, ref m, ref m, ref m, ref m, ref m);

                tempFileName = GetTempFile("html");

                object newFileName = (object)tempFileName;

                object fileType = (object)WdSaveFormat.wdFormatHTML;

                doc.SaveAs2(ref newFileName, ref fileType, ref m, ref m, ref m, ref m, ref m,
                    ref m, ref m, ref m, ref m, ref m, ref m, ref m, ref m, ref m, ref m);
            }
            catch(ArgumentException e)
            {
                MessageBox.Show(e.Message.ToString().ToUpper(), ":: argumentexcetion ::".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message.ToString().ToUpper(), ":: exception ::".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if(ac != null)
                { ac.Quit(ref readOnly, ref m, ref m); }
            }
        }

        private void DocumentConversionComplete(IAsyncResult result)
        {
            // navigate to our temp file. 
            webBrowser1.Navigate(tempFileName);
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            if (tempFileName != string.Empty)
            {
                // delete the temp file we created. 
                if (!string.IsNullOrEmpty(tempFileName))
                { File.Delete(tempFileName); }

                // set the tempFileName to an empty string. 
                tempFileName = string.Empty;
            }
        }

        string GetTempFile(string extension)
        {
            // Uses the Combine, GetTempPath, ChangeExtension, 
            // and GetRandomFile methods of Path to 
            // create a temp file of the extension we're looking for. 
            return Path.Combine(Path.GetTempPath(),
                Path.ChangeExtension(Path.GetRandomFileName(), extension));
        }
    }
}
