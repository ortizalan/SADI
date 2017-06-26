namespace SADI.Vistas.SerieDocumental
{
    partial class SerieDocumentalAdd
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
            this.cmdOUT = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdOUT
            // 
            this.cmdOUT.Location = new System.Drawing.Point(727, 502);
            this.cmdOUT.Name = "cmdOUT";
            this.cmdOUT.Size = new System.Drawing.Size(122, 42);
            this.cmdOUT.TabIndex = 11;
            this.cmdOUT.Text = ":: SALIR ::";
            this.cmdOUT.UseVisualStyleBackColor = true;
            this.cmdOUT.Click += new System.EventHandler(this.cmdOUT_Click);
            // 
            // SerieDocumentalAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(877, 556);
            this.Controls.Add(this.cmdOUT);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SerieDocumentalAdd";
            this.Text = "SerieDocumentalAdd";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button cmdOUT;
    }
}