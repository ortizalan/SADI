using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SADI.Clases.Controladores;
using SADI.Clases.Modelos;


namespace SADI.Vistas.Filas
{
    public partial class FilasAdd : Form
    {
        FilasModel fm = new FilasModel();
        FilasController fc = new FilasController();

        public FilasAdd()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Cargar Los Datos en el Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilasAdd_Load(object sender, EventArgs e)
        {
            catGeoCtrl.Opcion = 1;// Enviarle la opción al Control (1 = Filas)
            
            if(fc.ObtenerUltimoId())// Obtener el identificador del último registro de Filas
            {
                if(fc.Tabla.Rows.Count > 0)// Si trea registro la Consulta
                {
                    catGeoCtrl.Id = int.Parse(fc.Tabla.Rows[0][0].ToString()) + 1;
                }
                else// Si no trae registro la consulta
                {
                    catGeoCtrl.Id = 1;//Primer Registro
                }
            }
            else// Ocurrió un Error
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + fc.Error,
                    ":: mensaje desde la forma filasadd ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();//Cerrar la Forma
            }

            catGeoCtrl.ReLoad();// recargar el control
        }
        //Gaurdar los Datos
        private void cmdAdd_Click(object sender, EventArgs e)
        {
            if(catGeoCtrl.ValidarControl())
            {
                this.DeControAlObjeto();
                if(fc.IngresarRegisto(fm))//Intentar Ingresar el Objeto al Modelo
                {
                    //Ingreso Exitoso
                    DialogResult r;
                    // Preguntar si se quiere ingresar otro registro
                    r = MessageBox.Show("se ingresó el registro correctamente," + "\n"
                        + "¿desea ingresar otro registro?".ToUpper(),":: mensaje desde la forma filasadd ::",
                        MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                    if(r == DialogResult.Yes)//Si se desea ingresar otro Registro
                    {
                        catGeoCtrl.LimpiarControl();// Limpiar el Control
                        catGeoCtrl.ReLoad();// recargar el control
                        object ob = string.Empty;// Objeto vacío
                        EventArgs ev = null;//Manejador de Evento vacío
                        this.FilasAdd_Load(ob, ev);//Recargar la Forma
                    }
                    else// No se desea ingresar otro registro
                    {
                        this.Close();// Cerrar la forma
                    }
                }
                else//Ingreso NO Existoso
                {
                    MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + fc.Error,
                        ":: mensaje desde la forma filasadd ::".ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        //Cerrar la forma
        private void cmdOUT_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Pasar los Datos del Control al Objeto
        /// </summary>
        private void DeControAlObjeto()
        {
            fm.Id = catGeoCtrl.Id;
            fm.Fila = catGeoCtrl.Descripcion;
            fm.Foto = catGeoCtrl.Imagen;
            fm.Formato = catGeoCtrl.Formato;
        }
    }
}
