namespace app.web.core
{
    public interface IProcessOneRequest
    {
        void process(IContainRequestDetails the_request);
        bool can_process(IContainRequestDetails request);
    }
}