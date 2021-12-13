using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JuegoPeliculas
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private PeliculasVM peliculasVM;
        public MainWindow()
        {
            InitializeComponent();
            peliculasVM = new PeliculasVM();
            this.DataContext = peliculasVM;
        }

        private void VerPistaCheckbox_Click(object sender, RoutedEventArgs e)
        {
            PistaTextBlock.Visibility = Visibility.Visible;
        }

        private void SeleccionarJsonButton_Click(object sender, RoutedEventArgs e)
        {
            peliculasVM.CargarJson();
        }

        // Método para guardar en un archivo JSON todas las películas cargadas
        private void GuardarJsonButton_Click(object sender, RoutedEventArgs e)
        { 
            DialogService.SaveFileDialogService(JsonService.ExportarAJson(peliculasVM.ListaPeliculas));
        }

        // Método para añadir una película mediante el formulario a la lista de películas 
        private void AñadirPeliculaButton_Click(object sender, RoutedEventArgs e)
        {
            peliculasVM.AñadirPelicula();
        }

        // Método que nos permite eliminar una película de la lista de películas
        private void EliminarPeliculaButton_Click(object sender, RoutedEventArgs e)
        {
            peliculasVM.EliminarPelicula();
        }

        // Método que nos permite elegir una imagen de nuestro ordenador y establecerla como cartel de la nueva película
        private void ElegirImagenButton_Click(object sender, RoutedEventArgs e)
        {
            DialogService.OpenFileDialogService("imagen");
            // AzureImageService nos devuelve una URL de azure de la imagen seleccionada
            String urlImagen = AzureService.AzureImageService(DialogService.ArchivoSeleccionado);
            ImagenTextBox.Text = urlImagen;
        }
    }
}
