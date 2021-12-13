using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JuegoPeliculas
{
    class ListaPeliculasNullException : Exception
    {
        public ListaPeliculasNullException()
        {
            DialogService.MessageBoxService("No existe una Lista de Peliculas a la que añadir una película, prueba a cargar un archivo JSON",
                                                "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }

    class PeliculaNuevaCampoVacioNuloException : Exception
    {
        public PeliculaNuevaCampoVacioNuloException()
        {
            DialogService.MessageBoxService("Completa todos los campos para crear una nueva película",
                                                "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
