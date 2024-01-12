using System.ComponentModel.DataAnnotations;

namespace BackendPiendraPapelTijeras.Context.Models
{
    /// <summary>
    /// Clase que representa a un jugador en el juego de Piedra, Papel o Tijera.
    /// </summary>
    public class Jugador
    {
        /// <summary>
        /// Obtiene o establece el identificador único del jugador.
        /// </summary>
        [Key]
        public int IdJugador { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del jugador.
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único de la partida a la que pertenece el jugador.
        /// </summary>
        public int IdPartida { get; set; }

        /// <summary>
        /// Obtiene o establece la referencia a la partida a la que pertenece el jugador.
        /// </summary>
        public Partida Partida { get; set; }
    }
}