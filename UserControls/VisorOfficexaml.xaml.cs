﻿using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace SADI.UserControls
{
    /// <summary>
    /// Control del Visor Office
    /// </summary>
    public partial class VisorOfficexaml : System.Windows.Controls.UserControl
    {
        System.Windows.Xps.Packaging.XpsDocument xpsDoc;
        public static bool officeFileOpen_Status = false;

        /// <summary>
        /// 
        /// </summary>
        public VisorOfficexaml()
        {
            InitializeComponent();
        }

        private void OpenSourceFile_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            string xpsFilePath = String.Empty;
            // Filtro para seleccionar documentos de Office 
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Office Files(*.docx;*.doc;*.xlsx;*.xls;*.pptx;*.ppt)|*.docx;*.doc;*.xlsx;*.xls;*.pptx;*.ppt";

            // Mostrar OpenFileDialog a través del método ShowDialog 
            Nullable<bool> result = dlg.ShowDialog();

            //Tomar el Nombre del Archivo Seleccionado y mostrarlos en el TextBox
            if (result == true)
            {
                string filename = dlg.FileName;//Guardar el Nombre del Archivo
                xpsFilePath = System.Environment.CurrentDirectory + "\\" + dlg.SafeFileName + ".xps";// Cambiar el Nombre del Archivo (extensión)
                SourceUrl.Text = filename;//Indicarle el Nombre del Archivo a la fuente
            }

            var convertResults = OfficeToXps.ConvertToXps(SourceUrl.Text, ref xpsFilePath);//Conversión del archivo a XPS
            switch (convertResults.Result)//Evaluar la Conversión
            {
                case ConversionResult.OK://Conversión Correcta
                    xpsDoc = new System.Windows.Xps.Packaging.XpsDocument(xpsFilePath, FileAccess.ReadWrite);//Asignar el Documento XPS
                    documentViewer1.Document = xpsDoc.GetFixedDocumentSequence();
                    officeFileOpen_Status = true;
                    break;

                case ConversionResult.InvalidFilePath:
                    // Handle bad file path or file missing
                    break;
                case ConversionResult.UnexpectedError:
                    // This should only happen if the code is modified poorly
                    break;
                case ConversionResult.ErrorUnableToInitializeOfficeApp:
                    // Handle Office 2007 (Word | Excel | PowerPoint) not installed
                    break;
                case ConversionResult.ErrorUnableToOpenOfficeFile:
                    // Handle source file being locked or invalid permissions
                    break;
                case ConversionResult.ErrorUnableToAccessOfficeInterop:
                    // Handle Office 2007 (Word | Excel | PowerPoint) not installed
                    break;
                case ConversionResult.ErrorUnableToExportToXps:
                    // Handle Microsoft Save As PDF or XPS Add-In missing for 2007
                    break;
            }
        }

        private void ConvertImages_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (officeFileOpen_Status)
                {


                    FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                    DialogResult result = folderBrowserDialog1.ShowDialog();
                    string localpath = String.Empty;
                    localpath = folderBrowserDialog1.SelectedPath;

                    FixedDocumentSequence seq;
                    seq = xpsDoc.GetFixedDocumentSequence();
                    DocumentPaginator paginator = seq.DocumentPaginator;
                    //// I only want the all page for this example
                    for (int i = 0; i < paginator.PageCount; i++)
                    {
                        Visual visual = paginator.GetPage(i).Visual;
                        FrameworkElement fe = (FrameworkElement)visual;
                        int multiplyFactor = 4;
                        string outputPath = localpath + "\\page" + i + ".png";
                        Console.WriteLine(localpath);
                        RenderTargetBitmap bmp = new RenderTargetBitmap(
                            (int)fe.ActualWidth * multiplyFactor,
                            (int)fe.ActualHeight * multiplyFactor,
                            96d * multiplyFactor,
                            96d * multiplyFactor,
                            PixelFormats.Default);
                        bmp.Render(fe);
                        PngBitmapEncoder png = new PngBitmapEncoder();
                        png.Frames.Add(BitmapFrame.Create(bmp));
                        using (Stream stream = File.Create(outputPath))
                        {
                            png.Save(stream);
                        }
                    }

                    System.Windows.MessageBox.Show("Images Saved Successfully", "Status", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    System.Windows.MessageBox.Show("Please select a office File (*.docx,*.doc,*.els,*.elsx,*.ppt,*.pptx)", "Select a MS Office File", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Please Select a Folder Loaction to Store the Images", "Select a Folder Loaction", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        /// <summary>
        /// Método para la Selección de Una Sola Página
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Single_Page_Image_Click(object sender, RoutedEventArgs e)
        {
            MyPopUp.IsOpen = true;
            MyPopUp.Placement = System.Windows.Controls.Primitives.PlacementMode.MousePoint;
            MyPopUp.PlacementTarget = Single_Page_Image;
            Keyboard.Focus(PageNumberBox);
        }
        /// <summary>
        /// Salvar una sola Página como Imagen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SinglePageImage_Click(object sender, RoutedEventArgs e)
        {
            MyPopUp.IsOpen = false;
            try
            {
                if (officeFileOpen_Status)
                {
                    FixedDocumentSequence seq;
                    seq = xpsDoc.GetFixedDocumentSequence();
                    DocumentPaginator paginator = seq.DocumentPaginator;
                    if (int.Parse(PageNumberBox.Text) < paginator.PageCount)
                    {
                        FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                        DialogResult result = folderBrowserDialog1.ShowDialog();
                        string localpath = String.Empty;
                        localpath = folderBrowserDialog1.SelectedPath;
                        //// I only want the all page for this example

                        Visual visual = paginator.GetPage((int.Parse(PageNumberBox.Text) - 1)).Visual;
                        FrameworkElement fe = (FrameworkElement)visual;
                        int multiplyFactor = 4;
                        string outputPath = localpath + "\\page" + (int.Parse(PageNumberBox.Text) - 1) + ".png";
                        Console.WriteLine(localpath);
                        RenderTargetBitmap bmp = new RenderTargetBitmap(
                            (int)fe.ActualWidth * multiplyFactor,
                            (int)fe.ActualHeight * multiplyFactor,
                            96d * multiplyFactor,
                            96d * multiplyFactor,
                            PixelFormats.Default);
                        bmp.Render(fe);
                        PngBitmapEncoder png = new PngBitmapEncoder();
                        png.Frames.Add(BitmapFrame.Create(bmp));
                        using (Stream stream = File.Create(outputPath))
                        {
                            png.Save(stream);
                        }
                        System.Windows.MessageBox.Show("Image Saved Successfully", "Status", MessageBoxButton.OK, MessageBoxImage.Information);
                    }

                    else
                    {
                        System.Windows.MessageBox.Show("Given Page Number is Greater than Number of pages in the Document", "Page Number Overflow", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }

                else
                {
                    System.Windows.MessageBox.Show("Please select a office File (*.docx,*.doc,*.els,*.elsx,*.ppt,*.pptx)", "Select a MS Office File", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Please Select a Folder Loaction to Store the Images", "Select a Folder Loaction", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        /// <summary>
        /// Método para guardar la Ruta de la Conversión
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DestinationLoaction_Click(object sender, RoutedEventArgs e)
        {
            if (officeFileOpen_Status)
            {
                FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
                DialogResult result = folderBrowserDialog1.ShowDialog();
                string localpath = String.Empty;
                localpath = folderBrowserDialog1.SelectedPath + "\\OutputXpsDocument.xps";
                var convertResults = OfficeToXps.ConvertToXps(SourceUrl.Text, ref localpath);

                switch (convertResults.Result)
                {
                    case ConversionResult.OK:
                        System.Windows.Xps.Packaging.XpsDocument xpsDoc = new System.Windows.Xps.Packaging.XpsDocument(localpath, FileAccess.ReadWrite);
                        break;

                    case ConversionResult.InvalidFilePath:
                        System.Windows.MessageBox.Show("Files Missing in the mentioned Path", "InValid Path", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case ConversionResult.UnexpectedError:
                        // This should only happen if the code is modified poorly
                        break;
                    case ConversionResult.ErrorUnableToInitializeOfficeApp:
                        System.Windows.MessageBox.Show("Microsoft Office not Installed in the Machine", "Software Incompatibility", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case ConversionResult.ErrorUnableToOpenOfficeFile:
                        // Handle source file being locked or invalid permissions
                        break;
                    case ConversionResult.ErrorUnableToAccessOfficeInterop:
                        System.Windows.MessageBox.Show("Microsoft Office not Installed in the Machine", "Software Incompatibility", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    case ConversionResult.ErrorUnableToExportToXps:
                        // Handle Microsoft Save As PDF or XPS Add-In missing for 2007
                        break;
                }
                System.Windows.MessageBox.Show("File Saved Successfully", "Status", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                System.Windows.MessageBox.Show("Please select a office File (*.docx,*.doc,*.els,*.elsx,*.ppt,*.pptx)", "Select a MS Office File", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
