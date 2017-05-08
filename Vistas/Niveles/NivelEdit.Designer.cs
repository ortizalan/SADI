namespace SADI.Vistas.Niveles
{
    partial class NivelEdit
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
            this.catRegCtrll = new SADI.UserControls.CatalogosGeoLocalizaControl();
            this.cmdOUT = new System.Windows.Forms.Button();
            this.cmdEdit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // catRegCtrll
            // 
            this.catRegCtrll.Descripcion = null;
            this.catRegCtrll.Formato = null;
            this.catRegCtrll.Id = 0;
            this.catRegCtrll.Imagen = null;
            this.catRegCtrll.Lado = null;
            this.catRegCtrll.Location = new System.Drawing.Point(1, 2);
            this.catRegCtrll.Name = "catRegCtrll";
            this.catRegCtrll.Opcion = 0;
            this.catRegCtrll.Size = new System.Drawing.Size(599, 288);
            this.catRegCtrll.SubNivel = null;
            this.catRegCtrll.TabIndex = 0;
            // 
            // cmdOUT
            // 
            this.cmdOUT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOUT.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdOUT.Location = new System.Drawing.Point(449, 298);
            this.cmdOUT.Name = "cmdOUT";
            this.cmdOUT.Size = new System.Drawing.Size(120, 48);
            this.cmdOUT.TabIndex = 1;
            this.cmdOUT.Text = ":: SALIR ::";
            this.cmdOUT.UseVisualStyleBackColor = true;
            this.cmdOUT.Click += new System.EventHandler(this.cmdOUT_Click);
            // 
            // cmdEdit
            // 
            this.cmdEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdEdit.Location = new System.Drawing.Point(328, 298);
            this.cmdEdit.Name = "cmdEdit";
            this.cmdEdit.Size = new System.Drawing.Size(120, 48);
            this.cmdEdit.TabIndex = 2;
            this.cmdEdit.Text = ":: EDITAR ::";
            this.cmdEdit.UseVisualStyleBackColor = true;
            this.cmdEdit.Click += new System.EventHandler(this.cmdEdit_Click);
            // 
            // NivelEdit
            // 
            this.AcceptButton = this.cmdEdit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdOUT;
            this.ClientSize = new System.Drawing.Size(595, 358);
            this.Controls.Add(this.cmdEdit);
            this.Controls.Add(this.cmdOUT);
            this.Controls.Add(this.catRegCtrll);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NivelEdit";
            this.Text = "NivelEdit";
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.CatalogosGeoLocalizaControl catRegCtrll;
        private System.Windows.Forms.Button cmdOUT;
        private System.Windows.Forms.Button cmdEdit;
    }
}