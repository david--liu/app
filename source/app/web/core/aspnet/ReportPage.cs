using System.Web.UI;

namespace app.web.core.aspnet
{
    public class ReportPage<ReportModel> : Page,IDisplayA<ReportModel>
    {
        public ReportModel model { get; set; }
    }
}