using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FrontendPiedraPapelTijera.Models
{
    public class PartidaViewModel
    {
        [Required(ErrorMessage = "El campo es requerido.")]
        public int IdPartida { get; set; }
        public int? Ganador { get; set; }
    }
}
