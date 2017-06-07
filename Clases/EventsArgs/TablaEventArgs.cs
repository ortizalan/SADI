using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADI.Clases.EventsArgs
{
    class TablaEventArgs : EventArgs
    {
        /// <summary>
        /// Propiedad del Identificador de la Sección
        /// </summary>
        public string Seccion { get; set; }
        /// <summary>
        /// Propiedad del Identificador de la Serie
        /// </summary>
        public int Serie { get; set; }
        /// <summary>
        /// Propiedad del Identificador del Tema
        /// </summary>
        public int Tema { get; set; }
        /// <summary>
        /// Indice del Renglón
        /// </summary>
        public int RowIndex { get; set; }
        /// <summary>
        /// Índice de Columna
        /// </summary>
        public int ColIndex { get; set; }
        /// <summary>
        /// Valor Boleano de la Selección de Sección
        /// </summary>
        public bool SelSeccion { get; set; }
        /// <summary>
        /// Valor Boleano de la Selección de Serie
        /// </summary>
        public bool SelSerie { get; set; }
        /// <summary>
        /// Valor Boleano de la Selección de Tema
        /// </summary>
        public bool SelTema { get; set; }
    }
}
