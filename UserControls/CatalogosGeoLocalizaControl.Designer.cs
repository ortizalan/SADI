namespace SADI.UserControls
{
    partial class CatalogosGeoLocalizaControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.ImagenPb = new System.Windows.Forms.PictureBox();
            this.gpoBoxSel = new System.Windows.Forms.GroupBox();
            this.cboSubNiveles = new System.Windows.Forms.ComboBox();
            this.cboLados = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPb)).BeginInit();
            this.gpoBoxSel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(18, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ID";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(86, 31);
            this.txtId.Name = "txtId";
            this.txtId.Size = new System.Drawing.Size(57, 20);
            this.txtId.TabIndex = 1;
            this.txtId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtId_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblDescripcion);
            this.groupBox1.Controls.Add(this.txtDescripcion);
            this.groupBox1.Controls.Add(this.txtId);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(261, 128);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Generales";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(21, 72);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(13, 13);
            this.lblDescripcion.TabIndex = 3;
            this.lblDescripcion.Text = "::";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescripcion.Location = new System.Drawing.Point(86, 69);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(140, 20);
            this.txtDescripcion.TabIndex = 2;
            // 
            // ImagenPb
            // 
            this.ImagenPb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImagenPb.Location = new System.Drawing.Point(331, 33);
            this.ImagenPb.Name = "ImagenPb";
            this.ImagenPb.Size = new System.Drawing.Size(235, 228);
            this.ImagenPb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagenPb.TabIndex = 3;
            this.ImagenPb.TabStop = false;
            this.ImagenPb.DoubleClick += new System.EventHandler(this.ImagenPb_DoubleClick);
            // 
            // gpoBoxSel
            // 
            this.gpoBoxSel.Controls.Add(this.cboSubNiveles);
            this.gpoBoxSel.Controls.Add(this.cboLados);
            this.gpoBoxSel.Controls.Add(this.label3);
            this.gpoBoxSel.Controls.Add(this.label2);
            this.gpoBoxSel.Location = new System.Drawing.Point(18, 158);
            this.gpoBoxSel.Name = "gpoBoxSel";
            this.gpoBoxSel.Size = new System.Drawing.Size(261, 103);
            this.gpoBoxSel.TabIndex = 4;
            this.gpoBoxSel.TabStop = false;
            this.gpoBoxSel.Text = "Seleccione la Opción";
            // 
            // cboSubNiveles
            // 
            this.cboSubNiveles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSubNiveles.FormattingEnabled = true;
            this.cboSubNiveles.Location = new System.Drawing.Point(68, 62);
            this.cboSubNiveles.Name = "cboSubNiveles";
            this.cboSubNiveles.Size = new System.Drawing.Size(158, 21);
            this.cboSubNiveles.TabIndex = 3;
            this.cboSubNiveles.SelectedIndexChanged += new System.EventHandler(this.cboSubNiveles_SelectedIndexChanged);
            // 
            // cboLados
            // 
            this.cboLados.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLados.FormattingEnabled = true;
            this.cboLados.Location = new System.Drawing.Point(68, 29);
            this.cboLados.Name = "cboLados";
            this.cboLados.Size = new System.Drawing.Size(158, 21);
            this.cboLados.TabIndex = 2;
            this.cboLados.SelectedIndexChanged += new System.EventHandler(this.cboLados_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "SubNivel :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Lado :";
            // 
            // CatalogosGeoLocalizaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gpoBoxSel);
            this.Controls.Add(this.ImagenPb);
            this.Controls.Add(this.groupBox1);
            this.Name = "CatalogosGeoLocalizaControl";
            this.Size = new System.Drawing.Size(599, 288);
            this.Load += new System.EventHandler(this.CatalogosGeoLocalizaControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagenPb)).EndInit();
            this.gpoBoxSel.ResumeLayout(false);
            this.gpoBoxSel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.PictureBox ImagenPb;
        private System.Windows.Forms.GroupBox gpoBoxSel;
        private System.Windows.Forms.ComboBox cboSubNiveles;
        private System.Windows.Forms.ComboBox cboLados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
