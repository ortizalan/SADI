namespace SADI.Vistas.Filas
{
    partial class FilasEdit
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
            this.cmdEdit = new System.Windows.Forms.Button();
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
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEdit.Location = new System.Drawing.Point(387, 323);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(111, 57);
            this.cmdEdit.TabIndex = 1;
            this.cmdEdit.Text = ":: EDITAR ::";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // cmdOut
            // 
            this.cmdOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOut.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdOut.Location = new System.Drawing.Point(500, 323);
            this.cmdOut.Name = "cmdOut";
            this.cmdOut.Size = new System.Drawing.Size(111, 57);
            this.cmdOut.TabIndex = 2;
            this.cmdOut.Text = ":: SALIR ::";
            this.cmdOut.UseVisualStyleBackColor = true;
            this.cmdOut.Click += new System.EventHandler(this.cmdOut_Click);
            // 
            // FilasEdit
            // 
            this.AcceptButton = this.cmdEdit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdOut;
            this.ClientSize = new System.Drawing.Size(627, 403);
            this.Controls.Add(this.cmdOut);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.catGeoCtrll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FilasEdit";
            this.Text = "FilasEdit";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.CatalogosGeoLocalizaControl catGeoCtrll;
        private System.Windows.Forms.Button cmdEdit;
        private System.Windows.Forms.Button cmdOut;
    }
}