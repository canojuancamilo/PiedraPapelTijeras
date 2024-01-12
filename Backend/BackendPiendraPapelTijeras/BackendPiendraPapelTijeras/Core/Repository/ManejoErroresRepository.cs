using BackendPiendraPapelTijeras.Core.Interface.Repositories;

namespace BackendPiendraPapelTijeras.Core.Repository
{
    /// <summary>
    /// Implementación del repositorio para el manejo de errores mediante el registro de mensajes en un logger.
    /// </summary>
    public class ManejoErroresRepository : IManejoErroresRepository
    {
        private readonly ILogger<ManejoErroresRepository> _logger;

        /// <summary>
        /// Constructor de la clase <see cref="ManejoErroresRepository"/>.
        /// </summary>
        /// <param name="logger">Instancia del logger utilizado para el registro de mensajes.</param>
        public ManejoErroresRepository(ILogger<ManejoErroresRepository> logger)
        {
            _logger = logger;
        }

        /// <summary>
        /// Registra un mensaje de tipo debug.
        /// </summary>
        /// <param name="mensaje">Mensaje de depuración.</param>
        public void Debug(string mensaje)
        {
            _logger.LogDebug(mensaje);
        }

        /// <summary>
        /// Registra un mensaje de error.
        /// </summary>
        /// <param name="mensaje">Mensaje de error.</param>
        public void Error(string mensaje)
        {
            _logger.LogError(mensaje);
        }

        /// <summary>
        /// Registra un mensaje de información.
        /// </summary>
        /// <param name="mensaje">Mensaje informativo.</param>
        public void Information(string mensaje)
        {
            _logger.LogInformation(mensaje);
        }

        /// <summary>
        /// Registra un mensaje de advertencia.
        /// </summary>
        /// <param name="mensaje">Mensaje de advertencia.</param>
        public void Warning(string mensaje)
        {
            _logger.LogWarning(mensaje);
        }
    }
}
