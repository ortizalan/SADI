///////////////////////////////////////////////////////////
//  Secciones.cs
//  Implementation of the Auxiliar Class Parametros
//  Created on:      20-jun.-2017 
//  Original author: Ing. Alan Adalberto Ortiz Pérez
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADI.Clases
{
    public class Secciones
    {
        private string _seccion;

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public Secciones()
        {

        }
        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        /// <param name="val">Valor de la Sección</param>
        public Secciones(string val)
        {
            Seccion = val;// Asignación del Valor 
        }

        /// <summary>
        /// Acceso a la Propiedad Sección
        /// </summary>
        public string  Seccion
        { get { return _seccion; } set { _seccion = value; } }
    }
}
