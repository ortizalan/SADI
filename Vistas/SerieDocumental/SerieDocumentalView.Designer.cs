namespace SADI.Vistas.SerieDocumental
{
    partial class SerieDocumentalView
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
            this.dgvSeries = new System.Windows.Forms.DataGridView();
            this.dgvDigitalizados = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmdOUT = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDigitalizados)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSeries
            // 
            this.dgvSeries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvSeries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSeries.Location = new System.Drawing.Point(0, 32);
            this.dgvSeries.Name = "dgvSeries";
            this.dgvSeries.Size = new System.Drawing.Size(779, 322);
            this.dgvSeries.TabIndex = 0;
            this.dgvSeries.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSeries_RowEnter);
            // 
            // dgvDigitalizados
            // 
            this.dgvDigitalizados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDigitalizados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDigitalizados.Location = new System.Drawing.Point(785, 32);
            this.dgvDigitalizados.Name = "dgvDigitalizados";
            this.dgvDigitalizados.Size = new System.Drawing.Size(416, 322);
            this.dgvDigitalizados.TabIndex = 1;
            this.dgvDigitalizados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDigitalizados_CellClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(856, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(233, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "..:: DOCUMENTOS DIGITALIZADOS ::..";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(241, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(253, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "..:: SERIES DOCUMENTALES ACTIVAS ::..";
            // 
            // cmdOUT
            // 
            this.cmdOUT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdOUT.Location = new System.Drawing.Point(1071, 385);
            this.cmdOUT.Name = "cmdOUT";
            this.cmdOUT.Size = new System.Drawing.Size(118, 55);
            this.cmdOUT.TabIndex = 4;
            this.cmdOUT.Text = ":: SALIR ::";
            this.cmdOUT.UseVisualStyleBackColor = true;
            this.cmdOUT.Click += new System.EventHandler(this.cmdOUT_Click);
            // 
            // SerieDocumentalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 452);
            this.Controls.Add(this.cmdOUT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvDigitalizados);
            this.Controls.Add(this.dgvSeries);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SerieDocumentalView";
            this.ShowIcon = false;
            this.Text = "SerieDcoumentalView";
            ((System.ComponentModel.ISupportInitialize)(this.dgvSeries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDigitalizados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSeries;
        private System.Windows.Forms.DataGridView dgvDigitalizados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cmdOUT;
    }
}