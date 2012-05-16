using System.Web;

namespace app.web.core
{
    public interface ICreateRequests
    {
        IContainRequestDetails create_request_from(HttpContext new_http_context);
    }
}