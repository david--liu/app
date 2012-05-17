namespace app.web.core
{
    public interface IContainDataForClient
    {
        void store<T>(T model);
    }
}