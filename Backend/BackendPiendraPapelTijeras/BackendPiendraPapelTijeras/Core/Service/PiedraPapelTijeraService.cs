using BackendPiendraPapelTijeras.Context;
using BackendPiendraPapelTijeras.Context.Models;
using BackendPiendraPapelTijeras.Core.Interface.Repositories;
using BackendPiendraPapelTijeras.Core.Interface.Services;
using BackendPiendraPapelTijeras.Core.Repository;
using BackendPiendraPapelTijeras.Migrations;
using BackendPiendraPapelTijeras.Models;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

                resultados.Add(new ResultadoJugador()
                {
                    IdJugador = turno?.FirstOrDefault()?.IdJugadorGanador ?? 0,
                    Nombre = turno?.FirstOrDefault()?.Ganador.Nombre ?? string.Empty,
                    TurnosGanados = victorias,
                    TurnosEmpatados = empates,
                    TurnosPerdidos = perdidas,
                });
            }

            if (turnos == null || turnos.Count() == 0)
            {
                List<Jugador> jugadores = _piedraPapelTijeraRepository.ObtenerJugadoresPartida(idPartida);

                foreach (var jugador in jugadores)
                {
                    resultados.Add(new ResultadoJugador()
                    {
                        IdJugador = jugador.IdJugador,
                        Nombre = jugador.Nombre,
                        TurnosGanados = 0,
                        TurnosEmpatados = 0,
                        TurnosPerdidos = 0,
                    });
                }
            }

            return resultados;
        }

        public List<Jugador> RegistrarInicioPartida(string jugador1, string jugador2)
        {
            Partida partida = _piedraPapelTijeraRepository.RegistrarInicioPartida();
            List<Jugador> jugadores = _piedraPapelTijeraRepository.RegistrarJugadoresPartida(partida.IdPartida, jugador1, jugador2);

            return jugadores;
        }

        public void RegistrarTurnoPartida(int idPartida, int? idJugadorGanador)
        {
            Partida partida = _piedraPapelTijeraRepository.obtenerDetallePartida(idPartida);

            if (partida.Ganador != 0 && partida.Ganador != null)
                throw new InvalidOperationException($"La partida ya fue finalizada.");

            _piedraPapelTijeraRepository.RegistrarTurnoPartida(idPartida, idJugadorGanador);

            List<ResultadoJugador> resultados = this.obtenerResultadosPartida(idPartida);
            int partidasGanadasJugador = resultados?.FirstOrDefault(m => m.IdJugador == (idJugadorGanador ?? 0))?.TurnosGanados ?? 0;

            if (partidasGanadasJugador >= 3)
                _piedraPapelTijeraRepository.ActualizarPartida(idPartida, idJugadorGanador ?? 0);
        }
    }
}
