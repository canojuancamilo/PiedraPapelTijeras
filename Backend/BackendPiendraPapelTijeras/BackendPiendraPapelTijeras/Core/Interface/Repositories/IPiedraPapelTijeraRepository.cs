using BackendPiendraPapelTijeras.Context.Models;
using BackendPiendraPapelTijeras.Models;

namespace BackendPiendraPapelTijeras.Core.Interface.Repositories
{
    public interface IPiedraPapelTijeraRepository
    {
        public Partida RegistrarInicioPartida();
        public List<Jugador> RegistrarJugadoresPartida(int idPartida, string jugador1, string jugador2);
        public List<Turno> ObtenerTurnosPartida(int idPartida);
    }
}
