using BackendPiendraPapelTijeras.Context;
using BackendPiendraPapelTijeras.Context.Models;
using BackendPiendraPapelTijeras.Core.Interface.Repositories;
using BackendPiendraPapelTijeras.Core.Interface.Services;
using BackendPiendraPapelTijeras.Core.Repository;
using BackendPiendraPapelTijeras.Models;
using System.Collections.Generic;

namespace BackendPiendraPapelTijeras.Core.Service
{
    public class PiedraPapelTijeraService : IPiedraPapelTijeraService
    {
        private readonly IPiedraPapelTijeraRepository _piedraPapelTijeraRepository;

        public PiedraPapelTijeraService(IPiedraPapelTijeraRepository piedraPapelTijeraRepository)
        {
            _piedraPapelTijeraRepository = piedraPapelTijeraRepository;
        }

        public List<ResultadoJugador> obtenerResultadosPartida(int idPartida)
        {
            List<Turno> turnos = _piedraPapelTijeraRepository.ObtenerTurnosPartida(idPartida);
            List<ResultadoJugador> resultados = new List<ResultadoJugador>();

            foreach (var turno in turnos.Where(m => m.IdJugadorGanador != null).GroupBy(m => m.IdJugadorGanador))
            {
                int empates = turnos.Where(m => m.IdJugadorGanador == null).Count();
                int victorias = turno.Count();
                int perdidas = turnos.Where(m => m.IdJugadorGanador != null && m.IdJugadorGanador != turno?.FirstOrDefault()?.IdJugadorGanador).Count();

                resultados.Add(new ResultadoJugador() {
                    Idjugador = turno?.FirstOrDefault()?.IdJugadorGanador ?? 0,
                    Nombre = turno?.FirstOrDefault()?.Ganador.Nombre ?? string.Empty,
                    TurnosGanados = victorias,
                    TurnosEmpatados = empates,
                    TurnosPerdidos = perdidas,
                });
            }

            return resultados;
        }

        public List<Jugador> RegistrarInicioPartida(string jugador1, string jugador2)
        {
            Partida partida = _piedraPapelTijeraRepository.RegistrarInicioPartida();
            List<Jugador> jugadores = _piedraPapelTijeraRepository.RegistrarJugadoresPartida(partida.IdPartida, jugador1, jugador2);

            return jugadores;
        }
    }
}
