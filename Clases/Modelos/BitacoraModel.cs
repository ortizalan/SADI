///////////////////////////////////////////////////////////
//  BitacoraModel.cs
//  Implementation of the Class BitacoraModel
//  Generated by Enterprise Architect
//  Created on:      10-mar.-2017 13:18:29
//  Original author: Ing. Alan Adalberto Ortiz P�rez
///////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Text;
using System.IO;



using SADI.Clases.Modelos;
namespace SADI.Clases.Modelos {
	/// <summary>
	/// Modelo de la Tabla Bit�cora
	/// </summary>
	public class BitacoraModel {

		/// <summary>
		/// Propiedad Identificadora del registro en la Bit�cora
		/// </summary>
		private int _id;
		/// <summary>
		/// Propiedad de identificaci�n de la serie documental
		/// </summary>
		private RegistrosModel _seriedocal;
		/// <summary>
		/// Propiedad de la Fecha del Movimiento
		/// </summary>
		private DateTime _fecha;
		/// <summary>
		/// Propiedad de identificaci�n del movimiento realizado
		/// </summary>
		private MovimientosModel _movimiento;
		/// <summary>
		/// Propiedad del Usuario que realiz� el movieminto
		/// </summary>
		private UsuariosModel _usuario;
		/// <summary>
		/// Propiedad del Nombre de la Computadora desde d�nde se realiz� el movimiento
		/// </summary>
		private string _computadora;
		/// <summary>
		/// Propiedad de la IP o MAC Address desde d�nde se realiz� el movimiento
		/// </summary>
		private string _idcomputadora;
        /// <summary>
        /// Constructor de la clase
        /// </summary>
		public BitacoraModel(){

		}
        /// <summary>
        /// Destructor de la Clase
        /// </summary>
		~BitacoraModel(){

		}
        /// <summary>
        /// Constructor de la Clase que recibe par�metros
        /// </summary>
        /// <param name="id">Identificador del Modelo</param>
        /// <param name="seriedoc">Serie Documental del Modelo</param>
        /// <param name="fec">Fecha del Movimiento en el Modelo</param>
        /// <param name="mov">Movimiento en el Modelo</param>
        /// <param name="usr">Usuario que realiz� el Movimiento</param>
        /// <param name="comp">Computadora desde d�nde se realiz� el movimiento</param>
        /// <param name="idcomp">identificador de la computadora desde d�nde se realiz� el movimiento</param>
        public BitacoraModel(int id, RegistrosModel seriedoc, DateTime fec, MovimientosModel mov,
            UsuariosModel usr, string comp, string idcomp)
        {
            this.Id = id;
            this.SerieDoctal = seriedoc;
            this.Fecha = fec;
            this.Movimiento = mov;
            this.Usuario = usr;
            this.Computadora = comp;
            this.IdComputadora = idcomp;
        }

		/// <summary>
		/// Acceso a la Propiedad Identificaci�n del movimiento
		/// </summary>
		public int Id{
            get { return _id; }
            set { _id = value; }
		}
        /// <summary>
        /// Acceso a la Propiedad SerieDoctal
        /// </summary>
		public RegistrosModel SerieDoctal{
            get { return _seriedocal; }
            set { _seriedocal = value; }
		}

		/// <summary>
		/// Acceder a la Propiedad Fecha del Movimiento
		/// </summary>
		public DateTime Fecha{
            get { return _fecha; }
            set { _fecha = value; }
		}

		/// <summary>
		/// Acceso a la propiedad Moviemiento
		/// </summary>
		public MovimientosModel Movimiento{
            get { return _movimiento; }
            set { _movimiento = value; }
		}

		/// <summary>
		/// Acceso a la Propiedad Usuario
		/// </summary>
		public UsuariosModel Usuario{
            get { return _usuario; }
            set { _usuario = value; }
		}

		/// <summary>
		/// Acceso a la Propiedad Computadora
		/// </summary>
		public string Computadora{
            get { return _computadora; }
            set { _computadora = value; }
		}

		/// <summary>
		/// Acceso a la Propiedad de Identificaci�n de la Computadora
		/// </summary>
		public string IdComputadora{
            get { return _idcomputadora; }
            set { _idcomputadora = value; }
		}

	}//end BitacoraModel

}//end namespace Modelos