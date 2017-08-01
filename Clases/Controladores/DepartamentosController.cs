using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SADI.Clases.Modelos;

namespace SADI.Clases.Controladores
{
    class DepartamentosController : Metodos
    {
        /// <summary>
        /// Función para la Actualización de Registro de Departamentos
        /// </summary>
        /// <param name="o">Objeto del Tipo DepartamentosModel</param>
        /// <returns>Boleano</returns>
        public override bool ActualizarRegistro(object o)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Función para la Consulta de los Registro Específico 
        /// </summary>
        /// <param name="o">Objeto del Tipo Departamentos Model</param>
        /// <returns></returns>
        public override bool ConsultarRegistro(object o)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Consultar Todos los Registros Existentes de DepartamentosModel
        /// </summary>
        /// <returns>Boleano</returns>
        public override bool ConsultarRegistros()
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// Función para la Insersión de registro en el Modelo
        /// </summary>
        /// <param name="o">Objeto del Tipo DepartamentosModel</param>
        /// <returns>Boleano</returns>
        public override bool IngresarRegisto(object o)
        {
            throw new NotImplementedException();
        }

        #region Funciones Propias del Controlador

        /// <summary>
        /// 
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public bool SeleccionarDepartamentoXsubFondo(object o)
        {
            if(o.GetType() == typeof(DepartamentosModel))//Verificar si el Objeto es del tipo DepartamentosModel
            {
                //SI son del mismo tipo
                var d = (DepartamentosModel)o;//Castear variable "d" al tipo DepartmanetosModel

                string proce = "sp_departamentos_seleccion";//Nombre del Procedimiento a ejecutar
                List<Parametros> lista = new List<Parametros>();//Lista de Parámetros
                lista.Add(new Parametros(@"opc", "1"));//Seleccionar Departamentos por Subfondo
                lista.Add(new Parametros(@"id", string.Empty));//Vacío
                lista.Add(new Parametros(@"subfondo", d.SubFondo.Id.ToString()));//Identificador del SubFondo
                lista.Add(new Parametros(@"departamento", string.Empty));//Vacío

                if(Abrir())//Intentar Abrir la Conexión
                {
                    //Intento Exitoso
                    try
                    {
                        if(ConsultarProcedimiento(proce,lista))//Intentar la Consulta
                        { return true; }//Intento Exitoso
                        else//Intento NO Exitoso, ver Error
                        { return false; }
                    }
                    catch(Exception e)//Atrapar el Error
                    {
                        Error = e.Message.ToString();//Guardar el Error
                        return false;//Indicar que existe el error
                    }
                    finally { Cerrar(); }
                }
                else//Intento NO Exitoso, Ver Error
                {
                    return false;
                }
            }
            else//NO son del mismo tipo
            {
                Error = "el objeto no es del tipo departamentosmodel.";//enviar el error
                return false;//Indicar que existe el error
            }
        }

        #endregion
    }
}
