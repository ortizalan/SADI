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
            string resultado = string.Empty;
            byte[] encryptado = System.Text.Encoding.Unicode.GetBytes(cadena);
            resultado = Convert.ToBase64String(encryptado);

            return resultado;
        }
        /// <summary>
        /// Función Estática para Desencriptar un Texto
        /// </summary>
        /// <param name="cadena">Texto a Descriptar</param>
        /// <returns>Cadena Desencriptada</returns>
        public static string Desencriptar(string cadena)
        {
            string resultado = string.Empty;
            byte[] desencryptado = Convert.FromBase64String(cadena);
            resultado = System.Text.Encoding.Unicode.GetString(desencryptado);

            return resultado;
        }
    }
}
