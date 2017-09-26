﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SADI.Clases;
using SADI.Clases.EventsArgs;
using SADI.Clases.Controladores;
using SADI.Clases.Modelos;

namespace SADI.Vistas.SerieDocumental
{
    public partial class SerieDocumentalAdd : Form
    {
        #region Propiedades
        UsuariosModel um = new UsuariosModel();//Instancia de UsuariosModel
        AtributosModel am = new AtributosModel();//Instancia de AtributosModel
        AtributosController ac = new AtributosController();//Instancia de AtribitosController
        SeccionesController secc = new SeccionesController();//Controlador de las Secciones
        SeriesController serc = new SeriesController();//Controlador de las Series
        SeriesModel serm = new SeriesModel();//Modelo de la Serie
        TemasController tc = new TemasController();//Controlador del Tema
        TemasModel tm = new TemasModel();//Modelo de Temas
        RegistrosModel rm = new RegistrosModel();//Intencia del Modelo Registros
        RegistrosController rc = new RegistrosController();//Instancia del Controlador Registros
        ClasificacionesController cc = new ClasificacionesController();//Controlador de las Clasificaciones
        ValoresDoctalesController vdc = new ValoresDoctalesController();//Controlador de las Valoraciones Documentales

        #endregion


        /// <summary>
        /// Constructor de la Forma
        /// </summary>
        public SerieDocumentalAdd()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor de la Forma
        /// </summary>
        /// <param name="u">Objeto del tipo UsuariosModel</param>
        public SerieDocumentalAdd(UsuariosModel u)
        {
            InitializeComponent();
            am.Usuario = u;
            LLenarClasificaciones();
            LLenarValoracionesDoctales();
            LLenarSeccionesUsuario();
            SerieControlEventArgs ev = new SerieControlEventArgs { Opcion = 1 };
            ctrlSerieDocumental.SerieDocumental_Load(u,ev);
            //LLenarControl();
            ctrlSerieDocumental.cboSeccionCambioValor += new EventHandler(ctrlSerieDocumental_cboSeccionCambioValor);
            ctrlSerieDocumental.cboSerieCambioValor += new EventHandler(ctrlSerieDocumental_cboSerieCambioValor);
            ctrlSerieDocumental.CargaDeControl += new EventHandler(ctrlSerieDocumentl_CargaControl);
            LLenarControl();
        }

        private void ctrlSerieDocumentl_CargaControl(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ctrlSerieDocumental_cboSerieCambioValor(object sender, EventArgs e)
        {
            am.Serie.Id = ctrlSerieDocumental.Serie.Id;
            if(tc.ConsultarTemaXUsuarioSerieSeccion(am))
            {
                if(tc.Tabla.Rows.Count > 0)
                {
                    ctrlSerieDocumental.TemasT = tc.Tabla;
                }
                else
                {
                    MessageBox.Show("NO Temas Allowed");
                }
            }
        }

        private void ctrlSerieDocumental_cboSeccionCambioValor(object sender, EventArgs e)
        {
            am.Seccion.Id = ctrlSerieDocumental.Seccion.Id;
            if(serc.ConsultarSeriexSeccionUsuario(am))
            {
                if(serc.Tabla.Rows.Count > 0)
                {
                    ctrlSerieDocumental.SeriesT = serc.Tabla;
                }
                else
                {
                    MessageBox.Show("NO Hay Registro.");
                }
            }
        }

        /// <summary>
        /// Método para el LLenado Inicial del COntrol Serie Documental
        /// </summary>
        private void LLenarControl()
        {
            
            ///
            if(!string.IsNullOrEmpty(ctrlSerieDocumental.Seccion.Id))
            {
                am.Seccion.Id = ctrlSerieDocumental.Seccion.Id;
                if(serc.ConsultarSeriexSeccionUsuario(am))
                {
                    if(serc.Tabla.Rows.Count > 0)
                    {
                        ctrlSerieDocumental.SeriesT = serc.Tabla;
                    }
                    else
                    {
                        MessageBox.Show("Series VAcias");
                    }
                }
            }
           
           
        }
        /// <summary>
        /// Enviar La Tabla de Clasificaciones Documentales al Control
        /// </summary>
        private void LLenarClasificaciones()
        {
            if (cc.ConsultarRegistros())
            {
                if (cc.Tabla.Rows.Count > 0)
                {
                    ctrlSerieDocumental.ClasificacionesT = cc.Tabla;
                }
                else
                {
                    MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + cc.Error.ToUpper(),
                        ":: mensaje desde ingresar serie documental ::".ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// Enviar la Tabla de Voloración Documental al Control
        /// </summary>
        private void LLenarValoracionesDoctales()
        {
            if (vdc.ConsultarRegistros())
            {
                if (vdc.Tabla.Rows.Count > 0)
                {
                    ctrlSerieDocumental.ValoracionesDocaltesT = vdc.Tabla;
                }
                else
                {
                    MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + vdc.Error.ToUpper(),
                        ":: mensaje desde ingresar serie documental ::".ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        /// <summary>
        /// LLenar las Secciones Asignadas al Usuario
        /// </summary>
        private void LLenarSeccionesUsuario()
        {
            if (secc.ConsultarSeccionesXusuario(am))
            {
                if (secc.Tabla.Rows.Count > 0)
                {
                    ctrlSerieDocumental.SeccionesT = secc.Tabla;
                }
                else
                {
                    MessageBox.Show("no existen registros para la búsqueda de series.".ToUpper(), ":: mesnaje desde la consulta de serie ::".ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + secc.Error,
                    ":: mensae desde la consulta de la serie ::".ToUpper(),
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void cmdOUT_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
