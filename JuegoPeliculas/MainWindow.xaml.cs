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
using ComboBox = System.Windows.Controls.ComboBox;
using TextBox = System.Windows.Controls.TextBox;

namespace JuegoPeliculas
{
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
            // Trycatch para controlar si se cierra el dialogo de Json sin cargar ningun Json
            try
            {
                peliculasVM.CargarJson();
            }
            catch (Exception)
            {

            }
            
        }

        // Método para guardar en un archivo JSON todas las películas cargadas
        private void GuardarJsonButton_Click(object sender, RoutedEventArgs e)
        {
            peliculasVM.GuardarJson();
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
            peliculasVM.ValidarEntradaUsuario();
        }

        // Método para empezar una nueva partida
        private void NuevaPartidaButton_Click(object sender, RoutedEventArgs e)
        {
            peliculasVM.EmpezarNuevaPartida();
        }

        // Método para ver la pista de la película (la puntuación baja a la mitad)
        private void VerPistaCheckbox_Checked(object sender, RoutedEventArgs e)
        {
            peliculasVM.VerPista();
        }

        private void FinalizarPartidaButton_Click(object sender, RoutedEventArgs e)
        {
            peliculasVM.FinPartida();
        }

        private void LimpiarSeleccionButton_Click(object sender, RoutedEventArgs e)
        {
            peliculasVM.LimpiarSeleccion();
        }

        private void EditarPeliculaButton_Click(object sender, RoutedEventArgs e)
        {
            // Para que no se edite la película hasta pulsar el botón Editar Película
            BindingExpression beTitulo = TituloTextBox.GetBindingExpression(TextBox.TextProperty);
            BindingExpression bePista = PistaTextBox.GetBindingExpression(TextBox.TextProperty);
            BindingExpression beCartel = ImagenTextBox.GetBindingExpression(TextBox.TextProperty);
            BindingExpression beNivel = DificultadComboBox.GetBindingExpression(ComboBox.SelectedItemProperty);
            BindingExpression beGenero = GenerosComboBox.GetBindingExpression(ComboBox.SelectedItemProperty);
            beTitulo.UpdateSource();
            bePista.UpdateSource();
            beCartel.UpdateSource();
            beNivel.UpdateSource();
            beGenero.UpdateSource();
        }
    }
}
