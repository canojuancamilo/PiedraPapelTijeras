using System.ComponentModel.DataAnnotations;

namespace BackendPiendraPapelTijeras.Models
{
    /// <summary>
    /// Clase que representa el resultado de un jugador en el juego de Piedra, Papel o Tijera.
    /// </summary>
    public class ResultadoJugador
    {
        /// <summary>
        /// Obtiene o establece el identificador único del jugador.
        /// </summary>
        public int IdJugador { get; set; }

        /// <summary>
        /// Obtiene o establece el nombre del jugador.
        /// </summary>
        public required string Nombre { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad de turnos ganados por el jugador.
        /// </summary>
        public int TurnosGanados { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad de turnos empatados por el jugador.
        /// </summary>
        public int TurnosEmpatados { get; set; }

        /// <summary>
        /// Obtiene o establece la cantidad de turnos perdidos por el jugador.
        /// </summary>
        public int TurnosPerdidos { get; set; }
    }
}
