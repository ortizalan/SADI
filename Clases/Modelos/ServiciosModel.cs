using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADI.Clases.Modelos
{
    public class ServiciosModel : SubAreasModel
    {
        private SubAreasModel _subarea = new SubAreasModel();//Propiedad de SubAreasModel
        private string _servicio;//Descripción del registro del modelo

        /// <summary>
        /// Acceso a las Propiedades de SubAreasModel
        /// </summary>
        public SubAreasModel SubAreaId
        { get { return _subarea; }set { _subarea = value; } }
        /// <summary>
        /// Acceso a la Descripción del  Registro del Modelo
        /// </summary>
        public string Servicio
        { get { return _servicio; } set { _servicio = value; } }
    }
}
