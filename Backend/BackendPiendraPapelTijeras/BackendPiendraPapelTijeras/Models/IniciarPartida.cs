using System.ComponentModel.DataAnnotations;

namespace BackendPiendraPapelTijeras.Models
{
    /// <summary>
    /// Clase que representa los datos necesarios para iniciar una partida en el juego de Piedra, Papel o Tijera.
    /// </summary>
    public class IniciarPartida
    {
        /// <summary>
        /// Obtiene o establece el nombre del primer jugador.
        /// </summary>
        [Required(ErrorMessage = "El nombre del primer jugador es obligatorio.")]
        public string PrimerJugador { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del segundo jugador.
        /// </summary>
        [Required(ErrorMessage = "El nombre del segundo jugador es obligatorio.")]
        public string SegundoJugador { get; set; }
    }
}
