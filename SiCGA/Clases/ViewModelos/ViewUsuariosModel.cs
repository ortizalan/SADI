using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiCGA.Clases.Modelos;

namespace SiCGA.Clases.ViewModelos
{
    /// <summary>
    /// Calse del tipo ViewModel, para trabajar internamente
    /// </summary>
    class ViewUsuariosModel : UsuariosModel
    {
        #region Propiedades

        private int _edad;// propiedad Edad

        #endregion


        #region Constructores/Destructores
        /// <summary>
        /// Constructor Vacío de la clase
        /// </summary>
        public ViewUsuariosModel()
        { }
        /// <summary>
        /// Constructor de la Clase que recibe Parámetros
        /// </summary>
        /// <param name="edad">Asignación de la Esad</param>
        public ViewUsuariosModel(int edad)
        {
            this.Edad = edad;
        }
        /// <summary>
        /// Destructor de la Clase
        /// </summary>
        ~ViewUsuariosModel()
        {

        }

        #endregion
        /// <summary>
        /// Acceso a la Propiedad Edad
        /// </summary>
        /// 
        #region Getters/Setters
        public int Edad
        {
            get { return _edad; }
            set { _edad = value; }
        }


        #endregion
    }
}
