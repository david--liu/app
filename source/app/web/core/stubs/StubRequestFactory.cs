using System.Web;
using app.web.application.catalogbrowsing;

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
                object item = new DepartmentSelection();
                return (InputModel) item;
            }
        }
    }
}