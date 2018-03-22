using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SADI.Clases.Modelos;

namespace SADI.Clases.Controladores
{
    class SubAreasController : Metodos
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override bool ActualizarRegistro(object o)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override bool ConsultarRegistro(object o)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override bool ConsultarRegistros()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override bool IngresarRegisto(object o)
        {
            throw new NotImplementedException();
        }

        #region Funciones Propias del Controlador

        /// <summary>
        /// Función para Seleccionar Registros por SubFondo, Departamento y Area
        /// </summary>
        /// <param name="o">Objeto del Tipo SubAreasModel</param>
        /// <returns>Boleano</returns>
        public bool SeleccionarSubAreaXSubFondoAreaDepartamentoArea(object o)
        {
            if(o.GetType() == typeof(SubAreasModel))//Verificar que el Objeto sea del Tipo SubAreasModel
            {
                //SI es del mismo tipo
                var sa = (SubAreasModel)o;//Castear la variable "sa" al tipo SubAreasModel

                string proce = "sp_subareas_seleccion";//Nombre del Procedimiento
                List<Parametros> lista = new List<Parametros>();//Lista de Parámetros
                lista.Add(new Parametros(@"opc","1"));//OPción a ejecutar en el Procedimiento
                lista.Add(new Parametros(@"id", string.Empty));//Vacío
                lista.Add(new Parametros(@"subfondo", sa.SUBFondo.Id.ToString()));//Identificador del Subfondo
                lista.Add(new Parametros(@"area", sa.AreaId.Id.ToString()));//Identificador de la Area Médica
                lista.Add(new Parametros(@"subarea", string.Empty));//Vacío

                if (Abrir())//Intentar Abrir la Conexión
                {
                    //Intento Exitoso
                    try
                    {
                        if(ConsultarProcedimiento(proce,lista))//Intentar COnsultar el Procedimiento
                        { return true; }//Intento Exitoso
                        else//Intento NO Exitoso, Consultar Error
                        { return false; }
                    }
                    catch(Exception e)//Atrapar el Error
                    {
                        Error = e.Message.ToString();//Guardar el Error
                        return false;//Indicar que Existe Error
                    }
                    finally { Cerrar(); }//Cerrar la Conexión
                }
                else//Intento NO Exitoso, Consultar Error
                {
                    return false;
                }

            }
            else//NO es del mismo tipo
            {
                Error = "el objeto no es del mismo tipo que subareasmodel.";//Guardar el Error
                return false;//Indicar que existe error
            }
        }

        #endregion
    }
}
