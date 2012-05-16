using System.Web;

namespace app.web.core.aspnet
{
    public class ASPNetHandler : IHttpHandler
    {
        IProcessWebRequests front_controller;

        public ASPNetHandler(IProcessWebRequests front_controller)
        {
            this.front_controller = front_controller;
        }

        public void ProcessRequest(HttpContext context)
        {
            front_controller.process();
        }

        public bool IsReusable
        {
            get { throw new System.NotImplementedException(); }
        }
    }
}