///////////////////////////////////////////////////////////
//  DigitalizacionesModel.cs
//  Implementation of the Class DigitalizacionesModel
//  Generated by Enterprise Architect
//  Created on:      10-mar.-2017 13:18:33
//  Original author: Ing. Alan Adalberto Ortiz Pérez
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using SiCGA.Clases.Modelos;
namespace SiCGA.Clases.Modelos {
	/// <summary>
	/// Modelo de la Tabla Digitalizaciones
	/// </summary>
	public class DigitalizacionesModel {

		/// <summary>
		/// Propiedad que identifica el movimiento de digitalización
		/// </summary>
		private int _id;
		/// <summary>
		/// Propiedad que representa el código de la serie documental del documento
		/// </summary>
		private RegistrosModel _seriedoctal;
		/// <summary>
		/// Propiedad que representa al digitalización del documento
		/// </summary>
		private byte [] _documento;
		/// <summary>
		/// Propiedad que representa el folio del documento
		/// </summary>
		private int _folio;

        /// <summary>
        /// Constructo Vacio
        /// </summary>
		public DigitalizacionesModel(){

		}

		/// <summary>
		/// Constructor de la Clase
		/// </summary>
		/// <param name="id">Identificador del Modelo</param>
		/// <param name="seried">Serie Documental del Modelos</param>
		/// <param name="doc">Documeto</param>
		/// <param name="folio">Folio del Documento</param>
		public DigitalizacionesModel(int id, RegistrosModel seried, byte[] doc, int folio){
            this.Id = id;
            this.SerieDoctal = seried;
            this.Documento = doc;
            this.Folio = folio;
		}

		~DigitalizacionesModel(){

		}

		/// <summary>
		/// Acceder a la propiedad Id
		/// </summary>
		public int Id{
			get { return _id; }
            set { _id = value; }
		}

		/// <summary>
		/// Acceder a la Propiedad que aloja la serie documental
		/// </summary>a
		public RegistrosModel SDoctal{
            get { return _seriedoctal; }
            set { _seriedoctal = value; }
		}

		/// <summary>
		/// Acceder a la Propiedad del Documento digitalizado
		/// </summary>
		public byte[] Documento{
            get { return _documento; }
            set { _documento = value; }
		}

		/// <summary>
		/// Acceder a la propiedad del Folio del Documento
		/// </summary>
		public int Folio{
            get { return _folio; }
            set { _folio = value; }
		}

	}//end DigitalizacionesModel

}//end namespace Modelos