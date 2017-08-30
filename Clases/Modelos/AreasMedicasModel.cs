using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADI.Clases.Modelos
{
    public class AreasMedicasModel : DepartamentosModel
    {
        private DepartamentosModel _departamento = new DepartamentosModel();//Propiedad del DepartamentoModel
        private string _areamedica;// Descripción del Registro del Modelo

        /// <summary>
        /// Acceso a la Propiedad Departamento Model
        /// </summary>
        public DepartamentosModel DepartamentoId
        { get { return _departamento; } set { _departamento = value; } }
        /// <summary>
        /// Acceso a la Descripción del Registro del Modelo
        /// </summary>
        public string AreaMedica
        { get { return _areamedica; } set { _areamedica = value; } }
    }
}
