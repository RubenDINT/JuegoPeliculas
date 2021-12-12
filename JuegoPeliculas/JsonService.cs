using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoPeliculas
{
    class JsonService
    {
        public static void ExportarAJson(ObservableCollection<Pelicula> lista)
        {
            string peliculasJson = JsonConvert.SerializeObject(lista);
            File.WriteAllText("peliculas.json", peliculasJson);
        }

        public static ObservableCollection<Pelicula> ImportarJson(string archivo)
        {
            string peliculasJson = File.ReadAllText(archivo);
            ObservableCollection<Pelicula> lista = JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(peliculasJson);

            return lista;
        }
    }
}
