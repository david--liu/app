using System.Web;

namespace app.web.core
{
    public interface ICreateControllerRequests
    {
        object create_from(HttpContext new_http_context);
    }
}