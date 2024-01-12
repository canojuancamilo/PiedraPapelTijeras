using System.ComponentModel.DataAnnotations;

namespace BackendPiendraPapelTijeras.Context.Models
{
    /// <summary>
    /// Clase que representa una partida en el juego de Piedra, Papel o Tijera.
    /// </summary>
    public class Partida
    {
        /// <summary>
        /// Obtiene o establece el identificador único de la partida.
        /// </summary>
        [Key]
        public int IdPartida { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del jugador ganador, o null si no hay ganador.
        /// </summary>
        public int? Ganador { get; set; }
    }
}