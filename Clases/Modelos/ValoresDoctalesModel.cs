///////////////////////////////////////////////////////////
//  ValoresDoctalesModel.cs
//  Implementation of the Class ValoresDoctalesModel
//  Generated by Enterprise Architect
//  Created on:      10-mar.-2017 13:19:13
//  Original author: Ing. Alan Adalberto Ortiz P�rez
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



namespace SiCGA.Clases.Modelos {
	/// <summary>
	/// Modelo de la Tabla ValoresDoctales
	/// </summary>
	public class ValoresDoctalesModel {

		/// <summary>
		/// Propiedad de Identificaci�n de Valor Documental
		/// </summary>
		private int _id;
		/// <summary>
		/// Propiedad que describe el Valor Documental
		/// </summary>
		private string _valor;

		public ValoresDoctalesModel(){

		}

		/// <summary>
		/// Constructor de la Clase que recibe dos par�metros
		/// </summary>
		/// <param name="id"></param>
		/// <param name="val"></param>
		public ValoresDoctalesModel(int id, string val){

            this.Id = id;
            this.Valor = val;
		}

		~ValoresDoctalesModel(){

		}

		/// <summary>
		/// Acceder a la Propiedad Id
		/// </summary>
		public int Id{

            get { return _id; }
            set { _id = value; }
		}

		/// <summary>
		/// Acceder a la Propiedad Valor
		/// </summary>
		public string Valor{

            get { return _valor; }
            set { _valor = value; }
		}

	}//end ValoresDoctalesModel

}//end namespace Modelos