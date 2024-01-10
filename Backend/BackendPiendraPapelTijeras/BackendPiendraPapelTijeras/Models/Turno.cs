using System.ComponentModel.DataAnnotations;

namespace BackendPiendraPapelTijeras.Models
{
    public class Turno
    {
        [Key]
        public int IdTurno { get; set; }
        public int IdPartida { get; set; }
        public Partida Partida { get; set; }
        public string Resultado { get; set; }
        public int? IdJugadorGanador { get; set; }
        public Jugador? Ganador { get; set; }
    }
}
