using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SADI.Clases;
using SADI.Clases.Modelos;

namespace SADI.Clases.Controladores
{
    class LadosController : Metodos
    {
        /// <summary>
        /// Actualizar Registro del Modelo Lados
        /// </summary>
        /// <param name="o">Objeto del Tipo LadosModel</param>
        /// <returns>Boleano</returns>
        public override bool ActualizarRegistro(object o)
        {
            if(o.GetType() == typeof(LadosModel))// Verificar que el Objeto sea del Tipo Lados Model
            {
                var l = (LadosModel)o;// Castear le variable "l" al tipo LadosModel

                if(Abrir())// Intentar Abrir la Conexión
                {
                    // Intento Exitoso

                    List<Parametros> lista = new List<Parametros>();// Lista de Parámetros
                    lista.Add(new Parametros(@"opc", "3"));// Indicarle la opción al procedimiento
                    lista.Add(new Parametros(@"id", l.Id.ToString()));// Identificador del Registro
                    lista.Add(new Parametros(@"lado",l.Lado)); // Descripción del Lado del Modelo
                    lista.Add(new Parametros(@"img", l.Imagen.ToString()));// Imagen del Lado del Modelo

                    string proce = "sp_lados_crud";// Nombre del Procedimiento

                    if(EjecutarProcedimiento(proce, lista))// Ejecutar el Procedimiento
                    { return true; }// Ejecución Exitosa
                    else
                    { return false; }// Ejecución NO Exitosa

                }
                else// Intento NO Exitoso
                { return false; }
            }
            else
            { return false; }// No son del mismo tipo
        }
        /// <summary>
        /// Consultar un Registro en el Modelo Lados
        /// </summary>
        /// <param name="o">Objeto del tipo LadosModel</param>
        /// <returns>Boleano</returns>
        public override bool ConsultarRegistro(object o)
        {
            if (o.GetType() == typeof(LadosModel))// Verificar que el Objeto sea del Tipo Lados Model
            {
                var l = (LadosModel)o;// Castear le variable "l" al tipo LadosModel

                if (Abrir())// Intentar Abrir la Conexión
                {
                    // Intento Exitoso

                    List<Parametros> lista = new List<Parametros>();// Lista de Parámetros
                    lista.Add(new Parametros(@"opc", "4"));// Indicarle la opción al procedimiento
                    lista.Add(new Parametros(@"id", l.Id.ToString()));// Identificador del Registro
                    lista.Add(new Parametros(@"lado", string.Empty)); // Vacío
                    lista.Add(new Parametros(@"img", string.Empty));// Vacío

                    string proce = "sp_lados_crud";// Nombre del Procedimiento

                    if (ConsultarProcedimiento(proce, lista))// Consultar el Procedimiento
                    { return true; }// Consulta Exitosa
                    else
                    { return false; }// Consulta NO Exitosa

                }
                else// Intento NO Exitoso
                { return false; }
            }
            else
            { return false; }// No son del mismo tipo
        }
        /// <summary>
        /// Consultar todos los registros del Modelo Lados
        /// </summary>
        /// <returns>Boleano</returns>
        public override bool ConsultarRegistros()
        {
            if (Abrir())// Intentar Abrir la Conexión
            {
                // Intento Exitoso

                List<Parametros> lista = new List<Parametros>();// Lista de Parámetros
                lista.Add(new Parametros(@"opc", "1"));// Indicarle la opción al procedimiento
                lista.Add(new Parametros(@"id", string.Empty));// Vacío
                lista.Add(new Parametros(@"lado", string.Empty)); // Vacío
                lista.Add(new Parametros(@"img", string.Empty));// Vacío

                string proce = "sp_lados_crud";// Nombre del Procedimiento

                if (ConsultarProcedimiento(proce, lista))// Consultar el Procedimiento
                { return true; }// Consulta Exitosa
                else
                { return false; }// Consulta NO Exitosa

            }
            else// Intento NO Exitoso
            { return false; }
        }
        /// <summary>
        /// Ingresar un Registro al Modelo Lados
        /// </summary>
        /// <param name="o">Objeto del Tipo LadosModel</param>
        /// <returns>Boleano</returns>
        public override bool IngresarRegisto(object o)
        {
            if (o.GetType() == typeof(LadosModel))// Verificar que el Objeto sea del Tipo Lados Model
            {
                var l = (LadosModel)o;// Castear le variable "l" al tipo LadosModel

                if (Abrir())// Intentar Abrir la Conexión
                {
                    // Intento Exitoso

                    List<Parametros> lista = new List<Parametros>();// Lista de Parámetros
                    lista.Add(new Parametros(@"opc", "2"));// Indicarle la opción al procedimiento
                    lista.Add(new Parametros(@"id", l.Id.ToString()));// Identificador del Registro
                    lista.Add(new Parametros(@"lado", l.Lado)); // Descripción del Lado del Modelo
                    lista.Add(new Parametros(@"img", l.Imagen.ToString()));// Imagen del Lado del Modelo

                    string proce = "sp_lados_crud";// Nombre del Procedimiento

                    if (EjecutarProcedimiento(proce, lista))// Ejecutar el Procedimiento
                    { return true; }// Ejecución Exitosa
                    else
                    { return false; }// Ejecución NO Exitosa

                }
                else// Intento NO Exitoso
                { return false; }
            }
            else
            { return false; }// No son del mismo tipo
        }
    }
}
