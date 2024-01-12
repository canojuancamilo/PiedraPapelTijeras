using FrontendPiedraPapelTijera.Interfaces;

namespace BackendPiendraPapelTijeras.Core.Service
{
    public class ManejoErroresService : IManejoErrorService
    {
        private readonly IManejoErrorService _manejoErroresService;

        public ManejoErroresService(IManejoErrorService manejoErroresService)
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
