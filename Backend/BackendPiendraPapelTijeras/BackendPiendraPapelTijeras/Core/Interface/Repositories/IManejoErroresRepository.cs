namespace BackendPiendraPapelTijeras.Core.Interface.Repositories
{
    public interface IManejoErroresRepository
    {
        public void Error(string mensaje);
        public void Warning(string mensaje);
        public void Information(string mensaje);
        public void Debug(string mensaje);
    }
}
