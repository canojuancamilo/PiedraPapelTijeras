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
        readonly IManejoErroresService _manejoErroresService;

        public PiedraPapelTijeraController(IPiedraPapelTijeraService piedraPapelTijeraService,
            IManejoErroresService manejoErroresService)
        {
            _piedraPapelTijeraService = piedraPapelTijeraService;
            _manejoErroresService = manejoErroresService;
        }

        /// <summary>
        /// Inicia la partida Ingresando el registro de la partida y los jugadores enviados
        /// </summary>
        /// <param name="model"></param>
        /// <response code="201">La partida fue creada.</response>
        /// <response code="400">Los datos o el proceso es incorrecto. </response>
        /// <response code="500">un problema en el servidor.</response>
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
                _manejoErroresService.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Registra el turno y el gandador de dicha ronda, si hubo empate se debe enviar el valor de IdJugadorGanador en null
        /// </summary>
        /// <param name="model"></param>
        /// <response code="201">La partida fue creada.</response>
        /// <response code="400">Los datos o el proceso es incorrecto. </response>
        /// <response code="500">un problema en el servidor.</response>
        [HttpPost("RegistrarTurno")]
        public IActionResult PostRegistrarTurno([FromBody] PostTurno model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                _piedraPapelTijeraService.RegistrarTurnoPartida(model.IdPartida, model.IdJugadorGanador);
                List<ResultadoJugador> resultados = _piedraPapelTijeraService.ObtenerResultadosPartida(model.IdPartida);

                return CreatedAtAction(nameof(PostRegistrarTurno), resultados);
            }
            catch (Exception ex)
            {
                _manejoErroresService.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retorna el resultado de los turnos por jugador
        /// </summary>
        /// <response code="200">Lista de jugadores y los resultados de las rondas.</response>
        /// <response code="204">No se encontraron datos.</response>
        /// <response code="500">un problema en el servidor.</response>
        /// <remarks>
        /// Sample return:
        /// 
        ///     [
        ///         {
        ///           "idJugador": 1,
        ///           "nombre": "string",
        ///           "turnosGanados": 1,
        ///           "turnosEmpatados": 1,
        ///           "turnosPerdidos": 3
        ///         },
        ///         {
        ///           "idJugador": 2,
        ///           "nombre": "string",
        ///           "turnosGanados": 3,
        ///           "turnosEmpatados": 1,
        ///           "turnosPerdidos": 1
        ///         }
        ///     ]
        ///
        /// 
        /// </remarks>
        [HttpGet("ResultadoPartida/{idPartida}")]
        public IActionResult GetResultadoPartida(int idPartida)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                List<ResultadoJugador> resultados = _piedraPapelTijeraService.ObtenerResultadosPartida(idPartida);

                if(resultados == null || resultados.Count() ==0)
                    return NotFound();

                return Ok(resultados);
            }
            catch (Exception ex)
            {
                _manejoErroresService.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("EliminarTurnosPartida/{idPartida}")]
        public IActionResult DeleteTurnosPartida(int idPartida)
        {
            try
            {
                _piedraPapelTijeraService.EliminarTurnosPartida(idPartida);
                return NoContent();
            }
            catch (Exception ex)
            {
                _manejoErroresService.Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}
