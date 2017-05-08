namespace SADI.Vistas.Estantes
{
    partial class EstantesList
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
            this.dgvEstantes = new System.Windows.Forms.DataGridView();
            this.cmdOUT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstantes)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEstantes
            // 
            this.dgvEstantes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEstantes.Location = new System.Drawing.Point(-1, -1);
            this.dgvEstantes.Name = "dgvEstantes";
            this.dgvEstantes.Size = new System.Drawing.Size(600, 316);
            this.dgvEstantes.TabIndex = 0;
            this.dgvEstantes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvEstantes_KeyDown);
            // 
            // cmdOUT
            // 
            this.cmdOUT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOUT.Location = new System.Drawing.Point(467, 338);
            this.cmdOUT.Name = "cmdOUT";
            this.cmdOUT.Size = new System.Drawing.Size(121, 50);
            this.cmdOUT.TabIndex = 2;
            this.cmdOUT.Text = ":: SALIR ::";
            this.cmdOUT.UseVisualStyleBackColor = true;
            this.cmdOUT.Click += new System.EventHandler(this.cmdOUT_Click);
            // 
            // EstantesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 400);
            this.Controls.Add(this.cmdOUT);
            this.Controls.Add(this.dgvEstantes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EstantesList";
            this.Text = "EstantesList";
            this.Load += new System.EventHandler(this.EstantesList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEstantes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEstantes;
        private System.Windows.Forms.Button cmdOUT;
    }
}