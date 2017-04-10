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
            this.usuariosControl1 = new SADI.UserControls.UsuariosControl();
            this.SuspendLayout();
            // 
            // btnAgregar
            // 
            this.btnAgregar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAgregar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAgregar.Location = new System.Drawing.Point(459, 268);
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
            this.btnSalir.Location = new System.Drawing.Point(584, 268);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(125, 57);
            this.btnSalir.TabIndex = 0;
            this.btnSalir.Text = ":: SALIR ::";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // usuariosControl1
            // 
            this.usuariosControl1.Constraseña = null;
            this.usuariosControl1.Email = null;
            this.usuariosControl1.Estatus = false;
            this.usuariosControl1.IdJerarquia = 0;
            this.usuariosControl1.IdSeccion = null;
            this.usuariosControl1.IdSubFondo = 0;
            this.usuariosControl1.IdUnidadAdmva = 0;
            this.usuariosControl1.Location = new System.Drawing.Point(3, 0);
            this.usuariosControl1.Materno = null;
            this.usuariosControl1.Name = "usuariosControl1";
            this.usuariosControl1.Nombre = null;
            this.usuariosControl1.Opcion = 0;
            this.usuariosControl1.Paterno = null;
            this.usuariosControl1.Size = new System.Drawing.Size(718, 336);
            this.usuariosControl1.TabIndex = 4;
            this.usuariosControl1.Usuario = null;
            // 
            // AgregarUsuarios
            // 
            this.AcceptButton = this.btnAgregar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnAgregar;
            this.ClientSize = new System.Drawing.Size(722, 337);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.usuariosControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AgregarUsuarios";
            this.ShowIcon = false;
            this.Text = "AgregarUsuarios";
            this.Load += new System.EventHandler(this.AgregarUsuarios_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnSalir;
        private UserControls.UsuariosControl usuariosControl1;
    }
}