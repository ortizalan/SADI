namespace SADI.Vistas.Estantes
{
    partial class EstanteEdit
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
            this.catGeoCtrll = new SADI.UserControls.CatalogosGeoLocalizaControl();
            this.cmdEDIT = new System.Windows.Forms.Button();
            this.cmdOUT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // catGeoCtrll
            // 
            this.catGeoCtrll.Descripcion = null;
            this.catGeoCtrll.Formato = null;
            this.catGeoCtrll.Id = 0;
            this.catGeoCtrll.Imagen = null;
            this.catGeoCtrll.Lado = null;
            this.catGeoCtrll.Location = new System.Drawing.Point(3, 3);
            this.catGeoCtrll.Name = "catGeoCtrll";
            this.catGeoCtrll.Opcion = 0;
            this.catGeoCtrll.Size = new System.Drawing.Size(599, 288);
            this.catGeoCtrll.SubNivel = null;
            this.catGeoCtrll.TabIndex = 0;
            // 
            // cmdEDIT
            // 
            this.cmdEDIT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEDIT.Location = new System.Drawing.Point(349, 304);
            this.cmdEDIT.Name = "cmdEDIT";
            this.cmdEDIT.Size = new System.Drawing.Size(114, 47);
            this.cmdEDIT.TabIndex = 1;
            this.cmdEDIT.Text = ":: EDITAR ::";
            this.cmdEDIT.UseVisualStyleBackColor = true;
            this.cmdEDIT.Click += new System.EventHandler(this.cmdEDIT_Click);
            // 
            // cmdOUT
            // 
            this.cmdOUT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOUT.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdOUT.Location = new System.Drawing.Point(465, 304);
            this.cmdOUT.Name = "cmdOUT";
            this.cmdOUT.Size = new System.Drawing.Size(114, 47);
            this.cmdOUT.TabIndex = 2;
            this.cmdOUT.Text = ":: SALIR ::";
            this.cmdOUT.UseVisualStyleBackColor = true;
            this.cmdOUT.Click += new System.EventHandler(this.cmdOUT_Click);
            // 
            // EstanteEdit
            // 
            this.AcceptButton = this.cmdEDIT;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdOUT;
            this.ClientSize = new System.Drawing.Size(605, 370);
            this.Controls.Add(this.cmdOUT);
            this.Controls.Add(this.cmdEDIT);
            this.Controls.Add(this.catGeoCtrll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EstanteEdit";
            this.Text = "EstanteEdit";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.CatalogosGeoLocalizaControl catGeoCtrll;
        private System.Windows.Forms.Button cmdEDIT;
        private System.Windows.Forms.Button cmdOUT;
    }
}