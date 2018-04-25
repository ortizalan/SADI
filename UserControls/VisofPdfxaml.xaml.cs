using System.Windows;
using System.Windows.Controls;
using SADI.Clases;


namespace SADI.UserControls
{
    /// <summary>
    /// Interaction logic for VisofPdfxaml.xaml
    /// </summary>
    public partial class VisofPdfxaml : UserControl
    {
        public VisofPdfxaml()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            pdfViewer.LoadFile(Utilerias.Path);//Cargar el Archivo PDF
        }
    }
}
