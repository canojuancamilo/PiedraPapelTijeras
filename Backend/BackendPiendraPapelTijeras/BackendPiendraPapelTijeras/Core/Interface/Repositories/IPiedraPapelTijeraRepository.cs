using BackendPiendraPapelTijeras.Context.Models;

namespace BackendPiendraPapelTijeras.Core.Interface.Repositories
{
    /// <summary>
    /// Interfaz para un repositorio relacionado con el juego de Piedra, Papel o Tijera.
    /// </summary>
    public interface IPiedraPapelTijeraRepository
    {
        /// <summary>
        /// Registra el inicio de una nueva partida.
        /// </summary>
        /// <returns>Objeto de tipo Partida que representa la partida registrada.</returns>
        Partida RegistrarInicioPartida();

        /// <summary>
        /// Obtiene detalles de una partida específica.
        /// </summary>
        /// <param name="idPartida">Identificador único de la partida.</param>
        /// <returns>Objeto de tipo Partida que contiene los detalles de la partida.</returns>
        Partida? ObtenerDetallePartida(int idPartida);

        /// <summary>
        /// Registra los jugadores para una partida específica.
        /// </summary>
        /// <param name="idPartida">Identificador único de la partida.</param>
        /// <param name="jugador1">Nombre del primer jugador.</param>
        /// <param name="jugador2">Nombre del segundo jugador.</param>
        /// <returns>Lista de objetos de tipo Jugador que representa los jugadores registrados.</returns>
        List<Jugador> RegistrarJugadoresPartida(int idPartida, string jugador1, string jugador2);

        /// <summary>
        /// Obtiene la lista de jugadores para una partida específica.
        /// </summary>
        /// <param name="idPartida">Identificador único de la partida.</param>
        /// <returns>Lista de objetos de tipo Jugador que representa los jugadores de la partida.</returns>
        List<Jugador> ObtenerJugadoresPartida(int idPartida);

        /// <summary>
        /// Registra un turno en una partida, indicando el jugador ganador (si lo hay).
        /// </summary>
        /// <param name="idPartida">Identificador único de la partida.</param>
        /// <param name="idJugadorGanador">Identificador único del jugador ganador, o null si no hay ganador.</param>
        void RegistrarTurnoPartida(int idPartida, int? idJugadorGanador);

        /// <summary>
        /// Obtiene la lista de turnos registrados para una partida específica.
        /// </summary>
        /// <param name="idPartida">Identificador único de la partida.</param>
        /// <returns>Lista de objetos de tipo Turno que representa los turnos de la partida.</returns>
        List<Turno> ObtenerTurnosPartida(int idPartida);

        /// <summary>
        /// Actualiza los detalles de una partida indicando el jugador ganador.
        /// </summary>
        /// <param name="idPartida">Identificador único de la partida.</param>
        /// <param name="idJugadorGanador">Identificador único del jugador ganador.</param>
        void ActualizarPartida(int idPartida, int idJugadorGanador);

        /// <summary>
        /// Elimina los turnos de una partida
        /// </summary>
        /// <param name="idPartida">Identificador único de la partida.</param>
        void EliminarTurnosPartida(int idPartida);
    }
}