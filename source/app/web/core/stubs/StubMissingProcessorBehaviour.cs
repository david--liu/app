using System;

namespace app.web.core.stubs
{
    public class StubMissingProcessorBehaviour
    {
        public static IProcessOneRequest create()
        {
            return new StubMissingProcessor();
        }

        class StubMissingProcessor : IProcessOneRequest
        {
            public void process(IContainRequestDetails request)
            {
                throw new NotImplementedException();
            }

            public bool can_process(IContainRequestDetails request)
            {
                return false;
            }
        }
    }
}