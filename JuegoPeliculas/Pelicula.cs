using Microsoft.Toolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.IO;

class Pelicula : ObservableObject
{
    private string titulo;
    public string Titulo
    {
        get { return titulo; }
        set { SetProperty(ref titulo, value); }
    }

    private string pista;
    public string Pista
    {
        get { return pista; }
        set { SetProperty(ref pista, value); }
    }

    private string cartel;
    public string Cartel
    {
        get { return cartel; }
        set { SetProperty(ref cartel, value); }
    }

    private string nivel;
    public string Nivel
    {
        get { return nivel; }
        set { SetProperty(ref nivel, value); }
    }

    private string genero;
    public string Genero
    {
        get { return genero; }
        set { SetProperty(ref genero, value); }
    }

    public Pelicula(string titulo, string pista, string cartel, string nivel, string genero)
    {
        Titulo = titulo;
        Pista = pista;
        Cartel = cartel;
        Nivel = nivel;
        Genero = genero;
    }

    public static ObservableCollection<Pelicula> GetSamples()
    {
        ObservableCollection<Pelicula> lista = new ObservableCollection<Pelicula>();

        string peliculasJson = File.ReadAllText("peliculas.json");

        lista = JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(peliculasJson);

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
}

