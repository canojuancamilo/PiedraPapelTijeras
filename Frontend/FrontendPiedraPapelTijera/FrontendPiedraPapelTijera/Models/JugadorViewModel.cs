using System.ComponentModel;

namespace FrontendPiedraPapelTijera.Models
{
    public class JugadorViewModel
    {
        [DisplayName("Id jugador")]
        public int IdJugador { get; set; }

        [DisplayName("Id nombre")]
        public string Nombre { get; set; }

        [DisplayName("Id partia")]
        public int IdPartida { get; set; }

        public PartidaViewModel Partida { get; set; }
    }
}
