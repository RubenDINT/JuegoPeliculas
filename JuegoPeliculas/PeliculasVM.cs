using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;

namespace JuegoPeliculas
{
    class PeliculasVM : ObservableObject
    {
        private Random seed = new Random();

        #region Campos y propiedades de Partida
        private Partida partida;

        public Partida Partida
        {
            get { return partida; }
            set { SetProperty(ref partida, value); }
        }

        private String entradaUsuario = "";

        public String EntradaUsuario
        {
            get { return entradaUsuario; }
            set { SetProperty(ref entradaUsuario, value); }
        }

        private Boolean peliculasDisponibles = false;

        public Boolean PeliculasDisponibles
        {
            get { return peliculasDisponibles; }
            set { SetProperty(ref peliculasDisponibles, value); }
        }

        private bool pistaRevelada = false;

        public bool PistaRevelada
        {
            get { return pistaRevelada; }
            set { SetProperty(ref pistaRevelada, value); }
        }

        #endregion

        #region Campos y propiedades de Pelicula
        private Pelicula peliculaActual;

        public Pelicula PeliculaActual
        {
            get { return peliculaActual; }
            set { SetProperty(ref peliculaActual, value); }
        }

        private bool partidaEmpezada = false;

        public bool PartidaEmpezada
        {
            get { return partidaEmpezada; }
            set { SetProperty(ref partidaEmpezada, value); }
        }

        private ObservableCollection<Pelicula> listaPeliculas;

        public ObservableCollection<Pelicula> ListaPeliculas
        {
            get { return listaPeliculas; }
            set { SetProperty(ref listaPeliculas, value); }
        }

        private ObservableCollection<Pelicula> peliculasUsadas = new ObservableCollection<Pelicula>();

        public  ObservableCollection<Pelicula> PeliculasUsadas
        {
            get { return peliculasUsadas; }
            set { SetProperty(ref peliculasUsadas, value); }
        }


        private ObservableCollection<string> nivelesDificultad;

        public ObservableCollection<string> NivelesDificultad
        {
            get { return nivelesDificultad; }
            set { SetProperty(ref nivelesDificultad, value); }
        }

        private Pelicula peliculaNueva;

        public Pelicula PeliculaNueva
        {
            get { return peliculaNueva; }
            set { SetProperty(ref peliculaNueva, value); }
        }


        private ObservableCollection<string> generos;

        public ObservableCollection<string> Generos
        {
            get { return generos; }
            set { SetProperty(ref generos, value); }
        }

        private Pelicula pelicula;

        public Pelicula Pelicula
        {
            get { return pelicula; }
            set { SetProperty(ref pelicula, value); }
        }
        #endregion

        public PeliculasVM()
        {
            PeliculaNueva = new Pelicula();
            Generos = GetGeneros();
            NivelesDificultad = GetDificultades();
            ListaPeliculas = new ObservableCollection<Pelicula>();
            PeliculaActual = new Pelicula();


            Partida = new Partida();
        }

        #region Métodos Pelicula
        public static ObservableCollection<Pelicula> GetSamples() => JsonService.ImportarJson(DialogService.ArchivoSeleccionado);

        // Método que devuelve una película aleatoria entre la Lista de películas
        public Pelicula ElegirPeliculaAleatoria() => ListaPeliculas.ElementAt(seed.Next(ListaPeliculas.Count));

        public void CargarJson()
        {
            DialogService.OpenFileDialogService("json");
            ListaPeliculas = GetSamples();
            PeliculaActual = ElegirPeliculaAleatoria();
            PeliculasDisponibles = true;
        }

        public static ObservableCollection<string> GetDificultades()
        {
            ObservableCollection<string> lista = new ObservableCollection<string>();

            lista.Add("Fácil");
            lista.Add("Media");
            lista.Add("Difícil");

            return lista;
        }

        public static ObservableCollection<string> GetGeneros()
        {
            ObservableCollection<string> lista = new ObservableCollection<string>();

            lista.Add("Ciencia-Ficción");
            lista.Add("Terror");
            lista.Add("Comedia");
            lista.Add("Drama");
            lista.Add("Acción");

            return lista;
        }

