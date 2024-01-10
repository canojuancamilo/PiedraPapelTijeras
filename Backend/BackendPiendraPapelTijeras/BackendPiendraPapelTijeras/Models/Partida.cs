using System.ComponentModel.DataAnnotations;

namespace BackendPiendraPapelTijeras.Models
{
    public class Partida
    {
        [Key]
        public int IdPartida { get; set; }
        public int Ganador { get; set; }
    }
}
