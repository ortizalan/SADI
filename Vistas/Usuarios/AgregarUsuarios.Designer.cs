namespace SADI.Vistas.Usuarios
{
    partial class AgregarUsuarios
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
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.usrCtrl = new SADI.UserControls.UsuariosControl();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblSubFondo = new System.Windows.Forms.Label();
            this.lblDepartamento = new System.Windows.Forms.Label();
            this.lblAreaMedica = new System.Windows.Forms.Label();
            this.lblSubArea = new System.Windows.Forms.Label();
            this.lblServicio = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAgregar.Location = new System.Drawing.Point(675, 284);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(125, 57);
            this.btnAgregar.TabIndex = 3;
            this.btnAgregar.Text = ":: AGREGAR ::";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(800, 284);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(125, 57);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = ":: SALIR ::";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // usrCtrl
            // 
            this.usrCtrl.Contraseña = null;
            this.usrCtrl.Email = null;
            this.usrCtrl.Estatus = false;
            this.usrCtrl.IdAreaMedica = 0;
            this.usrCtrl.IdDepartamento = 0;
            this.usrCtrl.IdJerarquia = 0;
            this.usrCtrl.IdServicios = 0;
            this.usrCtrl.IdSubAreaMedica = 0;
            this.usrCtrl.IdSubFondo = 0;
            this.usrCtrl.Location = new System.Drawing.Point(6, 4);
            this.usrCtrl.Materno = null;
            this.usrCtrl.Name = "usrCtrl";
            this.usrCtrl.Nombre = null;
            this.usrCtrl.Opcion = 0;
            this.usrCtrl.Paterno = null;
            this.usrCtrl.Size = new System.Drawing.Size(746, 344);
            this.usrCtrl.TabIndex = 4;
            this.usrCtrl.Usuario = null;
            this.usrCtrl.cboSubFondosChange += new System.EventHandler(this.usrCtrl_cboSubFondosChange);
            this.usrCtrl.cboDepartamentosChange += new System.EventHandler(this.usrCtrl_cboDepartamentosChange);
            this.usrCtrl.cboAreasMedicasChange += new System.EventHandler(this.usrCtrl_cboAreasMedicasChange);
            this.usrCtrl.cboSubAreasChange += new System.EventHandler(this.usrCtrl_cboSubAreasChange);
            this.usrCtrl.cboServiciosChange += new System.EventHandler(this.usrCtrl_cboServiciosChange);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(759, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "SUBFONDO:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(759, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "DEPARTAMENTO:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(759, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "AREA MEDICA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(758, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "SUBAREA MEDICA";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(758, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "SERVICIO";
            // 
            // lblSubFondo
            // 
            this.lblSubFondo.AutoSize = true;
            this.lblSubFondo.Location = new System.Drawing.Point(886, 42);
            this.lblSubFondo.Name = "lblSubFondo";
            this.lblSubFondo.Size = new System.Drawing.Size(13, 13);
            this.lblSubFondo.TabIndex = 10;
            this.lblSubFondo.Text = "::";
            // 
            // lblDepartamento
            // 
            this.lblDepartamento.AutoSize = true;
            this.lblDepartamento.Location = new System.Drawing.Point(886, 68);
            this.lblDepartamento.Name = "lblDepartamento";
            this.lblDepartamento.Size = new System.Drawing.Size(13, 13);
            this.lblDepartamento.TabIndex = 11;
            this.lblDepartamento.Text = "::";
            // 
            // lblAreaMedica
            // 
            this.lblAreaMedica.AutoSize = true;
            this.lblAreaMedica.Location = new System.Drawing.Point(886, 94);
            this.lblAreaMedica.Name = "lblAreaMedica";
            this.lblAreaMedica.Size = new System.Drawing.Size(13, 13);
            this.lblAreaMedica.TabIndex = 12;
            this.lblAreaMedica.Text = "::";
            // 
            // lblSubArea
            // 
            this.lblSubArea.AutoSize = true;
            this.lblSubArea.Location = new System.Drawing.Point(886, 120);
            this.lblSubArea.Name = "lblSubArea";
            this.lblSubArea.Size = new System.Drawing.Size(13, 13);
            this.lblSubArea.TabIndex = 13;
            this.lblSubArea.Text = "::";
            // 
            // lblServicio
            // 
            this.lblServicio.AutoSize = true;
            this.lblServicio.Location = new System.Drawing.Point(886, 146);
            this.lblServicio.Name = "lblServicio";
            this.lblServicio.Size = new System.Drawing.Size(13, 13);
            this.lblServicio.TabIndex = 14;
            this.lblServicio.Text = "::";
            // 
            // AgregarUsuarios
            // 
            this.AcceptButton = this.btnAgregar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAgregar;
            this.ClientSize = new System.Drawing.Size(938, 353);
            this.ControlBox = false;
            this.Controls.Add(this.lblServicio);
            this.Controls.Add(this.lblSubArea);
            this.Controls.Add(this.lblAreaMedica);
            this.Controls.Add(this.lblDepartamento);
            this.Controls.Add(this.lblSubFondo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.usrCtrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarUsuarios";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "Agregar Usuarios";
            this.Load += new System.EventHandler(this.AgregarUsuarios_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnSalir;
        private UserControls.UsuariosControl usrCtrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblSubFondo;
        private System.Windows.Forms.Label lblDepartamento;
        private System.Windows.Forms.Label lblAreaMedica;
        private System.Windows.Forms.Label lblSubArea;
        private System.Windows.Forms.Label lblServicio;
    }
}