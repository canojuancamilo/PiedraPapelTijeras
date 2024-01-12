using FrontendPiedraPapelTijera.Interfaces;
using FrontendPiedraPapelTijera.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Net.Http;
using System.Reflection;

namespace FrontendPiedraPapelTijera.Repositories
{
    public class PiedraPapelTijeraRepository : IPiedraPapelTijeraRepository
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public PiedraPapelTijeraRepository(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
        }

        private string BaseUrl => $"{_configuration.GetValue<string>("BackendApi:Url")}/Api/PiedraPapelTijera";

        public async Task<List<JugadorViewModel>> IniciarPartida(string PrimerJugador, string SegundoJugador)
        {
            HttpResponseMessage response = new HttpResponseMessage() { };

            try
            {
                var modelo = new
                {
                    PrimerJugador = PrimerJugador,
                    SegundoJugador = SegundoJugador
                };

                response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/IniciarPartida", modelo);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<List<JugadorViewModel>>();
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
                }

                throw;
            }
        }

        public async Task<List<ResultadoPartidaViewModel>> ObtenerResultadosPartida(int IdPartida)
        {
            HttpResponseMessage response = new HttpResponseMessage() { };

            try
            {
                response = await _httpClient.GetAsync($"{BaseUrl}/ResultadoPartida/{IdPartida}");
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<List<ResultadoPartidaViewModel>>();
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
                }

                throw;
            }
        }

        public async Task<List<ResultadoPartidaViewModel>> RegistrarTurno(int IdPartida, int? IdJugadorGanador)
        {
            HttpResponseMessage response = new HttpResponseMessage() { };

            try
            {
                var modelo = new
                {
                    IdPartida = IdPartida,
                    IdJugadorGanador = IdJugadorGanador
                };

                response = await _httpClient.PostAsJsonAsync($"{BaseUrl}/RegistrarTurno", modelo);
                response.EnsureSuccessStatusCode();

                return await response.Content.ReadFromJsonAsync<List<ResultadoPartidaViewModel>>();
            }
            catch (HttpRequestException ex)
            {
                if (ex.StatusCode == HttpStatusCode.BadRequest)
                {
                    throw new InvalidOperationException(await response.Content.ReadAsStringAsync());
                }

                throw;
            }
        }
    }
}
