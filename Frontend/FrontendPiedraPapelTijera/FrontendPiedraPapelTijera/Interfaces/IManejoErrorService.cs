﻿namespace FrontendPiedraPapelTijera.Interfaces
{
    public interface IManejoErrorService
    {
        void Error(string mensaje);

        void Warning(string mensaje);

        void Information(string mensaje);

        void Debug(string mensaje);
    }
}
