namespace SADI.Vistas.Estantes
{
    partial class EstantesDetails
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
            this.catGeoCtrll.Location = new System.Drawing.Point(1, 1);
            this.catGeoCtrll.Name = "catGeoCtrll";
            this.catGeoCtrll.Opcion = 0;
            this.catGeoCtrll.Size = new System.Drawing.Size(599, 288);
            this.catGeoCtrll.SubNivel = null;
            this.catGeoCtrll.TabIndex = 0;
            // 
            // cmdOUT
            // 
            this.cmdOUT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOUT.Location = new System.Drawing.Point(449, 307);
            this.cmdOUT.Name = "cmdOUT";
            this.cmdOUT.Size = new System.Drawing.Size(123, 53);
            this.cmdOUT.TabIndex = 1;
            this.cmdOUT.Text = ":: SALIR ::";
            this.cmdOUT.UseVisualStyleBackColor = true;
            this.cmdOUT.Click += new System.EventHandler(this.cmdOUT_Click);
            // 
            // EstantesDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 385);
            this.Controls.Add(this.cmdOUT);
            this.Controls.Add(this.catGeoCtrll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EstantesDetails";
            this.Text = "EstantesDetails";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.CatalogosGeoLocalizaControl catGeoCtrll;
        private System.Windows.Forms.Button cmdOUT;
    }
}