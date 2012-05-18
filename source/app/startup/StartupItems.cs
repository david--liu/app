using System;
using app.infrastructure.containers.simple;
using app.web.core;

namespace app.startup
{
    public class StartupItems
    {
        public class ExceptionFactories
        {
            public static CreateMissingRequestProcessor_Behaviour missing_request_processor =
                () => new StubMissingRequestProcessor();

            public static FactoryNotRegisteredExceptionFactory_Behaviour factory_not_registered =
                type => new Exception(string.Format("There is no factory that can create an {0}", type.Name));

            public static ItemCreationExceptionFactory_Behaviour item_creation_exception =
                (type, inner_exception) =>
                    new Exception(string.Format("Failed to create an item of type #{0}", type.Name), inner_exception);
        }
    }

    public class StubMissingRequestProcessor : IProcessOneRequest
    {
        public void process(IContainRequestDetails request)
        {
        }

        public bool can_process(IContainRequestDetails request)
        {
            return false;
        }
    }
}