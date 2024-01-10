using BackendPiendraPapelTijeras.Context.Models;
using BackendPiendraPapelTijeras.Core.Interface.Services;
using BackendPiendraPapelTijeras.Models;
using Microsoft.AspNetCore.Mvc;

namespace BackendPiendraPapelTijeras.Controllers
{
    [ApiController]
    [Route("Api/[controller]")]
    public class PiedraPapelTijeraController : ControllerBase
    {
        readonly ILogger<PiedraPapelTijeraController> _logger;
        readonly IPiedraPapelTijeraService _piedraPapelTijeraService;

        public PiedraPapelTijeraController(ILogger<PiedraPapelTijeraController> logger,
           IPiedraPapelTijeraService piedraPapelTijeraService)
        {
            _logger = logger;
            _piedraPapelTijeraService = piedraPapelTijeraService;
        }

        [HttpPost("IniciarPartida")]
        public IActionResult PostIniciarPartida([FromBody] IniciarPartida model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                List<Jugador> jugadores = _piedraPapelTijeraService.RegistrarInicioPartida(model.PrimerJugador, model.SegundoJugador);

                return Ok(jugadores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("RegistrarTurno/{idPartida}/{IdjugadorGanador}")]
        public IActionResult PostRegistrarTurno(int idPartida, int IdjugadorGanador)
        {
            try
            {
                _piedraPapelTijeraService.RegistrarTurnoPartida(idPartida, IdjugadorGanador);
                List<ResultadoJugador> resultados = _piedraPapelTijeraService.obtenerResultadosPartida(idPartida);

                return Ok(resultados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("ResultadoPartida/{idPartida}")]
        public IActionResult GetResultadoPartida(int idPartida)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                List<ResultadoJugador> resultados = _piedraPapelTijeraService.obtenerResultadosPartida(idPartida);

                return Ok(resultados);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
