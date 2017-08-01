using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SADI.Clases.Modelos;

namespace SADI.Clases.Controladores
{
    class AreasMedicasController : Metodos
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
        /// Función para la COnsulta de Areas Médicas por Departamento y SubFondo
        /// </summary>
        /// <param name="o">Objeto del Tipo AreasMedicasModel</param>
        /// <returns>Boleano</returns>
        public bool SeleccionarAreaMedicaXdepartamento(object o)
        {
            if(o.GetType() == typeof(AreasMedicasModel))//Verificar que Objeto sea del tipo AreasMedicasModel
            {
                //si es del mismo tipo
                var a = (AreasMedicasModel)o;//Castear la varibale "o" al tipo AreasMedicasModel

                string proce = "sp_areasmedicas_seleccion";//Nombre del procedimiento a ejecutar
                List<Parametros> lista = new List<Parametros>();
                lista.Add(new Parametros(@"opc", "1"));
                lista.Add(new Parametros(@"id", string.Empty));
                lista.Add(new Parametros(@"subfondo", a.SubFondo.Id.ToString()));
                lista.Add(new Parametros(@"departamento", a.DepartamentoId.Id.ToString()));
                lista.Add(new Parametros(@"areamedica", string.Empty));

                if(Abrir())//Intentar abrir la conexión
                {
                    //Intento Exitoso

                    try
                    {
                        if(ConsultarProcedimiento(proce,lista))//Intentar la Consulta
                        { return true; }//Intento Exitoso, ver Tabla
                        else//Intento NO Exitoso, ver Error
                        { return false; }
                    }
                    catch(Exception e)//Atrapar el Error
                    {
                        Error = e.Message.ToString();//Guardar el Error
                        return false;
                    }
                    finally { Cerrar(); }//Cerrar la Conexión
                }
                else//Intento NO Exitoso, Ver Error
                {
                    return false;
                }
            }
            else//No son del mismo tipo
            {
                Error = "el objeto no es del tipo areasmedicasmodel.";//Guardar el Error
                return false;//Indicar que Existe Error
            }
        }

        #endregion
    }
}
