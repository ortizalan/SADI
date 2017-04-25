using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADI.Clases.Modelos
{
    class PosicionesModel : FilasModel
    {
        private string _posicion;// Propiedad de la descripcion de la posición
        private LadosModel _lado = new LadosModel();// Propiedad de la identificación del lado
        private SubNivelesModel _subnivel = new SubNivelesModel();// Propiedad de la identificación del subnivel

        /// <summary>
        /// Destructor de la Clase
        /// </summary>
        ~PosicionesModel() { }
        /// <summary>
        /// Acceso a la Propiedad Posición
        /// </summary>
        public string Posicion
        {
            get { return _posicion; }
            set { _posicion = value; }
        }
        /// <summary>
        /// Acceso a la propiedad Lado
        /// </summary>
        public LadosModel Lado
        {
            get { return _lado; }
            set { _lado = value; }
        }
        /// <summary>
        /// Acceso a la Propiedad SubNivel
        /// </summary>
        public SubNivelesModel SubNivel
        {
            get { return _subnivel; }
            set { _subnivel = value; }
        }
    }
}
