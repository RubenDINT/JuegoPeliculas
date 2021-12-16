using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JuegoPeliculas
{
    class Partida : ObservableObject
    {
        private const int MINIMO_PELICULAS = 5;

        private int puntuacionTotalPartida;

        public int PuntuacionTotalPartida
        {
            get { return puntuacionTotalPartida; }
            set { SetProperty(ref puntuacionTotalPartida,value); }
        }

        private String respuestaUsuario;

        public String RespuestaUsuario
        {
            get { return respuestaUsuario; }
            set { SetProperty(ref respuestaUsuario, value); }
        }

        private int puntuacionPeliculaActual;

        public int PuntuacionPeliculaActual
        {
            get { return puntuacionPeliculaActual; }
            set { SetProperty(ref puntuacionPeliculaActual, value); }
        }

        private bool partidaEmpezada = false;

        public bool PartidaEmpezada
        {
            get { return partidaEmpezada; }
            set { SetProperty(ref partidaEmpezada, value); }
        }

        public void PeliculaAcertada()
        {
            DialogService.MessageBoxService($"Has acertado, has ganado {PuntuacionPeliculaActual} puntos",
                                               "Info", MessageBoxButton.OK, MessageBoxImage.Information);
            PuntuacionTotalPartida += PuntuacionPeliculaActual;

        }
        public Partida()
        {
            PuntuacionTotalPartida = 0;
        }
    }
}
