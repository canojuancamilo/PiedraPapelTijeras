using BackendPiendraPapelTijeras.Context.Models;

namespace BackendPiendraPapelTijeras.Core.Interface.Repositories
{
    public interface IPiedraPapelTijeraRepository
    {
        public Partida RegistrarInicioPartida();
        public Partida obtenerDetallePartida(int idPartida);
        public List<Jugador> RegistrarJugadoresPartida(int idPartida, string jugador1, string jugador2);
        public List<Jugador> ObtenerJugadoresPartida(int idPartida);
        public void RegistrarTurnoPartida(int idPartida, int? idJugadorGanador);
        public List<Turno> ObtenerTurnosPartida(int idPartida);
        public void ActualizarPartida(int idPartida, int idJugadorGanador);
    }
}
