﻿using BackendPiendraPapelTijeras.Core.Interface.Services;

namespace BackendPiendraPapelTijeras.Core.Service
{
    public class ManejoErroresService : IManejoErroresService
    {
        private readonly IManejoErroresService _manejoErroresService;

        public ManejoErroresService(IManejoErroresService manejoErroresService)
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
