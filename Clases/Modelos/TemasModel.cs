using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADI.Clases.Modelos
{
    /// <summary>
    /// Modelo de Temas de las Series
    /// </summary>
    class TemasModel
    {
        private int _id;//identificador del tema
        private SeccionesModel _seccion;// Identificador de la Sección
        private SeriesModel _series;// Identificador de la Serie
        private string _tema;// Descripción del Tema

        /// <summary>
        /// Acceso a la Identificación del Tema
        /// </summary>
        public int Id
        { get { return _id; } set { _id = value; } }
        /// <summary>
        /// Acceso al Identificador de la Sección
        /// </summary>
        public SeccionesModel Seccion
        {
            get { return _seccion; }
            set { _seccion = new SeccionesModel(); _seccion = value; }
        }
        /// <summary>
        /// Acceder al Identificador de la Serie
        /// </summary>
        public SeriesModel Serie
        {
            get { return _series; }
            set { _series = new SeriesModel(); _series = value; }
        }
        /// <summary>
        /// Acceder a la Propiedad Descriptiva del Tema
        /// </summary>
        public string Tema
        { get { return _tema; } set { _tema = value; } }
    }
}
