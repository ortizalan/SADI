namespace SADI.Vistas.Filas
{
    partial class FilasList
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
            this.dgvFilas = new System.Windows.Forms.DataGridView();
            this.cmdOUT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvFilas
            // 
            this.dgvFilas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFilas.Location = new System.Drawing.Point(0, -2);
            this.dgvFilas.Name = "dgvFilas";
            this.dgvFilas.Size = new System.Drawing.Size(662, 316);
            this.dgvFilas.TabIndex = 0;
            this.dgvFilas.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvFilas_KeyDown);
            // 
            // cmdOUT
            // 
            this.cmdOUT.Location = new System.Drawing.Point(528, 331);
            this.cmdOUT.Name = "cmdOUT";
            this.cmdOUT.Size = new System.Drawing.Size(121, 50);
            this.cmdOUT.TabIndex = 1;
            this.cmdOUT.Text = ":: SALIR ::";
            this.cmdOUT.UseVisualStyleBackColor = true;
            this.cmdOUT.Click += new System.EventHandler(this.cmdOUT_Click);
            // 
            // FilasList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 403);
            this.Controls.Add(this.cmdOUT);
            this.Controls.Add(this.dgvFilas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(1, 1);
            this.Name = "FilasList";
            this.Text = "listaFilas";
            this.Load += new System.EventHandler(this.listaFilas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFilas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvFilas;
        private System.Windows.Forms.Button cmdOUT;
    }
}