using System.Web;

namespace app.web.core.aspnet
{
    public interface IDisplayA<ReportModel> : IHttpHandler
    {
        ReportModel model { get; set; }
    }
}