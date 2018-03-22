using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADI.Clases.Modelos
{
    public class AreasModel : SubFondosModel
    {
        private SubFondosModel _subfondo = new SubFondosModel();//Propiedad del DepartamentoModel
        private string _area;// Descripción del Registro del Modelo

        /// <summary>
        /// Acceso a la Propiedad Departamento Model
        /// </summary>
        public SubFondosModel SUBFondo
        { get { return _subfondo; } set { _subfondo = value; } }
        /// <summary>
        /// Acceso a la Descripción del Registro del Modelo
        /// </summary>
        public string Area
        { get { return _area; } set { _area = value; } }
    }
}