        public void LimpiarSeleccion()
        {
            if (!string.IsNullOrEmpty(PeliculaActual.Titulo))
            {
                PeliculaActual = new Pelicula();
                DialogService.MessageBoxService("Rellena los campos del formulario para añadir una película",
                                               "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        // Método para añadir una película a la lista de películas
        public void AñadirPelicula()
        {
            try
            {
                // Comprobamos si alguno de los campos para crear una película está vacío
                if (string.IsNullOrEmpty(PeliculaActual.Titulo) || string.IsNullOrEmpty(PeliculaActual.Pista) ||
                         string.IsNullOrEmpty(PeliculaActual.Cartel) || string.IsNullOrEmpty(PeliculaActual.Genero) ||
                         string.IsNullOrEmpty(PeliculaActual.Nivel))
                {
                    throw new PeliculaNuevaCampoVacioNuloException();
                }
                else
                {
                    ListaPeliculas.Add(PeliculaActual);
                    PeliculasDisponibles = true;
                    DialogService.MessageBoxService($"Película {PeliculaNueva.Titulo} añadida",
                                               "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (ListaPeliculasNullException)
            {
                DialogService.MessageBoxService("No existe una Lista de Peliculas a la que añadir una película, prueba a cargar un archivo JSON",
                                                "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            catch (PeliculaNuevaCampoVacioNuloException)
            {
                DialogService.MessageBoxService("Completa todos los campos para crear una nueva película",
                                                "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Método para eliminar una película a la lista de películas
        public void EliminarPelicula()
        {
            try
            {
                // Comprobamos al antes de añadir la película si la Lista de peliculas está vacía
                if (PeliculaActual == null) throw new PeliculaActualNullException();
                else
                {
                    DialogService.MessageBoxService($"Película {PeliculaActual.Titulo} eliminada",
                                               "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    ListaPeliculas.Remove(PeliculaActual);
                    
                }

            }
            catch (PeliculaActualNullException)
            {
                DialogService.MessageBoxService("Selecciona una Pelicula para borrarla",
                                                "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Método para elegir una imagen de nuestro ordenador, y obtener la url mediante Azure
        public void ElegirImagen()
        {
            try
            {
                DialogService.OpenFileDialogService("imagen");
                // AzureImageService nos devuelve una URL de azure de la imagen seleccionada
                PeliculaNueva.Cartel = AzureService.AzureImageService(DialogService.ArchivoSeleccionado);
            }
            catch (Exception)
            {
                DialogService.MessageBoxService("Error con Azure","Error", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Método que nos permite guardar el JSON cargado 
        public void GuardarJson()
        {
            DialogService.SaveFileDialogService(JsonService.ExportarAJson(ListaPeliculas));
        }
        #endregion

        #region Métodos Partida
        public void EmpezarNuevaPartida()
        {
            try
            {
                // Comprobación para saber si en la lista de películas hay mas de 5, si no se lanza una excepción
                if (ListaPeliculas.Count >= 5)
                {
                    Partida.PartidaEmpezada = true;
                    SetPuntosPeliculaActual();
                    DialogService.MessageBoxService("Partida Empezada",
                                              "Info", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                else throw new CantidadPeliculasException();
            }
            catch (CantidadPeliculasException)
            {
                DialogService.MessageBoxService("La cantidad de películas para empezar la partida debe ser igual o mayor que 5",
                                               "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Método que valida la entrada del usuario, y si este acierta, se encarga de asignar los puntos correspondientes
        public void ValidarEntradaUsuario()
        {
            if(EntradaUsuario.ToUpper() == PeliculaActual.Titulo.ToUpper())
            {
                Partida.PeliculaAcertada();
                DialogService.MessageBoxService($"Has acertado, has ganado {Partida.PuntuacionPeliculaActual} puntos",
                                   "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                SetPuntosPeliculaActual();

                if (partida.Turnos == 5) FinPartida();
                else SiguientePelicula();

                PistaRevelada = false;
            }
            else
            {
                DialogService.MessageBoxService("Has Fallado",
                                               "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Método que ocurre al finalizar la partida por turnos, o al pulsar el botón Finalizar Partida
        public void FinPartida()
        {
            DialogService.MessageBoxService($"Fin de Partida! Has ganado un total de {partida.PuntuacionTotalPartida} puntos ",
                                   "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            Partida.PartidaEmpezada = false;
        }

        // Método que cambia a la siguiente película
        public void SiguientePelicula()
        {
            Pelicula siguiente;

            // Añadimos a la lista de peliculas usadas la película actual
            PeliculasUsadas.Add(PeliculaActual);

            // Generamos otra película aleatoriamente
            do
            {
                siguiente = ElegirPeliculaAleatoria();
            } while (!ListaPeliculas.Contains(siguiente));

            PeliculaActual = siguiente;
        }

        // Método que dependiendo de la dificultad de la película en juego, nos devulve sus puntos
        public void SetPuntosPeliculaActual()
        {
            int puntos = 0;
            switch(PeliculaActual.Nivel)
            {
                case "Fácil":
                    puntos = 10;
                    break;
                case "Media":
                    puntos = 20;
                    break;
                case "Difícil":
                    puntos = 40;
                    break;
                default:
                    break;
            }

            Partida.PuntuacionPeliculaActual = puntos;
        }

        // Método que mostrará la pista dependiendo de la opción que elija el usuario en el MessageBox
        public void VerPista()
        {
            MessageBoxResult mbr = 
                DialogService.MessageBoxServiceWithResult($"La puntuación de la película bajará de {Partida.PuntuacionPeliculaActual} a {Partida.PuntuacionPeliculaActual / 2},\n¿Estás de acuerdo?",
                                               "Info", MessageBoxButton.OKCancel, MessageBoxImage.Information);


            if (mbr == MessageBoxResult.OK && !PistaRevelada)
            {
                PistaRevelada = true;
                Partida.PuntuacionPeliculaActual /= 2;
            }
            else if (mbr == MessageBoxResult.OK && PistaRevelada)
            {
                DialogService.MessageBoxServiceWithResult("Ya has revelado la pista de esta película",
                                                          "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                DialogService.MessageBoxServiceWithResult("Suerte!",
                                                          "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        #endregion
    }
}
