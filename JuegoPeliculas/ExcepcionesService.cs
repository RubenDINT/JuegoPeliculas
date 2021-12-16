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
            
        }
    }

    class PeliculaNuevaCampoVacioNuloException : Exception
    {
        public PeliculaNuevaCampoVacioNuloException()
        {
            
        }
    }

    class CantidadPeliculasException : Exception
    {
        public CantidadPeliculasException()
        {
            
        }

    }

    class PeliculaActualNullException : Exception
    {
        public PeliculaActualNullException()
        {

        }
    }

}
