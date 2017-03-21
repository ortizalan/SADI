///////////////////////////////////////////////////////////
//  JerarquiasModel.cs
//  Implementation of the Class JerarquiasModel
//  Generated by Enterprise Architect
//  Created on:      10-mar.-2017 13:18:39
//  Original author: Ing. Alan Adalberto Ortiz P�rez
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace SiCGA.Clases.Modelos {
	/// <summary>
	/// Modelo de la Tabla Jerarqu�as
	/// </summary>
	public class JerarquiasModel {

		/// <summary>
		/// Identificador de la Jerarqu�a
		/// </summary>
		private int _id;
		/// <summary>
		/// Descripci�n de la Jerarqu�a
		/// </summary>
		private string _jerarquia;

		public JerarquiasModel(){

		}

		/// <summary>
		/// Constructor que recibe Par�metros
		/// </summary>
		/// <param name="id">Identificador</param>
		/// <param name="jerarquia">Descripcion de la Jerarqu�a</param>
		public JerarquiasModel(int id, string jerarquia){

		}

		~JerarquiasModel(){

		}

		/// <summary>
		/// Acceder a la Propiedad Id
		/// </summary>
		public int Id{
			get;
			set;
		}

		/// <summary>
		/// Acceder a la Propiedad Jerarquia
		/// </summary>
		public string Jerarquia{
			get;
			set;
		}

	}//end JerarquiasModel

}//end namespace Modelos