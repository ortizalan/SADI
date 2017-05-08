namespace SADI.Vistas.Niveles
{
    partial class NivelAdd
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
            this.cmdIN = new System.Windows.Forms.Button();
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
            this.catGeoCtrll.Location = new System.Drawing.Point(1, 2);
            this.catGeoCtrll.Name = "catGeoCtrll";
            this.catGeoCtrll.Opcion = 0;
            this.catGeoCtrll.Size = new System.Drawing.Size(599, 288);
            this.catGeoCtrll.SubNivel = null;
            this.catGeoCtrll.TabIndex = 0;
            // 
            // cmdIN
            // 
            this.cmdIN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdIN.Location = new System.Drawing.Point(377, 296);
            this.cmdIN.Name = "cmdIN";
            this.cmdIN.Size = new System.Drawing.Size(109, 48);
            this.cmdIN.TabIndex = 1;
            this.cmdIN.Text = ":: INGRESAR ::";
            this.cmdIN.UseVisualStyleBackColor = true;
            this.cmdIN.Click += new System.EventHandler(this.cmdIN_Click);
            // 
            // cmdOUT
            // 
            this.cmdOUT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOUT.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdOUT.Location = new System.Drawing.Point(486, 296);
            this.cmdOUT.Name = "cmdOUT";
            this.cmdOUT.Size = new System.Drawing.Size(109, 48);
            this.cmdOUT.TabIndex = 2;
            this.cmdOUT.Text = ";; SALIR ::";
            this.cmdOUT.UseVisualStyleBackColor = true;
            this.cmdOUT.Click += new System.EventHandler(this.cmdOUT_Click);
            // 
            // NivelAdd
            // 
            this.AcceptButton = this.cmdIN;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdOUT;
            this.ClientSize = new System.Drawing.Size(608, 356);
            this.Controls.Add(this.cmdOUT);
            this.Controls.Add(this.cmdIN);
            this.Controls.Add(this.catGeoCtrll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NivelAdd";
            this.Text = "NivelAdd";
            this.Load += new System.EventHandler(this.NivelAdd_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.CatalogosGeoLocalizaControl catGeoCtrll;
        private System.Windows.Forms.Button cmdIN;
        private System.Windows.Forms.Button cmdOUT;
    }
}