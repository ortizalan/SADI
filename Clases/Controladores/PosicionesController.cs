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
    /// Objeto Controlador del Modelo Posiciones
    /// </summary>
    class PosicionesController : Metodos
    {
        /// <summary>
        /// Función para Actualizar Registro en el Modelo
        /// </summary>
        /// <param name="o">Objeto del Tipo PosicionesModel</param>
        /// <returns>Boleano</returns>
        public override bool ActualizarRegistro(object o)
        {
            if(o.GetType() == typeof(PosicionesModel))// Validar que el Objeto sea del Modelo PosicionesModel
            {
                var p = (PosicionesModel)o;// Castear la variable "p" al tipo PosicionesModel

                if(Abrir())// Intentar Abrir la Conexión
                {
                    // Intento Exitoso

                    try
                    {
                        List<Parametros> lista = new List<Parametros>();
                        lista.Add(new Parametros(@"opc", "3"));// Indicarle la Opción a Ejecutar al Procedimiento
                        lista.Add(new Parametros(@"id", p.Id.ToString()));//Identificador del Registro del Modelo
                        lista.Add(new Parametros(@"posicion", p.Posicion));//Descripción del Registro
                        lista.Add(new Parametros(@"lado", p.Lado.Id.ToString()));// Identificador del Lado del Registro
                        lista.Add(new Parametros(@"subnivel", p.SubNivel.Id.ToString()));// Identificador del SubNivel del Registro
                        lista.Add(new Parametros(@"img", p.Imagen.ToString()));// Imagen del Registro

                        string proce = "sp_posiciones.crud";//Nombre del Procedimiento

                        if(EjecutarProcedimiento(proce,lista))//Ejecutar el Procedimiento
                        { return true; }//Ejecición Exitosa
                        else
                        { return false; }// Ejecución NO Exitosa
                    }
                    catch(Exception e)// Atrapar el Error
                    {
                        Error = e.Message.ToString();// Guardar el Error
                        return false;// Indicar que existe el error
                    }
                    finally { Cerrar(); }// Cerrar la Conexión
                }
                else// Intento NO Exitoso, Consultar Error
                { return false; }
            }
            else// No son del mismo tipo
            { return false; }
        }
        /// <summary>
        /// Función para Seleccionar un Registro en el Modelo
        /// </summary>
        /// <param name="o">Objeto del Tipo PosicionesModel</param>
        /// <returns>Boleano</returns>
        public override bool ConsultarRegistro(object o)
        {
            if (o.GetType() == typeof(PosicionesModel))// Validar que el Objeto sea del Modelo PosicionesModel
            {
                var p = (PosicionesModel)o;// Castear la variable "p" al tipo PosicionesModel

                if (Abrir())// Intentar Abrir la Conexión
                {
                    // Intento Exitoso

                    try
                    {
                        List<Parametros> lista = new List<Parametros>();
                        lista.Add(new Parametros(@"opc", "4"));// Indicarle la Opción a Ejecutar al Procedimiento
                        lista.Add(new Parametros(@"id", p.Id.ToString()));//Identificador del Registro del Modelo
                        lista.Add(new Parametros(@"posicion", string.Empty));//Vacío
                        lista.Add(new Parametros(@"lado", string.Empty));// Vacío
                        lista.Add(new Parametros(@"subnivel", string.Empty));// Vacío
                        lista.Add(new Parametros(@"img", string.Empty));// Vacío

                        string proce = "sp_posiciones.crud";//Nombre del Procedimiento

                        if (ConsultarProcedimiento(proce, lista))//Consultar el Procedimiento
                        { return true; }//Consulta Exitosa
                        else
                        { return false; }// Consulta NO Exitosa
                    }
                    catch (Exception e)// Atrapar el Error
                    {
                        Error = e.Message.ToString();// Guardar el Error
                        return false;// Indicar que existe el error
                    }
                    finally { Cerrar(); }// Cerrar la Conexión
                }
                else// Intento NO Exitoso, Consultar Error
                { return false; }
            }
            else// No son del mismo tipo
            { return false; }
        }
        /// <summary>
        /// Función para Seleccionar todos los Registro del Modelo
        /// </summary>
        /// <returns>Boleano</returns>
        public override bool ConsultarRegistros()
        {
            if (Abrir())// Intentar Abrir la Conexión
            {
                // Intento Exitoso

                try
                {
                    List<Parametros> lista = new List<Parametros>();
                    lista.Add(new Parametros(@"opc", "1"));// Indicarle la Opción a Ejecutar al Procedimiento
                    lista.Add(new Parametros(@"id", string.Empty));//Vacío
                    lista.Add(new Parametros(@"posicion", string.Empty));//Vacío
                    lista.Add(new Parametros(@"lado", string.Empty));// Vacío
                    lista.Add(new Parametros(@"subnivel", string.Empty));// Vacío
                    lista.Add(new Parametros(@"img", string.Empty));// Vacío

                    string proce = "sp_posiciones.crud";//Nombre del Procedimiento

                    if (ConsultarProcedimiento(proce, lista))//Consultar el Procedimiento
                    { return true; }//Consulta Exitosa
                    else
                    { return false; }// Consulta NO Exitosa
                }
                catch (Exception e)// Atrapar el Error
                {
                    Error = e.Message.ToString();// Guardar el Error
                    return false;// Indicar que existe el error
                }
                finally { Cerrar(); }// Cerrar la Conexión
            }
            else// Intento NO Exitoso, Consultar Error
            { return false; }
        }
        /// <summary>
        /// Función para Ingresar un Registro al Modelo
        /// </summary>
        /// <param name="o">Objeto del Tipo PosicionesModel</param>
        /// <returns>Boleano</returns>
        public override bool IngresarRegisto(object o)
        {
            if (o.GetType() == typeof(PosicionesModel))// Validar que el Objeto sea del Modelo PosicionesModel
            {
                var p = (PosicionesModel)o;// Castear la variable "p" al tipo PosicionesModel

                if (Abrir())// Intentar Abrir la Conexión
                {
                    // Intento Exitoso

                    try
                    {
                        List<Parametros> lista = new List<Parametros>();
                        lista.Add(new Parametros(@"opc", "2"));// Indicarle la Opción a Ejecutar al Procedimiento
                        lista.Add(new Parametros(@"id", p.Id.ToString()));//Identificador del Registro del Modelo
                        lista.Add(new Parametros(@"posicion", p.Posicion));//Descripción del Registro
                        lista.Add(new Parametros(@"lado", p.Lado.Id.ToString()));// Identificador del Lado del Registro
                        lista.Add(new Parametros(@"subnivel", p.SubNivel.Id.ToString()));// Identificador del SubNivel del Registro
                        lista.Add(new Parametros(@"img", p.Imagen.ToString()));// Imagen del Registro

                        string proce = "sp_posiciones.crud";//Nombre del Procedimiento

                        if (EjecutarProcedimiento(proce, lista))//Ejecutar el Procedimiento
                        { return true; }//Ejecición Exitosa
                        else
                        { return false; }// Ejecución NO Exitosa
                    }
                    catch (Exception e)// Atrapar el Error
                    {
                        Error = e.Message.ToString();// Guardar el Error
                        return false;// Indicar que existe el error
                    }
                    finally { Cerrar(); }// Cerrar la Conexión
                }
                else// Intento NO Exitoso, Consultar Error
                { return false; }
            }
            else// No son del mismo tipo
            { return false; }
        }
    }
}
