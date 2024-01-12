using FrontendPiedraPapelTijera.Interfaces;

namespace BackendPiendraPapelTijeras.Core.Service
{
    public class ManejoErroresService : IManejoErrorService
    {
        private readonly IManejoErrorRepository _manejoErroresRepository;

        public ManejoErroresService(IManejoErrorRepository manejoErroresRepository)
        {
            _manejoErroresRepository = manejoErroresRepository;
        }

        public void Debug(string mensaje)
        {
            _manejoErroresRepository.Debug(mensaje);
        }

        public void Error(string mensaje)
        {
            _manejoErroresRepository.Error(mensaje);

        }

        public void Information(string mensaje)
        {
            _manejoErroresRepository.Information(mensaje);

        }

        public void Warning(string mensaje)
        {
            _manejoErroresRepository.Warning(mensaje);
        }
    }
}
