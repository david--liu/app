namespace app.web.core
{
    public interface IProcessOneRequest:ISupportAFeature
    {
        bool can_process(IContainRequestDetails request);
    }
}