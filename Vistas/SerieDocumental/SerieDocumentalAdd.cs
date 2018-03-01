using System;
using System.IO;
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
        DigitalizacionesModel dm = new DigitalizacionesModel();// Modelo de las Digitalizaciones
        DigitalizacionesController dc = new DigitalizacionesController();//Controlador de las Digitalizaciones
        BitacoraController bc = new BitacoraController();//Controlador de la Bitácora
        BitacoraModel bm = new BitacoraModel();//Modelo de la Bitácora
        TextBox txtDesc = new TextBox();
        TextBox txtOtrai = new TextBox();
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
                        MessageBox.Show("Series Vacias");
                    }
                }
            }
        }
        /// <summary>
        /// Enviar La Tabla de Clasificaciones Documentales al Control
        /// </summary>
        private void LLenarClasificaciones()
        {
            if (cc.ConsultarRegistros())//Hacer la consulta de las Clasificaciones Doscumentales
            {
                if (cc.Tabla.Rows.Count > 0)//Si existen registros en la consulta
                {
                    ctrlSerieDocumental.ClasificacionesT = cc.Tabla;// LLenar Tabla de Clasificaciones del Control Serie Documental
                }
                else//Consulta NO Exitosa
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
        /// <summary>
        /// Método para Ingresar el Registro de la Serie Documental
        /// </summary>
        private void cmdIN_Click(object sender, EventArgs e)
        {
            if(ctrlSerieDocumental.ValidarCampos())//Validar los campos del Control de Usuario
            {
                txtDesc.Text = ctrlSerieDocumental.Descripcion;
                txtOtrai.Text = ctrlSerieDocumental.OtraInfo; 

                rm.SerieDoctal = ctrlSerieDocumental.NumeroSerieDocumental;//Ingresar la serie Documental
                if(ctrlSerieDocumental.AgregarTema)//Hay que ingresar el Tema del Expediente a la Base de Datos
                {
                    tm.Seccion.Id = ctrlSerieDocumental.Seccion.Id;//Identificador de la Sección
                    tm.Serie.Id = ctrlSerieDocumental.Serie.Id;//Identificador de la Serie
                    tm.Tema = ctrlSerieDocumental.NombreExpediente;//Descripción del Tema
                    

                    if (tc.IngresarRegisto(tm))//Intentar Ingresar el Tema
                    {
                        int lastReg;
                        if(tc.ConsultarUltimoRegistroIngresado())//Intentar Obtener el Último Registro Ingresado
                        {
                            lastReg = (int)tc.Tabla.Rows[0][0];//Identificador del Último Registro
                            rm.Tema.Id = lastReg;//Asignar último Registro al modelo Registros
                        }
                        else//Intento NO exitoso, Consultar Error
                        {
                            MessageBox.Show("ocurrió el siguiente error : " + "\n" + tc.Error.ToUpper(),
                                ":: mensaje desde ingresar serie documental-ingreso automático de atributo ::".ToUpper(),
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;//Salir 
                        }
                        am.Seccion.Id = tm.Seccion.Id;
                        am.Serie.Id = tm.Serie.Id;
                        am.Temas.Id = lastReg;
                        if(ac.IngresoAutomaticoAtributo(am))//Intentar Agregar el Atributo al Usuario
                        { }//Intento Exitoso
                        else//Intento no Exitoso, Salir
                        {
                            MessageBox.Show("ocurrió el siguiente error : " + "\n" + ac.Error.ToUpper(), 
                                ":: mensaje desde ingresar serie documental-ingreso automático de atributo ::".ToUpper(),
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;//Salir
                        }
                    }
                    else
                    {
                        MessageBox.Show("ocurrió el siguiente error : ".ToUpper() + "\n" +
                            tc.Error, ":: mensaje desde forma ingresar serie documental ::".ToUpper(),
                            MessageBoxButtons.OK,MessageBoxIcon.Error);
                        return;//Salir
                    }
                }
                else//No Seleccionaron Agregar Tema
                {
                    rm.Tema.Id = ctrlSerieDocumental.Tema.Id;
                }
                rm.Fondo.Id = ctrlSerieDocumental.Fondo;
                rm.SubFondo.Id = ctrlSerieDocumental.SubFondo;
                rm.FechaInicio = ctrlSerieDocumental.FechaSerie;
                rm.FechaInicio = ctrlSerieDocumental.FechaSerie;
                //rm.Descripcion = Utilerias.CadenaConSaltoLines(txtDesc);
                //rm.OtraInfo = Utilerias.CadenaConSaltoLines(txtOtrai);
                rm.Descripcion = ctrlSerieDocumental.Descripcion;
                rm.OtraInfo = (!string.IsNullOrEmpty(ctrlSerieDocumental.OtraInfo) ? ctrlSerieDocumental.OtraInfo:string.Empty);
                rm.NumHojas = 0;
                rm.CveSevi = (!string.IsNullOrEmpty(ctrlSerieDocumental.ClaveSEVI) ? ctrlSerieDocumental.ClaveSEVI : string.Empty );
                rm.ValorDoctal.Id = ctrlSerieDocumental.ValorDoctal.Id;
                rm.Clasificacion.Id = ctrlSerieDocumental.Clasificacion.Id;
                rm.Estatus = true;

                if(rc.IngresarRegisto(rm))//Intentar Ingresar el Registro
                {
                    //Intento Exitoso

                    //////////////////////////////////////////////
                    //// INGRESO A LA BITACORA DEL MOVIMIENTO ////
                    //////////////////////////////////////////////
                    #region Ingresar a la Bitacora

                    bm.Registro.SerieDoctal = rm.SerieDoctal;//Número de la serie documental
                    bm.Fecha = DateTime.Now;//Fecha del movimiento
                    bm.Movimiento.Id = 1;//Id del movimiento
                    bm.Usuario.Id = am.Usuario.Id;//Id del usuario
                    bm.Computadora = System.Net.Dns.GetHostName();//Nombre de la computadora
                    System.Net.IPAddress[] ipaddress = System.Net.Dns.GetHostAddresses(bm.Computadora);//IP de la computadora

                    foreach(System.Net.IPAddress ip in ipaddress)
                    {
                        if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                        {
                            bm.IdComputadora = ip.ToString();//Identificar si es es IP
                        }
                        if(ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                        {
                            bm.MacAddress = ip.ToString();//Identificar si es MacAddress
                        }
                    }

                    ///Ingresar a la Bitácora el Movimiento
                    if(bc.IngresarRegisto(bm))
                    {
                        //Intento Exitoso
                    }
                    else//Intento NO Exitoso, mostrar el Error
                    {
                        MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + bc.Error.ToUpper(),
                            "..:: mensaje desde ingresar serie documental/bitácora ::..".ToUpper(),
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        rc.EliminarRegistroFallido(rm);
                    }

                    #endregion

                    ///<summary>
                    /// Agregar Documentos Digitalizados
                    /// </summary>
                    if (ctrlSerieDocumental.Digitalizado)//Verificar si existen documentos digitalizados
                    {
                        int c = 0;
                        // Si existen documentos digitalizados
                        foreach (DataRow r in ctrlSerieDocumental.DTDigitalizados.Rows)
                        {
                            //Ingresasr uno por uno los documentos digitalizados
                            byte[] docu = (byte[])r["documento"];
                            dm.SDoctal.SerieDoctal = rm.SerieDoctal;
                            dm.Documento = docu;
                            dm.NombreDoc = r["nombredoc"].ToString();
                            dm.Extension = r["extension"].ToString();
                            dm.Tamaño = Convert.ToInt32(r["tamaño"]);
                            dm.Folio = Convert.ToInt32(r["folio"]);
                            if(dc.IngresarRegisto(dm))//Intentar Ingresar Registro
                            {
                                //Intento Exitoso
                                c += 1;
                            }
                            else
                            {
                                MessageBox.Show("ocurrió el siguente error : ".ToUpper() + "\n" + dc.Error.ToUpper(),
                                    ":: mensaje desde ingresar serie documental-ingresar archivos digitales ::".ToUpper(),
                                    MessageBoxButtons.OK,MessageBoxIcon.Error);
                                return;
                            }
                        }

                        DialogResult result =  MessageBox.Show("se ingresó la serie documental con exito,".ToUpper() + "\n" +
                            "la serie documental cuenta con ".ToUpper() + c.ToString() + "archivos digitalizados".ToUpper(),
                            ":: mensaje desde ingresar serie documental ::".ToUpper(),
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if(result == DialogResult.OK)//
                        { Close(); }//Cerar la ventana
                    }
                }
                else//Intento NO Exitoso
                {
                    MessageBox.Show("no se ingresó el registro, ocurrió el siguiente error : ".ToUpper() + "\n" + rc.Error.ToUpper(),
                        ":: mensaje desde agregar serie documental ::".ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;//Salir
                }

                ////////////////////////////////////////////
                ///////////// Limpiar Control///////////////
                ////////////////////////////////////////////


            }
            else//No paso Validación Control Serie Documental
            {

            }
        }
    }
}
