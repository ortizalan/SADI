using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace SADI.Clases.Modelos
{
    /// <summary>
    /// Clase del Modelo Filas
    /// </summary>
    public class FilasModel
    {
        private int _id; // Propiedad de Identificador
        private string _fila;// Descripción de la Fila
        private Byte[] _imagen;// Imagen de la fila
        private Image _foto;//Propiedad de la Imagen
        private ImageFormat _formato;// Propiedad del Formato de la Foto
        Stream ms;

        /// <summary>
        /// Destructor de la Clase
        /// </summary>
        ~FilasModel()
        { }
        /// <summary>
        /// Acceso a la Propiedad Identificadora del Objeto
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        /// <summary>
        /// Acceso a la Propiedad de la Descripción de la Fila
        /// </summary>
        public string Fila
        {
            get { return _fila; }
            set { _fila = value; }
        }
        /// <summary>
        /// Acceder a la Propiedad Imagen del Objeto
        /// </summary>
        public Byte[] Imagen
        {
            get
            {
                //_imagen = new byte[(int)ms.Length];
                //ms.Position = 0;
                //ms.Read(_imagen, 0, (int)ms.Length);
                return _imagen;
            }
            set
            {
                _imagen = value;
                //ms = new MemoryStream(_imagen.Length);
                //ms.Write(value, 0, _imagen.Length);
            }
        }
        /// <summary>
        /// Acceder a la Foto del Objeto
        /// </summary>
        public Image Foto
        {
            get { return _foto; }
            set { _foto = value; }
        }
        /// <summary>
        /// Acceder a la propiedad Formato
        /// </summary>
        public ImageFormat Formato
        {
            get { return _formato; }
            set { _formato = value; }
        }
    }
}
