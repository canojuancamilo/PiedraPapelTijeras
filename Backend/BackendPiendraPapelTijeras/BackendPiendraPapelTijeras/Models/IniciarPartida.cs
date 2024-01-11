using System.ComponentModel.DataAnnotations;

namespace BackendPiendraPapelTijeras.Models
{
    public class IniciarPartida
    {
        [Required]
        public string PrimerJugador { get; set; }

        [Required]
        public string SegundoJugador { get; set; }
    }
}
