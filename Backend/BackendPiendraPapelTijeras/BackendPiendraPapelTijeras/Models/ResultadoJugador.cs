using System.ComponentModel.DataAnnotations;

namespace BackendPiendraPapelTijeras.Models
{
    public class ResultadoJugador
    {
        public int IdJugador { get; set; }

        public string Nombre { get; set; }

        public int TurnosGanados { get; set; }

        public int TurnosEmpatados { get; set; }

        public int TurnosPerdidos { get; set; }
    }
}
