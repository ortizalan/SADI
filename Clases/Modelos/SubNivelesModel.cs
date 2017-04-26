using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADI.Clases.Modelos
{
    public class SubNivelesModel : FilasModel
    {
        private string _subnivel;//Propiedad de la descripción del SubNivel
        /// <summary>
        /// Destructor de la Clase
        /// </summary>
        ~SubNivelesModel()
        {

        }
        /// <summary>
        /// Acceso a la Propiedad SubNivel
        /// </summary>
        public string SubNivel
        {
            get { return _subnivel; }
            set { _subnivel = value; }
        }
    }
}
