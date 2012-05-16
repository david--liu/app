namespace app.web.core
{
    public class FrontController : IProcessWebRequests
    {
        IFindRequestProcessors command_registry;

        public FrontController(IFindRequestProcessors command_registry)
        {
            this.command_registry = command_registry;
        }

        public void process(IContainRequestDetails a_new_request)
        {
            var the_command_that_can_handle = command_registry.get_the_command_that_can_handle(a_new_request);
            the_command_that_can_handle.process(a_new_request);
        }
    }
}