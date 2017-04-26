using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SADI.Clases.Modelos;

namespace SADI.UserControls
{
    public partial class CatalogosGeoLocalizaControl : UserControl
    {
        OpenFileDialog of = new OpenFileDialog();// Para cargar le imagen
        Stream ms; // MemoryStreamer
        ToolTip toolTip = new ToolTip();

        #region Propiedades
        private SubNivelesModel _subnivel;// Propiedad identificadora del SubNivel
        private LadosModel _lado;// Propiedad de identificación del lado
        private int _opc;// Opción para saber de que manera se ejecutará el control (Diseño)
        private int _id;// Propiedad del Identificador del Registro
        private string _descripcion;// Descripción del Registro
        private byte[] _imagen;//Imagen del registro
        private DataTable _tlados = new DataTable();
        private DataTable _tsubniveles = new DataTable();
        #endregion

        public CatalogosGeoLocalizaControl()
        {
            InitializeComponent();
        }
        #region Getters Setters

        /// <summary>
        /// Acceso ala Propiedad Laso
        /// </summary>
        public LadosModel Lado
        {
            get { return _lado; }
            set { _lado = value; }
        }
        /// <summary>
        /// Acceso a la Propiedad Identificadora del SubNivel
        /// </summary>
        public SubNivelesModel SubNivel
        {
            get { return _subnivel; }
            set { _subnivel = value; }
        }
        /// <summary>
        /// Acceso a la Propiedad Opción
        /// 1) Filas, 2) Estantes, 3) Niveles
        /// 4) Lados, 5) SubNivel, 6) Posición
        /// </summary>
        public int Opcion
        {
            get { return _opc; }
            set { _opc = value; }
        }
        /// <summary>
        /// Acceso a la Propiedad ID
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// Acceso ala Propiedad Descripción
        /// </summary>
        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        /// <summary>
        /// Acceso a la Propiedad Imagen
        /// </summary>
        public byte[] Imagen
        {
            get { return _imagen; }
            set { _imagen = value; }
        }
        /// <summary>
        /// Acceso a la Porpiedad Tabla Lados
        /// </summary>
        public DataTable TLados
        {
            set
            {
                _tlados = value;
                if (_tlados.Rows.Count > 0)
                {
                    cboLados.DataSource = _tlados;
                    cboLados.ValueMember = _tlados.Columns[0].ColumnName;
                    cboLados.DisplayMember = _tlados.Columns[1].ColumnName;
                }
            }
        }
        /// <summary>
        /// Acceso a la Propiedad Tabla Subniveles
        /// </summary>
        public DataTable TSubNiveles
        {
            set
            {
                _tsubniveles = value;
                if (_tsubniveles.Rows.Count > 0)
                {
                    cboSubNiveles.DataSource = _tsubniveles;
                    cboSubNiveles.ValueMember = _tsubniveles.Columns[0].ColumnName;
                    cboSubNiveles.DisplayMember = _tsubniveles.Columns[1].ColumnName;
                }
            }
        }
        #endregion
        /// <summary>
        /// Cuando Carga el Control
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CatalogosGeoLocalizaControl_Load(object sender, EventArgs e)
        {
            toolTip.AutoPopDelay = 3000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;

            toolTip.SetToolTip(this.ImagenPb, "Doble Click Para Cargar Imagen");

            switch (_opc)
            {
                case 1://Filas
                    lblDescripcion.Text = "Fila :";
                    break;
                case 2:// Estantes
                    lblDescripcion.Text = "Estante :";
                    break;
                case 3:
                    lblDescripcion.Text = "Nivel :";
                    break;
                case 4:
                    lblDescripcion.Text = "Lado :";
                    break;
                case 5:
                    lblDescripcion.Text = "SubNivel :";
                    break;
                case 6:
                    lblDescripcion.Text = "Posición ;";
                    gpoBoxSel.Enabled = true;
                    gpoBoxSel.Visible = true;
                    break;
            }
        }
        /// <summary>
        /// Cargar Imagen Nueva
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImagenPb_DoubleClick(object sender, EventArgs e)
        {
            of.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            of.Title = "eliga imagen a guardar".ToUpper();
            if (of.ShowDialog() == DialogResult.OK)
            {
                this.ImagenPb.Image = new Bitmap(of.FileName);
            }
            if (ImagenPb.Image != null)
            {
                Imagen = this.Imagen2Byte(ImagenPb.Image);
            }
        }
        /// <summary>
        /// Convertir Imagen a Arreglos de bytes
        /// </summary>
        /// <param name="img">Imagen</param>
        /// <returns>byte[]</returns>
        private byte[] Imagen2Byte(Image img)
        {
            ImageConverter conv = new ImageConverter();
            return (byte[])conv.ConvertTo(img, typeof(byte[]));
        }
        /// <summary>
        /// Método al cambiar los valores del combo Lados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboLados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLados.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                Lado.Id = (int)cboLados.SelectedValue;
            }
        }
        /// <summary>
        /// Método para el cambio de valores del combo SubNiveles
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboSubNiveles_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cboSubNiveles.SelectedValue.ToString() != "System.Data.DataRowView")
            {
                SubNivel.Id = (int)cboSubNiveles.SelectedValue;
            }
        }
    }
}
