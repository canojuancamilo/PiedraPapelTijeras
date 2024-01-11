namespace BackendPiendraPapelTijeras.Core.Interface.Services
{
    public interface IManejoErroresService
    {
        public void Error(string mensaje);
        public void Warning(string mensaje);
        public void Information(string mensaje);
        public void Debug(string mensaje);
    }
}
