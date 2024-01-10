﻿using System.ComponentModel.DataAnnotations;

namespace BackendPiendraPapelTijeras.Context.Models
{
    public class Turno
    {
        [Key]
        public int IdTurno { get; set; }
        public int IdPartida { get; set; }
        public Partida Partida { get; set; }
        public int? IdJugadorGanador { get; set; }
        public Jugador? Ganador { get; set; }
        public DateTime FechaRegistro { get; set; }
    }
}