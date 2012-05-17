using System.Web;

namespace app.web.core.aspnet
{
    public class WebFormDisplayEngine : IDisplayInformation
    {
        IFindViews view_registry;
        GetTheCurrentContext_Behaviour current_context_resolution;

        public WebFormDisplayEngine(IFindViews view_registry, GetTheCurrentContext_Behaviour current_context_resolution)
        {
            this.view_registry = view_registry;
            this.current_context_resolution = current_context_resolution;
        }

        public WebFormDisplayEngine():this(new WebFormViewRegistry(),
                                           () => HttpContext.Current)
        {
        }

        public void display<ReportModel>(ReportModel model)
        {
            //            view_registry.find_view_that_can_display(model).ProcessRequest(HttpContext.Current);
            view_registry.find_view_that_can_display(model).ProcessRequest(current_context_resolution());
        }
    }
}