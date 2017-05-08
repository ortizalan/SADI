using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SADI.Clases;
using SADI.Clases.Modelos;

namespace SADI.Clases.Controladores
{
    class EstantesController : Metodos
    {
        /// <summary>
        /// Actualizar el Modelo Estantes
        /// </summary>
        /// <param name="o">Onjeto del Tipo EstantesModel</param>
        /// <returns>Boleano</returns>
        public override bool ActualizarRegistro(object o)
        {
            if(o.GetType() == typeof(EstantesModel))// Verificar si el Objeto sea del Tipo EstantesModel
            {
                var e = (EstantesModel)o;// Castear la variable "e" al tipo EstantesModel

                if(Abrir())// Intentar Abrir la Conexión
                {
                    // Intento Exitoso

                    try
                    {
                        List<Parametros> lista = new List<Parametros>();// Lista de Parámetros
                        lista.Add(new Parametros(@"opc", "3"));//Indicarle la Opción al Procedimiento
                        lista.Add(new Parametros(@"id", e.Id.ToString()));// Identificador del Estante
                        lista.Add(new Parametros(@"estante", e.Estante));// Descripción del Estante
                        lista.Add(new Parametros(@"img",Utilerias.ImageToBase64(e.Foto,e.Formato)));// Imagen del Estante

                        string proce = "sp_estantes_crud";// Nombre del Procedimiento

                        if(EjecutarProcedimiento(proce, lista))// Ejecutar el Procedimiento
                        { return true; }// Ejecución Exitosa
                        else
                        { return false; }// Ejecución NO Exitosa
                    }
                    catch(Exception ex)// Atrapar el Error
                    {
                        Error = ex.Message.ToString();// Guarder el Error
                        return false;// Indicar que existe error
                    }
                    finally { Cerrar(); }// Cerrar la Conexión
         
                }
                else// Intento NO Exitoso, Consultar Error
                { return false; }
            }
            else// No son del Mismo Tipo
            { return false; }
        }
        /// <summary>
        /// Consultar un Registro del Modelo Estantes
        /// </summary>
        /// <param name="o">Objeto del Tipo Estantes</param>
        /// <returns>Boleano</returns>
        public override bool ConsultarRegistro(object o)
        {
            if (o.GetType() == typeof(EstantesModel))// Verificar si el Objeto sea del Tipo EstantesModel
            {
                var e = (EstantesModel)o;// Castear la variable "e" al tipo EstantesModel

                if (Abrir())// Intentar Abrir la Conexión
                {
                    // Intento Exitoso

                    try
                    {
                        List<Parametros> lista = new List<Parametros>();// Lista de Parámetros
                        lista.Add(new Parametros(@"opc", "4"));//Indicarle la Opción al Procedimiento
                        lista.Add(new Parametros(@"id", e.Id.ToString()));// Identificador del Estante
                        lista.Add(new Parametros(@"estante", string.Empty));// Vacío
                        lista.Add(new Parametros(@"img", string.Empty));// Vacío

                        string proce = "sp_estantes_crud";// Nombre del Procedimiento

                        if (ConsultarProcedimiento(proce, lista))// Consultar el Procedimiento
                        { return true; }// Consulta Exitosa
                        else
                        { return false; }// Consulta NO Exitosa
                    }
                    catch (Exception ex)// Atrapar el Error
                    {
                        Error = ex.Message.ToString();// Guarder el Error
                        return false;// Indicar que existe error
                    }
                    finally { Cerrar(); }// Cerrar la Conexión

                }
                else// Intento NO Exitoso, Consultar Error
                { return false; }
            }
            else// No son del Mismo Tipo
            { return false; }
        }
        /// <summary>
        /// Consultar Todos los Registros del Modelo Estantes
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
                    lista.Add(new Parametros(@"opc", "1"));//Indicarle la Opción al Procedimiento
                    lista.Add(new Parametros(@"id", string.Empty));// Vacío
                    lista.Add(new Parametros(@"estante", string.Empty));// Vacío
                    lista.Add(new Parametros(@"img", string.Empty));// Vacío

                    string proce = "sp_estantes_crud";// Nombre del Procedimiento

                    if (ConsultarProcedimiento(proce, lista))// Consultar el Procedimiento
                    { return true; }// Consulta Exitosa
                    else
                    { return false; }// Consulta NO Exitosa
                }
                catch (Exception ex)// Atrapar el Error
                {
                    Error = ex.Message.ToString();// Guarder el Error
                    return false;// Indicar que existe error
                }
                finally { Cerrar(); }// Cerrar la Conexión

            }
            else// Intento NO Exitoso, Consultar Error
            { return false; }
        }
        /// <summary>
        /// Ingresar Registro en el Modelo Estantes
        /// </summary>
        /// <param name="o">Objeto del Tipo EstantesModel</param>
        /// <returns>Boleano</returns>
        public override bool IngresarRegisto(object o)
        {
            if (o.GetType() == typeof(EstantesModel))// Verificar si el Objeto sea del Tipo EstantesModel
            {
                var e = (EstantesModel)o;// Castear la variable "e" al tipo EstantesModel

                if (Abrir())// Intentar Abrir la Conexión
                {
                    // Intento Exitoso

                    try
                    {
                        List<Parametros> lista = new List<Parametros>();// Lista de Parámetros
                        lista.Add(new Parametros(@"opc", "2"));//Indicarle la Opción al Procedimiento
                        lista.Add(new Parametros(@"id", e.Id.ToString()));// Identificador del Estante
                        lista.Add(new Parametros(@"estante", e.Estante));// Descripción del Estante
                        lista.Add(new Parametros(@"img", Utilerias.ImageToBase64(e.Foto,e.Formato)));// Imagen del Estante

                        string proce = "sp_estantes_crud";// Nombre del Procedimiento

                        if (EjecutarProcedimiento(proce, lista))// Ejecutar el Procedimiento
                        { return true; }// Ejecución Exitosa
                        else
                        { return false; }// Ejecución NO Exitosa
                    }
                    catch (Exception ex)// Atrapar el Error
                    {
                        Error = ex.Message.ToString();// Guarder el Error
                        return false;// Indicar que existe error
                    }
                    finally { Cerrar(); }// Cerrar la Conexión

                }
                else// Intento NO Exitoso, Consultar Error
                { return false; }
            }
            else// No son del Mismo Tipo
            { return false; }
        }
        /// <summary>
        /// Función para Consultar Último Id Ingresado
        /// </summary>
        /// <returns>Boleano</returns>
        public bool ObtenerUltimoId()
        {
            if(Abrir())//Intentar Abrir la Conexion
            {
                //Intento Exitoso
                try
                {
                    string sente = "select id from Estantes order By ID Desc";// Indicar la Sentencia SQL

                    if(ConsultarSentenciaSQL(sente))//Consultar la Sentencia
                    {
                        return true;// COnsulta Exitosa
                    }
                    else
                    {
                        return false;// COnsulta no Exitosa, Consultar Error
                    }
                }
                catch(Exception e)//Atrapar el Error
                {
                    Error = e.Message.ToString();//Guardar el Error
                    return false;// Indicar que existe el error
                }
                finally { Cerrar(); }//Cerrar la conexión
            }
            else// Intento Fallido, COnsulte Error
            {
                return false;
            }
        }
    }
}
