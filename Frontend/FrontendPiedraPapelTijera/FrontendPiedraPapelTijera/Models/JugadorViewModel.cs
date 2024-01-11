namespace FrontendPiedraPapelTijera.Models
{
    public class JugadorViewModel
    {
        public int IdJugador { get; set; }
        public string Nombre { get; set; }
        public int IdPartida { get; set; }
        public PartidaViewModel Partida { get; set; }
    }
}
