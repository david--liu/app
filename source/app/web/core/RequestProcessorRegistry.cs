using System.Collections.Generic;
using System.Linq;

namespace app.web.core
{
    public class RequestProcessorRegistry : IFindRequestProcessors
    {

        IEnumerable<IProcessOneRequest> all_the_possible_processors;
        CreateMissingRequestProcessor_Behaviour create_special_case;

        public RequestProcessorRegistry(IEnumerable<IProcessOneRequest> all_the_possible_processors, CreateMissingRequestProcessor_Behaviour create_special_case)
        {
            this.all_the_possible_processors = all_the_possible_processors;
            this.create_special_case = create_special_case;
        }

        public IProcessOneRequest get_the_command_that_can_handle(IContainRequestDetails the_request)
        {
            var process_one_request = all_the_possible_processors.FirstOrDefault(processor => processor.can_process(the_request));
            return process_one_request ?? create_special_case.Invoke();
        }
    }
}
