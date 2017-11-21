using System;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Principal;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

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
        /// <summary>
        /// Función que convierte Bytes a String
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        public static string BytesToStringConverted(byte[] bytes)
        {
            using (var stream = new MemoryStream(bytes))
            {
                using (var streamReader = new StreamReader(stream))
                {
                    return streamReader.ReadToEnd();
                }
            }
        }
        /// <summary>
        /// Imagen a String Base 64
        /// </summary>
        /// <param name="imagen">Archivo de Imagen</param>
        /// <param name="format">Formato JPG, BMP, PNG, etc</param>
        /// <returns>String</returns>
        public static string ImageToBase64(Image imagen, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {

                //Convertir Imagen a arreglo de Bytes
                imagen.Save(ms, format);
                byte[] imagenBytes = ms.ToArray();

                //Convertir los bytes a Base 64 String
                string base64string = Convert.ToBase64String(imagenBytes);
                return base64string;
            }
        }
        /// <summary>
        /// Función para convertir arreglo de bytes a Base64String
        /// </summary>
        /// <param name="bytes">Documento en Arreglo de Bytes</param>
        /// <returns>string</returns>
        public static string BytesToBase64(byte[] bytes)
        {
            string result = Convert.ToBase64String(bytes);
            return result;
        }
        /// <summary>
        /// Función para Convertir una Cadena a Imagen
        /// </summary>
        /// <param name="base46string">Imagen convertida en Cadena</param>
        /// <returns>Image</returns>
        public static Image Base64toImagen(string base46string)
        {
            //Convertir String Base 64 a Bytes
            byte[] ImagenBytes = Convert.FromBase64String(base46string);
            //Convertir Byte a Imagen
            using (var ms = new MemoryStream(ImagenBytes, 0, ImagenBytes.Length))
            {
                Image imagen = Image.FromStream(ms, true);
                return imagen;
            }
        }
        /// <summary>
        /// Función para convertis Base64String a Bytes
        /// </summary>
        /// <param name="bytes">cadena a convertir</param>
        /// <returns>byte[]</returns>
        public static byte[] Base64ToBytes(string bytes)
        {
            byte[] byts = Convert.FromBase64String(bytes);
            return byts;
        }
        /// <summary>
        /// Función para darle un Cierto Formato al DataGrid
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <returns>DataGridView</returns>
        public static DataGridView PropiedadesDataGridView(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToOrderColumns = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;

            return dgv;
        }
        /// <summary>
        /// Función para Guardar Cadena con Saltos de Línea
        /// </summary>
        /// <param name="cadena">TextBox</param>
        /// <returns>Cadena con Salto de Línea</returns>
        public static string CadenaConSaltoLines(TextBox cadena)
        {
            int lineaActual = 1;
            string texto = string.Empty;
            int inicio = 0;
            for(int x = 0; x<cadena.Text.Length;x++)
            {
                int linea = cadena.GetLineFromCharIndex(x);
                if(linea > lineaActual)
                {
                    texto += cadena.Text.Substring(inicio, x - inicio) + Environment.NewLine;
                    inicio += 1;
                    lineaActual = linea;
                }
            }

            return texto;
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
