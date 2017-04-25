using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADI.Clases.Modelos
{
    class LadosModel:FilasModel
    {
        private string _lado; //Propiedad de la descripción del Lado
        /// <summary>
        /// Destructor de la Clase
        /// </summary>
        ~LadosModel()
        {

        }
        /// <summary>
        /// Acceso a la Propiedad Lado
        /// </summary>
        public string Lado
        {
            get { return _lado; }
            set { _lado = value; }
        }

    }
}
