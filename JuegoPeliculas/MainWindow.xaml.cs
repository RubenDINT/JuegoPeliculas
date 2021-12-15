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
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace JuegoPeliculas
{
    public partial class MainWindow : Window
    {
        private PeliculasVM peliculasVM;
        private Partida partida;
        public MainWindow()
        {
            InitializeComponent();
            peliculasVM = new PeliculasVM();
            this.DataContext = peliculasVM;
        }

        private void DeshabilitarBotones()
        {
            NuevaPartidaButton.IsEnabled = false;
            FinalizarPartidaButton.IsEnabled = false;
            ValidarButton.IsEnabled = false;
            VerPistaCheckbox.IsEnabled = false;
            EntradaUsuarioTextBox.IsEnabled = false;
        }

        private void HabilitarBotones()
        {
            NuevaPartidaButton.IsEnabled = true;
            FinalizarPartidaButton.IsEnabled = true;
            ValidarButton.IsEnabled = true;
            VerPistaCheckbox.IsEnabled = true;
            EntradaUsuarioTextBox.IsEnabled = true;
        }

        private void VerPistaCheckbox_Click(object sender, RoutedEventArgs e)
        {
            PistaTextBlock.Visibility = Visibility.Visible;
        }

        private void SeleccionarJsonButton_Click(object sender, RoutedEventArgs e)
        {
            peliculasVM.CargarJson();
            NuevaPartidaButton.IsEnabled = true;
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
            peliculasVM.ElegirImagen();
        }

        // Método para comprobar si la entrada del usuario es la película que tiene que acertar
        private void ValidarButton_Click(object sender, RoutedEventArgs e)
        {
            string entradaUsuario = EntradaUsuarioTextBox.Text.ToUpper();
            if(entradaUsuario == peliculasVM.PeliculaActual.Titulo.ToUpper())
            {
                partida.PeliculaAcertada();
            }
            else
            {
                DialogService.MessageBoxService("Has Fallado",
                                               "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Método para empezar una nueva partida
        private void NuevaPartidaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Comprobación para saber si en la lista de películas hay mas de 5, si no se lanza una excepción
                if (peliculasVM.ListaPeliculas.Count >= 5)
                {
                    HabilitarBotones();
                    partida = new Partida();
                }
                else throw new CantidadPeliculasException();
            }
            catch (CantidadPeliculasException)
            {
                DialogService.MessageBoxService("La cantidad de películas para empezar la partida debe ser igual o mayor que 5",
                                               "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Método para ver la pista de la película (la puntuación baja a la mitad)
        private void VerPistaCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            int puntuacionActual = partida.PuntuacionPeliculaActual;
            int puntuacionRebajada = partida.PuntuacionPeliculaActual /= 2;

            MessageBoxResult mbr = DialogService.MessageBoxServiceWithResult($"La puntuación de la película bajará de {puntuacionActual} a {puntuacionRebajada},\n¿Estás de acuerdo?",
                                               "Info", MessageBoxButton.OKCancel, MessageBoxImage.Information);

            // ??
            if(mbr == MessageBoxResult.OK) PistaTextBlock.Visibility = Visibility.Visible;
            else PistaTextBlock.Visibility = Visibility.Hidden;
        }
    }
}
