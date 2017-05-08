using System;
using System.Windows.Forms;
using SADI.Clases;
using SADI.Clases.Controladores;

namespace SADI.Vistas.Niveles
{
    public partial class NivelList : Form
    {
        int opc;
        NivelesController nc = new NivelesController();
        /// <summary>
        /// Constructor de la Forma sin Recibir Parámetros
        /// </summary>
        public NivelList()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Constructor que Recibe Parámetros
        /// </summary>
        /// <param name="id">Opción a Ejecutar 1) Detalles 2) Editar</param>
        public NivelList(int opc)
        {
            InitializeComponent();
            this.opc = opc;

            if(nc.ConsultarRegistros())//Intentar Consulta
            {
                //Intento Exitoso
                if (nc.Tabla.Rows.Count > 0)//Verificar si tiene registro el Modelo
                {
                    LLenarGridNiveles();
                }
                else// No tiene registros 
                {
                    MessageBox.Show("no existen registros.".ToUpper(),":: mensaje desde lista niveles ::".ToUpper(),
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
            }
            else// Intento NO Exitoso
            {
                MessageBox.Show("ocurrió el siguiente error :".ToUpper() + "\n" + nc.Error,
                    ":: mensaje desde lista niveles ::",MessageBoxButtons.OK,MessageBoxIcon.Error);
                Close();//Cerrar la forma
            }
        }
        /// <summary>
        /// LLenar el Grid
        /// </summary>
        private void LLenarGridNiveles()
        {
            dgvNiveles.DataSource = nc.Tabla;// Indicarle la fuente de datos al Grid
            dgvNiveles.AllowUserToAddRows = false;// No Agregar Renglones en Diseño
            dgvNiveles.AllowUserToDeleteRows = false;// NO Borrar rengloes en diseño
            dgvNiveles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//Seleccionar todo el renglón
            dgvNiveles.ReadOnly = true;// Grid de solo lectura
            dgvNiveles.MultiSelect = false;// SOlamente un renglon seleccionado
            dgvNiveles.RowHeadersVisible = false;//Ocultar los Headers de los renglones
            dgvNiveles.Columns[2].Visible = false;//Ocultar la imagen de los registros
            dgvNiveles.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;//LLenado de todo el grid
        }

        private void dgvNiveles_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)//Verificar si se presionó Enter
            {
                e.SuppressKeyPress = true;//Eliminar el salto de línea

                if(dgvNiveles.SelectedRows.Count == 1)
                {
                    switch(opc)//Evaluar la Opción
                    {
                        case 1://Ver Detalles
                            NivelDetails nivelD = new NivelDetails((int)dgvNiveles.SelectedRows[0].Cells[0].Value);//Instancia de la forma
                            nivelD.MdiParent = this.MdiParent;
                            nivelD.Show();
                            break;
                        case 2:// Editar
                            NivelEdit nivelE = new NivelEdit((int)dgvNiveles.SelectedRows[0].Cells[0].Value);
                            nivelE.MdiParent = this.MdiParent;
                            nivelE.Show();
                            break;
                    }
                }
            }
        }
        // Botón Cerrar la Lista
        private void cmdOUT_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
