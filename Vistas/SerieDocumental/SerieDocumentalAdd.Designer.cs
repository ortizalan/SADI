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
            SADI.Clases.Modelos.SeccionesModel seccionesModel1 = new SADI.Clases.Modelos.SeccionesModel();
            SADI.Clases.Modelos.SeriesModel seriesModel1 = new SADI.Clases.Modelos.SeriesModel();
            SADI.Clases.Modelos.SeccionesModel seccionesModel2 = new SADI.Clases.Modelos.SeccionesModel();
            SADI.Clases.Modelos.TemasModel temasModel1 = new SADI.Clases.Modelos.TemasModel();
            SADI.Clases.Modelos.SeccionesModel seccionesModel3 = new SADI.Clases.Modelos.SeccionesModel();
            SADI.Clases.Modelos.SeriesModel seriesModel2 = new SADI.Clases.Modelos.SeriesModel();
            SADI.Clases.Modelos.SeccionesModel seccionesModel4 = new SADI.Clases.Modelos.SeccionesModel();
            SADI.Clases.Modelos.ValoresDoctalesModel valoresDoctalesModel1 = new SADI.Clases.Modelos.ValoresDoctalesModel();
            this.cmdOUT = new System.Windows.Forms.Button();
            this.ctrlSerieDocumental = new SADI.UserControls.SerieDocumental();
            this.SuspendLayout();
            // 
            // cmdOUT
            // 
            this.cmdOUT.Location = new System.Drawing.Point(770, 509);
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
            this.ctrlSerieDocumental.Estatus = false;
            this.ctrlSerieDocumental.FechaCierreSerie = new System.DateTime(((long)(0)));
            this.ctrlSerieDocumental.FechaSerie = new System.DateTime(((long)(0)));
            this.ctrlSerieDocumental.InfoAdicional = null;
            this.ctrlSerieDocumental.Location = new System.Drawing.Point(8, 5);
            this.ctrlSerieDocumental.Name = "ctrlSerieDocumental";
            this.ctrlSerieDocumental.NombreExpediente = null;
            this.ctrlSerieDocumental.NumeroSerieDocumental = null;
            seccionesModel1.Id = null;
            seccionesModel1.Seccion = null;
            this.ctrlSerieDocumental.Seccion = seccionesModel1;
            seriesModel1.Id = 0;
            seriesModel1.IdSerie = 0;
            seccionesModel2.Id = null;
            seccionesModel2.Seccion = null;
            seriesModel1.Seccion = seccionesModel2;
            seriesModel1.Serie = null;
            this.ctrlSerieDocumental.Serie = seriesModel1;
            this.ctrlSerieDocumental.Size = new System.Drawing.Size(890, 508);
            this.ctrlSerieDocumental.TabIndex = 12;
            temasModel1.Id = 0;
            seccionesModel3.Id = null;
            seccionesModel3.Seccion = null;
            temasModel1.Seccion = seccionesModel3;
            seriesModel2.Id = 0;
            seriesModel2.IdSerie = 0;
            seccionesModel4.Id = null;
            seccionesModel4.Seccion = null;
            seriesModel2.Seccion = seccionesModel4;
            seriesModel2.Serie = null;
            temasModel1.Serie = seriesModel2;
            temasModel1.Tema = null;
            this.ctrlSerieDocumental.Tema = temasModel1;
            valoresDoctalesModel1.Id = 0;
            valoresDoctalesModel1.Valor = null;
            this.ctrlSerieDocumental.ValorDoctal = valoresDoctalesModel1;
            // 
            // SerieDocumentalAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 562);
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
    }
}