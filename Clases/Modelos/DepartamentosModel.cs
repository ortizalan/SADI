using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADI.Clases.Modelos
{
    class DepartamentosModel
    {
        private int _id; //Identificador del Modelo
        private SubFondosModel _subfondo = new SubFondosModel();//Identificador del SubFondo
        private string _departamento;// Descripción del registro del Modelo

        /// <summary>
        /// Acceso a la Identificación del Registro
        /// </summary>
        public int Id
        { get { return _id; } set { _id = value; } }
        /// <summary>
        /// Acceso al Modelo SubfondoModel
        /// </summary>
        public SubFondosModel SubFondo
        { get { return _subfondo; }set { _subfondo = value; } }
        /// <summary>
        /// 
        /// </summary>
        public string Departamento
        { get { return _departamento; }set { _departamento = value; } }
    }
}
