using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADI.Clases.Modelos
{
    class AtributosModel
    {
        private int _id;//Propiedad de la Identificación de la Accesibilidad
        private UsuariosModel _usuario = new UsuariosModel();//Identificador del Usuario
        private SeriesModel _serie = new SeriesModel();//Identificador de la Serie
        private SeccionesModel _seccion = new SeccionesModel();//Identificador de la Sección
        private TemasModel _tema = new TemasModel();//Identificador del Tema

        /// <summary>
        /// Acceso al Identificador de la Accesibilidad
        /// </summary>
        public int Id
        { get { return _id; }set { _id = value; } }
        /// <summary>
        /// Acceder al indetificador del Usuario
        /// </summary>
        public UsuariosModel Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }
        /// <summary>
        /// Acceder al Identificador de la Serie
        /// </summary>
        public SeriesModel Serie
        {
            get { return _serie; }
            set { _serie = value; }
        }
        /// <summary>
        /// Acceder al Identificador de la Sección
        /// </summary>
        public SeccionesModel Seccion
        {
            get { return _seccion; }
            set { _seccion = value; }
        }
        /// <summary>
        /// Acceder al Identificador del Tema
        /// </summary>
        public TemasModel Temas
        {
            get { return _tema; }
            set { _tema = value; }
        }
    }
}
