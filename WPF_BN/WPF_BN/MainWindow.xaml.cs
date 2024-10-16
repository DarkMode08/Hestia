using Microsoft.Win32; // Para SaveFileDialog y OpenFileDialog
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Windows.Threading;
using IOPath = System.IO.Path;

namespace WPF_BN
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CargarArchivosTxt();
        }
        private void Windows_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }
        private void btnMinimize_click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void btnMaximize_click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
            {
                this.WindowState = WindowState.Normal;
                _Border0.CornerRadius = new CornerRadius(10);
            }
            else
            {
                _Border0.CornerRadius = new CornerRadius(0);
                this.WindowState = WindowState.Maximized;
            }
        }
        private void btnClose_click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void btnCollapse_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnFiles_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Crear un nuevo OpenFileDialog para abrir un txt
                Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog();
                openFileDialog.Filter = "Archive txt|*.txt|All Archive|*.*";

                // Mostrar el diálogo de abrir archivo y verificar si el usuario seleccionó un archivo
                if (openFileDialog.ShowDialog() == true) // Devuelve true si el usuario seleccionó un archivo
                {
                    // Guardar la ruta completa del archivo seleccionado
                    currentFilePath = openFileDialog.FileName;

                    // Actualizar la carpetaNotas con la carpeta donde está el archivo
                    carpetaNotas = IOPath.GetDirectoryName(currentFilePath);

                    // Leer el archivo seleccionado usando StreamReader
                    using (StreamReader readFileDialog = new StreamReader(currentFilePath))
                    {
                        // Crear un TextRange para establecer el contenido del RichTextBox
                        TextRange textRange = new TextRange(RichTextBox1.Document.ContentStart, RichTextBox1.Document.ContentEnd);

                        // Establecer el texto leído en el RichTextBox
                        textRange.Text = readFileDialog.ReadToEnd();
                    }

                    // Recargar los archivos .txt de la nueva carpeta
                    CargarArchivosTxt();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el archivo: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBookMark_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnNewNote_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Crear un nuevo SaveFileDialog para guardar un nuevo archivo txt
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
                saveFileDialog.Title = "Save New Note";

                // Mostrar el diálogo de guardar archivo y verificar si el usuario seleccionó una ubicación
                if (saveFileDialog.ShowDialog() == true)
                {
                    // Obtener la ruta del archivo seleccionado
                    string filePath = saveFileDialog.FileName;

                    // Crear un archivo de texto vacío en la ruta seleccionada
                    using (StreamWriter writer = new StreamWriter(filePath))
                    {
                        writer.Write(""); // Escribir contenido vacío en el archivo
                    }

                    // Actualizar el archivo actual con la nueva ruta
                    currentFilePath = filePath;

                    // Limpiar el contenido del RichTextBox
                    RichTextBox1.Document.Blocks.Clear();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear la nota: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void btnNewFolder_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnChangeSortOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCollapseAll_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnViewVault_Click(object sender, RoutedEventArgs e)
        {
            CargarArchivosTxt();
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {

        }

        private void RichTextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            RichTextBox1.TextChanged += (s, ev) => _Count = true;

            saveTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };

            saveTimer.Tick += (s, ev) =>
            {
                try
                {
                    if (_Count && !string.IsNullOrEmpty(currentFilePath))
                    {
                        TextRange range = new TextRange(RichTextBox1.Document.ContentStart, RichTextBox1.Document.ContentEnd);

                        using (StreamWriter writer = new StreamWriter(currentFilePath))
                        {
                            writer.Write(range.Text);
                        }

                        _Count = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al guardar el archivo: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            };

            saveTimer.Start();
        }

        private void CargarArchivosTxt()
        {
            try
            {
                // Limpiar el StackPanel si ya tiene contenido
                FileListStackPanel.Children.Clear();

                if (!string.IsNullOrEmpty(carpetaNotas) && Directory.Exists(carpetaNotas))
                {
                    // Obtener todos los archivos .txt de la carpeta
                    string[] archivosTxt = Directory.GetFiles(carpetaNotas, "*.txt");

                    // Crear un botón para cada archivo .txt y agregarlo al StackPanel
                    foreach (string archivo in archivosTxt)
                    {
                        Button btnArchivo = new Button
                        {
                            Content = IOPath.GetFileName(archivo),
                            Tag = archivo,
                            Margin = new Thickness(5),
                            HorizontalAlignment = HorizontalAlignment.Stretch
                        };

                        // Añadir un evento Click al botón para abrir el archivo
                        btnArchivo.Click += BtnArchivo_Click;

                        // Agregar el botón al StackPanel
                        FileListStackPanel.Children.Add(btnArchivo);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar los archivos: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnArchivo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Obtener el botón que fue clickeado
                Button boton = sender as Button;

                if (boton != null)
                {
                    // Obtener la ruta del archivo desde la propiedad Tag del botón
                    string rutaArchivo = boton.Tag.ToString();

                    // Leer el contenido del archivo y mostrarlo en el RichTextBox
                    string contenido = File.ReadAllText(rutaArchivo);
                    RichTextBox1.Document.Blocks.Clear(); // Limpiar el RichTextBox
                    RichTextBox1.Document.Blocks.Add(new Paragraph(new Run(contenido)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al abrir el archivo: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private string currentFilePath;
        private DispatcherTimer saveTimer;
        private bool _Count = false;
        //private string carpetaNotas = @"C:\RutaDeTuCarpeta"; // Cambia esta ruta por la que estés utilizando.
        private string carpetaNotas = string.Empty; // Inicialmente vacío, se actualizará cuando se abra un archivo
    }
}