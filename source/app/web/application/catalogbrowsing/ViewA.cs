using app.web.core;
using app.web.core.aspnet;

namespace app.web.application.catalogbrowsing
{
    public class ViewA<ReportModel> : ISupportAFeature
    {
        IFetchAn<ReportModel> query;
        IDisplayInformation display_engine;

        public ViewA(IFetchAn<ReportModel> query, IDisplayInformation display_engine)
        {
            this.query = query;
            this.display_engine = display_engine;
        }

        public ViewA(IFetchAn<ReportModel> query):this(query,new WebFormDisplayEngine())
        {
        }

        public void process(IContainRequestDetails request)
        {
            display_engine.display(query.run_using(request));
        }
    }
}