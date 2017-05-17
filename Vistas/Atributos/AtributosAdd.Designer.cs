namespace SADI.Vistas.Atributos
{
    partial class AtributosAdd
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
            this.dgvSecciones = new System.Windows.Forms.DataGridView();
            this.dgvSeries = new System.Windows.Forms.DataGridView();
            this.dgvTemas = new System.Windows.Forms.DataGridView();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.cmdOUT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecciones)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSecciones
            // 
            this.dgvSecciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSecciones.Location = new System.Drawing.Point(12, 58);
            this.dgvSecciones.Name = "dgvSecciones";
            this.dgvSecciones.Size = new System.Drawing.Size(429, 436);
            this.dgvSecciones.TabIndex = 0;
            this.dgvSecciones.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSecciones_CellContentClick);
            // 
            // dgvSeries
            // 
            this.dgvSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeries.Location = new System.Drawing.Point(447, 58);
            this.dgvSeries.Name = "dgvSeries";
            this.dgvSeries.Size = new System.Drawing.Size(384, 436);
            this.dgvSeries.TabIndex = 1;
            this.dgvSeries.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeries_CellContentClick);
            // 
            // dgvTemas
            // 
            this.dgvTemas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTemas.Location = new System.Drawing.Point(837, 58);
            this.dgvTemas.Name = "dgvTemas";
            this.dgvTemas.Size = new System.Drawing.Size(349, 436);
            this.dgvTemas.TabIndex = 2;
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(12, 12);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(131, 15);
            this.lblUsuario.TabIndex = 3;
            this.lblUsuario.Text = "Atribuciones para : ";
            // 
            // cmdOUT
            // 
            this.cmdOUT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOUT.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cmdOUT.Location = new System.Drawing.Point(1065, 500);
            this.cmdOUT.Name = "cmdOUT";
            this.cmdOUT.Size = new System.Drawing.Size(121, 57);
            this.cmdOUT.TabIndex = 4;
            this.cmdOUT.Text = ":: SALIR ::";
            this.cmdOUT.UseVisualStyleBackColor = true;
            this.cmdOUT.Click += new System.EventHandler(this.cmdOUT_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(193, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "SECCIONES :";
            // 
            // AtributosAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cmdOUT;
            this.ClientSize = new System.Drawing.Size(1198, 569);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmdOUT);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.dgvTemas);
            this.Controls.Add(this.dgvSeries);
            this.Controls.Add(this.dgvSecciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AtributosAdd";
            this.Text = "AtributosAdd";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSecciones)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTemas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSecciones;
        private System.Windows.Forms.DataGridView dgvSeries;
        private System.Windows.Forms.DataGridView dgvTemas;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Button cmdOUT;
        private System.Windows.Forms.Label label1;
    }
}