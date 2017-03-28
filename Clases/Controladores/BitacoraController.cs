using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SADI.Clases.Modelos;

namespace SADI.Clases.Controladores
{
    class BitacoraController : Metodos
    {
        /// <summary>
        /// Constructor de la Clase
        /// </summary>
		public BitacoraController()
		{
			
		}
        /// <summary>
        /// Destructor de la Clase
        /// </summary>
        ~BitacoraController() {
        }

        /// <summary>
        /// Método para Consultar un Registro por Id
        /// </summary>
        /// <param name="o">Objeto del tipo BitacoraModel</param>
        /// <returns>Bolean</returns>
        public override bool ConsultarRegistro(object o)
        {
            if(o.GetType() == typeof(BitacoraModel))// Verificar si el Objeto es del Tipo BitacoraModel
            {
                var b = (BitacoraModel)o;// Castear variable "b" al tipo BitacoraModel

                if(Abrir())// Intento de Abrir la conexión
                {
                    // Intento Exitoso
                    try
                    {
                        List<Parametros> lista = new List<Parametros>();// Crear una Arreglo de Parámetros
                        lista.Add(new Parametros(@"opc", "4"));// Enviar la opción al procedimiento
                        lista.Add(new Parametros(@"id", b.Id.ToString()));// La identificación del registro
                        lista.Add(new Parametros(@"seriedoc", string.Empty));
                        lista.Add(new Parametros(@"fecha", string.Empty));
                        lista.Add(new Parametros(@"mov", string.Empty));
                        lista.Add(new Parametros(@"usr", string.Empty));
                        lista.Add(new Parametros(@"comp", string.Empty));
                        lista.Add(new Parametros(@"idcom", string.Empty));

                        string proce = "sp_bitacora_crud";// Nombre del Procedimiento

                        if (ConsultarProcedimiento(proce, lista))// Consultar el Procedimiento
                        { return true; }// Consulta Exitosa, Consultar Tabla
                        else
                        { return false; }// Consulta NO Exitosa, consultar Error
                    }
                    catch(Exception e)// Cachar error
                    {
                        Error = e.Message.ToString();// Guardar el Error
                        return false;// Indicar que existió falló
                    }
                    finally { Cerrar(); }// Cerrar Conexción
                }
                else
                { return false; }// No se estableció la conexión, consultar Error
            }
            else//
            { return false; }// No es del tipo BitacoraModel
            throw new NotImplementedException();
        }
        /// <summary>
        /// Método para Actualizar Registro
        /// </summary>
        /// <param name="o">Objeto del Tipo BitcoraModel</param>
        /// <returns>Boleano</returns>
        public override bool ActualizarRegistro(object o)
        {
            if (o.GetType() == typeof(BitacoraModel))// Verificar si el Objeto es del Tipo BitacoraModel
            {
                var b = (BitacoraModel)o;// Castear variable "b" al tipo BitacoraModel

                if (Abrir())// Intento de Abrir la conexión
                {
                    // Intento Exitoso
                    try
                    {
                        List<Parametros> lista = new List<Parametros>();// Crear una Arreglo de Parámetros
                        lista.Add(new Parametros(@"opc", "2"));// Enviar la opción al procedimiento
                        lista.Add(new Parametros(@"id", b.Id.ToString()));// La identificación del registro
                        lista.Add(new Parametros(@"seriedoc", b.SerieDoctal.Id.ToString()));// Serie Documental del Movimiento
                        lista.Add(new Parametros(@"fecha", b.Fecha.ToString("yyyy-MM-dd")));// Fecha del Movimiento
                        lista.Add(new Parametros(@"mov", b.Movimiento.Id.ToString()));// Tipo del Moviemiento
                        lista.Add(new Parametros(@"usr", b.Usuario.Id.ToString()));// Identificador del Usuario
                        lista.Add(new Parametros(@"comp", b.Computadora));// Nombre de la Computadora
                        lista.Add(new Parametros(@"idcom", b.IdComputadora));// Identificador de la Computadora

                        string proce = "sp_bitacora_crud";// Nombre del Procedimiento

                        if (EjecutarProcedimiento(proce, lista))// Ejecutar el Procedimiento
                        { return true; }// Ejecución Exitosa, Consultar Tabla
                        else
                        { return false; }// Ejecución NO Exitosa, consultar Error
                    }
                    catch (Exception e)// Cachar error
                    {
                        Error = e.Message.ToString();// Guardar el Error
                        return false;// Indicar que existió falló
                    }
                    finally { Cerrar(); }// Cerrar Conexción
                }
                else
                { return false; }// No se estableció la conexión, consultar Error
            }
            else//
            { return false; }// No es del tipo BitacoraModel
            throw new NotImplementedException();
        }
        /// <summary>
        /// Método para Ingresar Registro
        /// </summary>
        /// <param name="o">Objeto del Tipo BitacoraModel</param>
        /// <returns>Boleano</returns>
        public override bool IngresarRegisto(object o)
        {
            if (o.GetType() == typeof(BitacoraModel))// Verificar si el Objeto es del Tipo BitacoraModel
            {
                var b = (BitacoraModel)o;// Castear variable "b" al tipo BitacoraModel

                if (Abrir())// Intento de Abrir la conexión
                {
                    // Intento Exitoso
                    try
                    {
                        List<Parametros> lista = new List<Parametros>();// Crear una Arreglo de Parámetros
                        lista.Add(new Parametros(@"opc", "3"));// Enviar la opción al procedimiento
                        lista.Add(new Parametros(@"id", b.Id.ToString()));// La identificación del registro
                        lista.Add(new Parametros(@"seriedoc", b.SerieDoctal.Id.ToString()));// Serie Documental del Movimiento
                        lista.Add(new Parametros(@"fecha", b.Fecha.ToString("yyyy-MM-dd")));// Fecha del Movimiento
                        lista.Add(new Parametros(@"mov", b.Movimiento.Id.ToString()));// Tipo del Moviemiento
                        lista.Add(new Parametros(@"usr", b.Usuario.Id.ToString()));// Identificador del Usuario
                        lista.Add(new Parametros(@"comp", b.Computadora));// Nombre de la Computadora
                        lista.Add(new Parametros(@"idcom", b.IdComputadora));// Identificador de la Computadora

                        string proce = "sp_bitacora_crud";// Nombre del Procedimiento

                        if (EjecutarProcedimiento(proce, lista))// Ejecución el Procedimiento
                        { return true; }// Ejecución Exitosa, Consultar Tabla
                        else
                        { return false; }// Ejecución NO Exitosa, consultar Error
                    }
                    catch (Exception e)// Cachar error
                    {
                        Error = e.Message.ToString();// Guardar el Error
                        return false;// Indicar que existió falló
                    }
                    finally { Cerrar(); }// Cerrar Conexción
                }
                else
                { return false; }// No se estableció la conexión, consultar Error
            }
            else//
            { return false; }// No es del tipo BitacoraModel
            throw new NotImplementedException();
        }
        /// <summary>
        /// Método para Consultar todos los Registros de BitacoraModel
        /// </summary>
        /// <returns>Boleano</returns>
        public override bool ConsultarRegistros()
        {
                if (Abrir())// Intento de Abrir la conexión
                {
                    // Intento Exitoso
                    try
                    {
                        List<Parametros> lista = new List<Parametros>();// Crear una Arreglo de Parámetros
                        lista.Add(new Parametros(@"opc", "1"));// Enviar la opción al procedimiento
                        lista.Add(new Parametros(@"id", string.Empty));// La identificación del registro
                        lista.Add(new Parametros(@"seriedoc", string.Empty));// Serie Documental del Movimiento
                        lista.Add(new Parametros(@"fecha", string.Empty));// Fecha del Movimiento
                        lista.Add(new Parametros(@"mov", string.Empty));// Tipo del Moviemiento
                        lista.Add(new Parametros(@"usr", string.Empty));// Identificador del Usuario
                        lista.Add(new Parametros(@"comp", string.Empty));// Nombre de la Computadora
                        lista.Add(new Parametros(@"idcom", string.Empty));// Identificador de la Computadora

                        string proce = "sp_bitacora_crud";// Nombre del Procedimiento

                        if (EjecutarProcedimiento(proce, lista))// Consultar el Procedimiento
                        { return true; }// Consulta Exitosa, Consultar Tabla
                        else
                        { return false; }// Consulta NO Exitosa, consultar Error
                    }
                    catch (Exception e)// Cachar error
                    {
                        Error = e.Message.ToString();// Guardar el Error
                        return false;// Indicar que existió falló
                    }
                    finally { Cerrar(); }// Cerrar Conexción
                }
                else
                { return false; }// No se estableció la conexión, consultar Error
            
            throw new NotImplementedException();
        }
    }
}