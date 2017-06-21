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
            this.gpoCrearSerieDoctal = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.cboTema = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboSeries = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboSeccion = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.gpoDetallesDoc = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboValorDoctal = new System.Windows.Forms.ComboBox();
            this.cboClasificaciones = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNombreExp = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescExpe = new System.Windows.Forms.TextBox();
            this.gpoCveSevi = new System.Windows.Forms.GroupBox();
            this.txtCveSevi = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkTieneSevi = new System.Windows.Forms.CheckBox();
            this.txtOtraInfo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chkStatus = new System.Windows.Forms.CheckBox();
            this.gpoSerieDoctal = new System.Windows.Forms.GroupBox();
            this.cmdOUT = new System.Windows.Forms.Button();
            this.gpoCrearSerieDoctal.SuspendLayout();
            this.gpoDetallesDoc.SuspendLayout();
            this.gpoCveSevi.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpoCrearSerieDoctal
            // 
            this.gpoCrearSerieDoctal.Controls.Add(this.label4);
            this.gpoCrearSerieDoctal.Controls.Add(this.dateTimePicker1);
            this.gpoCrearSerieDoctal.Controls.Add(this.cboTema);
            this.gpoCrearSerieDoctal.Controls.Add(this.label3);
            this.gpoCrearSerieDoctal.Controls.Add(this.cboSeries);
            this.gpoCrearSerieDoctal.Controls.Add(this.label2);
            this.gpoCrearSerieDoctal.Controls.Add(this.cboSeccion);
            this.gpoCrearSerieDoctal.Controls.Add(this.label1);
            this.gpoCrearSerieDoctal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpoCrearSerieDoctal.Location = new System.Drawing.Point(23, 41);
            this.gpoCrearSerieDoctal.Name = "gpoCrearSerieDoctal";
            this.gpoCrearSerieDoctal.Size = new System.Drawing.Size(496, 203);
            this.gpoCrearSerieDoctal.TabIndex = 0;
            this.gpoCrearSerieDoctal.TabStop = false;
            this.gpoCrearSerieDoctal.Text = "Crear Serie Documental";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(219, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Fecha de Creación :";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(360, 34);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(119, 23);
            this.dateTimePicker1.TabIndex = 6;
            // 
            // cboTema
            // 
            this.cboTema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTema.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTema.FormattingEnabled = true;
            this.cboTema.Location = new System.Drawing.Point(96, 155);
            this.cboTema.Name = "cboTema";
            this.cboTema.Size = new System.Drawing.Size(383, 21);
            this.cboTema.TabIndex = 5;
            this.cboTema.SelectedIndexChanged += new System.EventHandler(this.cboTema_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(44, 158);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tema :";
            // 
            // cboSeries
            // 
            this.cboSeries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSeries.FormattingEnabled = true;
            this.cboSeries.Location = new System.Drawing.Point(96, 117);
            this.cboSeries.Name = "cboSeries";
            this.cboSeries.Size = new System.Drawing.Size(383, 21);
            this.cboSeries.TabIndex = 3;
            this.cboSeries.SelectedValueChanged += new System.EventHandler(this.cboSeries_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(46, 120);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Serie :";
            // 
            // cboSeccion
            // 
            this.cboSeccion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSeccion.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSeccion.FormattingEnabled = true;
            this.cboSeccion.Location = new System.Drawing.Point(98, 77);
            this.cboSeccion.Name = "cboSeccion";
            this.cboSeccion.Size = new System.Drawing.Size(383, 21);
            this.cboSeccion.TabIndex = 1;
            this.cboSeccion.SelectedValueChanged += new System.EventHandler(this.cboSeccion_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(29, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sección :";
            // 
            // gpoDetallesDoc
            // 
            this.gpoDetallesDoc.Controls.Add(this.label6);
            this.gpoDetallesDoc.Controls.Add(this.label5);
            this.gpoDetallesDoc.Controls.Add(this.cboValorDoctal);
            this.gpoDetallesDoc.Controls.Add(this.cboClasificaciones);
            this.gpoDetallesDoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpoDetallesDoc.Location = new System.Drawing.Point(525, 41);
            this.gpoDetallesDoc.Name = "gpoDetallesDoc";
            this.gpoDetallesDoc.Size = new System.Drawing.Size(325, 155);
            this.gpoDetallesDoc.TabIndex = 1;
            this.gpoDetallesDoc.TabStop = false;
            this.gpoDetallesDoc.Text = "Detalles Documento";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(11, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 30);
            this.label6.TabIndex = 3;
            this.label6.Text = "     Valor \r\nDocumental :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 66);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 15);
            this.label5.TabIndex = 2;
            this.label5.Text = "Clasificación :";
            // 
            // cboValorDoctal
            // 
            this.cboValorDoctal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboValorDoctal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboValorDoctal.FormattingEnabled = true;
            this.cboValorDoctal.Location = new System.Drawing.Point(112, 105);
            this.cboValorDoctal.Name = "cboValorDoctal";
            this.cboValorDoctal.Size = new System.Drawing.Size(193, 21);
            this.cboValorDoctal.TabIndex = 1;
            // 
            // cboClasificaciones
            // 
            this.cboClasificaciones.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboClasificaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboClasificaciones.FormattingEnabled = true;
            this.cboClasificaciones.Location = new System.Drawing.Point(112, 63);
            this.cboClasificaciones.Name = "cboClasificaciones";
            this.cboClasificaciones.Size = new System.Drawing.Size(193, 21);
            this.cboClasificaciones.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 318);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(166, 15);
            this.label7.TabIndex = 2;
            this.label7.Text = "Nombre del Expediente :";
            // 
            // txtNombreExp
            // 
            this.txtNombreExp.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtNombreExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreExp.Location = new System.Drawing.Point(27, 337);
            this.txtNombreExp.Name = "txtNombreExp";
            this.txtNombreExp.Size = new System.Drawing.Size(433, 20);
            this.txtNombreExp.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(24, 363);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(191, 15);
            this.label8.TabIndex = 4;
            this.label8.Text = "Descripción del Expediente :";
            // 
            // txtDescExpe
            // 
            this.txtDescExpe.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtDescExpe.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescExpe.Location = new System.Drawing.Point(27, 383);
            this.txtDescExpe.Multiline = true;
            this.txtDescExpe.Name = "txtDescExpe";
            this.txtDescExpe.Size = new System.Drawing.Size(433, 112);
            this.txtDescExpe.TabIndex = 5;
            // 
            // gpoCveSevi
            // 
            this.gpoCveSevi.Controls.Add(this.txtCveSevi);
            this.gpoCveSevi.Controls.Add(this.label9);
            this.gpoCveSevi.Controls.Add(this.chkTieneSevi);
            this.gpoCveSevi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpoCveSevi.Location = new System.Drawing.Point(525, 207);
            this.gpoCveSevi.Name = "gpoCveSevi";
            this.gpoCveSevi.Size = new System.Drawing.Size(325, 97);
            this.gpoCveSevi.TabIndex = 6;
            this.gpoCveSevi.TabStop = false;
            this.gpoCveSevi.Text = "Clave SEVI";
            // 
            // txtCveSevi
            // 
            this.txtCveSevi.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCveSevi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCveSevi.Location = new System.Drawing.Point(99, 65);
            this.txtCveSevi.Name = "txtCveSevi";
            this.txtCveSevi.Size = new System.Drawing.Size(213, 20);
            this.txtCveSevi.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(11, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 15);
            this.label9.TabIndex = 3;
            this.label9.Text = "Clave SEVI :";
            // 
            // chkTieneSevi
            // 
            this.chkTieneSevi.AutoSize = true;
            this.chkTieneSevi.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkTieneSevi.Location = new System.Drawing.Point(14, 35);
            this.chkTieneSevi.Name = "chkTieneSevi";
            this.chkTieneSevi.Size = new System.Drawing.Size(166, 17);
            this.chkTieneSevi.TabIndex = 0;
            this.chkTieneSevi.Text = "Cuenta con Clave SEVI?";
            this.chkTieneSevi.UseVisualStyleBackColor = true;
            // 
            // txtOtraInfo
            // 
            this.txtOtraInfo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtOtraInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOtraInfo.Location = new System.Drawing.Point(485, 383);
            this.txtOtraInfo.Multiline = true;
            this.txtOtraInfo.Name = "txtOtraInfo";
            this.txtOtraInfo.Size = new System.Drawing.Size(365, 112);
            this.txtOtraInfo.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(485, 363);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(154, 15);
            this.label10.TabIndex = 7;
            this.label10.Text = "Información Adicional :";
            // 
            // chkStatus
            // 
            this.chkStatus.AutoSize = true;
            this.chkStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkStatus.Location = new System.Drawing.Point(27, 502);
            this.chkStatus.Name = "chkStatus";
            this.chkStatus.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkStatus.Size = new System.Drawing.Size(139, 19);
            this.chkStatus.TabIndex = 9;
            this.chkStatus.Text = "Expediente Activo";
            this.chkStatus.UseVisualStyleBackColor = true;
            // 
            // gpoSerieDoctal
            // 
            this.gpoSerieDoctal.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpoSerieDoctal.Location = new System.Drawing.Point(23, 251);
            this.gpoSerieDoctal.Name = "gpoSerieDoctal";
            this.gpoSerieDoctal.Size = new System.Drawing.Size(496, 64);
            this.gpoSerieDoctal.TabIndex = 10;
            this.gpoSerieDoctal.TabStop = false;
            this.gpoSerieDoctal.Text = "Serie Documental";
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
            this.Controls.Add(this.gpoSerieDoctal);
            this.Controls.Add(this.chkStatus);
            this.Controls.Add(this.txtOtraInfo);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.gpoCveSevi);
            this.Controls.Add(this.txtDescExpe);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtNombreExp);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.gpoDetallesDoc);
            this.Controls.Add(this.gpoCrearSerieDoctal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SerieDocumentalAdd";
            this.Text = "SerieDocumentalAdd";
            this.gpoCrearSerieDoctal.ResumeLayout(false);
            this.gpoCrearSerieDoctal.PerformLayout();
            this.gpoDetallesDoc.ResumeLayout(false);
            this.gpoDetallesDoc.PerformLayout();
            this.gpoCveSevi.ResumeLayout(false);
            this.gpoCveSevi.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpoCrearSerieDoctal;
        private System.Windows.Forms.ComboBox cboTema;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboSeries;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboSeccion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.GroupBox gpoDetallesDoc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboValorDoctal;
        private System.Windows.Forms.ComboBox cboClasificaciones;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNombreExp;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescExpe;
        private System.Windows.Forms.GroupBox gpoCveSevi;
        private System.Windows.Forms.CheckBox chkTieneSevi;
        private System.Windows.Forms.TextBox txtCveSevi;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtOtraInfo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chkStatus;
        private System.Windows.Forms.GroupBox gpoSerieDoctal;
        private System.Windows.Forms.Button cmdOUT;
    }
}