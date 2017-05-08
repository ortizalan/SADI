namespace SADI.Vistas.Estantes
{
    partial class EstanteAdd
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
            this.cmdIn = new System.Windows.Forms.Button();
            this.cmdOut = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // catGeoCtrll
            // 
            this.catGeoCtrll.Descripcion = null;
            this.catGeoCtrll.Formato = null;
            this.catGeoCtrll.Id = 0;
            this.catGeoCtrll.Imagen = null;
            this.catGeoCtrll.Lado = null;
            this.catGeoCtrll.Location = new System.Drawing.Point(12, 12);
            this.catGeoCtrll.Name = "catGeoCtrll";
            this.catGeoCtrll.Opcion = 0;
            this.catGeoCtrll.Size = new System.Drawing.Size(599, 288);
            this.catGeoCtrll.SubNivel = null;
            this.catGeoCtrll.TabIndex = 0;
            // 
            // cmdIn
            // 
            this.cmdIn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdIn.Location = new System.Drawing.Point(355, 325);
            this.cmdIn.Name = "cmdIn";
            this.cmdIn.Size = new System.Drawing.Size(115, 57);
            this.cmdIn.TabIndex = 1;
            this.cmdIn.Text = ":: INGRESAR ::";
            this.cmdIn.UseVisualStyleBackColor = true;
            this.cmdIn.Click += new System.EventHandler(this.cmdIn_Click);
            // 
            // cmdOut
            // 
            this.cmdOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdOut.Location = new System.Drawing.Point(470, 325);
            this.cmdOut.Name = "cmdOut";
            this.cmdOut.Size = new System.Drawing.Size(115, 57);
            this.cmdOut.TabIndex = 2;
            this.cmdOut.Text = ":: SALIR ::";
            this.cmdOut.UseVisualStyleBackColor = true;
            this.cmdOut.Click += new System.EventHandler(this.cmdOut_Click);
            // 
            // EstanteAdd
            // 
            this.AcceptButton = this.cmdIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdOut;
            this.ClientSize = new System.Drawing.Size(625, 409);
            this.Controls.Add(this.cmdOut);
            this.Controls.Add(this.cmdIn);
            this.Controls.Add(this.catGeoCtrll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EstanteAdd";
            this.Text = "EstanteAdd";
            this.Load += new System.EventHandler(this.EstanteAdd_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.CatalogosGeoLocalizaControl catGeoCtrll;
        private System.Windows.Forms.Button cmdIn;
        private System.Windows.Forms.Button cmdOut;
    }
}