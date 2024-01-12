using BackendPiendraPapelTijeras.Context;
using BackendPiendraPapelTijeras.Context.Models;
using BackendPiendraPapelTijeras.Core.Interface.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BackendPiendraPapelTijeras.Core.Repository
{
    /// <summary>
    /// Implementación del repositorio para operaciones relacionadas con el juego de Piedra, Papel o Tijera.
    /// </summary>
    public class PiedraPapelTijeraRepository : IPiedraPapelTijeraRepository
    {
        private readonly AplicationBdContext _dbContext;

        public PiedraPapelTijeraRepository(AplicationBdContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Obtiene la lista de turnos registrados para una partida específica.
        /// </summary>
        /// <param name="idPartida">Identificador único de la partida.</param>
        /// <returns>Lista de objetos de tipo Turno que representa los turnos de la partida.</returns>
        public List<Turno> ObtenerTurnosPartida(int idPartida)
        {
            List<Turno> turnos = _dbContext.Turnos.Include(m => m.Ganador).Where(m => m.IdPartida == idPartida).ToList();
            return turnos;
        }

        /// <summary>
        /// Registra el inicio de una nueva partida.
        /// </summary>
        /// <returns>Objeto de tipo Partida que representa la partida registrada.</returns>
        public Partida RegistrarInicioPartida()
        {
            Partida partida = new Partida { };
            _dbContext.Partidas.Add(partida);
            _dbContext.SaveChanges();

            return partida;
        }

        /// <summary>
        /// Registra los jugadores para una partida específica.
        /// </summary>
        /// <param name="partida">Identificador único de la partida.</param>
        /// <param name="jugador1">Nombre del primer jugador.</param>
        /// <param name="jugador2">Nombre del segundo jugador.</param>
        /// <returns>Lista de objetos de tipo Jugador que representa los jugadores registrados.</returns>
        public List<Jugador> RegistrarJugadoresPartida(int partida, string jugador1, string jugador2)
        {
            List<Jugador> jugadores = new List<Jugador>() {
            new Jugador(){Nombre = jugador1, IdPartida = partida},
            new Jugador(){Nombre = jugador2, IdPartida = partida}
            };

            _dbContext.Jugadores.AddRange(jugadores);
            _dbContext.SaveChanges();

            return jugadores;
        }

        /// <summary>
        /// Registra un turno en una partida, indicando el jugador ganador (si lo hay).
        /// </summary>
        /// <param name="idPartida">Identificador único de la partida.</param>
        /// <param name="idJugadorGanador">Identificador único del jugador ganador, o null si no hay ganador.</param>
        public void RegistrarTurnoPartida(int idPartida, int? idJugadorGanador)
        {
            _dbContext.Turnos.Add(new Turno()
            {
                IdPartida = idPartida,
                IdJugadorGanador = idJugadorGanador,
                FechaRegistro = DateTime.Now
            });

            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Actualiza los detalles de una partida indicando el jugador ganador.
        /// </summary>
        /// <param name="idPartida">Identificador único de la partida.</param>
        /// <param name="idJugadorGanador">Identificador único del jugador ganador.</param>
        public void ActualizarPartida(int idPartida, int idJugadorGanador)
        {
            Partida partida = _dbContext.Partidas?.FirstOrDefault(m => m.IdPartida == idPartida) ?? new Partida() { };

            partida.Ganador = idJugadorGanador;

            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Obtiene los detalles de una partida específica.
        /// </summary>
        /// <param name="idPartida">Identificador único de la partida.</param>
        /// <returns>Objeto de tipo Partida que contiene los detalles de la partida.</returns>
        public Partida? ObtenerDetallePartida(int idPartida)
        {
            return _dbContext.Partidas?.FirstOrDefault(m => m.IdPartida == idPartida);
        }

        /// <summary>
        /// Obtiene la lista de jugadores para una partida específica.
        /// </summary>
        /// <param name="idPartida">Identificador único de la partida.</param>
        /// <returns>Lista de objetos de tipo Jugador que representa los jugadores de la partida.</returns>
        public List<Jugador> ObtenerJugadoresPartida(int idPartida)
        {
            return _dbContext.Jugadores.Where(m => m.IdPartida == idPartida).ToList();
        }

        /// <summary>
        /// Elimina los turnos asociados a una partida.
        /// </summary>
        /// <param name="idPartida">Identificador único de la partida.</param>
        public void EliminarTurnosPartida(int idPartida)
        {
            var turnos = _dbContext.Turnos.Where(p => p.IdPartida == idPartida);
            _dbContext.Turnos.RemoveRange(turnos);
            _dbContext.SaveChanges();
        }
    }
}
