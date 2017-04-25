using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SADI.Clases;
using SADI.Clases.Modelos;

namespace SADI.Clases.Controladores
{
    /// <summary>
    /// Clase Controladora de Niveles
    /// </summary>
    class NivelesController : Metodos
    {
        /// <summary>
        /// Actualizar Resgistro en el Modelo Niveles
        /// </summary>
        /// <param name="o">Onbeto del tipo NivelesModel</param>
        /// <returns>Boleano</returns>
        public override bool ActualizarRegistro(object o)
        {
            if(o.GetType() == typeof(NivelesModel))// Validar que el Objeto sea del Tipo NivelesModelo
            {
                var n = (NivelesModel)o; // Castear la variabe "n" al tipo NivelesModel

                if(Abrir())// Intentar Abrir la Conexión
                {
                    // Intento Exitoso

                    try
                    {
                        List<Parametros> lista = new List<Parametros>();// Lista de Parámetros
                        lista.Add(new Parametros(@"opc", "3"));
                        lista.Add(new Parametros(@"id", n.Id.ToString()));// Identificador del Nivel
                        lista.Add(new Parametros(@"nivel", n.Nivel));//Descripción del Nivel
                        lista.Add(new Parametros(@"img", n.Imagen.ToString()));// Imagen del Nivel

                        string proce = "sp_niveles_crud";// Indicar el Nombre del Procedimiento

                        if(EjecutarProcedimiento(proce, lista))//Ejecutar el Procedimiento
                        { return true; }// Ejecución Exitosa
                        else
                        { return false; }// Ejecución NO Exitosa, COnsultar Error

                    }
                    catch(Exception e)// Atrapar el Error
                    {
                        Error = e.Message.ToString();// Guardar el Error
                        return false;//Indicar que existe el error
                    }
                    finally { Cerrar(); }// Cerrar la conexión
                }
                else// Intento NO Exitoso, Consultar Error
                { return false; }
            }
            else// Noson del mismo tipo
            { return false; }
        }
        /// <summary>
        /// Consultar un Registro del Modelo Niveles
        /// </summary>
        /// <param name="o">Objeto del tipo NivelesModel</param>
        /// <returns>Boleano</returns>
        public override bool ConsultarRegistro(object o)
        {
            if (o.GetType() == typeof(NivelesModel))// Validar que el Objeto sea del Tipo NivelesModelo
            {
                var n = (NivelesModel)o; // Castear la variabe "n" al tipo NivelesModel

                if (Abrir())// Intentar Abrir la Conexión
                {
                    // Intento Exitoso

                    try
                    {
                        List<Parametros> lista = new List<Parametros>();// Lista de Parámetros
                        lista.Add(new Parametros(@"opc", "4"));// Indicarle la Opción
                        lista.Add(new Parametros(@"id", n.Id.ToString()));// Identificador del Nivel
                        lista.Add(new Parametros(@"nivel", string.Empty));//Vacío
                        lista.Add(new Parametros(@"img", string.Empty));// Vacío

                        string proce = "sp_niveles_crud";// Indicar el Nombre del Procedimiento

                        if (ConsultarProcedimiento(proce, lista))//Consultar el Procedimiento
                        { return true; }// Consulta Exitosa
                        else
                        { return false; }// Consulta NO Exitosa, COnsultar Error

                    }
                    catch (Exception e)// Atrapar el Error
                    {
                        Error = e.Message.ToString();// Guardar el Error
                        return false;//Indicar que existe el error
                    }
                    finally { Cerrar(); }// Cerrar la conexión
                }
                else// Intento NO Exitoso, Consultar Error
                { return false; }
            }
            else// Noson del mismo tipo
            { return false; }
        }
        /// <summary>
        /// Consultar todos los Registros del Modelo Niveles
        /// </summary>
        /// <returns>Boleano</returns>
        public override bool ConsultarRegistros()
        {
            if (Abrir())// Intentar Abrir la Conexión
            {
                // Intento Exitoso

                try
                {
                    List<Parametros> lista = new List<Parametros>();// Lista de Parámetros
                    lista.Add(new Parametros(@"opc", "1"));// Indicarle la Opción
                    lista.Add(new Parametros(@"id", string.Empty));// Vacío
                    lista.Add(new Parametros(@"nivel", string.Empty));//Vacío
                    lista.Add(new Parametros(@"img", string.Empty));// Vacío

                    string proce = "sp_niveles_crud";// Indicar el Nombre del Procedimiento

                    if (ConsultarProcedimiento(proce, lista))//Consultar el Procedimiento
                    { return true; }// Consulta Exitosa
                    else
                    { return false; }// Consulta NO Exitosa, COnsultar Error

                }
                catch (Exception e)// Atrapar el Error
                {
                    Error = e.Message.ToString();// Guardar el Error
                    return false;//Indicar que existe el error
                }
                finally { Cerrar(); }// Cerrar la conexión
            }
            else// Intento NO Exitoso, Consultar Error
            { return false; }
        }
        /// <summary>
        /// Ingresar Registro al Modelo Niveles
        /// </summary>
        /// <param name="o">Onjeto del Tipo NivelesModel</param>
        /// <returns>Boleano</returns>
        public override bool IngresarRegisto(object o)
        {
            if (o.GetType() == typeof(NivelesModel))// Validar que el Objeto sea del Tipo NivelesModelo
            {
                var n = (NivelesModel)o; // Castear la variabe "n" al tipo NivelesModel

                if (Abrir())// Intentar Abrir la Conexión
                {
                    // Intento Exitoso

                    try
                    {
                        List<Parametros> lista = new List<Parametros>();// Lista de Parámetros
                        lista.Add(new Parametros(@"opc", "2"));
                        lista.Add(new Parametros(@"id", n.Id.ToString()));// Identificador del Nivel
                        lista.Add(new Parametros(@"nivel", n.Nivel));//Descripción del Nivel
                        lista.Add(new Parametros(@"img", n.Imagen.ToString()));// Imagen del Nivel

                        string proce = "sp_niveles_crud";// Indicar el Nombre del Procedimiento

                        if (EjecutarProcedimiento(proce, lista))//Ejecutar el Procedimiento
                        { return true; }// Ejecución Exitosa
                        else
                        { return false; }// Ejecución NO Exitosa, COnsultar Error

                    }
                    catch (Exception e)// Atrapar el Error
                    {
                        Error = e.Message.ToString();// Guardar el Error
                        return false;//Indicar que existe el error
                    }
                    finally { Cerrar(); }// Cerrar la conexión
                }
                else// Intento NO Exitoso, Consultar Error
                { return false; }
            }
            else// Noson del mismo tipo
            { return false; }
        }
    }
}
