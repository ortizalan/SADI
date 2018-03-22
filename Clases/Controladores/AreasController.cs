using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SADI.Clases.Modelos;

namespace SADI.Clases.Controladores
{
    class AreasController : Metodos
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
            if(o.GetType() == typeof(AreasModel))//Verificar que Objeto sea del tipo AreasMedicasModel
            {
                //si es del mismo tipo
                var a = (AreasModel)o;//Castear la varibale "o" al tipo AreasMedicasModel

                string proce = "sp_areasmedicas_seleccion";//Nombre del procedimiento a ejecutar
                List<Parametros> lista = new List<Parametros>();
                lista.Add(new Parametros(@"opc", "1"));
                lista.Add(new Parametros(@"id", string.Empty));
                lista.Add(new Parametros(@"subfondo", a.SUBFondo.Id.ToString()));
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

        /// <summary>
        /// Función para la Consulta de las Áreas según Subfondo
        /// </summary>
        /// <param name="o">Objeto del tipo AreasModel</param>
        /// <returns>boolean</returns>
        public bool SeleccionarAreaXsubFondo(object o)
        {
            if(o.GetType() == typeof(AreasModel))//verificar que el Objeto sea del tipo AreasModel
            {
                //Si es del mismo tipo
                var a = (AreasModel)o;//Castear la variable al tipo AreasModel

                string proce = "sp_areas_seleccion";//Nombre del procedimiento a ejecutar
                List<Parametros> lista = new List<Parametros>();//Lista genérica de Parámetros
                lista.Add(new Parametros(@"opc", "1"));//Indicar la opción a ejecutar dentro del procedimiento
                lista.Add(new Parametros(@"id", string.Empty));//Parámetro vacío
                lista.Add(new Parametros(@"subfondo", a.SUBFondo.Id.ToString()));//Identificador del SubFondo
                lista.Add(new Parametros(@"area", string.Empty));//Parámetro Vacío

                try
                {
                    if(Abrir())//Intentar abrir la conexión
                    {
                        //Intento Exitoso
                        if(ConsultarProcedimiento(proce,lista))
                        { return true; }//Consulta Exitosa
                        else//Consulta NO Exitosa
                        { return false; }//Indicar que existe el Error
                    }
                    else//Intento NO exitoso
                    {
                        return false;//Indicar que existe Error
                    }
                }
                catch(Exception e)//Atrapar el error
                {
                    Error = e.Message.ToUpper();//Guardar el Error
                    return false;//Indicar que existe el error
                }
                finally { Cerrar(); }//Cerrar la conexión
            }
            else//No es del mismo tipo
            {
                Error = "el objeto no es del tripo del modelo del área".ToUpper();//Guardar el Error
                return false;//Indicar que existe un error
            }
        }

        #endregion
    }
}
