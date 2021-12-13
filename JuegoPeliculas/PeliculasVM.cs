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
        private Pelicula peliculaActual;

        public Pelicula PeliculaActual
        {
            get { return peliculaActual; }
            set { SetProperty(ref peliculaActual, value); }
        }

        private ObservableCollection<Pelicula> listaPeliculas;

        public ObservableCollection<Pelicula> ListaPeliculas
        {
            get { return listaPeliculas; }
            set { SetProperty(ref listaPeliculas, value); }
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


        public static ObservableCollection<Pelicula> GetSamples() => JsonService.ImportarJson(DialogService.ArchivoSeleccionado);

        public void CargarJson()
        {
            DialogService.OpenFileDialogService("json");
            ListaPeliculas = GetSamples();
            PeliculaActual = listaPeliculas.FirstOrDefault();
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

        // Método para añadir una película a la lista de películas
        public void AñadirPelicula()
        {
            try
            {
                // Comprobamos al antes de añadir la película si la Lista de peliculas está vacía
                // O si alguno de los campos para crear una película está vacío
                if (ListaPeliculas == null) throw new ListaPeliculasNullException();
                else if (string.IsNullOrEmpty(PeliculaNueva.Titulo) || string.IsNullOrEmpty(PeliculaNueva.Pista) ||
                         string.IsNullOrEmpty(PeliculaNueva.Cartel) || string.IsNullOrEmpty(PeliculaNueva.Genero) ||
                         string.IsNullOrEmpty(PeliculaNueva.Nivel))
                {
                    throw new PeliculaNuevaCampoVacioNuloException();
                }
                else
                {
                    ListaPeliculas.Add(PeliculaNueva);
                    DialogService.MessageBoxService($"Película {PeliculaNueva.Titulo} añadida",
                                               "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            catch (ListaPeliculasNullException)
            {

            }
            catch (PeliculaNuevaCampoVacioNuloException)
            {

            }
        }

        // Método para eliminar una película a la lista de películas
        public void EliminarPelicula()
        {
            try
            {
                // Comprobamos al antes de añadir la película si la Lista de peliculas está vacía
                if (ListaPeliculas == null) throw new ListaPeliculasNullException();
                else
                {
                    ListaPeliculas.Remove(PeliculaActual);
                    DialogService.MessageBoxService($"Película {PeliculaActual.Titulo} eliminada",
                                               "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                }

            }
            catch (ListaPeliculasNullException)
            {

            }
        }
        public PeliculasVM()
        {
            PeliculaNueva = new Pelicula();
            Generos = GetGeneros();
            NivelesDificultad = GetDificultades();

        }

    }
}
