using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SADI.Clases;

namespace SADI.Vistas.Digitalizacion
{
    public partial class VisorOffice : Form
    {
        public VisorOffice()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VisorOffice_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            { visorOfficexaml1.xpsDoc.Close(); }
            catch(Exception ex)
            {
                MessageBox.Show("ocurrio el siguiente error :".ToUpper() + "\n" + ex.Message.ToString(),
                        ":: mensaje desde el visor de docus office ::".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            if(File.Exists(Utilerias.Path))//Verificar si existe el Archivo
            {
                try
                { File.Delete(Utilerias.Path); }//Borrar el Archivo
                catch(Exception ex)
                {
                    MessageBox.Show("ocurrio el siguiente error :".ToUpper() + "\n" + ex.Message.ToString(),
                        ":: mensaje desde el visor de docus office ::".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                string xps = Utilerias.Path + ".xps";//agregar la extensión xps

                if(File.Exists(xps))//Verificar si existe el archivo
                {
                    try
                    { File.Delete(xps); }//Borrar el Archivo
                    catch(Exception ex)
                    {
                        MessageBox.Show("ocurrio el siguiente error :".ToUpper() + "\n" + ex.Message.ToString(),
                          ":: mensaje desde el visor de docus office ::".ToUpper(), MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
