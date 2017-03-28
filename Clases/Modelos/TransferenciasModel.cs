///////////////////////////////////////////////////////////
//  TransferenciasModel.cs
//  Implementation of the Class TransferenciasModel
//  Generated by Enterprise Architect
//  Created on:      10-mar.-2017 13:19:03
//  Original author: Ing. Alan Adalberto Ortiz P�rez
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace SADI.Clases.Modelos {
	/// <summary>
	/// Modelo de la Tabla Transferencias
	/// </summary>
	public class TransferenciasModel {

		/// <summary>
		/// Propiedad ID de la Transferencia
		/// </summary>
		private int _id;
		/// <summary>
		/// Propiedad de la Descripci�n de la Transferencia
		/// </summary>
		private string _descripcion;
		/// <summary>
		/// Propiedad Fecha de la Transferencia
		/// </summary>
		private DateTime fecha;

		public TransferenciasModel(){

		}

		/// <summary>
		/// Constructor de la Clase con Par�metros
		/// </summary>
		/// <param name="id"></param>
		/// <param name="desc"></param>
		/// <param name="fec"></param>
		public TransferenciasModel(int id, string desc, DateTime fec){

		}

		~TransferenciasModel(){

		}

		/// <summary>
		/// Acceder a la Propiedad Id
		/// </summary>
		public int Id{
			get;
			set;
		}

		/// <summary>
		/// Acceder a la Propiedad Descripci�n
		/// </summary>
		public string Descripcion{
			get;
			set;
		}

		/// <summary>
		/// Acceder a la Propiedad Fecha
		/// </summary>
		public DateTime Fecha{
			get;
			set;
		}

	}//end TransferenciasModel

}//end namespace Modelos