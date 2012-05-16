namespace app.web.core
{
    public class FrontController : IProcessWebRequests{
        IFindRequestProcessors request_processor_locator;

        public FrontController(IFindRequestProcessors requestProcessorLocator){
            request_processor_locator = requestProcessorLocator;
        }

        public void process(IContainRequestDetails a_new_request){
            request_processor_locator.get_the_command_that_can_handle(a_new_request).process(a_new_request);

        }
    }
}