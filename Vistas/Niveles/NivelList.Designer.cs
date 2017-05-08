namespace SADI.Vistas.Niveles
{
    partial class NivelList
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
            this.dgvNiveles = new System.Windows.Forms.DataGridView();
            this.cmdOUT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNiveles)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvNiveles
            // 
            this.dgvNiveles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNiveles.Location = new System.Drawing.Point(0, 1);
            this.dgvNiveles.Name = "dgvNiveles";
            this.dgvNiveles.Size = new System.Drawing.Size(583, 269);
            this.dgvNiveles.TabIndex = 0;
            this.dgvNiveles.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvNiveles_KeyDown);
            // 
            // cmdOUT
            // 
            this.cmdOUT.Location = new System.Drawing.Point(460, 290);
            this.cmdOUT.Name = "cmdOUT";
            this.cmdOUT.Size = new System.Drawing.Size(112, 59);
            this.cmdOUT.TabIndex = 1;
            this.cmdOUT.Text = ":: SALIR ::";
            this.cmdOUT.UseVisualStyleBackColor = true;
            this.cmdOUT.Click += new System.EventHandler(this.cmdOUT_Click);
            // 
            // NivelList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.cmdOUT);
            this.Controls.Add(this.dgvNiveles);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NivelList";
            this.Text = "NivelList";
            ((System.ComponentModel.ISupportInitialize)(this.dgvNiveles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvNiveles;
        private System.Windows.Forms.Button cmdOUT;
    }
}