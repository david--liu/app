using System;
using System.Web;

namespace app.web.core.aspnet
{
    public class ASPNetHandler : IHttpHandler
    {
        IProcessWebRequests front_controller;
        ICreateControllerRequests controller_factory;

        public ASPNetHandler(IProcessWebRequests front_controller, ICreateControllerRequests controller_factory)
        {
            this.front_controller = front_controller;
            this.controller_factory = controller_factory;
        }

        public void ProcessRequest(HttpContext context)
        {
            var response = controller_factory.create_from(context);
            front_controller.process(response);
        }

        public bool IsReusable
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}