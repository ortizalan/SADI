using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SADI.Clases
{
    /// <summary>
    /// Clase para las Utilerías necesarias para el SADI
    /// </summary>
    public static class Utilerias
    {

    }

    /// <summary>
    /// Clase para las utilerías de seguridad en SADI
    /// </summary>
    public static class Seguridad
    {
        /// <summary>
        /// Función Estática Para la Encriptación de Cadenas de Texto
        /// </summary>
        /// <param name="cadena">Texto a Encritpar</param>
        /// <returns>Cadena Encriptada</returns>
        public static string Encriptar(string cadena)
        {
            string resultado = string.Empty;// Variable dónde guardaremos la encriptación
            byte[] encryptado = System.Text.Encoding.Unicode.GetBytes(cadena);// Encriptado de arreglo de Bytes de la cadena
            resultado = Convert.ToBase64String(encryptado);//Conversión a cadena del encriptado

            return resultado;// Retornamos cadena encriptada
        }
        /// <summary>
        /// Función Estática para Desencriptar un Texto
        /// </summary>
        /// <param name="cadena">Texto a Descriptar</param>
        /// <returns>Cadena Desencriptada</returns>
        public static string Desencriptar(string cadena)
        {
            string resultado = string.Empty;// Variable dónde guadaremos la desencriptación
            byte[] desencryptado = Convert.FromBase64String(cadena);// Desencriptado del Arreglo de bytes
            resultado = System.Text.Encoding.Unicode.GetString(desencryptado);// Conversión del resultado a cadena

            return resultado;// Retorno de cadena desencriptada
        }
    }
    /// <summary>
    /// Clase para manejar los datos de la computadora del usuario
    /// </summary>
    public static class Equipos
    {
        private static string _nomcompu;
        /// <summary>
        /// Acceso a la Propiedad Nombre de Computadora
        /// </summary>
        public static string NombreCompu
        {
            get { return _nomcompu; }
            set { _nomcompu = value; }
        }

    }
}
