using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private ObservableCollection<string> generos;

        public ObservableCollection<string> Generos
        {
            get { return generos; }
            set { SetProperty(ref generos, value); }
        }

        public static ObservableCollection<Pelicula> GetSamples()
        {
            string peliculasJson = File.ReadAllText("peliculas.json");

            ObservableCollection<Pelicula> lista = JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(peliculasJson);

            return lista;
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

        public PeliculasVM()
        {
            listaPeliculas = GetSamples();
            PeliculaActual = listaPeliculas.FirstOrDefault();
            generos = GetGeneros();
            nivelesDificultad = GetDificultades();
        }

    }
}
