using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace app.web.core.aspnet
{
    public class HttpResponseFactory : ICreateControllerRequests
    {
        public object create_from(HttpContext new_http_context)
        {
            // perform transformatino of HttpContext into our response object
            return new object();
        }
    }
}
