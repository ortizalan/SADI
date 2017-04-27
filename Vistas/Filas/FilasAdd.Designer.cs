namespace SADI.Vistas.Filas
{
    partial class FilasAdd
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
            this.catGeoCtrl = new SADI.UserControls.CatalogosGeoLocalizaControl();
            this.catalogosGeoLocalizaControl1 = new SADI.UserControls.CatalogosGeoLocalizaControl();
            this.cmdAdd = new System.Windows.Forms.Button();
            this.cmdOUT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // catGeoCtrl
            // 
            this.catGeoCtrl.Descripcion = null;
            this.catGeoCtrl.Id = 0;
            this.catGeoCtrl.Lado = null;
            this.catGeoCtrl.Location = new System.Drawing.Point(12, 2);
            this.catGeoCtrl.Name = "catGeoCtrl";
            this.catGeoCtrl.Opcion = 0;
            this.catGeoCtrl.Size = new System.Drawing.Size(599, 288);
            this.catGeoCtrl.SubNivel = null;
            this.catGeoCtrl.TabIndex = 0;
            // 
            // catalogosGeoLocalizaControl1
            // 
            this.catalogosGeoLocalizaControl1.Descripcion = null;
            this.catalogosGeoLocalizaControl1.Id = 0;
            this.catalogosGeoLocalizaControl1.Lado = null;
            this.catalogosGeoLocalizaControl1.Location = new System.Drawing.Point(12, 12);
            this.catalogosGeoLocalizaControl1.Name = "catalogosGeoLocalizaControl1";
            this.catalogosGeoLocalizaControl1.Opcion = 0;
            this.catalogosGeoLocalizaControl1.Size = new System.Drawing.Size(599, 288);
            this.catalogosGeoLocalizaControl1.SubNivel = null;
            this.catalogosGeoLocalizaControl1.TabIndex = 0;
            // 
            // cmdAdd
            // 
            this.cmdAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdAdd.Location = new System.Drawing.Point(365, 296);
            this.cmdAdd.Name = "cmdAdd";
            this.cmdAdd.Size = new System.Drawing.Size(121, 51);
            this.cmdAdd.TabIndex = 1;
            this.cmdAdd.Text = ":: AGREGAR ::";
            this.cmdAdd.UseVisualStyleBackColor = true;
            this.cmdAdd.Click += new System.EventHandler(this.cmdAdd_Click);
            // 
            // cmdOUT
            // 
            this.cmdOUT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOUT.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdOUT.Location = new System.Drawing.Point(489, 296);
            this.cmdOUT.Name = "cmdOUT";
            this.cmdOUT.Size = new System.Drawing.Size(121, 51);
            this.cmdOUT.TabIndex = 2;
            this.cmdOUT.Text = ":: SALIR ::";
            this.cmdOUT.UseVisualStyleBackColor = true;
            this.cmdOUT.Click += new System.EventHandler(this.cmdOUT_Click);
            // 
            // FilasAdd
            // 
            this.AcceptButton = this.cmdAdd;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdOUT;
            this.ClientSize = new System.Drawing.Size(623, 359);
            this.Controls.Add(this.cmdOUT);
            this.Controls.Add(this.cmdAdd);
            this.Controls.Add(this.catGeoCtrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FilasAdd";
            this.Text = "FilasAdd";
            this.Load += new System.EventHandler(this.FilasAdd_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.CatalogosGeoLocalizaControl catGeoCtrl;
        private UserControls.CatalogosGeoLocalizaControl catalogosGeoLocalizaControl1;
        private System.Windows.Forms.Button cmdAdd;
        private System.Windows.Forms.Button cmdOUT;
    }
}