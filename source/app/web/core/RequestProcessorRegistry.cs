using System.Collections.Generic;

namespace app.web.core
{
    public class RequestProcessorRegistry : IFindRequestProcessors
    {

        IEnumerable<IProcessOneRequest> all_the_possible_processors;

        public RequestProcessorRegistry(IEnumerable<IProcessOneRequest> all_the_possible_processors)
        {
            this.all_the_possible_processors = all_the_possible_processors;
        }

        public IProcessOneRequest get_the_command_that_can_handle(IContainRequestDetails the_request)
        {
            foreach (var processor in all_the_possible_processors)
            {
                if (processor.can_process(the_request))
                    return processor;
            }

            return null;
        }
    }
}