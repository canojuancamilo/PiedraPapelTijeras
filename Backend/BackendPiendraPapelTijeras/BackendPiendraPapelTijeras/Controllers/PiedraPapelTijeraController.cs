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

        [HttpGet("ResultadoPartida")]
        public IActionResult GetResultadoPartida([FromBody] IniciarPartida model)
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
    }
}
