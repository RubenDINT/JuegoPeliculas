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
        // Método al que le pasas una lista y te devuelve un string formato JSON
        public static string ExportarAJson(ObservableCollection<Pelicula> lista)
        {
            return JsonConvert.SerializeObject(lista);         
        }

        // Método al que le pasas el path de un archivo y te devuelve una lista 
        public static ObservableCollection<Pelicula> ImportarJson(string archivo)
        {
            string peliculasJson = File.ReadAllText(archivo);
            return JsonConvert.DeserializeObject<ObservableCollection<Pelicula>>(peliculasJson);
        }
    }
}
