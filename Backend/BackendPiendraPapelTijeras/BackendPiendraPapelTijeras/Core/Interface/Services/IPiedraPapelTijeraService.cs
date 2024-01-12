using BackendPiendraPapelTijeras.Context.Models;
using BackendPiendraPapelTijeras.Models;

namespace BackendPiendraPapelTijeras.Core.Interface.Services
{
    /// <summary>
    /// Interfaz para un servicio relacionado con el juego de Piedra, Papel o Tijera.
    /// </summary>
    public interface IPiedraPapelTijeraService
    {
        /// <summary>
        /// Registra el inicio de una nueva partida entre dos jugadores.
        /// </summary>
        /// <param name="jugador1">Nombre del primer jugador.</param>
        /// <param name="jugador2">Nombre del segundo jugador.</param>
        /// <returns>Lista de jugadores registrados para la partida.</returns>
        List<Jugador> RegistrarInicioPartida(string jugador1, string jugador2);

        /// <summary>
        /// Obtiene los resultados de una partida específica.
        /// </summary>
        /// <param name="idPartida">Identificador único de la partida.</param>
        /// <returns>Lista de resultados de los jugadores en la partida.</returns>
        List<ResultadoJugador> ObtenerResultadosPartida(int idPartida);

        /// <summary>
        /// Registra un turno en una partida, indicando el jugador ganador (si lo hay).
        /// </summary>
        /// <param name="idPartida">Identificador único de la partida.</param>
        /// <param name="idJugadorGanador">Identificador único del jugador ganador, o null si no hay ganador.</param>
        void RegistrarTurnoPartida(int idPartida, int? idJugadorGanador);

        /// <summary>
        /// Elimina los turnos de una partida
        /// </summary>
        /// <param name="idPartida">Identificador único de la partida.</param>
        void EliminarTurnosPartida(int idPartida);
    }
}
