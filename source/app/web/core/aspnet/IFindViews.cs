using System.Web;

namespace app.web.core.aspnet
{
    public interface IFindViews
    {
        IHttpHandler find_view_that_can_display<ReportModel>(ReportModel model);
    }
}