using app.web.core;

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

        public void process(IContainRequestDetails request)
        {
            display_engine.display(query.run_using(request));
        }
    }
}