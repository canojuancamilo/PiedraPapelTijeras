namespace BackendPiendraPapelTijeras.Core.Interface.Services
{
    /// <summary>
    /// Interfaz para un servicio de manejo de errores.
    /// </summary>
    public interface IManejoErroresService
    {
        /// <summary>
        /// Registra un mensaje de error.
        /// </summary>
        /// <param name="mensaje">Mensaje de error a registrar.</param>
        public void Error(string mensaje);

        /// <summary>
        /// Registra un mensaje de advertencia.
        /// </summary>
        /// <param name="mensaje">Mensaje de advertencia a registrar.</param>
        public void Warning(string mensaje);

        /// <summary>
        /// Registra un mensaje de información.
        /// </summary>
        /// <param name="mensaje">Mensaje de información a registrar.</param>
        public void Information(string mensaje);

        /// <summary>
        /// Registra un mensaje de depuración.
        /// </summary>
        /// <param name="mensaje">Mensaje de depuración a registrar.</param>
        public void Debug(string mensaje);
    }
}
