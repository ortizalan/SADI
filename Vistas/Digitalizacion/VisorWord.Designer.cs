﻿namespace SADI.Vistas.Digitalizacion
{
    partial class VisorWord
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
            this.button1 = new System.Windows.Forms.Button();
            this.ctrlVisorWord = new SADI.UserControls.WordViewerControl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(291, 541);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 38);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ctrlVisorWord
            // 
            this.ctrlVisorWord.Location = new System.Drawing.Point(125, 1);
            this.ctrlVisorWord.Name = "ctrlVisorWord";
            this.ctrlVisorWord.Size = new System.Drawing.Size(435, 534);
            this.ctrlVisorWord.TabIndex = 2;
            // 
            // VisorWord
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 591);
            this.Controls.Add(this.ctrlVisorWord);
            this.Controls.Add(this.button1);
            this.Name = "VisorWord";
            this.Text = "VisorWord";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private UserControls.WordViewerControl ctrlVisorWord;
    }
}