using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SADI.Clases;
using SADI.Clases.Modelos;

namespace SADI.Clases.Controladores
{
    class FilasController : Metodos
    {
        /// <summary>
        /// Actualizar el Registro
        /// </summary>
        /// <param name="o">Objeto del Tipo FilasModel</param>
        /// <returns>Boleano</returns>
        public override bool ActualizarRegistro(object o)
        {
            if (o.GetType() == typeof(FilasModel))// Verificar si el objeto es del tipo FilasModel
            {
                var f = (FilasModel)o;//Caster variable "f" al tipo FilasModel;

                if(Abrir())// Intentar Abrir la Conexión
                {
                    // Intento Exitoso
                    try
                    {
                        List<Parametros> lista = new List<Parametros>();// Lista de Parámetros
                        lista.Add(new Parametros(@"opc","3"));// Opción para el procedimiento
                        lista.Add(new Parametros(@"id", f.Id.ToString()));// Identificador del Registro
                        lista.Add(new Parametros(@"fila", f.Fila));// Descripción de la Fila
                        lista.Add(new Parametros(@"img", f.Imagen.ToString()));// Imagen de la Fila

                        string proce = "sp_filas_crud";// Nombre del procedimineto

                        if(EjecutarProcedimiento(proce,lista))// Ejecutar el procedimiento
                        { return true; }// Ejecución Exitosa
                        else
                        { return false; }// Ejecución NO Exitosa, Consultar Error


                    }
                    catch(Exception e)// Atrapar el Error
                    {
                        Error = e.Message.ToString();// Guardar el Error
                        return false;// Indicar que existe un error
                    }
                    finally { Cerrar(); }// Cerrar la Conexión
                }
                else// Intento NO Exitoso, consultar Error
                { return false; }
            }
            else//No son del mismo tipo
            { return false; }
        }
        /// <summary>
        /// Consultar un Registro en el Modelo
        /// </summary>
        /// <param name="o">Objeto del tipo FilasModel</param>
        /// <returns></returns>
        public override bool ConsultarRegistro(object o)
        {
            if (o.GetType() == typeof(FilasModel))// Verificar si el objeto es del tipo FilasModel
            {
                var f = (FilasModel)o;//Caster variable "f" al tipo FilasModel;

                if (Abrir())// Intentar Abrir la Conexión
                {
                    // Intento Exitoso
                    try
                    {
                        List<Parametros> lista = new List<Parametros>();// Lista de Parámetros
                        lista.Add(new Parametros(@"opc", "4"));// Opción para el procedimiento
                        lista.Add(new Parametros(@"id", f.Id.ToString()));// Identificador del Registro
                        lista.Add(new Parametros(@"fila", string.Empty));// Vacío
                        lista.Add(new Parametros(@"img", string.Empty));// Vacío

                        string proce = "sp_filas_crud";// Nombre del procedimineto

                        if (ConsultarProcedimiento(proce, lista))// Ejecutar el procedimiento
                        { return true; }// Consulta Exitosa
                        else
                        { return false; }// Consulta NO Exitosa, Consultar Error


                    }
                    catch (Exception e)// Atrapar el Error
                    {
                        Error = e.Message.ToString();// Guardar el Error
                        return false;// Indicar que existe un error
                    }
                    finally { Cerrar(); }// Cerrar la Conexión
                }
                else// Intento NO Exitoso, consultar Error
                { return false; }
            }
            else//No son del mismo tipo
            { return false; }
        }
        /// <summary>
        /// Consultar Todos los Registros en el Modelo Filas
        /// </summary>
        /// <returns></returns>
        public override bool ConsultarRegistros()
        {
            if (Abrir())// Intentar Abrir la Conexión
            {
                // Intento Exitoso
                try
                {
                    List<Parametros> lista = new List<Parametros>();// Lista de Parámetros
                    lista.Add(new Parametros(@"opc", "1"));// Opción para el procedimiento
                    lista.Add(new Parametros(@"id", string.Empty));// Vacío
                    lista.Add(new Parametros(@"fila", string.Empty));// Vacío
                    lista.Add(new Parametros(@"img", string.Empty));// Vacío

                    string proce = "sp_filas_crud";// Nombre del procedimineto

                    if (ConsultarProcedimiento(proce, lista))// Ejecutar el procedimiento
                    { return true; }// Consulta Exitosa
                    else
                    { return false; }// Consulta NO Exitosa, Consultar Error


                }
                catch (Exception e)// Atrapar el Error
                {
                    Error = e.Message.ToString();// Guardar el Error
                    return false;// Indicar que existe un error
                }
                finally { Cerrar(); }// Cerrar la Conexión
            }
            else// Intento NO Exitoso, consultar Error
            { return false; }
        }
        /// <summary>
        /// Ingresar un Registro en el Modelo
        /// </summary>
        /// <param name="o">Objeto del Tipo FilasModel</param>
        /// <returns>Boleano</returns>
        public override bool IngresarRegisto(object o)
        {
            if (o.GetType() == typeof(FilasModel))// Verificar si el objeto es del tipo FilasModel
            {
                var f = (FilasModel)o;//Caster variable "f" al tipo FilasModel;

                if (Abrir())// Intentar Abrir la Conexión
                {
                    // Intento Exitoso
                    try
                    {
                        List<Parametros> lista = new List<Parametros>();// Lista de Parámetros
                        lista.Add(new Parametros(@"opc", "2"));// Opción para el procedimiento
                        lista.Add(new Parametros(@"id", f.Id.ToString()));// Identificador del Registro
                        lista.Add(new Parametros(@"fila", f.Fila));// Descripción de la Fila
                        lista.Add(new Parametros(@"img", f.Imagen.ToString()));// Imagen de la Fila

                        string proce = "sp_filas_crud";// Nombre del procedimineto

                        if (EjecutarProcedimiento(proce, lista))// Ejecutar el procedimiento
                        { return true; }// Ejecución Exitosa
                        else
                        { return false; }// Ejecución NO Exitosa, Consultar Error


                    }
                    catch (Exception e)// Atrapar el Error
                    {
                        Error = e.Message.ToString();// Guardar el Error
                        return false;// Indicar que existe un error
                    }
                    finally { Cerrar(); }// Cerrar la Conexión
                }
                else// Intento NO Exitoso, consultar Error
                { return false; }
            }
            else//No son del mismo tipo
            { return false; }
        }
    }
}
