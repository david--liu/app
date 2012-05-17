using System;
using System.Web;

namespace app.web.core.stubs
{
    public class StubRequestFactory : ICreateRequests
    {
        public IContainRequestDetails create_request_from(HttpContext new_http_context)
        {
            return new StubRequest();
        }

        class StubRequest : IContainRequestDetails
        {
            public InputModel map<InputModel>()
            {
                return Activator.CreateInstance<InputModel>();
            }
        }
    }
}