using System.Collections.Generic;
using System.Linq;

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
            return all_the_possible_processors.First(processor => processor.can_process(the_request));
        }
    }
}