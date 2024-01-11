using BackendPiendraPapelTijeras.Context;
using BackendPiendraPapelTijeras.Context.Models;
using BackendPiendraPapelTijeras.Core.Interface.Repositories;
using BackendPiendraPapelTijeras.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BackendPiendraPapelTijeras.Core.Repository
{
    public class PiedraPapelTijeraRepository : IPiedraPapelTijeraRepository
    {
        private readonly AplicationBdContext _dbContext;

        public PiedraPapelTijeraRepository(AplicationBdContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Turno> ObtenerTurnosPartida(int idPartida)
        {
            List<Turno> turnos = _dbContext.Turnos.Include(m=> m.Ganador).Where(m => m.IdPartida == idPartida).ToList();
            return turnos;
        }

        public Partida RegistrarInicioPartida()
        {
            Partida partida = new Partida { };
            _dbContext.Partidas.Add(partida);
            _dbContext.SaveChanges();

            return partida;
        }

        public List<Jugador> RegistrarJugadoresPartida(int partida, string jugador1, string jugador2)
        {
            List<Jugador> jugadores = new List<Jugador>() {
            new Jugador(){Nombre = jugador1, IdPartida = partida},
            new Jugador(){Nombre = jugador1, IdPartida = partida}
            };

            _dbContext.Jugadores.AddRange(jugadores);
            _dbContext.SaveChanges();

            return jugadores;
        }

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

        public void ActualizarPartida(int idPartida, int idJugadorGanador)
        {
            Partida partida = _dbContext.Partidas?.FirstOrDefault(m => m.IdPartida == idPartida) ?? new Partida() { };

            partida.Ganador = idJugadorGanador;

            _dbContext.SaveChanges();
        }

        public Partida obtenerDetallePartida(int idPartida)
        {
            return _dbContext.Partidas?.FirstOrDefault(m => m.IdPartida == idPartida) ?? new Partida() { };
        }

        public List<Jugador> ObtenerJugadoresPartida(int idPartida) 
        {
           return _dbContext.Jugadores.Where(m => m.IdPartida == idPartida).ToList();
        }
    }
}
