using System.Web;

namespace app.web.core.aspnet
{
    public class ASPNetHandler : IHttpHandler
    {
        IProcessWebRequests front_controller;
        ICreateRequests request_factory;

        public ASPNetHandler(IProcessWebRequests front_controller, ICreateRequests request_factory)
        {
            this.front_controller = front_controller;
            this.request_factory = request_factory;
        }

        public ASPNetHandler()
        {
        }

        public void ProcessRequest(HttpContext context)
        {
            var request = request_factory.create_request_from(context);
            front_controller.process(request);
        }

        public bool IsReusable
        {
            get { return true; }
        }
    }
}