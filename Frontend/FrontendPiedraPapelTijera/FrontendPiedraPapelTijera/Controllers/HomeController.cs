using FrontendPiedraPapelTijera.Interfaces;
using FrontendPiedraPapelTijera.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FrontendPiedraPapelTijera.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPiedraPapelTijeraService _piedraPapelTijeraService;

        public HomeController(ILogger<HomeController> logger, IPiedraPapelTijeraService piedraPapelTijeraService)
        {
            _logger = logger;
            _piedraPapelTijeraService = piedraPapelTijeraService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("IniciarPartida")]
        public async Task<IActionResult> IniciarPartida(IniciarPartidaViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            try
            {
                List<JugadorViewModel> jugadores = await _piedraPapelTijeraService.IniciarPartida(model.PrimerJugador, model.SegundoJugador);
                return PartialView("_Partida", jugadores);
            }
            catch (Exception ex) 
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        [Route("ObtenerResultadosPartida/{idPartida}")]
        public async Task<IActionResult> ObtenerResultadosPartida(int idPartida)
        {
            try
            {
                List<ResultadoPartidaViewModel> resultadoPartida = await _piedraPapelTijeraService.ObtenerResultadosPartida(idPartida);
                return PartialView("_ResultadosPartida", resultadoPartida);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpPost]
        [Route("RegistrarTurno")]
        public async Task<IActionResult> RegistrarTurno(PartidaViewModel model)
        {
            try
            {
                List<ResultadoPartidaViewModel>  resultadoPartida = await _piedraPapelTijeraService.RegistrarTurno(model.IdPartida, model.Ganador);

                var finPartida = resultadoPartida.Any(m => m.TurnosGanados == 3);
                return Json(new { finPartida = finPartida, ganador = resultadoPartida?.FirstOrDefault(m => m.TurnosGanados == 3)?.Nombre}); 
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet]
        [Route("IniciarNuevaRonda/{idPartida}")]
        public IActionResult IniciarNuevaRonda(int idPartida)
        {
            try
            {
                List<JugadorViewModel> jugadores = new List<JugadorViewModel>(){
                        new JugadorViewModel() { IdPartida = idPartida, }
                };

                return PartialView("_Partida", jugadores);
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
