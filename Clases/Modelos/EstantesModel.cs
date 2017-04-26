using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADI.Clases.Modelos
{
    public class EstantesModel : FilasModel
    {
        private string _estante;// Descripcion del Estante
        /// <summary>
        /// Destrictor del Objeto
        /// </summary>
        ~EstantesModel()
        {

        }
        /// <summary>
        /// Acceder ala Propiedad Estante
        /// </summary>
        public string Estante
        {
            get { return _estante; }
            set { _estante = value; }
        }
    }
}
