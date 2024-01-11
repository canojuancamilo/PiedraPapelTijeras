using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrontendPiedraPapelTijera.Models
{
    public class IniciarPartidaViewModel
    {
        [Required(ErrorMessage = "El campo es requerido.")]
        [MaxLength(100, ErrorMessage = "El máximo  de caracteres es de 100.")]
        [DisplayName("Primer jugador")]
        public string PrimerJugador { get; set; }

        [Required(ErrorMessage = "El campo es requerido.")]
        [MaxLength(100, ErrorMessage = "El máximo  de caracteres es de 100.")]
        [DisplayName("Segundo jugador")]
        public string SegundoJugador { get; set; }
    }
}
