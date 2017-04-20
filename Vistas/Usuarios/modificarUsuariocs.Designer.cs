namespace SADI.Vistas.Usuarios
{
    partial class modificarUsuariocs
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
            this.usuariosControl1 = new SADI.UserControls.UsuariosControl();
            this.SuspendLayout();
            // 
            // usuariosControl1
            // 
            this.usuariosControl1.Location = new System.Drawing.Point(12, 3);
            this.usuariosControl1.Materno = null;
            this.usuariosControl1.Name = "usuariosControl1";
            this.usuariosControl1.Nombre = null;
            this.usuariosControl1.Opcion = 0;
            this.usuariosControl1.Paterno = null;
            this.usuariosControl1.Size = new System.Drawing.Size(718, 312);
            this.usuariosControl1.TabIndex = 0;
            this.usuariosControl1.Usuario = null;
            // 
            // modificarUsuariocs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 344);
            this.Controls.Add(this.usuariosControl1);
            this.Name = "modificarUsuariocs";
            this.Text = "modificarUsuariocs";
            this.Load += new System.EventHandler(this.modificarUsuariocs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.UsuariosControl usuariosControl1;
    }
}