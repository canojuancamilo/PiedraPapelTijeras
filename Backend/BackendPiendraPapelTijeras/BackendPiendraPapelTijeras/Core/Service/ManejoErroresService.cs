using BackendPiendraPapelTijeras.Core.Interface.Repositories;
using BackendPiendraPapelTijeras.Core.Interface.Services;

namespace BackendPiendraPapelTijeras.Core.Service
{
    public class ManejoErroresService : IManejoErroresService
    {
        private readonly IManejoErroresRepository _manejoErroresService;

        public ManejoErroresService(IManejoErroresRepository manejoErroresService)
        {
            _manejoErroresService = manejoErroresService;
        }

        public void Debug(string mensaje)
        {
            _manejoErroresService.Debug(mensaje);
        }

        public void Error(string mensaje)
        {
            _manejoErroresService.Error(mensaje);

        }

        public void Information(string mensaje)
        {
            _manejoErroresService.Information(mensaje);

        }

        public void Warning(string mensaje)
        {
            _manejoErroresService.Warning(mensaje);
        }
    }
}
