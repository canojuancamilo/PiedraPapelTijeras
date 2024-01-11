using FrontendPiedraPapelTijera.Interfaces;
using FrontendPiedraPapelTijera.Models;
using System.Net.Http;

namespace FrontendPiedraPapelTijera.Services
{
    public class PiedraPapelTijeraService: IPiedraPapelTijeraService
    {
        private readonly IPiedraPapelTijeraRepository _piedraPapelTijeraRepository;

        public PiedraPapelTijeraService(IPiedraPapelTijeraRepository piedraPapelTijeraRepository)
        {
            _piedraPapelTijeraRepository = piedraPapelTijeraRepository;
        }

        public async Task<List<JugadorViewModel>> IniciarPartida(string PrimerJugador, string SegundoJugador)
        {
            return  await _piedraPapelTijeraRepository.IniciarPartida(PrimerJugador, SegundoJugador);
        }

        public async Task<List<ResultadoPartidaViewModel>> ObtenerResultadosPartida(int IdPartida)
        {
            return await _piedraPapelTijeraRepository.ObtenerResultadosPartida(IdPartida);
        }

        public async Task<List<ResultadoPartidaViewModel>> RegistrarTurno(int IdPartida, int? IdJugadorGanador)
        {
            return await _piedraPapelTijeraRepository.RegistrarTurno(IdPartida, IdJugadorGanador);
        }
    }
}
