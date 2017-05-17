namespace SADI.Vistas.Temas
{
    partial class TemasAdd
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
            this.cboSecciones = new System.Windows.Forms.ComboBox();
            this.cboSeries = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTema = new System.Windows.Forms.TextBox();
            this.dgvTemas = new System.Windows.Forms.DataGridView();
            this.cmdIN = new System.Windows.Forms.Button();
            this.cmdOUT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemas)).BeginInit();
            this.SuspendLayout();
            // 
            // cboSecciones
            // 
            this.cboSecciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSecciones.FormattingEnabled = true;
            this.cboSecciones.Location = new System.Drawing.Point(178, 56);
            this.cboSecciones.Name = "cboSecciones";
            this.cboSecciones.Size = new System.Drawing.Size(268, 21);
            this.cboSecciones.TabIndex = 0;
            this.cboSecciones.SelectedIndexChanged += new System.EventHandler(this.cboSecciones_SelectedIndexChanged);
            // 
            // cboSeries
            // 
            this.cboSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeries.FormattingEnabled = true;
            this.cboSeries.Location = new System.Drawing.Point(178, 100);
            this.cboSeries.Name = "cboSeries";
            this.cboSeries.Size = new System.Drawing.Size(268, 21);
            this.cboSeries.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione Sección :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Seleccione Serie :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 149);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Descripción del Tema :";
            // 
            // txtTema
            // 
            this.txtTema.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTema.Location = new System.Drawing.Point(178, 146);
            this.txtTema.Name = "txtTema";
            this.txtTema.Size = new System.Drawing.Size(268, 20);
            this.txtTema.TabIndex = 5;
            // 
            // dgvTemas
            // 
            this.dgvTemas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTemas.Location = new System.Drawing.Point(489, 12);
            this.dgvTemas.Name = "dgvTemas";
            this.dgvTemas.Size = new System.Drawing.Size(379, 213);
            this.dgvTemas.TabIndex = 6;
            // 
            // cmdIN
            // 
            this.cmdIN.Location = new System.Drawing.Point(580, 238);
            this.cmdIN.Name = "cmdIN";
            this.cmdIN.Size = new System.Drawing.Size(142, 59);
            this.cmdIN.TabIndex = 7;
            this.cmdIN.Text = ":: INGRESAR ::";
            this.cmdIN.UseVisualStyleBackColor = true;
            this.cmdIN.Click += new System.EventHandler(this.cmdIN_Click);
            // 
            // cmdOUT
            // 
            this.cmdOUT.Location = new System.Drawing.Point(724, 238);
            this.cmdOUT.Name = "cmdOUT";
            this.cmdOUT.Size = new System.Drawing.Size(142, 59);
            this.cmdOUT.TabIndex = 8;
            this.cmdOUT.Text = ":: SALIR ::";
            this.cmdOUT.UseVisualStyleBackColor = true;
            this.cmdOUT.Click += new System.EventHandler(this.cmdOUT_Click);
            // 
            // TemasAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 316);
            this.Controls.Add(this.cmdOUT);
            this.Controls.Add(this.cmdIN);
            this.Controls.Add(this.dgvTemas);
            this.Controls.Add(this.txtTema);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboSeries);
            this.Controls.Add(this.cboSecciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TemasAdd";
            this.Text = "TemasAdd";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboSecciones;
        private System.Windows.Forms.ComboBox cboSeries;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTema;
        private System.Windows.Forms.DataGridView dgvTemas;
        private System.Windows.Forms.Button cmdIN;
        private System.Windows.Forms.Button cmdOUT;
    }
}