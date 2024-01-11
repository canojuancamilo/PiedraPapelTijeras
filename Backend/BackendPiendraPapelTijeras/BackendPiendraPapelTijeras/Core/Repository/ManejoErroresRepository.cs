using BackendPiendraPapelTijeras.Core.Interface.Repositories;

namespace BackendPiendraPapelTijeras.Core.Repository
{
    public class ManejoErroresRepository : IManejoErroresRepository
    {
        private readonly ILogger<ManejoErroresRepository> _logger;

        public ManejoErroresRepository(ILogger<ManejoErroresRepository> logger)
        {
            _logger = logger;
        }

        public void Debug(string mensaje)
        {
            _logger.LogDebug(mensaje);
        }

        public void Error(string mensaje)
        {
            _logger.LogError(mensaje);
        }

        public void Information(string mensaje)
        {
            _logger.LogInformation(mensaje);
        }

        public void Warning(string mensaje)
        {
            _logger.LogWarning(mensaje);
        }
    }
}
