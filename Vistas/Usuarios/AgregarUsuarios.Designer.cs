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
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAgregar.Location = new System.Drawing.Point(494, 284);
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
            this.btnSalir.Location = new System.Drawing.Point(619, 284);
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
            // AgregarUsuarios
            // 
            this.AcceptButton = this.btnAgregar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAgregar;
            this.ClientSize = new System.Drawing.Size(757, 353);
            this.ControlBox = false;
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

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnSalir;
        private UserControls.UsuariosControl usrCtrl;
    }
}