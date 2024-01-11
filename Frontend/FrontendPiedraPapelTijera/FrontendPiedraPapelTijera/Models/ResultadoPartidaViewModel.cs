using System.ComponentModel;

namespace FrontendPiedraPapelTijera.Models
{
    public class ResultadoPartidaViewModel
    {
        [DisplayName("Id")]
        public int IdJugador { get; set; }

        [DisplayName("Jugador")]
        public string Nombre { get; set; }

        [DisplayName("Victorias")]
        public int TurnosGanados { get; set; }

        [DisplayName("Empates")]
        public int TurnosEmpatados { get; set; }

        [DisplayName("Perdidas")]
        public int TurnosPerdidos { get; set; }
    }
}
