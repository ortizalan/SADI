using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADI.Clases.Modelos
{
    public class NivelesModel:FilasModel
    {
        private string _nivel;// Propiedad de la descripción del nivel
        /// <summary>
        /// Destructor del Objeto
        /// </summary>
        ~NivelesModel() { }
        /// <summary>
        /// Acceso a la Descripción del Objeto
        /// </summary>
        public string Nivel
        {
            get { return _nivel; }
            set { _nivel = value; }
        }
    }
}
