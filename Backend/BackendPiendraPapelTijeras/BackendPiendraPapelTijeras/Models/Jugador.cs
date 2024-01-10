using System.ComponentModel.DataAnnotations;

namespace BackendPiendraPapelTijeras.Models
{
    public class Jugador
    {
        [Key]
        public int IdJugador { get; set; }
        public string Nombre { get; set; }
        public int IdPartida { get; set; }
        public Partida Partida { get; set; }
    }
}
