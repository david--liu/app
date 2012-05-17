using System.Collections.Generic;
using System.Linq;
using app.web.core.stubs;

namespace app.web.core
{
    public class RequestProcessorRegistry : IFindRequestProcessors
    {
        IEnumerable<IProcessOneRequest> all_the_possible_processors;
        CreateMissingRequestProcessor_Behaviour special_case_factory;

        public RequestProcessorRegistry(IEnumerable<IProcessOneRequest> all_the_possible_processors,
                                        CreateMissingRequestProcessor_Behaviour special_case_factory)
        {
            this.all_the_possible_processors = all_the_possible_processors;
            this.special_case_factory = special_case_factory;
        }

        public RequestProcessorRegistry():this(new StubSetOfProcessors(),StubMissingProcessorBehaviour.create)
        {
        }

        public IProcessOneRequest get_the_command_that_can_handle(IContainRequestDetails the_request)
        {
            return all_the_possible_processors.FirstOrDefault(processor => processor.can_process(the_request)) ??
                special_case_factory();
        }
    }
}