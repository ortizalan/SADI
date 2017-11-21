namespace SADI.Vistas.SerieDocumental
{
    partial class SerieDocumentalAdd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            SADI.Clases.Modelos.ClasificacionesModel clasificacionesModel1 = new SADI.Clases.Modelos.ClasificacionesModel();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SerieDocumentalAdd));
            SADI.Clases.Modelos.DigitalizacionesModel digitalizacionesModel1 = new SADI.Clases.Modelos.DigitalizacionesModel();
            SADI.Clases.Modelos.RegistrosModel registrosModel1 = new SADI.Clases.Modelos.RegistrosModel();
            SADI.Clases.Modelos.ClasificacionesModel clasificacionesModel2 = new SADI.Clases.Modelos.ClasificacionesModel();
            SADI.Clases.Modelos.FondosModel fondosModel1 = new SADI.Clases.Modelos.FondosModel();
            SADI.Clases.Modelos.SubFondosModel subFondosModel1 = new SADI.Clases.Modelos.SubFondosModel();
            SADI.Clases.Modelos.TemasModel temasModel1 = new SADI.Clases.Modelos.TemasModel();
            SADI.Clases.Modelos.SeccionesModel seccionesModel1 = new SADI.Clases.Modelos.SeccionesModel();
            SADI.Clases.Modelos.SeriesModel seriesModel1 = new SADI.Clases.Modelos.SeriesModel();
            SADI.Clases.Modelos.SeccionesModel seccionesModel2 = new SADI.Clases.Modelos.SeccionesModel();
            SADI.Clases.Modelos.ValoresDoctalesModel valoresDoctalesModel1 = new SADI.Clases.Modelos.ValoresDoctalesModel();
            SADI.Clases.Modelos.SeccionesModel seccionesModel3 = new SADI.Clases.Modelos.SeccionesModel();
            SADI.Clases.Modelos.SeriesModel seriesModel2 = new SADI.Clases.Modelos.SeriesModel();
            SADI.Clases.Modelos.SeccionesModel seccionesModel4 = new SADI.Clases.Modelos.SeccionesModel();
            SADI.Clases.Modelos.TemasModel temasModel2 = new SADI.Clases.Modelos.TemasModel();
            SADI.Clases.Modelos.SeccionesModel seccionesModel5 = new SADI.Clases.Modelos.SeccionesModel();
            SADI.Clases.Modelos.SeriesModel seriesModel3 = new SADI.Clases.Modelos.SeriesModel();
            SADI.Clases.Modelos.SeccionesModel seccionesModel6 = new SADI.Clases.Modelos.SeccionesModel();
            SADI.Clases.Modelos.ValoresDoctalesModel valoresDoctalesModel2 = new SADI.Clases.Modelos.ValoresDoctalesModel();
            this.cmdOUT = new System.Windows.Forms.Button();
            this.ctrlSerieDocumental = new SADI.UserControls.SerieDocumental();
            this.cmdIN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdOUT
            // 
            this.cmdOUT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOUT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdOUT.Location = new System.Drawing.Point(770, 545);
            this.cmdOUT.Name = "cmdOUT";
            this.cmdOUT.Size = new System.Drawing.Size(122, 42);
            this.cmdOUT.TabIndex = 11;
            this.cmdOUT.Text = ":: SALIR ::";
            this.cmdOUT.UseVisualStyleBackColor = true;
            this.cmdOUT.Click += new System.EventHandler(this.cmdOUT_Click);
            // 
            // ctrlSerieDocumental
            // 
            clasificacionesModel1.Clasificacion = null;
            clasificacionesModel1.Id = 0;
            this.ctrlSerieDocumental.Clasificacion = clasificacionesModel1;
            this.ctrlSerieDocumental.ClaveSEVI = null;
            this.ctrlSerieDocumental.CtaSevi = false;
            this.ctrlSerieDocumental.Descripcion = null;
            digitalizacionesModel1.Documento = null;
            digitalizacionesModel1.Extension = null;
            digitalizacionesModel1.Folio = 0;
            digitalizacionesModel1.Id = 0;
            digitalizacionesModel1.NombreDoc = null;
            clasificacionesModel2.Clasificacion = null;
            clasificacionesModel2.Id = 0;
            registrosModel1.Clasificacion = clasificacionesModel2;
            registrosModel1.CveSevi = null;
            registrosModel1.Descripcion = null;
            registrosModel1.Estatus = false;
            registrosModel1.FechaCierre = null;
            registrosModel1.FechaInicio = new System.DateTime(((long)(0)));
            fondosModel1.Fondo = null;
            fondosModel1.Id = 0;
            registrosModel1.Fondo = fondosModel1;
            registrosModel1.NumHojas = 0;
            registrosModel1.OtraInfo = null;
            registrosModel1.SerieDoctal = null;
            subFondosModel1.Fondo = null;
            subFondosModel1.Id = 0;
            subFondosModel1.SubFondo = null;
            registrosModel1.SubFondo = subFondosModel1;
            temasModel1.Id = 0;
            seccionesModel1.Id = null;
            seccionesModel1.Seccion = null;
            temasModel1.Seccion = seccionesModel1;
            seriesModel1.Id = 0;
            seriesModel1.IdSerie = 0;
            seccionesModel2.Id = null;
            seccionesModel2.Seccion = null;
            seriesModel1.Seccion = seccionesModel2;
            seriesModel1.Serie = null;
            temasModel1.Serie = seriesModel1;
            temasModel1.Tema = null;
            registrosModel1.Tema = temasModel1;
            valoresDoctalesModel1.Id = 0;
            valoresDoctalesModel1.Valor = null;
            registrosModel1.ValorDoctal = valoresDoctalesModel1;
            digitalizacionesModel1.SDoctal = registrosModel1;
            digitalizacionesModel1.Tamaño = 0;
            this.ctrlSerieDocumental.Digitalizacion = digitalizacionesModel1;
            this.ctrlSerieDocumental.Digitalizado = false;
            this.ctrlSerieDocumental.Documento = null;
            this.ctrlSerieDocumental.Estatus = false;
            this.ctrlSerieDocumental.Extension = null;
            this.ctrlSerieDocumental.FechaCierreSerie = new System.DateTime(((long)(0)));
            this.ctrlSerieDocumental.FechaSerie = new System.DateTime(((long)(0)));
            this.ctrlSerieDocumental.Location = new System.Drawing.Point(2, 3);
            this.ctrlSerieDocumental.Name = "ctrlSerieDocumental";
            this.ctrlSerieDocumental.NombreExpediente = null;
            this.ctrlSerieDocumental.NumeroSerieDocumental = null;
            seccionesModel3.Id = null;
            seccionesModel3.Seccion = null;
            this.ctrlSerieDocumental.Seccion = seccionesModel3;
            seriesModel2.Id = 0;
            seriesModel2.IdSerie = 0;
            seccionesModel4.Id = null;
            seccionesModel4.Seccion = null;
            seriesModel2.Seccion = seccionesModel4;
            seriesModel2.Serie = null;
            this.ctrlSerieDocumental.Serie = seriesModel2;
            this.ctrlSerieDocumental.Size = new System.Drawing.Size(890, 536);
            this.ctrlSerieDocumental.TabIndex = 12;
            temasModel2.Id = 0;
            seccionesModel5.Id = null;
            seccionesModel5.Seccion = null;
            temasModel2.Seccion = seccionesModel5;
            seriesModel3.Id = 0;
            seriesModel3.IdSerie = 0;
            seccionesModel6.Id = null;
            seccionesModel6.Seccion = null;
            seriesModel3.Seccion = seccionesModel6;
            seriesModel3.Serie = null;
            temasModel2.Serie = seriesModel3;
            temasModel2.Tema = null;
            this.ctrlSerieDocumental.Tema = temasModel2;
            valoresDoctalesModel2.Id = 0;
            valoresDoctalesModel2.Valor = null;
            this.ctrlSerieDocumental.ValorDoctal = valoresDoctalesModel2;
            // 
            // cmdIN
            // 
            this.cmdIN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmdIN.Location = new System.Drawing.Point(628, 545);
            this.cmdIN.Name = "cmdIN";
            this.cmdIN.Size = new System.Drawing.Size(136, 42);
            this.cmdIN.TabIndex = 13;
            this.cmdIN.Text = ":: INGRESAR ::";
            this.cmdIN.UseVisualStyleBackColor = true;
            this.cmdIN.Click += new System.EventHandler(this.cmdIN_Click);
            // 
            // SerieDocumentalAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 596);
            this.Controls.Add(this.cmdIN);
            this.Controls.Add(this.cmdOUT);
            this.Controls.Add(this.ctrlSerieDocumental);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SerieDocumentalAdd";
            this.Text = "SerieDocumentalAdd";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cmdOUT;
        private UserControls.SerieDocumental ctrlSerieDocumental;
        private System.Windows.Forms.Button cmdIN;
    }
}