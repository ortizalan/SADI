using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADI.Clases.Modelos
{
    class SubAreasModel :AreasMedicasModel
    {
        private AreasMedicasModel _areamedica = new AreasMedicasModel();//Propiedad de AreasMedicasModel
        private string _subarea;// descripción de registro del modelo

        /// <summary>
        /// Acceso a la Propiedad AreasMedicasModel
        /// </summary>
        public AreasMedicasModel AreaMedicaId
        { get { return _areamedica; } set { _areamedica = value; } }
        /// <summary>
        /// Acceso a la descripción del registro del Modelo
        /// </summary>
        public string SubArea
        { get { return _subarea; } set { _subarea = value; } }
    }
}
