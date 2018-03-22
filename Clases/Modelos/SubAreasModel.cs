using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADI.Clases.Modelos
{
    public class SubAreasModel :AreasModel
    {
        private AreasModel _area = new AreasModel();//Propiedad de AreasMedicasModel
        private string _subarea;// descripción de registro del modelo

        /// <summary>
        /// Acceso a la Propiedad AreasMedicasModel
        /// </summary>
        public AreasModel AreaId
        { get { return _area; } set { _area = value; } }
        /// <summary>
        /// Acceso a la descripción del registro del Modelo
        /// </summary>
        public string SubArea
        { get { return _subarea; } set { _subarea = value; } }
    }
}
