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
        private int turnos;

        public int Turnos
        {
            get { return turnos; }
            set { SetProperty(ref turnos, value); }
        }

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

        private int puntuacionTotalPosible;

        public int PuntuacionTotalPosible
        {
            get { return puntuacionTotalPosible; }
            set { SetProperty(ref puntuacionTotalPosible, value); }
        }


        private bool partidaEmpezada = false;

        public bool PartidaEmpezada
        {
            get { return partidaEmpezada; }
            set { SetProperty(ref partidaEmpezada, value); }
        }
        public Partida()
        {
            PuntuacionTotalPartida = 0;
            PuntuacionTotalPosible = 0;
            turnos = 0;
        }
    }
}
