using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SADI.Clases.Modelos;
using SADI.Clases.Controladores;

namespace SADI.Vistas.SerieDocumental
{
    public partial class SerieDocumentalView : Form
    {
        UsuariosModel um = new UsuariosModel();//Objeto del Modelo de Usuarios

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        public SerieDocumentalView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor de la Clase
        /// </summary>
        /// <param name="u">Objeto del Tipo UsuarioModel</param>
        public SerieDocumentalView(UsuariosModel u)
        {
            InitializeComponent();
            um = u;
        }


    }
}

