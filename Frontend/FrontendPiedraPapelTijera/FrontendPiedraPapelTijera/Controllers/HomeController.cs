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

            List<JugadorViewModel> jugadores = new List<JugadorViewModel>();

            try
            {
                    jugadores = await _piedraPapelTijeraService.IniciarPartida(model.PrimerJugador, model.SegundoJugador);
            }
            catch (Exception ex) 
            {
                return BadRequest(new { error = ex.Message });
            }
            

            return PartialView("_Partida", jugadores);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
