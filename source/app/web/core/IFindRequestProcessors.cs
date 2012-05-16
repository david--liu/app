namespace app.web.core
{
    public interface IFindRequestProcessors
    {
        IProcessOneRequest get_the_command_that_can_handle(IContainRequestDetails the_request);
    }
}