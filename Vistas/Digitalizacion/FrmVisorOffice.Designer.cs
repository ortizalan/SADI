namespace SADI.Vistas.Digitalizacion
{
    partial class FrmVisorOffice
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
            this.VisorDocsOffice = new System.Windows.Forms.Integration.ElementHost();
            this.visorOfficexaml1 = new SADI.UserControls.VisorOfficexaml();
            this.SuspendLayout();
            // 
            // VisorDocsOffice
            // 
            this.VisorDocsOffice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VisorDocsOffice.Location = new System.Drawing.Point(0, 0);
            this.VisorDocsOffice.Name = "VisorDocsOffice";
            this.VisorDocsOffice.Size = new System.Drawing.Size(1031, 626);
            this.VisorDocsOffice.TabIndex = 0;
            this.VisorDocsOffice.Text = "elementHost1";
            this.VisorDocsOffice.Child = this.visorOfficexaml1;
            // 
            // FrmVisorOffice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1031, 626);
            this.Controls.Add(this.VisorDocsOffice);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmVisorOffice";
            this.ShowIcon = false;
            this.Text = "FrmVisorOffice";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Integration.ElementHost VisorDocsOffice;
        private UserControls.VisorOfficexaml visorOfficexaml1;
    }
}