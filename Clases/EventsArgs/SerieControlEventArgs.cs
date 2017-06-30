using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADI.Clases.EventsArgs
{
    public class SerieControlEventArgs : EventArgs
    {
        /// <summary>
        /// Opción Seleccionada en el Control
        /// </summary>
        public int Opcion { get; set; }
    }
}
