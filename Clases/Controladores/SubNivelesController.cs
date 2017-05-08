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
    /// Objeto Controlador del Modelo SubNiveles
    /// </summary>
    class SubNivelesController : Metodos
    {
        /// <summary>
        /// Método para Actualizar Registro en el Modelo
        /// </summary>
        /// <param name="o">Objeto del Tipo SubNivelesModel</param>
        /// <returns>Boleano</returns>
        public override bool ActualizarRegistro(object o)
        {
            if(o.GetType() == typeof(SubNivelesModel))// Verificar que el Objeto sea del Mismo tipo que el Modelo SubNivelesModel
            {
                var sn = (SubNivelesModel)o;// Castear la varibale "sn" al tipo SubNivelesModel

                if(Abrir())// Intentar Abrir la Conexión
                {
                    // Intento Exitoso

                    List<Parametros> lista = new List<Parametros>();// Lista de Parámetros
                    lista.Add(new Parametros(@"opc", "3"));// Indicarle la opción al Procedimiento
                    lista.Add(new Parametros(@"id", sn.Id.ToString()));// Identificador del Registro del Modelo
                    lista.Add(new Parametros(@"subnivel", sn.SubNivel));//Descripción del Registro del Modelo
                    lista.Add(new Parametros(@"img", Utilerias.ImageToBase64(sn.Foto,sn.Formato)));// Imagen del registro del Modelo

                    string proce = "sp_subniveles_crud";// Nobre del Procedimiento

                    if(EjecutarProcedimiento(proce,lista))// Ejecutar el Procedimiento
                    { return true; }// Ejeción Exitosa
                    else
                    { return false; }//Ejecución NO Exitosa, Cosnutlar Error
                }
                else// Intento Fallido
                { return false; }
            }
            else// No son del mismo tipo
            { return false; }
        }
        /// <summary>
        /// Función para la Selección de un sólo Registro del Modelo 
        /// </summary>
        /// <param name="o">Objeto del tipo SubNivelesModel</param>
        /// <returns>Boleano</returns>
        public override bool ConsultarRegistro(object o)
        {
            if (o.GetType() == typeof(SubNivelesModel))// Verificar que el Objeto sea del Mismo tipo que el Modelo SubNivelesModel
            {
                var sn = (SubNivelesModel)o;// Castear la varibale "sn" al tipo SubNivelesModel

                if (Abrir())// Intentar Abrir la Conexión
                {
                    // Intento Exitoso

                    List<Parametros> lista = new List<Parametros>();// Lista de Parámetros
                    lista.Add(new Parametros(@"opc", "4"));// Indicarle la opción al Procedimiento
                    lista.Add(new Parametros(@"id", sn.Id.ToString()));// Identificador del Registro del Modelo
                    lista.Add(new Parametros(@"subnivel", string.Empty));//Vacío
                    lista.Add(new Parametros(@"img", string.Empty));// Vacío

                    string proce = "sp_subniveles_crud";// Nobre del Procedimiento

                    if (ConsultarProcedimiento(proce, lista))// Consultar el Procedimiento
                    { return true; }// Consulta Exitosa
                    else
                    { return false; }//Consulta NO Exitosa, Cosnutlar Error
                }
                else// Intento Fallido
                { return false; }
            }
            else// No son del mismo tipo
            { return false; }
        }
        /// <summary>
        /// Función para la Consulta de todos los Registro del Modelo
        /// </summary>
        /// <returns>Boleano</returns>
        public override bool ConsultarRegistros()
        {
            if (Abrir())// Intentar Abrir la Conexión
            {
                // Intento Exitoso

                List<Parametros> lista = new List<Parametros>();// Lista de Parámetros
                lista.Add(new Parametros(@"opc", "1"));// Indicarle la opción al Procedimiento
                lista.Add(new Parametros(@"id", string.Empty));// Vacío
                lista.Add(new Parametros(@"subnivel", string.Empty));//Vacío
                lista.Add(new Parametros(@"img", string.Empty));// Vacío

                string proce = "sp_subniveles_crud";// Nobre del Procedimiento

                if (ConsultarProcedimiento(proce, lista))// Consultar el Procedimiento
                { return true; }// Consulta Exitosa
                else
                { return false; }//Consulta NO Exitosa, Cosnutlar Error
            }
            else// Intento Fallido
            { return false; }
        }
        /// <summary>
        /// Método para Ingresar Registro en el Modelo
        /// </summary>
        /// <param name="o">Objeto del Tipo SubNivelesModel</param>
        /// <returns>Boleano</returns>
        public override bool IngresarRegisto(object o)
        {
            if (o.GetType() == typeof(SubNivelesModel))// Verificar que el Objeto sea del Mismo tipo que el Modelo SubNivelesModel
            {
                var sn = (SubNivelesModel)o;// Castear la varibale "sn" al tipo SubNivelesModel

                if (Abrir())// Intentar Abrir la Conexión
                {
                    // Intento Exitoso

                    List<Parametros> lista = new List<Parametros>();// Lista de Parámetros
                    lista.Add(new Parametros(@"opc", "2"));// Indicarle la opción al Procedimiento
                    lista.Add(new Parametros(@"id", sn.Id.ToString()));// Identificador del Registro del Modelo
                    lista.Add(new Parametros(@"subnivel", sn.SubNivel));//Descripción del Registro del Modelo
                    lista.Add(new Parametros(@"img", Utilerias.ImageToBase64(sn.Foto,sn.Formato)));// Imagen del registro del Modelo

                    string proce = "sp_subniveles_crud";// Nobre del Procedimiento

                    if (EjecutarProcedimiento(proce, lista))// Ejecutar el Procedimiento
                    { return true; }// Ejeción Exitosa
                    else
                    { return false; }//Ejecución NO Exitosa, Cosnutlar Error
                }
                else// Intento Fallido
                { return false; }
            }
            else// No son del mismo tipo
            { return false; }
        }
    }
}
