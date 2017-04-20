using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;


namespace SADI.Clases
{
    /// <summary>
    /// Clase para las Utilerías necesarias para el SADI
    /// </summary>
    public static class Utilerias
    {
        private static string _ipadd;// Propiedad para la IP del equipo
        private static string _compname = Dns.GetHostName();// Propiedad del Nombre del Equipo
        private static WindowsIdentity _winUser = WindowsIdentity.GetCurrent();// Obtener los datos de Sesión de Windows
        private static string _userdomain = _winUser.Name;// Usuario de Dominio
        private static int _idusuario;// Id del usuario del sistema SADI
           
        private static string _dominio = IPGlobalProperties.GetIPGlobalProperties().DomainName;// Nombre del Dominio
        private static IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());// Obtener la Información del Host del Dominio
        /// <summary>
        /// Acceso a la Propiedad del Nombre del Equipo
        /// </summary>
        public static string IpAddress
        {
            get
            {
                IpLocal();
                return _ipadd;
            }
        }
        /// <summary>
        /// Acceso a la Propiedad Nombre de la Computadora
        /// </summary>
        public static string ComputerName
        {
            get { return _compname; }
            //set { _compname = value; }
        }
        /// <summary>
        /// Acceso al Nombre del Usuario del Dominio
        /// </summary>
        public static string UserDomain
        {
            get { return _userdomain; }
            //set { _userdomain = value; }
        }
        /// <summary>
        /// Acceso  al Nombre del Dominio
        /// </summary>
        public static string NombreDominio
        {
            get { return _dominio; }
        }
        // Obtener la IP Local
        private static void IpLocal()
        {
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    _ipadd = ip.ToString();
                    break;
                }
            }

        }
        /// <summary>
        /// Función para Validar el Correo Electrónico del Usuario
        /// </summary>
        /// <param name="email">Correo Electrónico</param>
        /// <returns>Boleano</returns>
        public static bool ValidarEmail(string email)
        {
            var foo = new EmailAddressAttribute();
            bool bar;

            bar = foo.IsValid(email);

            return bar;

        }
        /// <summary>
        /// Identificador del Usuario del SIstema SADI
        /// </summary>
        public static int IdUsuario
        {
            get { return _idusuario; }
            set { _idusuario = value; }
        }
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
