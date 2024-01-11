using FrontendPiedraPapelTijera.Models;

namespace FrontendPiedraPapelTijera.Interfaces
{
    public interface IPiedraPapelTijeraRepository
    {
        public  Task<List<JugadorViewModel>> IniciarPartida(string PrimerJugador, string SegundoJugador);
        public  Task<List<ResultadoPartidaViewModel>> RegistrarTurno(int IdPartida, int? IdJugadorGanador);
        public Task<List<ResultadoPartidaViewModel>> ObtenerResultadosPartida(int IdPartida);
    }
}
