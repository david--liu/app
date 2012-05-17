namespace app.web.core
{
    public interface IDataStore
    {
        void store<T>(T model);
    }
}