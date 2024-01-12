using BackendPiendraPapelTijeras.Core.Interface.Repositories;
using BackendPiendraPapelTijeras.Core.Interface.Services;

namespace BackendPiendraPapelTijeras.Core.Service
{
    public class ManejoErroresService : IManejoErroresService
    {
        private readonly IManejoErroresRepository _manejoErroresRepository;

        public ManejoErroresService(IManejoErroresRepository manejoErroresRepository)
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
