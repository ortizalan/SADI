using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADI.Clases
{
    public class Series
    {
        private int _serie;//Propiedad Serie

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public Series(int s)
        {
            Serie = s;
        }

        /// <summary>
        /// Acceso a la Propiedad Serie
        /// </summary>
        public int Serie
        {
            get { return _serie; }
            set { _serie = value; }
        }
    }
}
