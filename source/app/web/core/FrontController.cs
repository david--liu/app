namespace app.web.core
{
    public class FrontController : IProcessWebRequests
    {
        IFindRequestProcessors processor_registry;

        public FrontController(IFindRequestProcessors processor_registry)
        {
            this.processor_registry = processor_registry;
        }

        public void process(IContainRequestDetails a_new_request)
        {
            processor_registry.get_the_command_that_can_handle(a_new_request).process(a_new_request);
        }
    }
}