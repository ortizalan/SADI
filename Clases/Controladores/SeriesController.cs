///////////////////////////////////////////////////////////
//  SeriesController.cs
//  Implementation of the Class SeriesController
//  Generated by Enterprise Architect
//  Created on:      10-mar.-2017 13:18:56
//  Original author: Ing. Alan Adalberto Ortiz P�rez
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using SADI.Clases;
namespace SADI.Clases.Controladores {
	/// <summary>
	/// Controlador para el Modelo Series
	/// </summary>
	public class SeriesController : Metodos {

		public SeriesController(){

		}

		~SeriesController(){

		}

		/// <summary>
		/// M�todo Para Actualizar los Registros
		/// </summary>
		/// <returns>Boleano</returns>
		/// <param name="o">Objeto del Tipo class</param>
		public override bool ActualizarRegistro(Object o){

			return false;
		}

		/// <summary>
		/// M�todo Para Consultar un Registro
		/// </summary>
		/// <returns>Boleano</returns>
		/// <param name="o">Objeto del Tipo class</param>
		public override bool ConsultarRegistro(Object o){

			return false;
		}

		/// <summary>
		/// M�todo para Consultar Todos los Registros
		/// </summary>
		/// <returns>Boleano</returns>
		public override bool ConsultarRegistros(){

			return false;
		}

		/// <summary>
		/// M�todo para Ingresar un Registro
		/// </summary>
		/// <returns>Boleano</returns>
		/// <param name="o">Objeto del Tipo Class</param>
		public override bool IngresarRegisto(Object o){

			return false;
		}

	}//end SeriesController

}//end namespace Controladores