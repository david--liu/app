using System;
using System.Collections;
using System.Web;

namespace app.web.core.aspnet
{
    public class ASPNetHandler : IHttpHandler
    {
        IProcessWebRequests front_controller;
        ICreateControllerRequests request_factory;

        public ASPNetHandler(IProcessWebRequests front_controller, ICreateControllerRequests request_factory)
        {
            this.front_controller = front_controller;
            this.request_factory = request_factory;
        }

        public void ProcessRequest(HttpContext context)
        {
            var request = request_factory.create_from(context);
            front_controller.process(request);
            
        }

        public bool IsReusable
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}