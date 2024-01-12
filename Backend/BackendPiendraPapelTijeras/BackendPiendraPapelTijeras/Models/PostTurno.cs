using System.ComponentModel.DataAnnotations;

namespace BackendPiendraPapelTijeras.Models
{
    public class PostTurno
    {
        [Required]
        public int IdPartida { get; set; }

        public int? IdJugadorGanador { get; set; }
    }
}