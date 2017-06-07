using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADI.Clases
{
    class TemasSeriesEventArgs : EventArgs
    {
        /// <summary>
        /// Identificador de la Sección
        /// </summary>
        public string IdSeccion { get; set; }
        /// <summary>
        /// Identificador de la Serie
        /// </summary>
        public int IdSerie { get; set; }
        /// <summary>
        /// Identificador del Tema
        /// </summary>
        public int IdTema { get; set; }
        /// <summary>
        /// Opción para validar que es lo que se vá a borrar
        /// 1) Sección
        /// 2) Serie
        /// 3) Tema
        /// </summary>
        public int Opcion { get; set; }
    }
}
