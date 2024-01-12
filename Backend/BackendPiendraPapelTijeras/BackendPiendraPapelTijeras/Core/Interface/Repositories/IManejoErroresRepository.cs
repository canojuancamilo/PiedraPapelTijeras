namespace BackendPiendraPapelTijeras.Core.Interface.Repositories
{
    /// <summary>
    /// Interfaz para un repositorio de manejo de errores.
    /// </summary>
    public interface IManejoErroresRepository
    {
        /// <summary>
        /// Registra un mensaje de error.
        /// </summary>
        /// <param name="mensaje">Mensaje de error a registrar.</param>
        void Error(string mensaje);

        /// <summary>
        /// Registra un mensaje de advertencia.
        /// </summary>
        /// <param name="mensaje">Mensaje de advertencia a registrar.</param>
        void Warning(string mensaje);

        /// <summary>
        /// Registra un mensaje de información.
        /// </summary>
        /// <param name="mensaje">Mensaje de información a registrar.</param>
        void Information(string mensaje);

        /// <summary>
        /// Registra un mensaje de depuración.
        /// </summary>
        /// <param name="mensaje">Mensaje de depuración a registrar.</param>
        void Debug(string mensaje);
    }
}