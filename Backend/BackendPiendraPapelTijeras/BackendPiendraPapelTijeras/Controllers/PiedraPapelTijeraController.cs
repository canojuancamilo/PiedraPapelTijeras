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
        readonly IPiedraPapelTijeraService _piedraPapelTijeraService;

        public PiedraPapelTijeraController(IPiedraPapelTijeraService piedraPapelTijeraService)
        {
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

                return CreatedAtAction(nameof(PostIniciarPartida), jugadores);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("RegistrarTurno")]
        public IActionResult PostRegistrarTurno([FromBody] PostTurno model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _piedraPapelTijeraService.RegistrarTurnoPartida(model.IdPartida, model.IdJugadorGanador);
                List<ResultadoJugador> resultados = _piedraPapelTijeraService.obtenerResultadosPartida(model.IdPartida);

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
