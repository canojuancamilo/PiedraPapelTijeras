using BackendPiendraPapelTijeras.Context.Models;
using BackendPiendraPapelTijeras.Models;

namespace BackendPiendraPapelTijeras.Core.Interface.Services
{
    public interface IPiedraPapelTijeraService
    {
        public List<Jugador> RegistrarInicioPartida(string jugador1, string jugador2);

        public List<ResultadoJugador> ObtenerResultadosPartida(int idPartida);

        public void RegistrarTurnoPartida(int idPartida, int? idJugadorGanador);
    }
}
