using System.ComponentModel.DataAnnotations;

namespace BackendPiendraPapelTijeras.Context.Models
{
    /// <summary>
    /// Clase que representa un turno en el juego de Piedra, Papel o Tijera.
    /// </summary>
    public class Turno
    {
        /// <summary>
        /// Obtiene o establece el identificador único del turno.
        /// </summary>
        [Key]
        public int IdTurno { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único de la partida a la que pertenece el turno.
        /// </summary>
        public int IdPartida { get; set; }

        /// <summary>
        /// Obtiene o establece la referencia a la partida a la que pertenece el turno.
        /// </summary>
        public required Partida Partida { get; set; }

        /// <summary>
        /// Obtiene o establece el identificador único del jugador ganador, o null si no hay ganador.
        /// </summary>
        public int? IdJugadorGanador { get; set; }

        /// <summary>
        /// Obtiene o establece la referencia al jugador ganador, o null si no hay ganador.
        /// </summary>
        public Jugador? Ganador { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha y hora en que se registró el turno.
        /// </summary>
        public DateTime FechaRegistro { get; set; }
    }
}
