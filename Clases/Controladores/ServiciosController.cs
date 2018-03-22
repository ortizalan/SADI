using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SADI.Clases.Modelos;

namespace SADI.Clases.Controladores
{
    class ServiciosController : Metodos
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
        /// Función para la selección de los Servicios por SubFondo, Departamento,Área Médica y Sub Área Médica
        /// </summary>
        /// <param name="o">Objeto del Tipo ServiciosModel</param>
        /// <returns>Boleano</returns>
        public bool SeleccionarSeccionXSubFondoDeptoAreaSubArea(object o)
        {
            if(o.GetType() == typeof(ServiciosModel))//Verificar que el objeto sea del tipo servicios model
            {
                // Si son del mismo tipo
                var s = (ServiciosModel)o;//Castear la variable "o" al tipo ServiciosModel

                string proce = "sp_servicios_seleccion";//Nombre del procedimiento
                List<Parametros> lista = new List<Parametros>();//Lista de parámetros
                lista.Add(new Parametros(@"opc", "1"));//Opción a ejecutar dentro del procedimiento
                lista.Add(new Parametros(@"id", string.Empty));//Vacío
                lista.Add(new Parametros(@"subfondo", s.SUBFondo.Id.ToString()));//Identificador del Subfondo
                lista.Add(new Parametros(@"area", s.AreaId.Id.ToString()));//Identificador del ÁreaMédica
                lista.Add(new Parametros(@"subarea", s.SubAreaId.Id.ToString()));//Identificador de la Sub Area
                lista.Add(new Parametros(@"servicio", string.Empty));//Vacío

                if(Abrir())//Intentar Abrir la Conexión
                {
                    //Intento Existoso
                    try
                    {
                        if(ConsultarProcedimiento(proce, lista))//Intentar ejecutar el Procedimiento
                        { return true; }//Intento Exitoso,Consultar Tabla
                        else//Intento NO exitoso, Consultar Error
                        { return false; }
                    }
                    catch(Exception e)//Atrapar el Error
                    {
                        Error = e.Message.ToString();//Guardar el Error
                        return false;//Indicar que existe el Error
                    }
                    finally { Cerrar(); }//Cerrar la conexión
                }
                else//Intento NO Exitoso, Consultar Error
                { return false; }
            }
            else//No Son del Mismo Tipo
            {
                Error = "el objeto no es del tipo serviciosmodel.";
                return false;
            }
        }

        #endregion

    }
}
